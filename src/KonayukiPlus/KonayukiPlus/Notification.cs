using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonayukiPlus.Properties;
using NAudio.Wave;
using Newtonsoft.Json;

namespace KonayukiPlus;

public class Notification : Form
{
	private Class4 class4_0 = new Class4();

	private const int int_0 = 131072;

	private Timer timer_0 = new Timer();

	private static readonly List<Notification> list_0 = new List<Notification>();

	private bool bool_0;

	private readonly Class1 class1_0;

	private IntPtr intPtr_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string FilePath__BackingField;

	private bool bool_1 = false;

	private IContainer components = null;

	private Label lblMessage;

	private PictureBox picLogo;

	private Label lblTitle;

	public static string FilePath
	{
		[CompilerGenerated]
		get
		{
			return FilePath__BackingField;
		}
		[CompilerGenerated]
		set
		{
			FilePath__BackingField = value;
		}
	}

	protected override CreateParams CreateParams
	{
		[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
		get
		{
			CreateParams createParams = base.CreateParams;
			if (DropShadowSupported)
			{
				createParams.ClassStyle |= 131072;
			}
			return createParams;
		}
	}

	public static bool DropShadowSupported
	{
		get
		{
			OperatingSystem oSVersion = Environment.OSVersion;
			return oSVersion.Platform == PlatformID.Win32NT && oSVersion.Version.CompareTo(new Version(5, 1, 0, 0)) >= 0;
		}
	}

	private async void method_0(string P_0)
	{
		WaveOut waveOut = new WaveOut();
		Mp3FileReader mp3FileReader = new Mp3FileReader(Path.Combine(Class48.smethod_37(), P_0));
		waveOut.Init(mp3FileReader);
		waveOut.Play();
		await Task.Delay(3000);
		waveOut.Stop();
		mp3FileReader.Close();
	}

	public Notification(string P_0, string P_1, int P_2, Enum13 P_3, Class1.Enum5 P_4, Class1.Enum6 P_5, bool P_6 = false)
	{
		class4_0 = JsonConvert.DeserializeObject<Class4>(File.ReadAllText(Class48.smethod_37() + "\\configs.json"));
		InitializeComponent();
		try
		{
			switch (P_3)
			{
			case Enum13.Value0:
				method_0(class4_0.NotifySound[(int)P_3]);
				break;
			case Enum13.Value4:
				lblTitle.ForeColor = Color.PaleVioletRed;
				picLogo.Image = new Bitmap(Resources.MsgBox_Error);
				method_0(class4_0.NotifySound[(int)P_3]);
				break;
			case Enum13.Value1:
				lblTitle.ForeColor = Color.SkyBlue;
				picLogo.Image = new Bitmap(Resources.MsgBox_Info);
				method_0(class4_0.NotifySound[(int)P_3]);
				break;
			case Enum13.Value2:
				lblTitle.ForeColor = Color.LightGreen;
				picLogo.Image = new Bitmap(Resources.MsgBox_Success);
				method_0(class4_0.NotifySound[(int)P_3]);
				break;
			case Enum13.Value3:
				lblTitle.ForeColor = Color.Orange;
				picLogo.Image = new Bitmap(Resources.MsgBox_Warning);
				method_0(class4_0.NotifySound[(int)P_3]);
				break;
			default:
				new SoundPlayer(Resources.landscape).Play();
				break;
			}
		}
		catch
		{
			switch (P_3)
			{
			case Enum13.Value0:
				new SoundPlayer(Resources.garden).Play();
				break;
			case Enum13.Value4:
				lblTitle.ForeColor = Color.PaleVioletRed;
				picLogo.Image = new Bitmap(Resources.MsgBox_Error);
				new SoundPlayer(Resources.festival).Play();
				break;
			case Enum13.Value1:
				lblTitle.ForeColor = Color.SkyBlue;
				picLogo.Image = new Bitmap(Resources.MsgBox_Info);
				new SoundPlayer(Resources.savanna).Play();
				break;
			case Enum13.Value2:
				lblTitle.ForeColor = Color.LightGreen;
				picLogo.Image = new Bitmap(Resources.MsgBox_Success);
				new SoundPlayer(Resources.cityscape).Play();
				break;
			case Enum13.Value3:
				lblTitle.ForeColor = Color.Orange;
				picLogo.Image = new Bitmap(Resources.MsgBox_Warning);
				new SoundPlayer(Resources.landscape).Play();
				break;
			default:
				new SoundPlayer(Resources.landscape).Play();
				break;
			}
		}
		timer_0.Interval = 100;
		timer_0.Enabled = false;
		timer_0.Tick += timer_0_Tick;
		P_2 = ((P_2 >= 0) ? (P_2 * 1000) : int.MaxValue);
		timer_0.Interval = P_2;
		lblTitle.Text = P_0;
		lblMessage.Text = P_1;
		class1_0 = new Class1(this, P_4, P_5, 500);
		bool_1 = P_6;
	}

	private void timer_0_Tick(object P_0, EventArgs P_1)
	{
		Close();
	}

	public void method_1()
	{
		intPtr_0 = Native_user32.GetForegroundWindow();
		Show();
	}

	private void Notification_Load(object P_0, EventArgs P_1)
	{
		ToolTip toolTip = new ToolTip();
		toolTip.ShowAlways = true;
		toolTip.SetToolTip(lblTitle, lblTitle.Text);
		Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 18, Screen.PrimaryScreen.WorkingArea.Height - Height - 10);
		foreach (Notification item in list_0)
		{
			item.Top -= Height + 10;
		}
		list_0.Add(this);
		timer_0.Start();
	}

	private void Notification_Activated(object P_0, EventArgs P_1)
	{
		if (!bool_0)
		{
			Native_user32.SetForegroundWindow(intPtr_0);
		}
	}

	private void Notification_Shown(object P_0, EventArgs P_1)
	{
		bool_0 = true;
		class1_0.Duration = 0;
		class1_0.Direction = Class1.Enum6.Value2;
	}

	private void Notification_FormClosing(object P_0, FormClosingEventArgs P_1)
	{
		foreach (Notification item in list_0)
		{
			if (item == this)
			{
				break;
			}
			item.Top += Height;
		}
		list_0.Remove(this);
	}

	private void Notification_Click(object P_0, EventArgs P_1)
	{
		if (bool_1)
		{
			Process.Start("explorer", "/select," + FilePath);
		}
		Close();
	}

	private void picLogo_Click(object P_0, EventArgs P_1)
	{
		if (bool_1)
		{
			Process.Start("explorer", "/select," + FilePath);
		}
		Close();
	}

	private void lblTitle_Click(object P_0, EventArgs P_1)
	{
		if (bool_1)
		{
			Process.Start("explorer", "/select," + FilePath);
		}
		Close();
	}

	private void lblMessage_Click(object P_0, EventArgs P_1)
	{
		if (bool_1)
		{
			Process.Start("explorer", "/select," + FilePath);
		}
		Close();
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.Notification));
		this.lblMessage = new System.Windows.Forms.Label();
		this.lblTitle = new System.Windows.Forms.Label();
		this.picLogo = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.picLogo).BeginInit();
		base.SuspendLayout();
		this.lblMessage.BackColor = System.Drawing.Color.Transparent;
		this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMessage.ForeColor = System.Drawing.Color.DimGray;
		this.lblMessage.Location = new System.Drawing.Point(98, 36);
		this.lblMessage.Name = "lblMessage";
		this.lblMessage.Size = new System.Drawing.Size(283, 55);
		this.lblMessage.TabIndex = 2;
		this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
		this.lblTitle.BackColor = System.Drawing.Color.Transparent;
		this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lblTitle.Location = new System.Drawing.Point(98, 9);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.Size = new System.Drawing.Size(283, 24);
		this.lblTitle.TabIndex = 3;
		this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
		this.picLogo.Image = (System.Drawing.Image)resources.GetObject("picLogo.Image");
		this.picLogo.Location = new System.Drawing.Point(6, 9);
		this.picLogo.Name = "picLogo";
		this.picLogo.Size = new System.Drawing.Size(84, 84);
		this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picLogo.TabIndex = 4;
		this.picLogo.TabStop = false;
		this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(390, 100);
		base.Controls.Add(this.lblMessage);
		base.Controls.Add(this.picLogo);
		base.Controls.Add(this.lblTitle);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "Notification";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		base.TopMost = true;
		base.Activated += new System.EventHandler(this.Notification_Activated);
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notification_FormClosing);
		base.Load += new System.EventHandler(this.Notification_Load);
		base.Shown += new System.EventHandler(this.Notification_Shown);
		base.Click += new System.EventHandler(this.Notification_Click);
		((System.ComponentModel.ISupportInitialize)this.picLogo).EndInit();
		base.ResumeLayout(false);
	}
}
