using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace KonayukiPlus;

internal static class Program
{
	public class Class57 : WindowsFormsApplicationBase
	{
		private Class57()
		{
			IsSingleInstance = true;
		}

		public static void smethod_0(Form P_0)
		{
			Class57 @class = new Class57();
			@class.MainForm = P_0;
			if (Environment.GetCommandLineArgs().Length > 1)
			{
				if (Environment.GetCommandLineArgs()[1].Equals("/log"))
				{
					frmMain.bool_3 = true;
				}
				else
				{
					Class14.kFile = Environment.GetCommandLineArgs()[1];
				}
			}
			@class.StartupNextInstance += (object obj, StartupNextInstanceEventArgs e) =>
			{
				frmSplash.bool_1 = false;
				if (e.CommandLine.Count > 1)
				{
					if (e.CommandLine[1].Equals("/log"))
					{
						frmMain.bool_3 = true;
					}
					else
					{
						Class48.ShowAgain = true;
						Class14.kFile = e.CommandLine[1];
					}
				}
				else
				{
					Class48.ShowAgain = true;
				}
			};
			@class.Run(Environment.GetCommandLineArgs());
		}
	}

	[STAThread]
	private static void Main()
	{
		// ffmpeg and the UI emit/expect '.' decimals; parse and format invariantly so the app
		// does not crash on locales such as tr-TR where ',' is the decimal separator.
		System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
		if (Environment.Is64BitOperatingSystem)
		{
			Class14.smethod_0();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Class57.smethod_0(new frmSplash());
		}
		else
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			MessageBox.Show("This program is support windows x64 only.", "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Application.Exit();
		}
	}
}
