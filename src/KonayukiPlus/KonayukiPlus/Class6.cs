using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KonayukiPlus;

internal class Class6
{
	private enum Enum8
	{
		Value0,
		Value1,
		Value2,
		Value3,
		Value4,
		Value5,
		Value6,
		Value7,
		Value8,
		Value9
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate IntPtr Delegate0();

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate1(IntPtr P_0);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate2(IntPtr P_0, IntPtr P_1);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate3(IntPtr P_0);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate4(IntPtr P_0, byte[] P_1, int P_2, ref long P_3);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate5(IntPtr P_0, byte[] P_1, byte[] P_2);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate6(IntPtr P_0, byte[] P_1, int P_2, ref IntPtr P_3);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate7(IntPtr P_0, byte[] P_1, int P_2, ref double P_3);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int Delegate8(IntPtr P_0, byte[] P_1, int P_2, ref byte[] P_3);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void Delegate9(IntPtr P_0);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate uint Delegate10();

	private IntPtr intPtr_0;

	private IntPtr intPtr_1;

	private double? nullable_0;

	private Delegate0 delegate0_0;

	private Delegate1 delegate1_0;

	private Delegate2 delegate2_0;

	private Delegate3 delegate3_0;

	private Delegate4 delegate4_0;

	private Delegate5 delegate5_0;

	private Delegate6 delegate6_0;

	private Delegate7 delegate7_0;

	private Delegate8 delegate8_0;

	private Delegate9 delegate9_0;

	private Delegate10 delegate10_0;

	private int int_0 = 100;

	private double double_0 = 1.0;

	public double CurrentPosition
	{
		get
		{
			if (intPtr_1 == IntPtr.Zero)
			{
				return 0.0;
			}
			if (nullable_0.HasValue)
			{
				if (nullable_0 < 0.0)
				{
					return 0.0;
				}
				return nullable_0.Value;
			}
			int num = 5;
			double result = 0.0;
			delegate7_0(intPtr_1, smethod_0("time-pos"), num, ref result);
			return result;
		}
		set
		{
			if (!(intPtr_1 == IntPtr.Zero))
			{
				if (value <= method_10())
				{
					nullable_0 = value;
				}
				method_24("seek", value.ToString(CultureInfo.InvariantCulture), "absolute");
			}
		}
	}

	public double CurrentFrame
	{
		get
		{
			if (intPtr_1 == IntPtr.Zero)
			{
				return 0.0;
			}
			if (nullable_0.HasValue)
			{
				if (nullable_0 < 0.0)
				{
					return 0.0;
				}
				return nullable_0.Value;
			}
			double result = 0.0;
			delegate7_0(intPtr_1, smethod_0("estimated-frame-number"), 5, ref result);
			return result;
		}
		set
		{
			if (!(intPtr_1 == IntPtr.Zero))
			{
				method_24("seek", value.ToString(CultureInfo.InvariantCulture), "absolute");
			}
		}
	}

	public double TotalFrame
	{
		get
		{
			if (intPtr_1 == IntPtr.Zero)
			{
				return 0.0;
			}
			double result = 0.0;
			delegate7_0(intPtr_1, smethod_0("estimated-frame-count"), 5, ref result);
			return result;
		}
	}

	public int Volume
	{
		get
		{
			return int_0;
		}
		set
		{
			if (intPtr_1 != IntPtr.Zero)
			{
				method_24("set", "volume", value.ToString(CultureInfo.InvariantCulture));
				int_0 = value;
			}
		}
	}

	public double PlayRate
	{
		get
		{
			return double_0;
		}
		set
		{
			if (intPtr_1 != IntPtr.Zero)
			{
				method_24("set", "speed", Math.Round(value).ToString(CultureInfo.InvariantCulture));
				double_0 = value;
			}
		}
	}

	[DllImport("kernel32", SetLastError = true)]
	private static extern bool FreeLibrary(IntPtr P_0);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, SetLastError = true)]
	internal static extern IntPtr LoadLibrary(string P_0);

	[DllImport("kernel32.dll", BestFitMapping = false, CharSet = CharSet.Ansi, SetLastError = true)]
	internal static extern IntPtr GetProcAddress(IntPtr P_0, string P_1);

	private object method_0(Type P_0, string P_1)
	{
		IntPtr procAddress = GetProcAddress(intPtr_0, P_1);
		if (procAddress != IntPtr.Zero)
		{
			return Marshal.GetDelegateForFunctionPointer(procAddress, P_0);
		}
		return null;
	}

	private void method_1()
	{
		intPtr_0 = LoadLibrary(Class48.smethod_37() + "\\codecs\\mpv-1.dll");
		delegate0_0 = (Delegate0)method_0(typeof(Delegate0), "mpv_create");
		delegate1_0 = (Delegate1)method_0(typeof(Delegate1), "mpv_initialize");
		delegate3_0 = (Delegate3)method_0(typeof(Delegate3), "mpv_terminate_destroy");
		delegate2_0 = (Delegate2)method_0(typeof(Delegate2), "mpv_command");
		delegate4_0 = (Delegate4)method_0(typeof(Delegate4), "mpv_set_option");
		delegate5_0 = (Delegate5)method_0(typeof(Delegate5), "mpv_set_option_string");
		delegate6_0 = (Delegate6)method_0(typeof(Delegate6), "mpv_get_property");
		delegate7_0 = (Delegate7)method_0(typeof(Delegate7), "mpv_get_property");
		delegate8_0 = (Delegate8)method_0(typeof(Delegate8), "mpv_set_property");
		delegate9_0 = (Delegate9)method_0(typeof(Delegate9), "mpv_free");
		delegate10_0 = (Delegate10)method_0(typeof(Delegate10), "mpv_client_api_version");
	}

	public void method_2()
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			PlayRate = 1.0;
			byte[] array = smethod_0("yes");
			delegate8_0(intPtr_1, smethod_0("pause"), 1, ref array);
		}
	}

	public void method_3()
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			PlayRate = 1.0;
			byte[] array = smethod_0("no");
			delegate8_0(intPtr_1, smethod_0("pause"), 1, ref array);
		}
	}

	public void method_4(string P_0)
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			byte[] array = smethod_0(P_0);
			delegate8_0(intPtr_1, smethod_0("log-file"), 1, ref array);
		}
	}

	public void method_5()
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			string[] stringArray_ = frmMain.stringArray_0;
			foreach (string text in stringArray_)
			{
				delegate5_0(intPtr_1, smethod_0(text.Split('=')[0]), smethod_0(text.Split('=')[1]));
			}
		}
	}

	public void method_6(string P_0)
	{
		if (intPtr_1 != IntPtr.Zero)
		{
			delegate5_0(intPtr_1, smethod_0("osd-msg1"), smethod_0(P_0));
		}
	}

	public void method_7()
	{
		if (intPtr_1 != IntPtr.Zero)
		{
			method_2();
			PlayRate = 1.0;
			CurrentPosition = 0.0;
		}
	}

	public void method_8()
	{
		if (intPtr_1 != IntPtr.Zero)
		{
			PlayRate = 1.0;
			if (method_9())
			{
				method_3();
			}
			else
			{
				method_2();
			}
		}
	}

	private bool method_9()
	{
		if (intPtr_1 == IntPtr.Zero)
		{
			return true;
		}
		IntPtr zero = IntPtr.Zero;
		delegate6_0(intPtr_1, smethod_0("pause"), 1, ref zero);
		bool result = Marshal.PtrToStringAnsi(zero) == "yes";
		delegate9_0(zero);
		return result;
	}

	public double method_10()
	{
		if (intPtr_1 != IntPtr.Zero)
		{
			double result = 0.0;
			delegate7_0(intPtr_1, smethod_0("duration"), 5, ref result);
			return result;
		}
		return 0.0;
	}

	public string method_11()
	{
		if (intPtr_1 == IntPtr.Zero)
		{
			return string.Empty;
		}
		IntPtr zero = IntPtr.Zero;
		delegate6_0(intPtr_1, smethod_0("container-fps"), 1, ref zero);
		string result = Marshal.PtrToStringAnsi(zero);
		delegate9_0(zero);
		return result;
	}

	public void method_12()
	{
		try
		{
			FileInfo[] files = new DirectoryInfo(Class48.smethod_36()).GetFiles("*.avsi", SearchOption.AllDirectories);
			foreach (FileInfo fileInfo in files)
			{
				Directory.Delete(fileInfo.DirectoryName, recursive: true);
			}
		}
		catch
		{
		}
		Registry.CurrentUser.CreateSubKey("SOFTWARE\\AviSynth\\").SetValue("plugindir+", string.Empty);
	}

	~Class6()
	{
		method_14(false);
	}

	public void method_13()
	{
		method_14(true);
		GC.SuppressFinalize(this);
	}

	private void method_14(bool P_0)
	{
		method_15();
	}

	public void method_15()
	{
		try
		{
			lock (this)
			{
				if (intPtr_1 != IntPtr.Zero)
				{
					delegate3_0(intPtr_1);
					intPtr_1 = IntPtr.Zero;
				}
			}
		}
		catch
		{
		}
	}

	public double method_16()
	{
		if (intPtr_1 == IntPtr.Zero)
		{
			return 0.0;
		}
		int num = 5;
		double result = 0.0;
		delegate7_0(intPtr_1, smethod_0("time-pos"), num, ref result);
		return result;
	}

	public int method_17()
	{
		if (intPtr_1 == IntPtr.Zero)
		{
			return 0;
		}
		double num = 0.0;
		delegate7_0(intPtr_1, smethod_0("estimated-frame-number"), 5, ref num);
		return (int)num;
	}

	public void method_18()
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			delegate5_0(intPtr_1, smethod_0("mute"), smethod_0("no"));
		}
	}

	public void method_19()
	{
		if (intPtr_1 != IntPtr.Zero)
		{
			if (method_20())
			{
				delegate5_0(intPtr_1, smethod_0("mute"), smethod_0("no"));
			}
			else
			{
				delegate5_0(intPtr_1, smethod_0("mute"), smethod_0("yes"));
			}
		}
	}

	private bool method_20()
	{
		if (intPtr_1 == IntPtr.Zero)
		{
			return true;
		}
		IntPtr zero = IntPtr.Zero;
		delegate6_0(intPtr_1, smethod_0("mute"), 1, ref zero);
		bool result = Marshal.PtrToStringAnsi(zero) == "yes";
		delegate9_0(zero);
		return result;
	}

	public void method_21(double P_0)
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			method_24("seek", P_0.ToString(CultureInfo.InvariantCulture), "absolute");
		}
	}

	public void method_22()
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			method_24("frame-step");
			nullable_0 = null;
		}
	}

	public void method_23()
	{
		if (!(intPtr_1 == IntPtr.Zero))
		{
			method_24("frame-back-step");
			nullable_0 = null;
		}
	}

	private static byte[] smethod_0(string P_0)
	{
		return Encoding.UTF8.GetBytes(P_0 + "\0");
	}

	public static IntPtr smethod_1(string[] P_0, out IntPtr[] P_1)
	{
		int num = P_0.Length + 1;
		P_1 = new IntPtr[num];
		IntPtr intPtr = Marshal.AllocCoTaskMem(IntPtr.Size * num);
		for (int i = 0; i < P_0.Length; i++)
		{
			byte[] array = smethod_0(P_0[i]);
			IntPtr intPtr2 = Marshal.AllocHGlobal(array.Length);
			Marshal.Copy(array, 0, intPtr2, array.Length);
			P_1[i] = intPtr2;
		}
		Marshal.Copy(P_1, 0, intPtr, num);
		return intPtr;
	}

	private void method_24(params string[] args)
	{
		IntPtr intPtr = smethod_1(args, out var array);
		delegate2_0(intPtr_1, intPtr);
		IntPtr[] array2 = array;
		foreach (IntPtr hglobal in array2)
		{
			Marshal.FreeHGlobal(hglobal);
		}
		Marshal.FreeHGlobal(intPtr);
	}

	public void method_25(PictureBox P_0, string P_1)
	{
		if (intPtr_1 != IntPtr.Zero)
		{
			delegate3_0(intPtr_1);
		}
		method_1();
		if (!(intPtr_0 == IntPtr.Zero))
		{
			intPtr_1 = delegate0_0();
			if (!(intPtr_1 == IntPtr.Zero))
			{
				delegate1_0(intPtr_1);
				method_5();
				int num = 4;
				long num2 = P_0.Handle.ToInt64();
				delegate4_0(intPtr_1, smethod_0("wid"), num, ref num2);
				method_24("loadfile", P_1);
			}
		}
	}

	public string method_26()
	{
		string text = Path.GetTempFileName() + ".jpg";
		if (intPtr_1 != IntPtr.Zero)
		{
			text = text.Replace(".tmp.", ".");
			text = Class48.smethod_37() + "\\tmp\\" + Path.GetFileName(text);
			method_24("screenshot-to-file", text, "video");
			do
			{
				Application.DoEvents();
				Console.WriteLine(File.Exists(text));
			}
			while (!File.Exists(text));
		}
		return text;
	}
}
