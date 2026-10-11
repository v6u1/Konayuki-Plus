using System;
using System.Management;
using System.Runtime.InteropServices;

namespace KonayukiPlus;

public class Class18
{
	[DllImport("kernel32.dll")]
	private static extern bool GetPhysicallyInstalledSystemMemory(out long P_0);

	public static string smethod_0()
	{
		GetPhysicallyInstalledSystemMemory(out var num);
		return (num / 1024).ToString();
	}

	public static string smethod_1()
	{
		int num = 0;
		foreach (ManagementBaseObject item in new ManagementObjectSearcher("Select NumberOfCores from Win32_Processor").Get())
		{
			num += int.Parse(item["NumberOfCores"].ToString());
		}
		return num.ToString();
	}

	public static string smethod_2()
	{
		return Environment.ProcessorCount.ToString();
	}
}
