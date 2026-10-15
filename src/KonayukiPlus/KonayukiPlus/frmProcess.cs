using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace KonayukiPlus;

public class frmProcess : MetroForm
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static bool IsOK__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static string[] FList__BackingField;

	private IContainer components = null;

	private ListView lstProcess;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private MetroButton btnTerminate;

	private MetroButton btnTerminateAll;

	private MetroLabel lblProcess;

	private ColumnHeader columnHeader_2;

	public static bool IsOK
	{
		[CompilerGenerated]
		get
		{
			return IsOK__BackingField;
		}
		[CompilerGenerated]
		set
		{
			IsOK__BackingField = value;
		}
	}

	public static string[] FList
	{
		[CompilerGenerated]
		get
		{
			return FList__BackingField;
		}
		[CompilerGenerated]
		set
		{
			FList__BackingField = value;
		}
	}

	public frmProcess()
	{
		InitializeComponent();
	}

	private void method_0()
	{
		lstProcess.Items.Clear();
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (FList.Contains(process.ProcessName))
			{
				lstProcess.Items.Add(new ListViewItem(new string[3]
				{
					process.Id.ToString(),
					process.ProcessName + ".exe",
					process.MainWindowTitle
				}));
			}
		}
		lblProcess.Text = $"Process Total : {lstProcess.Items.Count}";
	}

	private void frmProcess_Load(object P_0, EventArgs P_1)
	{
		method_0();
	}

	// Kills one process by the id shown in the list; a process that already exited is not an error.
	private static void KillListed(string P_0)
	{
		try
		{
			Process.GetProcessById(int.Parse(P_0)).Kill();
		}
		catch
		{
		}
	}

	private void btnTerminate_Click(object P_0, EventArgs P_1)
	{
		// Each kill is tried on its own: one process that had already exited used to stop the rest.
		foreach (ListViewItem item in lstProcess.Items)
		{
			if (item.Selected)
			{
				KillListed(item.Text);
			}
		}
		Close();
	}

	private void btnTerminateAll_Click(object P_0, EventArgs P_1)
	{
		// The original refreshed the list after every kill while still indexing into it, so the list shifted
		// and every other process was skipped. Take the ids first, then kill them all.
		string[] ids = lstProcess.Items.Cast<ListViewItem>().Select((ListViewItem item) => item.Text).ToArray();
		foreach (string id in ids)
		{
			KillListed(id);
		}
		method_0();
		IsOK = true;
		Close();
	}

	private void lstProcess_KeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyCode != Keys.A || !P_1.Control)
		{
			return;
		}
		foreach (ListViewItem item in lstProcess.Items)
		{
			item.Selected = true;
		}
	}

	private void frmProcess_ResizeBegin(object P_0, EventArgs P_1)
	{
		Opacity = 0.75;
	}

	private void frmProcess_ResizeEnd(object P_0, EventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmProcess));
		this.lstProcess = new System.Windows.Forms.ListView();
		this.columnHeader_2 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_1 = new System.Windows.Forms.ColumnHeader();
		this.btnTerminate = new MetroFramework.Controls.MetroButton();
		this.btnTerminateAll = new MetroFramework.Controls.MetroButton();
		this.lblProcess = new MetroFramework.Controls.MetroLabel();
		base.SuspendLayout();
		this.lstProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.columnHeader_2, this.columnHeader_0, this.columnHeader_1 });
		this.lstProcess.FullRowSelect = true;
		this.lstProcess.Location = new System.Drawing.Point(23, 63);
		this.lstProcess.Name = "lstProcess";
		this.lstProcess.Size = new System.Drawing.Size(434, 205);
		this.lstProcess.TabIndex = 0;
		this.lstProcess.UseCompatibleStateImageBehavior = false;
		this.lstProcess.View = System.Windows.Forms.View.Details;
		this.lstProcess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstProcess_KeyDown);
		this.columnHeader_2.Text = "PID";
		this.columnHeader_2.Width = 0;
		this.columnHeader_0.Text = "Process Name";
		this.columnHeader_0.Width = 105;
		this.columnHeader_1.Text = "Process Title";
		this.columnHeader_1.Width = 300;
		this.btnTerminate.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnTerminate.Location = new System.Drawing.Point(291, 274);
		this.btnTerminate.Name = "btnTerminate";
		this.btnTerminate.Size = new System.Drawing.Size(75, 23);
		this.btnTerminate.TabIndex = 1;
		this.btnTerminate.Text = "Terminate";
		this.btnTerminate.UseSelectable = true;
		this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
		this.btnTerminateAll.Location = new System.Drawing.Point(372, 274);
		this.btnTerminateAll.Name = "btnTerminateAll";
		this.btnTerminateAll.Size = new System.Drawing.Size(85, 23);
		this.btnTerminateAll.TabIndex = 2;
		this.btnTerminateAll.Text = "Terminate ALL";
		this.btnTerminateAll.UseSelectable = true;
		this.btnTerminateAll.Click += new System.EventHandler(this.btnTerminateAll_Click);
		this.lblProcess.AutoSize = true;
		this.lblProcess.Location = new System.Drawing.Point(23, 274);
		this.lblProcess.Name = "lblProcess";
		this.lblProcess.Size = new System.Drawing.Size(102, 19);
		this.lblProcess.TabIndex = 3;
		this.lblProcess.Text = "Process Total : 0";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
		base.ClientSize = new System.Drawing.Size(480, 320);
		base.Controls.Add(this.lblProcess);
		base.Controls.Add(this.btnTerminateAll);
		base.Controls.Add(this.btnTerminate);
		base.Controls.Add(this.lstProcess);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "frmProcess";
		base.Resizable = false;
		base.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.Style = MetroFramework.MetroColorStyle.Pink;
		this.Text = "PROCESS DETECTED";
		base.Load += new System.EventHandler(this.frmProcess_Load);
		base.ResizeBegin += new System.EventHandler(this.frmProcess_ResizeBegin);
		base.ResizeEnd += new System.EventHandler(this.frmProcess_ResizeEnd);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	static frmProcess()
	{
		IsOK = false;
	}
}
