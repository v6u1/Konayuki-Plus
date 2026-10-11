using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace KonayukiPlus;

[CompilerGenerated]
internal static class CosturaAssemblyLoader
{
	private static object objectValue = new object();

	private static Dictionary<string, bool> dictionary = new Dictionary<string, bool>();

	private static Dictionary<string, string> dictionary2 = new Dictionary<string, string>();

	private static Dictionary<string, string> dictionary3 = new Dictionary<string, string>();

	private static int intValue;

	private static string _003C_003Eb__0(CultureInfo P_0)
	{
		if (P_0 == null)
		{
			return "";
		}
		return P_0.Name;
	}

	private static Assembly _003C_003Eb__1(AssemblyName P_0)
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			AssemblyName name = assembly.GetName();
			if (string.Equals(name.Name, P_0.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(_003C_003Eb__0(name.CultureInfo), _003C_003Eb__0(P_0.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
			{
				return assembly;
			}
		}
		return null;
	}

	private static void _003C_003Eb__2(Stream P_0, Stream P_1)
	{
		byte[] array = new byte[81920];
		int count;
		while ((count = P_0.Read(array, 0, array.Length)) != 0)
		{
			P_1.Write(array, 0, count);
		}
	}

	private static Stream _003C_003Eb__3(string P_0)
	{
		Assembly executingAssembly = Assembly.GetExecutingAssembly();
		if (P_0.EndsWith(".compressed"))
		{
			using (Stream stream = executingAssembly.GetManifestResourceStream(P_0))
			{
				using DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress);
				MemoryStream memoryStream = new MemoryStream();
				_003C_003Eb__2(deflateStream, memoryStream);
				memoryStream.Position = 0L;
				return memoryStream;
			}
		}
		return executingAssembly.GetManifestResourceStream(P_0);
	}

	private static Stream _003C_003Eb__4(Dictionary<string, string> P_0, string P_1)
	{
		if (P_0.TryGetValue(P_1, out var value))
		{
			return _003C_003Eb__3(value);
		}
		return null;
	}

	private static byte[] _003C_003Eb__5(Stream P_0)
	{
		byte[] array = new byte[P_0.Length];
		P_0.Read(array, 0, array.Length);
		return array;
	}

	private static Assembly _003C_003Eb__6(Dictionary<string, string> P_0, Dictionary<string, string> P_1, AssemblyName P_2)
	{
		string text = P_2.Name.ToLowerInvariant();
		if (P_2.CultureInfo != null && !string.IsNullOrEmpty(P_2.CultureInfo.Name))
		{
			text = P_2.CultureInfo.Name + "." + text;
		}
		byte[] rawAssembly;
		using (Stream stream = _003C_003Eb__4(P_0, text))
		{
			if (stream == null)
			{
				return null;
			}
			rawAssembly = _003C_003Eb__5(stream);
		}
		using (Stream stream2 = _003C_003Eb__4(P_1, text))
		{
			if (stream2 != null)
			{
				byte[] rawSymbolStore = _003C_003Eb__5(stream2);
				return Assembly.Load(rawAssembly, rawSymbolStore);
			}
		}
		return Assembly.Load(rawAssembly);
	}

	public static Assembly _003C_003Eb__7(object P_0, ResolveEventArgs P_1)
	{
		lock (objectValue)
		{
			if (dictionary.ContainsKey(P_1.Name))
			{
				return null;
			}
		}
		AssemblyName assemblyName = new AssemblyName(P_1.Name);
		Assembly assembly = _003C_003Eb__1(assemblyName);
		if (assembly != null)
		{
			return assembly;
		}
		assembly = _003C_003Eb__6(dictionary2, dictionary3, assemblyName);
		if (assembly == null)
		{
			lock (objectValue)
			{
				dictionary[P_1.Name] = true;
			}
			if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
			{
				assembly = Assembly.Load(assemblyName);
			}
		}
		return assembly;
	}

	static CosturaAssemblyLoader()
	{
		dictionary2.Add("bytesize", "costura.bytesize.dll.compressed");
		dictionary2.Add("costura", "costura.costura.dll.compressed");
		dictionary2.Add("dotnetzip", "costura.dotnetzip.dll.compressed");
		dictionary3.Add("dotnetzip", "costura.dotnetzip.pdb.compressed");
		dictionary2.Add("metroframework.design", "costura.metroframework.design.dll.compressed");
		dictionary2.Add("metroframework", "costura.metroframework.dll.compressed");
		dictionary2.Add("metroframework.fonts", "costura.metroframework.fonts.dll.compressed");
		dictionary2.Add("microsoft.windowsapicodepack", "costura.microsoft.windowsapicodepack.dll.compressed");
		dictionary2.Add("microsoft.windowsapicodepack.shell", "costura.microsoft.windowsapicodepack.shell.dll.compressed");
		dictionary2.Add("naudio", "costura.naudio.dll.compressed");
		dictionary2.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
		dictionary2.Add("system", "costura.system.dll.compressed");
	}

	public static void _003C_003Eb__8()
	{
		if (Interlocked.Exchange(ref intValue, 1) == 1)
		{
			return;
		}
		AppDomain.CurrentDomain.AssemblyResolve += (object P_0, ResolveEventArgs P_1) =>
		{
			lock (objectValue)
			{
				if (dictionary.ContainsKey(P_1.Name))
				{
					return (Assembly)null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(P_1.Name);
			Assembly assembly = _003C_003Eb__1(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = _003C_003Eb__6(dictionary2, dictionary3, assemblyName);
			if (assembly == null)
			{
				lock (objectValue)
				{
					dictionary[P_1.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != 0)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		};
	}
}
