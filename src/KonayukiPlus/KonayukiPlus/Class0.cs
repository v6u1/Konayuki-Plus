using System;
using System.Runtime.InteropServices;

namespace KonayukiPlus;

public class Class0
{
	private IntPtr intPtr_0;

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_New();

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern void MediaInfoList_Delete(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_Open(IntPtr P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, IntPtr P_2);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern void MediaInfoList_Close(IntPtr P_0, IntPtr P_1);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_Inform(IntPtr P_0, IntPtr P_1, IntPtr P_2);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_GetI(IntPtr P_0, IntPtr P_1, IntPtr P_2, IntPtr P_3, IntPtr P_4, IntPtr P_5);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_Get(IntPtr P_0, IntPtr P_1, IntPtr P_2, IntPtr P_3, [MarshalAs(UnmanagedType.LPWStr)] string P_4, IntPtr P_5, IntPtr P_6);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_Option(IntPtr P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_State_Get(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoList_Count_Get(IntPtr P_0, IntPtr P_1, IntPtr P_2, IntPtr P_3);

	public Class0()
	{
		intPtr_0 = MediaInfoList_New();
	}

	~Class0()
	{
		MediaInfoList_Delete(intPtr_0);
	}

	public int method_0(string P_0, Enum3 P_1)
	{
		return (int)MediaInfoList_Open(intPtr_0, P_0, (IntPtr)(int)P_1);
	}

	public void method_1(int P_0)
	{
		MediaInfoList_Close(intPtr_0, (IntPtr)P_0);
	}

	public string method_2(int P_0)
	{
		return Marshal.PtrToStringUni(MediaInfoList_Inform(intPtr_0, (IntPtr)P_0, (IntPtr)0));
	}

	public string method_3(int P_0, Enum0 P_1, int P_2, string P_3, Enum1 P_4, Enum1 P_5)
	{
		return Marshal.PtrToStringUni(MediaInfoList_Get(intPtr_0, (IntPtr)P_0, (IntPtr)(int)P_1, (IntPtr)P_2, P_3, (IntPtr)(int)P_4, (IntPtr)(int)P_5));
	}

	public string method_4(int P_0, Enum0 P_1, int P_2, int P_3, Enum1 P_4)
	{
		return Marshal.PtrToStringUni(MediaInfoList_GetI(intPtr_0, (IntPtr)P_0, (IntPtr)(int)P_1, (IntPtr)P_2, (IntPtr)P_3, (IntPtr)(int)P_4));
	}

	public string method_5(string P_0, string P_1)
	{
		return Marshal.PtrToStringUni(MediaInfoList_Option(intPtr_0, P_0, P_1));
	}

	public int method_6()
	{
		return (int)MediaInfoList_State_Get(intPtr_0);
	}

	public int method_7(int P_0, Enum0 P_1, int P_2)
	{
		return (int)MediaInfoList_Count_Get(intPtr_0, (IntPtr)P_0, (IntPtr)(int)P_1, (IntPtr)P_2);
	}

	public void method_8(string P_0)
	{
		method_0(P_0, Enum3.Value0);
	}

	public void method_9()
	{
		method_1(-1);
	}

	public string method_10(int P_0, Enum0 P_1, int P_2, string P_3, Enum1 P_4)
	{
		return method_3(P_0, P_1, P_2, P_3, P_4, Enum1.Value0);
	}

	public string method_11(int P_0, Enum0 P_1, int P_2, string P_3)
	{
		return method_3(P_0, P_1, P_2, P_3, Enum1.Value1, Enum1.Value0);
	}

	public string method_12(int P_0, Enum0 P_1, int P_2, int P_3)
	{
		return method_4(P_0, P_1, P_2, P_3, Enum1.Value1);
	}

	public string method_13(string P_0)
	{
		return method_5(P_0, "");
	}

	public int method_14(int P_0, Enum0 P_1)
	{
		return method_7(P_0, P_1, -1);
	}
}
