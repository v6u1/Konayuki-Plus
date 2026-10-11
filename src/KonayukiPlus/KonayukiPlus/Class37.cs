using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class37
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class32 Intro__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class29 Source__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class35 EndCard__BackingField;

	public Class32 Intro
	{
		[CompilerGenerated]
		get
		{
			return Intro__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Intro__BackingField = value;
		}
	}

	public Class29 Source
	{
		[CompilerGenerated]
		get
		{
			return Source__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Source__BackingField = value;
		}
	}

	public Class35 EndCard
	{
		[CompilerGenerated]
		get
		{
			return EndCard__BackingField;
		}
		[CompilerGenerated]
		set
		{
			EndCard__BackingField = value;
		}
	}

	public Class37()
	{
		Intro = new Class32();
		Source = new Class29();
		EndCard = new Class35();
	}
}
