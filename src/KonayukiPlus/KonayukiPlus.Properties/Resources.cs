using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;

namespace KonayukiPlus.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager("KonayukiPlus.Properties.Resources", typeof(Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static UnmanagedMemoryStream cityscape => ResourceManager.GetStream("cityscape", resourceCulture);

	internal static UnmanagedMemoryStream festival => ResourceManager.GetStream("festival", resourceCulture);

	internal static UnmanagedMemoryStream garden => ResourceManager.GetStream("garden", resourceCulture);

	internal static UnmanagedMemoryStream heritage => ResourceManager.GetStream("heritage", resourceCulture);

	internal static UnmanagedMemoryStream landscape => ResourceManager.GetStream("landscape", resourceCulture);

	internal static Bitmap MsgBox_Error
	{
		get
		{
			object obj = ResourceManager.GetObject("MsgBox_Error", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap MsgBox_Info
	{
		get
		{
			object obj = ResourceManager.GetObject("MsgBox_Info", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap MsgBox_Success
	{
		get
		{
			object obj = ResourceManager.GetObject("MsgBox_Success", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap MsgBox_Warning
	{
		get
		{
			object obj = ResourceManager.GetObject("MsgBox_Warning", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap mute_off
	{
		get
		{
			object obj = ResourceManager.GetObject("mute_off", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap mute_on
	{
		get
		{
			object obj = ResourceManager.GetObject("mute_on", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static UnmanagedMemoryStream normal => ResourceManager.GetStream("normal", resourceCulture);

	internal static Bitmap player_off
	{
		get
		{
			object obj = ResourceManager.GetObject("player_off", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static Bitmap player_on
	{
		get
		{
			object obj = ResourceManager.GetObject("player_on", resourceCulture);
			return (Bitmap)obj;
		}
	}

	internal static UnmanagedMemoryStream savanna => ResourceManager.GetStream("savanna", resourceCulture);

	internal static UnmanagedMemoryStream sonata => ResourceManager.GetStream("sonata", resourceCulture);

	internal Resources()
	{
	}
}
