using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KonayukiPlus;

internal class Class17
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string AuthorName__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string AuthorEmail__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string AuthorDescription__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, string> frmMain__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, string> frmConfig__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static JObject avsMsg__BackingField;

	public static Dictionary<string, Class17> dictionary_0;

	public static Class17 class17_0;

	public string AuthorName
	{
		[CompilerGenerated]
		get
		{
			return AuthorName__BackingField;
		}
		[CompilerGenerated]
		set
		{
			AuthorName__BackingField = value;
		}
	}

	public string AuthorEmail
	{
		[CompilerGenerated]
		get
		{
			return AuthorEmail__BackingField;
		}
		[CompilerGenerated]
		set
		{
			AuthorEmail__BackingField = value;
		}
	}

	public string AuthorDescription
	{
		[CompilerGenerated]
		get
		{
			return AuthorDescription__BackingField;
		}
		[CompilerGenerated]
		set
		{
			AuthorDescription__BackingField = value;
		}
	}

	public Dictionary<string, string> frmMain
	{
		[CompilerGenerated]
		get
		{
			return frmMain__BackingField;
		}
		[CompilerGenerated]
		set
		{
			frmMain__BackingField = value;
		}
	}

	public Dictionary<string, string> frmConfig
	{
		[CompilerGenerated]
		get
		{
			return frmConfig__BackingField;
		}
		[CompilerGenerated]
		set
		{
			frmConfig__BackingField = value;
		}
	}

	public static JObject avsMsg
	{
		[CompilerGenerated]
		get
		{
			return avsMsg__BackingField;
		}
		[CompilerGenerated]
		set
		{
			avsMsg__BackingField = value;
		}
	}

	public static void smethod_0(ToolStripMenuItem P_0, ToolStripMenuItem P_1, string P_2)
	{
		Class4 class4 = new Class4();
		try
		{
			class4 = Class48.LoadConfig();
		}
		catch
		{
			frmConfigs.smethod_0();
		}
		if (!Directory.Exists(Class48.smethod_37() + "\\languages"))
		{
			Directory.CreateDirectory(Class48.smethod_37() + "\\languages");
		}
		foreach (string item in from result in Directory.GetFiles(Path.Combine(Class48.smethod_37(), "languages"), "*.json", SearchOption.TopDirectoryOnly)
			orderby result
			select result)
		{
			try
			{
				string text = File.ReadAllText(item);
				Class17 class5 = JsonConvert.DeserializeObject<Class17>(text);
				string stringValue = Path.GetFileNameWithoutExtension(item);
				dictionary_0.Add(stringValue, class5);
				if (Path.GetFileNameWithoutExtension(item).Equals(P_2))
				{
					avsMsg = JObject.Parse(text)["avsMsg"] as JObject;
				}
				P_0.DropDownItems.Add(stringValue + " [" + class5.AuthorName + "]").Click += delegate
				{
					Class4 value = new Class4
					{
						IsAutoLoadSub = class4.IsAutoLoadSub,
						IsMT = class4.IsMT,
						IsSDL2 = class4.IsSDL2,
						IsCRC32 = class4.IsCRC32,
						IsTopMost = class4.IsTopMost,
						AfterCompletion = class4.AfterCompletion,
						Lang = stringValue
					};
					Class48.SaveConfig(value);
					for (int i = 0; i < P_0.DropDownItems.Count; i++)
					{
						if (P_0.DropDownItems[i].Text == stringValue + " [" + class5.AuthorName + "]")
						{
							((ToolStripMenuItem)P_0.DropDownItems[i]).Checked = true;
							P_0.DropDownItems[i].Enabled = false;
						}
						else
						{
							((ToolStripMenuItem)P_0.DropDownItems[i]).Checked = false;
							P_0.DropDownItems[i].Enabled = true;
						}
						if (P_1.DropDownItems[i].Text == stringValue + " [" + class5.AuthorName + "]")
						{
							((ToolStripMenuItem)P_1.DropDownItems[i]).Checked = true;
							P_1.DropDownItems[i].Enabled = false;
						}
						else
						{
							((ToolStripMenuItem)P_1.DropDownItems[i]).Checked = false;
							P_1.DropDownItems[i].Enabled = true;
						}
					}
					new Notification("KONAYUKI PLUS", "Please restart application for the applied changes to take effect.", -1, Enum13.Value0, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
				};
				P_1.DropDownItems.Add(stringValue + " [" + class5.AuthorName + "]").Click += delegate
				{
					Class4 value = new Class4
					{
						IsAutoLoadSub = class4.IsAutoLoadSub,
						IsMT = class4.IsMT,
						IsSDL2 = class4.IsSDL2,
						IsCRC32 = class4.IsCRC32,
						IsTopMost = class4.IsTopMost,
						AfterCompletion = class4.AfterCompletion,
						Lang = stringValue
					};
					Class48.SaveConfig(value);
					for (int i = 0; i < P_1.DropDownItems.Count; i++)
					{
						if (P_0.DropDownItems[i].Text == stringValue + " [" + class5.AuthorName + "]")
						{
							((ToolStripMenuItem)P_0.DropDownItems[i]).Checked = true;
							P_0.DropDownItems[i].Enabled = false;
						}
						else
						{
							((ToolStripMenuItem)P_0.DropDownItems[i]).Checked = false;
							P_0.DropDownItems[i].Enabled = true;
						}
						if (P_1.DropDownItems[i].Text == stringValue + " [" + class5.AuthorName + "]")
						{
							((ToolStripMenuItem)P_1.DropDownItems[i]).Checked = true;
							P_1.DropDownItems[i].Enabled = false;
						}
						else
						{
							((ToolStripMenuItem)P_1.DropDownItems[i]).Checked = false;
							P_1.DropDownItems[i].Enabled = true;
						}
					}
					new Notification("KONAYUKI PLUS", "Please restart application for the applied changes to take effect.", -1, Enum13.Value0, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
				};
				P_0.DropDownItems[P_0.DropDownItems.Count - 1].Image = Image.FromFile(Path.Combine(Class48.smethod_37(), "languages", "Flags", stringValue + ".png"));
				P_1.DropDownItems[P_1.DropDownItems.Count - 1].Image = Image.FromFile(Path.Combine(Class48.smethod_37(), "languages", "Flags", stringValue + ".png"));
			}
			catch
			{
			}
		}
		if (!dictionary_0.ContainsKey(P_2))
		{
			return;
		}
		frmHelper.string_0 = P_2;
		class17_0 = dictionary_0[P_2];
		for (int num = 0; num < P_0.DropDownItems.Count; num++)
		{
			if (P_0.DropDownItems[num].Text.Substring(0, P_2.Length) == P_2)
			{
				((ToolStripMenuItem)P_0.DropDownItems[num]).Checked = true;
				P_0.DropDownItems[num].Enabled = false;
			}
		}
		for (int num2 = 0; num2 < P_1.DropDownItems.Count; num2++)
		{
			if (P_1.DropDownItems[num2].Text.Substring(0, P_2.Length) == P_2)
			{
				((ToolStripMenuItem)P_1.DropDownItems[num2]).Checked = true;
				P_1.DropDownItems[num2].Enabled = false;
			}
		}
	}

	public Class17()
	{
		AuthorName = "Proflylab";
		AuthorEmail = "proflylab@protonmail.com";
		AuthorDescription = "Hello World!!";
		frmMain = new Dictionary<string, string>();
		frmConfig = new Dictionary<string, string>();
	}

	static Class17()
	{
		avsMsg = new JObject();
		dictionary_0 = new Dictionary<string, Class17>();
		class17_0 = new Class17();
	}
}
