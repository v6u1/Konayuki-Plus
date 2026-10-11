using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

// Applies mechanical fixes to ILSpy-decompiled sources, driven by the compiler's own error
// locations so each edit lands exactly on the offending token:
//
//   CS0103  an undefined identifier that is really a property setter's renamed `value`
//           parameter (ILSpy names it by type: num, text, @enum, cultureInfo, ...) -> `value`
//   CS0117  `base._002Ector();` / `this._002Ector();` — a leftover explicit object..ctor call -> removed
//
//   SourceFixer <build.log>
// Prints how many edits it made; re-run the build and the fixer until both reach zero.

if (args.Length != 1)
{
    Console.Error.WriteLine("usage: SourceFixer <build.log>");
    return 2;
}

// error lines look like:  C:\path\File.cs(117,9): error CS0103: 'num' ... [C:\...csproj]
var rx = new Regex(@"^(?<file>[A-Za-z]:\\[^(]+\.cs)\((?<line>\d+),(?<col>\d+)\): error (?<code>CS\d+): (?<msg>.*)$");
var byFile = new Dictionary<string, List<(int Line, int Col, string Code, string Name)>>(StringComparer.OrdinalIgnoreCase);
foreach (var raw in File.ReadLines(args[0]))
{
    var m = rx.Match(raw.Trim());
    if (!m.Success)
        continue;
    var code = m.Groups["code"].Value;
    if (code is not ("CS0103" or "CS0117"))
        continue;
    var msg = m.Groups["msg"].Value;
    // CS0117 message mentions the type first ('object') then the missing member ('_002Ector');
    // gate on the member appearing anywhere in the message rather than on quote order (locale-independent).
    if (code == "CS0117" && !msg.Contains("_002Ector"))
        continue;
    var name = Regex.Match(msg, "'(?<n>[^']+)'").Groups["n"].Value;
    var file = Path.GetFullPath(m.Groups["file"].Value);
    (byFile.TryGetValue(file, out var l) ? l : byFile[file] = new())
        .Add((int.Parse(m.Groups["line"].Value), int.Parse(m.Groups["col"].Value), code, name));
}

int totalValue = 0, totalCtor = 0, files = 0;
foreach (var (file, diags) in byFile)
{
    if (!File.Exists(file))
    {
        Console.Error.WriteLine($"[skip] missing {file}");
        continue;
    }
    var text = SourceText.From(File.ReadAllText(file), Encoding.UTF8);
    var tree = CSharpSyntaxTree.ParseText(text, new CSharpParseOptions(LanguageVersion.CSharp11));
    var root = tree.GetRoot();

    // Resolve each diagnostic position to a syntax node up front (positions are stable until we rewrite).
    var replaceWithValue = new HashSet<SyntaxNode>();
    var removeStatements = new HashSet<StatementSyntax>();
    foreach (var (line, col, code, _) in diags)
    {
        int pos = text.Lines[line - 1].Start + (col - 1);
        var token = root.FindToken(pos);
        if (code == "CS0103")
        {
            if (token.Parent is IdentifierNameSyntax id && InSetterOrInit(id))
                replaceWithValue.Add(id);
            else
                Console.Error.WriteLine($"[warn] {Path.GetFileName(file)}({line},{col}) CS0103 not a setter value-param: {token.Parent?.Kind()}");
        }
        else // CS0117 _002Ector
        {
            var stmt = token.Parent?.FirstAncestorOrSelf<ExpressionStatementSyntax>();
            if (stmt is not null && stmt.ToString().Contains("_002Ector"))
                removeStatements.Add(stmt);
            else
                Console.Error.WriteLine($"[warn] {Path.GetFileName(file)}({line},{col}) CS0117 not a ._002Ector() statement");
        }
    }

    var newRoot = root.ReplaceNodes(
        replaceWithValue.Cast<SyntaxNode>().Concat(removeStatements),
        (original, _) =>
        {
            if (original is IdentifierNameSyntax id)
                return SyntaxFactory.IdentifierName("value").WithTriviaFrom(id);
            return original; // statements handled below via RemoveNodes
        });

    // Remove the ._002Ector() statements (can't both replace and remove in one pass cleanly).
    if (removeStatements.Count > 0)
    {
        var toRemove = newRoot.DescendantNodes().OfType<ExpressionStatementSyntax>()
            .Where(s => s.Expression is InvocationExpressionSyntax inv
                        && inv.Expression is MemberAccessExpressionSyntax ma
                        && ma.Name.Identifier.Text == "_002Ector").ToList();
        newRoot = newRoot.RemoveNodes(toRemove, SyntaxRemoveOptions.KeepNoTrivia)!;
    }

    File.WriteAllText(file, newRoot.ToFullString(), new UTF8Encoding(false));
    totalValue += replaceWithValue.Count;
    totalCtor += removeStatements.Count;
    files++;
}

Console.WriteLine($"[fix] {files} files, {totalValue} value-param renames, {totalCtor} base..ctor removals");
return 0;

static bool InSetterOrInit(SyntaxNode node)
{
    for (var n = node.Parent; n is not null; n = n.Parent)
    {
        if (n is AccessorDeclarationSyntax a)
            return a.IsKind(SyntaxKind.SetAccessorDeclaration) || a.IsKind(SyntaxKind.InitAccessorDeclaration)
                || a.IsKind(SyntaxKind.AddAccessorDeclaration) || a.IsKind(SyntaxKind.RemoveAccessorDeclaration);
        if (n is MethodDeclarationSyntax or AnonymousFunctionExpressionSyntax or LocalFunctionStatementSyntax)
            return false;
    }
    return false;
}
