using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class25
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class24 Intro__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class23 EndCard__BackingField;

	public Class24 Intro
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

	public Class23 EndCard
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

	public Class25()
	{
		Intro = new Class24();
		EndCard = new Class23();
	}
}
