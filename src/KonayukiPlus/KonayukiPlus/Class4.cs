using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class4
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<int, string> NotifySound__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool IsAutoLoadSub__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool IsMT__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool IsSDL2__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool IsCRC32__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool IsTopMost__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int AfterCompletion__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string Lang__BackingField;

	public Dictionary<int, string> NotifySound
	{
		[CompilerGenerated]
		get
		{
			return NotifySound__BackingField;
		}
		[CompilerGenerated]
		set
		{
			NotifySound__BackingField = value;
		}
	}

	public bool IsAutoLoadSub
	{
		[CompilerGenerated]
		get
		{
			return IsAutoLoadSub__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsAutoLoadSub__BackingField = value;
		}
	}

	public bool IsMT
	{
		[CompilerGenerated]
		get
		{
			return IsMT__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsMT__BackingField = value;
		}
	}

	public bool IsSDL2
	{
		[CompilerGenerated]
		get
		{
			return IsSDL2__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsSDL2__BackingField = value;
		}
	}

	public bool IsCRC32
	{
		[CompilerGenerated]
		get
		{
			return IsCRC32__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsCRC32__BackingField = value;
		}
	}

	public bool IsTopMost
	{
		[CompilerGenerated]
		get
		{
			return IsTopMost__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsTopMost__BackingField = value;
		}
	}

	public int AfterCompletion
	{
		[CompilerGenerated]
		get
		{
			return AfterCompletion__BackingField;
		}
		[CompilerGenerated]
		set
		{
			AfterCompletion__BackingField = value;
		}
	}

	public string Lang
	{
		[CompilerGenerated]
		get
		{
			return Lang__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Lang__BackingField = value;
		}
	}

	public Class4()
	{
		NotifySound = new Dictionary<int, string>();
		IsAutoLoadSub = true;
		IsMT = true;
		IsSDL2 = false;
		IsCRC32 = true;
		IsTopMost = false;
		AfterCompletion = 0;
		Lang = "English";
	}
}
