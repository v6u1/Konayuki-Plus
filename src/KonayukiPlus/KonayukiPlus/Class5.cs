using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

public static class Class5
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool IsPreview__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool IsExecute__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string File__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string FPSNum__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string FPSDen__BackingField;

	public static bool IsPreview
	{
		[CompilerGenerated]
		get
		{
			return IsPreview__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsPreview__BackingField = value;
		}
	}

	public static bool IsExecute
	{
		[CompilerGenerated]
		get
		{
			return IsExecute__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsExecute__BackingField = value;
		}
	}

	public static string File
	{
		[CompilerGenerated]
		get
		{
			return File__BackingField;
		}
		[CompilerGenerated]
		set
		{
			File__BackingField = value;
		}
	}

	public static string FPSNum
	{
		[CompilerGenerated]
		get
		{
			return FPSNum__BackingField;
		}
		[CompilerGenerated]
		set
		{
			FPSNum__BackingField = value;
		}
	}

	public static string FPSDen
	{
		[CompilerGenerated]
		get
		{
			return FPSDen__BackingField;
		}
		[CompilerGenerated]
		set
		{
			FPSDen__BackingField = value;
		}
	}

	static Class5()
	{
		IsPreview = false;
		IsExecute = false;
		File = string.Empty;
		FPSNum = string.Empty;
		FPSDen = string.Empty;
	}
}
