using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KonayukiPlus;

public class frmTimer : Form
{
	private struct Struct1
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;
	}

	private IContainer components = null;

	private Label lblCurrentTime;

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
	private static extern bool GetWindowRect(HandleRef P_0, out Struct1 P_1);

	[DllImport("user32.dll")]
	private static extern IntPtr SetWindowPos(IntPtr P_0, int P_1, int P_2, int P_3, int P_4, int P_5, int P_6);

	public frmTimer()
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

	private void frmTimer_Load(object P_0, EventArgs P_1)
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
					SetWindowPos(Handle, 0, Cursor.Position.X + 15, Cursor.Position.Y + 15, 56, 17, 0);
					if (Cursor.Position.X - (@struct.int_0 + 8) >= 0 && Cursor.Position.X - (@struct.int_0 + 8) <= @struct.int_2 - 8 - (@struct.int_0 + 8) && Cursor.Position.Y - @struct.int_1 >= 0 && Cursor.Position.Y - @struct.int_1 <= @struct.int_3 - @struct.int_1 - 8)
					{
						try
						{
							float num5 = Cursor.Position.X - (@struct.int_0 + 8);
							float num6 = @struct.int_2 - 8 - (@struct.int_0 + 8);
							double num7 = num5 / num6 * 100f;
							double value = TimeSpan.Parse(method_0().Replace(" ", "").Split('|')[1]).TotalSeconds * num7 / 100.0;
							lblCurrentTime.Text = TimeSpan.FromSeconds(value).ToString();
						}
						catch
						{
						}
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

	private void frmTimer_FormClosing(object P_0, FormClosingEventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmTimer));
		this.lblCurrentTime = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.lblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblCurrentTime.ForeColor = System.Drawing.Color.White;
		this.lblCurrentTime.Location = new System.Drawing.Point(0, 0);
		this.lblCurrentTime.Name = "lblCurrentTime";
		this.lblCurrentTime.Size = new System.Drawing.Size(56, 17);
		this.lblCurrentTime.TabIndex = 0;
		this.lblCurrentTime.Text = "00:00:00";
		this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(247, 150, 193);
		base.ClientSize = new System.Drawing.Size(56, 17);
		base.Controls.Add(this.lblCurrentTime);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Location = new System.Drawing.Point(-9999, -9999);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmTimer";
		base.Opacity = 0.9;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Current Time";
		base.TopMost = true;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTimer_FormClosing);
		base.Load += new System.EventHandler(this.frmTimer_Load);
		base.ResumeLayout(false);
	}
}
