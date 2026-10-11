using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace KonayukiPlus;

public sealed class Class1
{
	public enum Enum5
	{
		Value0 = 0,
		Value1 = 0x10,
		Value2 = 0x40000,
		Value3 = 0x80000
	}

	[Flags]
	public enum Enum6
	{
		Value0 = 1,
		Value1 = 2,
		Value2 = 4,
		Value3 = 8
	}

	private const int int_0 = 65536;

	private const int int_1 = 131072;

	private const int int_2 = 250;

	private readonly Form form_0;

	private Enum5 enum5_0;

	private Enum6 enum6_0;

	private int int_3;

	public Enum5 Method
	{
		get
		{
			return enum5_0;
		}
		set
		{
			enum5_0 = value;
		}
	}

	public Enum6 Direction
	{
		get
		{
			return enum6_0;
		}
		set
		{
			enum6_0 = value;
		}
	}

	public int Duration
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public Form Form => form_0;

	public Class1(Form P_0)
	{
		form_0 = P_0;
		form_0.Load += form_0_Load;
		form_0.VisibleChanged += form_0_VisibleChanged;
		form_0.Closing += form_0_Closing;
		int_3 = 250;
	}

	public Class1(Form P_0, Enum5 P_1, int P_2)
		: this(P_0)
	{
		enum5_0 = P_1;
		int_3 = P_2;
	}

	public Class1(Form P_0, Enum5 P_1, Enum6 P_2, int P_3)
		: this(P_0, P_1, P_3)
	{
		enum6_0 = P_2;
	}

	private void form_0_Load(object P_0, EventArgs P_1)
	{
		if (form_0.MdiParent == null || enum5_0 != Enum5.Value3)
		{
			Native_user32.AnimateWindow(form_0.Handle, int_3, (int)((Enum5)0x20000 | enum5_0) | (int)enum6_0);
		}
	}

	private void form_0_VisibleChanged(object P_0, EventArgs P_1)
	{
		if (form_0.MdiParent == null)
		{
			int num = (int)enum5_0 | (int)enum6_0;
			num = ((!form_0.Visible) ? (num | 0x10000) : (num | 0x20000));
			Native_user32.AnimateWindow(form_0.Handle, int_3, num);
		}
	}

	private void form_0_Closing(object P_0, CancelEventArgs P_1)
	{
		if (!P_1.Cancel && (form_0.MdiParent == null || enum5_0 != Enum5.Value3))
		{
			Native_user32.AnimateWindow(form_0.Handle, int_3, (int)((Enum5)0x10000 | enum5_0) | (int)enum6_0);
		}
	}
}
