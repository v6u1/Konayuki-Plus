using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KonayukiPlus;

public static class Native_kernel32
{
	[Flags]
	public enum Enum9
	{
		Value0 = 1,
		Value1 = 2,
		Value2 = 8,
		Value3 = 0x10,
		Value4 = 0x20,
		Value5 = 0x40,
		Value6 = 0x80,
		Value7 = 0x100,
		Value8 = 0x200
	}

	[DllImport("kernel32.dll")]
	private static extern IntPtr OpenThread(Enum9 P_0, bool P_1, uint P_2);

	[DllImport("kernel32.dll")]
	private static extern uint SuspendThread(IntPtr P_0);

	[DllImport("kernel32.dll")]
	private static extern int ResumeThread(IntPtr P_0);

	public static void smethod_0(this Process P_0)
	{
		foreach (ProcessThread thread in P_0.Threads)
		{
			IntPtr intPtr = OpenThread(Enum9.Value1, false, (uint)thread.Id);
			if (intPtr == IntPtr.Zero)
			{
				break;
			}
			SuspendThread(intPtr);
		}
	}

	public static void smethod_1(this Process P_0)
	{
		foreach (ProcessThread thread in P_0.Threads)
		{
			IntPtr intPtr = OpenThread(Enum9.Value1, false, (uint)thread.Id);
			if (intPtr == IntPtr.Zero)
			{
				break;
			}
			ResumeThread(intPtr);
		}
	}
}
