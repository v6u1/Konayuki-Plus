using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KonayukiPlus;

internal class Native_user32_2
{
	[DllImport("user32.dll")]
	private static extern int SetWindowText(IntPtr P_0, string P_1);

	[DllImport("user32.dll")]
	private static extern IntPtr FindWindowEx(IntPtr P_0, IntPtr P_1, string P_2, string P_3);

	[DllImport("User32.dll")]
	private static extern int SendMessage(IntPtr P_0, int P_1, int P_2, string P_3);

	public static void smethod_0(string P_0 = null, string P_1 = null)
	{
		Process process = Process.Start(new ProcessStartInfo("notepad.exe"));
		if (process != null)
		{
			process.WaitForInputIdle();
			if (!string.IsNullOrEmpty(P_1))
			{
				SetWindowText(process.MainWindowHandle, P_1);
			}
			if (!string.IsNullOrEmpty(P_0))
			{
				IntPtr intPtr = FindWindowEx(process.MainWindowHandle, new IntPtr(0), "Edit", null);
				SendMessage(intPtr, 12, 0, P_0);
			}
		}
	}
}
