using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KonayukiPlus;

public class frmHelp : Form
{
	private struct Struct2
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;
	}

	private IntPtr intPtr_0;

	private frmHelper frmHelper_0 = new frmHelper();

	private IContainer components = null;

	private PictureBox picHelp;

	[DllImport("user32.dll")]
	private static extern bool SetForegroundWindow(IntPtr P_0);

	[DllImport("user32.dll")]
	private static extern int GetWindowText(IntPtr P_0, StringBuilder P_1, int P_2);

	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll")]
	public static extern int GetWindowLong(IntPtr P_0, int P_1);

	[DllImport("user32.dll")]
	public static extern int SetWindowLong(IntPtr P_0, int P_1, int P_2);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern IntPtr FindWindow(string P_0, string P_1);

	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(HandleRef P_0, out Struct2 P_1);

	[DllImport("user32.dll")]
	private static extern IntPtr SetWindowPos(IntPtr P_0, int P_1, int P_2, int P_3, int P_4, int P_5, int P_6);

	public frmHelp()
	{
		Hide();
		InitializeComponent();
		Hide();
		method_0(picHelp, "Click for Help");
	}

	private void method_0(Control P_0, string P_1)
	{
		ToolTip toolTip = new ToolTip();
		toolTip.ShowAlways = true;
		toolTip.SetToolTip(P_0, P_1);
	}

	private string method_1()
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		IntPtr foregroundWindow = GetForegroundWindow();
		if (GetWindowText(foregroundWindow, stringBuilder, 256) > 0)
		{
			return stringBuilder.ToString();
		}
		return null;
	}

	private void frmHelp_Load(object P_0, EventArgs P_1)
	{
		Timer timer = new Timer
		{
			Interval = 1,
			Enabled = true
		};
		timer.Tick += delegate
		{
			intPtr_0 = FindWindow("PREVIEW", null);
			if (intPtr_0 != new IntPtr(0))
			{
				if (method_1() != "HelpButton")
				{
					if (GetForegroundWindow() == intPtr_0 && method_1() != "ffplay")
					{
						GetWindowRect(new HandleRef(this, intPtr_0), out var @struct);
						int num = SystemInformation.PrimaryMonitorSize.Width / 2 - (@struct.int_2 - @struct.int_0) / 2;
						int num2 = @struct.int_2 - @struct.int_0;
						int num3 = SystemInformation.PrimaryMonitorSize.Height / 2 - (@struct.int_3 - @struct.int_1) / 2;
						int num4 = @struct.int_3 - @struct.int_1;
						SetWindowPos(Handle, 0, @struct.int_0 - 46, Class48.smethod_8() ? (@struct.int_1 - 4) : @struct.int_1, 46, 46, 0);
						Show();
					}
					else
					{
						Location = new Point(-9999, -9999);
						Hide();
					}
				}
				else
				{
					GetWindowRect(new HandleRef(this, intPtr_0), out var struct2);
					int num5 = SystemInformation.PrimaryMonitorSize.Width / 2 - (struct2.int_2 - struct2.int_0) / 2;
					int num6 = struct2.int_2 - struct2.int_0;
					int num7 = SystemInformation.PrimaryMonitorSize.Height / 2 - (struct2.int_3 - struct2.int_1) / 2;
					int num8 = struct2.int_3 - struct2.int_1;
					SetWindowPos(Handle, 0, struct2.int_0 - 46, struct2.int_1, 46, 46, 0);
				}
			}
			else
			{
				Location = new Point(-9999, -9999);
				Hide();
			}
		};
	}

	private void picHelp_Click(object P_0, EventArgs P_1)
	{
		SetForegroundWindow(intPtr_0);
		frmHelper.IsHelper = !frmHelper.IsHelper;
	}

	private void frmHelp_FormClosing(object P_0, FormClosingEventArgs P_1)
	{
		if (P_1.CloseReason == CloseReason.ApplicationExitCall || P_1.CloseReason == CloseReason.WindowsShutDown)
		{
			P_1.Cancel = false;
		}
		else
		{
			P_1.Cancel = true;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmHelp));
		this.picHelp = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.picHelp).BeginInit();
		base.SuspendLayout();
		this.picHelp.Image = (System.Drawing.Image)resources.GetObject("picHelp.Image");
		this.picHelp.Location = new System.Drawing.Point(0, 0);
		this.picHelp.Name = "picHelp";
		this.picHelp.Size = new System.Drawing.Size(46, 46);
		this.picHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picHelp.TabIndex = 0;
		this.picHelp.TabStop = false;
		this.picHelp.Click += new System.EventHandler(this.picHelp_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(46, 46);
		base.Controls.Add(this.picHelp);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Location = new System.Drawing.Point(-9999, -9999);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmHelp";
		base.Opacity = 0.9;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "HelpButton";
		base.TopMost = true;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHelp_FormClosing);
		base.Load += new System.EventHandler(this.frmHelp_Load);
		((System.ComponentModel.ISupportInitialize)this.picHelp).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
