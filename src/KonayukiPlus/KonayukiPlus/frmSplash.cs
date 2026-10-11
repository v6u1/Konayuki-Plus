using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteSizeLib;
using Ionic.Zip;
using Newtonsoft.Json;

namespace KonayukiPlus;

public class frmSplash : Form
{
	public static bool bool_0 = false;

	public static bool bool_1 = true;

	private Thread thread_0;

	private string string_0 = string.Empty;

	private bool bool_2 = false;

	private int int_0;

	private int int_1 = 1;

	private string string_1 = string.Empty;

	private Class13 class13_0 = new Class13();

	public static bool bool_3 = false;

	private readonly string string_2 = Server.Api;

	private readonly string[] stringArray_0 = new string[5] { "https://konayuki.moe/", "http://fb.com/konayuki.moe", "https://twitter.com/Konayuki_moe", "https://github.com/Proflylab/", "https://link.konayuki.moe/discord.html" };

	private IContainer components = null;

	private PictureBox picSplash;

	private PictureBox prgBar;

	private Label lblStatus;

	private PictureBox picWebsite;

	private PictureBox picFacebook;

	private PictureBox picGithub;

	private PictureBox picTwitter;

	private PictureBox picDiscord;

	private Label lblAPI;

	public frmSplash()
	{
		InitializeComponent();
		Opacity = 0.0;
	}

	private void method_0()
	{
		// Telemetry removed in the revival. This background thread originally swept the hidden
		// log-staging folder and uploaded any leftover archives via Class10.smethod_6.
	}

	private void method_1()
	{
		Class7.smethod_0();
		byte[] bytes = new byte[16]
		{
			75, 111, 110, 97, 121, 117, 107, 105, 80, 108,
			117, 115, 46, 101, 120, 101
		};
		string_0 = Process.GetCurrentProcess().ProcessName + ".exe";
		if (string_0.Equals(Encoding.ASCII.GetString(bytes)))
		{
			Class48.smethod_2(picWebsite, "Website");
			Class48.smethod_2(picFacebook, "Facebook");
			Class48.smethod_2(picTwitter, "Twitter");
			Class48.smethod_2(picGithub, "Github");
			Class48.smethod_2(picDiscord, "Discord");
			if (bool_1)
			{
				Class48.smethod_34();
				Class48.smethod_35();
			}
		}
		else
		{
			MessageBox.Show("Please change the processname to KonayukiPlus.exe", "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			Application.Exit();
		}
		Class48.smethod_38();
	}

	private void frmSplash_Load(object P_0, EventArgs P_1)
	{
		method_1();
	}

	private async void method_2()
	{
		while (true)
		{
			await Task.Delay(500);
			lblAPI.Text = "Connecting API_Plugins : Con't connect to server?";
			lblAPI.BackColor = ((lblAPI.BackColor == Color.Red) ? Color.Green : Color.Red);
		}
	}

	private void method_3(string P_0)
	{
		int_0 = 100;
		int intValue = 6;
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
		{
			Interval = 500,
			Enabled = true
		};
		timer.Tick += delegate
		{
			if (intValue < 0)
			{
				Application.Exit();
			}
			lblStatus.Visible = false;
			bool_2 = true;
			lblAPI.Text = P_0;
			lblAPI.Visible = !lblAPI.Visible;
			intValue--;
		};
	}

	private void method_4(string P_0, bool P_1 = false)
	{
		string stringValue = string.Empty;
		bool boolValue2 = false;
		bool boolValue3 = true;
		int intValue = 0;
		string stringValue2 = string.Empty;
		WebClient webClient = new WebClient();
		webClient.Encoding = Encoding.UTF8;
		string stringValue3 = string.Empty;
		string stringValue4 = string.Empty;
		string stringValue6 = string.Empty;
		string stringValue7 = string.Empty;
		List<int> list = new List<int>();
		if (!Directory.Exists(Class48.smethod_37() + "\\tmp\\"))
		{
			Directory.CreateDirectory(Class48.smethod_37() + "\\tmp\\");
		}
		File.Delete(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"));
		webClient.DownloadFileAsync(new Uri(P_0 + "/list.txt"), Class48.smethod_37() + "\\tmp\\list.txt");
		webClient.DownloadProgressChanged += (object obj, DownloadProgressChangedEventArgs e) =>
		{
			if (!boolValue3)
			{
				lblStatus.Text = string.Concat(stringValue, " -> ", ByteSize.FromBytes(e.BytesReceived), "/", ByteSize.FromBytes(e.TotalBytesToReceive), $"({e.ProgressPercentage}%)");
			}
		};
		webClient.DownloadFileCompleted += delegate
		{
			try
			{
				boolValue3 = false;
				if (frmMain.string_2.Equals(string.Empty))
				{
					frmMain.string_2 = File.ReadAllText(Class48.smethod_37() + "\\tmp\\list.txt");
				}
				File.Delete(Class48.smethod_37() + "\\tmp\\list.txt");
				MatchCollection matchCollection = Regex.Matches(frmMain.string_2, "(?<filename>.*?)\\|(?<hash>.*?)\\|(?<run>.*?)\\|(?<cmd>.*?)\n");
				if (matchCollection.Count == 0 && !boolValue2)
				{
					method_3("Connecting... Can't connect to server?");
				}
				else if (intValue < matchCollection.Count)
				{
					stringValue2 = matchCollection[intValue].Groups["filename"].ToString();
					stringValue3 = matchCollection[intValue].Groups["hash"].ToString();
					stringValue4 = Class48.smethod_37() + stringValue2;
					if (P_1)
					{
						if (File.Exists(stringValue4))
						{
							File.SetAttributes(stringValue4, FileAttributes.Normal);
							if (stringValue2.Contains(string_0))
							{
								string text = Class48.smethod_5(stringValue4);
								File.Delete(Path.Combine(Class48.smethod_37(), string_0) + ".safe");
								File.Move(Path.Combine(Class48.smethod_37(), string_0), Path.Combine(Class48.smethod_37(), string_0) + ".safe");
								Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
								webClient.DownloadFileAsync(new Uri(P_0 + stringValue2), stringValue4);
								File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [DL] -> " + stringValue2 + "\r\n");
								stringValue = "Downloading... " + Path.GetFileName(stringValue2);
								list.Add(intValue);
							}
							else
							{
								Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
								webClient.DownloadFileAsync(new Uri(P_0 + stringValue2), stringValue4);
								File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [DL] -> " + stringValue2 + "\r\n");
								stringValue = "Downloading... " + Path.GetFileName(stringValue2);
								list.Add(intValue);
							}
						}
						else
						{
							Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
							webClient.DownloadFileAsync(new Uri(P_0 + stringValue2), stringValue4);
							File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [DL] -> " + stringValue2 + "\r\n");
							stringValue = "Downloading... " + Path.GetFileName(stringValue2);
							list.Add(intValue);
						}
					}
					else if (File.Exists(stringValue4))
					{
						File.SetAttributes(stringValue4, FileAttributes.Normal);
						if (stringValue2.Contains(string_0))
						{
							string text2 = Class48.smethod_5(stringValue4);
							File.Delete(Path.Combine(Class48.smethod_37(), string_0) + ".safe");
							File.Move(Path.Combine(Class48.smethod_37(), string_0), Path.Combine(Class48.smethod_37(), string_0) + ".safe");
							if (text2.Equals(stringValue3))
							{
								Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
								Application.DoEvents();
								webClient.DownloadFileAsync(new Uri("about:blank"), Class48.smethod_37() + "\\tmp\\list.txt");
								File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [OK] -> " + stringValue2 + "\r\n");
								lblStatus.Text = "Checking... " + Path.GetFileName(stringValue2);
								if (File.Exists(Path.Combine(Class48.smethod_37(), string_0) + ".safe"))
								{
									File.Move(Path.Combine(Class48.smethod_37(), string_0) + ".safe", Path.Combine(Class48.smethod_37(), string_0));
								}
							}
							else
							{
								Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
								webClient.DownloadFileAsync(new Uri(P_0 + stringValue2), stringValue4);
								File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [UPDATE] -> " + stringValue2 + "\r\n");
								stringValue = "Updating... " + Path.GetFileName(stringValue2);
								list.Add(intValue);
							}
						}
						else if (Class48.smethod_5(stringValue4).Equals(stringValue3))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
							Application.DoEvents();
							webClient.DownloadFileAsync(new Uri("about:blank"), Class48.smethod_37() + "\\tmp\\list.txt");
							File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [OK] -> " + stringValue2 + "\r\n");
							lblStatus.Text = "Checking... " + Path.GetFileName(stringValue2);
						}
						else
						{
							Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
							webClient.DownloadFileAsync(new Uri(P_0 + stringValue2), stringValue4);
							File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [UPDATE] -> " + stringValue2 + "\r\n");
							stringValue = "Updating... " + Path.GetFileName(stringValue2);
							list.Add(intValue);
						}
					}
					else
					{
						Directory.CreateDirectory(Path.GetDirectoryName(stringValue4));
						webClient.DownloadFileAsync(new Uri(P_0 + stringValue2), stringValue4);
						File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [DL] -> " + stringValue2 + "\r\n");
						stringValue = "Downloading... " + Path.GetFileName(stringValue2);
						list.Add(intValue);
					}
					intValue++;
					int_0 = (int)(100f / (float)matchCollection.Count * (float)intValue);
				}
				else
				{
					bool flag = false;
					bool flag2 = false;
					foreach (int item in list)
					{
						frmMain.bool_3 = true;
						stringValue2 = matchCollection[item].Groups["filename"].ToString();
						stringValue3 = matchCollection[item].Groups["hash"].ToString();
						stringValue6 = matchCollection[item].Groups["run"].ToString();
						stringValue7 = matchCollection[item].Groups["cmd"].ToString();
						stringValue4 = Class48.smethod_37() + stringValue2;
						if (Class48.smethod_5(stringValue4).Equals(stringValue3))
						{
							if (stringValue2.Contains(string_0))
							{
								flag2 = true;
							}
							else if (Path.GetExtension(stringValue4).ToLower().Equals(".zip"))
							{
								lblStatus.Text = "Extracting... " + Path.GetFileName(stringValue4);
								File.AppendAllText(Path.Combine(Class48.smethod_37(), "tmp", "synclog.log"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " [EXTACT] -> " + stringValue2 + "\r\n");
								using ZipFile zipFile = ZipFile.Read(stringValue4);
								zipFile.ExtractAll(Path.GetDirectoryName(stringValue4), ExtractExistingFileAction.OverwriteSilently);
							}
							else
							{
								TopMost = false;
								if (stringValue6.Equals(bool.TrueString))
								{
									lblStatus.Text = "Installing... " + Path.GetFileName(stringValue4);
									Process process = new Process();
									process.StartInfo.FileName = stringValue4;
									process.StartInfo.Arguments = stringValue7;
									process.StartInfo.ErrorDialog = true;
									process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
									process.Start();
									while (!process.HasExited)
									{
										Application.DoEvents();
									}
									process.WaitForExit();
								}
							}
						}
						else
						{
							flag = true;
						}
					}
					if (flag)
					{
						method_3("File Corruption");
					}
					else if (flag2)
					{
						if (File.Exists(Path.Combine(Class48.smethod_37(), string_0)))
						{
							int_0 = 100;
							int intValue2 = 6;
							System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
							{
								Interval = 500,
								Enabled = true
							};
							timer.Tick += delegate
							{
								if (intValue2 < 0)
								{
									if (File.Exists(Path.Combine(Class48.smethod_37(), string_0)))
									{
										Process.Start(Path.Combine(Application.StartupPath, string_0), "/log");
										Application.Exit();
									}
									else
									{
										method_3("KonayukiPlus.exe file not found!!");
									}
								}
								lblStatus.Visible = false;
								bool_2 = true;
								lblAPI.Text = (P_1 ? "The repair has been completed" : "KonayukiPlus.exe has changed");
								lblAPI.Visible = !lblAPI.Visible;
								intValue2--;
							};
						}
						else
						{
							method_3("KonayukiPlus.exe file not found!!");
						}
					}
					else
					{
						int_0 = 101;
					}
				}
			}
			catch
			{
				boolValue2 = true;
				method_3("Connecting... Can't connect to server?");
			}
		};
	}

	private void frmSplash_Shown(object P_0, EventArgs P_1)
	{
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
		{
			Interval = 1
		};
		if (bool_0)
		{
			lblStatus.Visible = true;
			lblStatus.Text = "Developer Mode";
			if (File.Exists(Class48.smethod_37() + "\\plugins.cfg"))
			{
				string_1 = File.ReadAllText(Class48.smethod_37() + "\\plugins.cfg");
			}
			else
			{
				string_1 = bool.TrueString;
			}
		}
		else
		{
			string_1 = Class12.smethod_0(string_2);
		}
		Opacity = 1.0;
		if (string_1 == bool.TrueString)
		{
			int intValue = 11;
			System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer
			{
				Interval = 500,
				Enabled = true
			};
			timer2.Tick += delegate
			{
				if (intValue < 0)
				{
					Application.Exit();
				}
				lblAPI.Text = "Connecting... Can't connect to server?";
				lblAPI.Visible = !lblAPI.Visible;
				intValue--;
			};
			return;
		}
		frmMain.string_0 = string_1;
		class13_0 = JsonConvert.DeserializeObject<Class13>(Class48.smethod_19(Class49.smethod_1(string_1), false));
		frmMain.string_1 = class13_0.Version;
		frmProcess.FList = class13_0.Proc;
		Class10.PList = class13_0.Proxy;
		int intValue2 = 7;
		System.Windows.Forms.Timer timer3 = new System.Windows.Forms.Timer
		{
			Interval = 250,
			Enabled = true
		};
		timer3.Tick += delegate
		{
			lblAPI.Text = "Connecting... API V." + frmMain.string_1;
			lblAPI.Visible = !lblAPI.Visible;
			intValue2--;
			if (intValue2 <= 0)
			{
				timer.Start();
				timer3.Stop();
				lblStatus.Visible = true;
				if (bool_0)
				{
					int_0 = 101;
				}
				else
				{
					method_4(Server.Sync, bool_3);
				}
			}
		};
		int intValue3 = prgBar.Width;
		int intValue4 = prgBar.Height;
		double doubleValue = (double)intValue3 / 100.0;
		int_0 = 0;
		Bitmap bitmap = new Bitmap(intValue3, intValue4);
		timer.Tick += delegate
		{
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.FromArgb(247, 150, 193));
			graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, (int)((double)int_0 * doubleValue), intValue4));
			if (bool_2)
			{
				graphics.DrawString(null, new Font("Segoe UI", intValue4 / 2, FontStyle.Bold), Brushes.Pink, new PointF(intValue3 / 2 - intValue4, intValue4 / 10));
			}
			else
			{
				graphics.DrawString(int_0 + "%", new Font("Segoe UI", intValue4 / 2, FontStyle.Bold), Brushes.Pink, new PointF(intValue3 / 2 - intValue4, intValue4 / 10));
			}
			prgBar.Image = bitmap;
			if (int_0 > 100)
			{
				graphics.Dispose();
				timer.Stop();
				frmMain frmMain2 = new frmMain();
				frmMain2.Show();
				Hide();
				thread_0 = new Thread(method_0);
				thread_0.Start();
			}
		};
	}

	private void prgBar_Paint(object P_0, PaintEventArgs P_1)
	{
		ControlPaint.DrawBorder(P_1.Graphics, prgBar.ClientRectangle, Color.White, ButtonBorderStyle.Dashed);
	}

	private void frmSplash_FormClosing(object P_0, FormClosingEventArgs P_1)
	{
		if (int_0 <= 100)
		{
			P_1.Cancel = true;
		}
		if (P_1.CloseReason == CloseReason.ApplicationExitCall || P_1.CloseReason == CloseReason.WindowsShutDown)
		{
			if (thread_0 != null)
			{
				thread_0.Abort();
			}
			P_1.Cancel = false;
		}
	}

	private void picWebsite_Click(object P_0, EventArgs P_1)
	{
		Process.Start(stringArray_0[0]);
	}

	private void picFacebook_Click(object P_0, EventArgs P_1)
	{
		Process.Start(stringArray_0[1]);
	}

	private void picTwitter_Click(object P_0, EventArgs P_1)
	{
		Process.Start(stringArray_0[2]);
	}

	private void picGithub_Click(object P_0, EventArgs P_1)
	{
		Process.Start(stringArray_0[3]);
	}

	private void picDiscord_Click(object P_0, EventArgs P_1)
	{
		Process.Start(stringArray_0[4]);
	}

	private void picSplash_MouseDown(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Clicks == 1 && P_1.Button == MouseButtons.Left)
		{
			Opacity = 0.75;
			this.smethod_14();
			Opacity = 1.0;
		}
	}

	private void lblAPI_MouseDown(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Clicks == 1 && P_1.Button == MouseButtons.Left)
		{
			Opacity = 0.75;
			this.smethod_14();
			Opacity = 1.0;
		}
	}

	private void prgBar_MouseDown(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Clicks == 1 && P_1.Button == MouseButtons.Left)
		{
			Opacity = 0.75;
			this.smethod_14();
			Opacity = 1.0;
		}
	}

	private void lblStatus_MouseDown(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Clicks == 1 && P_1.Button == MouseButtons.Left)
		{
			Opacity = 0.75;
			this.smethod_14();
			Opacity = 1.0;
		}
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && components != null)
		{
			components.Dispose();
		}
		base.Dispose(P_0);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmSplash));
		this.lblStatus = new System.Windows.Forms.Label();
		this.prgBar = new System.Windows.Forms.PictureBox();
		this.picSplash = new System.Windows.Forms.PictureBox();
		this.picWebsite = new System.Windows.Forms.PictureBox();
		this.picFacebook = new System.Windows.Forms.PictureBox();
		this.picGithub = new System.Windows.Forms.PictureBox();
		this.picTwitter = new System.Windows.Forms.PictureBox();
		this.picDiscord = new System.Windows.Forms.PictureBox();
		this.lblAPI = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.prgBar).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picSplash).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picWebsite).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picFacebook).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picGithub).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picTwitter).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picDiscord).BeginInit();
		base.SuspendLayout();
		this.lblStatus.AutoSize = true;
		this.lblStatus.BackColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus.ForeColor = System.Drawing.Color.White;
		this.lblStatus.Location = new System.Drawing.Point(222, 154);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(67, 15);
		this.lblStatus.TabIndex = 2;
		this.lblStatus.Text = "Checking...";
		this.lblStatus.Visible = false;
		this.lblStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblStatus_MouseDown);
		this.prgBar.BackColor = System.Drawing.Color.White;
		this.prgBar.Location = new System.Drawing.Point(224, 128);
		this.prgBar.Name = "prgBar";
		this.prgBar.Size = new System.Drawing.Size(401, 18);
		this.prgBar.TabIndex = 1;
		this.prgBar.TabStop = false;
		this.prgBar.Paint += new System.Windows.Forms.PaintEventHandler(this.prgBar_Paint);
		this.prgBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.prgBar_MouseDown);
		this.picSplash.Image = (System.Drawing.Image)resources.GetObject("picSplash.Image");
		this.picSplash.Location = new System.Drawing.Point(0, 0);
		this.picSplash.Name = "picSplash";
		this.picSplash.Size = new System.Drawing.Size(667, 223);
		this.picSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picSplash.TabIndex = 0;
		this.picSplash.TabStop = false;
		this.picSplash.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSplash_MouseDown);
		this.picWebsite.Image = (System.Drawing.Image)resources.GetObject("picWebsite.Image");
		this.picWebsite.Location = new System.Drawing.Point(527, 15);
		this.picWebsite.Name = "picWebsite";
		this.picWebsite.Size = new System.Drawing.Size(20, 19);
		this.picWebsite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picWebsite.TabIndex = 3;
		this.picWebsite.TabStop = false;
		this.picWebsite.Click += new System.EventHandler(this.picWebsite_Click);
		this.picFacebook.Image = (System.Drawing.Image)resources.GetObject("picFacebook.Image");
		this.picFacebook.Location = new System.Drawing.Point(553, 15);
		this.picFacebook.Name = "picFacebook";
		this.picFacebook.Size = new System.Drawing.Size(20, 19);
		this.picFacebook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picFacebook.TabIndex = 4;
		this.picFacebook.TabStop = false;
		this.picFacebook.Click += new System.EventHandler(this.picFacebook_Click);
		this.picGithub.Image = (System.Drawing.Image)resources.GetObject("picGithub.Image");
		this.picGithub.Location = new System.Drawing.Point(605, 15);
		this.picGithub.Name = "picGithub";
		this.picGithub.Size = new System.Drawing.Size(20, 19);
		this.picGithub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picGithub.TabIndex = 5;
		this.picGithub.TabStop = false;
		this.picGithub.Click += new System.EventHandler(this.picGithub_Click);
		this.picTwitter.Image = (System.Drawing.Image)resources.GetObject("picTwitter.Image");
		this.picTwitter.Location = new System.Drawing.Point(579, 15);
		this.picTwitter.Name = "picTwitter";
		this.picTwitter.Size = new System.Drawing.Size(20, 19);
		this.picTwitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picTwitter.TabIndex = 6;
		this.picTwitter.TabStop = false;
		this.picTwitter.Click += new System.EventHandler(this.picTwitter_Click);
		this.picDiscord.Image = (System.Drawing.Image)resources.GetObject("picDiscord.Image");
		this.picDiscord.Location = new System.Drawing.Point(631, 15);
		this.picDiscord.Name = "picDiscord";
		this.picDiscord.Size = new System.Drawing.Size(19, 22);
		this.picDiscord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picDiscord.TabIndex = 7;
		this.picDiscord.TabStop = false;
		this.picDiscord.Click += new System.EventHandler(this.picDiscord_Click);
		this.lblAPI.BackColor = System.Drawing.Color.White;
		this.lblAPI.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAPI.ForeColor = System.Drawing.Color.Pink;
		this.lblAPI.Location = new System.Drawing.Point(224, 128);
		this.lblAPI.Name = "lblAPI";
		this.lblAPI.Size = new System.Drawing.Size(401, 18);
		this.lblAPI.TabIndex = 8;
		this.lblAPI.Text = "Connnecting...";
		this.lblAPI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblAPI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblAPI_MouseDown);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.LightGray;
		base.ClientSize = new System.Drawing.Size(667, 223);
		base.Controls.Add(this.lblAPI);
		base.Controls.Add(this.picDiscord);
		base.Controls.Add(this.picTwitter);
		base.Controls.Add(this.picGithub);
		base.Controls.Add(this.picFacebook);
		base.Controls.Add(this.picWebsite);
		base.Controls.Add(this.lblStatus);
		base.Controls.Add(this.prgBar);
		base.Controls.Add(this.picSplash);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmSplash";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "KONAYUKI SYNC⁺";
		base.TopMost = true;
		base.TransparencyKey = System.Drawing.Color.LightGray;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSplash_FormClosing);
		base.Load += new System.EventHandler(this.frmSplash_Load);
		base.Shown += new System.EventHandler(this.frmSplash_Shown);
		((System.ComponentModel.ISupportInitialize)this.prgBar).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picSplash).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picWebsite).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picFacebook).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picGithub).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picTwitter).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picDiscord).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
