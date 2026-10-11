using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class38
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class39 Enhancer__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class40 Color__BackingField;

	public Class39 Enhancer
	{
		[CompilerGenerated]
		get
		{
			return Enhancer__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Enhancer__BackingField = value;
		}
	}

	public Class40 Color
	{
		[CompilerGenerated]
		get
		{
			return Color__BackingField;
		}
		[CompilerGenerated]
		set
		{
			Color__BackingField = value;
		}
	}

	public Class38()
	{
		Enhancer = new Class39();
		Color = new Class40();
	}
}
