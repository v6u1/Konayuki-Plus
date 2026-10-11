using System;
using System.Runtime.InteropServices;

namespace KonayukiPlus;

public class Native_MediaInfo
{
	private IntPtr intPtr_0;

	private bool bool_0;

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_New();

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern void MediaInfo_Delete(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Open(IntPtr P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoA_Open(IntPtr P_0, IntPtr P_1);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Open_Buffer_Init(IntPtr P_0, long P_1, long P_2);

	[DllImport("codecs\\MediaInfo.dll", EntryPoint = "MediaInfoA_Open")]
	private static extern IntPtr MediaInfoA_Open_2(IntPtr P_0, long P_1, long P_2);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Open_Buffer_Continue(IntPtr P_0, IntPtr P_1, IntPtr P_2);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoA_Open_Buffer_Continue(IntPtr P_0, long P_1, byte[] P_2, IntPtr P_3);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern long MediaInfo_Open_Buffer_Continue_GoTo_Get(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern long MediaInfoA_Open_Buffer_Continue_GoTo_Get(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Open_Buffer_Finalize(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoA_Open_Buffer_Finalize(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern void MediaInfo_Close(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Inform(IntPtr P_0, IntPtr P_1);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoA_Inform(IntPtr P_0, IntPtr P_1);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_GetI(IntPtr P_0, IntPtr P_1, IntPtr P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoA_GetI(IntPtr P_0, IntPtr P_1, IntPtr P_2, IntPtr P_3, IntPtr P_4);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Get(IntPtr P_0, IntPtr P_1, IntPtr P_2, [MarshalAs(UnmanagedType.LPWStr)] string P_3, IntPtr P_4, IntPtr P_5);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoA_Get(IntPtr P_0, IntPtr P_1, IntPtr P_2, IntPtr P_3, IntPtr P_4, IntPtr P_5);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Option(IntPtr P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfoA_Option(IntPtr P_0, IntPtr P_1, IntPtr P_2);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_State_Get(IntPtr P_0);

	[DllImport("codecs\\MediaInfo.dll")]
	private static extern IntPtr MediaInfo_Count_Get(IntPtr P_0, IntPtr P_1, IntPtr P_2);

	public Native_MediaInfo()
	{
		try
		{
			intPtr_0 = MediaInfo_New();
		}
		catch
		{
			intPtr_0 = (IntPtr)0;
		}
		if (Environment.OSVersion.ToString().IndexOf("Windows") == -1)
		{
			bool_0 = true;
		}
		else
		{
			bool_0 = false;
		}
	}

	~Native_MediaInfo()
	{
		if (!(intPtr_0 == (IntPtr)0))
		{
			MediaInfo_Delete(intPtr_0);
		}
	}

	public int method_0(string P_0)
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return 0;
		}
		if (bool_0)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(P_0);
			int result = (int)MediaInfoA_Open(intPtr_0, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}
		return (int)MediaInfo_Open(intPtr_0, P_0);
	}

	public int method_1(long P_0, long P_1)
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return 0;
		}
		return (int)MediaInfo_Open_Buffer_Init(intPtr_0, P_0, P_1);
	}

	public int method_2(IntPtr P_0, IntPtr P_1)
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return 0;
		}
		return (int)MediaInfo_Open_Buffer_Continue(intPtr_0, P_0, P_1);
	}

	public long method_3()
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return 0L;
		}
		return MediaInfo_Open_Buffer_Continue_GoTo_Get(intPtr_0);
	}

	public int method_4()
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return 0;
		}
		return (int)MediaInfo_Open_Buffer_Finalize(intPtr_0);
	}

	public void method_5()
	{
		if (!(intPtr_0 == (IntPtr)0))
		{
			MediaInfo_Close(intPtr_0);
		}
	}

	public string method_6()
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return "Unable to load MediaInfo library";
		}
		if (bool_0)
		{
			return Marshal.PtrToStringAnsi(MediaInfoA_Inform(intPtr_0, (IntPtr)0));
		}
		return Marshal.PtrToStringUni(MediaInfo_Inform(intPtr_0, (IntPtr)0));
	}

	public string method_7(Enum0 P_0, int P_1, string P_2, Enum1 P_3, Enum1 P_4)
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return "Unable to load MediaInfo library";
		}
		if (bool_0)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(P_2);
			string result = Marshal.PtrToStringAnsi(MediaInfoA_Get(intPtr_0, (IntPtr)(int)P_0, (IntPtr)P_1, intPtr, (IntPtr)(int)P_3, (IntPtr)(int)P_4));
			Marshal.FreeHGlobal(intPtr);
			return result;
		}
		return Marshal.PtrToStringUni(MediaInfo_Get(intPtr_0, (IntPtr)(int)P_0, (IntPtr)P_1, P_2, (IntPtr)(int)P_3, (IntPtr)(int)P_4));
	}

	public string method_8(Enum0 P_0, int P_1, int P_2, Enum1 P_3)
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return "Unable to load MediaInfo library";
		}
		if (bool_0)
		{
			return Marshal.PtrToStringAnsi(MediaInfoA_GetI(intPtr_0, (IntPtr)(int)P_0, (IntPtr)P_1, (IntPtr)P_2, (IntPtr)(int)P_3));
		}
		return Marshal.PtrToStringUni(MediaInfo_GetI(intPtr_0, (IntPtr)(int)P_0, (IntPtr)P_1, (IntPtr)P_2, (IntPtr)(int)P_3));
	}

	public string method_9(string P_0, string P_1)
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return "Unable to load MediaInfo library";
		}
		if (bool_0)
		{
			IntPtr intPtr = Marshal.StringToHGlobalAnsi(P_0);
			IntPtr intPtr2 = Marshal.StringToHGlobalAnsi(P_1);
			string result = Marshal.PtrToStringAnsi(MediaInfoA_Option(intPtr_0, intPtr, intPtr2));
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
			return result;
		}
		return Marshal.PtrToStringUni(MediaInfo_Option(intPtr_0, P_0, P_1));
	}

	public int method_10()
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return 0;
		}
		return (int)MediaInfo_State_Get(intPtr_0);
	}

	public int method_11(Enum0 P_0, int P_1)
	{
		if (intPtr_0 == (IntPtr)0)
		{
			return 0;
		}
		return (int)MediaInfo_Count_Get(intPtr_0, (IntPtr)(int)P_0, (IntPtr)P_1);
	}

	public string method_12(Enum0 P_0, int P_1, string P_2, Enum1 P_3)
	{
		return method_7(P_0, P_1, P_2, P_3, Enum1.Value0);
	}

	public string method_13(Enum0 P_0, int P_1, string P_2)
	{
		return method_7(P_0, P_1, P_2, Enum1.Value1, Enum1.Value0);
	}

	public string method_14(Enum0 P_0, int P_1, int P_2)
	{
		return method_8(P_0, P_1, P_2, Enum1.Value1);
	}

	public string method_15(string P_0)
	{
		return method_9(P_0, "");
	}

	public int method_16(Enum0 P_0)
	{
		return method_11(P_0, -1);
	}
}
