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
				else if (Environment.GetCommandLineArgs()[1].Equals("/repair"))
				{
					frmSplash.bool_3 = true;
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
					else if (e.CommandLine[1].Equals("/repair"))
					{
						// a repair start that found this instance still running: there is nothing to open
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
		// Log unexpected errors to tmp\crash.log instead of the raw .NET dialog or a silent exit (see CrashLog).
		Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
		Application.ThreadException += (object sender, System.Threading.ThreadExceptionEventArgs e) => CrashLog.Report(e.Exception, fatal: false);
		AppDomain.CurrentDomain.UnhandledException += (object sender, System.UnhandledExceptionEventArgs e) => CrashLog.Report(e.ExceptionObject as Exception, fatal: true);
		// "/repair <pid>": started by Repair in the menu. Wait for the instance that started us to close first,
		// otherwise the single-instance check would hand our arguments to it and exit.
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		if (commandLineArgs.Length > 2 && commandLineArgs[1].Equals("/repair") && int.TryParse(commandLineArgs[2], out int previousPid))
		{
			try
			{
				System.Diagnostics.Process.GetProcessById(previousPid).WaitForExit(15000);
			}
			catch
			{
				// already gone
			}
		}
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
