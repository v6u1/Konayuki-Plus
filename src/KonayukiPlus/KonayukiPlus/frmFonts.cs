using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ByteSizeLib;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace KonayukiPlus;

public class frmFonts : MetroForm
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static List<string> files__BackingField;

	private static List<string> list_0;

	private static List<string> list_1;

	private int int_0 = -1;

	private IContainer components = null;

	private ListView lstAegisub;

	private ColumnHeader columnHeader_0;

	private MetroButton btnDL;

	private Panel pnLog;

	private RichTextBox txtLog;

	private MetroButton btnCheck;

	private Label lblStatus;

	public static List<string> files
	{
		[CompilerGenerated]
		get
		{
			return files__BackingField;
		}
		[CompilerGenerated]
		set
		{
			files__BackingField = value;
		}
	}

	public frmFonts()
	{
		InitializeComponent();
	}

	private void method_0()
	{
		PrivateFontCollection privateFontCollection = new PrivateFontCollection();
		string[] array = Directory.GetFiles(Environment.ExpandEnvironmentVariables("%SystemRoot%\\Fonts"));
		foreach (string filename in array)
		{
			try
			{
				privateFontCollection.AddFontFile(filename);
			}
			catch
			{
			}
		}
		FontFamily[] families = privateFontCollection.Families;
		foreach (FontFamily fontFamily in families)
		{
			list_1.Add(fontFamily.Name.ToLower());
		}
	}

	private void method_1(string P_0)
	{
		string[] array = File.ReadAllLines(P_0);
		string[] array2 = array;
		foreach (string input in array2)
		{
			Match match = Regex.Match(input, "Style: (.*?),(?<fontName>.*?),");
			if (match.Success && !list_1.Contains(match.Groups["fontName"].Value.ToLower()) && !list_0.Contains(match.Groups["fontName"].Value.ToLower()))
			{
				list_0.Add(match.Groups["fontName"].Value.ToLower());
			}
		}
	}

	private void method_2()
	{
		txtLog.Clear();
		if (list_0.Count > 0)
		{
			foreach (string item in list_0)
			{
				if (frmMain.dictionary_0.ContainsKey(Class49.smethod_0(item)))
				{
					txtLog.SelectionColor = Color.FromArgb(0, 255, 0);
					RichTextBox richTextBox = txtLog;
					richTextBox.SelectedText = richTextBox.SelectedText + item + "->Found on the server\r\n";
				}
				else
				{
					txtLog.SelectionColor = Color.FromArgb(255, 0, 0);
					RichTextBox richTextBox2 = txtLog;
					richTextBox2.SelectedText = richTextBox2.SelectedText + item + "->Not found on the server\r\n";
				}
			}
			return;
		}
		txtLog.Text += "All fonts found.";
	}

	private void frmFonts_Load(object P_0, EventArgs P_1)
	{
	}

	private void method_3()
	{
		WebClient webClient = new WebClient();
		webClient.Encoding = Encoding.UTF8;
		int_0++;
		Directory.CreateDirectory(Class48.smethod_37() + "\\tmp\\fonts\\");
		if (list_0.Count > 0)
		{
			if (int_0 < list_0.Count)
			{
				if (frmMain.dictionary_0.ContainsKey(Class49.smethod_0(list_0[int_0])))
				{
					webClient.DownloadFileAsync(new Uri(frmMain.dictionary_0[Class49.smethod_0(list_0[int_0])]), Class48.smethod_37() + "\\tmp\\fonts\\" + Path.GetFileName(frmMain.dictionary_0[Class49.smethod_0(list_0[int_0])]));
					webClient.DownloadProgressChanged += (object P_0, DownloadProgressChangedEventArgs P_1) =>
					{
						lblStatus.Text = string.Concat("Downloading -> ", ByteSize.FromBytes(P_1.BytesReceived), "/", ByteSize.FromBytes(P_1.TotalBytesToReceive), $"({P_1.ProgressPercentage}%)");
					};
					webClient.DownloadFileCompleted += delegate
					{
						Console.WriteLine(Environment.ExpandEnvironmentVariables("%SystemRoot%\\Fonts") + "\\" + Path.GetFileName(frmMain.dictionary_0[Class49.smethod_0(list_0[int_0])]));
						Console.WriteLine(frmMain.dictionary_0[Class49.smethod_0(list_0[int_0])]);
						File.Copy(Class48.smethod_37() + "\\tmp\\fonts\\" + Path.GetFileName(frmMain.dictionary_0[Class49.smethod_0(list_0[int_0])]), Environment.ExpandEnvironmentVariables("%SystemRoot%\\Fonts") + "\\" + Path.GetFileName(frmMain.dictionary_0[Class49.smethod_0(list_0[int_0])]), overwrite: true);
						method_3();
					};
				}
				else
				{
					method_3();
				}
			}
			else
			{
				txtLog.Text = "Download completed.";
			}
		}
		else
		{
			txtLog.Text = "All fonts found.";
		}
	}

	private void btnDL_Click(object P_0, EventArgs P_1)
	{
		method_3();
		btnDL.Enabled = false;
		try
		{
			Process.Start(Class48.smethod_37() + "\\languages\\Fonts\\FontReg.exe");
		}
		catch
		{
		}
	}

	private void btnCheck_Click(object P_0, EventArgs P_1)
	{
		btnCheck.Enabled = false;
		txtLog.Text = "Now Loading...";
		Application.DoEvents();
		list_0.Clear();
		list_1.Clear();
		method_0();
		foreach (string file in files)
		{
			btnDL.Enabled = true;
			lstAegisub.Items.Add(file);
			method_1(file);
		}
		files.Clear();
		method_2();
	}

	private void frmFonts_ResizeBegin(object P_0, EventArgs P_1)
	{
		Opacity = 0.75;
	}

	private void frmFonts_ResizeEnd(object P_0, EventArgs P_1)
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmFonts));
		this.lstAegisub = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.btnDL = new MetroFramework.Controls.MetroButton();
		this.pnLog = new System.Windows.Forms.Panel();
		this.txtLog = new System.Windows.Forms.RichTextBox();
		this.btnCheck = new MetroFramework.Controls.MetroButton();
		this.lblStatus = new System.Windows.Forms.Label();
		this.pnLog.SuspendLayout();
		base.SuspendLayout();
		this.lstAegisub.Columns.AddRange(new System.Windows.Forms.ColumnHeader[1] { this.columnHeader_0 });
		this.lstAegisub.FullRowSelect = true;
		this.lstAegisub.Location = new System.Drawing.Point(23, 63);
		this.lstAegisub.Name = "lstAegisub";
		this.lstAegisub.Size = new System.Drawing.Size(495, 222);
		this.lstAegisub.TabIndex = 1;
		this.lstAegisub.UseCompatibleStateImageBehavior = false;
		this.lstAegisub.View = System.Windows.Forms.View.Details;
		this.columnHeader_0.Text = "FileName";
		this.columnHeader_0.Width = 470;
		this.btnDL.Enabled = false;
		this.btnDL.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnDL.Location = new System.Drawing.Point(442, 397);
		this.btnDL.Name = "btnDL";
		this.btnDL.Size = new System.Drawing.Size(75, 23);
		this.btnDL.TabIndex = 2;
		this.btnDL.Text = "Download";
		this.btnDL.UseSelectable = true;
		this.btnDL.Click += new System.EventHandler(this.btnDL_Click);
		this.pnLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pnLog.BackColor = System.Drawing.Color.White;
		this.pnLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnLog.Controls.Add(this.txtLog);
		this.pnLog.Location = new System.Drawing.Point(23, 291);
		this.pnLog.Name = "pnLog";
		this.pnLog.Size = new System.Drawing.Size(495, 100);
		this.pnLog.TabIndex = 68;
		this.txtLog.BackColor = System.Drawing.Color.White;
		this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtLog.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtLog.ForeColor = System.Drawing.SystemColors.WindowText;
		this.txtLog.Location = new System.Drawing.Point(0, 0);
		this.txtLog.Name = "txtLog";
		this.txtLog.ReadOnly = true;
		this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
		this.txtLog.Size = new System.Drawing.Size(493, 98);
		this.txtLog.TabIndex = 67;
		this.txtLog.Text = "Please click 'Check' button";
		this.btnCheck.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnCheck.Location = new System.Drawing.Point(361, 397);
		this.btnCheck.Name = "btnCheck";
		this.btnCheck.Size = new System.Drawing.Size(75, 23);
		this.btnCheck.TabIndex = 69;
		this.btnCheck.Text = "Check";
		this.btnCheck.UseSelectable = true;
		this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
		this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.lblStatus.BackColor = System.Drawing.Color.White;
		this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblStatus.ForeColor = System.Drawing.Color.Black;
		this.lblStatus.Location = new System.Drawing.Point(21, 399);
		this.lblStatus.Name = "lblStatus";
		this.lblStatus.Size = new System.Drawing.Size(335, 18);
		this.lblStatus.TabIndex = 70;
		this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
		base.ClientSize = new System.Drawing.Size(541, 433);
		base.Controls.Add(this.lblStatus);
		base.Controls.Add(this.btnCheck);
		base.Controls.Add(this.pnLog);
		base.Controls.Add(this.btnDL);
		base.Controls.Add(this.lstAegisub);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(541, 433);
		base.Name = "frmFonts";
		base.Resizable = false;
		base.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
		base.Style = MetroFramework.MetroColorStyle.Pink;
		this.Text = "Font Finder";
		base.Load += new System.EventHandler(this.frmFonts_Load);
		base.ResizeBegin += new System.EventHandler(this.frmFonts_ResizeBegin);
		base.ResizeEnd += new System.EventHandler(this.frmFonts_ResizeEnd);
		this.pnLog.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	static frmFonts()
	{
		files = new List<string>();
		list_0 = new List<string>();
		list_1 = new List<string>();
	}
}
