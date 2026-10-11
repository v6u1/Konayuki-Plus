using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Win32;

namespace KonayukiPlus;

public static class Class12
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string AvsiPath__BackingField;

	public static string AvsiPath
	{
		[CompilerGenerated]
		get
		{
			return AvsiPath__BackingField;
		}
		[CompilerGenerated]
		set
		{
			AvsiPath__BackingField = value;
		}
	}

	public static string smethod_0(string P_0)
	{
		WebClient webClient = new WebClient();
		try
		{
			webClient.Encoding = Encoding.UTF8;
			return webClient.DownloadString(P_0);
		}
		catch
		{
		}
		return bool.TrueString;
	}

	public static void smethod_1(string P_0)
	{
		string text = Class48.smethod_18(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds.ToString());
		Registry.CurrentUser.CreateSubKey("SOFTWARE\\AviSynth\\").SetValue("plugindir+", Class48.smethod_36() + text);
		if (!Directory.Exists(Class48.smethod_36() + text))
		{
			Directory.CreateDirectory(Class48.smethod_36() + text).Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory;
			File.WriteAllText(Class48.smethod_36() + text + "\\" + Class48.smethod_18(text) + ".avsi", P_0, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		}
		else
		{
			File.WriteAllText(Class48.smethod_36() + text + "\\" + Class48.smethod_18(text) + ".avsi", P_0, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		}
		AvsiPath = (Class48.smethod_36() + text + "\\" + Class48.smethod_18(text) + ".avsi").Replace("\\", "/");
	}

	public static void smethod_2(bool P_0 = false)
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Class48.smethod_36()).GetFiles("*.avsi", SearchOption.AllDirectories);
			foreach (FileInfo fileInfo in files)
			{
				Directory.Delete(fileInfo.DirectoryName ?? throw new InvalidOperationException(), recursive: true);
			}
		}
		catch
		{
		}
		if (P_0)
		{
			try
			{
				for (int num = Directory.EnumerateFiles(Class48.smethod_36()).Count(); num != 0; num = Directory.EnumerateFiles(Class48.smethod_36()).Count())
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(Class48.smethod_36());
					FileInfo[] files2 = directoryInfo.GetFiles();
					foreach (FileInfo fileInfo2 in files2)
					{
						fileInfo2.Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					foreach (DirectoryInfo directoryInfo2 in directories)
					{
						directoryInfo2.Delete(recursive: true);
					}
				}
			}
			catch
			{
			}
		}
		Registry.CurrentUser.CreateSubKey("SOFTWARE\\AviSynth\\").SetValue("plugindir+", string.Empty);
	}

	public static void smethod_3()
	{
		if (Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\AviSynth\\", "plugindir+", null) == null)
		{
			Registry.CurrentUser.CreateSubKey("SOFTWARE\\AviSynth\\").SetValue("plugindir+", "");
		}
		else if (Directory.Exists(Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\AviSynth\\", "plugindir+", null).ToString()))
		{
			Directory.Delete(Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\AviSynth\\", "plugindir+", null).ToString(), recursive: true);
		}
	}
}
