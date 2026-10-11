using System;
using System.Runtime.InteropServices;

namespace KonayukiPlus;

internal static class Native_user32
{
	[DllImport("user32")]
	internal static extern IntPtr GetForegroundWindow();

	[DllImport("user32")]
	internal static extern bool SetForegroundWindow(IntPtr P_0);

	[DllImport("user32")]
	internal static extern bool AnimateWindow(IntPtr P_0, int P_1, int P_2);

	[DllImport("Gdi32.dll")]
	internal static extern IntPtr CreateRoundRectRgn(int P_0, int P_1, int P_2, int P_3, int P_4, int P_5);
}
