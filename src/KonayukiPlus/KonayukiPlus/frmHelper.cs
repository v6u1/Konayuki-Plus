using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KonayukiPlus;

public class frmHelper : Form
{
	private struct Struct3
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool IsHelper__BackingField;

	public static string string_0;

	private IContainer components = null;

	private PictureBox picHelper;

	public static bool IsHelper
	{
		[CompilerGenerated]
		get
		{
			return IsHelper__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsHelper__BackingField = value;
		}
	}

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
	private static extern bool GetWindowRect(HandleRef P_0, out Struct3 P_1);

	[DllImport("user32.dll")]
	private static extern IntPtr SetWindowPos(IntPtr P_0, int P_1, int P_2, int P_3, int P_4, int P_5, int P_6);

	public frmHelper()
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

	private void frmHelper_Load(object P_0, EventArgs P_1)
	{
		if (File.Exists(Class48.smethod_37() + "\\languages\\Overlay\\" + string_0 + ".png"))
		{
			picHelper.Image = Image.FromFile(Class48.smethod_37() + "\\languages\\Overlay\\" + string_0 + ".png");
		}
		SetWindowLong(Handle, -20, GetWindowLong(Handle, -20) | 0x80000 | 0x20);
		Timer timer = new Timer
		{
			Interval = 1,
			Enabled = true
		};
		timer.Tick += delegate
		{
			IntPtr intPtr = FindWindow("PREVIEW", null);
			if (IsHelper)
			{
				if (intPtr != new IntPtr(0))
				{
					if (GetForegroundWindow() == intPtr && method_0() != "ffplay")
					{
						GetWindowRect(new HandleRef(this, intPtr), out var @struct);
						int num = SystemInformation.PrimaryMonitorSize.Width / 2 - (@struct.int_2 - @struct.int_0) / 2;
						int num2 = @struct.int_2 - @struct.int_0;
						int num3 = SystemInformation.PrimaryMonitorSize.Height / 2 - (@struct.int_3 - @struct.int_1) / 2;
						int num4 = @struct.int_3 - @struct.int_1;
						if ((GetWindowLong(intPtr, -16) & 0x10000) != 65536)
						{
							SetWindowPos(Handle, 0, 0, 0, picHelper.Width, picHelper.Height, 0);
						}
						else
						{
							if (@struct.int_2 - 8 - (@struct.int_0 + 8) >= picHelper.Width && @struct.int_3 - (@struct.int_1 + 39) >= picHelper.Height)
							{
								SetWindowPos(Handle, 0, @struct.int_0 + 8, @struct.int_1 + 31, picHelper.Width, picHelper.Height, 0);
							}
							else
							{
								SetWindowPos(Handle, 0, @struct.int_0 + 8, @struct.int_1 + 31, (@struct.int_2 - 8 - (@struct.int_0 + 8) >= picHelper.Width) ? picHelper.Width : (@struct.int_2 - 8 - (@struct.int_0 + 8)), (@struct.int_3 - (@struct.int_1 + 39) >= picHelper.Height) ? picHelper.Height : (@struct.int_3 - (@struct.int_1 + 39)), 0);
							}
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
			}
			else
			{
				Location = new Point(-9999, -9999);
				Hide();
			}
		};
	}

	private void frmHelper_FormClosing(object P_0, FormClosingEventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmHelper));
		this.picHelper = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.picHelper).BeginInit();
		base.SuspendLayout();
		this.picHelper.Image = (System.Drawing.Image)resources.GetObject("picHelper.Image");
		this.picHelper.Location = new System.Drawing.Point(0, 0);
		this.picHelper.Name = "picHelper";
		this.picHelper.Size = new System.Drawing.Size(470, 504);
		this.picHelper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picHelper.TabIndex = 1;
		this.picHelper.TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(470, 504);
		base.Controls.Add(this.picHelper);
		base.Enabled = false;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Location = new System.Drawing.Point(-9999, -9999);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmHelper";
		base.Opacity = 0.9;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmHelper";
		base.TopMost = true;
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHelper_FormClosing);
		base.Load += new System.EventHandler(this.frmHelper_Load);
		((System.ComponentModel.ISupportInitialize)this.picHelper).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	static frmHelper()
	{
		IsHelper = false;
		string_0 = string.Empty;
	}
}
