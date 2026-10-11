using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KonayukiPlus;

public class frmBorder : Form
{
	private struct Struct0
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;
	}

	private IContainer components = null;

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
	private static extern bool GetWindowRect(HandleRef P_0, out Struct0 P_1);

	[DllImport("user32.dll")]
	private static extern IntPtr SetWindowPos(IntPtr P_0, int P_1, int P_2, int P_3, int P_4, int P_5, int P_6);

	public frmBorder()
	{
		Hide();
		InitializeComponent();
		Hide();
	}

	private string method_0()
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		IntPtr foregroundWindow = GetForegroundWindow();
		if (GetWindowText(foregroundWindow, stringBuilder, 256) > 0)
		{
			return stringBuilder.ToString();
		}
		return null;
	}

	private void frmBorder_Load(object P_0, EventArgs P_1)
	{
		SetWindowLong(Handle, -20, GetWindowLong(Handle, -20) | 0x80000 | 0x20);
		Timer timer = new Timer
		{
			Interval = 1,
			Enabled = true
		};
		timer.Tick += delegate
		{
			IntPtr intPtr = FindWindow("PREVIEW", null);
			if (intPtr != new IntPtr(0))
			{
				if (GetForegroundWindow() == intPtr && method_0() != "ffplay")
				{
					GetWindowRect(new HandleRef(this, intPtr), out var @struct);
					int num = SystemInformation.PrimaryMonitorSize.Width / 2 - (@struct.int_2 - @struct.int_0) / 2;
					int num2 = @struct.int_2 - @struct.int_0;
					int num3 = SystemInformation.PrimaryMonitorSize.Height / 2 - (@struct.int_3 - @struct.int_1) / 2;
					int num4 = @struct.int_3 - @struct.int_1;
					if (@struct.int_2 - @struct.int_0 - 8 >= SystemInformation.PrimaryMonitorSize.Width || @struct.int_3 - @struct.int_1 >= SystemInformation.PrimaryMonitorSize.Height)
					{
						Hide();
					}
					else
					{
						SetWindowPos(Handle, 0, @struct.int_0 + 4, @struct.int_1 - 4, @struct.int_2 - 8 - @struct.int_0, @struct.int_3 - @struct.int_1, 0);
						Show();
					}
				}
				else
				{
					Location = new Point(-9999, -9999);
					Hide();
				}
			}
			else
			{
				Location = new Point(-9999, -9999);
				Hide();
			}
		};
	}

	private void frmBorder_Paint(object P_0, PaintEventArgs P_1)
	{
		Pen pen = new Pen(Color.FromArgb(247, 150, 193), 8f);
		P_1.Graphics.DrawLine(pen, new Point(0, 0), new Point(Width, 0));
		P_1.Graphics.DrawLine(pen, new Point(0, 0), new Point(0, Height));
		P_1.Graphics.DrawLine(pen, new Point(Width, 0), new Point(Width, Height));
		P_1.Graphics.DrawLine(pen, new Point(0, Height), new Point(Width, Height));
	}

	private void frmBorder_FormClosing(object P_0, FormClosingEventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmBorder));
		base.SuspendLayout();
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.LightGray;
		base.ClientSize = new System.Drawing.Size(1296, 759);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Location = new System.Drawing.Point(-9999, -9999);
		base.MinimizeBox = false;
		base.Name = "frmBorder";
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		base.TopMost = true;
		base.TransparencyKey = System.Drawing.Color.LightGray;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBorder_FormClosing);
		base.Load += new System.EventHandler(this.frmBorder_Load);
		base.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBorder_Paint);
		base.ResumeLayout(false);
	}
}
