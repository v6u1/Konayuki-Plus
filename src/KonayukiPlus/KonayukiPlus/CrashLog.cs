using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace KonayukiPlus;

/// <summary>
/// Last-resort handler for unexpected errors, added by the revival (the original had none: an error in an
/// event handler showed the raw .NET dialog, and one on a background thread closed the app without a trace).
///
/// Every such error is appended to <c>tmp\crash.log</c> in the installation folder, which is also
/// <c>%ProgramData%\Konayuki Container\tmp\crash.log</c>, so users can attach it to a bug report.
/// Errors on the UI thread leave the app running; errors on background threads cannot be recovered from
/// (the runtime ends the process), so they are only logged. The same error repeating within a minute,
/// for example from a timer, is logged and shown once.
/// </summary>
internal static class CrashLog
{
    private static readonly object Gate = new object();
    private static string lastKey;
    private static DateTime lastAt;
    private static int showing;

    public static string FilePath => Path.Combine(Application.StartupPath, "tmp", "crash.log");

    public static void Report(Exception ex, bool fatal)
    {
        string key = ex == null ? "null" : ex.GetType().FullName + "|" + ex.Message + "|" + ex.StackTrace;
        lock (Gate)
        {
            if (key == lastKey && DateTime.Now - lastAt < TimeSpan.FromMinutes(1))
            {
                return;
            }
            lastKey = key;
            lastAt = DateTime.Now;
        }
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            File.AppendAllText(FilePath, string.Format("==== {0:yyyy-MM-dd HH:mm:ss} | {1} | v{2} | {3}{4}{5}{4}{4}",
                DateTime.Now, fatal ? "fatal" : "recovered", Assembly.GetExecutingAssembly().GetName().Version,
                Environment.OSVersion.VersionString, Environment.NewLine, ex));
        }
        catch
        {
            // the log is best effort
        }
        if (fatal || Interlocked.Exchange(ref showing, 1) == 1)
        {
            return;
        }
        try
        {
            MessageBox.Show("Something went wrong, but KONAYUKI PLUS can keep running.\r\n\r\n"
                + (ex == null ? "Unknown error" : ex.Message)
                + "\r\n\r\nThe details were saved to:\r\n" + FilePath
                + "\r\n\r\nPlease attach that file when you report the problem:\r\n" + Server.Support,
                "KONAYUKI PLUS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            Interlocked.Exchange(ref showing, 0);
        }
    }
}
