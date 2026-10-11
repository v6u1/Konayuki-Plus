using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KonayukiPlus;

internal class Class3
{
	[Flags]
	private enum Enum7
	{
		Value0 = 0,
		Value1 = 1,
		Value2 = 2
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	private static extern short GetKeyState(int P_0);

	private static Enum7 smethod_0(Keys P_0)
	{
		Enum7 @enum = Enum7.Value0;
		short keyState = GetKeyState((int)P_0);
		if ((keyState & 0x8000) == 32768)
		{
			@enum |= Enum7.Value1;
		}
		if ((keyState & 1) == 1)
		{
			@enum |= Enum7.Value2;
		}
		return @enum;
	}

	public static bool smethod_1(Keys P_0)
	{
		return Enum7.Value1 == (smethod_0(P_0) & Enum7.Value1);
	}

	public static bool smethod_2(Keys P_0)
	{
		return Enum7.Value2 == (smethod_0(P_0) & Enum7.Value2);
	}
}
