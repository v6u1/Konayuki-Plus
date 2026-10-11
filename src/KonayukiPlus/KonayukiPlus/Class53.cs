using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class53
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int Status__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class37 Fade__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class27 Disslove__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class25 Custom__BackingField;

	public int Status
	{
		[CompilerGenerated]
		get
		{
			return Status__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Status__BackingField = value;
		}
	}

	public Class37 Fade
	{
		[CompilerGenerated]
		get
		{
			return Fade__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Fade__BackingField = value;
		}
	}

	public Class27 Disslove
	{
		[CompilerGenerated]
		get
		{
			return Disslove__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Disslove__BackingField = value;
		}
	}

	public Class25 Custom
	{
		[CompilerGenerated]
		get
		{
			return Custom__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Custom__BackingField = value;
		}
	}

	public Class53()
	{
		Fade = new Class37();
		Disslove = new Class27();
		Custom = new Class25();
	}
}
