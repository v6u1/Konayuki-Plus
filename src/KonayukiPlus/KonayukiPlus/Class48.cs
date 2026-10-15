using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonayukiPlus.Properties;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using NAudio.Wave;

namespace KonayukiPlus;

public static class Class48
{
	public struct Struct4
	{
		public uint uint_0;

		public IntPtr intPtr_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;
	}

	private struct Struct5
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string LogPath__BackingField;

	private const int int_0 = 3;

	private const int int_1 = 33554432;

	public const uint uint_0 = 3u;

	public const uint uint_1 = 12u;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool ShowAgain__BackingField;

	private static Random random_0;

	public static string LogPath
	{
		[CompilerGenerated]
		get
		{
			return LogPath__BackingField;
		}
		[CompilerGenerated]
		set
		{
			LogPath__BackingField = value;
		}
	}

	public static bool ShowAgain
	{
		[CompilerGenerated]
		get
		{
			return ShowAgain__BackingField;
		}
		[CompilerGenerated]
		set
		{
			ShowAgain__BackingField = value;
		}
	}

	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindow(string P_0, string P_1);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool SetWindowText(IntPtr P_0, string P_1);

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(HandleRef P_0, out Struct5 P_1);

	[DllImport("user32.dll")]
	private static extern IntPtr SetWindowPos(IntPtr P_0, int P_1, int P_2, int P_3, int P_4, int P_5, int P_6);

	[DllImport("user32")]
	private static extern IntPtr GetSystemMenu(IntPtr P_0, bool P_1);

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr P_0, int P_1, int P_2, int P_3);

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	[DllImport("user32.dll")]
	private static extern int GetWindowText(IntPtr P_0, StringBuilder P_1, int P_2);

	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
	public static extern bool CreateSymbolicLink(string P_0, string P_1, int P_2);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern int GetFinalPathNameByHandleW(IntPtr P_0, [In][Out] StringBuilder P_1, int P_2, int P_3);

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern SafeFileHandle CreateFileW(string P_0, int P_1, int P_2, IntPtr P_3, int P_4, int P_5, IntPtr P_6);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool FlashWindowEx(ref Struct4 P_0);

	public static bool smethod_0(Form P_0)
	{
		IntPtr handle = P_0.Handle;
		Struct4 structure = default;
		structure.uint_0 = Convert.ToUInt32(Marshal.SizeOf(structure));
		structure.intPtr_0 = handle;
		structure.uint_1 = 15u;
		structure.uint_2 = 5u;
		structure.uint_3 = 0u;
		return FlashWindowEx(ref structure);
	}

	public static void smethod_1()
	{
		Registry.CurrentUser.CreateSubKey("Console").SetValue("WindowPosition", int.MaxValue, RegistryValueKind.DWord);
	}

	public static void smethod_2(Control P_0, string P_1)
	{
		ToolTip toolTip = new ToolTip();
		toolTip.ShowAlways = true;
		toolTip.SetToolTip(P_0, P_1);
	}

	public static bool smethod_3(string P_0)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		IntPtr foregroundWindow = GetForegroundWindow();
		if (GetWindowText(foregroundWindow, stringBuilder, 256) > 0)
		{
			return stringBuilder.ToString().Equals(P_0);
		}
		return false;
	}

	public static bool smethod_4(IntPtr P_0)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		IntPtr foregroundWindow = GetForegroundWindow();
		Console.WriteLine(foregroundWindow + "->" + P_0);
		return foregroundWindow.Equals(P_0);
	}

	public static string smethod_5(string P_0)
	{
		using FileStream fileStream = File.OpenRead(P_0);
		using SHA1Managed sHA1Managed = new SHA1Managed();
		byte[] array = sHA1Managed.ComputeHash(fileStream);
		fileStream.Close();
		return BitConverter.ToString(array).ToLower().Replace("-", string.Empty);
	}

	public static Image smethod_6(this PictureBox P_0, float P_1)
	{
		Bitmap bitmap = new Bitmap(P_0.Width, P_0.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		ColorMatrix colorMatrix = new ColorMatrix();
		colorMatrix.Matrix33 = P_1;
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
		graphics.DrawImage(P_0.Image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, P_0.Width, P_0.Height, GraphicsUnit.Pixel, imageAttributes);
		graphics.Dispose();
		return P_0.Image = bitmap;
	}

	public static async void smethod_7(Enum13 P_0, string P_1)
	{
		WaveOut waveOut = new WaveOut();
		waveOut.Init(new Mp3FileReader(P_1));
		waveOut.Play();
		await Task.Delay(3000);
		waveOut.Stop();
		switch (P_0)
		{
		case Enum13.Value0:
			new SoundPlayer(Resources.garden).Play();
			break;
		case Enum13.Value4:
			new SoundPlayer(Resources.festival).Play();
			break;
		case Enum13.Value1:
			new SoundPlayer(Resources.savanna).Play();
			break;
		case Enum13.Value2:
			new SoundPlayer(Resources.cityscape).Play();
			break;
		case Enum13.Value3:
			new SoundPlayer(Resources.landscape).Play();
			break;
		default:
			new SoundPlayer(Resources.landscape).Play();
			break;
		}
	}

	public static bool smethod_8()
	{
		return Environment.OSVersion.Version.Major == 10;
	}

	public static string smethod_9(string P_0, bool P_1 = false)
	{
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			double num = double.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Height"));
			if (P_1)
			{
				num = Math.Floor(float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Width")) / (float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Height")) / 720f));
				native_MediaInfo.method_5();
				return (num % 2.0 == 0.0) ? ("-x " + num + " -y 720") : ("-x " + (num + 1.0) + " -y 720");
			}
			if (num > 720.0)
			{
				num = Math.Floor(float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Width")) / (float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Height")) / 720f));
				native_MediaInfo.method_5();
				return (num % 2.0 == 0.0) ? ("-x " + num + " -y 720") : ("-x " + (num + 1.0) + " -y 720");
			}
		}
		catch
		{
		}
		return null;
	}

	public static string smethod_10(string P_0)
	{
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			string text = native_MediaInfo.method_13(Enum0.Value1, 0, "colour_primaries");
			if (text == string.Empty)
			{
				text = "NULL";
			}
			native_MediaInfo.method_5();
			return text;
		}
		catch
		{
		}
		return "NULL";
	}

	public static string smethod_11(string P_0)
	{
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			string result = native_MediaInfo.method_13(Enum0.Value1, 0, "Duration").Replace(".000000", "").Remove(native_MediaInfo.method_13(Enum0.Value1, 0, "Duration").Replace(".000000", "").Length - 3);
			native_MediaInfo.method_5();
			return result;
		}
		catch
		{
		}
		return null;
	}

	public static string smethod_12(string P_0, string P_1)
	{
		string empty = string.Empty;
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			switch (Path.GetExtension(P_0.ToLower()))
			{
			case ".mp4":
			case ".mkv":
			case ".avi":
			case ".wmv":
			case ".mov":
			case ".mpg":
				empty = native_MediaInfo.method_13(Enum0.Value1, 0, "Duration").Replace(".000000", "").Remove(native_MediaInfo.method_13(Enum0.Value1, 0, "Duration").Replace(".000000", "").Length - 3);
				break;
			case ".png":
			case ".jpg":
				empty = P_1;
				break;
			default:
				empty = "0";
				break;
			}
			native_MediaInfo.method_5();
			return empty;
		}
		catch
		{
		}
		return "0";
	}

	public static string smethod_13(int P_0)
	{
		return new string((from text in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", P_0)
			select text[random_0.Next(text.Length)]).ToArray());
	}

	public static void smethod_14(this Form P_0)
	{
		ReleaseCapture();
		SendMessage(P_0.Handle, 161, 2, 0);
	}

	public static void smethod_15(this RichTextBox P_0, string P_1, Color P_2, bool P_3 = false, bool P_4 = false)
	{
		if (P_4)
		{
			P_1 += Environment.NewLine;
		}
		P_0.SelectionStart = P_0.TextLength;
		P_0.SelectionLength = 0;
		if (P_3)
		{
			P_0.SelectionColor = P_2;
			P_0.SelectionBackColor = ((P_2 == Color.Red) ? Color.White : Color.HotPink);
		}
		else
		{
			P_0.SelectionBackColor = Color.White;
			P_0.SelectionColor = Color.Black;
		}
		P_0.AppendText(P_1);
		P_0.SelectionColor = P_0.ForeColor;
		P_0.ScrollToCaret();
	}

	public static void smethod_16(string P_0, string P_1, string[] P_2)
	{
		byte[] array = new byte[2];
		array = File.ReadAllBytes(P_0);
		if (array[0] == 80 && array[1] == 71)
		{
			File.Copy(P_0, P_1, overwrite: true);
		}
		else
		{
			File.WriteAllLines(P_1, P_2, Encoding.UTF8);
		}
	}

	public static void smethod_17(this Process P_0, string P_1)
	{
		try
		{
			while (P_0.MainWindowHandle == IntPtr.Zero)
			{
				P_0.Refresh();
				Application.DoEvents();
			}
			SetWindowText(P_0.MainWindowHandle, P_1);
		}
		catch
		{
		}
	}

	public static string smethod_18(string P_0)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(P_0);
		byte[] array = mD.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static dynamic smethod_19(string P_0, bool P_1 = true)
	{
		byte[] array = new byte[100]
		{
			57, 49, 105, 103, 55, 76, 104, 112, 105, 104,
			56, 72, 36, 52, 65, 51, 106, 109, 48, 79,
			50, 88, 54, 109, 117, 57, 49, 36, 74, 106,
			87, 116, 98, 82, 82, 38, 36, 88, 57, 104,
			105, 117, 36, 81, 51, 116, 37, 111, 117, 97,
			49, 81, 117, 117, 77, 79, 51, 66, 99, 52,
			111, 55, 112, 106, 48, 121, 69, 37, 105, 75,
			53, 33, 104, 100, 90, 106, 103, 65, 38, 53,
			73, 66, 53, 116, 78, 103, 55, 97, 38, 73,
			35, 106, 85, 88, 52, 64, 114, 90, 86, 65
		};
		byte[] bytes = Encoding.UTF8.GetBytes(P_0);
		for (int i = 0; i < bytes.Length; i++)
		{
			bytes[i] ^= array[i % array.Length];
		}
		if (P_1)
		{
			return bytes;
		}
		return Encoding.UTF8.GetString(bytes);
	}

	public static IntPtr smethod_20()
	{
		return FindWindow("SDL_app", null);
	}

	public static bool smethod_21()
	{
		if (FindWindow("PREVIEW", null) != (IntPtr)0)
		{
			return true;
		}
		return false;
	}

	public static void smethod_22(string P_0, object P_1)
	{
		GetWindowRect(new HandleRef(P_1, FindWindow("SDL_app", null)), out var @struct);
		int num = SystemInformation.PrimaryMonitorSize.Width / 2 - (@struct.int_2 - @struct.int_0) / 2;
		int num2 = @struct.int_2 - @struct.int_0;
		int num3 = SystemInformation.PrimaryMonitorSize.Height / 2 - (@struct.int_3 - @struct.int_1) / 2;
		int num4 = @struct.int_3 - @struct.int_1;
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(P_0);
		double num5 = double.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Height"));
		if (num5 > 720.0)
		{
			num5 = Math.Floor(float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Width")) / (float.Parse(native_MediaInfo.method_13(Enum0.Value1, 0, "Height")) / 720f));
			SetWindowPos(FindWindow("SDL_app", null), 0, num, num3, (int)((num5 % 2.0 == 0.0) ? num5 : (num5 + 1.0)) + 16, 759, 0);
		}
		else
		{
			SetWindowPos(FindWindow("SDL_app", null), 0, num, num3, num2, num4, 0);
		}
		native_MediaInfo.method_5();
	}

	public static void smethod_23(IntPtr P_0, object P_1)
	{
		GetWindowRect(new HandleRef(P_1, P_0), out var @struct);
		int num = SystemInformation.PrimaryMonitorSize.Width / 2 - (@struct.int_2 - @struct.int_0) / 2;
		int num2 = @struct.int_2 - @struct.int_0;
		int num3 = SystemInformation.PrimaryMonitorSize.Height / 2 - (@struct.int_3 - @struct.int_1) / 2;
		int num4 = @struct.int_3 - @struct.int_1;
		if (@struct.int_0 < 0 || @struct.int_2 > SystemInformation.PrimaryMonitorSize.Width || @struct.int_3 > SystemInformation.PrimaryMonitorSize.Height)
		{
			SetWindowPos(P_0, 0, num, num3, num2, num4, 0);
		}
	}

	public static void smethod_24(IntPtr P_0, string P_1)
	{
		SetWindowText(P_0, P_1);
	}

	public static Color smethod_25(string P_0)
	{
		return ColorTranslator.FromHtml("#" + P_0);
	}

	public static string smethod_26(Panel P_0)
	{
		return (P_0.BackColor.ToArgb() & 0xFFFFFF).ToString("X6");
	}

	// Encoder tables, indexed by the position in the encoder list (cboVideoEncoder). Indices 0-10 are the
	// original encoders; 11 and 12 were added by the revival. Index 11 is also listed as a 10-bit encoder in
	// the AviSynth template on the server, and 12 was added there, so both get 10-bit input.
	//   11  Software Encoder - AV1 10-bit (SVT-AV1)
	//   12  Nvidia Encoder - AV1 10-bit (NVENC, RTX 40 series and newer)
	public static string smethod_27(int P_0)
	{
		string[] array = new string[13]
		{
			"-c:v libx264 -x264-params keyint=240:min-keyint=1", "-c:v libx265 -x265-params keyint=240:min-keyint=1", "-c:v libx265 -x265-params keyint=240:min-keyint=1", "-c:v h264_qsv", "-c:v hevc_qsv", "-c:v hevc_qsv", "-c:v h264_nvenc -rc constqp", "-c:v hevc_nvenc -rc constqp", "-c:v hevc_nvenc -rc constqp", "-c:v h264_amf -rc cqp",
			"-c:v hevc_amf -rc cqp", "-c:v libsvtav1 -g 240", "-c:v av1_nvenc -rc constqp -tune hq -g 240"
		};
		return array[P_0];
	}

	public static string smethod_28(int P_0, int P_1)
	{
		string[] array = new string[7] { "-preset veryslow", "-preset slower", "-preset slow", "-preset medium", "-preset fast", "-preset faster", "-preset veryfast" };
		string[] array2 = new string[3] { "-preset slow", "-preset medium", "-preset fast" };
		string[] array3 = new string[3] { "-quality quality", "-quality balanced", "-quality speed" };
		// SVT-AV1 presets for the seven software preset names (Very Slow ... Very Fast)
		string[] array4 = new string[7] { "-preset 3", "-preset 4", "-preset 5", "-preset 6", "-preset 8", "-preset 10", "-preset 12" };
		// NVENC AV1 presets for Slow / Medium / Fast
		string[] array5 = new string[3] { "-preset p7", "-preset p5", "-preset p3" };
		if (P_0 == 6 || P_0 == 7 || P_0 == 8)
		{
			return array2[P_1];
		}
		if (P_0 == 9 || P_0 == 10)
		{
			return array3[P_1];
		}
		if (P_0 == 11)
		{
			return array4[P_1];
		}
		if (P_0 == 12)
		{
			return array5[P_1];
		}
		return array[P_1];
	}

	public static string smethod_29(int P_0)
	{
		string[] array = new string[13]
		{
			"-profile:v high -tune film", "-profile:v main", "-profile:v main10", "-profile:v high -look_ahead 0", "-profile:v main -load_plugins 6fadc791a0c2eb479ab6dcd5ea9da347", "-profile:v main10 -load_plugins 6fadc791a0c2eb479ab6dcd5ea9da347", "-profile:v high", "-profile:v main", "-profile:v main10", "-profile:v high",
			"-profile:v main", "", ""
		};
		return array[P_0];
	}

	// The quality slider (10-28) keeps the HEVC scale for every encoder, so the recommendations shown next to it
	// stay valid. The AV1 encoders use other scales; these mappings were measured to give the same SSIM as HEVC
	// at the same slider value (NVENC AV1: QP 0-255, SVT-AV1: CRF 0-63).
	public static string smethod_30(int P_0, int P_1)
	{
		string[] array = new string[13]
		{
			$"-crf {P_1}",
			$"-crf {P_1}",
			$"-crf {P_1}",
			$"-q {P_1}",
			$"-q {P_1}",
			$"-q {P_1}",
			$"-qp {P_1}",
			$"-qp {P_1}",
			$"-qp {P_1}",
			$"-qp_i {P_1} -qp_p {P_1} -qp_b {P_1}",
			$"-qp_i {P_1} -qp_p {P_1}",
			$"-crf {Math.Max(1, Math.Min(63, (int)Math.Round(1.75 * P_1 - 10.0)))}",
			$"-qp {Math.Max(1, Math.Min(255, 5 * P_1 - 30))}"
		};
		return array[P_0];
	}

	public static string smethod_31(int P_0, int P_1)
	{
		string[] array = new string[4] { "128k", "192k", "256k", "320k" };
		if (P_0 == 0)
		{
			return "-c:a aac -aac_coder:a 1 -b:a " + array[P_1];
		}
		return "-c:a flac -compression_level:a 8";
	}

	public static string smethod_32(string P_0)
	{
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(P_0);
		string text = native_MediaInfo.method_13(Enum0.Value1, 0, "FrameRate_Num");
		if (text == "")
		{
			return "0";
		}
		return text;
	}

	public static string smethod_33(string P_0)
	{
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(P_0);
		string text = native_MediaInfo.method_13(Enum0.Value1, 0, "FrameRate_Den");
		if (text == "")
		{
			return "0";
		}
		return text;
	}

	public static void smethod_34()
	{
		try
		{
			foreach (string item in from P_0 in Directory.GetFiles(smethod_37() + "\\languages\\fonts\\", "*.*", SearchOption.AllDirectories)
				where Regex.IsMatch(P_0.ToLower(), "^.+\\.(fon|ttc|ttf|otf)$")
				select P_0)
			{
				File.Copy(item, Environment.ExpandEnvironmentVariables("%SystemRoot%\\Fonts") + "\\" + Path.GetFileName(item.ToLower()), overwrite: true);
			}
			Process.Start(smethod_37() + "\\languages\\Fonts\\FontReg.exe");
		}
		catch
		{
		}
	}

	public static void smethod_35()
	{
		try
		{
			if (File.Exists(smethod_37() + "\\codecs\\AviSynth.dll"))
			{
				File.Copy(smethod_37() + "\\codecs\\AviSynth.dll", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32") + "\\AviSynth.dll", overwrite: true);
			}
			if (File.Exists(smethod_37() + "\\codecs\\DevIL.dll"))
			{
				File.Copy(smethod_37() + "\\codecs\\DevIL.dll", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32") + "\\DevIL.dll", overwrite: true);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
			Environment.Exit(0);
		}
	}

	public static string smethod_36()
	{
		return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "trash\\");
	}

	public static string smethod_37()
	{
		return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Konayuki Container");
	}

	public static void smethod_38()
	{
		try
		{
			Directory.Delete(smethod_37());
		}
		catch
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.Arguments = "/c RD /S /Q \"" + smethod_37() + "\"";
			process.Start();
			process.WaitForExit();
		}
		if (!CreateSymbolicLink(smethod_37(), Application.StartupPath, 1))
		{
			MessageBox.Show("Can't create container please contact https://m.me/Konayuki.moe", "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Environment.Exit(0);
		}
	}

	public static string smethod_39(string P_0, string P_1)
	{
		string text = smethod_36() + smethod_18(P_0 + Path.GetFileName(P_1)) + Path.GetExtension(P_1);
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		if (File.Exists(P_1) && CreateSymbolicLink(text, P_1, 0))
		{
			File.SetAttributes(text, FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory);
		}
		return text;
	}

	public static string smethod_40(string P_0)
	{
		SafeFileHandle safeFileHandle = CreateFileW(P_0, 0, 2, IntPtr.Zero, 3, 33554432, IntPtr.Zero);
		if (safeFileHandle.IsInvalid)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(512);
		int finalPathNameByHandleW = GetFinalPathNameByHandleW(safeFileHandle.DangerousGetHandle(), stringBuilder, stringBuilder.Capacity, 0);
		if (finalPathNameByHandleW < 0)
		{
			return string.Empty;
		}
		if (stringBuilder[0] == '\\' && stringBuilder[1] == '\\' && stringBuilder[2] == '?' && stringBuilder[3] == '\\')
		{
			return stringBuilder.ToString().Substring(4);
		}
		return stringBuilder.ToString();
	}

	public static string smethod_41(string P_0)
	{
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			string text = native_MediaInfo.method_13(Enum0.Value1, 0, "FrameRate_Mode/String");
			native_MediaInfo.method_5();
			return (text == string.Empty) ? "NULL" : text;
		}
		catch
		{
		}
		return "NULL";
	}

	public static string smethod_42(string P_0)
	{
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			string value = Regex.Match(native_MediaInfo.method_13(Enum0.Value1, 0, "Rotation/String"), "\\d+").Value;
			native_MediaInfo.method_5();
			return (value == string.Empty) ? "0" : value;
		}
		catch
		{
		}
		return "0";
	}

	public static string smethod_43(string P_0)
	{
		try
		{
			Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
			native_MediaInfo.method_0(P_0);
			string text = native_MediaInfo.method_13(Enum0.Value1, 0, "colour_range");
			native_MediaInfo.method_5();
			return (text == string.Empty) ? "NULL" : text;
		}
		catch
		{
		}
		return "NULL";
	}

	static Class48()
	{
		ShowAgain = false;
		random_0 = new Random();
	}
}
