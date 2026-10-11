using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class32
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class31 IN__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class33 OUT__BackingField;

	public Class31 IN
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

	public Class33 OUT
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

	public Class32()
	{
		IN = new Class31();
		OUT = new Class33();
	}
}
