using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class41
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int Format__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int Quality__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int SampleRates__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int TrackId__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Class54> Track__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class42 Volume__BackingField;

	public int Format
	{
		[CompilerGenerated]
		get
		{
			return Format__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Format__BackingField = value;
		}
	}

	public int Quality
	{
		[CompilerGenerated]
		get
		{
			return Quality__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Quality__BackingField = value;
		}
	}

	public int SampleRates
	{
		[CompilerGenerated]
		get
		{
			return SampleRates__BackingField;
		}
		[CompilerGenerated]
		set
		{
			SampleRates__BackingField = value;
		}
	}

	public int TrackId
	{
		[CompilerGenerated]
		get
		{
			return TrackId__BackingField;
		}
		[CompilerGenerated]
		set
		{
			TrackId__BackingField = value;
		}
	}

	public List<Class54> Track
	{
		[CompilerGenerated]
		get
		{
			return Track__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Track__BackingField = value;
		}
	}

	public Class42 Volume
	{
		[CompilerGenerated]
		get
		{
			return Volume__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Volume__BackingField = value;
		}
	}

	public Class41()
	{
		TrackId = -1;
		Volume = new Class42();
	}
}
