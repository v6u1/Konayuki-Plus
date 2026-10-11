using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace KonayukiPlus;

public class frmAbout : MetroForm
{
	private readonly string[] stringArray_0 = new string[5] { "https://konayuki.moe/", "http://fb.com/konayuki.moe", "https://twitter.com/Konayuki_moe", "https://github.com/Proflylab/", "https://link.konayuki.moe/discord.html" };

	private IContainer components = null;

	private PictureBox picLogo;

	private PictureBox picDiscord;

	private PictureBox picTwitter;

	private PictureBox picGithub;

	private PictureBox picFacebook;

	private PictureBox picWebsite;

	private Label lblHDev;

	private Label lblDevAvisynth;

	private Label lblContributors;

	private Label lbl3rdparty;

	private LinkLabel linklblContributors;

	private LinkLabel linklbl3rdparty;

	private PictureBox picLogo2;

	private LinkLabel linkDev;

	private LinkLabel linkCoDev;

	private Label lblHeader;

	private LinkLabel linkVersion;

	public frmAbout()
	{
		InitializeComponent();
	}

	private void frmAbout_Load(object P_0, EventArgs P_1)
	{
		Class48.smethod_2(picWebsite, "Website");
		Class48.smethod_2(picFacebook, "Facebook");
		Class48.smethod_2(picTwitter, "Twitter");
		Class48.smethod_2(picGithub, "Github");
		Class48.smethod_2(picDiscord, "Discord");
		Class48.smethod_2(linkVersion, "Click to Copy");
		linkVersion.Text = "V=" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + " / API=" + frmMain.string_1;
		string[] array = new string[20]
		{
			"AK-FS", "ChokeChoke-Fansub", "JEDAi Encoder", "KamiAmagumoSub", "KataFansub", "Konayuki-fs", "Kryxelix", "Madao Fansub", "NaTa Subtitle", "Onigiri-FS",
			"Otaku-Fansub", "Pasakorn-FS", "PeaLz-FS", "Pure's app", "RealX", "RubyFansub", "Seikai-Fansub", "Sesano-FS", "VirgoNeo-FS", "WindSky-Fs"
		};
		string[] array2 = new string[11]
		{
			"AviSynth+", "ByteSize", "DotNetZip", "FFmpeg", "Fody", "MediaInfo", "MetroFramework", "mpv", "NAudio", "Newtonsoft.Json",
			"SVP"
		};
		string[] array3 = new string[20]
		{
			"https://www.facebook.com/profile.php?id=1728096390807148", "https://www.facebook.com/profile.php?id=299748283506833", "https://www.facebook.com/profile.php?id=124776511600037", "https://www.facebook.com/profile.php?id=2043379775888578", "https://www.facebook.com/profile.php?id=759115634231529", "https://www.facebook.com/profile.php?id=1596773727309015", "https://www.facebook.com/profile.php?id=1708920062694480", "https://www.facebook.com/profile.php?id=1451546008240930", "https://www.facebook.com/profile.php?id=1666538763579542", "https://www.facebook.com/profile.php?id=462553260455453",
			"https://www.facebook.com/profile.php?id=422086237914426", "https://www.facebook.com/profile.php?id=1628962184009048", "https://www.facebook.com/profile.php?id=389742367765571", "https://www.facebook.com/profile.php?id=639918592789743", "https://www.facebook.com/profile.php?id=200510173864684", "https://www.facebook.com/profile.php?id=237199830108704", "https://www.facebook.com/profile.php?id=1602982576677976", "https://www.facebook.com/profile.php?id=1833766746850999", "https://www.facebook.com/profile.php?id=1481552282061512", "https://www.facebook.com/profile.php?id=106345242801794"
		};
		string[] array4 = new string[11]
		{
			"http://avs-plus.net/", "https://github.com/omar/ByteSize", "https://github.com/haf/DotNetZip.Semverd", "https://www.ffmpeg.org/", "https://github.com/Fody/Fody", "https://mediaarea.net/en/MediaInfo", "https://github.com/dennismagno/metroframework-modern-ui", "https://mpv.io/", "https://github.com/naudio/NAudio", "https://www.newtonsoft.com/json",
			"https://www.svp-team.com/"
		};
		linkDev.smethod_0(new string[1] { "Proflylab" }, new string[1] { "mailto:proflylab@pm.com" });
		linkCoDev.smethod_0(new string[1] { "MinorMole" }, new string[1] { "mailto:support@konayuki.moe)" });
		linklblContributors.smethod_0(array, array3);
		linklbl3rdparty.smethod_0(array2, array4);
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

	private void picLogo_MouseHover(object P_0, EventArgs P_1)
	{
		picLogo.SendToBack();
	}

	private void picLogo2_MouseLeave(object P_0, EventArgs P_1)
	{
		picLogo2.SendToBack();
	}

	private void linkVersion_LinkClicked(object P_0, LinkLabelLinkClickedEventArgs P_1)
	{
		Clipboard.SetText(linkVersion.Text);
	}

	private void frmAbout_ResizeBegin(object P_0, EventArgs P_1)
	{
		Opacity = 0.75;
	}

	private void frmAbout_ResizeEnd(object P_0, EventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmAbout));
		this.picLogo = new System.Windows.Forms.PictureBox();
		this.picDiscord = new System.Windows.Forms.PictureBox();
		this.picTwitter = new System.Windows.Forms.PictureBox();
		this.picGithub = new System.Windows.Forms.PictureBox();
		this.picFacebook = new System.Windows.Forms.PictureBox();
		this.picWebsite = new System.Windows.Forms.PictureBox();
		this.lblHDev = new System.Windows.Forms.Label();
		this.lblDevAvisynth = new System.Windows.Forms.Label();
		this.lblContributors = new System.Windows.Forms.Label();
		this.lbl3rdparty = new System.Windows.Forms.Label();
		this.linklblContributors = new System.Windows.Forms.LinkLabel();
		this.linklbl3rdparty = new System.Windows.Forms.LinkLabel();
		this.picLogo2 = new System.Windows.Forms.PictureBox();
		this.linkDev = new System.Windows.Forms.LinkLabel();
		this.linkCoDev = new System.Windows.Forms.LinkLabel();
		this.lblHeader = new System.Windows.Forms.Label();
		this.linkVersion = new System.Windows.Forms.LinkLabel();
		((System.ComponentModel.ISupportInitialize)this.picLogo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picDiscord).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picTwitter).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picGithub).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picFacebook).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picWebsite).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picLogo2).BeginInit();
		base.SuspendLayout();
		this.picLogo.Image = (System.Drawing.Image)resources.GetObject("picLogo.Image");
		this.picLogo.Location = new System.Drawing.Point(11, 13);
		this.picLogo.Name = "picLogo";
		this.picLogo.Size = new System.Drawing.Size(128, 128);
		this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picLogo.TabIndex = 33;
		this.picLogo.TabStop = false;
		this.picLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLogo_MouseDown);
		this.picLogo.MouseHover += new System.EventHandler(this.picLogo_MouseHover);
		this.picDiscord.Image = (System.Drawing.Image)resources.GetObject("picDiscord.Image");
		this.picDiscord.Location = new System.Drawing.Point(280, 297);
		this.picDiscord.Name = "picDiscord";
		this.picDiscord.Size = new System.Drawing.Size(25, 29);
		this.picDiscord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picDiscord.TabIndex = 38;
		this.picDiscord.TabStop = false;
		this.picDiscord.Click += new System.EventHandler(this.picDiscord_Click);
		this.picTwitter.Image = (System.Drawing.Image)resources.GetObject("picTwitter.Image");
		this.picTwitter.Location = new System.Drawing.Point(216, 297);
		this.picTwitter.Name = "picTwitter";
		this.picTwitter.Size = new System.Drawing.Size(26, 25);
		this.picTwitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picTwitter.TabIndex = 37;
		this.picTwitter.TabStop = false;
		this.picTwitter.Click += new System.EventHandler(this.picTwitter_Click);
		this.picGithub.Image = (System.Drawing.Image)resources.GetObject("picGithub.Image");
		this.picGithub.Location = new System.Drawing.Point(248, 297);
		this.picGithub.Name = "picGithub";
		this.picGithub.Size = new System.Drawing.Size(26, 25);
		this.picGithub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picGithub.TabIndex = 36;
		this.picGithub.TabStop = false;
		this.picGithub.Click += new System.EventHandler(this.picGithub_Click);
		this.picFacebook.Image = (System.Drawing.Image)resources.GetObject("picFacebook.Image");
		this.picFacebook.Location = new System.Drawing.Point(184, 297);
		this.picFacebook.Name = "picFacebook";
		this.picFacebook.Size = new System.Drawing.Size(26, 25);
		this.picFacebook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picFacebook.TabIndex = 35;
		this.picFacebook.TabStop = false;
		this.picFacebook.Click += new System.EventHandler(this.picFacebook_Click);
		this.picWebsite.Image = (System.Drawing.Image)resources.GetObject("picWebsite.Image");
		this.picWebsite.Location = new System.Drawing.Point(152, 297);
		this.picWebsite.Name = "picWebsite";
		this.picWebsite.Size = new System.Drawing.Size(26, 25);
		this.picWebsite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picWebsite.TabIndex = 34;
		this.picWebsite.TabStop = false;
		this.picWebsite.Click += new System.EventHandler(this.picWebsite_Click);
		this.lblHDev.AutoSize = true;
		this.lblHDev.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblHDev.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lblHDev.Location = new System.Drawing.Point(148, 66);
		this.lblHDev.Name = "lblHDev";
		this.lblHDev.Size = new System.Drawing.Size(126, 17);
		this.lblHDev.TabIndex = 39;
		this.lblHDev.Text = "Software Developer:";
		this.lblDevAvisynth.AutoSize = true;
		this.lblDevAvisynth.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblDevAvisynth.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lblDevAvisynth.Location = new System.Drawing.Point(148, 108);
		this.lblDevAvisynth.Name = "lblDevAvisynth";
		this.lblDevAvisynth.Size = new System.Drawing.Size(169, 17);
		this.lblDevAvisynth.TabIndex = 40;
		this.lblDevAvisynth.Text = "AviSynth+ Script Developer:";
		this.lblContributors.AutoSize = true;
		this.lblContributors.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblContributors.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lblContributors.Location = new System.Drawing.Point(148, 149);
		this.lblContributors.Name = "lblContributors";
		this.lblContributors.Size = new System.Drawing.Size(84, 17);
		this.lblContributors.TabIndex = 41;
		this.lblContributors.Text = "Contributors:";
		this.lbl3rdparty.AutoSize = true;
		this.lbl3rdparty.Font = new System.Drawing.Font("Segoe UI", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl3rdparty.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lbl3rdparty.Location = new System.Drawing.Point(148, 236);
		this.lbl3rdparty.Name = "lbl3rdparty";
		this.lbl3rdparty.Size = new System.Drawing.Size(152, 17);
		this.lbl3rdparty.TabIndex = 42;
		this.lbl3rdparty.Text = "Third-party components:";
		this.linklblContributors.AutoSize = true;
		this.linklblContributors.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linklblContributors.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.linklblContributors.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		this.linklblContributors.LinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linklblContributors.Location = new System.Drawing.Point(148, 169);
		this.linklblContributors.Name = "linklblContributors";
		this.linklblContributors.Size = new System.Drawing.Size(437, 60);
		this.linklblContributors.TabIndex = 45;
		this.linklblContributors.TabStop = true;
		this.linklblContributors.Text = resources.GetString("linklblContributors.Text");
		this.linklblContributors.VisitedLinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linklbl3rdparty.AutoSize = true;
		this.linklbl3rdparty.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linklbl3rdparty.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.linklbl3rdparty.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		this.linklbl3rdparty.LinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linklbl3rdparty.Location = new System.Drawing.Point(148, 256);
		this.linklbl3rdparty.Name = "linklbl3rdparty";
		this.linklbl3rdparty.Size = new System.Drawing.Size(416, 30);
		this.linklbl3rdparty.TabIndex = 46;
		this.linklbl3rdparty.TabStop = true;
		this.linklbl3rdparty.Text = "AviSynth+, ByteSize, DotNetZip, FFmpeg, Fody, MediaInfo, MetroFramework, \r\nmpv, NAudio, Newtonsoft.Json, SVP";
		this.linklbl3rdparty.VisitedLinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.picLogo2.Image = (System.Drawing.Image)resources.GetObject("picLogo2.Image");
		this.picLogo2.Location = new System.Drawing.Point(11, 13);
		this.picLogo2.Name = "picLogo2";
		this.picLogo2.Size = new System.Drawing.Size(128, 128);
		this.picLogo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picLogo2.TabIndex = 47;
		this.picLogo2.TabStop = false;
		this.picLogo2.MouseLeave += new System.EventHandler(this.picLogo2_MouseLeave);
		this.linkDev.AutoSize = true;
		this.linkDev.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkDev.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.linkDev.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		this.linkDev.LinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linkDev.Location = new System.Drawing.Point(148, 86);
		this.linkDev.Name = "linkDev";
		this.linkDev.Size = new System.Drawing.Size(54, 15);
		this.linkDev.TabIndex = 48;
		this.linkDev.TabStop = true;
		this.linkDev.Text = "Proflylab";
		this.linkDev.VisitedLinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linkCoDev.AutoSize = true;
		this.linkCoDev.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkCoDev.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.linkCoDev.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		this.linkCoDev.LinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linkCoDev.Location = new System.Drawing.Point(148, 128);
		this.linkCoDev.Name = "linkCoDev";
		this.linkCoDev.Size = new System.Drawing.Size(66, 15);
		this.linkCoDev.TabIndex = 49;
		this.linkCoDev.TabStop = true;
		this.linkCoDev.Text = "MinorMole";
		this.linkCoDev.VisitedLinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.lblHeader.AutoSize = true;
		this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.lblHeader.Location = new System.Drawing.Point(145, 13);
		this.lblHeader.Name = "lblHeader";
		this.lblHeader.Size = new System.Drawing.Size(202, 32);
		this.lblHeader.TabIndex = 50;
		this.lblHeader.Text = "KONAYUKI PLUS";
		this.linkVersion.AutoSize = true;
		this.linkVersion.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.linkVersion.ForeColor = System.Drawing.Color.FromArgb(247, 150, 193);
		this.linkVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
		this.linkVersion.LinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linkVersion.Location = new System.Drawing.Point(148, 45);
		this.linkVersion.Name = "linkVersion";
		this.linkVersion.Size = new System.Drawing.Size(12, 15);
		this.linkVersion.TabIndex = 51;
		this.linkVersion.TabStop = true;
		this.linkVersion.Text = "?";
		this.linkVersion.VisitedLinkColor = System.Drawing.Color.FromArgb(255, 200, 100);
		this.linkVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVersion_LinkClicked);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
		base.ClientSize = new System.Drawing.Size(620, 342);
		base.Controls.Add(this.linkVersion);
		base.Controls.Add(this.lblHeader);
		base.Controls.Add(this.linkCoDev);
		base.Controls.Add(this.linkDev);
		base.Controls.Add(this.linklbl3rdparty);
		base.Controls.Add(this.linklblContributors);
		base.Controls.Add(this.lbl3rdparty);
		base.Controls.Add(this.lblContributors);
		base.Controls.Add(this.lblDevAvisynth);
		base.Controls.Add(this.lblHDev);
		base.Controls.Add(this.picDiscord);
		base.Controls.Add(this.picTwitter);
		base.Controls.Add(this.picGithub);
		base.Controls.Add(this.picFacebook);
		base.Controls.Add(this.picWebsite);
		base.Controls.Add(this.picLogo);
		base.Controls.Add(this.picLogo2);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmAbout";
		base.Resizable = false;
		base.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Style = MetroFramework.MetroColorStyle.Pink;
		base.Load += new System.EventHandler(this.frmAbout_Load);
		base.ResizeBegin += new System.EventHandler(this.frmAbout_ResizeBegin);
		base.ResizeEnd += new System.EventHandler(this.frmAbout_ResizeEnd);
		((System.ComponentModel.ISupportInitialize)this.picLogo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picDiscord).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picTwitter).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picGithub).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picFacebook).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picWebsite).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picLogo2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
