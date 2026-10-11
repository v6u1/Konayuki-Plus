using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace KonayukiPlus;

public class frmChangelog : MetroForm
{
	private IContainer components = null;

	private Panel pnLog;

	private WebBrowser wbChangelog;

	public frmChangelog()
	{
		InitializeComponent();
	}

	private void frmChangelog_Load(object P_0, EventArgs P_1)
	{
		if (frmSplash.bool_0)
		{
			wbChangelog.WebBrowserShortcutsEnabled = true;
			wbChangelog.Url = new Uri("http://127.0.0.1:4000/plus_changelog.html");
		}
		else
		{
			wbChangelog.WebBrowserShortcutsEnabled = false;
			wbChangelog.Url = new Uri(Server.Changelog);
		}
	}

	private void wbChangelog_DocumentCompleted(object P_0, WebBrowserDocumentCompletedEventArgs P_1)
	{
		if (wbChangelog.ReadyState == WebBrowserReadyState.Complete && wbChangelog.Url.ToString() != "about:blank")
		{
			if (wbChangelog.DocumentTitle.ToLower().Contains("konayuki.moe"))
			{
				pnLog.Visible = true;
				Text = "What's New";
				Refresh();
			}
			else
			{
				Text = "Server Offline";
				Refresh();
			}
		}
	}

	private void frmChangelog_ResizeBegin(object P_0, EventArgs P_1)
	{
		Opacity = 0.75;
	}

	private void frmChangelog_ResizeEnd(object P_0, EventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmChangelog));
		this.pnLog = new System.Windows.Forms.Panel();
		this.wbChangelog = new System.Windows.Forms.WebBrowser();
		this.pnLog.SuspendLayout();
		base.SuspendLayout();
		this.pnLog.BackColor = System.Drawing.Color.White;
		this.pnLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnLog.Controls.Add(this.wbChangelog);
		this.pnLog.Location = new System.Drawing.Point(20, 72);
		this.pnLog.Name = "pnLog";
		this.pnLog.Size = new System.Drawing.Size(760, 508);
		this.pnLog.TabIndex = 68;
		this.pnLog.Visible = false;
		this.wbChangelog.Dock = System.Windows.Forms.DockStyle.Fill;
		this.wbChangelog.Location = new System.Drawing.Point(0, 0);
		this.wbChangelog.MinimumSize = new System.Drawing.Size(20, 20);
		this.wbChangelog.Name = "wbChangelog";
		this.wbChangelog.ScriptErrorsSuppressed = true;
		this.wbChangelog.Size = new System.Drawing.Size(758, 506);
		this.wbChangelog.TabIndex = 69;
		this.wbChangelog.Url = new System.Uri("about:blank", System.UriKind.Absolute);
		this.wbChangelog.WebBrowserShortcutsEnabled = false;
		this.wbChangelog.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbChangelog_DocumentCompleted);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
		base.ClientSize = new System.Drawing.Size(800, 600);
		base.Controls.Add(this.pnLog);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmChangelog";
		base.Resizable = false;
		base.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Style = MetroFramework.MetroColorStyle.Pink;
		this.Text = "Loading...";
		base.Load += new System.EventHandler(this.frmChangelog_Load);
		base.ResizeBegin += new System.EventHandler(this.frmChangelog_ResizeBegin);
		base.ResizeEnd += new System.EventHandler(this.frmChangelog_ResizeEnd);
		this.pnLog.ResumeLayout(false);
		base.ResumeLayout(false);
	}
}
