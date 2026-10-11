using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KonayukiPlus;

public static class Class14
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string kFile__BackingField;

	public static string kFile
	{
		[CompilerGenerated]
		get
		{
			return kFile__BackingField;
		}
		[CompilerGenerated]
		set
		{
			kFile__BackingField = value;
		}
	}

	[DllImport("Kernel32.dll")]
	private static extern bool Wow64EnableWow64FsRedirection(bool P_0);

	public static void smethod_0()
	{
		Registry.ClassesRoot.CreateSubKey(".kpj").SetValue("", "konayuki.kpj");
		Registry.ClassesRoot.CreateSubKey("konayuki.kpj").SetValue("", "Konayuki Project File");
		Registry.ClassesRoot.CreateSubKey("konayuki.kpj\\DefaultIcon").SetValue("", Class48.smethod_37() + "\\KonayukiPlusLib.dll,2");
		Registry.ClassesRoot.CreateSubKey("konayuki.kpj\\shell\\open\\command").SetValue("", Application.ExecutablePath + " \"%1\"");
		Wow64EnableWow64FsRedirection(false);
		Process.Start("ie4uinit", "-ClearIconCache");
		Process.Start("ie4uinit", "-show");
		Wow64EnableWow64FsRedirection(true);
	}
}
