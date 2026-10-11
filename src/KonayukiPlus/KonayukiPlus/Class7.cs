using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KonayukiPlus;

public class Class7
{
	public static void smethod_0()
	{
		string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32", "drivers", "etc", "hosts");
		try
		{
			if (File.Exists(path))
			{
				List<string> list = File.ReadAllLines(path, Encoding.UTF8).ToList();
				list.RemoveAll((string P_0) => P_0.ToLower().Contains("konayuki.moe"));
				File.SetAttributes(path, (FileAttributes)0);
				File.WriteAllLines(path, list, Encoding.UTF8);
			}
		}
		catch
		{
			MessageBox.Show("Error Code : 0x00000000\r\nPlease contact us for help.", "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			Application.Exit();
		}
	}
}
