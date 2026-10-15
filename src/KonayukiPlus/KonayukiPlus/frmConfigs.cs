using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using KonayukiPlus.Properties;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using NAudio.Wave;
using Newtonsoft.Json;

namespace KonayukiPlus;

public class frmConfigs : MetroForm
{
	private Class4 class4_0 = new Class4();

	private IContainer components = null;

	private MetroTabControl tcConfig;

	private MetroTabPage tpGeneral;

	private MetroComboBox cboAfterCompletion;

	private MetroLabel lblAfterCompletion;

	private MetroCheckBox chkCRC32;

	private MetroCheckBox chkSDL;

	private MetroCheckBox chkMT;

	private MetroCheckBox chkAutoSub;

	private MetroTabPage tpNotification;

	private MetroComboBox cboNotifySound;

	private MetroButton btnNotifySound;

	private MetroLabel lblNotifySound;

	private MetroButton btnNotifyPlay;

	public frmConfigs()
	{
		InitializeComponent();
		method_1();
	}

	private void method_0(Control P_0, string P_1)
	{
		ToolTip toolTip = new ToolTip();
		toolTip.ShowAlways = true;
		toolTip.SetToolTip(P_0, P_1);
	}

	private void method_1()
	{
		Control control = this;
		Dictionary<string, string> frmConfig = Class17.class17_0.frmConfig;
		do
		{
			control = GetNextControl(control, forward: true);
			if (control != null && control.Name != string.Empty && frmConfig.ContainsKey(control.Name))
			{
				method_0(control, frmConfig[control.Name]);
			}
		}
		while (control != null);
	}

	private void frmConfigs_Load(object P_0, EventArgs P_1)
	{
		try
		{
			class4_0 = Class48.LoadConfig();
		}
		catch
		{
			smethod_0();
		}
		cboAfterCompletion.SelectedIndex = class4_0.AfterCompletion;
		cboNotifySound.Text = "System";
		chkAutoSub.Checked = class4_0.IsAutoLoadSub;
		chkMT.Checked = class4_0.IsMT;
		chkSDL.Checked = class4_0.IsSDL2;
		chkCRC32.Checked = class4_0.IsCRC32;
		cboAfterCompletion.SelectedIndex = class4_0.AfterCompletion;
	}

	public static void smethod_0()
	{
		Class4 value = new Class4();
		Class48.SaveConfig(value);
	}

	private void frmConfigs_FormClosing(object P_0, FormClosingEventArgs P_1)
	{
		Class4 value = new Class4
		{
			NotifySound = class4_0.NotifySound,
			IsAutoLoadSub = chkAutoSub.Checked,
			IsMT = chkMT.Checked,
			IsSDL2 = chkSDL.Checked,
			IsCRC32 = chkCRC32.Checked,
			IsTopMost = class4_0.IsTopMost,
			AfterCompletion = cboAfterCompletion.SelectedIndex,
			Lang = class4_0.Lang
		};
		Class48.SaveConfig(value);
	}

	private void btnNotifySound_Click(object P_0, EventArgs P_1)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = "Mp3 File",
			Filter = "File Type (*.mp3)|*.mp3"
		};
		if (openFileDialog.ShowDialog(this) != DialogResult.OK || !Path.GetExtension(openFileDialog.FileName).ToLower().Contains(".mp3"))
		{
			return;
		}
		if (!Directory.Exists(Path.Combine(Class48.smethod_37(), "codecs", "assets")))
		{
			Directory.CreateDirectory(Path.Combine(Class48.smethod_37(), "codecs", "assets"));
		}
		string[] files = Directory.GetFiles(Path.Combine(Class48.smethod_37(), "codecs", "assets"));
		foreach (string path in files)
		{
			File.SetAttributes(path, FileAttributes.Normal);
		}
		try
		{
			if (File.Exists(Path.Combine(Class48.smethod_37(), "codecs", "assets", Path.GetFileName(class4_0.NotifySound[cboNotifySound.SelectedIndex]))))
			{
				File.Delete(Path.Combine(Class48.smethod_37(), "codecs", "assets", Path.GetFileName(class4_0.NotifySound[cboNotifySound.SelectedIndex])));
			}
		}
		catch
		{
		}
		if (!Directory.Exists(Path.Combine(Class48.smethod_37(), "codecs", "assets")))
		{
			Directory.CreateDirectory(Path.Combine(Class48.smethod_37(), "codecs", "assets"));
		}
		try
		{
			File.Copy(openFileDialog.FileName, Path.Combine(Class48.smethod_37(), "codecs", "assets", Path.GetFileName(openFileDialog.FileName)) ?? "", overwrite: true);
		}
		catch (Exception ex)
		{
			MetroMessageBox.Show(this, ex.Message.ToString(), "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		class4_0.NotifySound[cboNotifySound.SelectedIndex] = Path.Combine("codecs", "assets", Path.GetFileName(openFileDialog.FileName)) ?? "";
	}

	private async void btnNotifyPlay_Click(object P_0, EventArgs P_1)
	{
		btnNotifyPlay.Enabled = false;
		btnNotifySound.Enabled = false;
		try
		{
			WaveOut waveOut = new WaveOut();
			Mp3FileReader mp3FileReader = new Mp3FileReader(Path.Combine(Class48.smethod_37(), class4_0.NotifySound[cboNotifySound.SelectedIndex]));
			waveOut.Init(mp3FileReader);
			waveOut.Play();
			await Task.Delay(3000);
			waveOut.Stop();
			mp3FileReader.Close();
		}
		catch
		{
			switch ((Enum13)cboNotifySound.SelectedIndex)
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
		btnNotifyPlay.Enabled = true;
		btnNotifySound.Enabled = true;
	}

	private void frmConfigs_ResizeBegin(object P_0, EventArgs P_1)
	{
		Opacity = 0.75;
	}

	private void frmConfigs_ResizeEnd(object P_0, EventArgs P_1)
	{
		Opacity = 1.0;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmConfigs));
		this.tcConfig = new MetroFramework.Controls.MetroTabControl();
		this.tpGeneral = new MetroFramework.Controls.MetroTabPage();
		this.cboAfterCompletion = new MetroFramework.Controls.MetroComboBox();
		this.lblAfterCompletion = new MetroFramework.Controls.MetroLabel();
		this.chkCRC32 = new MetroFramework.Controls.MetroCheckBox();
		this.chkSDL = new MetroFramework.Controls.MetroCheckBox();
		this.chkMT = new MetroFramework.Controls.MetroCheckBox();
		this.chkAutoSub = new MetroFramework.Controls.MetroCheckBox();
		this.tpNotification = new MetroFramework.Controls.MetroTabPage();
		this.btnNotifyPlay = new MetroFramework.Controls.MetroButton();
		this.lblNotifySound = new MetroFramework.Controls.MetroLabel();
		this.cboNotifySound = new MetroFramework.Controls.MetroComboBox();
		this.btnNotifySound = new MetroFramework.Controls.MetroButton();
		this.tcConfig.SuspendLayout();
		this.tpGeneral.SuspendLayout();
		this.tpNotification.SuspendLayout();
		base.SuspendLayout();
		this.tcConfig.Controls.Add(this.tpGeneral);
		this.tcConfig.Controls.Add(this.tpNotification);
		this.tcConfig.Location = new System.Drawing.Point(23, 63);
		this.tcConfig.Name = "tcConfig";
		this.tcConfig.SelectedIndex = 0;
		this.tcConfig.Size = new System.Drawing.Size(421, 244);
		this.tcConfig.TabIndex = 0;
		this.tcConfig.UseSelectable = true;
		this.tpGeneral.Controls.Add(this.cboAfterCompletion);
		this.tpGeneral.Controls.Add(this.lblAfterCompletion);
		this.tpGeneral.Controls.Add(this.chkCRC32);
		this.tpGeneral.Controls.Add(this.chkSDL);
		this.tpGeneral.Controls.Add(this.chkMT);
		this.tpGeneral.Controls.Add(this.chkAutoSub);
		this.tpGeneral.HorizontalScrollbarBarColor = true;
		this.tpGeneral.HorizontalScrollbarHighlightOnWheel = false;
		this.tpGeneral.HorizontalScrollbarSize = 10;
		this.tpGeneral.Location = new System.Drawing.Point(4, 38);
		this.tpGeneral.Name = "tpGeneral";
		this.tpGeneral.Size = new System.Drawing.Size(413, 202);
		this.tpGeneral.TabIndex = 0;
		this.tpGeneral.Text = "General";
		this.tpGeneral.VerticalScrollbarBarColor = true;
		this.tpGeneral.VerticalScrollbarHighlightOnWheel = false;
		this.tpGeneral.VerticalScrollbarSize = 10;
		this.cboAfterCompletion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboAfterCompletion.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboAfterCompletion.FormattingEnabled = true;
		this.cboAfterCompletion.ItemHeight = 19;
		this.cboAfterCompletion.Items.AddRange(new object[4] { "Do Nothing", "Shutdown", "Restart", "Log Off" });
		this.cboAfterCompletion.Location = new System.Drawing.Point(134, 110);
		this.cboAfterCompletion.Name = "cboAfterCompletion";
		this.cboAfterCompletion.Size = new System.Drawing.Size(170, 25);
		this.cboAfterCompletion.TabIndex = 9;
		this.cboAfterCompletion.UseSelectable = true;
		this.lblAfterCompletion.AutoSize = true;
		this.lblAfterCompletion.Location = new System.Drawing.Point(16, 112);
		this.lblAfterCompletion.Name = "lblAfterCompletion";
		this.lblAfterCompletion.Size = new System.Drawing.Size(111, 19);
		this.lblAfterCompletion.TabIndex = 8;
		this.lblAfterCompletion.Text = "After Completion";
		this.chkCRC32.AutoSize = true;
		this.chkCRC32.Checked = true;
		this.chkCRC32.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkCRC32.Location = new System.Drawing.Point(18, 80);
		this.chkCRC32.Name = "chkCRC32";
		this.chkCRC32.Size = new System.Drawing.Size(202, 15);
		this.chkCRC32.TabIndex = 6;
		this.chkCRC32.Text = "Add CRC32 at the end of filename";
		this.chkCRC32.UseSelectable = true;
		this.chkSDL.AutoSize = true;
		this.chkSDL.Location = new System.Drawing.Point(18, 59);
		this.chkSDL.Name = "chkSDL";
		this.chkSDL.Size = new System.Drawing.Size(286, 15);
		this.chkSDL.TabIndex = 5;
		this.chkSDL.Text = "Preview while encoding (May affect performance)";
		this.chkSDL.UseSelectable = true;
		this.chkMT.AutoSize = true;
		this.chkMT.Checked = true;
		this.chkMT.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkMT.Location = new System.Drawing.Point(18, 38);
		this.chkMT.Name = "chkMT";
		this.chkMT.Size = new System.Drawing.Size(102, 15);
		this.chkMT.TabIndex = 4;
		this.chkMT.Text = "Multithreading";
		this.chkMT.UseSelectable = true;
		this.chkAutoSub.AutoSize = true;
		this.chkAutoSub.Checked = true;
		this.chkAutoSub.CheckState = System.Windows.Forms.CheckState.Checked;
		this.chkAutoSub.Location = new System.Drawing.Point(18, 17);
		this.chkAutoSub.Name = "chkAutoSub";
		this.chkAutoSub.Size = new System.Drawing.Size(123, 15);
		this.chkAutoSub.TabIndex = 3;
		this.chkAutoSub.Text = "Auto-Load Subtitle";
		this.chkAutoSub.UseSelectable = true;
		this.tpNotification.Controls.Add(this.btnNotifyPlay);
		this.tpNotification.Controls.Add(this.lblNotifySound);
		this.tpNotification.Controls.Add(this.cboNotifySound);
		this.tpNotification.Controls.Add(this.btnNotifySound);
		this.tpNotification.HorizontalScrollbarBarColor = true;
		this.tpNotification.HorizontalScrollbarHighlightOnWheel = false;
		this.tpNotification.HorizontalScrollbarSize = 10;
		this.tpNotification.Location = new System.Drawing.Point(4, 38);
		this.tpNotification.Name = "tpNotification";
		this.tpNotification.Size = new System.Drawing.Size(413, 202);
		this.tpNotification.TabIndex = 1;
		this.tpNotification.Text = "Notification";
		this.tpNotification.VerticalScrollbarBarColor = true;
		this.tpNotification.VerticalScrollbarHighlightOnWheel = false;
		this.tpNotification.VerticalScrollbarSize = 10;
		this.btnNotifyPlay.Location = new System.Drawing.Point(287, 20);
		this.btnNotifyPlay.Name = "btnNotifyPlay";
		this.btnNotifyPlay.Size = new System.Drawing.Size(48, 23);
		this.btnNotifyPlay.TabIndex = 10;
		this.btnNotifyPlay.Text = "PLAY";
		this.btnNotifyPlay.UseSelectable = true;
		this.btnNotifyPlay.Click += new System.EventHandler(this.btnNotifyPlay_Click);
		this.lblNotifySound.AutoSize = true;
		this.lblNotifySound.Location = new System.Drawing.Point(12, 22);
		this.lblNotifySound.Name = "lblNotifySound";
		this.lblNotifySound.Size = new System.Drawing.Size(46, 19);
		this.lblNotifySound.TabIndex = 9;
		this.lblNotifySound.Text = "Sound";
		this.cboNotifySound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboNotifySound.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboNotifySound.FormattingEnabled = true;
		this.cboNotifySound.ItemHeight = 19;
		this.cboNotifySound.Items.AddRange(new object[5] { "System", "Info", "Success", "Warning", "Error" });
		this.cboNotifySound.Location = new System.Drawing.Point(64, 19);
		this.cboNotifySound.Name = "cboNotifySound";
		this.cboNotifySound.Size = new System.Drawing.Size(217, 25);
		this.cboNotifySound.TabIndex = 5;
		this.cboNotifySound.UseSelectable = true;
		this.btnNotifySound.Location = new System.Drawing.Point(341, 20);
		this.btnNotifySound.Name = "btnNotifySound";
		this.btnNotifySound.Size = new System.Drawing.Size(69, 23);
		this.btnNotifySound.TabIndex = 2;
		this.btnNotifySound.Text = "CHANGE";
		this.btnNotifySound.UseSelectable = true;
		this.btnNotifySound.Click += new System.EventHandler(this.btnNotifySound_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
		base.ClientSize = new System.Drawing.Size(467, 330);
		base.Controls.Add(this.tcConfig);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmConfigs";
		base.Resizable = false;
		base.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
		base.ShowInTaskbar = false;
		base.Style = MetroFramework.MetroColorStyle.Pink;
		this.Text = "CONFIGURATION ";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfigs_FormClosing);
		base.Load += new System.EventHandler(this.frmConfigs_Load);
		base.ResizeBegin += new System.EventHandler(this.frmConfigs_ResizeBegin);
		base.ResizeEnd += new System.EventHandler(this.frmConfigs_ResizeEnd);
		this.tcConfig.ResumeLayout(false);
		this.tpGeneral.ResumeLayout(false);
		this.tpGeneral.PerformLayout();
		this.tpNotification.ResumeLayout(false);
		this.tpNotification.PerformLayout();
		base.ResumeLayout(false);
	}
}
