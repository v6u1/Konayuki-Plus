using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class29
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class28 IN__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class30 OUT__BackingField;

	public Class28 IN
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

	public Class30 OUT
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

	public Class29()
	{
		IN = new Class28();
		OUT = new Class30();
	}
}
