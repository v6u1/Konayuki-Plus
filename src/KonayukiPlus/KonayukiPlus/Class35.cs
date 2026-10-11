using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class35
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class34 IN__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class36 OUT__BackingField;

	public Class34 IN
	{
		[CompilerGenerated]
		get
		{
			return IN__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IN__BackingField = value;
		}
	}

	public Class36 OUT
	{
		[CompilerGenerated]
		get
		{
			return OUT__BackingField;
		}
		[CompilerGenerated]
		set
		{
			OUT__BackingField = value;
		}
	}

	public Class35()
	{
		IN = new Class34();
		OUT = new Class36();
	}
}
