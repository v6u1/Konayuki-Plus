using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace KonayukiPlus;

public static class Native_Shell32
{
	[DllImport("Shell32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true)]
	private static extern int ExtractIconExW(string P_0, int P_1, out IntPtr P_2, out IntPtr P_3, int P_4);

	public static Icon smethod_0(int P_0, bool P_1 = true)
	{
		ExtractIconExW("KonayukiPlusLib.dll", P_0, out var intPtr, out var intPtr2, 1);
		try
		{
			return Icon.FromHandle(P_1 ? intPtr : intPtr2);
		}
		catch
		{
			return null;
		}
	}
}
