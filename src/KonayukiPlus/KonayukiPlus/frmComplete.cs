using System;
using System.ComponentModel;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace KonayukiPlus;

public class frmComplete : MetroForm
{
	private Timer timer_0;

	public static string string_0 = "Restart";

	private IContainer components = null;

	private PictureBox picLogo;

	private Label lblMsgBox;

	private Label lblHeader;

	private Label lblWillStart;

	public frmComplete()
	{
		InitializeComponent();
	}

	public static void smethod_0(int P_0)
	{
		ManagementBaseObject managementBaseObject = null;
		ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
		managementClass.Get();
		managementClass.Scope.Options.EnablePrivileges = true;
		ManagementBaseObject methodParameters = managementClass.GetMethodParameters("Win32Shutdown");
		methodParameters["Flags"] = P_0.ToString();
		methodParameters["Reserved"] = "0";
		foreach (ManagementObject instance in managementClass.GetInstances())
		{
			managementBaseObject = instance.InvokeMethod("Win32Shutdown", methodParameters, null);
		}
	}

	private void frmComplete_Load(object P_0, EventArgs P_1)
	{
		int intValue = 60;
		lblMsgBox.Text = $"Windows will {string_0} in {intValue} second";
		lblWillStart.Text = string_0 + " will start on " + DateTime.Now.Add(new TimeSpan(0, 0, 0, 60)).ToString("yyyy-MM-dd HH:mm:ss");
		timer_0 = new Timer
		{
			Interval = 1000,
			Enabled = true
		};
		timer_0.Tick += delegate
		{
			intValue--;
			if (intValue == 0)
			{
				lblMsgBox.Text = $"Windows will {string_0} in {intValue} second";
				switch (string_0)
				{
				case "Shutdown":
					smethod_0(5);
					break;
				case "Restart":
					smethod_0(6);
					break;
				default:
					smethod_0(4);
					break;
				}
				timer_0.Enabled = false;
				Close();
			}
			else
			{
				lblMsgBox.Text = $"Windows will {string_0} in {intValue} second";
			}
		};
	}

	private void frmComplete_FormClosing(object P_0, FormClosingEventArgs P_1)
	{
		timer_0.Enabled = false;
	}

	private void frmComplete_ResizeBegin(object P_0, EventArgs P_1)
	{
		Opacity = 0.75;
	}

	private void frmComplete_ResizeEnd(object P_0, EventArgs P_1)
	{
		Opacity = 1.0;
	}

	private void picLogo_MouseDown(object P_0, MouseEventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmComplete));
		this.picLogo = new System.Windows.Forms.PictureBox();
		this.lblMsgBox = new System.Windows.Forms.Label();
		this.lblHeader = new System.Windows.Forms.Label();
		this.lblWillStart = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.picLogo).BeginInit();
		base.SuspendLayout();
		this.picLogo.Image = (System.Drawing.Image)resources.GetObject("picLogo.Image");
		this.picLogo.Location = new System.Drawing.Point(11, 13);
		this.picLogo.Name = "picLogo";
		this.picLogo.Size = new System.Drawing.Size(128, 128);
		this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picLogo.TabIndex = 0;
		this.picLogo.TabStop = false;
		this.picLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLogo_MouseDown);
		this.lblMsgBox.AutoSize = true;
		this.lblMsgBox.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMsgBox.ForeColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.lblMsgBox.Location = new System.Drawing.Point(148, 62);
		this.lblMsgBox.Name = "lblMsgBox";
		this.lblMsgBox.Size = new System.Drawing.Size(213, 17);
		this.lblMsgBox.TabIndex = 52;
		this.lblMsgBox.Text = "Windows will shutdown in ? second";
		this.lblHeader.AutoSize = true;
		this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lblHeader.Location = new System.Drawing.Point(145, 13);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(213, 32);
		this.lblHeader.TabIndex = 53;
		this.lblHeader.Text = "After Completion";
		this.lblWillStart.AutoSize = true;
		this.lblWillStart.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblWillStart.ForeColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.lblWillStart.Location = new System.Drawing.Point(148, 97);
		this.lblWillStart.Name = "lblWillStart";
		this.lblWillStart.Size = new System.Drawing.Size(136, 17);
		this.lblWillStart.TabIndex = 54;
		this.lblWillStart.Text = "Shutdown will start on";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
		base.ClientSize = new System.Drawing.Size(500, 152);
		base.Controls.Add(this.lblWillStart);
		base.Controls.Add(this.lblHeader);
		base.Controls.Add(this.lblMsgBox);
		base.Controls.Add(this.picLogo);
		base.DisplayHeader = false;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmComplete";
		base.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
		base.Resizable = false;
		base.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Style = MetroFramework.MetroColorStyle.Pink;
		this.Text = "Completion";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComplete_FormClosing);
		base.Load += new System.EventHandler(this.frmComplete_Load);
		base.ResizeBegin += new System.EventHandler(this.frmComplete_ResizeBegin);
		base.ResizeEnd += new System.EventHandler(this.frmComplete_ResizeEnd);
		((System.ComponentModel.ISupportInitialize)this.picLogo).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
