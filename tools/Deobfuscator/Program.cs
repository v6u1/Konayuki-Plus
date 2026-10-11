using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;

// KonayukiPlus.exe is protected with Obfuscar (HideStrings + UseKoreanNames) and
// bundles its dependencies with Costura.Fody. This tool undoes both.
//
//   analyze <in.exe> <outdir>   report what is obfuscated, dump the hidden strings
//                               to <outdir>/strings.tsv and the Costura-embedded
//                               assemblies to <outdir>/costura/
//   clean <in.exe> <out.exe>    inline the hidden strings, rename the Korean
//                               identifiers (recovering WinForms names from the
//                               designer code where possible) and write a clean
//                               assembly plus <out>.map.csv (old -> new names)

switch (args.FirstOrDefault())
{
    case "analyze" when args.Length == 3:
        Analyzer.Run(Load(args[1]), Directory.CreateDirectory(args[2]).FullName);
        return 0;
    case "clean" when args.Length == 3:
        Cleaner.Run(Load(args[1]), Path.GetFullPath(args[2]));
        return 0;
    case "resources" when args.Length == 3:
    {
        var module = Load(args[1]);
        var outDir = Directory.CreateDirectory(args[2]).FullName;
        int n = 0;
        foreach (var res in module.Resources.OfType<EmbeddedResource>().Where(r => r.Name.String.EndsWith(".resources")))
        {
            var path = Path.Combine(outDir, res.Name.String);
            using var fs = File.Create(path);
            res.CreateReader().AsStream().CopyTo(fs);
            Console.WriteLine($"  {res.Name}  ({res.Length} bytes)");
            n++;
        }
        Console.WriteLine($"[resources] {n} compiled .resources extracted to {outDir}");
        return 0;
    }
    default:
        Console.Error.WriteLine("usage: Deobfuscator analyze <in.exe> <outdir>");
        Console.Error.WriteLine("       Deobfuscator clean <in.exe> <out.exe>");
        return 1;
}

static ModuleDefMD Load(string path) => ModuleDefMD.Load(path, ModuleDef.CreateModuleContext());

static class Names
{
    // Obfuscar's UseKoreanNames emits Hangul identifiers; anything non-ASCII is ours to rename.
    public static bool IsObfuscated(string? name) => !string.IsNullOrEmpty(name) && name.Any(c => c > 0x7E);

    public static string Escape(string s) => s.Replace("\\", "\\\\").Replace("\t", "\\t").Replace("\r", "\\r").Replace("\n", "\\n");
}

/// <summary>Obfuscar's HideStrings class: one XOR-encrypted UTF-8 blob plus one getter method per string.</summary>
sealed class HiddenStrings
{
    public required TypeDef Type { get; init; }
    public required Dictionary<MethodDef, (int Index, string Value)> Getters { get; init; }
    public int Key { get; init; }

    public static HiddenStrings? Find(ModuleDef module)
    {
        var type = module.Types.FirstOrDefault(t => t.Namespace.String.StartsWith("<PrivateImplementationDetails>{"));
        if (type is null)
            return null;

        var cctor = type.FindStaticConstructor() ?? throw new InvalidDataException("string class has no static constructor");
        var ins = cctor.Body.Instructions;
        var blob = ins.Where(i => i.OpCode.Code == Code.Ldtoken).Select(i => i.Operand).OfType<FieldDef>().Single(f => f.HasFieldRVA);

        // The static constructor decrypts in place: data[i] = (byte)(data[i] ^ i ^ key)
        int key = 0xAA;
        for (int i = 1; i < ins.Count; i++)
        {
            if (ins[i].OpCode.Code == Code.Xor && ins[i - 1].IsLdcI4())
            {
                key = ins[i - 1].GetLdcI4Value() & 0xFF;
                break;
            }
        }
        var data = (byte[])blob.InitialValue.Clone();
        for (int i = 0; i < data.Length; i++)
            data[i] = (byte)(data[i] ^ i ^ key);

        // Every getter is: return cache[index] ?? helper(index, offset, length);
        var helper = type.Methods.Single(m => m.IsStatic && m.MethodSig.Params.Count == 3 && m.ReturnType.ElementType == ElementType.String);
        var utf8 = new UTF8Encoding(false, throwOnInvalidBytes: true);
        var getters = new Dictionary<MethodDef, (int, string)>();
        foreach (var m in type.Methods)
        {
            if (m == helper || !m.HasBody || m.MethodSig.Params.Count != 0 || m.ReturnType.ElementType != ElementType.String)
                continue;
            var body = m.Body.Instructions;
            int call = body.ToList().FindIndex(i => i.OpCode.Code == Code.Call && i.Operand == helper);
            if (call < 3)
                throw new InvalidDataException($"unexpected string getter body in {m.Name}");
            int index = body[call - 3].GetLdcI4Value();
            int offset = body[call - 2].GetLdcI4Value();
            int length = body[call - 1].GetLdcI4Value();
            getters[m] = (index, utf8.GetString(data, offset, length));
        }
        return new HiddenStrings { Type = type, Getters = getters, Key = key };
    }
}

static class Costura
{
    /// <summary>Costura stores each dependency as a raw-deflate resource named costura.&lt;name&gt;.dll.compressed.</summary>
    public static List<(string File, string Assembly)> Extract(ModuleDef module, string dir)
    {
        Directory.CreateDirectory(dir);
        var result = new List<(string, string)>();
        foreach (var res in module.Resources.OfType<EmbeddedResource>().Where(r => r.Name.String.StartsWith("costura.")))
        {
            var fileName = res.Name.String["costura.".Length..].Replace(".compressed", "");
            var path = Path.Combine(dir, fileName);
            using (var input = new DeflateStream(res.CreateReader().AsStream(), CompressionMode.Decompress))
            using (var output = File.Create(path))
                input.CopyTo(output);
            string asm = "-";
            if (fileName.EndsWith(".dll"))
            {
                try { asm = AssemblyName.GetAssemblyName(path).FullName; }
                catch (Exception e) { asm = "(not a .NET assembly: " + e.GetType().Name + ")"; }
            }
            result.Add((fileName, asm));
        }
        return result;
    }
}

static class Analyzer
{
    public static void Run(ModuleDefMD module, string outDir)
    {
        var types = module.GetTypes().ToList();
        Console.WriteLine($"== {module.Assembly.FullName}  runtime={module.RuntimeVersion}");

        // --- hidden strings ---
        var hidden = HiddenStrings.Find(module);
        if (hidden is null)
        {
            Console.WriteLine("[strings] no Obfuscar string class found");
        }
        else
        {
            // where is each string used?
            var usage = new Dictionary<MethodDef, List<string>>();
            foreach (var t in types.Where(t => t != hidden.Type))
                foreach (var m in t.Methods.Where(m => m.HasBody))
                    foreach (var i in m.Body.Instructions)
                        if (i.OpCode.Code == Code.Call && i.Operand is MethodDef g && hidden.Getters.ContainsKey(g))
                            (usage.TryGetValue(g, out var l) ? l : usage[g] = new()).Add($"{t.Name}.{m.Name}");

            var lines = hidden.Getters.OrderBy(kv => kv.Value.Index).Select(kv =>
                $"{kv.Value.Index}\t{Names.Escape(kv.Value.Value)}\t{string.Join(", ", usage.GetValueOrDefault(kv.Key) ?? new List<string>())}");
            File.WriteAllLines(Path.Combine(outDir, "strings.tsv"), lines, new UTF8Encoding(false));
            Console.WriteLine($"[strings] key=0x{hidden.Key:X2}, {hidden.Getters.Count} strings decrypted -> strings.tsv");
            Console.WriteLine("[strings] network-looking strings:");
            foreach (var kv in hidden.Getters.OrderBy(kv => kv.Value.Index))
            {
                var v = kv.Value.Value;
                if (v.Contains("://") || v.Contains("www.") || v.Contains(".moe") || v.Contains(".php") || v.Contains(".json") || v.Contains("api"))
                    Console.WriteLine($"  #{kv.Value.Index,-5} {Names.Escape(v),-90} <- {string.Join(", ", usage.GetValueOrDefault(kv.Key) ?? new List<string>())}");
            }
        }

        // --- what is obfuscated ---
        var named = types.Where(t => hidden is null || (t != hidden.Type && t.DeclaringType != hidden.Type)).ToList();
        var methods = named.SelectMany(t => t.Methods).ToList();
        Console.WriteLine($"[names] types {named.Count(t => Names.IsObfuscated(t.Name))}/{named.Count}, " +
                          $"methods {methods.Count(m => Names.IsObfuscated(m.Name))}/{methods.Count}, " +
                          $"fields {named.SelectMany(t => t.Fields).Count(f => Names.IsObfuscated(f.Name))}/{named.Sum(t => t.Fields.Count)}, " +
                          $"properties {named.SelectMany(t => t.Properties).Count(p => Names.IsObfuscated(p.Name))}/{named.Sum(t => t.Properties.Count)}, " +
                          $"events {named.SelectMany(t => t.Events).Count(e => Names.IsObfuscated(e.Name))}/{named.Sum(t => t.Events.Count)}");
        var virt = methods.Where(m => m.IsVirtual && Names.IsObfuscated(m.Name)).ToList();
        Console.WriteLine($"[names] obfuscated virtual methods: {virt.Count} (overrides: {virt.Count(m => !m.IsNewSlot)}, in interfaces: {virt.Count(m => m.DeclaringType.IsInterface)})");
        foreach (var m in virt.Take(15))
            Console.WriteLine($"         {m.DeclaringType.Name}.{m.Name} {m.MethodSig} newslot={m.IsNewSlot} abstract={m.IsAbstract}");
        var namespaces = named.Where(t => !t.IsNested).GroupBy(t => t.Namespace.String).Select(g => $"'{g.Key}'({g.Count()})");
        Console.WriteLine($"[names] namespaces: {string.Join(", ", namespaces)}");

        var compilerGenerated = named.Where(t => t.CustomAttributes.IsDefined("System.Runtime.CompilerServices.CompilerGeneratedAttribute")).ToList();
        Console.WriteLine($"[names] compiler-generated types: {compilerGenerated.Count}, obfuscated: {compilerGenerated.Count(t => Names.IsObfuscated(t.Name))}; " +
                          $"sample: {string.Join(", ", compilerGenerated.Take(8).Select(t => t.Name.String))}");

        Console.WriteLine("[types] base types of top-level types:");
        foreach (var g in named.Where(t => !t.IsNested && !t.IsGlobalModuleType).GroupBy(t => t.IsEnum ? "<enum>" : t.IsInterface ? "<interface>" : t.BaseType?.FullName ?? "<none>").OrderByDescending(g => g.Count()))
            Console.WriteLine($"         {g.Count(),3} x {g.Key}");

        var moduleCctor = module.GlobalType.FindStaticConstructor();
        if (moduleCctor is not null)
            Console.WriteLine($"[module] <Module>.cctor calls: {string.Join(", ", moduleCctor.Body.Instructions.Where(i => i.OpCode.FlowControl == FlowControl.Call).Select(i => i.Operand?.ToString()))}");

        Console.WriteLine("[resources]");
        foreach (var r in module.Resources)
            Console.WriteLine($"         {r.Name} ({(r as EmbeddedResource)?.Length ?? 0} bytes)");

        Console.WriteLine("[costura] embedded assemblies:");
        foreach (var (file, asm) in Costura.Extract(module, Path.Combine(outDir, "costura")))
            Console.WriteLine($"         {file,-45} {asm}");

        Console.WriteLine("[refs] assembly references:");
        foreach (var r in module.GetAssemblyRefs())
            Console.WriteLine($"         {r.FullName}");
    }
}

static class Cleaner
{
    public static void Run(ModuleDefMD module, string outPath)
    {
        InlineStrings(module);

        var renamer = new Renamer(module);
        renamer.Run();
        File.WriteAllLines(Path.ChangeExtension(outPath, ".map.csv"), renamer.Map, new UTF8Encoding(false));

        foreach (var attrs in new[] { module.Assembly.CustomAttributes, module.CustomAttributes })
            foreach (var ca in attrs.Where(a => a.TypeFullName == "System.Runtime.CompilerServices.SuppressIldasmAttribute").ToList())
                attrs.Remove(ca);

        var options = new ModuleWriterOptions(module);
        options.MetadataOptions.Flags |= MetadataFlags.KeepOldMaxStack;
        module.Write(outPath, options);
        Console.WriteLine($"[write] {outPath}");
    }

    static void InlineStrings(ModuleDef module)
    {
        var hidden = HiddenStrings.Find(module) ?? throw new InvalidDataException("no Obfuscar string class found");
        int inlined = 0;
        foreach (var t in module.GetTypes().Where(t => !IsInside(t, hidden.Type)))
        {
            foreach (var m in t.Methods.Where(m => m.HasBody))
            {
                foreach (var i in m.Body.Instructions)
                {
                    if (i.OpCode.Code == Code.Call && i.Operand is MethodDef g && hidden.Getters.TryGetValue(g, out var s))
                    {
                        // call string Getter() and ldstr have the same stack effect
                        i.OpCode = OpCodes.Ldstr;
                        i.Operand = s.Value;
                        inlined++;
                    }
                }
            }
        }

        int leftovers = module.GetTypes().Where(t => !IsInside(t, hidden.Type))
            .SelectMany(t => t.Methods).Where(m => m.HasBody).SelectMany(m => m.Body.Instructions)
            .Count(i => i.Operand == hidden.Type || (i.Operand is IMemberRef r && r.DeclaringType is TypeDef dt && IsInside(dt, hidden.Type)));
        if (leftovers > 0)
            throw new InvalidDataException($"{leftovers} references to the string class remain");
        module.Types.Remove(hidden.Type);
        Console.WriteLine($"[strings] {hidden.Getters.Count} strings, {inlined} call sites inlined, string class removed");
    }

    static bool IsInside(TypeDef t, TypeDef outer)
    {
        for (var d = t; d is not null; d = d.DeclaringType)
            if (d == outer)
                return true;
        return false;
    }
}

/// <summary>
/// Gives every Hangul identifier an ASCII name. WinForms names come back from the
/// designer code (this.btnStart.Name = "btnStart"), event handlers are named after
/// the control and event they are wired to, P/Invoke methods after their entry point.
/// Everything else gets a de4dot-style placeholder (Class3, method_2, string_0).
/// Compiler-generated types and members get compiler-style names so ILSpy can
/// fold closures, state machines and auto-properties back into C#.
/// </summary>
sealed class Renamer
{
    const string RootNamespace = "KonayukiPlus";
    const string CompilerGeneratedAttribute = "System.Runtime.CompilerServices.CompilerGeneratedAttribute";
    static readonly Regex Identifier = new("^[A-Za-z_][A-Za-z0-9_]*$");
    static readonly string[] DesignerBases =
    {
        "System.Windows.Forms.Form", "MetroFramework.Forms.MetroForm",
        "System.Windows.Forms.UserControl", "MetroFramework.Controls.MetroUserControl",
    };
    static readonly HashSet<string> Keywords = new()
    {
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const",
        "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern",
        "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface",
        "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override",
        "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
        "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof",
        "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while",
    };

    public List<string> Map { get; } = new() { "kind,owner,old,new" };

    readonly ModuleDef module;
    readonly List<TypeDef> types;
    readonly Dictionary<string, int> counters = new();
    readonly Dictionary<object, HashSet<string>> typeScopes = new();
    readonly Dictionary<string, string> renamedTypes = new(); // old full name -> new full name
    readonly HashSet<TypeDef> vsGenerated = new();

    public Renamer(ModuleDef module)
    {
        this.module = module;
        types = module.GetTypes().ToList();
    }

    public void Run()
    {
        var oldNames = types.ToDictionary(t => t, t => t.FullName);
        foreach (var t in types.Where(t => !Obf(t.Name)))
            ScopeOf(t).Add(t.Name.String);
        foreach (var t in types.Where(t => !t.IsGlobalModuleType))
            RenameType(t);
        foreach (var t in types)
            if (oldNames[t] != t.FullName)
                renamedTypes[oldNames[t]] = t.FullName;

        foreach (var t in types)
            RenameMembers(t);
        RenameResources();
        CheckInterfaces();

        int left = types.Count(t => Obf(t.Name)) + types.Sum(t => t.Methods.Count(m => Obf(m.Name)) + t.Fields.Count(f => Obf(f.Name)));
        Console.WriteLine($"[names] {Map.Count - 1} identifiers renamed, {left} obfuscated names left");
    }

    // ---------------- types ----------------

    void RenameType(TypeDef t)
    {
        if (!t.IsNested && Obf(t.Namespace))
            t.Namespace = RootNamespace;
        if (!Obf(t.Name))
            return;
        var name = TypeName(t);
        if (name == "<PrivateImplementationDetails>")
            t.Namespace = "";
        Rename(t, Unique(name, ScopeOf(t)), "type", t.DeclaringType?.FullName ?? t.Namespace.String);
    }

    string TypeName(TypeDef t)
    {
        if (module.EntryPoint?.DeclaringType == t)
            return "Program";
        if (module.GlobalType.FindStaticConstructor()?.Body.Instructions.Any(i => i.Operand is MethodDef m && m.DeclaringType == t) == true)
            return "CosturaAssemblyLoader";
        // Visual Studio's Properties.Resources / Properties.Settings are [CompilerGenerated] too, but are ordinary code
        if (!t.IsNested && t.Properties.Any(p => p.Name.String == "ResourceManager" && p.GetMethod is { IsStatic: true }))
        {
            vsGenerated.Add(t);
            t.Namespace = RootNamespace + ".Properties";
            return "Resources";
        }
        if (!t.IsNested && InheritsFrom(t, "System.Configuration.ApplicationSettingsBase"))
        {
            vsGenerated.Add(t);
            t.Namespace = RootNamespace + ".Properties";
            return "Settings";
        }
        if (t.DeclaringType?.Name.String == "<PrivateImplementationDetails>" && t.IsValueType && t.ClassLayout is not null)
            return "__StaticArrayInitTypeSize=" + t.ClassSize;
        if (IsCG(t))
        {
            if (!t.IsNested)
            {
                if (t.HasGenericParameters)
                    return "<>f__AnonymousType" + Next("anon");
                if (t.NestedTypes.Count > 0 || t.Fields.Any(f => f.HasFieldRVA))
                    return "<PrivateImplementationDetails>";
                return "Class" + Next("Class");
            }
            return IsStateMachine(t) ? "<>d__" + Next("sm") : "<>c__DisplayClass" + Next("dc");
        }
        if (t.IsEnum)
            return "Enum" + Next("Enum");
        if (t.IsInterface)
            return "IInterface" + Next("Interface");
        if (t.IsValueType)
            return "Struct" + Next("Struct");
        if (DesignerSelfName(t) is { } designerName)
            return designerName;
        if (InheritsFrom(t, "System.MulticastDelegate"))
            return "Delegate" + Next("Delegate");
        if (InheritsFrom(t, "System.Configuration.ApplicationSettingsBase"))
            return "Settings";
        if (t.Properties.Any(p => p.Name.String == "ResourceManager" && p.GetMethod is { IsStatic: true }))
            return "Resources";
        if (InheritsFrom(t, "System.Security.Cryptography.HashAlgorithm"))
            return UsesConstant(t, unchecked((int)0xEDB88320)) ? "Crc32" : "HashAlgorithm" + Next("Hash");
        var pinvokes = t.Methods.Where(m => m.IsPinvokeImpl && m.ImplMap is not null).ToList();
        if (pinvokes.Count > 0 && pinvokes.Count * 2 >= t.Methods.Count)
        {
            var dll = pinvokes.GroupBy(m => m.ImplMap.Module.Name.String).OrderByDescending(g => g.Count()).First().Key;
            return "Native_" + Regex.Replace(Path.GetFileNameWithoutExtension(dll), "[^A-Za-z0-9]", "_");
        }
        if (IsDesignerType(t))
            return "Form" + Next("Form");
        if (InheritsFrom(t, "System.Windows.Forms.Control"))
            return "Control" + Next("Control");
        if (InheritsFrom(t, "System.EventArgs"))
            return "EventArgs" + Next("EventArgs");
        if (InheritsFrom(t, "System.Exception"))
            return "Exception" + Next("Exception");
        if (InheritsFrom(t, "System.Attribute"))
            return "Attribute" + Next("Attribute");
        return "Class" + Next("Class");
    }

    /// <summary>Forms set their own Name in InitializeComponent: this.Name = "frmMain".</summary>
    static string? DesignerSelfName(TypeDef t)
    {
        if (InitializeComponent(t) is not { } init)
            return null;
        var ins = init.Body.Instructions;
        for (int i = 0; i + 2 < ins.Count; i++)
        {
            if (ins[i].OpCode.Code == Code.Ldarg_0 && ins[i + 1].OpCode.Code == Code.Ldstr && IsCall(ins[i + 2], "set_Name")
                && IsValid((string)ins[i + 1].Operand))
                return (string)ins[i + 1].Operand;
        }
        return null;
    }

    // ---------------- members ----------------

    void RenameMembers(TypeDef t)
    {
        var owner = t.FullName;
        var used = new HashSet<string>(
            t.Fields.Select(f => f.Name.String)
                .Concat(t.Methods.Select(m => m.Name.String))
                .Concat(t.Properties.Select(p => p.Name.String))
                .Concat(t.Events.Select(e => e.Name.String))
                .Where(n => !Names.IsObfuscated(n)));
        var local = new Dictionary<string, int>();
        bool inCompilerGenerated = (IsCG(t) || AncestorIsCG(t)) && !vsGenerated.Contains(t);
        bool isPrivateImplementationDetails = t.Name.String == "<PrivateImplementationDetails>";

        var designerFields = DesignerFieldNames(t);
        var backingFields = BackingFields(t);
        foreach (var f in t.Fields.Where(f => Obf(f.Name)).ToList())
        {
            string name;
            var fieldType = f.FieldType.FullName;
            if (designerFields.TryGetValue(f, out var designerName))
                name = designerName;
            else if (vsGenerated.Contains(t) && fieldType == "System.Resources.ResourceManager")
                name = "resourceMan";
            else if (vsGenerated.Contains(t) && fieldType == "System.Globalization.CultureInfo")
                name = "resourceCulture";
            else if (vsGenerated.Contains(t) && f.IsStatic && fieldType == t.FullName)
                name = "defaultInstance";
            else if (inCompilerGenerated)
                name = CompilerGeneratedFieldName(t, f, local);
            else if (t.IsEnum)
                name = "Value" + Count(local, "Value");
            else if (backingFields.TryGetValue(f, out var property))
                name = $"<{property}>k__BackingField";
            else if (IsCG(f) && IsDelegate(f.FieldType))
                name = "CS$<>9__CachedAnonymousMethodDelegate" + (Count(local, "cache") + 1);
            else if (f.FieldType.FullName == "System.ComponentModel.IContainer")
                name = "components";
            else
            {
                var word = TypeWord(f.FieldType);
                name = word + "_" + Count(local, word);
            }
            Rename(f, Unique(name, used), "field", owner);
        }

        var init = InitializeComponent(t);
        var handlers = EventHandlerNames(t);
        foreach (var m in t.Methods.Where(m => Obf(m.Name)).ToList())
        {
            string name;
            if (m == module.EntryPoint)
                name = "Main";
            else if (isPrivateImplementationDetails && m.ReturnType.ElementType == ElementType.U4
                     && m.MethodSig.Params.Count == 1 && m.MethodSig.Params[0].ElementType == ElementType.String)
                name = "ComputeStringHash"; // ILSpy needs this name to rebuild switch-on-string
            else if (m == init)
                name = "InitializeComponent";
            else if (m.IsPinvokeImpl && m.ImplMap is { } map && IsValid(map.Name.String))
                name = map.Name.String;
            else if (handlers.TryGetValue(m, out var handler))
                name = handler;
            else if (inCompilerGenerated || IsCG(m))
                name = "<>b__" + Count(local, "<>b__");
            else
                name = m.IsStatic ? "smethod_" + Count(local, "smethod_") : "method_" + Count(local, "method_");
            Rename(m, Unique(name, used), "method", owner);
        }

        RenameGenericParameters(t.GenericParameters, owner);
        foreach (var m in t.Methods)
            RenameGenericParameters(m.GenericParameters, owner + "::" + m.Name);
    }

    void RenameGenericParameters(IList<GenericParam> parameters, string owner)
    {
        for (int i = 0; i < parameters.Count; i++)
        {
            if (!Obf(parameters[i].Name))
                continue;
            var name = parameters.Count == 1 ? "T" : "T" + (i + 1);
            Map.Add($"generic,{owner},{parameters[i].Name},{name}");
            parameters[i].Name = name;
        }
    }

    /// <summary>this.&lt;field&gt;.Name = "btnStart" in InitializeComponent gives the field its original name back.</summary>
    static Dictionary<FieldDef, string> DesignerFieldNames(TypeDef t)
    {
        var result = new Dictionary<FieldDef, string>();
        if (InitializeComponent(t) is not { } init)
            return result;
        var ins = init.Body.Instructions;
        for (int i = 1; i + 2 < ins.Count; i++)
        {
            if (ins[i - 1].OpCode.Code == Code.Ldarg_0 && ins[i].OpCode.Code == Code.Ldfld && ins[i].Operand is FieldDef f && f.DeclaringType == t
                && ins[i + 1].OpCode.Code == Code.Ldstr && IsCall(ins[i + 2], "set_Name") && IsValid((string)ins[i + 1].Operand))
                result.TryAdd(f, (string)ins[i + 1].Operand);
        }
        return result;
    }

    /// <summary>this.btnStart.Click += new EventHandler(this.X) names X btnStart_Click (X must not be a lambda).</summary>
    static Dictionary<MethodDef, string> EventHandlerNames(TypeDef t)
    {
        var result = new Dictionary<MethodDef, string>();
        foreach (var m in t.Methods.Where(m => m.HasBody))
        {
            var ins = m.Body.Instructions;
            for (int i = 2; i + 2 < ins.Count; i++)
            {
                if (ins[i].OpCode.Code != Code.Ldftn || ins[i].Operand is not MethodDef h || h.DeclaringType != t || !Obf(h.Name) || IsCG(h) || result.ContainsKey(h))
                    continue;
                if (ins[i - 1].OpCode.Code != Code.Ldarg_0 || ins[i + 1].OpCode.Code != Code.Newobj || ins[i + 2].Operand is not IMethod adder || !adder.Name.String.StartsWith("add_"))
                    continue;
                string? source = ins[i - 2].OpCode.Code == Code.Ldfld && ins[i - 2].Operand is IField f ? f.Name.String
                               : ins[i - 2].OpCode.Code == Code.Ldarg_0 ? t.Name.String
                               : null;
                if (source is not null && !Names.IsObfuscated(source))
                    result[h] = $"{source}_{adder.Name.String["add_".Length..]}";
            }
        }
        return result;
    }

    /// <summary>Auto-property getters are just ldarg.0; ldfld F; ret.</summary>
    static Dictionary<FieldDef, string> BackingFields(TypeDef t)
    {
        var result = new Dictionary<FieldDef, string>();
        foreach (var p in t.Properties)
        {
            var body = p.GetMethod?.Body?.Instructions;
            if (body is null || body.Count > 3)
                continue;
            if (body.FirstOrDefault(i => i.OpCode.Code is Code.Ldfld or Code.Ldsfld)?.Operand is FieldDef f && f.DeclaringType == t && IsCG(f))
                result.TryAdd(f, p.Name.String);
        }
        return result;
    }

    /// <summary>Names the C# compiler would have used, so ILSpy recognises closures and state machines.</summary>
    string CompilerGeneratedFieldName(TypeDef t, FieldDef f, Dictionary<string, int> local)
    {
        var sig = f.FieldType.RemovePinnedAndModifiers();
        var def = sig.ToTypeDefOrRef()?.ResolveTypeDef();
        var full = sig.FullName;
        if (def is not null && def == OuterNonCG(t))
            return "<>4__this";
        if (f.IsStatic && def == t)
            return "<>9";
        if (def is not null && def != t && IsCG(def))
            return "CS$<>8__locals" + (Count(local, "locals") + 1);
        if (f.IsStatic && IsDelegate(sig))
            return "<>9__" + Count(local, "<>9__");
        if (full.StartsWith("System.Runtime.CompilerServices.Async") && full.Contains("MethodBuilder"))
            return "<>t__builder";
        if (full.Contains("Awaiter"))
            return "<>u__" + (Count(local, "<>u__") + 1);
        var word = LocalName(TypeWord(sig));
        if (IsStateMachine(t))
        {
            if (f == StateField(t))
                return "<>1__state";
            if (f == CurrentField(t))
                return "<>2__current";
            return $"<{word}>5__{Count(local, "5__") + 1}";
        }
        // captured locals of a closure: ILSpy uses these as variable names
        int n = Count(local, word);
        return n == 0 ? word : word + (n + 1);
    }

    static FieldDef? StateField(TypeDef t) =>
        t.Methods.FirstOrDefault(m => m.Name.String.EndsWith("MoveNext") && m.HasBody)?.Body.Instructions
            .FirstOrDefault(i => i.OpCode.Code == Code.Ldfld && i.Operand is FieldDef { FieldType.ElementType: ElementType.I4 } fd && fd.DeclaringType == t)
            ?.Operand as FieldDef;

    static FieldDef? CurrentField(TypeDef t) =>
        t.Methods.FirstOrDefault(m => m.Name.String.EndsWith("get_Current") && m.HasBody && m.Body.Instructions.Count <= 3)?.Body.Instructions
            .FirstOrDefault(i => i.OpCode.Code == Code.Ldfld)?.Operand as FieldDef;

    // ---------------- resources ----------------

    void RenameResources()
    {
        foreach (var r in module.Resources.Where(r => r.Name.String.EndsWith(".resources")))
        {
            var baseName = r.Name.String[..^".resources".Length];
            if (renamedTypes.TryGetValue(baseName, out var newBase))
            {
                Map.Add($"resource,,{r.Name},{newBase}.resources");
                r.Name = newBase + ".resources";
            }
        }
        // new ResourceManager("<old base name>", ...) and similar literals
        foreach (var i in types.SelectMany(t => t.Methods).Where(m => m.HasBody).SelectMany(m => m.Body.Instructions))
            if (i.OpCode.Code == Code.Ldstr && renamedTypes.TryGetValue((string)i.Operand, out var newName))
                i.Operand = newName;
    }

    void CheckInterfaces()
    {
        var moduleInterfaces = types.Where(t => t.IsInterface).ToHashSet();
        foreach (var t in types.Where(t => !t.IsInterface))
            foreach (var ii in t.Interfaces)
                if (ii.Interface.ResolveTypeDef() is { } it && moduleInterfaces.Contains(it))
                    Console.WriteLine($"[warn] {t.FullName} implements {it.FullName}: check its implementations still match");
    }

    // ---------------- helpers ----------------

    void Rename(IFullName member, string newName, string kind, string owner)
    {
        Map.Add($"{kind},{owner},{member.Name},{newName}");
        member.Name = newName;
    }

    HashSet<string> ScopeOf(TypeDef t)
    {
        object key = (object?)t.DeclaringType ?? t.Namespace.String;
        if (!typeScopes.TryGetValue(key, out var set))
            typeScopes[key] = set = new HashSet<string>();
        return set;
    }

    string Next(string kind) => Count(counters, kind).ToString();

    static int Count(Dictionary<string, int> counters, string key)
    {
        counters.TryGetValue(key, out var n);
        counters[key] = n + 1;
        return n;
    }

    static string Unique(string name, HashSet<string> used)
    {
        var candidate = name;
        for (int i = 2; !used.Add(candidate); i++)
            candidate = name + "_" + i;
        return candidate;
    }

    static bool Obf(UTF8String? s) => Names.IsObfuscated(s?.String);
    static bool IsValid(string s) => Identifier.IsMatch(s) && !Keywords.Contains(s);
    static string LocalName(string word) => Keywords.Contains(word) ? word + "Value" : word;
    static bool IsCG(IHasCustomAttribute x) => x.CustomAttributes.IsDefined(CompilerGeneratedAttribute);
    static bool IsCall(Instruction i, string name) => i.OpCode.FlowControl == FlowControl.Call && i.Operand is IMethod m && m.Name.String == name;
    static bool IsDesignerType(TypeDef t) => DesignerBases.Any(b => InheritsFrom(t, b));
    static bool IsStateMachine(TypeDef t) => Implements(t, "System.Runtime.CompilerServices.IAsyncStateMachine") || Implements(t, "System.Collections.IEnumerator");
    static bool Implements(TypeDef t, string fullName) => t.Interfaces.Any(i => i.Interface.FullName == fullName);
    static bool UsesConstant(TypeDef t, int value) => t.Methods.Any(m => m.HasBody && m.Body.Instructions.Any(i => i.IsLdcI4() && i.GetLdcI4Value() == value));

    static MethodDef? InitializeComponent(TypeDef t) =>
        !IsDesignerType(t) ? null : t.Methods.FirstOrDefault(m => m.HasBody && !m.IsStatic && m.MethodSig.Params.Count == 0
            && m.ReturnType.ElementType == ElementType.Void
            && m.Body.Instructions.Any(i => IsCall(i, "SuspendLayout")) && m.Body.Instructions.Any(i => IsCall(i, "ResumeLayout")));

    static bool InheritsFrom(TypeDef t, string fullName)
    {
        for (var b = t.BaseType; b is not null; b = b.ResolveTypeDef()?.BaseType)
            if (b.FullName == fullName)
                return true;
        return false;
    }

    static bool AncestorIsCG(TypeDef t)
    {
        for (var d = t.DeclaringType; d is not null; d = d.DeclaringType)
            if (IsCG(d))
                return true;
        return false;
    }

    static TypeDef OuterNonCG(TypeDef t)
    {
        var o = t;
        while (o.DeclaringType is not null && IsCG(o))
            o = o.DeclaringType;
        return o;
    }

    static bool IsDelegate(TypeSig sig)
    {
        var tdr = sig.RemovePinnedAndModifiers().ToTypeDefOrRef();
        if (tdr is null)
            return false;
        if (tdr.ResolveTypeDef() is { } def)
            return def.BaseType?.FullName == "System.MulticastDelegate";
        var n = tdr.Name.String;
        return n.StartsWith("Action") || n.StartsWith("Func") || n.EndsWith("Handler") || n.EndsWith("Callback");
    }

    /// <summary>de4dot-style field word: string, int, metroButton, list, stringArray...</summary>
    static string TypeWord(TypeSig sig)
    {
        sig = sig.RemovePinnedAndModifiers();
        switch (sig)
        {
            case SZArraySig a: return TypeWord(a.Next) + "Array";
            case ArraySig a: return TypeWord(a.Next) + "Array";
            case ByRefSig r: return TypeWord(r.Next);
            case PtrSig p: return TypeWord(p.Next) + "Ptr";
            case GenericInstSig g: return TypeWord(g.GenericType);
            case GenericSig: return "gparam";
        }
        var primitive = sig.ElementType switch
        {
            ElementType.String => "string", ElementType.Boolean => "bool", ElementType.Char => "char",
            ElementType.I1 => "sbyte", ElementType.U1 => "byte", ElementType.I2 => "short", ElementType.U2 => "ushort",
            ElementType.I4 => "int", ElementType.U4 => "uint", ElementType.I8 => "long", ElementType.U8 => "ulong",
            ElementType.R4 => "float", ElementType.R8 => "double", ElementType.I => "intPtr", ElementType.U => "uintPtr",
            ElementType.Object => "object",
            _ => null,
        };
        if (primitive is not null)
            return primitive;
        var name = (sig as TypeDefOrRefSig)?.TypeDefOrRef.Name.String ?? "obj";
        int tick = name.IndexOf('`');
        if (tick > 0)
            name = name[..tick];
        if (name.Length == 0 || Names.IsObfuscated(name))
            return "obj";
        return char.ToLowerInvariant(name[0]) + name[1..];
    }
}
