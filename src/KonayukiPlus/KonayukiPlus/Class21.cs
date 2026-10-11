using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KonayukiPlus;

internal class Class21
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Class22 SubRemover__BackingField;

	public Class22 SubRemover
	{
		[CompilerGenerated]
		get
		{
			return SubRemover__BackingField;
		}
		[CompilerGenerated]
		set
		{
			SubRemover__BackingField = value;
		}
	}

	public Class21()
	{
		SubRemover = new Class22();
	}
}
