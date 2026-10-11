namespace System.Runtime.CompilerServices
{
    // .NET Framework 4.7.1 has no ModuleInitializerAttribute, but the C# compiler recognises it
    // purely by full name, so we supply our own. Needed because Costura.Fody's assembly-resolver
    // hook was originally installed from the <Module> type initializer, and module initializers
    // cannot be expressed in C# source — they are lost when the assembly is decompiled. Without
    // this, the embedded dependencies (Newtonsoft.Json, MetroFramework, ...) never resolve and the
    // app dies with a FileNotFoundException as soon as the splash touches one.
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal sealed class ModuleInitializerAttribute : Attribute
    {
    }
}

namespace KonayukiPlus
{
    internal static class CosturaBootstrap
    {
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void Attach()
        {
            // Re-registers the AppDomain.AssemblyResolve handler that unpacks the
            // costura.*.dll.compressed resources on demand — the exact call the original
            // module initializer made.
            CosturaAssemblyLoader._003C_003Eb__8();
        }
    }
}
