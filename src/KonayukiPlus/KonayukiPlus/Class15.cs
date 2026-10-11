using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KonayukiPlus;

public class Class15
{
	[ComImport]
	[Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
	private class Class16
	{
	}

	[ComImport]
	[Guid("42f85136-db7e-439c-85f1-e4075d135fc8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	private interface IInterface0
	{
		[PreserveSig]
		uint method_0([In] IntPtr P_0);

		void method_1();

		void method_2([In] uint P_0);

		void method_3(out uint P_0);

		void method_4();

		void method_5();

		void method_6([In] Enum11 P_0);

		void method_7(out Enum11 P_0);

		void method_8(IInterface1 P_0);

		void method_9(IInterface1 P_0);

		void method_10(out IInterface1 P_0);

		void method_11(out IInterface1 P_0);

		void method_12([In][MarshalAs(UnmanagedType.LPWStr)] string P_0);

		void method_13([MarshalAs(UnmanagedType.LPWStr)] out string P_0);

		void method_14([In][MarshalAs(UnmanagedType.LPWStr)] string P_0);

		void method_15([In][MarshalAs(UnmanagedType.LPWStr)] string P_0);

		void method_16([In][MarshalAs(UnmanagedType.LPWStr)] string P_0);

		void method_17(out IInterface1 P_0);

		void method_18(IInterface1 P_0, int P_1);

		void method_19([In][MarshalAs(UnmanagedType.LPWStr)] string P_0);

		void method_20(int P_0);

		void method_21();

		void method_22();

		void method_23([MarshalAs(UnmanagedType.Interface)] IntPtr P_0);

		void method_24([MarshalAs(UnmanagedType.Interface)] out IntPtr P_0);

		void method_25([MarshalAs(UnmanagedType.Interface)] out IntPtr P_0);
	}

	[ComImport]
	[Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	private interface IInterface1
	{
		void method_0();

		void method_1();

		void method_2([In] Enum10 P_0, [MarshalAs(UnmanagedType.LPWStr)] out string P_1);

		void method_3();

		void method_4();
	}

	private enum Enum10 : uint
	{
		Value0 = 2147794944u,
		Value1 = 2147647488u,
		Value2 = 2147844096u,
		Value3 = 0u,
		Value4 = 2148007937u,
		Value5 = 2147684353u,
		Value6 = 2147991553u,
		Value7 = 2147581953u,
		Value8 = 2147909632u
	}

	[Flags]
	private enum Enum11
	{
		Value0 = 0x80,
		Value1 = 0x200,
		Value2 = 0x2000,
		Value3 = 0x20000000,
		Value4 = 0x2000000,
		Value5 = 0x1000,
		Value6 = 0x40,
		Value7 = 0x10000000,
		Value8 = 0x20000,
		Value9 = 0x40000,
		Value10 = 8,
		Value11 = 0x100000,
		Value12 = 0x8000,
		Value13 = 0x10000,
		Value14 = 0x100,
		Value15 = 2,
		Value16 = 0x800,
		Value17 = 0x20,
		Value18 = 0x4000,
		Value19 = 4
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string Title__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string DirectoryPath__BackingField;

	private const uint uint_0 = 2147943623u;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return Title__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Title__BackingField = value;
		}
	}

	public string DirectoryPath
	{
		[CompilerGenerated]
		get
		{
			return DirectoryPath__BackingField;
		}
		[CompilerGenerated]
		set
		{
			DirectoryPath__BackingField = value;
		}
	}

	public DialogResult method_0(IWin32Window P_0)
	{
		IntPtr intPtr = P_0?.Handle ?? GetActiveWindow();
		IInterface0 @interface = (IInterface0)new Class16();
		@interface.method_14(Title);
		try
		{
			IInterface1 interface2;
			if (!string.IsNullOrEmpty(DirectoryPath))
			{
				uint num = 0u;
				if (SHILCreateFromPath(DirectoryPath, out var intPtr2, ref num) == 0 && SHCreateShellItem(IntPtr.Zero, IntPtr.Zero, intPtr2, out interface2) == 0)
				{
					@interface.method_9(interface2);
				}
			}
			@interface.method_6(Enum11.Value6 | Enum11.Value17);
			switch (@interface.method_0(intPtr))
			{
			case 2147943623u:
				return DialogResult.Cancel;
			default:
				return DialogResult.Abort;
			case 0u:
			{
				@interface.method_17(out interface2);
				interface2.method_2(Enum10.Value2, out var directoryPath);
				DirectoryPath = directoryPath;
				return DialogResult.OK;
			}
			}
		}
		finally
		{
			Marshal.ReleaseComObject(@interface);
		}
	}

	[DllImport("shell32.dll")]
	private static extern int SHILCreateFromPath([MarshalAs(UnmanagedType.LPWStr)] string P_0, out IntPtr P_1, ref uint P_2);

	[DllImport("shell32.dll")]
	private static extern int SHCreateShellItem(IntPtr P_0, IntPtr P_1, IntPtr P_2, out IInterface1 P_3);

	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();
}
