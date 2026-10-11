using System;
using System.Text;

namespace KonayukiPlus;

public static class Class49
{
	public static string smethod_0(string P_0)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(P_0);
		return Convert.ToBase64String(bytes);
	}

	public static string smethod_1(string P_0)
	{
		byte[] bytes = Convert.FromBase64String(P_0);
		return Encoding.UTF8.GetString(bytes);
	}
}
