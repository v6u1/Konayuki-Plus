using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class56
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string MainPath__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string Cores__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string Threads__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string Ram__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int Preview__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int EncodeStatus__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string ScanType__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string ScanMethod__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string ScanOrder__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string DAR__BackingField;

	public string MainPath
	{
		[CompilerGenerated]
		get
		{
			return MainPath__BackingField;
		}
		[CompilerGenerated]
		set
		{
			MainPath__BackingField = value;
		}
	}

	public string Cores
	{
		[CompilerGenerated]
		get
		{
			return Cores__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Cores__BackingField = value;
		}
	}

	public string Threads
	{
		[CompilerGenerated]
		get
		{
			return Threads__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Threads__BackingField = value;
		}
	}

	public string Ram
	{
		[CompilerGenerated]
		get
		{
			return Ram__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Ram__BackingField = value;
		}
	}

	public int Preview
	{
		[CompilerGenerated]
		get
		{
			return Preview__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Preview__BackingField = value;
		}
	}

	public int EncodeStatus
	{
		[CompilerGenerated]
		get
		{
			return EncodeStatus__BackingField;
		}
		[CompilerGenerated]
		set
		{
			EncodeStatus__BackingField = value;
		}
	}

	public string ScanType
	{
		[CompilerGenerated]
		get
		{
			return ScanType__BackingField;
		}
		[CompilerGenerated]
		set
		{
			ScanType__BackingField = value;
		}
	}

	public string ScanMethod
	{
		[CompilerGenerated]
		get
		{
			return ScanMethod__BackingField;
		}
		[CompilerGenerated]
		set
		{
			ScanMethod__BackingField = value;
		}
	}

	public string ScanOrder
	{
		[CompilerGenerated]
		get
		{
			return ScanOrder__BackingField;
		}
		[CompilerGenerated]
		set
		{
			ScanOrder__BackingField = value;
		}
	}

	public string DAR
	{
		[CompilerGenerated]
		get
		{
			return DAR__BackingField;
		}
		[CompilerGenerated]
		set
		{
			DAR__BackingField = value;
		}
	}

	public string method_0(string P_0)
	{
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(P_0);
		if (native_MediaInfo.method_13(Enum0.Value1, 0, "ScanType/String") == "")
		{
			return "NULL";
		}
		return native_MediaInfo.method_13(Enum0.Value1, 0, "ScanType/String");
	}

	public string method_1(string P_0)
	{
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(P_0);
		if (native_MediaInfo.method_13(Enum0.Value1, 0, "ScanType_StoreMethod/String") == "")
		{
			return "NULL";
		}
		return native_MediaInfo.method_13(Enum0.Value1, 0, "ScanType_StoreMethod/String");
	}

	public string method_2(string P_0)
	{
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(P_0);
		if (native_MediaInfo.method_13(Enum0.Value1, 0, "ScanOrder/String") == "")
		{
			return "NULL";
		}
		return native_MediaInfo.method_13(Enum0.Value1, 0, "ScanOrder/String");
	}

	public string method_3(string P_0)
	{
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			double num = Math.Floor(float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Height")) / float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "DisplayAspectRatio/String").Split(':')[1]) * float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "DisplayAspectRatio/String").Split(':')[0]));
			return (num % 2.0 == 0.0) ? num.ToString() : (num + 1.0).ToString();
		}
		catch
		{
		}
		return "0";
	}
}
