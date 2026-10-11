using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteSizeLib;
using KonayukiPlus.Properties;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KonayukiPlus;

public class frmMain : MetroForm
{
	private bool bool_0 = false;

	private bool bool_1 = false;

	private bool bool_2 = false;

	private int int_0 = -1;

	public static bool bool_3 = false;

	public static string string_0 = string.Empty;

	public static string string_1 = string.Empty;

	public static Dictionary<string, string> dictionary_0;

	public static string[] stringArray_0;

	public static string string_2 = string.Empty;

	private Class6 class6_0 = new Class6();

	private ToolTip toolTip_0 = new ToolTip();

	private int int_1 = 1;

	private bool bool_4 = false;

	private bool bool_5 = false;

	private bool bool_6 = false;

	private int int_2 = 0;

	private int int_3 = 0;

	private bool bool_7 = true;

	private bool bool_8 = true;

	private string string_3 = "Untitled";

	private string string_4 = string.Empty;

	private bool bool_9 = true;

	private bool bool_10 = false;

	private bool bool_11 = true;

	private bool bool_12 = false;

	private Process process_0;

	private int int_4 = -1;

	private Class13 class13_0 = new Class13();

	private Class4 class4_0 = new Class4();

	private Class47 class47_0 = new Class47();

	private Class52 class52_0 = new Class52();

	private Class56 class56_0 = new Class56();

	private List<Class52> list_0 = new List<Class52>();

	private BackgroundWorker backgroundWorker_0 = new BackgroundWorker();

	private ColorDialog colorDialog_0 = new ColorDialog();

	private NotifyIcon notifyIcon_0 = new NotifyIcon();

	private frmHelp frmHelp_0 = new frmHelp();

	private frmHelper frmHelper_0 = new frmHelper();

	private frmTimer frmTimer_0 = new frmTimer();

	private frmBorder frmBorder_0 = new frmBorder();

	private IContainer components = null;

	private MetroButton btnAdd;

	private MetroButton btnStart;

	private MetroButton btnDel;

	private MetroButton btnStop;

	private ListView lstQueue;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private TreeView tvDetails;

	private MetroTextBox txtOutput;

	private MetroToggle togSameInput;

	private MetroLabel lblSameInput;

	private MetroLabel lblOutput;

	private MetroTabPage tpSpecial;

	private MetroTabPage tpLogo;

	private MetroTabPage tpTransition;

	private MetroTabPage tpVideo;

	private MetroTabPage tpLog;

	private MetroTabPage tpAudio;

	private MetroTabPage tpMain;

	private GroupBox grpEndCard;

	private MetroLabel lblEndCard;

	private MetroTextBox txtEndCardMusic;

	private GroupBox grpIntro;

	private MetroLabel lblIntro;

	private MetroTextBox txtIntroMusic;

	private MetroTextBox txtIntro;

	private MetroTabControl tcQueue;

	private GroupBox grpVideoSetting;

	private MetroLabel lblVideoQualityLevel;

	private MetroLabel lblVideoQuality;

	private MetroLabel lblVideoEncoder;

	private MetroComboBox cboVideoEncoder;

	private MetroLabel lblVideoSetting;

	private MetroToggle togOntop;

	private GroupBox grpAudioSetting;

	private MetroLabel lblAudioQuality;

	private MetroComboBox cboAudioQuality;

	private MetroLabel lblAudioFormat;

	private MetroComboBox cboAudioFormat;

	private MetroLabel lblAudioSetting;

	private GroupBox grpKaraoke;

	private MetroLabel lblKaraoke;

	private MetroTextBox txtKaraokeED;

	private MetroTextBox txtKaraokeOP;

	private GroupBox grpSubtitle;

	private MetroLabel lblSubtitle;

	private MetroLabel lblSubtitleFile;

	private MetroLabel lblVideoPreset;

	private MetroComboBox cboVideoPreset;

	private GroupBox grpVideoEnhancer;

	private MetroLabel lblVideoLineDarkenerLevel;

	private MetroLabel lblVideoLineDarkener;

	private MetroTrackBar tbVideoLineDarkener;

	private MetroLabel lblVideoEnhancer;

	private MetroLabel lblVideoNoiseRemover;

	private MetroComboBox cboVideoRemover;

	private MetroLabel lblVideoWarpSharp;

	private MetroTrackBar tbVideoWarpSharp;

	private MetroLabel lblVideoSharpen;

	private MetroTrackBar tbVideoSharpen;

	private GroupBox grpColorEnhancer;

	private MetroLabel lblColorSaturationLevel;

	private MetroLabel lblColorContrastLevel;

	private MetroLabel lblColorSaturation;

	private MetroTrackBar tbColorSaturation;

	private MetroLabel lblColorContrast;

	private MetroTrackBar tbColorContrast;

	private MetroLabel lblColorEnhancer;

	private MetroLabel lblColorDebanding;

	private MetroComboBox cboColorDebanding;

	private MetroLabel lblColorBrightnessLevel;

	private MetroLabel lblColorBrightness;

	private MetroTrackBar tbColorBrightness;

	private MetroLabel lblVideoWarpSharpLevel;

	private MetroLabel lblVideoSharpenLevel;

	private GroupBox grpVolumeControl;

	private MetroLabel lblVolumeSourceLevel;

	private MetroTrackBar tbVolumeSource;

	private MetroLabel lblVolumeControl;

	private MetroLabel lblVolumeEndCardLevel;

	private MetroLabel lblVolumeEndCard;

	private MetroTrackBar tbVolumeEndCard;

	private MetroLabel lblVolumeIntroLevel;

	private MetroLabel lblVolumeIntro;

	private MetroTrackBar tbVolumeIntro;

	private MetroLabel lblVolumeSource;

	private MetroLink lblLinkLineDarkener;

	private MetroLink lblLinkWarpSharp;

	private MetroLink lblLinkSharpen;

	private MetroPanel pnFade;

	private NumericUpDown udIntroFadeInTime;

	private GroupBox grpIntroFadeIn;

	private MetroLabel lblIntroFadeIn;

	private MetroButton btnIntroFadeInColor;

	private MetroToggle togFadeIn;

	private MetroLabel lblIntroFadeInTimeSec;

	private GroupBox grpEndCardFadeOut;

	private MetroLabel lblEndCardFadeOutTime;

	private Panel pEndCardOutColor;

	private MetroLabel lblEndCardFadeOutTimeSec;

	private MetroToggle togEndCardOut;

	private MetroLabel lblIntroEndCardOut;

	private MetroButton btnEndCardFadeOutColor;

	private NumericUpDown udEndCardFadeOutTime;

	private GroupBox grpSourceFadeOut;

	private MetroLabel lblSourceFadeOutTime;

	private Panel pSourceOutColor;

	private MetroLabel lblSourceFadeOutTimeSec;

	private MetroToggle togSourceOut;

	private MetroLabel lblIntroSourceOut;

	private MetroButton btnSourceFadeOutColor;

	private NumericUpDown udSourceFadeOutTime;

	private GroupBox grpSourceFadeIn;

	private MetroLabel lblSourceFadeInTime;

	private Panel pSourceInColor;

	private MetroLabel lblSourceFadeInTimeSec;

	private MetroToggle togSourceIn;

	private MetroLabel lblIntroSourceIn;

	private MetroButton btnSourceFadeInColor;

	private NumericUpDown udSourceFadeInTime;

	private GroupBox grpIntroFadeOut;

	private MetroLabel lblIntroFadeOutTime;

	private Panel pFadeOutColor;

	private MetroLabel lblIntroFadeOutTimeSec;

	private MetroToggle togFadeOut;

	private MetroLabel lblIntroFadeOut;

	private MetroButton btnIntroFadeOutColor;

	private NumericUpDown udIntroFadeOutTime;

	private MetroLabel lblIntroFadeInTime;

	private Panel pFadeInColor;

	private MetroPanel pnDissolveAll;

	private GroupBox grpDissolve;

	private MetroLabel lblDissolveTime;

	private MetroLabel lblDissolveTimeSec;

	private NumericUpDown udDissolveTime;

	private MetroLabel lblDissolveControl;

	private MetroLabel lblDissolveFadeOutTime;

	private NumericUpDown udDissolveFadeInTime;

	private MetroLabel lblDissolveFadeOutTimeSec;

	private MetroLabel lblDissolveFadeInTimeSec;

	private NumericUpDown udDissolveFadeOutTime;

	private MetroLabel lblDissolveFadeInTime;

	private GroupBox grpEndCardFadeIn;

	private MetroLabel lblEndCardFadeInTime;

	private Panel pEndCardInColor;

	private MetroLabel lblEndCardFadeInTimeSec;

	private MetroToggle togEndCardIn;

	private MetroLabel lblIntroEndCardIn;

	private MetroButton btnEndCardFadeInColor;

	private NumericUpDown udEndCardFadeInTime;

	private MetroPanel pnTransition;

	private GroupBox grpTransitionEndCard;

	private MetroTextBox txtEndCardTransitionOverlay;

	private MetroTextBox txtEndCardTransition;

	private MetroLabel lblEndCardTransitionFile;

	private MetroLabel lblEndCardTransition;

	private MetroLabel lblEndCardTransitionAudioSec;

	private MetroLabel lblEndCardTransitionAudio;

	private NumericUpDown udEndCardTransitionAudioTime;

	private GroupBox grpTransitionIntro;

	private MetroTextBox txtIntroTransitionOverlay;

	private MetroTextBox txtIntroTransition;

	private MetroLabel lblIntroTransitionFile;

	private MetroLabel lblIntroTransition;

	private MetroLabel lblIntroTransitionAudioSec;

	private MetroLabel lblIntroTransitionAudio;

	private NumericUpDown udIntroTransitionAudioTime;

	private GroupBox groupBox19;

	private MetroTextBox txtLogoSubtitle;

	private MetroLabel lblLogoSubtitleFile;

	private MetroLabel lblLogoSubtitle;

	private GroupBox grpLogo;

	private GroupBox grpLogoSetting;

	private MetroLabel lblLogoSetting;

	private GroupBox groupBox21;

	private MetroLabel lblLogoTimeAlways;

	private MetroToggle togLogoTime;

	private MetroLabel lblLogoShowTimeMinute;

	private MetroLabel lblLogoTime;

	private NumericUpDown udLogoTimeSecMinute;

	private MetroLabel lblLogoShowTime;

	private NumericUpDown udLogoTimeSec;

	private MetroLabel lblLogoShowTimeSec;

	private MetroTextBox txtLogo;

	private MetroLabel lblLogoFile;

	private MetroLabel lblLogo;

	private MetroPanel pnFadeAll;

	private Panel pLogoFadeColor;

	private MetroButton btnLogoFadeColor;

	private MetroLabel lblLogoOpacityLevel;

	private MetroLabel lblLogoOpacity;

	private MetroTrackBar tbLogoOpacity;

	private MetroLabel lblLogoBlend;

	private MetroComboBox cboLogoBlend;

	private MetroLink lblTransitionLink;

	private MetroLabel lblTransitionTUT;

	private GroupBox grpHardSubRemover;

	private MetroLabel lblHardSubRemover;

	private NumericUpDown udRemoverRight;

	private MetroLabel lblRemoverRight;

	private NumericUpDown udRemoverLeft;

	private MetroLabel lblRemoverLeft;

	private NumericUpDown udRemoverBottom;

	private MetroLabel lblRemoverBottom;

	private MetroLabel lblObjectRemove;

	private NumericUpDown udRemoverTop;

	private MetroLabel lblRemoverTop;

	private MetroLink lblTroubleLink;

	private MetroLabel lblTrouble;

	private MetroLabel lblRemoverLevel1Level;

	private MetroLabel lblRemoverLevel1;

	private MetroTrackBar tbRemoverLevel1;

	private MetroLabel lblRemoverLevel2Level;

	private MetroLabel lblRemoverLevel2;

	private MetroTrackBar tbRemoverLevel2;

	private MetroToggle togHardSubRemover;

	private MetroLink lblRemoverLink;

	private MetroLabel lblRemoverTUT;

	private GroupBox grpClipDetails;

	private MetroLabel lblClipDeailsName;

	private MetroLabel lblClipDetails;

	private MetroTextBox txtClipDeailsAuthor;

	private MetroLabel lblClipDeailsAuthor;

	private MetroTextBox txtClipDeailsName;

	private MetroLink lblLinkRemover;

	private MetroToggle togLogoSubtitle;

	private MetroToggle togLogo;

	private MetroToggle togClipDetails;

	private MetroLink lblLinkDebanding;

	private MetroLabel lblVideoResize;

	private MetroComboBox cboVideoResize;

	private MetroLabel lblVideoSmooth;

	private MetroComboBox cboVideoSmooth;

	private MetroLabel lblIntroTimeSec;

	private NumericUpDown udIntroTime;

	private MetroLabel lblIntroTime;

	private MetroLabel lblEndCardTimeSec;

	private NumericUpDown udEndCardTime;

	private MetroLabel lblEndCardTime;

	private ContextMenuStrip cmsControlQueue;

	private ToolStripMenuItem tsmiPause;

	private ToolStripMenuItem tsmiSkip;

	private ToolStripMenuItem tsmiStopAfterCurrent;

	private MetroButton btnSetting;

	private ColumnHeader columnHeader_2;

	private ColumnHeader columnHeader_3;

	private ColumnHeader columnHeader_4;

	private TableLayoutPanel splitIntroEndCard;

	private MetroComboBox cboTransition;

	private MetroLabel lblTransition;

	private ColumnHeader columnHeader_5;

	private MetroToggle togIntro;

	private MetroToggle togEndCard;

	private MetroToggle togSubtitle;

	private MetroToggle togKaraoke;

	private MetroLink lblLinkLogo;

	private MetroLabel lblHowtoUse;

	private ToolStripMenuItem tsmiStop;

	private ContextMenuStrip cmsControlQueue_2;

	private ToolStripMenuItem tsmiAddFiles;

	private ToolStripMenuItem tsmiAddFolder;

	private ContextMenuStrip cmsControlQueue_3;

	private ContextMenuStrip cmsControlQueue_4;

	private ToolStripSeparator toolStripMenuItem5;

	private ToolStripMenuItem tsmiNewProject;

	private ToolStripMenuItem tsmiOpenProject;

	private ToolStripMenuItem tsmiSaveProject;

	private ToolStripMenuItem tsmiSaveasProject;

	private MetroButton btnInfo;

	private ToolStripMenuItem tsmiAbout;

	private MetroButton btnPreview;

	private MetroTrackBar tbVideo;

	private PictureBox picLogo;

	private MetroProgressSpinner psProgress;

	private MetroLabel lblOntop;

	private ToolStripMenuItem tsmiEmptyFile;

	private ToolStripMenuItem tsmiDeleteFile;

	private ContextMenuStrip cmsControlQueue_5;

	private ContextMenuStrip cmsControlQueue_6;

	private ToolStripMenuItem tsmiOpenKonayuki;

	private ToolStripSeparator toolStripMenuItem1;

	private ToolStripMenuItem tsmiTraySettings;

	private ToolStripMenuItem tsmiTrayLanguage;

	private ToolStripSeparator toolStripMenuItem2;

	private ToolStripMenuItem tsmiTrayApiVersion;

	private ToolStripSeparator toolStripMenuItem3;

	private ToolStripMenuItem tsmiTrayAbout;

	private ToolStripSeparator toolStripMenuItem4;

	private ToolStripSeparator toolStripMenuItem7;

	private ToolStripMenuItem tsmiExit;

	private MetroTextBox txtEndCard;

	private ContextMenuStrip cmsControlQueue_7;

	private ToolStripMenuItem tsmiSettings;

	private ToolStripMenuItem tsmiLanguage;

	private ToolStripMenuItem tsmiTroubleshooting;

	private PictureBox picWait;

	private MetroCheckBox chkIntroMusic;

	private MetroCheckBox chkEndCardMusic;

	private MetroCheckBox chkKaraokeOP;

	private MetroCheckBox chkEndCardTransitionOverlay;

	private MetroCheckBox chkIntroTransitionOverlay;

	private MetroCheckBox chkKaraokeED;

	private ColumnHeader columnHeader_6;

	private Panel pnLog;

	private RichTextBox txtLog;

	private ColumnHeader columnHeader_7;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripMenuItem tsmiSetOutputFile;

	private ToolStripSeparator toolStripSeparator2;

	private ToolStripMenuItem tsmiPlayInput;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripMenuItem tsmiOpenInput;

	private ToolStripMenuItem tsmiOpenOutput;

	private MetroButton btnCompare;

	private ContextMenuStrip cmsControlQueue_8;

	private ToolStripMenuItem tsmiCompare1;

	private ToolStripMenuItem tsmiCompare2;

	private ToolStripMenuItem tsmiCompare3;

	private ColumnHeader columnHeader_8;

	private PictureBox picSaved;

	private ToolStripMenuItem tsmiRepair;

	private ToolStripMenuItem tsmiChangelog;

	private MetroButton btnMPC;

	private MetroButton btnCompareMPC;

	private ContextMenuStrip cmsControlQueue_9;

	private ToolStripMenuItem tsmiCompareMPC1;

	private ToolStripMenuItem tsmiCompareMPC2;

	private ToolStripMenuItem tsmiCompareMPC3;

	private ToolStripMenuItem tsmiCompareMPC4;

	private ToolStripMenuItem tsmiDuplicate;

	private MetroLabel lblAudioTrack;

	private MetroComboBox cboAudioTrack;

	private MetroComboBox cboAudioTrack2;

	private ToolStripMenuItem tsmiTUT;

	private ToolStripMenuItem tsmiSetOutputFolder;

	private ToolStripMenuItem tsmiClearOutput;

	private MetroComboBox cboAudioSampleRates;

	private TableLayoutPanel splitMain;

	private MetroTabControl tcPlayer;

	private MetroTabPage tpPreview;

	private Panel pnControl;

	private Button btnPlay;

	private Button btnGoTo;

	private Button btnMute;

	private Button btnStoped;

	private MetroTrackBar tbVolume;

	private Button btnDecreaseSpeed;

	private MetroTrackBar tbSeek;

	private Button btnIncreaseSpeed;

	private Button btnPreviousFrame;

	private Panel panel1;

	private Button btnNextFrame;

	private Button btnFullScreen;

	private Button btnComp;

	private Button btnPause;

	private Panel panel2;

	private MetroToggle togPreview;

	private MetroTabPage tpMediaInfo;

	private RichTextBox rtbInfo;

	private MetroTextBox txtSubtitle;

	private PictureBox videoBox;

	private MetroButton btnFonts;

	private Button btnReset;

	private ToolStripMenuItem tsmiDisable;

	private MetroLabel lblGoToFrame;

	private MetroTextBox txtGoToFrame;

	private MetroLabel lblGoToHelp;

	private Button btnGotoExit;

	private Panel pnGoto;

	private ColumnHeader columnHeader_9;

	public frmMain()
	{
		InitializeComponent();
		backgroundWorker_0.WorkerReportsProgress = true;
		backgroundWorker_0.WorkerSupportsCancellation = true;
		backgroundWorker_0.DoWork += backgroundWorker_0_DoWork;
		backgroundWorker_0.ProgressChanged += backgroundWorker_0_ProgressChanged;
		backgroundWorker_0.RunWorkerCompleted += backgroundWorker_0_RunWorkerCompleted;
		Control control = this;
		do
		{
			control = GetNextControl(control, forward: true);
			if (control == null)
			{
				continue;
			}
			if (!(control is RichTextBox) && !(control is ListView))
			{
				control.MouseWheel += (object P_0, MouseEventArgs P_1) =>
				{
					((HandledMouseEventArgs)P_1).Handled = true;
				};
			}
			if (control is MetroTrackBar && control.Name != "tbVideo" && control.Name != "tbSeek" && control.Name != "tbVolume")
			{
				control.MouseUp += delegate
				{
					method_33();
				};
			}
			if (control is MetroToggle && control.Name != "togOntop" && control.Name != "togSameInput" && control.Name != "togPreview" && control.Name != "togClipDetails" && control.Name != "togIntro" && control.Name != "togEndCard")
			{
				((MetroToggle)control).MouseUp += delegate
				{
					method_33();
				};
			}
			if (control is MetroComboBox && control.Name != "cboVideoEncoder" && control.Name != "cboVideoPreset" && control.Name != "cboAudioFormat" && control.Name != "cboAudioQuality" && control.Name != "cboAudioSampleRates" && control.Name != "cboVideoSmooth")
			{
				((MetroComboBox)control).DropDownClosed += delegate
				{
					method_33();
				};
			}
			if (control is NumericUpDown && control.Name != "udIntroTime" && control.Name != "udEndCardTime")
			{
				((NumericUpDown)control).MouseUp += delegate
				{
					method_33();
				};
				((NumericUpDown)control).KeyDown += (object P_0, KeyEventArgs P_1) =>
				{
					if (P_1.KeyCode != Keys.Up && P_1.KeyCode != Keys.Down && P_1.KeyCode != Keys.Left && P_1.KeyCode != Keys.Right)
					{
						method_33();
					}
				};
			}
			if (control is MetroCheckBox)
			{
				((MetroCheckBox)control).MouseUp += delegate
				{
					method_33();
				};
			}
		}
		while (control != null);
		method_3(true);
		method_24();
		method_20();
		method_22();
		method_21();
		method_26(class4_0.Lang);
		method_31();
		Class2.smethod_0();
		class13_0 = JsonConvert.DeserializeObject<Class13>(Class48.smethod_19(Class49.smethod_1(string_0), false));
		if (frmSplash.bool_0)
		{
			tsmiRepair.Visible = false;
			btnMPC.Visible = true;
			btnCompareMPC.Visible = true;
		}
	}

	private void method_0(bool P_0)
	{
		if (P_0 && File.Exists(Class48.smethod_37() + "\\plugins.cfg"))
		{
			string_0 = File.ReadAllText(Class48.smethod_37() + "\\plugins.cfg");
			class13_0 = JsonConvert.DeserializeObject<Class13>(Class48.smethod_19(Class49.smethod_1(string_0), false));
			string_1 = class13_0.Version;
		}
	}

	private void method_1()
	{
		if (!method_30() || lstQueue.Items.Count <= 0)
		{
			return;
		}
		Show();
		WindowState = FormWindowState.Normal;
		Focus();
		Class48.smethod_23(Handle, this);
		DialogResult dialogResult = MetroMessageBox.Show(this, "Do you want to save changes to " + string_3 + "?", "KONAYUKI PLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
		if (dialogResult == DialogResult.Yes)
		{
			if (string_3 == "Untitled")
			{
				method_28();
				return;
			}
			method_11();
			File.WriteAllText(string_3, JsonConvert.SerializeObject(list_0, Formatting.Indented));
		}
	}

	private bool method_2(string P_0)
	{
		foreach (Match item in Regex.Matches(string_2, "(?<filename>.*?)\\|(?<hash>.*?)\\|(?<run>.*?)\\|(?<cmd>.*?)\n"))
		{
			if (P_0.Contains(item.Groups["filename"].Value))
			{
				return Class48.smethod_5(P_0).Equals(item.Groups["hash"].Value);
			}
		}
		return false;
	}

	private void method_3(bool P_0)
	{
		notifyIcon_0.Text = "KONAYUKI PLUS";
		notifyIcon_0.Icon = Icon;
		notifyIcon_0.Visible = P_0;
		notifyIcon_0.MouseClick += (object obj, MouseEventArgs e) =>
		{
			if (e.Button == MouseButtons.Right)
			{
				tsmiTrayApiVersion.Text = "API V." + class13_0.Version;
			}
		};
		notifyIcon_0.MouseDoubleClick += (object obj, MouseEventArgs e) =>
		{
			if (e.Button == MouseButtons.Left)
			{
				togPreview.Checked = false;
				class6_0.method_15();
				videoBox.Image = Resources.player_off;
				Class12.smethod_2();
				Show();
				WindowState = FormWindowState.Normal;
				Focus();
			}
		};
		notifyIcon_0.ContextMenuStrip = cmsControlQueue_6;
	}

	private void method_4(int P_0, bool P_1 = false)
	{
		if (bool_2)
		{
			return;
		}
		foreach (ListViewItem item in lstQueue.Items)
		{
			if (item.Selected)
			{
				frmHelp_0.Show();
				frmHelp_0.Hide();
				frmHelper_0.Show();
				frmHelper_0.Hide();
				frmTimer_0.Show();
				frmTimer_0.Hide();
				if (Class48.smethod_8())
				{
					frmBorder_0.Show();
					frmBorder_0.Hide();
				}
				bool_9 = false;
				method_17(item.Index, Class48.smethod_18(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds.ToString()) + ".avs", P_0, P_1);
			}
		}
		bool_9 = true;
	}

	private async void method_5(string P_0)
	{
		class6_0.method_6(P_0);
		await Task.Delay(3000);
		class6_0.method_6(string.Empty);
	}

	private int method_6(string P_0)
	{
		try
		{
			string[] array = new string[11]
			{
				"\\moves3", "\\moves4", "\\fsvp", "\\jitter", "\\frs", "\\z", "\\rnd", "\\distort", "\\mover", "\\movevc",
				"\\movevc"
			};
			string[] array2 = File.ReadAllLines(P_0);
			bool flag = false;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array;
				foreach (string value in array3)
				{
					if (array2[i].Contains(value))
					{
						flag = true;
					}
					if (Regex.Match(array2[i], "\\\\([\\d]+)vc").Success || Regex.Match(array2[i], "\\\\([\\d]+)va").Success || Regex.Match(array2[i], "\\\\([\\d]+)img").Success)
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				return 1;
			}
			return 0;
		}
		catch
		{
			return 0;
		}
	}

	private void method_7(string P_0, string P_1)
	{
		try
		{
			string[] array = File.ReadAllLines(P_0);
			List<string> list = new List<string>();
			foreach (Match item in Regex.Matches(string.Join("\r\n", array), "Style: (.*?),"))
			{
				list.Add(item.Groups[1].Value);
			}
			for (int i = 0; i < array.Length; i++)
			{
				Match match2 = Regex.Match(array[i], "Dialogue: (.*?),(.*?),(.*?),(.*?),(.*)");
				if (match2.Success && !list.Contains(match2.Groups[4].Value))
				{
					array[i] = array[i].Replace(match2.Groups[4].Value, "Default");
				}
			}
			Class48.smethod_16(P_0, P_1, array);
		}
		catch
		{
		}
	}

	private void method_8(string P_0)
	{
		if (!(Application.OpenForms["frmComplete"] is frmComplete))
		{
			frmComplete.string_0 = P_0;
			frmComplete frmComplete2 = new frmComplete();
			frmComplete2.ShowDialog(this);
		}
	}

	private void backgroundWorker_0_RunWorkerCompleted(object P_0, RunWorkerCompletedEventArgs P_1)
	{
		method_31();
		Class12.smethod_2(true);
		if (P_1.Cancelled)
		{
			psProgress.Visible = false;
			new Notification("Notification", "Stop!!", 10, Enum13.Value3, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
			return;
		}
		if (P_1.Error != null)
		{
			psProgress.Visible = false;
			Class48.smethod_23(Handle, this);
			MetroMessageBox.Show(this, P_1.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			bool_12 = false;
			tvDetails.Nodes.Clear();
			return;
		}
		psProgress.Visible = false;
		if (bool_10)
		{
			TaskbarManager.Instance.SetProgressValue(0, 100);
			switch (class4_0.AfterCompletion)
			{
			case 1:
				method_8("Shutdown");
				break;
			case 2:
				method_8("Restart");
				break;
			case 3:
				method_8("Log Off");
				break;
			}
		}
	}

	private void backgroundWorker_0_ProgressChanged(object P_0, ProgressChangedEventArgs P_1)
	{
		if (TaskbarManager.IsPlatformSupported)
		{
			TaskbarManager.Instance.SetProgressValue(P_1.ProgressPercentage, 100);
		}
	}

	private void backgroundWorker_0_DoWork(object P_0, DoWorkEventArgs P_1)
	{
		while (!bool_9)
		{
		}
		string text = Class48.smethod_18(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds.ToString()) ?? "";
		string stringValue = text + ".avs";
		if (!Directory.Exists(Path.Combine(Class48.smethod_37(), "tmp")))
		{
			Directory.CreateDirectory(Path.Combine(Class48.smethod_37(), "tmp"));
		}
		Class48.LogPath = Class48.smethod_37() + "\\tmp\\a_" + text + ".log";
		int intValue;
		for (intValue = 0; intValue < lstQueue.Items.Count; intValue++)
		{
			if (backgroundWorker_0.CancellationPending)
			{
				P_1.Cancel = true;
				break;
			}
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() =>
				{
					if (list_0[intValue].Checked)
					{
						bool_12 = true;
						method_17(intValue, stringValue);
						int_4 = intValue;
						if (tvDetails.Nodes.Count != 0)
						{
							try
							{
								tvDetails.Nodes[0].Nodes[5].Text = "Input Size : " + ByteSize.FromBytes(new FileInfo(list_0[intValue].Fullpath + "\\" + list_0[intValue].File).Length);
								return;
							}
							catch
							{
								return;
							}
						}
						method_31();
					}
				}));
			}
			if (bool_12)
			{
				if (!Directory.Exists(Path.Combine(Class48.smethod_37(), "tmp")))
				{
					Directory.CreateDirectory(Path.Combine(Class48.smethod_37(), "tmp"));
				}
				string text2 = (togClipDetails.Checked ? ("-metadata title=\"" + txtClipDeailsName.Text + "\" -metadata artist=\"" + txtClipDeailsAuthor.Text + "\"") : null);
				string text3 = ((list_0[intValue].Audio.Format == 0) ? ".mp4" : ".mkv");
				method_25(intValue, "-y -i \"" + Class48.smethod_37() + "\\tmp\\a_" + stringValue + $"\" {Class48.smethod_27(list_0[intValue].Video.Encoder)} {Class48.smethod_28(list_0[intValue].Video.Encoder, list_0[intValue].Video.Preset)} {Class48.smethod_29(list_0[intValue].Video.Encoder)} {Class48.smethod_30(list_0[intValue].Video.Encoder, list_0[intValue].Video.Quality)} {text2} -metadata comment=\"V={Assembly.GetExecutingAssembly().GetName().Version.ToString()} / API={class13_0.Version} / Encode_Time={DateTime.Now} / Encoder={list_0[intValue].Video.Encoder} / Preset={list_0[intValue].Video.Preset} / Quality={list_0[intValue].Video.Quality} / Resize={list_0[intValue].Advance.Video.Enhancer.Resize} / 60FPS={list_0[intValue].Advance.Video.Enhancer.FPS60} / Line_Darkener={list_0[intValue].Advance.Video.Enhancer.LineDarkener} / Sharpen={list_0[intValue].Advance.Video.Enhancer.Sharpen} / Warp_Sharp={list_0[intValue].Advance.Video.Enhancer.WarpSharp} / Noise_Remover={list_0[intValue].Advance.Video.Enhancer.NoiseRemover} / Brightness={list_0[intValue].Advance.Video.Color.Brightness} / Contrast={list_0[intValue].Advance.Video.Color.Contrast} / Saturation={list_0[intValue].Advance.Video.Color.Saturation} / Debanding={list_0[intValue].Advance.Video.Color.Debanding} / Source_Vol={list_0[intValue].Audio.Volume.Source} / Intro_Vol={list_0[intValue].Audio.Volume.Intro} / EndCard_Vol={list_0[intValue].Audio.Volume.Endcard} / Logo_Remover={list_0[intValue].Advance.Special.SubRemover.Status}\" {Class48.smethod_31(list_0[intValue].Audio.Format, list_0[intValue].Audio.Quality)} ", Class48.smethod_37() + "\\tmp\\f_" + text + text3);
				bool_12 = false;
			}
		}
	}

	private List<Class54> method_9(string P_0)
	{
		List<Class54> list = new List<Class54>();
		string empty = string.Empty;
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(Path.Combine(P_0));
		for (int i = 0; i < native_MediaInfo.method_16(Enum0.Value2); i++)
		{
			string title = ((native_MediaInfo.method_13(Enum0.Value2, i, "Title") == string.Empty) ? "Untitled" : native_MediaInfo.method_13(Enum0.Value2, i, "Title"));
			string language = ((native_MediaInfo.method_13(Enum0.Value2, i, "Language/String") == string.Empty) ? "Unknown" : native_MediaInfo.method_13(Enum0.Value2, i, "Language/String"));
			string format = ((native_MediaInfo.method_13(Enum0.Value2, i, "Format") == string.Empty) ? "Unknown" : native_MediaInfo.method_13(Enum0.Value2, i, "Format"));
			string channel = ((native_MediaInfo.method_13(Enum0.Value2, i, "Channel(s)/String") == string.Empty) ? "Unknown" : native_MediaInfo.method_13(Enum0.Value2, i, "Channel(s)/String"));
			string sampleRate = ((native_MediaInfo.method_13(Enum0.Value2, i, "SamplingRate/String") == string.Empty) ? "Unknown" : native_MediaInfo.method_13(Enum0.Value2, i, "SamplingRate/String"));
			string bitDepth = ((native_MediaInfo.method_13(Enum0.Value2, i, "BitDepth/String") == string.Empty) ? "Unknown" : native_MediaInfo.method_13(Enum0.Value2, i, "BitDepth/String"));
			string bitRate = ((native_MediaInfo.method_13(Enum0.Value2, i, "BitRate/String") == string.Empty) ? "Unknown" : native_MediaInfo.method_13(Enum0.Value2, i, "BitRate/String"));
			list.Add(new Class54
			{
				Id = i,
				Title = title,
				Language = language,
				Format = format,
				Channel = channel,
				SampleRate = sampleRate,
				BitDepth = bitDepth,
				BitRate = bitRate
			});
		}
		native_MediaInfo.method_5();
		return list;
	}

	private void method_10(string P_0)
	{
		lstQueue.Items.Add(new ListViewItem(new string[10]
		{
			Path.GetFileName(P_0),
			Path.GetExtension(P_0).ToLower().ToLower(),
			"Ready",
			null,
			null,
			Path.GetDirectoryName(P_0),
			null,
			bool.FalseString,
			Class48.smethod_9(P_0),
			null
		})
		{
			Checked = true
		});
		list_0.Add(new Class52
		{
			File = Path.GetFileName(P_0),
			Fullpath = Path.GetDirectoryName(P_0),
			Type = Path.GetExtension(P_0).ToLower(),
			Checked = true,
			Video = new Class55
			{
				Encoder = cboVideoEncoder.SelectedIndex,
				Preset = cboVideoPreset.SelectedIndex,
				Quality = tbVideo.Value
			},
			Subtitle = new Class51
			{
				Enable = togSubtitle.Checked,
				File = txtSubtitle.Text
			},
			Intro = new Class45
			{
				Enable = togIntro.Checked,
				MusicEnable = chkIntroMusic.Checked,
				File = txtIntro.Text,
				Music = txtIntroMusic.Text,
				Time = udIntroTime.Value
			},
			Endcard = new Class44
			{
				Enable = togEndCard.Checked,
				MusicEnable = chkEndCardMusic.Checked,
				File = txtEndCard.Text,
				Music = txtEndCardMusic.Text,
				Time = udEndCardTime.Value
			},
			Karaoke = new Class46
			{
				Enable = togKaraoke.Checked,
				OPEnable = chkKaraokeOP.Checked,
				EDEnable = chkKaraokeED.Checked,
				OP = txtKaraokeOP.Text,
				ED = txtKaraokeED.Text
			},
			Audio = new Class41
			{
				Format = cboAudioFormat.SelectedIndex,
				Quality = cboAudioQuality.SelectedIndex,
				SampleRates = cboAudioSampleRates.SelectedIndex,
				Track = method_9(P_0),
				Volume = new Class42
				{
					Intro = tbVolumeIntro.Value,
					Source = tbVolumeSource.Value,
					Endcard = tbVolumeEndCard.Value
				}
			},
			Details = new Class43
			{
				Enable = togClipDetails.Checked,
				Title = txtClipDeailsName.Text,
				Author = txtClipDeailsAuthor.Text
			},
			Advance = new Class26
			{
				Video = new Class38
				{
					Enhancer = new Class39
					{
						Resize = cboVideoResize.SelectedIndex,
						FPS60 = cboVideoSmooth.SelectedIndex,
						LineDarkener = tbVideoLineDarkener.Value,
						Sharpen = tbVideoSharpen.Value,
						WarpSharp = tbVideoWarpSharp.Value,
						NoiseRemover = cboVideoRemover.SelectedIndex
					},
					Color = new Class40
					{
						Brightness = tbColorBrightness.Value,
						Contrast = tbColorContrast.Value,
						Saturation = tbColorSaturation.Value,
						Debanding = cboColorDebanding.SelectedIndex
					}
				},
				Transition = new Class53
				{
					Status = cboTransition.SelectedIndex,
					Fade = new Class37
					{
						Intro = new Class32
						{
							IN = new Class31
							{
								Status = togFadeIn.Checked,
								Time = udIntroFadeInTime.Value,
								Color = Class48.smethod_26(pFadeInColor)
							},
							OUT = new Class33
							{
								Status = togFadeOut.Checked,
								Time = udIntroFadeOutTime.Value,
								Color = Class48.smethod_26(pFadeOutColor)
							}
						},
						Source = new Class29
						{
							IN = new Class28
							{
								Status = togSourceIn.Checked,
								Time = udSourceFadeInTime.Value,
								Color = Class48.smethod_26(pSourceInColor)
							},
							OUT = new Class30
							{
								Status = togSourceOut.Checked,
								Time = udSourceFadeOutTime.Value,
								Color = Class48.smethod_26(pSourceOutColor)
							}
						},
						EndCard = new Class35
						{
							IN = new Class34
							{
								Status = togEndCardIn.Checked,
								Time = udEndCardFadeInTime.Value,
								Color = Class48.smethod_26(pEndCardInColor)
							},
							OUT = new Class36
							{
								Status = togEndCardOut.Checked,
								Time = udEndCardFadeOutTime.Value,
								Color = Class48.smethod_26(pEndCardOutColor)
							}
						}
					},
					Disslove = new Class27
					{
						Time = udDissolveTime.Value,
						FadeInTime = udDissolveFadeInTime.Value,
						FadeOutTime = udDissolveFadeOutTime.Value
					},
					Custom = new Class25
					{
						Intro = new Class24
						{
							Enable = chkIntroTransitionOverlay.Checked,
							File = txtIntroTransition.Text,
							Overlay = txtIntroTransitionOverlay.Text,
							Time = udIntroTransitionAudioTime.Value
						},
						EndCard = new Class23
						{
							Enable = chkEndCardTransitionOverlay.Checked,
							File = txtEndCardTransition.Text,
							Overlay = txtEndCardTransitionOverlay.Text,
							Time = udEndCardTransitionAudioTime.Value
						}
					}
				},
				Logo = new Class20
				{
					Enable = togLogo.Checked,
					File = txtLogo.Text,
					AlwaysShow = togLogoTime.Checked,
					ShowTime = udLogoTimeSec.Value,
					ShowEvery = udLogoTimeSecMinute.Value,
					Color = Class48.smethod_26(pLogoFadeColor),
					Opacity = tbLogoOpacity.Value,
					BlendMode = cboLogoBlend.Text,
					ASS = new Class19
					{
						Enable = togLogoSubtitle.Checked,
						File = txtLogoSubtitle.Text
					}
				},
				Special = new Class21
				{
					SubRemover = new Class22
					{
						Status = togHardSubRemover.Checked,
						Top = udRemoverTop.Value,
						Bottom = udRemoverBottom.Value,
						Left = udRemoverLeft.Value,
						Right = udRemoverRight.Value,
						Level1 = tbRemoverLevel1.Value,
						Level2 = tbRemoverLevel2.Value
					}
				}
			},
			System = new Class56
			{
				MainPath = Class48.smethod_37(),
				Cores = Class18.smethod_1(),
				Threads = Class18.smethod_2(),
				Ram = Class18.smethod_0(),
				Preview = 0,
				EncodeStatus = 0,
				ScanType = class56_0.method_0(P_0),
				ScanMethod = class56_0.method_1(P_0),
				ScanOrder = class56_0.method_2(P_0),
				DAR = class56_0.method_3(P_0)
			}
		});
	}

	private void method_11()
	{
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			list_0[i].Checked = lstQueue.Items[i].Checked;
		}
	}

	private void method_12(int P_0, bool P_1 = false)
	{
		list_0[P_0].Checked = lstQueue.Items[P_0].Checked;
		list_0[P_0].Video.Encoder = cboVideoEncoder.SelectedIndex;
		list_0[P_0].Video.Preset = cboVideoPreset.SelectedIndex;
		list_0[P_0].Video.Quality = tbVideo.Value;
		list_0[P_0].Subtitle.Enable = togSubtitle.Checked;
		list_0[P_0].Subtitle.File = (P_1 ? txtSubtitle.Text : list_0[P_0].Subtitle.File);
		list_0[P_0].Intro.Enable = togIntro.Checked;
		list_0[P_0].Intro.MusicEnable = chkIntroMusic.Checked;
		list_0[P_0].Intro.File = txtIntro.Text;
		list_0[P_0].Intro.Music = txtIntroMusic.Text;
		list_0[P_0].Intro.Time = udIntroTime.Value;
		list_0[P_0].Endcard.Enable = togEndCard.Checked;
		list_0[P_0].Endcard.MusicEnable = chkEndCardMusic.Checked;
		list_0[P_0].Endcard.File = txtEndCard.Text;
		list_0[P_0].Endcard.Music = txtEndCardMusic.Text;
		list_0[P_0].Endcard.Time = udEndCardTime.Value;
		list_0[P_0].Karaoke.Enable = togKaraoke.Checked;
		list_0[P_0].Karaoke.OPEnable = chkKaraokeOP.Checked;
		list_0[P_0].Karaoke.EDEnable = chkKaraokeED.Checked;
		list_0[P_0].Karaoke.OP = txtKaraokeOP.Text;
		list_0[P_0].Karaoke.ED = txtKaraokeED.Text;
		list_0[P_0].Details.Enable = togClipDetails.Checked;
		list_0[P_0].Details.Title = txtClipDeailsName.Text;
		list_0[P_0].Details.Author = txtClipDeailsAuthor.Text;
		list_0[P_0].Audio.Format = cboAudioFormat.SelectedIndex;
		list_0[P_0].Audio.Quality = cboAudioQuality.SelectedIndex;
		list_0[P_0].Audio.SampleRates = cboAudioSampleRates.SelectedIndex;
		if (lstQueue.SelectedItems.Count <= 1)
		{
			if (list_0[P_0].Audio.Track != null)
			{
				if (list_0[P_0].Audio.Track.Count > 0)
				{
					cboAudioTrack.Visible = true;
					list_0[P_0].Audio.TrackId = cboAudioTrack.SelectedIndex;
				}
				else
				{
					cboAudioTrack.Visible = false;
					cboAudioTrack2.SelectedIndex = 1;
				}
			}
		}
		else
		{
			cboAudioTrack2.SelectedIndex = 0;
			cboAudioTrack.Visible = false;
		}
		list_0[P_0].Audio.Volume.Intro = tbVolumeIntro.Value;
		list_0[P_0].Audio.Volume.Source = tbVolumeSource.Value;
		list_0[P_0].Audio.Volume.Endcard = tbVolumeEndCard.Value;
		list_0[P_0].Advance.Video.Enhancer.Resize = cboVideoResize.SelectedIndex;
		list_0[P_0].Advance.Video.Enhancer.FPS60 = cboVideoSmooth.SelectedIndex;
		list_0[P_0].Advance.Video.Enhancer.LineDarkener = tbVideoLineDarkener.Value;
		list_0[P_0].Advance.Video.Enhancer.Sharpen = tbVideoSharpen.Value;
		list_0[P_0].Advance.Video.Enhancer.WarpSharp = tbVideoWarpSharp.Value;
		list_0[P_0].Advance.Video.Enhancer.NoiseRemover = cboVideoRemover.SelectedIndex;
		list_0[P_0].Advance.Video.Color.Brightness = tbColorBrightness.Value;
		list_0[P_0].Advance.Video.Color.Contrast = tbColorContrast.Value;
		list_0[P_0].Advance.Video.Color.Saturation = tbColorSaturation.Value;
		list_0[P_0].Advance.Video.Color.Debanding = cboColorDebanding.SelectedIndex;
		list_0[P_0].Advance.Transition.Status = cboTransition.SelectedIndex;
		list_0[P_0].Advance.Transition.Fade.Intro.IN.Status = togFadeIn.Checked;
		list_0[P_0].Advance.Transition.Fade.Intro.IN.Time = udIntroFadeInTime.Value;
		list_0[P_0].Advance.Transition.Fade.Intro.IN.Color = Class48.smethod_26(pFadeInColor);
		list_0[P_0].Advance.Transition.Fade.Intro.OUT.Status = togFadeOut.Checked;
		list_0[P_0].Advance.Transition.Fade.Intro.OUT.Time = udIntroFadeOutTime.Value;
		list_0[P_0].Advance.Transition.Fade.Intro.OUT.Color = Class48.smethod_26(pFadeOutColor);
		list_0[P_0].Advance.Transition.Fade.Source.IN.Status = togSourceIn.Checked;
		list_0[P_0].Advance.Transition.Fade.Source.IN.Time = udSourceFadeInTime.Value;
		list_0[P_0].Advance.Transition.Fade.Source.IN.Color = Class48.smethod_26(pSourceInColor);
		list_0[P_0].Advance.Transition.Fade.Source.OUT.Status = togSourceOut.Checked;
		list_0[P_0].Advance.Transition.Fade.Source.OUT.Time = udSourceFadeOutTime.Value;
		list_0[P_0].Advance.Transition.Fade.Source.OUT.Color = Class48.smethod_26(pSourceOutColor);
		list_0[P_0].Advance.Transition.Fade.EndCard.IN.Status = togEndCardIn.Checked;
		list_0[P_0].Advance.Transition.Fade.EndCard.IN.Time = udEndCardFadeInTime.Value;
		list_0[P_0].Advance.Transition.Fade.EndCard.IN.Color = Class48.smethod_26(pEndCardInColor);
		list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Status = togEndCardOut.Checked;
		list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Time = udEndCardFadeOutTime.Value;
		list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Color = Class48.smethod_26(pEndCardOutColor);
		list_0[P_0].Advance.Transition.Disslove.Time = udDissolveTime.Value;
		list_0[P_0].Advance.Transition.Disslove.FadeInTime = udDissolveFadeInTime.Value;
		list_0[P_0].Advance.Transition.Disslove.FadeOutTime = udDissolveFadeOutTime.Value;
		list_0[P_0].Advance.Transition.Custom.Intro.File = txtIntroTransition.Text;
		list_0[P_0].Advance.Transition.Custom.Intro.Enable = chkIntroTransitionOverlay.Checked;
		list_0[P_0].Advance.Transition.Custom.Intro.Overlay = txtIntroTransitionOverlay.Text;
		list_0[P_0].Advance.Transition.Custom.Intro.Time = udIntroTransitionAudioTime.Value;
		list_0[P_0].Advance.Transition.Custom.EndCard.File = txtEndCardTransition.Text;
		list_0[P_0].Advance.Transition.Custom.EndCard.Enable = chkEndCardTransitionOverlay.Checked;
		list_0[P_0].Advance.Transition.Custom.EndCard.Overlay = txtEndCardTransitionOverlay.Text;
		list_0[P_0].Advance.Transition.Custom.EndCard.Time = udEndCardTransitionAudioTime.Value;
		list_0[P_0].Advance.Logo.Enable = togLogo.Checked;
		list_0[P_0].Advance.Logo.File = txtLogo.Text;
		list_0[P_0].Advance.Logo.AlwaysShow = togLogoTime.Checked;
		list_0[P_0].Advance.Logo.ShowTime = udLogoTimeSec.Value;
		list_0[P_0].Advance.Logo.ShowEvery = udLogoTimeSecMinute.Value;
		list_0[P_0].Advance.Logo.Color = Class48.smethod_26(pLogoFadeColor);
		list_0[P_0].Advance.Logo.Opacity = tbLogoOpacity.Value;
		list_0[P_0].Advance.Logo.BlendMode = cboLogoBlend.Text;
		list_0[P_0].Advance.Logo.ASS.Enable = togLogoSubtitle.Checked;
		list_0[P_0].Advance.Logo.ASS.File = txtLogoSubtitle.Text;
		list_0[P_0].Advance.Special.SubRemover.Status = togHardSubRemover.Checked;
		list_0[P_0].Advance.Special.SubRemover.Top = udRemoverTop.Value;
		list_0[P_0].Advance.Special.SubRemover.Bottom = udRemoverBottom.Value;
		list_0[P_0].Advance.Special.SubRemover.Left = udRemoverLeft.Value;
		list_0[P_0].Advance.Special.SubRemover.Right = udRemoverRight.Value;
		list_0[P_0].Advance.Special.SubRemover.Level1 = tbRemoverLevel1.Value;
		list_0[P_0].Advance.Special.SubRemover.Level2 = tbRemoverLevel2.Value;
	}

	private void method_13(string P_0)
	{
		if (class4_0.IsAutoLoadSub)
		{
			if (File.Exists(Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".ass")))
			{
				txtSubtitle.Text = Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".ass");
			}
			else if (File.Exists(Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".ssa")))
			{
				txtSubtitle.Text = Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".ssa");
			}
			else if (File.Exists(Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".srt")))
			{
				txtSubtitle.Text = Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".srt");
			}
			else if (File.Exists(Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".sup")))
			{
				txtSubtitle.Text = Path.Combine(Path.GetDirectoryName(P_0), Path.GetFileNameWithoutExtension(P_0) + ".sup");
			}
		}
	}

	private bool method_14(string P_0, bool P_1 = true)
	{
		string[] source = new string[4] { ".ass", ".ssa", ".srt", ".sup" };
		if (P_1)
		{
			FileInfo[] files = new DirectoryInfo(Path.GetDirectoryName(P_0)).GetFiles("*.*");
			foreach (FileInfo fileInfo in files)
			{
				if (Path.GetFileNameWithoutExtension(fileInfo.Name) == Path.GetFileNameWithoutExtension(P_0) && source.Contains(Path.GetExtension(fileInfo.Name).ToLower()))
				{
					File.Move(fileInfo.DirectoryName + "\\" + fileInfo.Name, fileInfo.DirectoryName + "\\" + Path.GetFileNameWithoutExtension(fileInfo.Name) + string_4 + Path.GetExtension(fileInfo.Name));
				}
			}
			return false;
		}
		FileInfo[] files2 = new DirectoryInfo(Path.GetDirectoryName(P_0)).GetFiles("*.*");
		foreach (FileInfo fileInfo2 in files2)
		{
			if (Path.GetFileNameWithoutExtension(fileInfo2.Name) == Path.GetFileNameWithoutExtension(P_0) + string_4 && source.Contains(Path.GetExtension(fileInfo2.Name).ToLower()))
			{
				File.Move(fileInfo2.DirectoryName + "\\" + fileInfo2.Name, fileInfo2.DirectoryName + "\\" + Path.GetFileNameWithoutExtension(fileInfo2.Name).Substring(0, Path.GetFileNameWithoutExtension(fileInfo2.Name).Length - string_4.Length) + Path.GetExtension(fileInfo2.Name));
			}
		}
		return true;
	}

	private bool method_15(int P_0, string P_1, int P_2 = 0)
	{
		if (P_2 > 0)
		{
			Class12.smethod_2();
		}
		if (method_16(P_0))
		{
			bool_2 = false;
			if (!Directory.Exists(Path.Combine(Class48.smethod_37(), "tmp")))
			{
				Directory.CreateDirectory(Path.Combine(Class48.smethod_37(), "tmp"));
			}
			string text = "DO_NOT_DELETE_ME";
			string text2 = Class49.smethod_1(class13_0.Function);
			if (list_0[P_0].Subtitle.Enable)
			{
				method_7(list_0[P_0].Subtitle.File, Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\s_" + P_1, Path.GetExtension(list_0[P_0].Subtitle.File)));
			}
			if (list_0[P_0].Karaoke.Enable)
			{
				if (list_0[P_0].Karaoke.OPEnable)
				{
					method_7(list_0[P_0].Karaoke.OP, Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\o_" + P_1, Path.GetExtension(list_0[P_0].Karaoke.OP)));
				}
				if (list_0[P_0].Karaoke.EDEnable)
				{
					method_7(list_0[P_0].Karaoke.ED, Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\e_" + P_1, Path.GetExtension(list_0[P_0].Karaoke.ED)));
				}
			}
			if (list_0[P_0].Advance.Logo.ASS.Enable)
			{
				method_7(list_0[P_0].Advance.Logo.ASS.File, Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\l_" + P_1, Path.GetExtension(list_0[P_0].Advance.Logo.ASS.File)));
			}
			string text3 = Class48.smethod_32(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File));
			string text4 = Class48.smethod_33(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File));
			string newValue = Class48.smethod_41(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File));
			string newValue2 = Class48.smethod_42(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File));
			string newValue3 = Class48.smethod_43(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File));
			string fileName = Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File);
			string text5 = new FileInfo(fileName).Length.ToString();
			text2 = text2.Replace("{MT}", class4_0.IsMT.ToString()).Replace("{FUNCTION}", text).Replace("{MAIN_PATH}", list_0[P_0].System.MainPath)
				.Replace("{CORES}", list_0[P_0].System.Cores)
				.Replace("{THREADS}", list_0[P_0].System.Threads)
				.Replace("{RAM}", list_0[P_0].System.Ram)
				.Replace("{PREVIEW}", (P_2 == 0) ? "0" : P_2.ToString())
				.Replace("{ENCODER}", list_0[P_0].Video.Encoder.ToString())
				.Replace("{SCAN_TYPE}", list_0[P_0].System.ScanType)
				.Replace("{SCAN_METHOD}", list_0[P_0].System.ScanMethod)
				.Replace("{SCAN_ORDER}", list_0[P_0].System.ScanOrder)
				.Replace("{DAR}", list_0[P_0].System.DAR)
				.Replace("{SOURCE_PATH}", Class48.smethod_39("SOURCE_PATH", Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File)))
				.Replace("{SUBTITLE_ENABLE}", list_0[P_0].Subtitle.Enable.ToString())
				.Replace("{SUBTITLE_VSFILTER}", method_6(Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\s_" + P_1, Path.GetExtension(list_0[P_0].Subtitle.File))).ToString())
				.Replace("{SUBTITLE_FILE}", Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\s_" + P_1, Path.GetExtension(list_0[P_0].Subtitle.File)))
				.Replace("{INTRO_ENABLE}", list_0[P_0].Intro.Enable.ToString())
				.Replace("{INTRO_PATH}", Class48.smethod_39("INTRO_PATH", list_0[P_0].Intro.File))
				.Replace("{INTRO_MUSIC}", Class48.smethod_39("INTRO_MUSIC", list_0[P_0].Intro.Music))
				.Replace("{INTRO_MUSIC_ENABLE}", list_0[P_0].Intro.MusicEnable.ToString())
				.Replace("{INTRO_TIME}", list_0[P_0].Intro.Time.ToString())
				.Replace("{ENDCARD_ENABLE}", list_0[P_0].Endcard.Enable.ToString())
				.Replace("{ENDCARD_PATH}", Class48.smethod_39("ENDCARD_PATH", list_0[P_0].Endcard.File))
				.Replace("{ENDCARD_MUSIC}", Class48.smethod_39("ENDCARD_MUSIC", list_0[P_0].Endcard.Music))
				.Replace("{ENDCARD_MUSIC_ENABLE}", list_0[P_0].Endcard.MusicEnable.ToString())
				.Replace("{ENDCARD_TIME}", list_0[P_0].Endcard.Time.ToString())
				.Replace("{KARAOKE_ENABLE}", list_0[P_0].Karaoke.Enable.ToString())
				.Replace("{KARAOKE_OP_VSFILTER}", method_6(Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\o_" + P_1, Path.GetExtension(list_0[P_0].Karaoke.OP))).ToString())
				.Replace("{KARAOKE_ED_VSFILTER}", method_6(Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\e_" + P_1, Path.GetExtension(list_0[P_0].Karaoke.ED))).ToString())
				.Replace("{KARAOKE_OP}", Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\o_" + P_1, Path.GetExtension(list_0[P_0].Karaoke.OP)))
				.Replace("{KARAOKE_OP_ENABLE}", list_0[P_0].Karaoke.OPEnable.ToString())
				.Replace("{KARAOKE_ED}", Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\e_" + P_1, Path.GetExtension(list_0[P_0].Karaoke.ED)))
				.Replace("{KARAOKE_ED_ENABLE}", list_0[P_0].Karaoke.EDEnable.ToString())
				.Replace("{AUDIO_SAMPLE}", list_0[P_0].Audio.SampleRates.ToString())
				.Replace("{AUDIO_TRACK}", list_0[P_0].Audio.TrackId.ToString())
				.Replace("{INTRO_VOLUME}", list_0[P_0].Audio.Volume.Intro.ToString())
				.Replace("{SOURCE_VOLUME}", list_0[P_0].Audio.Volume.Source.ToString())
				.Replace("{ENDCARD_VOLUME}", list_0[P_0].Audio.Volume.Endcard.ToString())
				.Replace("{RESIZE}", list_0[P_0].Advance.Video.Enhancer.Resize.ToString())
				.Replace("{60FPS}", list_0[P_0].Advance.Video.Enhancer.FPS60.ToString())
				.Replace("{LINE_DARKENER}", list_0[P_0].Advance.Video.Enhancer.LineDarkener.ToString())
				.Replace("{SHARPEN}", list_0[P_0].Advance.Video.Enhancer.Sharpen.ToString())
				.Replace("{WARP_SHARP}", list_0[P_0].Advance.Video.Enhancer.WarpSharp.ToString())
				.Replace("{NOISE_REMOVER}", list_0[P_0].Advance.Video.Enhancer.NoiseRemover.ToString())
				.Replace("{BRIGHTNESS}", list_0[P_0].Advance.Video.Color.Brightness.ToString())
				.Replace("{CONTRAST}", list_0[P_0].Advance.Video.Color.Contrast.ToString())
				.Replace("{SATURATION}", list_0[P_0].Advance.Video.Color.Saturation.ToString())
				.Replace("{DEBANDING}", list_0[P_0].Advance.Video.Color.Debanding.ToString())
				.Replace("{TRANSITION}", list_0[P_0].Advance.Transition.Status.ToString())
				.Replace("{INTRO_FADE_IN}", list_0[P_0].Advance.Transition.Fade.Intro.IN.Status.ToString())
				.Replace("{INTRO_FADE_IN_TIME}", list_0[P_0].Advance.Transition.Fade.Intro.IN.Time.ToString())
				.Replace("{INTRO_FADE_IN_COLOR}", list_0[P_0].Advance.Transition.Fade.Intro.IN.Color.ToString())
				.Replace("{INTRO_FADE_OUT}", list_0[P_0].Advance.Transition.Fade.Intro.OUT.Status.ToString())
				.Replace("{INTRO_FADE_OUT_TIME}", list_0[P_0].Advance.Transition.Fade.Intro.OUT.Time.ToString())
				.Replace("{INTRO_FADE_OUT_COLOR}", list_0[P_0].Advance.Transition.Fade.Intro.OUT.Color.ToString())
				.Replace("{SOURCE_FADE_IN}", list_0[P_0].Advance.Transition.Fade.Source.IN.Status.ToString())
				.Replace("{SOURCE_FADE_IN_TIME}", list_0[P_0].Advance.Transition.Fade.Source.IN.Time.ToString())
				.Replace("{SOURCE_FADE_IN_COLOR}", list_0[P_0].Advance.Transition.Fade.Source.IN.Color.ToString())
				.Replace("{SOURCE_FADE_OUT}", list_0[P_0].Advance.Transition.Fade.Source.OUT.Status.ToString())
				.Replace("{SOURCE_FADE_OUT_TIME}", list_0[P_0].Advance.Transition.Fade.Source.OUT.Time.ToString())
				.Replace("{SOURCE_FADE_OUT_COLOR}", list_0[P_0].Advance.Transition.Fade.Source.OUT.Color.ToString())
				.Replace("{ENDCARD_FADE_IN}", list_0[P_0].Advance.Transition.Fade.EndCard.IN.Status.ToString())
				.Replace("{ENDCARD_FADE_IN_TIME}", list_0[P_0].Advance.Transition.Fade.EndCard.IN.Time.ToString())
				.Replace("{ENDCARD_FADE_IN_COLOR}", list_0[P_0].Advance.Transition.Fade.EndCard.IN.Color.ToString())
				.Replace("{ENDCARD_FADE_OUT}", list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Status.ToString())
				.Replace("{ENDCARD_FADE_OUT_TIME}", list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Time.ToString())
				.Replace("{ENDCARD_FADE_OUT_COLOR}", list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Color.ToString())
				.Replace("{DISSOLVE_TIME}", list_0[P_0].Advance.Transition.Disslove.Time.ToString())
				.Replace("{DISSOLVE_FADE_IN_TIME}", list_0[P_0].Advance.Transition.Disslove.FadeInTime.ToString())
				.Replace("{DISSOLVE_FADE_OUT_TIME}", list_0[P_0].Advance.Transition.Disslove.FadeOutTime.ToString())
				.Replace("{CUSTOM_TRANSITION_INTRO_PATH}", Class48.smethod_39("CUSTOM_TRANSITION_INTRO_PATH", list_0[P_0].Advance.Transition.Custom.Intro.File))
				.Replace("{OVERLAY_TRANSITION_INTRO_ENABLE}", list_0[P_0].Advance.Transition.Custom.Intro.Enable.ToString())
				.Replace("{OVERLAY_TRANSITION_INTRO_PATH}", Class48.smethod_39("OVERLAY_TRANSITION_INTRO_PATH", list_0[P_0].Advance.Transition.Custom.Intro.Overlay))
				.Replace("{CUSTOM_TRANSITION_INTRO_TIME}", list_0[P_0].Advance.Transition.Custom.Intro.Time.ToString())
				.Replace("{CUSTOM_TRANSITION_ENDCARD_PATH}", Class48.smethod_39("CUSTOM_TRANSITION_ENDCARD_PATH", list_0[P_0].Advance.Transition.Custom.EndCard.File))
				.Replace("{OVERLAY_TRANSITION_ENDCARD_ENABLE}", list_0[P_0].Advance.Transition.Custom.EndCard.Enable.ToString())
				.Replace("{OVERLAY_TRANSITION_ENDCARD_PATH}", Class48.smethod_39("OVERLAY_TRANSITION_ENDCARD_PATH", list_0[P_0].Advance.Transition.Custom.EndCard.Overlay))
				.Replace("{CUSTOM_TRANSITION_ENDCARD_TIME}", list_0[P_0].Advance.Transition.Custom.EndCard.Time.ToString())
				.Replace("{LOGO_ENABLE}", list_0[P_0].Advance.Logo.Enable.ToString())
				.Replace("{LOGO_PATH}", Class48.smethod_39("LOGO_PATH", list_0[P_0].Advance.Logo.File))
				.Replace("{LOGO_ALWAYS_SHOW}", list_0[P_0].Advance.Logo.AlwaysShow.ToString())
				.Replace("{LOGO_SHOW_TIME}", list_0[P_0].Advance.Logo.ShowTime.ToString())
				.Replace("{LOGO_EVERY_TIME}", list_0[P_0].Advance.Logo.ShowEvery.ToString())
				.Replace("{LOGO_FADE_COLOR}", list_0[P_0].Advance.Logo.Color)
				.Replace("{LOGO_OPACITY}", list_0[P_0].Advance.Logo.Opacity.ToString())
				.Replace("{LOGO_BLEND_MODE}", list_0[P_0].Advance.Logo.BlendMode.ToString())
				.Replace("{LOGO_ASS_ENABLE}", list_0[P_0].Advance.Logo.ASS.Enable.ToString())
				.Replace("{LOGO_ASS_PATH}", Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\l_" + P_1, Path.GetExtension(list_0[P_0].Advance.Logo.ASS.File)))
				.Replace("{LOGO_ASS_VSFILTER}", Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\l_" + P_1, Path.GetExtension(list_0[P_0].Advance.Logo.ASS.File)))
				.Replace("{HARDSUB_REMOVER}", list_0[P_0].Advance.Special.SubRemover.Status.ToString())
				.Replace("{HARDSUB_TOP}", list_0[P_0].Advance.Special.SubRemover.Top.ToString())
				.Replace("{HARDSUB_BOTTOM}", list_0[P_0].Advance.Special.SubRemover.Bottom.ToString())
				.Replace("{HARDSUB_LEFT}", list_0[P_0].Advance.Special.SubRemover.Left.ToString())
				.Replace("{HARDSUB_RIGHT}", list_0[P_0].Advance.Special.SubRemover.Right.ToString())
				.Replace("{HARDSUB_LEVEL_1}", list_0[P_0].Advance.Special.SubRemover.Level1.ToString())
				.Replace("{HARDSUB_LEVEL_2}", list_0[P_0].Advance.Special.SubRemover.Level2.ToString())
				.Replace("{FRAMERATE_NUM}", text3)
				.Replace("{FRAMERATE_DEN}", text4)
				.Replace("{COLOR_PRIMARIES}", Class48.smethod_10(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File)))
				.Replace("{FFINDEX}", Path.Combine(Class48.smethod_37(), "ffindexs", Class48.smethod_18(text5)) + ".ffindex")
				.Replace("{FFINDEX_STATUS}", lstQueue.Items[P_0].SubItems[9].Text ?? "")
				.Replace("{FRAME_RATE_MODE}", newValue)
				.Replace("{ROTATION}", newValue2)
				.Replace("{COLOR_RANGE}", newValue3);
			if (Class17.avsMsg != null)
			{
				foreach (KeyValuePair<string, JToken> item in Class17.avsMsg)
				{
					text2 = text2.Replace("{" + item.Key + "}", item.Value.ToString());
				}
			}
			Class12.smethod_1(text2);
			if (P_2 > 0)
			{
				Class5.File = Class48.smethod_37() + "\\tmp\\a_" + P_1;
				Class5.FPSNum = text3;
				Class5.FPSDen = text4;
				Class5.IsExecute = true;
			}
			File.WriteAllText(Class48.smethod_37() + "\\tmp\\a_" + P_1, $"{text}(MT={class4_0.IsMT})", Encoding.Default);
			return true;
		}
		bool_2 = false;
		return false;
	}

	private bool method_16(int P_0)
	{
		if (lstQueue.Items[P_0].SubItems[9].Text == bool.FalseString)
		{
			return true;
		}
		bool_2 = true;
		if (!Directory.Exists(Class48.smethod_37() + "\\ffindexs"))
		{
			Directory.CreateDirectory(Class48.smethod_37() + "\\ffindexs");
		}
		string text = Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File);
		if (!File.Exists(text))
		{
			Class48.smethod_23(Handle, this);
			MetroMessageBox.Show(this, "Could not find file '" + text + "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
			lstQueue.Items[P_0].SubItems[9].Text = null;
			return false;
		}
		string text2 = new FileInfo(text).Length.ToString();
		string text3 = Path.Combine(Class48.smethod_37(), "ffindexs", Class48.smethod_18(text2)) + ".ffindex";
		lstQueue.Items[P_0].SubItems[2].Text = "Indexing";
		string stringValue = string.Empty;
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			FileName = Class48.smethod_37() + "\\codecs\\filters\\FFmpeg\\ffmsindex.exe",
			Arguments = " -t -1 \"" + text + "\" \"" + text3 + "\"",
			CreateNoWindow = true,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			StandardOutputEncoding = Encoding.UTF8
		};
		Process process2 = process;
		process2.OutputDataReceived += (object obj, DataReceivedEventArgs e) =>
		{
			if (e.Data != null)
			{
				stringValue = e.Data;
			}
		};
		if (frmSplash.bool_0)
		{
			if (!File.Exists(Class48.smethod_37() + "\\codecs\\filters\\FFmpeg\\ffmsindex.exe"))
			{
				Class48.smethod_23(Handle, this);
				MetroMessageBox.Show(this, "Could not find file '" + Class48.smethod_37() + "\\codecs\\filters\\FFmpeg\\ffmsindex.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
				lstQueue.Items[P_0].SubItems[9].Text = null;
				return false;
			}
			process2.Start();
			process2.BeginOutputReadLine();
			int_0 = P_0;
		}
		else
		{
			if (!File.Exists(Class48.smethod_37() + "\\codecs\\filters\\FFmpeg\\ffmsindex.exe"))
			{
				Class48.smethod_23(Handle, this);
				MetroMessageBox.Show(this, "Could not find file '" + Class48.smethod_37() + "\\codecs\\filters\\FFmpeg\\ffmsindex.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
				lstQueue.Items[P_0].SubItems[9].Text = null;
				return false;
			}
			if (!method_2(Class48.smethod_37() + "\\codecs\\filters\\FFmpeg\\ffmsindex.exe"))
			{
				Class48.smethod_23(Handle, this);
				MetroMessageBox.Show(this, "File incorrect detected '" + Class48.smethod_37() + "\\codecs\\filters\\FFmpeg\\ffmsindex.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
				lstQueue.Items[P_0].SubItems[9].Text = null;
				return false;
			}
			process2.Start();
			process2.BeginOutputReadLine();
		}
		while (!process2.HasExited)
		{
			if (!stringValue.Contains("Error:") && !stringValue.Contains("indexing:") && stringValue.Contains("please wait"))
			{
				if (tvDetails.Nodes.Count != 0)
				{
					if (tvDetails.Nodes[0].Nodes[7].Text != stringValue.Replace("Indexing, please wait...", "Indexing : "))
					{
						tvDetails.Nodes[0].Nodes[7].Text = stringValue.Replace("Indexing, please wait...", "Indexing : ");
					}
				}
				else
				{
					method_31();
				}
			}
			process2.Refresh();
			Application.DoEvents();
		}
		process2.WaitForExit();
		process2.Close();
		lstQueue.Items[P_0].SubItems[2].Text = (bool_1 ? "Pause" : "Ready");
		if (stringValue.Contains("unsupported"))
		{
			if (tvDetails.Nodes.Count != 0)
			{
				tvDetails.Nodes[0].Nodes[7].Text = "Indexing : done";
			}
			else
			{
				method_31();
			}
			Class48.smethod_23(Handle, this);
			lstQueue.Items[P_0].SubItems[9].Text = bool.FalseString;
			return true;
		}
		if (File.Exists(text3))
		{
			if (tvDetails.Nodes.Count != 0)
			{
				tvDetails.Nodes[0].Nodes[7].Text = "Indexing : done";
			}
			else
			{
				method_31();
			}
			lstQueue.Items[P_0].SubItems[9].Text = bool.TrueString;
			return true;
		}
		if (tvDetails.Nodes.Count != 0)
		{
			tvDetails.Nodes[0].Nodes[7].Text = "Indexing : done";
		}
		else
		{
			method_31();
		}
		Class48.smethod_23(Handle, this);
		lstQueue.Items[P_0].SubItems[9].Text = bool.FalseString;
		return true;
	}

	private void method_17(int P_0, string P_1, int P_2 = 0, bool P_3 = false)
	{
		method_0(frmSplash.bool_0);
		Class50 class50 = new Class50();
		if (!Directory.Exists(Path.Combine(Class48.smethod_37(), "tmp")))
		{
			Directory.CreateDirectory(Path.Combine(Class48.smethod_37(), "tmp"));
		}
		string stringValue2 = string.Empty;
		if (P_2 == 0)
		{
			if (method_15(P_0, P_1))
			{
			}
		}
		else if (P_3)
		{
			while (!bool_7)
			{
				Application.DoEvents();
			}
			bool boolValue = true;
			string empty = string.Empty;
			empty = ((!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "K-Lite Codec Pack\\MPC-HC64\\mpc-hc64.exe"))) ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "K-Lite Codec Pack\\MPC-HC64\\mpc-hc64_nvo.exe") : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "K-Lite Codec Pack\\MPC-HC64\\mpc-hc64.exe"));
			if (!(lstQueue.Items[P_0].SubItems[7].Text == bool.FalseString))
			{
				return;
			}
			lstQueue.Items[P_0].SubItems[7].Text = bool.TrueString;
			if (!method_15(P_0, P_1, P_2))
			{
				return;
			}
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = empty,
					Arguments = "\"" + Class48.smethod_37() + "\\tmp\\a_" + P_1 + "\"",
					CreateNoWindow = true
				}
			};
			bool_7 = false;
			try
			{
				process.Start();
			}
			catch
			{
				Class12.smethod_2();
				boolValue = false;
				bool_7 = true;
				lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
				Class48.smethod_23(Handle, this);
				MetroMessageBox.Show(this, "Could not find 'Media Player Classic'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			Timer timer = new Timer
			{
				Enabled = true,
				Interval = 1
			};
			timer.Start();
			timer.Tick += delegate
			{
				if (process.HasExited)
				{
					lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
					Class12.smethod_2();
					bool_7 = true;
					timer.Stop();
				}
				else
				{
					if (boolValue && process.MainWindowTitle.Contains(P_1))
					{
						Class12.smethod_2();
						boolValue = false;
						bool_7 = true;
					}
					process.Refresh();
					Application.DoEvents();
				}
			};
		}
		else
		{
			if (!(lstQueue.Items[P_0].SubItems[7].Text == bool.FalseString))
			{
				return;
			}
			lstQueue.Items[P_0].SubItems[7].Text = bool.TrueString;
			if (!method_15(P_0, P_1, P_2))
			{
				return;
			}
			TimeSpan timeSpan = TimeSpan.FromSeconds(0.0);
			if (list_0[P_0].Intro.Enable)
			{
				timeSpan += TimeSpan.FromSeconds(Convert.ToDouble(Class48.smethod_12(list_0[P_0].Intro.File, list_0[P_0].Intro.Time.ToString())));
			}
			if (list_0[P_0].Endcard.Enable)
			{
				timeSpan += TimeSpan.FromSeconds(Convert.ToDouble(Class48.smethod_12(list_0[P_0].Endcard.File, list_0[P_0].Endcard.Time.ToString())));
			}
			timeSpan += TimeSpan.FromSeconds(Convert.ToDouble(Class48.smethod_11(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File))));
			string text = P_2 switch
			{
				5 => Class48.smethod_9(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File), true), 
				1 => (list_0[P_0].Advance.Video.Enhancer.Resize >= 3) ? Class48.smethod_9(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File), true) : lstQueue.Items[P_0].SubItems[8].Text, 
				_ => (list_0[P_0].Advance.Video.Enhancer.Resize >= 3) ? Class48.smethod_9(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File), true) : lstQueue.Items[P_0].SubItems[8].Text, 
			};
			Process process2 = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = Class48.smethod_37() + "\\codecs\\ffplay.exe",
					Arguments = "\"" + Class48.smethod_37() + "\\tmp\\a_" + P_1 + "\"" + $" {text} -window_title \"[{P_0 + 1}] | {timeSpan} | {list_0[P_0].File}\"",
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardError = true,
					StandardErrorEncoding = Encoding.UTF8
				}
			};
			process2.ErrorDataReceived += (object obj3, DataReceivedEventArgs e) =>
			{
				if (e.Data != null)
				{
					stringValue2 = e.Data;
					Match match = Regex.Match(e.Data.Replace(" ", ""), "Duration:(.*?),");
					if (match.Success)
					{
						class50.Duration = TimeSpan.Parse(match.Groups[1].Value).TotalSeconds;
						Class12.smethod_2();
					}
				}
			};
			if (frmSplash.bool_0)
			{
				if (!File.Exists(Class48.smethod_37() + "\\codecs\\ffplay.exe"))
				{
					Class12.smethod_2();
					Class48.smethod_23(Handle, this);
					MetroMessageBox.Show(this, "Could not find file '" + Class48.smethod_37() + "\\codecs\\ffplay.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
					return;
				}
				process2.Start();
				process2.BeginErrorReadLine();
			}
			else
			{
				if (!File.Exists(Class48.smethod_37() + "\\codecs\\ffplay.exe"))
				{
					Class12.smethod_2();
					Class48.smethod_23(Handle, this);
					MetroMessageBox.Show(this, "Could not find file '" + Class48.smethod_37() + "\\codecs\\ffplay.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
					return;
				}
				if (!method_2(Class48.smethod_37() + "\\codecs\\ffplay.exe"))
				{
					Class12.smethod_2();
					Class48.smethod_23(Handle, this);
					MetroMessageBox.Show(this, "File incorrect detected '" + Class48.smethod_37() + "\\codecs\\ffplay.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
					return;
				}
				process2.Start();
				process2.BeginErrorReadLine();
			}
			try
			{
				while (process2.MainWindowHandle == IntPtr.Zero)
				{
					process2.Refresh();
					Application.DoEvents();
				}
			}
			catch
			{
			}
			Timer timer2 = new Timer
			{
				Enabled = true,
				Interval = 1
			};
			timer2.Start();
			timer2.Tick += delegate
			{
				if (process2.HasExited)
				{
					lstQueue.Items[P_0].SubItems[7].Text = bool.FalseString;
					Class12.smethod_2();
					timer2.Stop();
				}
			};
		}
	}

	private void method_18(int P_0)
	{
		togSubtitle.Checked = list_0[P_0].Subtitle.Enable;
		txtSubtitle.Text = list_0[P_0].Subtitle.File;
		togIntro.Checked = list_0[P_0].Intro.Enable;
		chkIntroMusic.Checked = list_0[P_0].Intro.MusicEnable;
		txtIntro.Text = list_0[P_0].Intro.File;
		txtIntroMusic.Text = list_0[P_0].Intro.Music;
		udIntroTime.Value = list_0[P_0].Intro.Time;
		togEndCard.Checked = list_0[P_0].Endcard.Enable;
		chkEndCardMusic.Checked = list_0[P_0].Endcard.MusicEnable;
		txtEndCard.Text = list_0[P_0].Endcard.File;
		txtEndCardMusic.Text = list_0[P_0].Endcard.Music;
		udEndCardTime.Value = list_0[P_0].Endcard.Time;
		togKaraoke.Checked = list_0[P_0].Karaoke.Enable;
		txtKaraokeOP.Text = list_0[P_0].Karaoke.OP;
		chkKaraokeOP.Checked = list_0[P_0].Karaoke.OPEnable;
		txtKaraokeED.Text = list_0[P_0].Karaoke.ED;
		chkKaraokeED.Checked = list_0[P_0].Karaoke.EDEnable;
		togClipDetails.Checked = list_0[P_0].Details.Enable;
		txtClipDeailsName.Text = list_0[P_0].Details.Title;
		txtClipDeailsAuthor.Text = list_0[P_0].Details.Author;
		cboVideoEncoder.SelectedIndex = list_0[P_0].Video.Encoder;
		cboVideoPreset.SelectedIndex = list_0[P_0].Video.Preset;
		tbVideo.Value = list_0[P_0].Video.Quality;
		cboVideoResize.SelectedIndex = list_0[P_0].Advance.Video.Enhancer.Resize;
		cboVideoSmooth.SelectedIndex = list_0[P_0].Advance.Video.Enhancer.FPS60;
		tbVideoLineDarkener.Value = list_0[P_0].Advance.Video.Enhancer.LineDarkener;
		tbVideoSharpen.Value = list_0[P_0].Advance.Video.Enhancer.Sharpen;
		tbVideoWarpSharp.Value = list_0[P_0].Advance.Video.Enhancer.WarpSharp;
		cboVideoRemover.SelectedIndex = list_0[P_0].Advance.Video.Enhancer.NoiseRemover;
		tbColorBrightness.Value = list_0[P_0].Advance.Video.Color.Brightness;
		tbColorContrast.Value = list_0[P_0].Advance.Video.Color.Contrast;
		tbColorSaturation.Value = list_0[P_0].Advance.Video.Color.Saturation;
		cboColorDebanding.SelectedIndex = list_0[P_0].Advance.Video.Color.Debanding;
		cboAudioFormat.SelectedIndex = list_0[P_0].Audio.Format;
		cboAudioQuality.SelectedIndex = list_0[P_0].Audio.Quality;
		cboAudioSampleRates.SelectedIndex = list_0[P_0].Audio.SampleRates;
		if (lstQueue.SelectedItems.Count <= 1)
		{
			cboAudioTrack.Items.Clear();
			if (list_0[P_0].Audio.Track != null)
			{
				foreach (Class54 item in list_0[P_0].Audio.Track)
				{
					cboAudioTrack.Items.Add(item.Title + " | " + item.Language + " | " + item.Format + " | " + item.Channel + " | " + item.SampleRate + " | " + item.BitDepth + " | " + item.BitRate);
				}
				if (list_0[P_0].Audio.Track.Count > 0)
				{
					if (list_0[P_0].Audio.TrackId == -1)
					{
						cboAudioTrack.SelectedIndex = 0;
						list_0[P_0].Audio.TrackId = 0;
					}
					else
					{
						cboAudioTrack.SelectedIndex = list_0[P_0].Audio.TrackId;
					}
				}
			}
		}
		else
		{
			cboAudioTrack2.SelectedIndex = 0;
			cboAudioTrack.Visible = false;
		}
		tbVolumeSource.Value = list_0[P_0].Audio.Volume.Source;
		tbVolumeIntro.Value = list_0[P_0].Audio.Volume.Intro;
		tbVolumeEndCard.Value = list_0[P_0].Audio.Volume.Endcard;
		cboTransition.SelectedIndex = list_0[P_0].Advance.Transition.Status;
		togFadeIn.Checked = list_0[P_0].Advance.Transition.Fade.Intro.IN.Status;
		togFadeOut.Checked = list_0[P_0].Advance.Transition.Fade.Intro.OUT.Status;
		togSourceIn.Checked = list_0[P_0].Advance.Transition.Fade.Source.IN.Status;
		togSourceOut.Checked = list_0[P_0].Advance.Transition.Fade.Source.OUT.Status;
		togEndCardIn.Checked = list_0[P_0].Advance.Transition.Fade.EndCard.IN.Status;
		togEndCardOut.Checked = list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Status;
		pFadeInColor.BackColor = Class48.smethod_25(list_0[P_0].Advance.Transition.Fade.Intro.IN.Color);
		pFadeOutColor.BackColor = Class48.smethod_25(list_0[P_0].Advance.Transition.Fade.Intro.OUT.Color);
		pSourceInColor.BackColor = Class48.smethod_25(list_0[P_0].Advance.Transition.Fade.Source.IN.Color);
		pSourceOutColor.BackColor = Class48.smethod_25(list_0[P_0].Advance.Transition.Fade.Source.OUT.Color);
		pEndCardInColor.BackColor = Class48.smethod_25(list_0[P_0].Advance.Transition.Fade.EndCard.IN.Color);
		pEndCardOutColor.BackColor = Class48.smethod_25(list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Color);
		udIntroFadeInTime.Value = list_0[P_0].Advance.Transition.Fade.Intro.IN.Time;
		udIntroFadeOutTime.Value = list_0[P_0].Advance.Transition.Fade.Intro.OUT.Time;
		udSourceFadeInTime.Value = list_0[P_0].Advance.Transition.Fade.Source.IN.Time;
		udSourceFadeOutTime.Value = list_0[P_0].Advance.Transition.Fade.Source.OUT.Time;
		udEndCardFadeInTime.Value = list_0[P_0].Advance.Transition.Fade.EndCard.IN.Time;
		udEndCardFadeOutTime.Value = list_0[P_0].Advance.Transition.Fade.EndCard.OUT.Time;
		udDissolveTime.Value = list_0[P_0].Advance.Transition.Disslove.Time;
		udDissolveFadeInTime.Value = list_0[P_0].Advance.Transition.Disslove.FadeInTime;
		udDissolveFadeOutTime.Value = list_0[P_0].Advance.Transition.Disslove.FadeOutTime;
		txtIntroTransition.Text = list_0[P_0].Advance.Transition.Custom.Intro.File;
		chkIntroTransitionOverlay.Checked = list_0[P_0].Advance.Transition.Custom.Intro.Enable;
		txtIntroTransitionOverlay.Text = list_0[P_0].Advance.Transition.Custom.Intro.Overlay;
		udIntroTransitionAudioTime.Value = list_0[P_0].Advance.Transition.Custom.Intro.Time;
		txtEndCardTransition.Text = list_0[P_0].Advance.Transition.Custom.EndCard.File;
		chkEndCardTransitionOverlay.Checked = list_0[P_0].Advance.Transition.Custom.EndCard.Enable;
		txtEndCardTransitionOverlay.Text = list_0[P_0].Advance.Transition.Custom.EndCard.Overlay;
		udEndCardTransitionAudioTime.Value = list_0[P_0].Advance.Transition.Custom.EndCard.Time;
		togLogo.Checked = list_0[P_0].Advance.Logo.Enable;
		txtLogo.Text = list_0[P_0].Advance.Logo.File;
		togLogoTime.Checked = list_0[P_0].Advance.Logo.AlwaysShow;
		udLogoTimeSec.Value = list_0[P_0].Advance.Logo.ShowTime;
		udLogoTimeSecMinute.Value = list_0[P_0].Advance.Logo.ShowEvery;
		cboLogoBlend.Text = list_0[P_0].Advance.Logo.BlendMode;
		tbLogoOpacity.Value = list_0[P_0].Advance.Logo.Opacity;
		pLogoFadeColor.BackColor = Class48.smethod_25(list_0[P_0].Advance.Logo.Color);
		togLogoSubtitle.Checked = list_0[P_0].Advance.Logo.ASS.Enable;
		txtLogoSubtitle.Text = list_0[P_0].Advance.Logo.ASS.File;
		togHardSubRemover.Checked = list_0[P_0].Advance.Special.SubRemover.Status;
		udRemoverTop.Value = list_0[P_0].Advance.Special.SubRemover.Top;
		udRemoverBottom.Value = list_0[P_0].Advance.Special.SubRemover.Bottom;
		udRemoverLeft.Value = list_0[P_0].Advance.Special.SubRemover.Left;
		udRemoverRight.Value = list_0[P_0].Advance.Special.SubRemover.Right;
		tbRemoverLevel1.Value = list_0[P_0].Advance.Special.SubRemover.Level1;
		tbRemoverLevel2.Value = list_0[P_0].Advance.Special.SubRemover.Level2;
	}

	private void method_19()
	{
		txtOutput.Text = "C:\\";
		togSubtitle.Checked = true;
		txtSubtitle.Text = null;
		chkIntroMusic.Enabled = false;
		chkIntroMusic.Checked = false;
		txtIntro.Text = null;
		txtIntroMusic.Text = null;
		udIntroTime.Value = 1m;
		togIntro.Checked = false;
		togEndCard.Checked = false;
		chkEndCardMusic.Enabled = false;
		chkEndCardMusic.Checked = false;
		txtEndCard.Text = null;
		txtEndCardMusic.Text = null;
		udEndCardTime.Value = 1m;
		togKaraoke.Checked = false;
		txtKaraokeOP.Text = null;
		chkKaraokeOP.Enabled = false;
		chkKaraokeOP.Checked = false;
		txtKaraokeED.Text = null;
		chkKaraokeED.Enabled = false;
		chkKaraokeED.Checked = false;
		togClipDetails.Checked = false;
		txtClipDeailsName.Text = null;
		txtClipDeailsAuthor.Text = null;
		togSameInput.Checked = false;
		cboVideoEncoder.SelectedIndex = 0;
		cboVideoPreset.Text = "Slow";
		tbVideo.Value = 20;
		cboVideoResize.Text = "Original";
		cboVideoSmooth.Text = "Disable";
		tbVideoLineDarkener.Value = 0;
		tbVideoSharpen.Value = 0;
		tbVideoWarpSharp.Value = 0;
		cboVideoRemover.Text = "Disable";
		tbColorBrightness.Value = 100;
		tbColorContrast.Value = 100;
		tbColorSaturation.Value = 100;
		cboColorDebanding.Text = "Disable";
		cboAudioFormat.Text = "AAC (Advanced Audio Coding)";
		cboAudioQuality.Text = "128 Kbps Dafault";
		cboAudioSampleRates.Text = "Original";
		cboAudioTrack2.SelectedIndex = 0;
		tbVolumeSource.Value = 100;
		tbVolumeIntro.Value = 100;
		tbVolumeEndCard.Value = 100;
		cboTransition.Text = "Fade";
		togFadeIn.Checked = true;
		togFadeOut.Checked = true;
		togSourceIn.Checked = true;
		togSourceOut.Checked = true;
		togEndCardIn.Checked = true;
		togEndCardOut.Checked = true;
		pFadeInColor.BackColor = Color.Black;
		pFadeOutColor.BackColor = Color.Black;
		pSourceInColor.BackColor = Color.Black;
		pSourceOutColor.BackColor = Color.Black;
		pEndCardInColor.BackColor = Color.Black;
		pEndCardOutColor.BackColor = Color.Black;
		udIntroFadeInTime.Value = 1m;
		udIntroFadeOutTime.Value = 1m;
		udSourceFadeInTime.Value = 1m;
		udSourceFadeOutTime.Value = 1m;
		udEndCardFadeInTime.Value = 1m;
		udEndCardFadeOutTime.Value = 1m;
		udDissolveTime.Value = 1m;
		udDissolveFadeInTime.Value = 1m;
		udDissolveFadeOutTime.Value = 1m;
		txtIntroTransition.Text = null;
		chkIntroTransitionOverlay.Checked = false;
		txtIntroTransitionOverlay.Text = null;
		udIntroTransitionAudioTime.Value = 1m;
		txtEndCardTransition.Text = null;
		chkEndCardTransitionOverlay.Checked = false;
		txtEndCardTransitionOverlay.Text = null;
		udEndCardTransitionAudioTime.Value = 1m;
		togLogo.Checked = false;
		txtLogo.Text = null;
		togLogoTime.Checked = false;
		udLogoTimeSec.Value = 15m;
		udLogoTimeSecMinute.Value = 7m;
		cboLogoBlend.Text = "Blend";
		tbLogoOpacity.Value = 100;
		pLogoFadeColor.BackColor = Color.Black;
		togLogoSubtitle.Checked = false;
		txtLogoSubtitle.Text = null;
		togHardSubRemover.Checked = false;
		udRemoverTop.Value = 2m;
		udRemoverBottom.Value = 2m;
		udRemoverLeft.Value = 2m;
		udRemoverRight.Value = 2m;
		tbRemoverLevel1.Value = 256;
		tbRemoverLevel2.Value = 50;
	}

	private void method_20()
	{
		Class48.smethod_2(picSaved, "Saved");
	}

	private void method_21()
	{
		try
		{
			class4_0 = JsonConvert.DeserializeObject<Class4>(File.ReadAllText(Class48.smethod_37() + "\\configs.json"));
		}
		catch
		{
		}
		togOntop.Checked = class4_0.IsTopMost;
	}

	private void method_22()
	{
		try
		{
			class52_0 = JsonConvert.DeserializeObject<Class52>(File.ReadAllText(Class48.smethod_37() + "\\recent.json"));
			txtOutput.Text = class52_0.Output;
			togSubtitle.Checked = class52_0.Subtitle.Enable;
			txtSubtitle.Text = class52_0.Subtitle.File;
			togIntro.Checked = class52_0.Intro.Enable;
			chkIntroMusic.Checked = class52_0.Intro.MusicEnable;
			txtIntro.Text = class52_0.Intro.File;
			txtIntroMusic.Text = class52_0.Intro.Music;
			udIntroTime.Value = class52_0.Intro.Time;
			togEndCard.Checked = class52_0.Endcard.Enable;
			chkEndCardMusic.Checked = class52_0.Endcard.MusicEnable;
			txtEndCard.Text = class52_0.Endcard.File;
			txtEndCardMusic.Text = class52_0.Endcard.Music;
			udEndCardTime.Value = class52_0.Endcard.Time;
			togKaraoke.Checked = class52_0.Karaoke.Enable;
			txtKaraokeOP.Text = class52_0.Karaoke.OP;
			chkKaraokeOP.Checked = class52_0.Karaoke.OPEnable;
			txtKaraokeED.Text = class52_0.Karaoke.ED;
			chkKaraokeED.Checked = class52_0.Karaoke.EDEnable;
			togClipDetails.Checked = class52_0.Details.Enable;
			txtClipDeailsName.Text = class52_0.Details.Title;
			txtClipDeailsAuthor.Text = class52_0.Details.Author;
			togSameInput.Checked = class52_0.IsOutput;
			cboVideoEncoder.SelectedIndex = class52_0.Video.Encoder;
			cboVideoPreset.SelectedIndex = class52_0.Video.Preset;
			tbVideo.Value = class52_0.Video.Quality;
			cboVideoResize.SelectedIndex = class52_0.Advance.Video.Enhancer.Resize;
			cboVideoSmooth.SelectedIndex = class52_0.Advance.Video.Enhancer.FPS60;
			tbVideoLineDarkener.Value = class52_0.Advance.Video.Enhancer.LineDarkener;
			tbVideoSharpen.Value = class52_0.Advance.Video.Enhancer.Sharpen;
			tbVideoWarpSharp.Value = class52_0.Advance.Video.Enhancer.WarpSharp;
			cboVideoRemover.SelectedIndex = class52_0.Advance.Video.Enhancer.NoiseRemover;
			tbColorBrightness.Value = class52_0.Advance.Video.Color.Brightness;
			tbColorContrast.Value = class52_0.Advance.Video.Color.Contrast;
			tbColorSaturation.Value = class52_0.Advance.Video.Color.Saturation;
			cboColorDebanding.SelectedIndex = class52_0.Advance.Video.Color.Debanding;
			cboAudioFormat.SelectedIndex = class52_0.Audio.Format;
			cboAudioQuality.SelectedIndex = class52_0.Audio.Quality;
			cboAudioSampleRates.SelectedIndex = class52_0.Audio.SampleRates;
			tbVolumeSource.Value = class52_0.Audio.Volume.Source;
			tbVolumeIntro.Value = class52_0.Audio.Volume.Intro;
			tbVolumeEndCard.Value = class52_0.Audio.Volume.Endcard;
			togPreview.Checked = class52_0.IsPreview;
			Width = class52_0.Width;
			Height = class52_0.Height;
			cboTransition.SelectedIndex = class52_0.Advance.Transition.Status;
			togFadeIn.Checked = class52_0.Advance.Transition.Fade.Intro.IN.Status;
			togFadeOut.Checked = class52_0.Advance.Transition.Fade.Intro.OUT.Status;
			togSourceIn.Checked = class52_0.Advance.Transition.Fade.Source.IN.Status;
			togSourceOut.Checked = class52_0.Advance.Transition.Fade.Source.OUT.Status;
			togEndCardIn.Checked = class52_0.Advance.Transition.Fade.EndCard.IN.Status;
			togEndCardOut.Checked = class52_0.Advance.Transition.Fade.EndCard.OUT.Status;
			pFadeInColor.BackColor = Class48.smethod_25(class52_0.Advance.Transition.Fade.Intro.IN.Color);
			pFadeOutColor.BackColor = Class48.smethod_25(class52_0.Advance.Transition.Fade.Intro.OUT.Color);
			pSourceInColor.BackColor = Class48.smethod_25(class52_0.Advance.Transition.Fade.Source.IN.Color);
			pSourceOutColor.BackColor = Class48.smethod_25(class52_0.Advance.Transition.Fade.Source.OUT.Color);
			pEndCardInColor.BackColor = Class48.smethod_25(class52_0.Advance.Transition.Fade.EndCard.IN.Color);
			pEndCardOutColor.BackColor = Class48.smethod_25(class52_0.Advance.Transition.Fade.EndCard.OUT.Color);
			udIntroFadeInTime.Value = class52_0.Advance.Transition.Fade.Intro.IN.Time;
			udIntroFadeOutTime.Value = class52_0.Advance.Transition.Fade.Intro.OUT.Time;
			udSourceFadeInTime.Value = class52_0.Advance.Transition.Fade.Source.IN.Time;
			udSourceFadeOutTime.Value = class52_0.Advance.Transition.Fade.Source.OUT.Time;
			udEndCardFadeInTime.Value = class52_0.Advance.Transition.Fade.EndCard.IN.Time;
			udEndCardFadeOutTime.Value = class52_0.Advance.Transition.Fade.EndCard.OUT.Time;
			udDissolveTime.Value = class52_0.Advance.Transition.Disslove.Time;
			udDissolveFadeInTime.Value = class52_0.Advance.Transition.Disslove.FadeInTime;
			udDissolveFadeOutTime.Value = class52_0.Advance.Transition.Disslove.FadeOutTime;
			txtIntroTransition.Text = class52_0.Advance.Transition.Custom.Intro.File;
			chkIntroTransitionOverlay.Checked = class52_0.Advance.Transition.Custom.Intro.Enable;
			txtIntroTransitionOverlay.Text = class52_0.Advance.Transition.Custom.Intro.Overlay;
			udIntroTransitionAudioTime.Value = class52_0.Advance.Transition.Custom.Intro.Time;
			txtEndCardTransition.Text = class52_0.Advance.Transition.Custom.EndCard.File;
			chkEndCardTransitionOverlay.Checked = class52_0.Advance.Transition.Custom.EndCard.Enable;
			txtEndCardTransitionOverlay.Text = class52_0.Advance.Transition.Custom.EndCard.Overlay;
			udEndCardTransitionAudioTime.Value = class52_0.Advance.Transition.Custom.EndCard.Time;
			togLogo.Checked = class52_0.Advance.Logo.Enable;
			txtLogo.Text = class52_0.Advance.Logo.File;
			togLogoTime.Checked = class52_0.Advance.Logo.AlwaysShow;
			udLogoTimeSec.Value = class52_0.Advance.Logo.ShowTime;
			udLogoTimeSecMinute.Value = class52_0.Advance.Logo.ShowEvery;
			cboLogoBlend.Text = class52_0.Advance.Logo.BlendMode;
			tbLogoOpacity.Value = class52_0.Advance.Logo.Opacity;
			pLogoFadeColor.BackColor = Class48.smethod_25(class52_0.Advance.Logo.Color);
			togLogoSubtitle.Checked = class52_0.Advance.Logo.ASS.Enable;
			txtLogoSubtitle.Text = class52_0.Advance.Logo.ASS.File;
			togHardSubRemover.Checked = class52_0.Advance.Special.SubRemover.Status;
			udRemoverTop.Value = class52_0.Advance.Special.SubRemover.Top;
			udRemoverBottom.Value = class52_0.Advance.Special.SubRemover.Bottom;
			udRemoverLeft.Value = class52_0.Advance.Special.SubRemover.Left;
			udRemoverRight.Value = class52_0.Advance.Special.SubRemover.Right;
			tbRemoverLevel1.Value = class52_0.Advance.Special.SubRemover.Level1;
			tbRemoverLevel2.Value = class52_0.Advance.Special.SubRemover.Level2;
		}
		catch
		{
			method_19();
		}
		bool_0 = true;
	}

	private void method_23()
	{
		class52_0 = new Class52
		{
			Output = txtOutput.Text,
			Video = new Class55
			{
				Encoder = cboVideoEncoder.SelectedIndex,
				Preset = cboVideoPreset.SelectedIndex,
				Quality = tbVideo.Value
			},
			Subtitle = new Class51
			{
				Enable = togSubtitle.Checked,
				File = txtSubtitle.Text
			},
			Intro = new Class45
			{
				Enable = togIntro.Checked,
				MusicEnable = chkIntroMusic.Checked,
				File = txtIntro.Text,
				Music = txtIntroMusic.Text,
				Time = udIntroTime.Value
			},
			Endcard = new Class44
			{
				Enable = togEndCard.Checked,
				MusicEnable = chkEndCardMusic.Checked,
				File = txtEndCard.Text,
				Music = txtEndCardMusic.Text,
				Time = udEndCardTime.Value
			},
			Karaoke = new Class46
			{
				Enable = togKaraoke.Checked,
				OPEnable = chkKaraokeOP.Checked,
				EDEnable = chkKaraokeED.Checked,
				OP = txtKaraokeOP.Text,
				ED = txtKaraokeED.Text
			},
			Audio = new Class41
			{
				Format = cboAudioFormat.SelectedIndex,
				Quality = cboAudioQuality.SelectedIndex,
				SampleRates = cboAudioSampleRates.SelectedIndex,
				Volume = new Class42
				{
					Intro = tbVolumeIntro.Value,
					Source = tbVolumeSource.Value,
					Endcard = tbVolumeEndCard.Value
				}
			},
			Details = new Class43
			{
				Enable = togClipDetails.Checked,
				Title = txtClipDeailsName.Text,
				Author = txtClipDeailsAuthor.Text
			},
			Advance = new Class26
			{
				Video = new Class38
				{
					Enhancer = new Class39
					{
						Resize = cboVideoResize.SelectedIndex,
						FPS60 = cboVideoSmooth.SelectedIndex,
						LineDarkener = tbVideoLineDarkener.Value,
						Sharpen = tbVideoSharpen.Value,
						WarpSharp = tbVideoWarpSharp.Value,
						NoiseRemover = cboVideoRemover.SelectedIndex
					},
					Color = new Class40
					{
						Brightness = tbColorBrightness.Value,
						Contrast = tbColorContrast.Value,
						Saturation = tbColorSaturation.Value,
						Debanding = cboColorDebanding.SelectedIndex
					}
				},
				Transition = new Class53
				{
					Status = cboTransition.SelectedIndex,
					Fade = new Class37
					{
						Intro = new Class32
						{
							IN = new Class31
							{
								Status = togFadeIn.Checked,
								Time = udIntroFadeInTime.Value,
								Color = Class48.smethod_26(pFadeInColor)
							},
							OUT = new Class33
							{
								Status = togFadeOut.Checked,
								Time = udIntroFadeOutTime.Value,
								Color = Class48.smethod_26(pFadeOutColor)
							}
						},
						Source = new Class29
						{
							IN = new Class28
							{
								Status = togSourceIn.Checked,
								Time = udSourceFadeInTime.Value,
								Color = Class48.smethod_26(pSourceInColor)
							},
							OUT = new Class30
							{
								Status = togSourceOut.Checked,
								Time = udSourceFadeOutTime.Value,
								Color = Class48.smethod_26(pSourceOutColor)
							}
						},
						EndCard = new Class35
						{
							IN = new Class34
							{
								Status = togEndCardIn.Checked,
								Time = udEndCardFadeInTime.Value,
								Color = Class48.smethod_26(pEndCardInColor)
							},
							OUT = new Class36
							{
								Status = togEndCardOut.Checked,
								Time = udEndCardFadeOutTime.Value,
								Color = Class48.smethod_26(pEndCardOutColor)
							}
						}
					},
					Disslove = new Class27
					{
						Time = udDissolveTime.Value,
						FadeInTime = udDissolveFadeInTime.Value,
						FadeOutTime = udDissolveFadeOutTime.Value
					},
					Custom = new Class25
					{
						Intro = new Class24
						{
							Enable = chkIntroTransitionOverlay.Checked,
							File = txtIntroTransition.Text,
							Overlay = txtIntroTransitionOverlay.Text,
							Time = udIntroTransitionAudioTime.Value
						},
						EndCard = new Class23
						{
							Enable = chkEndCardTransitionOverlay.Checked,
							File = txtEndCardTransition.Text,
							Overlay = txtEndCardTransitionOverlay.Text,
							Time = udEndCardTransitionAudioTime.Value
						}
					}
				},
				Logo = new Class20
				{
					Enable = togLogo.Checked,
					File = txtLogo.Text,
					AlwaysShow = togLogoTime.Checked,
					ShowTime = udLogoTimeSec.Value,
					ShowEvery = udLogoTimeSecMinute.Value,
					Color = Class48.smethod_26(pLogoFadeColor),
					Opacity = tbLogoOpacity.Value,
					BlendMode = cboLogoBlend.Text,
					ASS = new Class19
					{
						Enable = togLogoSubtitle.Checked,
						File = txtLogoSubtitle.Text
					}
				},
				Special = new Class21
				{
					SubRemover = new Class22
					{
						Status = togHardSubRemover.Checked,
						Top = udRemoverTop.Value,
						Bottom = udRemoverBottom.Value,
						Left = udRemoverLeft.Value,
						Right = udRemoverRight.Value,
						Level1 = tbRemoverLevel1.Value,
						Level2 = tbRemoverLevel2.Value
					}
				}
			},
			IsOutput = togSameInput.Checked,
			IsPreview = togPreview.Checked,
			Width = Width,
			Height = Height
		};
		string contents = JsonConvert.SerializeObject(class52_0, Formatting.Indented);
		File.WriteAllText(Class48.smethod_37() + "\\recent.json", contents);
	}

	private void method_24()
	{
		tpMain.AutoScroll = true;
		tpVideo.AutoScroll = true;
		tpAudio.AutoScroll = true;
		tpTransition.AutoScroll = true;
		tpLogo.AutoScroll = true;
		tpLog.AutoScroll = true;
		tpSpecial.AutoScroll = true;
	}

	private void method_25(int P_0, string P_1, string P_2)
	{
		int intValue2 = 0;
		bool boolValue = true;
		bool boolValue2 = true;
		string stringValue2 = string.Empty;
		string stringValue3 = string.Empty;
		TimeSpan timeSpan = TimeSpan.FromSeconds(0.0);
		DateTime dateTime = DateTime.Now;
		Class50 class50 = new Class50();
		IntPtr intPtr = new IntPtr(0);
		string text = (class4_0.IsSDL2 ? "-f sdl2 \"PREVIEW PLUS\"" : null);
		Match match = Regex.Match(P_1, "tmp\\\\a_(.*?)\\.avs");
		string text2 = ((!match.Success) ? string.Empty : match.Groups[1].Value);
		string stringValue4 = Class48.smethod_39("SOURCE_PATH", Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File));
		string stringValue6 = Class48.smethod_39("INTRO_PATH", list_0[P_0].Intro.File);
		string stringValue8 = Class48.smethod_39("INTRO_MUSIC", list_0[P_0].Intro.Music);
		string stringValue10 = Class48.smethod_39("ENDCARD_PATH", list_0[P_0].Endcard.File);
		string stringValue12 = Class48.smethod_39("ENDCARD_MUSIC", list_0[P_0].Endcard.Music);
		string stringValue14 = Class48.smethod_39("CUSTOM_TRANSITION_INTRO_PATH", list_0[P_0].Advance.Transition.Custom.Intro.File);
		string stringValue16 = Class48.smethod_39("OVERLAY_TRANSITION_INTRO_PATH", list_0[P_0].Advance.Transition.Custom.Intro.Overlay);
		string stringValue18 = Class48.smethod_39("CUSTOM_TRANSITION_ENDCARD_PATH", list_0[P_0].Advance.Transition.Custom.EndCard.File);
		string stringValue20 = Class48.smethod_39("OVERLAY_TRANSITION_ENDCARD_PATH", list_0[P_0].Advance.Transition.Custom.EndCard.Overlay);
		string stringValue22 = Class48.smethod_39("LOGO_PATH", list_0[P_0].Advance.Logo.File);
		string stringValue24 = Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\s_" + text2, Path.GetExtension(list_0[P_0].Subtitle.File));
		string stringValue26 = Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\o_" + text2, Path.GetExtension(list_0[P_0].Karaoke.OP));
		string stringValue28 = Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\e_" + text2, Path.GetExtension(list_0[P_0].Karaoke.ED));
		string stringValue30 = Path.ChangeExtension(Class48.smethod_37() + "\\tmp\\l_" + text2, Path.GetExtension(list_0[P_0].Advance.Logo.ASS.File));
		string stringValue31 = list_0[P_0].Subtitle.File;
		string stringValue32 = list_0[P_0].Karaoke.OP;
		string stringValue33 = list_0[P_0].Karaoke.ED;
		string stringValue34 = list_0[P_0].Advance.Logo.ASS.File;
		string stringValue35 = Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File);
		string stringValue36 = list_0[P_0].Intro.File;
		string stringValue37 = list_0[P_0].Intro.Music;
		string stringValue38 = list_0[P_0].Endcard.File;
		string stringValue39 = list_0[P_0].Endcard.Music;
		string stringValue40 = list_0[P_0].Advance.Transition.Custom.Intro.File;
		string stringValue41 = list_0[P_0].Advance.Transition.Custom.Intro.Overlay;
		string stringValue42 = list_0[P_0].Advance.Transition.Custom.EndCard.File;
		string stringValue43 = list_0[P_0].Advance.Transition.Custom.EndCard.Overlay;
		string stringValue44 = list_0[P_0].Advance.Logo.File;
		Invoke((MethodInvoker)(() =>
		{
			txtLog.Clear();
			try
			{
				txtLog.AppendText("File=" + Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File) + "\r\n" + Regex.Split(P_1, "-metadata comment=\"")[1].Replace(" / ", "\r\n").Split('"')[0] + "\r\n");
			}
			catch
			{
			}
		}));
		process_0 = new Process
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = Class48.smethod_37() + "\\codecs\\ffmpeg.exe",
				Arguments = P_1 + "\"" + P_2 + "\" " + text,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardError = true,
				StandardErrorEncoding = Encoding.UTF8
			}
		};
		process_0.ErrorDataReceived += (object obj3, DataReceivedEventArgs e) =>
		{
			if (e.Data != null)
			{
				if (InvokeRequired)
				{
					Invoke((MethodInvoker)(() =>
					{
						togPreview.Enabled = true;
					}));
				}
				if (boolValue && Class48.smethod_20() != (IntPtr)0)
				{
					Class48.smethod_22(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File), this);
					Class48.smethod_22(Path.Combine(list_0[P_0].Fullpath, list_0[P_0].File), this);
					boolValue = false;
				}
				stringValue2 = e.Data;
				stringValue3 += e.Data;
				Match match2 = Regex.Match(e.Data.Replace(" ", ""), "Duration:(.*?),");
				Match match3 = Regex.Match(e.Data.Replace(" ", ""), "frame=(.*?)f");
				Match match4 = Regex.Match(e.Data.Replace(" ", ""), "fps=(.*?)q");
				Match match5 = Regex.Match(e.Data.Replace(" ", ""), "size=(.*?)k");
				Match match6 = Regex.Match(e.Data.Replace(" ", ""), "time=(.*?)b");
				Match match7 = Regex.Match(e.Data.Replace(" ", ""), "bitrate=(.*?)k");
				Match match8 = Regex.Match(e.Data.Replace(" ", ""), "speed=(.*?)x");
				if (match2.Success)
				{
					class50.Duration = TimeSpan.Parse(match2.Groups[1].Value).TotalSeconds;
					Class12.smethod_2();
				}
				if (match3.Success)
				{
					if (intPtr == new IntPtr(0))
					{
						intPtr = Class48.FindWindow("SDL_app", "PREVIEW PLUS");
					}
					class50.Fps = match4.Groups[1].Value;
					class50.Time = TimeSpan.Parse(match6.Groups[1].Value).TotalSeconds;
					class50.Size = match5.Groups[1].Value;
					class50.Speed = match8.Groups[1].Value;
					class50.Percent = class50.Time / class50.Duration * 100.0;
					try
					{
						timeSpan = TimeSpan.FromTicks(DateTime.Now.Subtract(dateTime).Ticks * ((long)class50.Duration - (long)class50.Time) / (long)class50.Time);
					}
					catch
					{
					}
					class50.TimeRemaining = timeSpan.TotalSeconds;
					if (InvokeRequired)
					{
						Invoke((MethodInvoker)(() =>
						{
							if (class50.TimeRemaining <= 1.0)
							{
								lstQueue.Items[P_0].SubItems[2].Text = "100%";
							}
							else
							{
								if (TaskbarManager.IsPlatformSupported)
								{
									TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
								}
								Class48.smethod_24(intPtr, list_0[P_0].File + " | " + TimeSpan.FromTicks(DateTime.Now.Subtract(dateTime).Ticks).ToString("hh\\:mm\\:ss") + " | " + timeSpan.ToString("hh\\:mm\\:ss") + " | " + class50.Fps + " fps | " + class50.Speed + "x | " + ByteSize.FromKiloBytes(long.Parse(class50.Size)).ToString() + " | " + class50.Percent.ToString("f2") + "%");
								if (tvDetails.Nodes.Count != 0)
								{
									tvDetails.Nodes[0].Nodes[0].Text = "Time Elapsed : " + TimeSpan.FromTicks(DateTime.Now.Subtract(dateTime).Ticks).ToString("hh\\:mm\\:ss");
									tvDetails.Nodes[0].Nodes[1].Text = "Remaining Time : " + timeSpan.ToString("hh\\:mm\\:ss");
									tvDetails.Nodes[0].Nodes[2].Text = "Status : " + class50.Percent.ToString("f2") + "%";
									tvDetails.Nodes[0].Nodes[3].Text = "FPS : " + class50.Fps + " fps";
									tvDetails.Nodes[0].Nodes[4].Text = "Speed : " + class50.Speed + "x";
									tvDetails.Nodes[0].Nodes[6].Text = "Output Size : " + ByteSize.FromKiloBytes(long.Parse(class50.Size)).ToString();
								}
								else
								{
									method_31();
								}
								psProgress.Value = (int)class50.Percent;
								lstQueue.Items[P_0].SubItems[2].Text = class50.Percent.ToString("f2") + "%";
								intValue2 = (int)class50.Percent;
								backgroundWorker_0.ReportProgress((int)class50.Percent);
							}
							lstQueue.Items[P_0].SubItems[3].Text = class50.Fps;
							lstQueue.Items[P_0].SubItems[4].Text = class50.Speed + "x";
						}));
					}
				}
				else if (InvokeRequired)
				{
					Invoke((MethodInvoker)(() =>
					{
						if (Class12.AvsiPath != null && e.Data.Contains(Class12.AvsiPath))
						{
							txtLog.SelectionColor = Color.Red;
							txtLog.smethod_15(e.Data.Replace("(" + Class12.AvsiPath + ", line ", boolValue2 ? "Error code : " : "").Replace(")", " "), Color.Red, true);
							boolValue2 = false;
						}
						else
						{
							Match match9 = Regex.Match(e.Data, "\\*H\\*(.*?)\\*H\\*");
							if (match9.Success)
							{
								txtLog.smethod_15(match9.Groups[1].Value.Replace("*H*", string.Empty) + Environment.NewLine, Color.White, true);
							}
							else
							{
								txtLog.smethod_15(e.Data.Replace(stringValue4, stringValue35).Replace(stringValue6, stringValue36).Replace(stringValue8, stringValue37)
									.Replace(stringValue10, stringValue38)
									.Replace(stringValue12, stringValue39)
									.Replace(stringValue14, stringValue40)
									.Replace(stringValue16, stringValue41)
									.Replace(stringValue18, stringValue42)
									.Replace(stringValue20, stringValue43)
									.Replace(stringValue22, stringValue44)
									.Replace(stringValue24, stringValue31)
									.Replace(stringValue26, stringValue32)
									.Replace(stringValue28, stringValue33)
									.Replace(stringValue30, stringValue34), Color.Black, false, true);
							}
						}
					}));
				}
			}
		};
		if (frmSplash.bool_0)
		{
			process_0.Start();
			process_0.BeginErrorReadLine();
			process_0.WaitForExit();
			Class12.smethod_2();
		}
		else
		{
			if (!method_2(Class48.smethod_37() + "\\codecs\\ffmpeg.exe"))
			{
				Class12.smethod_2();
				Class48.smethod_23(Handle, this);
				MetroMessageBox.Show(this, "File incorrect detected '" + Class48.smethod_37() + "\\codecs\\ffmpeg.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				psProgress.Visible = false;
				return;
			}
			process_0.Start();
			process_0.BeginErrorReadLine();
			process_0.WaitForExit();
			Class12.smethod_2();
		}
		method_27(tcQueue.TabCount);
		if (!Directory.Exists(Path.Combine(Class48.smethod_37(), "tmp")))
		{
			Directory.CreateDirectory(Path.Combine(Class48.smethod_37(), "tmp"));
		}
		try
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() =>
				{
					File.WriteAllText(Class48.LogPath, txtLog.Text.Replace("\n", "\r\n"), Encoding.UTF8);
				}));
			}
		}
		catch
		{
		}
		if (stringValue2.Contains("Qavg") || stringValue2.Contains("muxing"))
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() =>
				{
					string empty = string.Empty;
					string text3 = (class4_0.IsCRC32 ? (" [" + Crc32.smethod_6(P_2) + "]") : null);
					string text4 = DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
					string text5 = ((list_0[P_0].Audio.Format == 0) ? ".mp4" : ".mkv");
					if (lstQueue.Items[P_0].SubItems[6].Text != "")
					{
						if (Path.GetExtension(lstQueue.Items[P_0].SubItems[6].Text).ToLower() != string.Empty)
						{
							string text6 = Path.Combine(Path.GetDirectoryName(lstQueue.Items[P_0].SubItems[6].Text), Path.GetFileNameWithoutExtension(lstQueue.Items[P_0].SubItems[6].Text) + text3 + text5);
							if (!Directory.Exists(Path.GetDirectoryName(text6)))
							{
								Directory.CreateDirectory(Path.GetDirectoryName(text6));
							}
							empty = text6;
						}
						else
						{
							if (!Directory.Exists(lstQueue.Items[P_0].SubItems[6].Text))
							{
								Directory.CreateDirectory(lstQueue.Items[P_0].SubItems[6].Text);
							}
							empty = Path.Combine(lstQueue.Items[P_0].SubItems[6].Text, Path.GetFileNameWithoutExtension(list_0[P_0].File) + $"{text3}_{P_0 + 1}_{text4}{text5}");
						}
					}
					else if (togSameInput.Checked)
					{
						if (!Directory.Exists(list_0[P_0].Fullpath))
						{
							Directory.CreateDirectory(list_0[P_0].Fullpath);
						}
						empty = Path.Combine(list_0[P_0].Fullpath, Path.GetFileNameWithoutExtension(list_0[P_0].File) + $"{text3}_{P_0 + 1}_{text4}{text5}");
					}
					else
					{
						if (!Directory.Exists(txtOutput.Text))
						{
							Directory.CreateDirectory(txtOutput.Text);
						}
						empty = Path.Combine(txtOutput.Text, Path.GetFileNameWithoutExtension(list_0[P_0].File) + $"{text3}_{P_0 + 1}_{text4}{text5}");
					}
					File.Copy(P_2, empty, overwrite: true);
					if (TaskbarManager.IsPlatformSupported)
					{
						TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
					}
					lstQueue.Items[P_0].SubItems[2].Text = "Done";
					lstQueue.Items[P_0].Checked = false;
					method_11();
					backgroundWorker_0.ReportProgress(100);
					Notification.FilePath = empty;
					Class12.smethod_2();
					if (list_0[P_0].Subtitle.Enable)
					{
						Class10.smethod_4(list_0[P_0].Subtitle.File);
					}
					new Notification(Path.GetFileName(empty), "Your encode have been completed.", 10, Enum13.Value1, Class1.Enum5.Value2, Class1.Enum6.Value3, true).method_1();
				}));
			}
		}
		else if (stringValue2.Contains("Conversion failed!"))
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() =>
				{
					lstQueue.Items[P_0].SubItems[2].Text = "Error";
					backgroundWorker_0.ReportProgress(100);
					if (TaskbarManager.IsPlatformSupported)
					{
						TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
					}
					if (stringValue3.Contains("Unsupported pixel format 'yuv420p10le'"))
					{
						Class12.smethod_2();
						new Notification(list_0[P_0].File, "Preview while encoding unsupported 10bit.", 10, Enum13.Value3, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
					}
					else
					{
						Class12.smethod_2();
						new Notification(list_0[P_0].File, "Conversion failed!", 10, Enum13.Value3, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
					}
				}));
			}
		}
		else if (stringValue2.Contains("Unknown error occurred"))
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() =>
				{
					lstQueue.Items[P_0].SubItems[2].Text = "Error";
					backgroundWorker_0.ReportProgress(100);
					if (TaskbarManager.IsPlatformSupported)
					{
						TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
					}
					Class12.smethod_2();
					new Notification(list_0[P_0].File, "Unknown error occurred", 10, Enum13.Value3, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
				}));
			}
		}
		else if (stringValue3.Contains("Weighted P-Frames"))
		{
			if (InvokeRequired)
			{
				Invoke((MethodInvoker)(() =>
				{
					string empty = string.Empty;
					string text3 = (class4_0.IsCRC32 ? (" [" + Crc32.smethod_6(P_2) + "]") : null);
					string text4 = DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
					string text5 = ((list_0[P_0].Audio.Format == 0) ? ".mp4" : ".mkv");
					if (lstQueue.Items[P_0].SubItems[6].Text != "")
					{
						if (Path.GetExtension(lstQueue.Items[P_0].SubItems[6].Text).ToLower() != string.Empty)
						{
							string text6 = Path.Combine(Path.GetDirectoryName(lstQueue.Items[P_0].SubItems[6].Text), Path.GetFileNameWithoutExtension(lstQueue.Items[P_0].SubItems[6].Text) + text3 + text5);
							if (!Directory.Exists(Path.GetDirectoryName(text6)))
							{
								Directory.CreateDirectory(Path.GetDirectoryName(text6));
							}
							empty = text6;
						}
						else
						{
							if (!Directory.Exists(lstQueue.Items[P_0].SubItems[6].Text))
							{
								Directory.CreateDirectory(lstQueue.Items[P_0].SubItems[6].Text);
							}
							empty = Path.Combine(lstQueue.Items[P_0].SubItems[6].Text, Path.GetFileNameWithoutExtension(list_0[P_0].File) + $"{text3}_{P_0 + 1}_{text4}{text5}");
						}
					}
					else if (togSameInput.Checked)
					{
						if (!Directory.Exists(list_0[P_0].Fullpath))
						{
							Directory.CreateDirectory(list_0[P_0].Fullpath);
						}
						empty = Path.Combine(list_0[P_0].Fullpath, Path.GetFileNameWithoutExtension(list_0[P_0].File) + $"{text3}_{P_0 + 1}_{text4}{text5}");
					}
					else
					{
						if (!Directory.Exists(txtOutput.Text))
						{
							Directory.CreateDirectory(txtOutput.Text);
						}
						empty = Path.Combine(txtOutput.Text, Path.GetFileNameWithoutExtension(list_0[P_0].File) + $"{text3}_{P_0 + 1}_{text4}{text5}");
					}
					File.Copy(P_2, empty, overwrite: true);
					if (TaskbarManager.IsPlatformSupported)
					{
						TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
					}
					lstQueue.Items[P_0].SubItems[2].Text = "Done";
					lstQueue.Items[P_0].Checked = false;
					method_11();
					backgroundWorker_0.ReportProgress(100);
					Notification.FilePath = empty;
					Class12.smethod_2();
					if (list_0[P_0].Subtitle.Enable)
					{
						Class10.smethod_4(list_0[P_0].Subtitle.File);
					}
					new Notification(Path.GetFileName(empty), "Your encode have been completed.", 10, Enum13.Value1, Class1.Enum5.Value2, Class1.Enum6.Value3, true).method_1();
				}));
			}
		}
		else if (InvokeRequired)
		{
			Invoke((MethodInvoker)(() =>
			{
				backgroundWorker_0.ReportProgress(0);
				lstQueue.Items[P_0].SubItems[2].Text = "Skip";
				if (TaskbarManager.IsPlatformSupported)
				{
					TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
				}
				Class12.smethod_2();
				new Notification(list_0[P_0].File, "Skip", 10, Enum13.Value3, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
			}));
		}
		bool_10 = true;
	}

	private void method_26(string P_0)
	{
		Class17.smethod_0(tsmiLanguage, tsmiTrayLanguage, P_0);
		Control control = this;
		Dictionary<string, string> dictionary = Class17.class17_0.frmMain;
		do
		{
			control = GetNextControl(control, forward: true);
			if (control != null && control.Name != string.Empty)
			{
				if (dictionary.ContainsKey(control.Name))
				{
					Class48.smethod_2(control, dictionary[control.Name]);
				}
				if (control is MetroTextBox && dictionary.ContainsKey(control.Name))
				{
					((MetroTextBox)control).WaterMark = dictionary[control.Name];
				}
			}
		}
		while (control != null);
	}

	private void method_27(int P_0)
	{
		Invoke((MethodInvoker)(() =>
		{
			tcQueue.SelectedIndex = P_0 - 1;
		}));
	}

	private void method_28()
	{
		int intValue = 0;
		Timer timer = new Timer
		{
			Enabled = false,
			Interval = 250
		};
		timer.Tick += delegate
		{
			picSaved.Visible = !picSaved.Visible;
			intValue++;
			if (intValue == 6)
			{
				intValue = 0;
				timer.Enabled = false;
			}
		};
		SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = "Save as",
			Filter = "Konayuki Project|*.kpj"
		};
		if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			method_11();
			string_3 = saveFileDialog.FileName;
			File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(list_0, Formatting.Indented));
			timer.Enabled = true;
		}
	}

	private void method_29(int P_0)
	{
		int intValue = 0;
		Timer timer = new Timer
		{
			Enabled = true,
			Interval = 500
		};
		timer.Tick += delegate
		{
			picSaved.Visible = !picSaved.Visible;
			intValue++;
			if (intValue == P_0 * 2)
			{
				intValue = 0;
				timer.Enabled = false;
			}
		};
	}

	private bool method_30()
	{
		if (string_3 != "Untitled")
		{
			try
			{
				return !JsonConvert.DeserializeObject(File.ReadAllText(string_3)).ToString().Equals(JsonConvert.DeserializeObject(JsonConvert.SerializeObject(list_0, Formatting.Indented)).ToString());
			}
			catch
			{
				return true;
			}
		}
		return true;
	}

	private void method_31()
	{
		tvDetails.Nodes.Clear();
		tvDetails.Nodes.Add("Details");
		tvDetails.Nodes[0].Nodes.Add("Time Elapsed : none");
		tvDetails.Nodes[0].Nodes.Add("Remaining Time : none");
		tvDetails.Nodes[0].Nodes.Add("Status : none");
		tvDetails.Nodes[0].Nodes.Add("FPS : none");
		tvDetails.Nodes[0].Nodes.Add("Speed : none");
		tvDetails.Nodes[0].Nodes.Add("Input Size : none");
		tvDetails.Nodes[0].Nodes.Add("Output Size : none");
		tvDetails.Nodes[0].Nodes.Add("Indexing : none");
		tvDetails.ExpandAll();
	}

	private void frmMain_Shown(object P_0, EventArgs P_1)
	{
		if (bool_3 && !(Application.OpenForms["frmChangelog"] is frmChangelog))
		{
			frmChangelog frmChangelog2 = new frmChangelog();
			frmChangelog2.TopMost = TopMost;
			frmChangelog2.ShowDialog(this);
		}
		Class12.smethod_2(true);
	}

	private void method_32(string P_0)
	{
		Native_MediaInfo native_MediaInfo = new Native_MediaInfo();
		native_MediaInfo.method_0(P_0);
		native_MediaInfo.method_9("Complete", "0");
		rtbInfo.Clear();
		string[] array = Regex.Split(native_MediaInfo.method_6(), "\r\n");
		foreach (string text in array)
		{
			if (text.IndexOf("General") == 0 || text.IndexOf("Video") == 0 || text.IndexOf("Audio") == 0 || text.IndexOf("Text") == 0 || text.IndexOf("Other") == 0 || text.IndexOf("Image") == 0 || text.IndexOf("Menu") == 0)
			{
				rtbInfo.SelectionFont = new Font(rtbInfo.SelectionFont.FontFamily, 10f, FontStyle.Bold);
				rtbInfo.SelectionColor = Color.FromArgb(255, 51, 153);
				rtbInfo.SelectedText = text + "\r\n";
			}
			else
			{
				rtbInfo.SelectionColor = Color.Black;
				RichTextBox richTextBox = rtbInfo;
				richTextBox.SelectedText = richTextBox.SelectedText + text + "\r\n";
			}
		}
	}

	private void method_33(bool P_0 = false)
	{
		if (lstQueue.SelectedItems.Count != 1)
		{
			return;
		}
		int index = lstQueue.Items.IndexOf(lstQueue.SelectedItems[0]);
		method_32(Path.Combine(list_0[index].Fullpath, list_0[index].File));
		if (!Class5.IsPreview)
		{
			return;
		}
		videoBox.Image = Resources.player_on;
		if (!bool_2)
		{
			method_15(lstQueue.Items.IndexOf(lstQueue.SelectedItems[0]), Class48.smethod_18(TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds.ToString()) + ".avs", int_1);
			if (P_0)
			{
				tbSeek.Value = 0;
			}
			bool_9 = true;
		}
	}

	private void frmMain_Load(object P_0, EventArgs P_1)
	{
		dictionary_0 = class13_0.Fonts;
		stringArray_0 = class13_0.Player;
		method_27(1);
		int intValue = 0;
		Timer timer = new Timer
		{
			Enabled = false,
			Interval = 250
		};
		timer.Tick += delegate
		{
			picSaved.Visible = !picSaved.Visible;
			intValue++;
			if (intValue == 6)
			{
				intValue = 0;
				timer.Enabled = false;
			}
		};
		Timer timer2 = new Timer
		{
			Enabled = true,
			Interval = 1
		};
		timer2.Tick += delegate
		{
			if (bool_8 && Class3.smethod_1(Keys.ControlKey) && Class3.smethod_1(Keys.S))
			{
				if (string_3 == "Untitled")
				{
					if (Class48.smethod_3("KONAYUKI PLUS"))
					{
						bool_8 = false;
						method_28();
						bool_8 = true;
					}
				}
				else
				{
					bool_8 = false;
					method_11();
					File.WriteAllText(string_3, JsonConvert.SerializeObject(list_0, Formatting.Indented));
					timer.Enabled = true;
					timer2.Enabled = false;
					bool_8 = true;
				}
			}
		};
		Timer timer3 = new Timer
		{
			Enabled = true,
			Interval = 1
		};
		timer3.Tick += delegate
		{
			if (!Class3.smethod_1(Keys.ControlKey) || !Class3.smethod_1(Keys.S))
			{
				timer2.Enabled = true;
			}
		};
		Timer timer4 = new Timer
		{
			Enabled = true,
			Interval = 1
		};
		timer4.Tick += delegate
		{
			if (Class48.ShowAgain)
			{
				togPreview.Checked = false;
				class6_0.method_15();
				videoBox.Image = Resources.player_off;
				Class12.smethod_2();
				Class48.ShowAgain = false;
				Show();
				WindowState = FormWindowState.Normal;
				Focus();
				Class48.smethod_0(this);
			}
			Class5.IsPreview = togPreview.Checked;
			if (Class5.IsPreview)
			{
				if (Class5.IsExecute)
				{
					Application.DoEvents();
					Class5.IsExecute = false;
					int_3 = tbSeek.Value;
					class6_0.method_25(videoBox, Class5.File);
					Application.DoEvents();
				}
				if (class6_0.TotalFrame != 0.0)
				{
					if (!bool_5)
					{
						class6_0.method_12();
						bool_5 = true;
						int_2 = (int)class6_0.TotalFrame;
						if (tbVolume.Value == 50)
						{
							class6_0.Volume = 0;
							btnMute.BackgroundImage = Resources.mute_off;
						}
						else
						{
							class6_0.Volume = tbVolume.Value;
							btnMute.BackgroundImage = Resources.mute_on;
						}
						if (Class5.FPSNum == "0" || Class5.FPSDen == "0" || cboVideoSmooth.SelectedIndex > 0)
						{
							tbSeek.Maximum = (int)((double)int_2 - double.Parse(class6_0.method_11()));
							double num = (double)int_3 / double.Parse(class6_0.method_11());
							double currentPosition = Math.Floor(num * 1000.0) / 1000.0;
							class6_0.CurrentPosition = currentPosition;
						}
						else
						{
							tbSeek.Maximum = (int)((double)int_2 - double.Parse(Class5.FPSNum) / double.Parse(Class5.FPSDen));
							double num2 = (double)int_3 / (double.Parse(Class5.FPSNum) / double.Parse(Class5.FPSDen));
							double currentPosition2 = Math.Floor(num2 * 1000.0) / 1000.0;
							class6_0.CurrentPosition = currentPosition2;
						}
					}
					int value = class6_0.method_17();
					try
					{
						if (!bool_6)
						{
							tbSeek.Value = value;
						}
					}
					catch
					{
					}
				}
				else
				{
					bool_5 = false;
				}
			}
			togHardSubRemover.Checked = false;
			Class48.SendMessage(Class48.FindWindow(null, "Warning"), 130, 0, 0);
			method_21();
			if (lstQueue.SelectedItems.Count > 0)
			{
				splitMain.Visible = true;
				togPreview.Visible = true;
				btnReset.Visible = true;
				btnPreview.Enabled = true;
				btnCompare.Enabled = true;
				btnMPC.Enabled = true;
				btnCompareMPC.Enabled = true;
				for (int i = 0; i < lstQueue.SelectedItems.Count; i++)
				{
					method_12(lstQueue.Items.IndexOf(lstQueue.SelectedItems[i]));
				}
			}
			else
			{
				class6_0.method_15();
				splitMain.Visible = false;
				togPreview.Visible = false;
				btnReset.Visible = false;
				btnPreview.Enabled = false;
				btnCompare.Enabled = false;
				btnMPC.Enabled = false;
				btnCompareMPC.Enabled = false;
			}
			if (Class14.kFile != null)
			{
				if (lstQueue.Items.Count > 0)
				{
					if (string_3 != "Untitled" && !File.Exists(string_3))
					{
						string_3 = Class14.kFile;
					}
				}
				else
				{
					string_3 = Class14.kFile;
				}
				list_0.AddRange(JsonConvert.DeserializeObject<List<Class52>>(File.ReadAllText(Class14.kFile)));
				List<Class52> list = new List<Class52>();
				list = JsonConvert.DeserializeObject<List<Class52>>(File.ReadAllText(Class14.kFile));
				for (int j = 0; j < list.Count; j++)
				{
					lstQueue.Items.Add(new ListViewItem(new string[10]
					{
						list[j].File,
						list[j].Type,
						"Ready",
						null,
						null,
						list[j].Fullpath,
						list[j].Output,
						bool.FalseString,
						Class48.smethod_9(Path.Combine(list[j].Fullpath, list[j].File)),
						null
					})
					{
						Checked = list[j].Checked
					});
					list_0[lstQueue.Items.Count - 1].Audio.Track = method_9(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.MainPath = Class48.smethod_37();
					list_0[lstQueue.Items.Count - 1].System.Cores = Class18.smethod_1();
					list_0[lstQueue.Items.Count - 1].System.Threads = Class18.smethod_2();
					list_0[lstQueue.Items.Count - 1].System.Ram = Class18.smethod_0();
					list_0[lstQueue.Items.Count - 1].System.ScanType = class56_0.method_0(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.ScanMethod = class56_0.method_1(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.ScanOrder = class56_0.method_2(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.DAR = class56_0.method_3(Path.Combine(list[j].Fullpath, list[j].File));
				}
				Class14.kFile = null;
			}
		};
	}

	private void frmMain_Resize(object P_0, EventArgs P_1)
	{
		if (WindowState == FormWindowState.Minimized)
		{
		}
		if (bool_0 && !bool_4)
		{
			class52_0.Width = Width;
			class52_0.Height = Height;
		}
	}

	private void togOntop_CheckedChanged(object P_0, EventArgs P_1)
	{
		TopMost = togOntop.Checked;
		string lang = "English";
		for (int i = 0; i < tsmiTrayLanguage.DropDownItems.Count; i++)
		{
			if (((ToolStripMenuItem)tsmiTrayLanguage.DropDownItems[i]).Checked)
			{
				lang = tsmiTrayLanguage.DropDownItems[i].Text;
			}
		}
		Class4 value = new Class4
		{
			IsAutoLoadSub = class4_0.IsAutoLoadSub,
			IsMT = class4_0.IsMT,
			IsSDL2 = class4_0.IsSDL2,
			IsCRC32 = class4_0.IsCRC32,
			IsTopMost = togOntop.Checked,
			AfterCompletion = class4_0.AfterCompletion,
			Lang = lang
		};
		File.WriteAllText(Class48.smethod_37() + "\\configs.json", JsonConvert.SerializeObject(value, Formatting.Indented));
	}

	private void togClipDetails_CheckedChanged(object P_0, EventArgs P_1)
	{
		txtClipDeailsName.Enabled = togClipDetails.Checked;
		txtClipDeailsAuthor.Enabled = togClipDetails.Checked;
	}

	private void btnIntroFadeInColor_Click(object P_0, EventArgs P_1)
	{
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			pFadeInColor.BackColor = colorDialog_0.Color;
			method_33();
		}
	}

	private void btnIntroFadeOutColor_Click(object P_0, EventArgs P_1)
	{
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			pFadeOutColor.BackColor = colorDialog_0.Color;
			method_33();
		}
	}

	private void btnSourceFadeInColor_Click(object P_0, EventArgs P_1)
	{
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			pSourceInColor.BackColor = colorDialog_0.Color;
			method_33();
		}
	}

	private void btnSourceFadeOutColor_Click(object P_0, EventArgs P_1)
	{
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			pSourceOutColor.BackColor = colorDialog_0.Color;
			method_33();
		}
	}

	private void btnEndCardFadeInColor_Click(object P_0, EventArgs P_1)
	{
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			pEndCardInColor.BackColor = colorDialog_0.Color;
			method_33();
		}
	}

	private void btnEndCardFadeOutColor_Click(object P_0, EventArgs P_1)
	{
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			pEndCardOutColor.BackColor = colorDialog_0.Color;
			method_33();
		}
	}

	private void btnLogoFadeColor_Click(object P_0, EventArgs P_1)
	{
		if (colorDialog_0.ShowDialog(this) == DialogResult.OK)
		{
			pLogoFadeColor.BackColor = colorDialog_0.Color;
			method_33();
		}
	}

	private void btnStart_Click(object P_0, EventArgs P_1)
	{
		if (lstQueue.CheckedItems.Count > 0)
		{
			togPreview.Enabled = false;
			togPreview.Checked = false;
			class6_0.method_15();
			videoBox.Image = Resources.player_off;
			string text = string.Empty;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			bool flag8 = false;
			bool flag9 = false;
			bool flag10 = false;
			for (int i = 0; i < lstQueue.Items.Count; i++)
			{
				if (list_0[i].Checked)
				{
					if (list_0[i].Advance.Video.Enhancer.Resize != 0)
					{
						flag = true;
					}
					if (list_0[i].Advance.Video.Enhancer.FPS60 != 0)
					{
						flag2 = true;
					}
					if (list_0[i].Advance.Video.Enhancer.LineDarkener != 0)
					{
						flag3 = true;
					}
					if (list_0[i].Advance.Video.Enhancer.Sharpen != 0)
					{
						flag4 = true;
					}
					if (list_0[i].Advance.Video.Enhancer.WarpSharp != 0)
					{
						flag5 = true;
					}
					if (list_0[i].Advance.Video.Enhancer.NoiseRemover != 0)
					{
						flag6 = true;
					}
					if (list_0[i].Advance.Video.Color.Brightness != 100)
					{
						flag7 = true;
					}
					if (list_0[i].Advance.Video.Color.Contrast != 100)
					{
						flag8 = true;
					}
					if (list_0[i].Advance.Video.Color.Saturation != 100)
					{
						flag9 = true;
					}
					if (list_0[i].Advance.Video.Color.Debanding != 0)
					{
						flag10 = true;
					}
				}
			}
			if (flag)
			{
				text += "\r\n- Resize Video";
			}
			if (flag2)
			{
				text += "\r\n- Motion Interpolation (60FPS)";
			}
			if (flag3)
			{
				text += "\r\n- Line Darkener";
			}
			if (flag4)
			{
				text += "\r\n- Sharpen";
			}
			if (flag5)
			{
				text += "\r\n- Warp Sharp";
			}
			if (flag6)
			{
				text += "\r\n- Mosquito Noise Remover";
			}
			if (flag7)
			{
				text += "\r\n- Brightness";
			}
			if (flag8)
			{
				text += "\r\n- Contrast";
			}
			if (flag9)
			{
				text += "\r\n- Saturation";
			}
			if (flag10)
			{
				text += "\r\n- Debanding";
			}
			if (flag | flag2 | flag3 | flag4 | flag5 | flag6 | flag7 | flag8 | flag9 | flag10)
			{
				Class48.smethod_23(Handle, this);
				int num = text.Split(new string[1] { "\r\n" }, StringSplitOptions.None).Length;
				num = ((num <= 8) ? 280 : (num * 35));
				if (MetroMessageBox.Show(this, text + "\r\n\r\nDo you want to encode?", "Some of your video in the queue has been using those option...", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, num) == DialogResult.No)
				{
					return;
				}
			}
			bool flag11 = false;
			frmProcess.IsOK = false;
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				if (class13_0.Proc.Contains(process.ProcessName))
				{
					flag11 = true;
				}
			}
			if (flag11)
			{
				frmProcess frmProcess2 = new frmProcess();
				frmProcess2.TopMost = TopMost;
				frmProcess2.ShowDialog(this);
				if (frmProcess.IsOK)
				{
					if (!backgroundWorker_0.IsBusy)
					{
						method_11();
						backgroundWorker_0.RunWorkerAsync();
						psProgress.Value = 0;
						psProgress.Visible = true;
						bool_10 = false;
					}
					Process[] processesByName = Process.GetProcessesByName("ffmpeg");
					foreach (Process process2 in processesByName)
					{
						if (process_0 != null && process2.Id == process_0.Id)
						{
							psProgress.Visible = true;
							process2.smethod_1();
						}
					}
				}
			}
			else
			{
				if (!backgroundWorker_0.IsBusy)
				{
					method_11();
					backgroundWorker_0.RunWorkerAsync();
					psProgress.Value = 0;
					psProgress.Visible = true;
					bool_10 = false;
				}
				try
				{
					Process[] processesByName2 = Process.GetProcessesByName("ffmpeg");
					foreach (Process process3 in processesByName2)
					{
						if (process_0 != null && process3.Id == process_0.Id)
						{
							psProgress.Visible = true;
							process3.smethod_1();
						}
					}
				}
				catch
				{
				}
			}
		}
		if (TaskbarManager.IsPlatformSupported)
		{
			TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
		}
	}

	private void btnAdd_Click(object P_0, EventArgs P_1)
	{
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 1);
		p = button.PointToScreen(p);
		cmsControlQueue_2.Show(p);
	}

	private void btnStop_Click(object P_0, EventArgs P_1)
	{
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 1);
		p = button.PointToScreen(p);
		cmsControlQueue.Show(p);
	}

	private void cboVideoEncoder_SelectedIndexChanged(object P_0, EventArgs P_1)
	{
		cboVideoPreset.Items.Clear();
		if (cboVideoEncoder.SelectedIndex == 6 || cboVideoEncoder.SelectedIndex == 7 || cboVideoEncoder.SelectedIndex == 8)
		{
			ComboBox.ObjectCollection items = cboVideoPreset.Items;
			object[] items2 = new string[3] { "Slow", "Medium", "Fast" };
			items.AddRange(items2);
			cboVideoPreset.Text = "Slow";
		}
		else if (cboVideoEncoder.SelectedIndex == 9 || cboVideoEncoder.SelectedIndex == 10)
		{
			ComboBox.ObjectCollection items3 = cboVideoPreset.Items;
			object[] items2 = new string[3] { "Quality", "Balanced", "Speed" };
			items3.AddRange(items2);
			cboVideoPreset.Text = "Quality";
		}
		else
		{
			ComboBox.ObjectCollection items4 = cboVideoPreset.Items;
			object[] items2 = new string[7] { "Very Slow", "Slower", "Slow", "Medium", "Fast", "Faster", "Very Fast" };
			items4.AddRange(items2);
			cboVideoPreset.Text = "Slow";
		}
		switch (cboVideoEncoder.SelectedIndex)
		{
		case 0:
		case 3:
		case 6:
		case 9:
			lblVideoQuality.Text = "Quality (CRF/QP) [Recommend for TV 20 - 22, BD 16 - 18]";
			break;
		default:
			lblVideoQuality.Text = "Quality (CRF/QP) [Recommend for TV 24 - 26, BD 20 - 22]";
			break;
		}
	}

	private void cboTransition_SelectedIndexChanged(object P_0, EventArgs P_1)
	{
		pnFadeAll.Visible = false;
		pnDissolveAll.Visible = false;
		pnTransition.Visible = false;
		switch (cboTransition.SelectedIndex)
		{
		case 1:
			pnFadeAll.Visible = true;
			return;
		case 2:
			pnDissolveAll.Visible = true;
			return;
		case 3:
			pnTransition.Visible = true;
			return;
		}
		pnFadeAll.Visible = false;
		pnDissolveAll.Visible = false;
		pnDissolveAll.Visible = false;
		pnTransition.Visible = false;
	}

	private void method_34()
	{
		cmsControlQueue_5.Items.Add("123").Click += delegate
		{
			MessageBox.Show("");
		};
	}

	private void btnDel_Click(object P_0, EventArgs P_1)
	{
		string text = bool.FalseString;
		foreach (ListViewItem item in lstQueue.Items)
		{
			if (item.SubItems[7].Text == bool.TrueString)
			{
				text = bool.TrueString;
			}
		}
		if (bool_2 || bool_12 || text == bool.TrueString)
		{
			Class48.smethod_23(Handle, this);
			MetroMessageBox.Show(this, "Please stop all preview and encoding !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			cmsControlQueue_5.Enabled = false;
			return;
		}
		cmsControlQueue_5.Enabled = true;
		tsmiDeleteFile.Text = $"Delete Queue ({lstQueue.SelectedItems.Count} selected)";
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 1);
		p = button.PointToScreen(p);
		cmsControlQueue_5.Show(p);
	}

	private void tbColorBrightness_ValueChanged(object P_0, EventArgs P_1)
	{
		if (tbColorBrightness.Value == 100)
		{
			lblColorBrightnessLevel.Text = "Disable";
		}
		else
		{
			lblColorBrightnessLevel.Text = tbColorBrightness.Value.ToString();
		}
	}

	private void tbColorContrast_ValueChanged(object P_0, EventArgs P_1)
	{
		if (tbColorContrast.Value == 100)
		{
			lblColorContrastLevel.Text = "Disable";
		}
		else
		{
			lblColorContrastLevel.Text = tbColorContrast.Value.ToString();
		}
	}

	private void tbColorSaturation_ValueChanged(object P_0, EventArgs P_1)
	{
		if (tbColorSaturation.Value == 100)
		{
			lblColorSaturationLevel.Text = "Disable";
		}
		else
		{
			lblColorSaturationLevel.Text = tbColorSaturation.Value.ToString();
		}
	}

	private void tbVideo_ValueChanged(object P_0, EventArgs P_1)
	{
		lblVideoQualityLevel.Text = $"<< Highest {tbVideo.Value} Lowest >>";
	}

	private void tbVideoLineDarkener_ValueChanged(object P_0, EventArgs P_1)
	{
		if (tbVideoLineDarkener.Value == 0)
		{
			lblVideoLineDarkenerLevel.Text = "Disable";
		}
		else
		{
			lblVideoLineDarkenerLevel.Text = tbVideoLineDarkener.Value.ToString();
		}
	}

	private void tbVideoSharpen_ValueChanged(object P_0, EventArgs P_1)
	{
		if (tbVideoSharpen.Value == 0)
		{
			lblVideoSharpenLevel.Text = "Disable";
		}
		else
		{
			lblVideoSharpenLevel.Text = tbVideoSharpen.Value.ToString();
		}
	}

	private void tbVideoWarpSharp_ValueChanged(object P_0, EventArgs P_1)
	{
		if (tbVideoWarpSharp.Value == 0)
		{
			lblVideoWarpSharpLevel.Text = "Disable";
		}
		else
		{
			lblVideoWarpSharpLevel.Text = tbVideoWarpSharp.Value.ToString();
		}
	}

	private void tbVolumeSource_ValueChanged(object P_0, EventArgs P_1)
	{
		lblVolumeSourceLevel.Text = tbVolumeSource.Value + "%";
	}

	private void tbVolumeIntro_ValueChanged(object P_0, EventArgs P_1)
	{
		lblVolumeIntroLevel.Text = tbVolumeIntro.Value + "%";
	}

	private void tbVolumeEndCard_ValueChanged(object P_0, EventArgs P_1)
	{
		lblVolumeEndCardLevel.Text = tbVolumeEndCard.Value + "%";
	}

	private void tbLogoOpacity_ValueChanged(object P_0, EventArgs P_1)
	{
		lblLogoOpacityLevel.Text = tbLogoOpacity.Value + "%";
	}

	private void tbRemoverLevel1_ValueChanged(object P_0, EventArgs P_1)
	{
		lblRemoverLevel1Level.Text = tbRemoverLevel1.Value.ToString();
	}

	private void tbRemoverLevel2_ValueChanged(object P_0, EventArgs P_1)
	{
		lblRemoverLevel2Level.Text = tbRemoverLevel2.Value.ToString();
	}

	private void method_35(string P_0)
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(P_0);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				fileInfo.Delete();
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				method_35(directoryInfo2.FullName);
				directoryInfo2.Delete();
			}
		}
		catch
		{
		}
	}

	private void frmMain_FormClosing(object P_0, FormClosingEventArgs P_1)
	{
		if (P_1.CloseReason == CloseReason.ApplicationExitCall || P_1.CloseReason == CloseReason.WindowsShutDown)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("ffmpeg");
				foreach (Process process in processesByName)
				{
					process.Kill();
					if (process_0 != null && process.Id == process_0.Id)
					{
						process.smethod_1();
					}
				}
				Process[] processesByName2 = Process.GetProcessesByName("ffplay");
				foreach (Process process2 in processesByName2)
				{
					process2.Kill();
				}
			}
			catch
			{
				Class48.smethod_23(Handle, this);
				if (MetroMessageBox.Show(this, "Some program take over the processes, KONAYUKI PLUS can't terminate the process properly.\r\nPlease restart the computer.", "KONAYUKI PLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
				{
					frmComplete.smethod_0(6);
				}
			}
			P_1.Cancel = false;
			method_23();
			method_3(false);
			method_35(Path.Combine(Class48.smethod_37(), "tmp"));
		}
		else
		{
			P_1.Cancel = true;
			Hide();
			if (bool_11)
			{
				new Notification("KONAYUKI PLUS still running", "Click icon on the icon tray to bring it back.", -1, Enum13.Value0, Class1.Enum5.Value2, Class1.Enum6.Value3).method_1();
				bool_11 = false;
			}
		}
		class6_0.method_15();
		Class12.smethod_2(true);
	}

	private void togIntro_CheckedChanged(object P_0, EventArgs P_1)
	{
		tbVolumeIntro.Enabled = togIntro.Checked;
		txtIntro.Enabled = togIntro.Checked;
		txtIntroMusic.Enabled = togIntro.Checked;
		udIntroTime.Enabled = togIntro.Checked;
		chkIntroMusic.Enabled = togIntro.Checked;
	}

	private void togEndCard_CheckedChanged(object P_0, EventArgs P_1)
	{
		tbVolumeEndCard.Enabled = togEndCard.Checked;
		txtEndCard.Enabled = togEndCard.Checked;
		txtEndCardMusic.Enabled = togEndCard.Checked;
		udEndCardTime.Enabled = togEndCard.Checked;
		chkEndCardMusic.Enabled = togEndCard.Checked;
	}

	private void togSubtitle_CheckedChanged(object P_0, EventArgs P_1)
	{
		txtSubtitle.Enabled = togSubtitle.Checked;
	}

	private void togKaraoke_CheckedChanged(object P_0, EventArgs P_1)
	{
		txtKaraokeOP.Enabled = togKaraoke.Checked;
		txtKaraokeED.Enabled = togKaraoke.Checked;
		chkKaraokeOP.Enabled = togKaraoke.Checked;
		chkKaraokeED.Enabled = togKaraoke.Checked;
	}

	private void togFadeIn_CheckedChanged(object P_0, EventArgs P_1)
	{
		btnIntroFadeInColor.Enabled = togFadeIn.Checked;
		udIntroFadeInTime.Enabled = togFadeIn.Checked;
	}

	private void togFadeOut_CheckedChanged(object P_0, EventArgs P_1)
	{
		btnIntroFadeOutColor.Enabled = togFadeOut.Checked;
		udIntroFadeOutTime.Enabled = togFadeOut.Checked;
	}

	private void togSourceIn_CheckedChanged(object P_0, EventArgs P_1)
	{
		btnSourceFadeInColor.Enabled = togSourceIn.Checked;
		udSourceFadeInTime.Enabled = togSourceIn.Checked;
	}

	private void togSourceOut_CheckedChanged(object P_0, EventArgs P_1)
	{
		btnSourceFadeOutColor.Enabled = togSourceOut.Checked;
		udSourceFadeOutTime.Enabled = togSourceOut.Checked;
	}

	private void togEndCardIn_CheckedChanged(object P_0, EventArgs P_1)
	{
		btnEndCardFadeInColor.Enabled = togEndCardIn.Checked;
		udEndCardFadeInTime.Enabled = togEndCardIn.Checked;
	}

	private void togEndCardOut_CheckedChanged(object P_0, EventArgs P_1)
	{
		btnEndCardFadeOutColor.Enabled = togEndCardOut.Checked;
		udEndCardFadeOutTime.Enabled = togEndCardOut.Checked;
	}

	private void togLogo_CheckedChanged(object P_0, EventArgs P_1)
	{
		txtLogo.Enabled = togLogo.Checked;
		togLogoTime.Enabled = togLogo.Checked;
		udLogoTimeSec.Enabled = togLogo.Checked;
		txtLogo.Enabled = togLogo.Checked;
		udLogoTimeSecMinute.Enabled = togLogo.Checked;
		cboLogoBlend.Enabled = togLogo.Checked;
		tbLogoOpacity.Enabled = togLogo.Checked;
		btnLogoFadeColor.Enabled = togLogo.Checked;
	}

	private void togLogoTime_CheckedChanged(object P_0, EventArgs P_1)
	{
		udLogoTimeSec.Enabled = !togLogoTime.Checked;
		udLogoTimeSecMinute.Enabled = !togLogoTime.Checked;
	}

	private void togLogoSubtitle_CheckedChanged(object P_0, EventArgs P_1)
	{
		txtLogoSubtitle.Enabled = togLogoSubtitle.Checked;
	}

	private void togHardSubRemover_CheckedChanged(object P_0, EventArgs P_1)
	{
		udRemoverTop.Enabled = togHardSubRemover.Checked;
		udRemoverBottom.Enabled = togHardSubRemover.Checked;
		udRemoverLeft.Enabled = togHardSubRemover.Checked;
		udRemoverRight.Enabled = togHardSubRemover.Checked;
		tbRemoverLevel1.Enabled = togHardSubRemover.Checked;
		tbRemoverLevel2.Enabled = togHardSubRemover.Checked;
	}

	private string[] method_36(string P_0, Enum12 P_1, bool P_2)
	{
		string empty = string.Empty;
		empty = P_1 switch
		{
			Enum12.Value1 => "File Types (*.ass;*.srt;*.ssa;*.sup)|*.ass;*.srt;*.ssa;*.sup", 
			Enum12.Value3 => "File Types (*.mp4;*.mkv;*.avi;*.wmv;*.mov;*.mpg;*.webm;*.mpeg;*.m2ts;*.ts;*.png;*.jpg)|*.mp4;*.mkv;*.avi;*.wmv;*.mov;*.mpg;*.webm;*.mpeg;*.m2ts;*.ts;*.png;*.jpg", 
			Enum12.Value5 => "File Types (*.aac;*.mp3;*.wma;*.flac)|*.aac;*.mp3;*.wma;*.flac", 
			Enum12.Value7 => "File Types (*.png;*.mov)|*.png;*.mov", 
			Enum12.Value8 => "File Types (*.mov)|*.mov", 
			Enum12.Value9 => "Konayuki Project|*.kpj", 
			_ => "File Types (*.mp4;*.mkv;*.avi;*.wmv;*.mov;*.mpg;*.webm;*.mpeg;*.m2ts;*.ts)|*.mp4;*.mkv;*.avi;*.wmv;*.mov;*.mpg;*.webm;*.mpeg;*.m2ts;*.ts", 
		};
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = P_0,
			Filter = empty,
			Multiselect = P_2
		};
		if (openFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			return openFileDialog.FileNames;
		}
		return new string[0];
	}

	private void tsmiAddFiles_Click(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Files", Enum12.Value0, true);
		foreach (string text in array)
		{
			if (Class8.Source.Contains(Path.GetExtension(text).ToLower()))
			{
				method_13(text);
				method_10(text);
			}
			try
			{
				lstQueue.Items[lstQueue.Items.Count - 1].Selected = true;
			}
			catch
			{
			}
		}
	}

	private void btnInfo_Click(object P_0, EventArgs P_1)
	{
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 1);
		p = button.PointToScreen(p);
		cmsControlQueue_4.Show(p);
	}

	private void txtSubtitle_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Subtitle", Enum12.Value1, false);
		foreach (string path in array)
		{
			if (!Class8.Subtitle.Contains(Path.GetExtension(path).ToLower()))
			{
				continue;
			}
			foreach (ListViewItem item in lstQueue.Items)
			{
				if (item.Selected)
				{
					txtSubtitle.Text = path;
					method_12(item.Index, true);
					method_33();
				}
			}
		}
	}

	private void txtIntro_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Intro", Enum12.Value3, false);
		foreach (string path in array)
		{
			if (Class8.Intro.Contains(Path.GetExtension(path).ToLower()))
			{
				txtIntro.Text = path;
				method_33(true);
			}
		}
	}

	private void txtIntroMusic_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Intro Music", Enum12.Value5, false);
		foreach (string path in array)
		{
			if (Class8.IntroMusic.Contains(Path.GetExtension(path).ToLower()))
			{
				txtIntroMusic.Text = path;
				method_33();
			}
		}
	}

	private void txtEndCard_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add EndCard", Enum12.Value3, false);
		foreach (string path in array)
		{
			if (Class8.EndCard.Contains(Path.GetExtension(path).ToLower()))
			{
				txtEndCard.Text = path;
				method_33(true);
			}
		}
	}

	private void txtEndCardMusic_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add EndCard Music", Enum12.Value5, false);
		foreach (string path in array)
		{
			if (Class8.EndCardMusic.Contains(Path.GetExtension(path).ToLower()))
			{
				txtEndCardMusic.Text = path;
				method_33();
			}
		}
	}

	private void txtKaraokeOP_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Karaoke OP", Enum12.Value1, false);
		foreach (string path in array)
		{
			if (Class8.Karaoke.Contains(Path.GetExtension(path).ToLower()))
			{
				txtKaraokeOP.Text = path;
				method_33();
			}
		}
	}

	private void txtKaraokeED_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Karaoke ED", Enum12.Value1, false);
		foreach (string path in array)
		{
			if (Class8.Karaoke.Contains(Path.GetExtension(path).ToLower()))
			{
				txtKaraokeED.Text = path;
				method_33();
			}
		}
	}

	private void txtIntroTransition_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Intro Transition", Enum12.Value8, false);
		foreach (string path in array)
		{
			if (Class8.Transition.Contains(Path.GetExtension(path).ToLower()))
			{
				txtIntroTransition.Text = path;
				method_33();
			}
		}
	}

	private void txtIntroTransitionOverlay_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Intro Transition Overlay", Enum12.Value8, false);
		foreach (string path in array)
		{
			if (Class8.Transition.Contains(Path.GetExtension(path).ToLower()))
			{
				txtIntroTransitionOverlay.Text = path;
				method_33();
			}
		}
	}

	private void txtEndCardTransition_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Intro EndCard", Enum12.Value8, false);
		foreach (string path in array)
		{
			if (Class8.Transition.Contains(Path.GetExtension(path).ToLower()))
			{
				txtEndCardTransition.Text = path;
				method_33();
			}
		}
	}

	private void txtEndCardTransitionOverlay_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Intro EndCard Overlay", Enum12.Value8, false);
		foreach (string path in array)
		{
			if (Class8.Transition.Contains(Path.GetExtension(path).ToLower()))
			{
				txtEndCardTransitionOverlay.Text = path;
				method_33();
			}
		}
	}

	private void txtLogo_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Logo", Enum12.Value7, false);
		foreach (string path in array)
		{
			if (Class8.Logo.Contains(Path.GetExtension(path).ToLower()))
			{
				txtLogo.Text = path;
				method_33();
			}
		}
	}

	private void txtLogoSubtitle_ButtonClick(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Add Logo ASS", Enum12.Value1, false);
		foreach (string path in array)
		{
			if (Class8.Subtitle.Contains(Path.GetExtension(path).ToLower()))
			{
				txtLogoSubtitle.Text = path;
				method_33();
			}
		}
	}

	private void btnSetting_Click(object P_0, EventArgs P_1)
	{
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 1);
		p = button.PointToScreen(p);
		cmsControlQueue_7.Show(p);
	}

	private void btnPreview_Click(object P_0, EventArgs P_1)
	{
		method_4(1);
	}

	private void tsmiPause_Click(object P_0, EventArgs P_1)
	{
		Process[] processesByName = Process.GetProcessesByName("ffmpeg");
		foreach (Process process in processesByName)
		{
			if (process_0 != null && process.Id == process_0.Id)
			{
				psProgress.Visible = false;
				lstQueue.Items[int_4].SubItems[2].Text = "Pause";
				if (TaskbarManager.IsPlatformSupported)
				{
					TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused);
				}
				process.smethod_0();
				bool_1 = true;
			}
		}
	}

	private void tsmiSkip_Click(object P_0, EventArgs P_1)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("ffmpeg");
			foreach (Process process in processesByName)
			{
				process.Kill();
				if (process_0 != null && process.Id == process_0.Id)
				{
					process.smethod_1();
				}
			}
		}
		catch
		{
			Class48.smethod_23(Handle, this);
			if (MetroMessageBox.Show(this, "Some program take over the processes, KONAYUKI PLUS can't terminate the process properly.\r\nPlease restart the computer.", "KONAYUKI PLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
			{
				method_1();
				frmComplete.smethod_0(6);
			}
			else
			{
				method_1();
				Application.Exit();
			}
		}
	}

	private void tsmiStop_Click(object P_0, EventArgs P_1)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("ffmpeg");
			foreach (Process process in processesByName)
			{
				process.Kill();
				if (process_0 != null && process.Id == process_0.Id)
				{
					process.smethod_1();
				}
			}
		}
		catch
		{
			Class48.smethod_23(Handle, this);
			if (MetroMessageBox.Show(this, "Some program take over the processes, KONAYUKI PLUS can't terminate the process properly.\r\nPlease restart the computer.", "KONAYUKI PLUS", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
			{
				method_1();
				frmComplete.smethod_0(6);
			}
			else
			{
				method_1();
				Application.Exit();
			}
		}
		if (backgroundWorker_0.WorkerSupportsCancellation)
		{
			backgroundWorker_0.CancelAsync();
		}
	}

	private void tsmiStopAfterCurrent_Click(object P_0, EventArgs P_1)
	{
		if (backgroundWorker_0.WorkerSupportsCancellation)
		{
			backgroundWorker_0.CancelAsync();
		}
	}

	private void tsmiAddFolder_Click(object P_0, EventArgs P_1)
	{
		Class15 @class = new Class15
		{
			Title = "Add Folder"
		};
		if (@class.method_0(this) != DialogResult.OK)
		{
			return;
		}
		string[] files = Directory.GetFiles(@class.DirectoryPath);
		foreach (string text in files)
		{
			if (Class8.Source.Contains(Path.GetExtension(text).ToLower()))
			{
				method_13(text);
				method_10(text);
			}
		}
	}

	private void lstQueue_MouseClick(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Button == MouseButtons.Left && lstQueue.SelectedItems.Count > 0)
		{
			method_33(true);
		}
	}

	private void lstQueue_SelectedIndexChanged(object P_0, EventArgs P_1)
	{
		if (lstQueue.SelectedItems.Count > 0)
		{
			method_18(lstQueue.Items.IndexOf(lstQueue.SelectedItems[0]));
		}
	}

	private void tsmiNewProject_Click(object P_0, EventArgs P_1)
	{
		int intValue = 0;
		Timer timer = new Timer
		{
			Enabled = false,
			Interval = 250
		};
		timer.Tick += delegate
		{
			picSaved.Visible = !picSaved.Visible;
			intValue++;
			if (intValue == 6)
			{
				intValue = 0;
				timer.Enabled = false;
			}
		};
		if (method_30())
		{
			if (lstQueue.Items.Count <= 0)
			{
				return;
			}
			Class48.smethod_23(Handle, this);
			switch (MetroMessageBox.Show(this, "Do you want to save changes to " + string_3 + "?", "KONAYUKI PLUS", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk))
			{
			case DialogResult.Yes:
				if (string_3 == "Untitled")
				{
					method_28();
				}
				else
				{
					method_11();
					File.WriteAllText(string_3, JsonConvert.SerializeObject(list_0, Formatting.Indented));
					timer.Enabled = true;
				}
				string_3 = "Untitled";
				lstQueue.Items.Clear();
				list_0.Clear();
				break;
			case DialogResult.No:
				string_3 = "Untitled";
				lstQueue.Items.Clear();
				list_0.Clear();
				break;
			}
		}
		else
		{
			string_3 = "Untitled";
			lstQueue.Items.Clear();
			list_0.Clear();
		}
	}

	private void tsmiOpenProject_Click(object P_0, EventArgs P_1)
	{
		string[] array = method_36("Open Project", Enum12.Value9, false);
		foreach (string path in array)
		{
			if (Class8.Project.Contains(Path.GetExtension(path).ToLower()))
			{
				string_3 = path;
				list_0.AddRange(JsonConvert.DeserializeObject<List<Class52>>(File.ReadAllText(path)));
				List<Class52> list = new List<Class52>();
				list = JsonConvert.DeserializeObject<List<Class52>>(File.ReadAllText(path));
				for (int j = 0; j < list.Count; j++)
				{
					lstQueue.Items.Add(new ListViewItem(new string[10]
					{
						list[j].File,
						list[j].Type,
						"Ready",
						null,
						null,
						list[j].Fullpath,
						list[j].Output,
						bool.FalseString,
						Class48.smethod_9(Path.Combine(list[j].Fullpath, list[j].File)),
						null
					})
					{
						Checked = list[j].Checked
					});
					list_0[lstQueue.Items.Count - 1].Audio.Track = method_9(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.MainPath = Class48.smethod_37();
					list_0[lstQueue.Items.Count - 1].System.Cores = Class18.smethod_1();
					list_0[lstQueue.Items.Count - 1].System.Threads = Class18.smethod_2();
					list_0[lstQueue.Items.Count - 1].System.Ram = Class18.smethod_0();
					list_0[lstQueue.Items.Count - 1].System.ScanType = class56_0.method_0(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.ScanMethod = class56_0.method_1(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.ScanOrder = class56_0.method_2(Path.Combine(list[j].Fullpath, list[j].File));
					list_0[lstQueue.Items.Count - 1].System.DAR = class56_0.method_3(Path.Combine(list[j].Fullpath, list[j].File));
				}
			}
		}
	}

	private void tsmiSaveProject_Click(object P_0, EventArgs P_1)
	{
		int intValue = 0;
		Timer timer = new Timer
		{
			Enabled = false,
			Interval = 250
		};
		timer.Tick += delegate
		{
			picSaved.Visible = !picSaved.Visible;
			intValue++;
			if (intValue == 6)
			{
				intValue = 0;
				timer.Enabled = false;
			}
		};
		if (string_3 == "Untitled")
		{
			if (Class48.smethod_3("KONAYUKI PLUS"))
			{
				method_28();
			}
		}
		else
		{
			method_11();
			File.WriteAllText(string_3, JsonConvert.SerializeObject(list_0, Formatting.Indented));
			timer.Enabled = true;
		}
	}

	private void tsmiSaveasProject_Click(object P_0, EventArgs P_1)
	{
		method_28();
	}

	private void tsmiEmptyFile_Click(object P_0, EventArgs P_1)
	{
		lstQueue.Items.Clear();
		list_0.Clear();
	}

	private void tsmiDeleteFile_Click(object P_0, EventArgs P_1)
	{
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (lstQueue.Items[i].Selected)
			{
				lstQueue.Items[i].Remove();
				list_0.RemoveAt(i);
				i--;
			}
		}
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

	private void picLogo_DoubleClick(object P_0, EventArgs P_1)
	{
		Process.Start("https://konayuki.moe");
	}

	private void tsmiOpenKonayuki_Click(object P_0, EventArgs P_1)
	{
		Show();
		WindowState = FormWindowState.Normal;
		Focus();
	}

	private void tsmiExit_Click(object P_0, EventArgs P_1)
	{
		method_1();
		Application.Exit();
	}

	private void tsmiAbout_Click(object P_0, EventArgs P_1)
	{
		if (!(Application.OpenForms["frmAbout"] is frmAbout))
		{
			frmAbout frmAbout2 = new frmAbout();
			frmAbout2.TopMost = TopMost;
			frmAbout2.ShowDialog(this);
		}
	}

	private void tsmiTrayAbout_Click(object P_0, EventArgs P_1)
	{
		if (!(Application.OpenForms["frmAbout"] is frmAbout))
		{
			frmAbout frmAbout2 = new frmAbout();
			frmAbout2.TopMost = TopMost;
			frmAbout2.ShowDialog(this);
		}
	}

	private void tsmiTraySettings_Click(object P_0, EventArgs P_1)
	{
		if (!(Application.OpenForms["frmConfigs"] is frmConfigs))
		{
			frmConfigs frmConfigs2 = new frmConfigs();
			frmConfigs2.TopMost = TopMost;
			frmConfigs2.ShowDialog(this);
		}
	}

	private void tsmiSettings_Click(object P_0, EventArgs P_1)
	{
		if (!(Application.OpenForms["frmConfigs"] is frmConfigs))
		{
			frmConfigs frmConfigs2 = new frmConfigs();
			frmConfigs2.TopMost = TopMost;
			frmConfigs2.ShowDialog(this);
		}
	}

	private void lstQueue_KeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyCode == Keys.A && P_1.Control)
		{
			foreach (ListViewItem item in lstQueue.Items)
			{
				item.Selected = true;
			}
		}
		if (P_1.KeyCode != Keys.Delete || bool_2)
		{
			return;
		}
		string text = bool.FalseString;
		foreach (ListViewItem item2 in lstQueue.Items)
		{
			if (item2.SubItems[7].Text == bool.TrueString)
			{
				text = bool.TrueString;
			}
		}
		if (bool_12 || !(text != bool.TrueString))
		{
			return;
		}
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (lstQueue.Items[i].Selected)
			{
				lstQueue.Items[i].Remove();
				list_0.RemoveAt(i);
				i--;
			}
		}
	}

	private void tsmiTroubleshooting_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Server.Help + "TROUBLESHOOTING.html");
	}

	private void txtOutput_ButtonClick(object P_0, EventArgs P_1)
	{
		Class15 @class = new Class15
		{
			Title = "Output Folder"
		};
		if (@class.method_0(this) == DialogResult.OK)
		{
			txtOutput.Text = @class.DirectoryPath;
		}
	}

	private void txtLog_LinkClicked(object P_0, LinkClickedEventArgs P_1)
	{
		Process.Start(P_1.LinkText);
	}

	private void cboAudioFormat_SelectedIndexChanged(object P_0, EventArgs P_1)
	{
		cboAudioQuality.Items.Clear();
		if (cboAudioFormat.SelectedIndex == 0)
		{
			ComboBox.ObjectCollection items = cboAudioQuality.Items;
			object[] items2 = new string[4] { "128 Kbps Dafault", "192 Kbps", "256 Kbps", "320 Kbps" };
			items.AddRange(items2);
			cboAudioQuality.Text = "128 Kbps Dafault";
			cboAudioSampleRates.Text = "Original";
			cboAudioQuality.Enabled = true;
			cboAudioSampleRates.Enabled = true;
		}
		else
		{
			ComboBox.ObjectCollection items3 = cboAudioQuality.Items;
			object[] items2 = new string[1] { "Same as source" };
			items3.AddRange(items2);
			cboAudioQuality.Text = "Same as source";
			cboAudioSampleRates.Text = "Original";
			cboAudioQuality.Enabled = false;
			cboAudioSampleRates.Enabled = false;
		}
	}

	private void btnCompare_Click(object P_0, EventArgs P_1)
	{
		ActiveControl = null;
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 1);
		p = button.PointToScreen(p);
		cmsControlQueue_8.Show(p);
	}

	private void btnPreview_MouseHover(object P_0, EventArgs P_1)
	{
		btnPreview.BringToFront();
	}

	private void btnCompare_MouseHover(object P_0, EventArgs P_1)
	{
		btnCompare.BringToFront();
	}

	private void method_37(object P_0, EventArgs P_1)
	{
		if (frmSplash.bool_0)
		{
			if (File.Exists(Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe"))
			{
				if (lstQueue.SelectedItems.Count <= 0)
				{
					return;
				}
				for (int i = 0; i < lstQueue.Items.Count; i++)
				{
					if (lstQueue.Items[i].Selected)
					{
						Process.Start(Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe", "\"" + Path.Combine(list_0[i].Fullpath, list_0[i].File) + "\"");
					}
				}
			}
			else
			{
				Class48.smethod_23(Handle, this);
				MetroMessageBox.Show(this, "Could not find file '" + Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else if (File.Exists(Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe"))
		{
			if (method_2(Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe"))
			{
				if (lstQueue.SelectedItems.Count <= 0)
				{
					return;
				}
				for (int j = 0; j < lstQueue.Items.Count; j++)
				{
					if (lstQueue.Items[j].Selected)
					{
						Process.Start(Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe", "\"" + Path.Combine(list_0[j].Fullpath, list_0[j].File) + "\"");
					}
				}
			}
			else
			{
				Class48.smethod_23(Handle, this);
				MetroMessageBox.Show(this, "File incorrect detected '" + Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		else
		{
			Class48.smethod_23(Handle, this);
			MetroMessageBox.Show(this, "Could not find file '" + Class48.smethod_37() + "\\codecs\\KonayukiInfo.exe'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void tsmiSetOutputFile_Click(object P_0, EventArgs P_1)
	{
		if (lstQueue.SelectedItems.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Title = "Output File",
				Filter = "File Types [Auto] (*.mp4;*.mkv)|*.mp4;*.mkv;",
				FileName = list_0[i].File
			};
			if (lstQueue.Items[i].Selected && saveFileDialog.ShowDialog(this) == DialogResult.OK && lstQueue.Items[i].Selected)
			{
				list_0[i].Output = saveFileDialog.FileName;
				lstQueue.Items[i].SubItems[6].Text = saveFileDialog.FileName;
			}
		}
	}

	private void tsmiSetOutputFolder_Click(object P_0, EventArgs P_1)
	{
		if (lstQueue.SelectedItems.Count <= 0)
		{
			return;
		}
		Class15 @class = new Class15
		{
			Title = "Output Folder"
		};
		if (@class.method_0(this) != DialogResult.OK)
		{
			return;
		}
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (lstQueue.Items[i].Selected && lstQueue.Items[i].Selected)
			{
				list_0[i].Output = @class.DirectoryPath;
				lstQueue.Items[i].SubItems[6].Text = @class.DirectoryPath;
			}
		}
	}

	private void tsmiClearOutput_Click(object P_0, EventArgs P_1)
	{
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (lstQueue.Items[i].Selected)
			{
				list_0[i].Output = "";
				lstQueue.Items[i].SubItems[6].Text = "";
			}
		}
	}

	private void tsmiPlayInput_Click(object P_0, EventArgs P_1)
	{
		if (lstQueue.SelectedItems.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (lstQueue.Items[i].Selected && File.Exists(Path.Combine(list_0[i].Fullpath, list_0[i].File)))
			{
				Process.Start(Path.Combine(list_0[i].Fullpath, list_0[i].File) ?? "");
			}
		}
	}

	private void tsmiOpenInput_Click(object P_0, EventArgs P_1)
	{
		if (lstQueue.SelectedItems.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (lstQueue.Items[i].Selected)
			{
				Process.Start("explorer.exe", "/select," + Path.Combine(list_0[i].Fullpath, list_0[i].File));
			}
		}
	}

	private void tsmiOpenOutput_Click(object P_0, EventArgs P_1)
	{
		if (lstQueue.SelectedItems.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (!lstQueue.Items[i].Selected)
			{
				continue;
			}
			if (lstQueue.Items[i].SubItems[6].Text != string.Empty)
			{
				if (Path.GetExtension(lstQueue.Items[i].SubItems[6].Text) != string.Empty)
				{
					Process.Start("explorer.exe", Path.GetDirectoryName(list_0[i].Output) ?? "");
				}
				else
				{
					Process.Start("explorer.exe", list_0[i].Output ?? "");
				}
			}
			else if (togSameInput.Checked)
			{
				Process.Start("explorer.exe", list_0[i].Fullpath ?? "");
			}
			else
			{
				Process.Start("explorer.exe", txtOutput.Text ?? "");
			}
		}
	}

	private void tsmiCompare1_Click(object P_0, EventArgs P_1)
	{
		tsmiDisable.Checked = false;
		tsmiCompare1.Checked = true;
		tsmiCompare2.Checked = false;
		tsmiCompare3.Checked = false;
		int_1 = 2;
		method_33();
	}

	private void tsmiCompare2_Click(object P_0, EventArgs P_1)
	{
		tsmiDisable.Checked = false;
		tsmiCompare1.Checked = false;
		tsmiCompare2.Checked = true;
		tsmiCompare3.Checked = false;
		int_1 = 3;
		method_33();
	}

	private void tsmiCompare3_Click(object P_0, EventArgs P_1)
	{
		tsmiDisable.Checked = false;
		tsmiCompare1.Checked = false;
		tsmiCompare2.Checked = false;
		tsmiCompare3.Checked = true;
		int_1 = 4;
		method_33();
	}

	private void togSameInput_CheckedChanged(object P_0, EventArgs P_1)
	{
		txtOutput.Enabled = !togSameInput.Checked;
	}

	private void tsmiRepair_Click(object P_0, EventArgs P_1)
	{
		File.Delete(Path.Combine(Class48.smethod_37(), "recent.json"));
		File.Delete(Path.Combine(Class48.smethod_37(), "configs.json"));
		method_3(false);
		frmSplash.bool_3 = true;
		frmSplash frmSplash2 = new frmSplash();
		frmSplash2.Show();
		Hide();
	}

	private void tsmiChangelog_Click(object P_0, EventArgs P_1)
	{
		if (!(Application.OpenForms["frmChangelog"] is frmChangelog))
		{
			frmChangelog frmChangelog2 = new frmChangelog();
			frmChangelog2.TopMost = TopMost;
			frmChangelog2.ShowDialog(this);
		}
	}

	private void lblLinkLineDarkener_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.LineDarkenerLink);
	}

	private void lblLinkSharpen_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.SharpenLink);
	}

	private void lblLinkWarpSharp_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.WarpSharpLink);
	}

	private void lblLinkRemover_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.NoiseRemoverLink);
	}

	private void lblLinkDebanding_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.DebandingLink);
	}

	private void lblTransitionLink_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.CustomTransitionLink);
	}

	private void lblLinkLogo_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.LogoLink);
	}

	private void lblRemoverLink_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.SubRemoverLink);
	}

	private void method_38(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.CrossInterlaceLink);
	}

	private void lblTroubleLink_Click(object P_0, EventArgs P_1)
	{
		Process.Start("https://m.me/Konayuki.moe");
	}

	private void btnMPC_Click(object P_0, EventArgs P_1)
	{
		method_4(1, true);
	}

	private void btnCompareMPC_Click(object P_0, EventArgs P_1)
	{
		ActiveControl = null;
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 1);
		p = button.PointToScreen(p);
		cmsControlQueue_9.Show(p);
	}

	private void tsmiCompareMPC1_Click(object P_0, EventArgs P_1)
	{
		method_4(2, true);
	}

	private void tsmiCompareMPC2_Click(object P_0, EventArgs P_1)
	{
		method_4(3, true);
	}

	private void tsmiCompareMPC3_Click(object P_0, EventArgs P_1)
	{
		method_4(4, true);
	}

	private void tsmiCompareMPC4_Click(object P_0, EventArgs P_1)
	{
		method_4(5, true);
	}

	private void tsmiDuplicate_Click(object P_0, EventArgs P_1)
	{
		foreach (ListViewItem item in lstQueue.Items)
		{
			if (item.Selected)
			{
				method_10(Path.Combine(list_0[item.Index].Fullpath, list_0[item.Index].File));
			}
		}
	}

	private void tsmiTUT_Click(object P_0, EventArgs P_1)
	{
		Process.Start(Class47.TutorialLink);
	}

	private void videoBox_MouseMove(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Y >= videoBox.Height - 52)
		{
			pnControl.Visible = true;
		}
		else
		{
			pnControl.Visible = false;
		}
	}

	private void splitMain_MouseMove(object P_0, MouseEventArgs P_1)
	{
	}

	private void btnPlay_Click(object P_0, EventArgs P_1)
	{
		if (Class5.IsPreview)
		{
			if (class6_0.TotalFrame == 0.0)
			{
				method_33();
			}
			else
			{
				class6_0.method_3();
			}
		}
		videoBox.Focus();
	}

	private void btnPause_Click(object P_0, EventArgs P_1)
	{
		class6_0.method_2();
		videoBox.Focus();
	}

	private void btnStoped_Click(object P_0, EventArgs P_1)
	{
		class6_0.method_7();
		videoBox.Focus();
	}

	private void btnDecreaseSpeed_Click(object P_0, EventArgs P_1)
	{
		videoBox.Focus();
		method_5(class6_0.PlayRate + "x");
		if (class6_0.PlayRate > 1.0)
		{
			class6_0.PlayRate -= 0.25;
		}
	}

	private void btnIncreaseSpeed_Click(object P_0, EventArgs P_1)
	{
		videoBox.Focus();
		method_5(class6_0.PlayRate + "x");
		if (class6_0.PlayRate < 10.0)
		{
			class6_0.PlayRate += 0.25;
		}
	}

	private void btnPreviousFrame_Click(object P_0, EventArgs P_1)
	{
		videoBox.Focus();
		class6_0.method_2();
		method_5(tbSeek.Value + "/" + int_2);
		class6_0.method_23();
	}

	private void btnNextFrame_Click(object P_0, EventArgs P_1)
	{
		videoBox.Focus();
		class6_0.method_2();
		method_5(tbSeek.Value + "/" + int_2);
		class6_0.method_22();
	}

	[DllImport("user32.dll")]
	public static extern IntPtr SetParent(IntPtr P_0, IntPtr P_1);

	public void method_39()
	{
		videoBox.Focus();
		if (!bool_4)
		{
			bool_4 = true;
		}
		else
		{
			bool_4 = false;
		}
		if (bool_4)
		{
			WindowState = FormWindowState.Normal;
			FormBorderStyle = FormBorderStyle.None;
			Bounds = Screen.PrimaryScreen.Bounds;
			videoBox.Dock = DockStyle.None;
			pnControl.Dock = DockStyle.None;
			videoBox.Width = Bounds.Width;
			videoBox.Height = Bounds.Height;
			pnControl.Width = Bounds.Width;
			pnControl.Location = new Point(0, Bounds.Height - pnControl.Height);
			pnGoto.Location = new Point(Bounds.Width / 2 - pnGoto.Width / 2, Bounds.Height / 2 - pnGoto.Height / 2);
			SetParent(videoBox.Handle, Handle);
			SetParent(pnControl.Handle, Handle);
			SetParent(pnGoto.Handle, Handle);
		}
		else
		{
			Size = new Size(class52_0.Width, class52_0.Height);
			CenterToScreen();
			SetParent(videoBox.Handle, tpPreview.Handle);
			SetParent(pnControl.Handle, tpPreview.Handle);
			SetParent(pnGoto.Handle, tpPreview.Handle);
			videoBox.Dock = DockStyle.Fill;
			pnControl.Width = videoBox.Width;
			pnControl.Location = new Point(0, videoBox.Height - pnControl.Height);
			pnGoto.Location = new Point(videoBox.Width / 2 - pnGoto.Width / 2, videoBox.Height / 2 - pnGoto.Height / 2);
		}
	}

	private void btnFullScreen_Click(object P_0, EventArgs P_1)
	{
		method_39();
	}

	private void btnFonts_Click(object P_0, EventArgs P_1)
	{
		for (int i = 0; i < lstQueue.Items.Count; i++)
		{
			if (File.Exists(list_0[i].Subtitle.File))
			{
				frmFonts.files.Add(list_0[i].Subtitle.File);
			}
			if (File.Exists(list_0[i].Karaoke.OP))
			{
				frmFonts.files.Add(list_0[i].Karaoke.OP);
			}
			if (File.Exists(list_0[i].Karaoke.ED))
			{
				frmFonts.files.Add(list_0[i].Karaoke.ED);
			}
			if (File.Exists(list_0[i].Advance.Logo.ASS.File))
			{
				frmFonts.files.Add(list_0[i].Advance.Logo.ASS.File);
			}
		}
		new frmFonts().ShowDialog(this);
		method_33();
	}

	private void btnComp_Click(object P_0, EventArgs P_1)
	{
		Button button = (Button)P_0;
		Point p = new Point(0, button.Height + 2);
		p = button.PointToScreen(p);
		cmsControlQueue_8.Show(p);
	}

	private void tbSeek_MouseDown(object P_0, MouseEventArgs P_1)
	{
		bool_6 = true;
	}

	private void tbSeek_MouseUp(object P_0, MouseEventArgs P_1)
	{
		bool_6 = false;
	}

	private void tbSeek_ValueChanged(object P_0, EventArgs P_1)
	{
		if (bool_6 && class6_0.TotalFrame != 0.0)
		{
			Application.DoEvents();
			if (Class5.FPSNum == "0" || Class5.FPSDen == "0" || cboVideoSmooth.SelectedIndex > 0)
			{
				double num = (double)tbSeek.Value / double.Parse(class6_0.method_11());
				double currentPosition = Math.Floor(num * 1000.0) / 1000.0;
				class6_0.CurrentPosition = currentPosition;
			}
			else
			{
				double num2 = (double)tbSeek.Value / (double.Parse(Class5.FPSNum) / double.Parse(Class5.FPSDen));
				double currentPosition2 = Math.Floor(num2 * 1000.0) / 1000.0;
				class6_0.CurrentPosition = currentPosition2;
			}
			toolTip_0.SetToolTip(tbSeek, TimeSpan.FromSeconds(class6_0.method_16()).ToString("hh\\:mm\\:ss\\.fff"));
		}
	}

	private void btnReset_Click(object P_0, EventArgs P_1)
	{
		if (lstQueue.SelectedItems.Count > 0)
		{
			method_19();
			method_12(lstQueue.Items.IndexOf(lstQueue.SelectedItems[0]));
			method_18(lstQueue.Items.IndexOf(lstQueue.SelectedItems[0]));
			method_33(true);
		}
	}

	private void tbVolume_ValueChanged(object P_0, EventArgs P_1)
	{
		if (tbVolume.Value == 50)
		{
			btnMute.Tag = "off";
			class6_0.Volume = 0;
			btnMute.BackgroundImage = Resources.mute_off;
		}
		else
		{
			btnMute.Tag = "on";
			class6_0.Volume = tbVolume.Value;
			btnMute.BackgroundImage = Resources.mute_on;
		}
		class6_0.method_18();
		toolTip_0.SetToolTip(tbVolume, ((tbVolume.Value - 50) * 100 / 50).ToString());
	}

	private void videoBox_MouseDoubleClick(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Button == MouseButtons.Left)
		{
			method_39();
			videoBox.Focus();
			class6_0.method_8();
		}
	}

	private void frmMain_KeyDown(object P_0, KeyEventArgs P_1)
	{
		if (!bool_4)
		{
			return;
		}
		if (class6_0.TotalFrame != 0.0)
		{
			switch (P_1.KeyCode)
			{
			case Keys.Space:
				videoBox.Focus();
				class6_0.method_8();
				break;
			case Keys.Left:
				videoBox.Focus();
				class6_0.method_2();
				method_5(tbSeek.Value + "/" + int_2);
				class6_0.method_23();
				break;
			case Keys.Right:
				videoBox.Focus();
				class6_0.method_2();
				method_5(tbSeek.Value + "/" + int_2);
				class6_0.method_22();
				break;
			case Keys.Up:
				videoBox.Focus();
				method_5(class6_0.PlayRate + "x");
				if (class6_0.PlayRate < 10.0)
				{
					class6_0.PlayRate += 0.25;
				}
				break;
			case Keys.Down:
				videoBox.Focus();
				method_5(class6_0.PlayRate + "x");
				if (class6_0.PlayRate > 1.0)
				{
					class6_0.PlayRate -= 0.25;
				}
				break;
			case Keys.G:
				pnGoto.Visible = !pnGoto.Visible;
				break;
			case Keys.M:
				videoBox.Focus();
				method_40();
				break;
			case Keys.Return:
			case Keys.Escape:
			case Keys.F:
				videoBox.Focus();
				method_39();
				break;
			}
		}
		else
		{
			Keys keyCode = P_1.KeyCode;
			Keys keys = keyCode;
			if (keys == Keys.Return || keys == Keys.Escape || keys == Keys.F)
			{
				videoBox.Focus();
				method_39();
			}
		}
	}

	private void method_40()
	{
		class6_0.method_19();
		if (btnMute.Tag.ToString() == "on")
		{
			btnMute.Tag = "off";
			btnMute.BackgroundImage = Resources.mute_off;
		}
		else
		{
			btnMute.Tag = "on";
			btnMute.BackgroundImage = Resources.mute_on;
		}
	}

	private void btnMute_Click(object P_0, EventArgs P_1)
	{
		method_40();
	}

	private void videoBox_MouseClick(object P_0, MouseEventArgs P_1)
	{
		if (P_1.Button == MouseButtons.Left)
		{
			class6_0.method_8();
		}
	}

	private void tsmiDisable_Click(object P_0, EventArgs P_1)
	{
		tsmiDisable.Checked = true;
		tsmiCompare1.Checked = false;
		tsmiCompare2.Checked = false;
		tsmiCompare3.Checked = false;
		int_1 = 1;
		method_33();
	}

	private void txtGoToFrame_KeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyCode != Keys.Return)
		{
			return;
		}
		try
		{
			Application.DoEvents();
			if ((double)int.Parse(txtGoToFrame.Text) < class6_0.TotalFrame)
			{
				if (Class5.FPSNum == "0" || Class5.FPSDen == "0" || cboVideoSmooth.SelectedIndex > 0)
				{
					double num = (double)int.Parse(txtGoToFrame.Text) / double.Parse(class6_0.method_11());
					double currentPosition = Math.Floor(num * 1000.0) / 1000.0;
					class6_0.CurrentPosition = currentPosition;
				}
				else
				{
					double num2 = (double)int.Parse(txtGoToFrame.Text) / (double.Parse(Class5.FPSNum) / double.Parse(Class5.FPSDen));
					double currentPosition2 = Math.Floor(num2 * 1000.0) / 1000.0;
					class6_0.CurrentPosition = currentPosition2;
				}
			}
			else
			{
				MessageBox.Show("The entered time is greater than the file duration", "MsgBox", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		catch
		{
		}
		pnGoto.Visible = false;
	}

	private void btnGoTo_Click(object P_0, EventArgs P_1)
	{
		if (class6_0.TotalFrame != 0.0)
		{
			pnGoto.Visible = !pnGoto.Visible;
			txtGoToFrame.Text = tbSeek.Value.ToString();
			pnGoto.Focus();
		}
	}

	private void udIntroTime_KeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyCode != Keys.Up && P_1.KeyCode != Keys.Down && P_1.KeyCode != Keys.Left && P_1.KeyCode != Keys.Right)
		{
			method_33(true);
		}
	}

	private void udEndCardTime_KeyDown(object P_0, KeyEventArgs P_1)
	{
		if (P_1.KeyCode != Keys.Up && P_1.KeyCode != Keys.Down && P_1.KeyCode != Keys.Left && P_1.KeyCode != Keys.Right)
		{
			method_33(true);
		}
	}

	private void cboVideoSmooth_DropDownClosed(object P_0, EventArgs P_1)
	{
		method_33(true);
	}

	private void btnGotoExit_Click(object P_0, EventArgs P_1)
	{
		pnGoto.Visible = false;
	}

	private void togPreview_MouseUp(object P_0, MouseEventArgs P_1)
	{
		if (togPreview.Checked)
		{
			Class5.IsPreview = true;
			method_33();
		}
		else
		{
			class6_0.method_15();
			videoBox.Image = Resources.player_off;
			Class12.smethod_2();
		}
	}

	private void togIntro_MouseUp(object P_0, MouseEventArgs P_1)
	{
		method_33(true);
	}

	private void togEndCard_MouseUp(object P_0, MouseEventArgs P_1)
	{
		method_33(true);
	}

	private void udIntroTime_MouseUp(object P_0, MouseEventArgs P_1)
	{
		method_33(true);
	}

	private void udEndCardTime_MouseUp(object P_0, MouseEventArgs P_1)
	{
		method_33(true);
	}

	private void frmMain_DragLeave(object P_0, EventArgs P_1)
	{
	}

	private void frmMain_ResizeBegin(object P_0, EventArgs P_1)
	{
		Opacity = 0.75;
	}

	private void frmMain_ResizeEnd(object P_0, EventArgs P_1)
	{
		Opacity = 1.0;
	}

	private void picWait_MouseDown(object P_0, MouseEventArgs P_1)
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonayukiPlus.frmMain));
		this.cmsControlQueue = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiPause = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiSkip = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiStop = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiStopAfterCurrent = new System.Windows.Forms.ToolStripMenuItem();
		this.lstQueue = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_2 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_3 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_4 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_1 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_5 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_6 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_7 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_8 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_9 = new System.Windows.Forms.ColumnHeader();
		this.cmsControlQueue_3 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiPlayInput = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiSetOutputFile = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiSetOutputFolder = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiClearOutput = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiOpenInput = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiOpenOutput = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiDuplicate = new System.Windows.Forms.ToolStripMenuItem();
		this.tvDetails = new System.Windows.Forms.TreeView();
		this.txtOutput = new MetroFramework.Controls.MetroTextBox();
		this.togSameInput = new MetroFramework.Controls.MetroToggle();
		this.lblSameInput = new MetroFramework.Controls.MetroLabel();
		this.lblOutput = new MetroFramework.Controls.MetroLabel();
		this.tpSpecial = new MetroFramework.Controls.MetroTabPage();
		this.grpHardSubRemover = new System.Windows.Forms.GroupBox();
		this.lblRemoverLevel2Level = new MetroFramework.Controls.MetroLabel();
		this.lblRemoverLevel2 = new MetroFramework.Controls.MetroLabel();
		this.tbRemoverLevel2 = new MetroFramework.Controls.MetroTrackBar();
		this.togHardSubRemover = new MetroFramework.Controls.MetroToggle();
		this.lblRemoverLink = new MetroFramework.Controls.MetroLink();
		this.lblRemoverTUT = new MetroFramework.Controls.MetroLabel();
		this.lblRemoverLevel1Level = new MetroFramework.Controls.MetroLabel();
		this.lblRemoverLevel1 = new MetroFramework.Controls.MetroLabel();
		this.tbRemoverLevel1 = new MetroFramework.Controls.MetroTrackBar();
		this.udRemoverRight = new System.Windows.Forms.NumericUpDown();
		this.lblRemoverRight = new MetroFramework.Controls.MetroLabel();
		this.udRemoverLeft = new System.Windows.Forms.NumericUpDown();
		this.lblRemoverLeft = new MetroFramework.Controls.MetroLabel();
		this.udRemoverBottom = new System.Windows.Forms.NumericUpDown();
		this.lblRemoverBottom = new MetroFramework.Controls.MetroLabel();
		this.lblObjectRemove = new MetroFramework.Controls.MetroLabel();
		this.udRemoverTop = new System.Windows.Forms.NumericUpDown();
		this.lblRemoverTop = new MetroFramework.Controls.MetroLabel();
		this.lblHardSubRemover = new MetroFramework.Controls.MetroLabel();
		this.tpLogo = new MetroFramework.Controls.MetroTabPage();
		this.groupBox19 = new System.Windows.Forms.GroupBox();
		this.togLogoSubtitle = new MetroFramework.Controls.MetroToggle();
		this.txtLogoSubtitle = new MetroFramework.Controls.MetroTextBox();
		this.lblLogoSubtitleFile = new MetroFramework.Controls.MetroLabel();
		this.lblLogoSubtitle = new MetroFramework.Controls.MetroLabel();
		this.grpLogo = new System.Windows.Forms.GroupBox();
		this.lblLinkLogo = new MetroFramework.Controls.MetroLink();
		this.togLogo = new MetroFramework.Controls.MetroToggle();
		this.lblHowtoUse = new MetroFramework.Controls.MetroLabel();
		this.grpLogoSetting = new System.Windows.Forms.GroupBox();
		this.pLogoFadeColor = new System.Windows.Forms.Panel();
		this.btnLogoFadeColor = new MetroFramework.Controls.MetroButton();
		this.lblLogoOpacityLevel = new MetroFramework.Controls.MetroLabel();
		this.lblLogoOpacity = new MetroFramework.Controls.MetroLabel();
		this.tbLogoOpacity = new MetroFramework.Controls.MetroTrackBar();
		this.lblLogoBlend = new MetroFramework.Controls.MetroLabel();
		this.cboLogoBlend = new MetroFramework.Controls.MetroComboBox();
		this.lblLogoSetting = new MetroFramework.Controls.MetroLabel();
		this.groupBox21 = new System.Windows.Forms.GroupBox();
		this.lblLogoTimeAlways = new MetroFramework.Controls.MetroLabel();
		this.togLogoTime = new MetroFramework.Controls.MetroToggle();
		this.lblLogoShowTimeMinute = new MetroFramework.Controls.MetroLabel();
		this.lblLogoTime = new MetroFramework.Controls.MetroLabel();
		this.udLogoTimeSecMinute = new System.Windows.Forms.NumericUpDown();
		this.lblLogoShowTime = new MetroFramework.Controls.MetroLabel();
		this.udLogoTimeSec = new System.Windows.Forms.NumericUpDown();
		this.lblLogoShowTimeSec = new MetroFramework.Controls.MetroLabel();
		this.txtLogo = new MetroFramework.Controls.MetroTextBox();
		this.lblLogoFile = new MetroFramework.Controls.MetroLabel();
		this.lblLogo = new MetroFramework.Controls.MetroLabel();
		this.tpTransition = new MetroFramework.Controls.MetroTabPage();
		this.cboTransition = new MetroFramework.Controls.MetroComboBox();
		this.lblTransition = new MetroFramework.Controls.MetroLabel();
		this.pnFadeAll = new MetroFramework.Controls.MetroPanel();
		this.pnFade = new MetroFramework.Controls.MetroPanel();
		this.grpEndCardFadeOut = new System.Windows.Forms.GroupBox();
		this.lblEndCardFadeOutTime = new MetroFramework.Controls.MetroLabel();
		this.pEndCardOutColor = new System.Windows.Forms.Panel();
		this.lblEndCardFadeOutTimeSec = new MetroFramework.Controls.MetroLabel();
		this.togEndCardOut = new MetroFramework.Controls.MetroToggle();
		this.lblIntroEndCardOut = new MetroFramework.Controls.MetroLabel();
		this.btnEndCardFadeOutColor = new MetroFramework.Controls.MetroButton();
		this.udEndCardFadeOutTime = new System.Windows.Forms.NumericUpDown();
		this.grpSourceFadeOut = new System.Windows.Forms.GroupBox();
		this.lblSourceFadeOutTime = new MetroFramework.Controls.MetroLabel();
		this.pSourceOutColor = new System.Windows.Forms.Panel();
		this.lblSourceFadeOutTimeSec = new MetroFramework.Controls.MetroLabel();
		this.togSourceOut = new MetroFramework.Controls.MetroToggle();
		this.lblIntroSourceOut = new MetroFramework.Controls.MetroLabel();
		this.btnSourceFadeOutColor = new MetroFramework.Controls.MetroButton();
		this.udSourceFadeOutTime = new System.Windows.Forms.NumericUpDown();
		this.grpEndCardFadeIn = new System.Windows.Forms.GroupBox();
		this.lblEndCardFadeInTime = new MetroFramework.Controls.MetroLabel();
		this.pEndCardInColor = new System.Windows.Forms.Panel();
		this.lblEndCardFadeInTimeSec = new MetroFramework.Controls.MetroLabel();
		this.togEndCardIn = new MetroFramework.Controls.MetroToggle();
		this.lblIntroEndCardIn = new MetroFramework.Controls.MetroLabel();
		this.btnEndCardFadeInColor = new MetroFramework.Controls.MetroButton();
		this.udEndCardFadeInTime = new System.Windows.Forms.NumericUpDown();
		this.grpSourceFadeIn = new System.Windows.Forms.GroupBox();
		this.lblSourceFadeInTime = new MetroFramework.Controls.MetroLabel();
		this.pSourceInColor = new System.Windows.Forms.Panel();
		this.lblSourceFadeInTimeSec = new MetroFramework.Controls.MetroLabel();
		this.togSourceIn = new MetroFramework.Controls.MetroToggle();
		this.lblIntroSourceIn = new MetroFramework.Controls.MetroLabel();
		this.btnSourceFadeInColor = new MetroFramework.Controls.MetroButton();
		this.udSourceFadeInTime = new System.Windows.Forms.NumericUpDown();
		this.grpIntroFadeOut = new System.Windows.Forms.GroupBox();
		this.lblIntroFadeOutTime = new MetroFramework.Controls.MetroLabel();
		this.pFadeOutColor = new System.Windows.Forms.Panel();
		this.lblIntroFadeOutTimeSec = new MetroFramework.Controls.MetroLabel();
		this.togFadeOut = new MetroFramework.Controls.MetroToggle();
		this.lblIntroFadeOut = new MetroFramework.Controls.MetroLabel();
		this.btnIntroFadeOutColor = new MetroFramework.Controls.MetroButton();
		this.udIntroFadeOutTime = new System.Windows.Forms.NumericUpDown();
		this.grpIntroFadeIn = new System.Windows.Forms.GroupBox();
		this.lblIntroFadeInTime = new MetroFramework.Controls.MetroLabel();
		this.pFadeInColor = new System.Windows.Forms.Panel();
		this.lblIntroFadeInTimeSec = new MetroFramework.Controls.MetroLabel();
		this.togFadeIn = new MetroFramework.Controls.MetroToggle();
		this.lblIntroFadeIn = new MetroFramework.Controls.MetroLabel();
		this.btnIntroFadeInColor = new MetroFramework.Controls.MetroButton();
		this.udIntroFadeInTime = new System.Windows.Forms.NumericUpDown();
		this.pnDissolveAll = new MetroFramework.Controls.MetroPanel();
		this.grpDissolve = new System.Windows.Forms.GroupBox();
		this.lblDissolveTime = new MetroFramework.Controls.MetroLabel();
		this.lblDissolveTimeSec = new MetroFramework.Controls.MetroLabel();
		this.udDissolveTime = new System.Windows.Forms.NumericUpDown();
		this.lblDissolveControl = new MetroFramework.Controls.MetroLabel();
		this.lblDissolveFadeOutTime = new MetroFramework.Controls.MetroLabel();
		this.udDissolveFadeInTime = new System.Windows.Forms.NumericUpDown();
		this.lblDissolveFadeOutTimeSec = new MetroFramework.Controls.MetroLabel();
		this.lblDissolveFadeInTimeSec = new MetroFramework.Controls.MetroLabel();
		this.udDissolveFadeOutTime = new System.Windows.Forms.NumericUpDown();
		this.lblDissolveFadeInTime = new MetroFramework.Controls.MetroLabel();
		this.pnTransition = new MetroFramework.Controls.MetroPanel();
		this.lblTransitionLink = new MetroFramework.Controls.MetroLink();
		this.lblTransitionTUT = new MetroFramework.Controls.MetroLabel();
		this.grpTransitionEndCard = new System.Windows.Forms.GroupBox();
		this.chkEndCardTransitionOverlay = new MetroFramework.Controls.MetroCheckBox();
		this.lblEndCardTransitionFile = new MetroFramework.Controls.MetroLabel();
		this.lblEndCardTransition = new MetroFramework.Controls.MetroLabel();
		this.lblEndCardTransitionAudioSec = new MetroFramework.Controls.MetroLabel();
		this.lblEndCardTransitionAudio = new MetroFramework.Controls.MetroLabel();
		this.udEndCardTransitionAudioTime = new System.Windows.Forms.NumericUpDown();
		this.txtEndCardTransitionOverlay = new MetroFramework.Controls.MetroTextBox();
		this.txtEndCardTransition = new MetroFramework.Controls.MetroTextBox();
		this.grpTransitionIntro = new System.Windows.Forms.GroupBox();
		this.chkIntroTransitionOverlay = new MetroFramework.Controls.MetroCheckBox();
		this.lblIntroTransitionFile = new MetroFramework.Controls.MetroLabel();
		this.lblIntroTransition = new MetroFramework.Controls.MetroLabel();
		this.lblIntroTransitionAudioSec = new MetroFramework.Controls.MetroLabel();
		this.lblIntroTransitionAudio = new MetroFramework.Controls.MetroLabel();
		this.udIntroTransitionAudioTime = new System.Windows.Forms.NumericUpDown();
		this.txtIntroTransitionOverlay = new MetroFramework.Controls.MetroTextBox();
		this.txtIntroTransition = new MetroFramework.Controls.MetroTextBox();
		this.tpVideo = new MetroFramework.Controls.MetroTabPage();
		this.grpColorEnhancer = new System.Windows.Forms.GroupBox();
		this.lblLinkDebanding = new MetroFramework.Controls.MetroLink();
		this.lblColorSaturationLevel = new MetroFramework.Controls.MetroLabel();
		this.lblColorContrastLevel = new MetroFramework.Controls.MetroLabel();
		this.lblColorSaturation = new MetroFramework.Controls.MetroLabel();
		this.tbColorSaturation = new MetroFramework.Controls.MetroTrackBar();
		this.lblColorContrast = new MetroFramework.Controls.MetroLabel();
		this.tbColorContrast = new MetroFramework.Controls.MetroTrackBar();
		this.lblColorEnhancer = new MetroFramework.Controls.MetroLabel();
		this.lblColorDebanding = new MetroFramework.Controls.MetroLabel();
		this.cboColorDebanding = new MetroFramework.Controls.MetroComboBox();
		this.lblColorBrightnessLevel = new MetroFramework.Controls.MetroLabel();
		this.lblColorBrightness = new MetroFramework.Controls.MetroLabel();
		this.tbColorBrightness = new MetroFramework.Controls.MetroTrackBar();
		this.grpVideoEnhancer = new System.Windows.Forms.GroupBox();
		this.lblVideoSmooth = new MetroFramework.Controls.MetroLabel();
		this.cboVideoSmooth = new MetroFramework.Controls.MetroComboBox();
		this.lblVideoResize = new MetroFramework.Controls.MetroLabel();
		this.lblLinkRemover = new MetroFramework.Controls.MetroLink();
		this.lblLinkWarpSharp = new MetroFramework.Controls.MetroLink();
		this.lblLinkSharpen = new MetroFramework.Controls.MetroLink();
		this.lblLinkLineDarkener = new MetroFramework.Controls.MetroLink();
		this.lblVideoWarpSharpLevel = new MetroFramework.Controls.MetroLabel();
		this.lblVideoSharpenLevel = new MetroFramework.Controls.MetroLabel();
		this.lblVideoWarpSharp = new MetroFramework.Controls.MetroLabel();
		this.tbVideoWarpSharp = new MetroFramework.Controls.MetroTrackBar();
		this.lblVideoSharpen = new MetroFramework.Controls.MetroLabel();
		this.tbVideoSharpen = new MetroFramework.Controls.MetroTrackBar();
		this.lblVideoEnhancer = new MetroFramework.Controls.MetroLabel();
		this.lblVideoNoiseRemover = new MetroFramework.Controls.MetroLabel();
		this.cboVideoRemover = new MetroFramework.Controls.MetroComboBox();
		this.lblVideoLineDarkenerLevel = new MetroFramework.Controls.MetroLabel();
		this.lblVideoLineDarkener = new MetroFramework.Controls.MetroLabel();
		this.tbVideoLineDarkener = new MetroFramework.Controls.MetroTrackBar();
		this.cboVideoResize = new MetroFramework.Controls.MetroComboBox();
		this.grpVideoSetting = new System.Windows.Forms.GroupBox();
		this.lblVideoPreset = new MetroFramework.Controls.MetroLabel();
		this.cboVideoPreset = new MetroFramework.Controls.MetroComboBox();
		this.lblVideoQualityLevel = new MetroFramework.Controls.MetroLabel();
		this.lblVideoQuality = new MetroFramework.Controls.MetroLabel();
		this.tbVideo = new MetroFramework.Controls.MetroTrackBar();
		this.lblVideoEncoder = new MetroFramework.Controls.MetroLabel();
		this.cboVideoEncoder = new MetroFramework.Controls.MetroComboBox();
		this.lblVideoSetting = new MetroFramework.Controls.MetroLabel();
		this.tpLog = new MetroFramework.Controls.MetroTabPage();
		this.pnLog = new System.Windows.Forms.Panel();
		this.txtLog = new System.Windows.Forms.RichTextBox();
		this.lblTroubleLink = new MetroFramework.Controls.MetroLink();
		this.lblTrouble = new MetroFramework.Controls.MetroLabel();
		this.tpAudio = new MetroFramework.Controls.MetroTabPage();
		this.grpVolumeControl = new System.Windows.Forms.GroupBox();
		this.lblVolumeEndCardLevel = new MetroFramework.Controls.MetroLabel();
		this.lblVolumeEndCard = new MetroFramework.Controls.MetroLabel();
		this.tbVolumeEndCard = new MetroFramework.Controls.MetroTrackBar();
		this.lblVolumeIntroLevel = new MetroFramework.Controls.MetroLabel();
		this.lblVolumeIntro = new MetroFramework.Controls.MetroLabel();
		this.tbVolumeIntro = new MetroFramework.Controls.MetroTrackBar();
		this.lblVolumeControl = new MetroFramework.Controls.MetroLabel();
		this.lblVolumeSourceLevel = new MetroFramework.Controls.MetroLabel();
		this.lblVolumeSource = new MetroFramework.Controls.MetroLabel();
		this.tbVolumeSource = new MetroFramework.Controls.MetroTrackBar();
		this.grpAudioSetting = new System.Windows.Forms.GroupBox();
		this.lblAudioTrack = new MetroFramework.Controls.MetroLabel();
		this.cboAudioTrack = new MetroFramework.Controls.MetroComboBox();
		this.cboAudioSampleRates = new MetroFramework.Controls.MetroComboBox();
		this.lblAudioQuality = new MetroFramework.Controls.MetroLabel();
		this.cboAudioQuality = new MetroFramework.Controls.MetroComboBox();
		this.lblAudioFormat = new MetroFramework.Controls.MetroLabel();
		this.cboAudioFormat = new MetroFramework.Controls.MetroComboBox();
		this.lblAudioSetting = new MetroFramework.Controls.MetroLabel();
		this.cboAudioTrack2 = new MetroFramework.Controls.MetroComboBox();
		this.tpMain = new MetroFramework.Controls.MetroTabPage();
		this.splitIntroEndCard = new System.Windows.Forms.TableLayoutPanel();
		this.grpIntro = new System.Windows.Forms.GroupBox();
		this.chkIntroMusic = new MetroFramework.Controls.MetroCheckBox();
		this.togIntro = new MetroFramework.Controls.MetroToggle();
		this.lblIntroTimeSec = new MetroFramework.Controls.MetroLabel();
		this.udIntroTime = new System.Windows.Forms.NumericUpDown();
		this.lblIntroTime = new MetroFramework.Controls.MetroLabel();
		this.lblIntro = new MetroFramework.Controls.MetroLabel();
		this.txtIntroMusic = new MetroFramework.Controls.MetroTextBox();
		this.txtIntro = new MetroFramework.Controls.MetroTextBox();
		this.grpEndCard = new System.Windows.Forms.GroupBox();
		this.chkEndCardMusic = new MetroFramework.Controls.MetroCheckBox();
		this.togEndCard = new MetroFramework.Controls.MetroToggle();
		this.lblEndCardTimeSec = new MetroFramework.Controls.MetroLabel();
		this.udEndCardTime = new System.Windows.Forms.NumericUpDown();
		this.lblEndCardTime = new MetroFramework.Controls.MetroLabel();
		this.lblEndCard = new MetroFramework.Controls.MetroLabel();
		this.txtEndCardMusic = new MetroFramework.Controls.MetroTextBox();
		this.txtEndCard = new MetroFramework.Controls.MetroTextBox();
		this.grpClipDetails = new System.Windows.Forms.GroupBox();
		this.togClipDetails = new MetroFramework.Controls.MetroToggle();
		this.lblClipDeailsName = new MetroFramework.Controls.MetroLabel();
		this.lblClipDetails = new MetroFramework.Controls.MetroLabel();
		this.txtClipDeailsAuthor = new MetroFramework.Controls.MetroTextBox();
		this.lblClipDeailsAuthor = new MetroFramework.Controls.MetroLabel();
		this.txtClipDeailsName = new MetroFramework.Controls.MetroTextBox();
		this.grpKaraoke = new System.Windows.Forms.GroupBox();
		this.togKaraoke = new MetroFramework.Controls.MetroToggle();
		this.lblKaraoke = new MetroFramework.Controls.MetroLabel();
		this.txtKaraokeED = new MetroFramework.Controls.MetroTextBox();
		this.txtKaraokeOP = new MetroFramework.Controls.MetroTextBox();
		this.chkKaraokeOP = new MetroFramework.Controls.MetroCheckBox();
		this.chkKaraokeED = new MetroFramework.Controls.MetroCheckBox();
		this.grpSubtitle = new System.Windows.Forms.GroupBox();
		this.togSubtitle = new MetroFramework.Controls.MetroToggle();
		this.lblSubtitle = new MetroFramework.Controls.MetroLabel();
		this.lblSubtitleFile = new MetroFramework.Controls.MetroLabel();
		this.txtSubtitle = new MetroFramework.Controls.MetroTextBox();
		this.tcQueue = new MetroFramework.Controls.MetroTabControl();
		this.togOntop = new MetroFramework.Controls.MetroToggle();
		this.cmsControlQueue_2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiAddFiles = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiAddFolder = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiNewProject = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiOpenProject = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiSaveProject = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiSaveasProject = new System.Windows.Forms.ToolStripMenuItem();
		this.cmsControlQueue_4 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiTUT = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiChangelog = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiTroubleshooting = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
		this.psProgress = new MetroFramework.Controls.MetroProgressSpinner();
		this.lblOntop = new MetroFramework.Controls.MetroLabel();
		this.cmsControlQueue_5 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiEmptyFile = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
		this.cmsControlQueue_6 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiOpenKonayuki = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiTraySettings = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiTrayLanguage = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiTrayApiVersion = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiTrayAbout = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
		this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
		this.cmsControlQueue_7 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiRepair = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiLanguage = new System.Windows.Forms.ToolStripMenuItem();
		this.cmsControlQueue_8 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiDisable = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiCompare1 = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiCompare2 = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiCompare3 = new System.Windows.Forms.ToolStripMenuItem();
		this.cmsControlQueue_9 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.tsmiCompareMPC1 = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiCompareMPC2 = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiCompareMPC3 = new System.Windows.Forms.ToolStripMenuItem();
		this.tsmiCompareMPC4 = new System.Windows.Forms.ToolStripMenuItem();
		this.splitMain = new System.Windows.Forms.TableLayoutPanel();
		this.tcPlayer = new MetroFramework.Controls.MetroTabControl();
		this.tpPreview = new MetroFramework.Controls.MetroTabPage();
		this.pnGoto = new System.Windows.Forms.Panel();
		this.lblGoToHelp = new MetroFramework.Controls.MetroLabel();
		this.btnGotoExit = new System.Windows.Forms.Button();
		this.txtGoToFrame = new MetroFramework.Controls.MetroTextBox();
		this.lblGoToFrame = new MetroFramework.Controls.MetroLabel();
		this.pnControl = new System.Windows.Forms.Panel();
		this.btnGoTo = new System.Windows.Forms.Button();
		this.tbVolume = new MetroFramework.Controls.MetroTrackBar();
		this.btnMute = new System.Windows.Forms.Button();
		this.panel2 = new System.Windows.Forms.Panel();
		this.btnFullScreen = new System.Windows.Forms.Button();
		this.btnPause = new System.Windows.Forms.Button();
		this.btnPlay = new System.Windows.Forms.Button();
		this.tbSeek = new MetroFramework.Controls.MetroTrackBar();
		this.btnStoped = new System.Windows.Forms.Button();
		this.panel1 = new System.Windows.Forms.Panel();
		this.btnNextFrame = new System.Windows.Forms.Button();
		this.btnDecreaseSpeed = new System.Windows.Forms.Button();
		this.btnPreviousFrame = new System.Windows.Forms.Button();
		this.btnIncreaseSpeed = new System.Windows.Forms.Button();
		this.btnComp = new System.Windows.Forms.Button();
		this.videoBox = new System.Windows.Forms.PictureBox();
		this.tpMediaInfo = new MetroFramework.Controls.MetroTabPage();
		this.rtbInfo = new System.Windows.Forms.RichTextBox();
		this.togPreview = new MetroFramework.Controls.MetroToggle();
		this.btnReset = new System.Windows.Forms.Button();
		this.btnFonts = new MetroFramework.Controls.MetroButton();
		this.btnMPC = new MetroFramework.Controls.MetroButton();
		this.btnCompareMPC = new MetroFramework.Controls.MetroButton();
		this.picSaved = new System.Windows.Forms.PictureBox();
		this.btnPreview = new MetroFramework.Controls.MetroButton();
		this.btnCompare = new MetroFramework.Controls.MetroButton();
		this.picLogo = new System.Windows.Forms.PictureBox();
		this.btnInfo = new MetroFramework.Controls.MetroButton();
		this.btnSetting = new MetroFramework.Controls.MetroButton();
		this.btnStop = new MetroFramework.Controls.MetroButton();
		this.btnDel = new MetroFramework.Controls.MetroButton();
		this.btnAdd = new MetroFramework.Controls.MetroButton();
		this.picWait = new System.Windows.Forms.PictureBox();
		this.btnStart = new MetroFramework.Controls.MetroButton();
		this.cmsControlQueue.SuspendLayout();
		this.cmsControlQueue_3.SuspendLayout();
		this.tpSpecial.SuspendLayout();
		this.grpHardSubRemover.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udRemoverRight).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.udRemoverLeft).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.udRemoverBottom).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.udRemoverTop).BeginInit();
		this.tpLogo.SuspendLayout();
		this.groupBox19.SuspendLayout();
		this.grpLogo.SuspendLayout();
		this.grpLogoSetting.SuspendLayout();
		this.groupBox21.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udLogoTimeSecMinute).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.udLogoTimeSec).BeginInit();
		this.tpTransition.SuspendLayout();
		this.pnFadeAll.SuspendLayout();
		this.pnFade.SuspendLayout();
		this.grpEndCardFadeOut.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardFadeOutTime).BeginInit();
		this.grpSourceFadeOut.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udSourceFadeOutTime).BeginInit();
		this.grpEndCardFadeIn.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardFadeInTime).BeginInit();
		this.grpSourceFadeIn.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udSourceFadeInTime).BeginInit();
		this.grpIntroFadeOut.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroFadeOutTime).BeginInit();
		this.grpIntroFadeIn.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroFadeInTime).BeginInit();
		this.pnDissolveAll.SuspendLayout();
		this.grpDissolve.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udDissolveTime).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.udDissolveFadeInTime).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.udDissolveFadeOutTime).BeginInit();
		this.pnTransition.SuspendLayout();
		this.grpTransitionEndCard.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardTransitionAudioTime).BeginInit();
		this.grpTransitionIntro.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroTransitionAudioTime).BeginInit();
		this.tpVideo.SuspendLayout();
		this.grpColorEnhancer.SuspendLayout();
		this.grpVideoEnhancer.SuspendLayout();
		this.grpVideoSetting.SuspendLayout();
		this.tpLog.SuspendLayout();
		this.pnLog.SuspendLayout();
		this.tpAudio.SuspendLayout();
		this.grpVolumeControl.SuspendLayout();
		this.grpAudioSetting.SuspendLayout();
		this.tpMain.SuspendLayout();
		this.splitIntroEndCard.SuspendLayout();
		this.grpIntro.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroTime).BeginInit();
		this.grpEndCard.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardTime).BeginInit();
		this.grpClipDetails.SuspendLayout();
		this.grpKaraoke.SuspendLayout();
		this.grpSubtitle.SuspendLayout();
		this.tcQueue.SuspendLayout();
		this.cmsControlQueue_2.SuspendLayout();
		this.cmsControlQueue_4.SuspendLayout();
		this.cmsControlQueue_5.SuspendLayout();
		this.cmsControlQueue_6.SuspendLayout();
		this.cmsControlQueue_7.SuspendLayout();
		this.cmsControlQueue_8.SuspendLayout();
		this.cmsControlQueue_9.SuspendLayout();
		this.splitMain.SuspendLayout();
		this.tcPlayer.SuspendLayout();
		this.tpPreview.SuspendLayout();
		this.pnGoto.SuspendLayout();
		this.pnControl.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.videoBox).BeginInit();
		this.tpMediaInfo.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.picSaved).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picLogo).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.picWait).BeginInit();
		base.SuspendLayout();
		this.cmsControlQueue.DropShadowEnabled = false;
		this.cmsControlQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.tsmiPause, this.tsmiSkip, this.tsmiStop, this.tsmiStopAfterCurrent });
		this.cmsControlQueue.Name = "cmsControlQueue";
		this.cmsControlQueue.Size = new System.Drawing.Size(171, 92);
		this.tsmiPause.Image = (System.Drawing.Image)resources.GetObject("tsmiPause.Image");
		this.tsmiPause.Name = "tsmiPause";
		this.tsmiPause.Size = new System.Drawing.Size(170, 22);
		this.tsmiPause.Text = "Pause";
		this.tsmiPause.Click += new System.EventHandler(this.tsmiPause_Click);
		this.tsmiSkip.Image = (System.Drawing.Image)resources.GetObject("tsmiSkip.Image");
		this.tsmiSkip.Name = "tsmiSkip";
		this.tsmiSkip.Size = new System.Drawing.Size(170, 22);
		this.tsmiSkip.Text = "Skip";
		this.tsmiSkip.Click += new System.EventHandler(this.tsmiSkip_Click);
		this.tsmiStop.Image = (System.Drawing.Image)resources.GetObject("tsmiStop.Image");
		this.tsmiStop.Name = "tsmiStop";
		this.tsmiStop.Size = new System.Drawing.Size(170, 22);
		this.tsmiStop.Text = "Stop All";
		this.tsmiStop.Click += new System.EventHandler(this.tsmiStop_Click);
		this.tsmiStopAfterCurrent.Image = (System.Drawing.Image)resources.GetObject("tsmiStopAfterCurrent.Image");
		this.tsmiStopAfterCurrent.Name = "tsmiStopAfterCurrent";
		this.tsmiStopAfterCurrent.Size = new System.Drawing.Size(170, 22);
		this.tsmiStopAfterCurrent.Text = "Stop After Current";
		this.tsmiStopAfterCurrent.Click += new System.EventHandler(this.tsmiStopAfterCurrent_Click);
		this.lstQueue.Alignment = System.Windows.Forms.ListViewAlignment.Default;
		this.lstQueue.AllowDrop = true;
		this.lstQueue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.lstQueue.CheckBoxes = true;
		this.lstQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[10] { this.columnHeader_0, this.columnHeader_2, this.columnHeader_3, this.columnHeader_4, this.columnHeader_1, this.columnHeader_5, this.columnHeader_6, this.columnHeader_7, this.columnHeader_8, this.columnHeader_9 });
		this.lstQueue.ContextMenuStrip = this.cmsControlQueue_3;
		this.lstQueue.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lstQueue.FullRowSelect = true;
		this.lstQueue.Location = new System.Drawing.Point(24, 106);
		this.lstQueue.Name = "lstQueue";
		this.lstQueue.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.lstQueue.Size = new System.Drawing.Size(974, 146);
		this.lstQueue.TabIndex = 5;
		this.lstQueue.UseCompatibleStateImageBehavior = false;
		this.lstQueue.View = System.Windows.Forms.View.Details;
		this.lstQueue.SelectedIndexChanged += new System.EventHandler(this.lstQueue_SelectedIndexChanged);
		this.lstQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstQueue_KeyDown);
		this.lstQueue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstQueue_MouseClick);
		this.columnHeader_0.Text = "File";
		this.columnHeader_0.Width = 661;
		this.columnHeader_2.Text = "Type";
		this.columnHeader_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.columnHeader_3.Text = "Status";
		this.columnHeader_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.columnHeader_4.Text = "FPS";
		this.columnHeader_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.columnHeader_4.Width = 50;
		this.columnHeader_1.Text = "Speed";
		this.columnHeader_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		this.columnHeader_1.Width = 50;
		this.columnHeader_5.Text = "Directory";
		this.columnHeader_5.Width = 0;
		this.columnHeader_6.Text = "Output";
		this.columnHeader_7.Text = "Preview";
		this.columnHeader_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.columnHeader_7.Width = 0;
		this.columnHeader_8.Text = "Axis";
		this.columnHeader_8.Width = 0;
		this.columnHeader_9.Text = "Index";
		this.columnHeader_9.Width = 0;
		this.cmsControlQueue_3.DropShadowEnabled = false;
		this.cmsControlQueue_3.Items.AddRange(new System.Windows.Forms.ToolStripItem[10] { this.tsmiPlayInput, this.toolStripSeparator2, this.tsmiSetOutputFile, this.tsmiSetOutputFolder, this.tsmiClearOutput, this.toolStripSeparator3, this.tsmiOpenInput, this.tsmiOpenOutput, this.toolStripSeparator1, this.tsmiDuplicate });
		this.cmsControlQueue_3.Name = "cmsControlQueue";
		this.cmsControlQueue_3.Size = new System.Drawing.Size(181, 176);
		this.tsmiPlayInput.Image = (System.Drawing.Image)resources.GetObject("tsmiPlayInput.Image");
		this.tsmiPlayInput.Name = "tsmiPlayInput";
		this.tsmiPlayInput.Size = new System.Drawing.Size(180, 22);
		this.tsmiPlayInput.Text = "Play Media";
		this.tsmiPlayInput.Click += new System.EventHandler(this.tsmiPlayInput_Click);
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
		this.tsmiSetOutputFile.Image = (System.Drawing.Image)resources.GetObject("tsmiSetOutputFile.Image");
		this.tsmiSetOutputFile.Name = "tsmiSetOutputFile";
		this.tsmiSetOutputFile.Size = new System.Drawing.Size(180, 22);
		this.tsmiSetOutputFile.Text = "Set Output File";
		this.tsmiSetOutputFile.Click += new System.EventHandler(this.tsmiSetOutputFile_Click);
		this.tsmiSetOutputFolder.Image = (System.Drawing.Image)resources.GetObject("tsmiSetOutputFolder.Image");
		this.tsmiSetOutputFolder.Name = "tsmiSetOutputFolder";
		this.tsmiSetOutputFolder.Size = new System.Drawing.Size(180, 22);
		this.tsmiSetOutputFolder.Text = "Set Output Folder";
		this.tsmiSetOutputFolder.Click += new System.EventHandler(this.tsmiSetOutputFolder_Click);
		this.tsmiClearOutput.Image = (System.Drawing.Image)resources.GetObject("tsmiClearOutput.Image");
		this.tsmiClearOutput.Name = "tsmiClearOutput";
		this.tsmiClearOutput.Size = new System.Drawing.Size(180, 22);
		this.tsmiClearOutput.Text = "Clear Output";
		this.tsmiClearOutput.Click += new System.EventHandler(this.tsmiClearOutput_Click);
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
		this.tsmiOpenInput.Image = (System.Drawing.Image)resources.GetObject("tsmiOpenInput.Image");
		this.tsmiOpenInput.Name = "tsmiOpenInput";
		this.tsmiOpenInput.Size = new System.Drawing.Size(180, 22);
		this.tsmiOpenInput.Text = "Open Input Folder";
		this.tsmiOpenInput.Click += new System.EventHandler(this.tsmiOpenInput_Click);
		this.tsmiOpenOutput.Image = (System.Drawing.Image)resources.GetObject("tsmiOpenOutput.Image");
		this.tsmiOpenOutput.Name = "tsmiOpenOutput";
		this.tsmiOpenOutput.Size = new System.Drawing.Size(180, 22);
		this.tsmiOpenOutput.Text = "Open Output Folder";
		this.tsmiOpenOutput.Click += new System.EventHandler(this.tsmiOpenOutput_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
		this.tsmiDuplicate.Image = (System.Drawing.Image)resources.GetObject("tsmiDuplicate.Image");
		this.tsmiDuplicate.Name = "tsmiDuplicate";
		this.tsmiDuplicate.Size = new System.Drawing.Size(180, 22);
		this.tsmiDuplicate.Text = "Duplicate";
		this.tsmiDuplicate.Click += new System.EventHandler(this.tsmiDuplicate_Click);
		this.tvDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.tvDetails.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.tvDetails.Location = new System.Drawing.Point(1004, 68);
		this.tvDetails.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
		this.tvDetails.Name = "tvDetails";
		this.tvDetails.Scrollable = false;
		this.tvDetails.ShowRootLines = false;
		this.tvDetails.Size = new System.Drawing.Size(252, 184);
		this.tvDetails.TabIndex = 6;
		this.txtOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtOutput.CustomButton.Image = null;
		this.txtOutput.CustomButton.Location = new System.Drawing.Point(1016, 1);
		this.txtOutput.CustomButton.Name = "";
		this.txtOutput.CustomButton.Size = new System.Drawing.Size(23, 23);
		this.txtOutput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtOutput.CustomButton.TabIndex = 1;
		this.txtOutput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtOutput.CustomButton.UseSelectable = true;
		this.txtOutput.Lines = new string[1] { "C:\\" };
		this.txtOutput.Location = new System.Drawing.Point(80, 262);
		this.txtOutput.MaxLength = 32767;
		this.txtOutput.Name = "txtOutput";
		this.txtOutput.PasswordChar = '\0';
		this.txtOutput.ReadOnly = true;
		this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtOutput.SelectedText = "";
		this.txtOutput.SelectionLength = 0;
		this.txtOutput.SelectionStart = 0;
		this.txtOutput.ShortcutsEnabled = true;
		this.txtOutput.ShowButton = true;
		this.txtOutput.Size = new System.Drawing.Size(1040, 25);
		this.txtOutput.TabIndex = 12;
		this.txtOutput.Text = "C:\\";
		this.txtOutput.UseSelectable = true;
		this.txtOutput.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtOutput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtOutput.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtOutput_ButtonClick);
		this.togSameInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togSameInput.AutoSize = true;
		this.togSameInput.DisplayStatus = false;
		this.togSameInput.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togSameInput.Location = new System.Drawing.Point(1206, 266);
		this.togSameInput.Name = "togSameInput";
		this.togSameInput.Size = new System.Drawing.Size(50, 17);
		this.togSameInput.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togSameInput.TabIndex = 15;
		this.togSameInput.Text = "Off";
		this.togSameInput.UseSelectable = true;
		this.togSameInput.CheckedChanged += new System.EventHandler(this.togSameInput_CheckedChanged);
		this.lblSameInput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblSameInput.AutoSize = true;
		this.lblSameInput.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblSameInput.Location = new System.Drawing.Point(1126, 267);
		this.lblSameInput.Name = "lblSameInput";
		this.lblSameInput.Size = new System.Drawing.Size(77, 15);
		this.lblSameInput.TabIndex = 17;
		this.lblSameInput.Text = "Same as input";
		this.lblOutput.AutoSize = true;
		this.lblOutput.Location = new System.Drawing.Point(23, 265);
		this.lblOutput.Name = "lblOutput";
		this.lblOutput.Size = new System.Drawing.Size(50, 19);
		this.lblOutput.TabIndex = 23;
		this.lblOutput.Text = "Output";
		this.tpSpecial.Controls.Add(this.grpHardSubRemover);
		this.tpSpecial.HorizontalScrollbar = true;
		this.tpSpecial.HorizontalScrollbarBarColor = false;
		this.tpSpecial.HorizontalScrollbarHighlightOnWheel = false;
		this.tpSpecial.HorizontalScrollbarSize = 12;
		this.tpSpecial.Location = new System.Drawing.Point(4, 34);
		this.tpSpecial.Name = "tpSpecial";
		this.tpSpecial.Size = new System.Drawing.Size(632, 372);
		this.tpSpecial.TabIndex = 5;
		this.tpSpecial.Text = "Special";
		this.tpSpecial.VerticalScrollbar = true;
		this.tpSpecial.VerticalScrollbarBarColor = true;
		this.tpSpecial.VerticalScrollbarHighlightOnWheel = true;
		this.tpSpecial.VerticalScrollbarSize = 12;
		this.grpHardSubRemover.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpHardSubRemover.BackColor = System.Drawing.Color.Transparent;
		this.grpHardSubRemover.Controls.Add(this.lblRemoverLevel2Level);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverLevel2);
		this.grpHardSubRemover.Controls.Add(this.tbRemoverLevel2);
		this.grpHardSubRemover.Controls.Add(this.togHardSubRemover);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverLink);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverTUT);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverLevel1Level);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverLevel1);
		this.grpHardSubRemover.Controls.Add(this.tbRemoverLevel1);
		this.grpHardSubRemover.Controls.Add(this.udRemoverRight);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverRight);
		this.grpHardSubRemover.Controls.Add(this.udRemoverLeft);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverLeft);
		this.grpHardSubRemover.Controls.Add(this.udRemoverBottom);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverBottom);
		this.grpHardSubRemover.Controls.Add(this.lblObjectRemove);
		this.grpHardSubRemover.Controls.Add(this.udRemoverTop);
		this.grpHardSubRemover.Controls.Add(this.lblRemoverTop);
		this.grpHardSubRemover.Controls.Add(this.lblHardSubRemover);
		this.grpHardSubRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpHardSubRemover.Location = new System.Drawing.Point(13, 14);
		this.grpHardSubRemover.Name = "grpHardSubRemover";
		this.grpHardSubRemover.Size = new System.Drawing.Size(606, 334);
		this.grpHardSubRemover.TabIndex = 53;
		this.grpHardSubRemover.TabStop = false;
		this.lblRemoverLevel2Level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblRemoverLevel2Level.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblRemoverLevel2Level.Location = new System.Drawing.Point(500, 226);
		this.lblRemoverLevel2Level.Name = "lblRemoverLevel2Level";
		this.lblRemoverLevel2Level.Size = new System.Drawing.Size(98, 15);
		this.lblRemoverLevel2Level.TabIndex = 68;
		this.lblRemoverLevel2Level.Text = "50";
		this.lblRemoverLevel2Level.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblRemoverLevel2.AutoSize = true;
		this.lblRemoverLevel2.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblRemoverLevel2.Location = new System.Drawing.Point(7, 226);
		this.lblRemoverLevel2.Name = "lblRemoverLevel2";
		this.lblRemoverLevel2.Size = new System.Drawing.Size(40, 15);
		this.lblRemoverLevel2.TabIndex = 67;
		this.lblRemoverLevel2.Text = "Level 2";
		this.tbRemoverLevel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbRemoverLevel2.BackColor = System.Drawing.Color.Transparent;
		this.tbRemoverLevel2.Enabled = false;
		this.tbRemoverLevel2.LargeChange = 10;
		this.tbRemoverLevel2.Location = new System.Drawing.Point(7, 243);
		this.tbRemoverLevel2.Minimum = 1;
		this.tbRemoverLevel2.MouseWheelBarPartitions = 100;
		this.tbRemoverLevel2.Name = "tbRemoverLevel2";
		this.tbRemoverLevel2.Size = new System.Drawing.Size(591, 23);
		this.tbRemoverLevel2.TabIndex = 66;
		this.tbRemoverLevel2.Text = "metroTrackBar6";
		this.tbRemoverLevel2.ValueChanged += new System.EventHandler(this.tbRemoverLevel2_ValueChanged);
		this.togHardSubRemover.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togHardSubRemover.AutoSize = true;
		this.togHardSubRemover.DisplayStatus = false;
		this.togHardSubRemover.Enabled = false;
		this.togHardSubRemover.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togHardSubRemover.Location = new System.Drawing.Point(548, 0);
		this.togHardSubRemover.Name = "togHardSubRemover";
		this.togHardSubRemover.Size = new System.Drawing.Size(50, 17);
		this.togHardSubRemover.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togHardSubRemover.TabIndex = 65;
		this.togHardSubRemover.Text = "Off";
		this.togHardSubRemover.UseSelectable = true;
		this.togHardSubRemover.CheckedChanged += new System.EventHandler(this.togHardSubRemover_CheckedChanged);
		this.lblRemoverLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblRemoverLink.BackColor = System.Drawing.Color.Transparent;
		this.lblRemoverLink.FontSize = MetroFramework.MetroLinkSize.Tall;
		this.lblRemoverLink.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblRemoverLink.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblRemoverLink.Location = new System.Drawing.Point(512, 23);
		this.lblRemoverLink.Name = "lblRemoverLink";
		this.lblRemoverLink.Size = new System.Drawing.Size(83, 26);
		this.lblRemoverLink.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblRemoverLink.TabIndex = 63;
		this.lblRemoverLink.Text = "click here";
		this.lblRemoverLink.UseSelectable = true;
		this.lblRemoverLink.Click += new System.EventHandler(this.lblRemoverLink_Click);
		this.lblRemoverTUT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblRemoverTUT.AutoSize = true;
		this.lblRemoverTUT.FontSize = MetroFramework.MetroLabelSize.Tall;
		this.lblRemoverTUT.Location = new System.Drawing.Point(411, 24);
		this.lblRemoverTUT.Name = "lblRemoverTUT";
		this.lblRemoverTUT.Size = new System.Drawing.Size(105, 25);
		this.lblRemoverTUT.TabIndex = 64;
		this.lblRemoverTUT.Text = "How to use?";
		this.lblRemoverLevel1Level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblRemoverLevel1Level.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblRemoverLevel1Level.Location = new System.Drawing.Point(500, 185);
		this.lblRemoverLevel1Level.Name = "lblRemoverLevel1Level";
		this.lblRemoverLevel1Level.Size = new System.Drawing.Size(98, 15);
		this.lblRemoverLevel1Level.TabIndex = 42;
		this.lblRemoverLevel1Level.Text = "256";
		this.lblRemoverLevel1Level.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblRemoverLevel1.AutoSize = true;
		this.lblRemoverLevel1.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblRemoverLevel1.Location = new System.Drawing.Point(7, 185);
		this.lblRemoverLevel1.Name = "lblRemoverLevel1";
		this.lblRemoverLevel1.Size = new System.Drawing.Size(38, 15);
		this.lblRemoverLevel1.TabIndex = 41;
		this.lblRemoverLevel1.Text = "Level 1";
		this.tbRemoverLevel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbRemoverLevel1.BackColor = System.Drawing.Color.Transparent;
		this.tbRemoverLevel1.Enabled = false;
		this.tbRemoverLevel1.LargeChange = 100;
		this.tbRemoverLevel1.Location = new System.Drawing.Point(7, 202);
		this.tbRemoverLevel1.Maximum = 999;
		this.tbRemoverLevel1.Minimum = 1;
		this.tbRemoverLevel1.MouseWheelBarPartitions = 500;
		this.tbRemoverLevel1.Name = "tbRemoverLevel1";
		this.tbRemoverLevel1.Size = new System.Drawing.Size(591, 23);
		this.tbRemoverLevel1.TabIndex = 40;
		this.tbRemoverLevel1.Text = "metroTrackBar1";
		this.tbRemoverLevel1.Value = 256;
		this.tbRemoverLevel1.ValueChanged += new System.EventHandler(this.tbRemoverLevel1_ValueChanged);
		this.udRemoverRight.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.udRemoverRight.Enabled = false;
		this.udRemoverRight.Location = new System.Drawing.Point(421, 99);
		this.udRemoverRight.Maximum = new decimal(new int[4] { 2160, 0, 0, 0 });
		this.udRemoverRight.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.udRemoverRight.Name = "udRemoverRight";
		this.udRemoverRight.Size = new System.Drawing.Size(45, 20);
		this.udRemoverRight.TabIndex = 35;
		this.udRemoverRight.Value = new decimal(new int[4] { 2, 0, 0, 0 });
		this.lblRemoverRight.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblRemoverRight.Location = new System.Drawing.Point(464, 99);
		this.lblRemoverRight.Name = "lblRemoverRight";
		this.lblRemoverRight.Size = new System.Drawing.Size(96, 19);
		this.lblRemoverRight.TabIndex = 34;
		this.lblRemoverRight.Text = "Right Edge";
		this.lblRemoverRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.udRemoverLeft.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.udRemoverLeft.Enabled = false;
		this.udRemoverLeft.Location = new System.Drawing.Point(164, 99);
		this.udRemoverLeft.Maximum = new decimal(new int[4] { 2160, 0, 0, 0 });
		this.udRemoverLeft.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.udRemoverLeft.Name = "udRemoverLeft";
		this.udRemoverLeft.Size = new System.Drawing.Size(45, 20);
		this.udRemoverLeft.TabIndex = 33;
		this.udRemoverLeft.Value = new decimal(new int[4] { 2, 0, 0, 0 });
		this.lblRemoverLeft.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblRemoverLeft.Location = new System.Drawing.Point(75, 98);
		this.lblRemoverLeft.Name = "lblRemoverLeft";
		this.lblRemoverLeft.Size = new System.Drawing.Size(96, 19);
		this.lblRemoverLeft.TabIndex = 32;
		this.lblRemoverLeft.Text = "Left Edge";
		this.lblRemoverLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.udRemoverBottom.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.udRemoverBottom.Enabled = false;
		this.udRemoverBottom.Location = new System.Drawing.Point(294, 144);
		this.udRemoverBottom.Maximum = new decimal(new int[4] { 2160, 0, 0, 0 });
		this.udRemoverBottom.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.udRemoverBottom.Name = "udRemoverBottom";
		this.udRemoverBottom.Size = new System.Drawing.Size(45, 20);
		this.udRemoverBottom.TabIndex = 31;
		this.udRemoverBottom.Value = new decimal(new int[4] { 2, 0, 0, 0 });
		this.lblRemoverBottom.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblRemoverBottom.Location = new System.Drawing.Point(268, 170);
		this.lblRemoverBottom.Name = "lblRemoverBottom";
		this.lblRemoverBottom.Size = new System.Drawing.Size(96, 19);
		this.lblRemoverBottom.TabIndex = 30;
		this.lblRemoverBottom.Text = "Bottom Edge";
		this.lblRemoverBottom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.lblObjectRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblObjectRemove.FontSize = MetroFramework.MetroLabelSize.Tall;
		this.lblObjectRemove.Location = new System.Drawing.Point(230, 95);
		this.lblObjectRemove.Name = "lblObjectRemove";
		this.lblObjectRemove.Size = new System.Drawing.Size(172, 28);
		this.lblObjectRemove.TabIndex = 29;
		this.lblObjectRemove.Text = "Object to be Remove";
		this.lblObjectRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.udRemoverTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.udRemoverTop.Enabled = false;
		this.udRemoverTop.Location = new System.Drawing.Point(294, 56);
		this.udRemoverTop.Maximum = new decimal(new int[4] { 2160, 0, 0, 0 });
		this.udRemoverTop.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
		this.udRemoverTop.Name = "udRemoverTop";
		this.udRemoverTop.Size = new System.Drawing.Size(45, 20);
		this.udRemoverTop.TabIndex = 28;
		this.udRemoverTop.Value = new decimal(new int[4] { 2, 0, 0, 0 });
		this.lblRemoverTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblRemoverTop.Location = new System.Drawing.Point(275, 27);
		this.lblRemoverTop.Name = "lblRemoverTop";
		this.lblRemoverTop.Size = new System.Drawing.Size(83, 19);
		this.lblRemoverTop.TabIndex = 27;
		this.lblRemoverTop.Text = "Top Edge";
		this.lblRemoverTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		this.lblHardSubRemover.AutoSize = true;
		this.lblHardSubRemover.Location = new System.Drawing.Point(6, -3);
		this.lblHardSubRemover.Name = "lblHardSubRemover";
		this.lblHardSubRemover.Size = new System.Drawing.Size(271, 19);
		this.lblHardSubRemover.TabIndex = 22;
		this.lblHardSubRemover.Text = "Hardsub / Logo Remover (COMING SOON!)";
		this.tpLogo.Controls.Add(this.groupBox19);
		this.tpLogo.Controls.Add(this.grpLogo);
		this.tpLogo.HorizontalScrollbar = true;
		this.tpLogo.HorizontalScrollbarBarColor = false;
		this.tpLogo.HorizontalScrollbarHighlightOnWheel = false;
		this.tpLogo.HorizontalScrollbarSize = 12;
		this.tpLogo.Location = new System.Drawing.Point(4, 34);
		this.tpLogo.Name = "tpLogo";
		this.tpLogo.Size = new System.Drawing.Size(632, 372);
		this.tpLogo.TabIndex = 4;
		this.tpLogo.Text = "Logo";
		this.tpLogo.VerticalScrollbar = true;
		this.tpLogo.VerticalScrollbarBarColor = true;
		this.tpLogo.VerticalScrollbarHighlightOnWheel = true;
		this.tpLogo.VerticalScrollbarSize = 12;
		this.groupBox19.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox19.BackColor = System.Drawing.Color.Transparent;
		this.groupBox19.Controls.Add(this.togLogoSubtitle);
		this.groupBox19.Controls.Add(this.txtLogoSubtitle);
		this.groupBox19.Controls.Add(this.lblLogoSubtitleFile);
		this.groupBox19.Controls.Add(this.lblLogoSubtitle);
		this.groupBox19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.groupBox19.Location = new System.Drawing.Point(13, 302);
		this.groupBox19.Name = "groupBox19";
		this.groupBox19.Size = new System.Drawing.Size(606, 68);
		this.groupBox19.TabIndex = 60;
		this.groupBox19.TabStop = false;
		this.togLogoSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togLogoSubtitle.AutoSize = true;
		this.togLogoSubtitle.DisplayStatus = false;
		this.togLogoSubtitle.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togLogoSubtitle.Location = new System.Drawing.Point(546, 0);
		this.togLogoSubtitle.Name = "togLogoSubtitle";
		this.togLogoSubtitle.Size = new System.Drawing.Size(50, 17);
		this.togLogoSubtitle.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togLogoSubtitle.TabIndex = 66;
		this.togLogoSubtitle.Text = "Off";
		this.togLogoSubtitle.UseSelectable = true;
		this.togLogoSubtitle.CheckedChanged += new System.EventHandler(this.togLogoSubtitle_CheckedChanged);
		this.txtLogoSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtLogoSubtitle.CustomButton.Image = null;
		this.txtLogoSubtitle.CustomButton.Location = new System.Drawing.Point(509, 1);
		this.txtLogoSubtitle.CustomButton.Name = "";
		this.txtLogoSubtitle.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtLogoSubtitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtLogoSubtitle.CustomButton.TabIndex = 1;
		this.txtLogoSubtitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtLogoSubtitle.CustomButton.UseSelectable = true;
		this.txtLogoSubtitle.Enabled = false;
		this.txtLogoSubtitle.Lines = new string[0];
		this.txtLogoSubtitle.Location = new System.Drawing.Point(65, 30);
		this.txtLogoSubtitle.MaxLength = 32767;
		this.txtLogoSubtitle.Name = "txtLogoSubtitle";
		this.txtLogoSubtitle.PasswordChar = '\0';
		this.txtLogoSubtitle.PromptText = "Please Select File";
		this.txtLogoSubtitle.ReadOnly = true;
		this.txtLogoSubtitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtLogoSubtitle.SelectedText = "";
		this.txtLogoSubtitle.SelectionLength = 0;
		this.txtLogoSubtitle.SelectionStart = 0;
		this.txtLogoSubtitle.ShortcutsEnabled = true;
		this.txtLogoSubtitle.ShowButton = true;
		this.txtLogoSubtitle.ShowClearButton = true;
		this.txtLogoSubtitle.Size = new System.Drawing.Size(531, 23);
		this.txtLogoSubtitle.TabIndex = 52;
		this.txtLogoSubtitle.UseSelectable = true;
		this.txtLogoSubtitle.WaterMark = "Please Select File";
		this.txtLogoSubtitle.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtLogoSubtitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtLogoSubtitle.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtLogoSubtitle_ButtonClick);
		this.lblLogoSubtitleFile.AutoSize = true;
		this.lblLogoSubtitleFile.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblLogoSubtitleFile.Location = new System.Drawing.Point(7, 34);
		this.lblLogoSubtitleFile.Name = "lblLogoSubtitleFile";
		this.lblLogoSubtitleFile.Size = new System.Drawing.Size(52, 15);
		this.lblLogoSubtitleFile.TabIndex = 54;
		this.lblLogoSubtitleFile.Text = "Logo File";
		this.lblLogoSubtitle.AutoSize = true;
		this.lblLogoSubtitle.Location = new System.Drawing.Point(6, -3);
		this.lblLogoSubtitle.Name = "lblLogoSubtitle";
		this.lblLogoSubtitle.Size = new System.Drawing.Size(86, 19);
		this.lblLogoSubtitle.TabIndex = 22;
		this.lblLogoSubtitle.Text = "Subtitle Logo";
		this.grpLogo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpLogo.BackColor = System.Drawing.Color.Transparent;
		this.grpLogo.Controls.Add(this.lblLinkLogo);
		this.grpLogo.Controls.Add(this.togLogo);
		this.grpLogo.Controls.Add(this.lblHowtoUse);
		this.grpLogo.Controls.Add(this.grpLogoSetting);
		this.grpLogo.Controls.Add(this.groupBox21);
		this.grpLogo.Controls.Add(this.txtLogo);
		this.grpLogo.Controls.Add(this.lblLogoFile);
		this.grpLogo.Controls.Add(this.lblLogo);
		this.grpLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpLogo.Location = new System.Drawing.Point(13, 14);
		this.grpLogo.Name = "grpLogo";
		this.grpLogo.Size = new System.Drawing.Size(606, 282);
		this.grpLogo.TabIndex = 58;
		this.grpLogo.TabStop = false;
		this.lblLinkLogo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblLinkLogo.BackColor = System.Drawing.Color.Transparent;
		this.lblLinkLogo.FontSize = MetroFramework.MetroLinkSize.Tall;
		this.lblLinkLogo.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblLinkLogo.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblLinkLogo.Location = new System.Drawing.Point(512, 22);
		this.lblLinkLogo.Name = "lblLinkLogo";
		this.lblLinkLogo.Size = new System.Drawing.Size(83, 26);
		this.lblLinkLogo.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblLinkLogo.TabIndex = 67;
		this.lblLinkLogo.Text = "click here";
		this.lblLinkLogo.UseSelectable = true;
		this.lblLinkLogo.Click += new System.EventHandler(this.lblLinkLogo_Click);
		this.togLogo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togLogo.AutoSize = true;
		this.togLogo.DisplayStatus = false;
		this.togLogo.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togLogo.Location = new System.Drawing.Point(548, 0);
		this.togLogo.Name = "togLogo";
		this.togLogo.Size = new System.Drawing.Size(50, 17);
		this.togLogo.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togLogo.TabIndex = 66;
		this.togLogo.Text = "Off";
		this.togLogo.UseSelectable = true;
		this.togLogo.CheckedChanged += new System.EventHandler(this.togLogo_CheckedChanged);
		this.lblHowtoUse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblHowtoUse.AutoSize = true;
		this.lblHowtoUse.FontSize = MetroFramework.MetroLabelSize.Tall;
		this.lblHowtoUse.Location = new System.Drawing.Point(411, 23);
		this.lblHowtoUse.Name = "lblHowtoUse";
		this.lblHowtoUse.Size = new System.Drawing.Size(105, 25);
		this.lblHowtoUse.TabIndex = 68;
		this.lblHowtoUse.Text = "How to use?";
		this.grpLogoSetting.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpLogoSetting.BackColor = System.Drawing.Color.Transparent;
		this.grpLogoSetting.Controls.Add(this.pLogoFadeColor);
		this.grpLogoSetting.Controls.Add(this.btnLogoFadeColor);
		this.grpLogoSetting.Controls.Add(this.lblLogoOpacityLevel);
		this.grpLogoSetting.Controls.Add(this.lblLogoOpacity);
		this.grpLogoSetting.Controls.Add(this.tbLogoOpacity);
		this.grpLogoSetting.Controls.Add(this.lblLogoBlend);
		this.grpLogoSetting.Controls.Add(this.cboLogoBlend);
		this.grpLogoSetting.Controls.Add(this.lblLogoSetting);
		this.grpLogoSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpLogoSetting.Location = new System.Drawing.Point(11, 162);
		this.grpLogoSetting.Name = "grpLogoSetting";
		this.grpLogoSetting.Size = new System.Drawing.Size(585, 109);
		this.grpLogoSetting.TabIndex = 62;
		this.grpLogoSetting.TabStop = false;
		this.pLogoFadeColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.pLogoFadeColor.BackColor = System.Drawing.Color.Black;
		this.pLogoFadeColor.Location = new System.Drawing.Point(543, 67);
		this.pLogoFadeColor.Name = "pLogoFadeColor";
		this.pLogoFadeColor.Size = new System.Drawing.Size(30, 30);
		this.pLogoFadeColor.TabIndex = 51;
		this.btnLogoFadeColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnLogoFadeColor.Enabled = false;
		this.btnLogoFadeColor.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnLogoFadeColor.Location = new System.Drawing.Point(462, 67);
		this.btnLogoFadeColor.Name = "btnLogoFadeColor";
		this.btnLogoFadeColor.Size = new System.Drawing.Size(75, 30);
		this.btnLogoFadeColor.TabIndex = 50;
		this.btnLogoFadeColor.Text = "Fade Color";
		this.btnLogoFadeColor.UseSelectable = true;
		this.btnLogoFadeColor.Click += new System.EventHandler(this.btnLogoFadeColor_Click);
		this.lblLogoOpacityLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblLogoOpacityLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblLogoOpacityLevel.Location = new System.Drawing.Point(358, 57);
		this.lblLogoOpacityLevel.Name = "lblLogoOpacityLevel";
		this.lblLogoOpacityLevel.Size = new System.Drawing.Size(98, 15);
		this.lblLogoOpacityLevel.TabIndex = 39;
		this.lblLogoOpacityLevel.Text = "100%";
		this.lblLogoOpacityLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblLogoOpacity.AutoSize = true;
		this.lblLogoOpacity.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblLogoOpacity.Location = new System.Drawing.Point(12, 57);
		this.lblLogoOpacity.Name = "lblLogoOpacity";
		this.lblLogoOpacity.Size = new System.Drawing.Size(45, 15);
		this.lblLogoOpacity.TabIndex = 38;
		this.lblLogoOpacity.Text = "Opacity";
		this.tbLogoOpacity.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbLogoOpacity.BackColor = System.Drawing.Color.Transparent;
		this.tbLogoOpacity.Enabled = false;
		this.tbLogoOpacity.LargeChange = 10;
		this.tbLogoOpacity.Location = new System.Drawing.Point(12, 74);
		this.tbLogoOpacity.MouseWheelBarPartitions = 100;
		this.tbLogoOpacity.Name = "tbLogoOpacity";
		this.tbLogoOpacity.Size = new System.Drawing.Size(444, 23);
		this.tbLogoOpacity.TabIndex = 37;
		this.tbLogoOpacity.Text = "metroTrackBar19";
		this.tbLogoOpacity.Value = 100;
		this.tbLogoOpacity.ValueChanged += new System.EventHandler(this.tbLogoOpacity_ValueChanged);
		this.lblLogoBlend.AutoSize = true;
		this.lblLogoBlend.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblLogoBlend.Location = new System.Drawing.Point(8, 30);
		this.lblLogoBlend.Name = "lblLogoBlend";
		this.lblLogoBlend.Size = new System.Drawing.Size(68, 15);
		this.lblLogoBlend.TabIndex = 29;
		this.lblLogoBlend.Text = "Blend Mode";
		this.cboLogoBlend.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboLogoBlend.Enabled = false;
		this.cboLogoBlend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboLogoBlend.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboLogoBlend.FormattingEnabled = true;
		this.cboLogoBlend.ItemHeight = 19;
		this.cboLogoBlend.Items.AddRange(new object[12]
		{
			"Blend", "Add", "Subtract", "Multiply", "Chroma", "Luma", "Lighten", "Darken", "SoftLight", "HardLight",
			"Difference", "Exclusion"
		});
		this.cboLogoBlend.Location = new System.Drawing.Point(82, 25);
		this.cboLogoBlend.Name = "cboLogoBlend";
		this.cboLogoBlend.Size = new System.Drawing.Size(491, 25);
		this.cboLogoBlend.TabIndex = 28;
		this.cboLogoBlend.UseSelectable = true;
		this.lblLogoSetting.AutoSize = true;
		this.lblLogoSetting.Location = new System.Drawing.Point(6, -3);
		this.lblLogoSetting.Name = "lblLogoSetting";
		this.lblLogoSetting.Size = new System.Drawing.Size(83, 19);
		this.lblLogoSetting.TabIndex = 22;
		this.lblLogoSetting.Text = "Logo Setting";
		this.groupBox21.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox21.BackColor = System.Drawing.Color.Transparent;
		this.groupBox21.Controls.Add(this.lblLogoTimeAlways);
		this.groupBox21.Controls.Add(this.togLogoTime);
		this.groupBox21.Controls.Add(this.lblLogoShowTimeMinute);
		this.groupBox21.Controls.Add(this.lblLogoTime);
		this.groupBox21.Controls.Add(this.udLogoTimeSecMinute);
		this.groupBox21.Controls.Add(this.lblLogoShowTime);
		this.groupBox21.Controls.Add(this.udLogoTimeSec);
		this.groupBox21.Controls.Add(this.lblLogoShowTimeSec);
		this.groupBox21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.groupBox21.Location = new System.Drawing.Point(11, 96);
		this.groupBox21.Name = "groupBox21";
		this.groupBox21.Size = new System.Drawing.Size(585, 60);
		this.groupBox21.TabIndex = 59;
		this.groupBox21.TabStop = false;
		this.lblLogoTimeAlways.AutoSize = true;
		this.lblLogoTimeAlways.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblLogoTimeAlways.Location = new System.Drawing.Point(150, 1);
		this.lblLogoTimeAlways.Name = "lblLogoTimeAlways";
		this.lblLogoTimeAlways.Size = new System.Drawing.Size(71, 15);
		this.lblLogoTimeAlways.TabIndex = 61;
		this.lblLogoTimeAlways.Text = "Always Show";
		this.togLogoTime.AutoSize = true;
		this.togLogoTime.DisplayStatus = false;
		this.togLogoTime.Enabled = false;
		this.togLogoTime.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togLogoTime.Location = new System.Drawing.Point(94, 0);
		this.togLogoTime.Name = "togLogoTime";
		this.togLogoTime.Size = new System.Drawing.Size(50, 17);
		this.togLogoTime.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togLogoTime.TabIndex = 60;
		this.togLogoTime.Text = "Off";
		this.togLogoTime.UseSelectable = true;
		this.togLogoTime.CheckedChanged += new System.EventHandler(this.togLogoTime_CheckedChanged);
		this.lblLogoShowTimeMinute.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblLogoShowTimeMinute.AutoSize = true;
		this.lblLogoShowTimeMinute.Location = new System.Drawing.Point(420, 27);
		this.lblLogoShowTimeMinute.Name = "lblLogoShowTimeMinute";
		this.lblLogoShowTimeMinute.Size = new System.Drawing.Size(49, 19);
		this.lblLogoShowTimeMinute.TabIndex = 50;
		this.lblLogoShowTimeMinute.Text = "Minute";
		this.lblLogoTime.AutoSize = true;
		this.lblLogoTime.Location = new System.Drawing.Point(6, -3);
		this.lblLogoTime.Name = "lblLogoTime";
		this.lblLogoTime.Size = new System.Drawing.Size(82, 19);
		this.lblLogoTime.TabIndex = 22;
		this.lblLogoTime.Text = "Time Setting";
		this.udLogoTimeSecMinute.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.udLogoTimeSecMinute.Enabled = false;
		this.udLogoTimeSecMinute.Location = new System.Drawing.Point(374, 27);
		this.udLogoTimeSecMinute.Maximum = new decimal(new int[4] { 60, 0, 0, 0 });
		this.udLogoTimeSecMinute.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		this.udLogoTimeSecMinute.Name = "udLogoTimeSecMinute";
		this.udLogoTimeSecMinute.Size = new System.Drawing.Size(40, 20);
		this.udLogoTimeSecMinute.TabIndex = 2;
		this.udLogoTimeSecMinute.Value = new decimal(new int[4] { 7, 0, 0, 0 });
		this.lblLogoShowTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblLogoShowTime.AutoSize = true;
		this.lblLogoShowTime.Location = new System.Drawing.Point(98, 27);
		this.lblLogoShowTime.Name = "lblLogoShowTime";
		this.lblLogoShowTime.Size = new System.Drawing.Size(92, 19);
		this.lblLogoShowTime.TabIndex = 51;
		this.lblLogoShowTime.Text = "Show logo for";
		this.udLogoTimeSec.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.udLogoTimeSec.Enabled = false;
		this.udLogoTimeSec.Location = new System.Drawing.Point(196, 27);
		this.udLogoTimeSec.Maximum = new decimal(new int[4] { 300, 0, 0, 0 });
		this.udLogoTimeSec.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
		this.udLogoTimeSec.Name = "udLogoTimeSec";
		this.udLogoTimeSec.Size = new System.Drawing.Size(40, 20);
		this.udLogoTimeSec.TabIndex = 2;
		this.udLogoTimeSec.Value = new decimal(new int[4] { 15, 0, 0, 0 });
		this.lblLogoShowTimeSec.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblLogoShowTimeSec.AutoSize = true;
		this.lblLogoShowTimeSec.Location = new System.Drawing.Point(242, 27);
		this.lblLogoShowTimeSec.Name = "lblLogoShowTimeSec";
		this.lblLogoShowTimeSec.Size = new System.Drawing.Size(127, 19);
		this.lblLogoShowTimeSec.TabIndex = 50;
		this.lblLogoShowTimeSec.Text = "Second  |  For every";
		this.txtLogo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtLogo.CustomButton.Image = null;
		this.txtLogo.CustomButton.Location = new System.Drawing.Point(509, 1);
		this.txtLogo.CustomButton.Name = "";
		this.txtLogo.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtLogo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtLogo.CustomButton.TabIndex = 1;
		this.txtLogo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtLogo.CustomButton.UseSelectable = true;
		this.txtLogo.Enabled = false;
		this.txtLogo.Lines = new string[0];
		this.txtLogo.Location = new System.Drawing.Point(65, 61);
		this.txtLogo.MaxLength = 32767;
		this.txtLogo.Name = "txtLogo";
		this.txtLogo.PasswordChar = '\0';
		this.txtLogo.PromptText = "Please Select File";
		this.txtLogo.ReadOnly = true;
		this.txtLogo.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtLogo.SelectedText = "";
		this.txtLogo.SelectionLength = 0;
		this.txtLogo.SelectionStart = 0;
		this.txtLogo.ShortcutsEnabled = true;
		this.txtLogo.ShowButton = true;
		this.txtLogo.ShowClearButton = true;
		this.txtLogo.Size = new System.Drawing.Size(531, 23);
		this.txtLogo.TabIndex = 52;
		this.txtLogo.UseSelectable = true;
		this.txtLogo.WaterMark = "Please Select File";
		this.txtLogo.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtLogo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtLogo.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtLogo_ButtonClick);
		this.lblLogoFile.AutoSize = true;
		this.lblLogoFile.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblLogoFile.Location = new System.Drawing.Point(7, 64);
		this.lblLogoFile.Name = "lblLogoFile";
		this.lblLogoFile.Size = new System.Drawing.Size(52, 15);
		this.lblLogoFile.TabIndex = 54;
		this.lblLogoFile.Text = "Logo File";
		this.lblLogo.AutoSize = true;
		this.lblLogo.Location = new System.Drawing.Point(6, -3);
		this.lblLogo.Name = "lblLogo";
		this.lblLogo.Size = new System.Drawing.Size(130, 19);
		this.lblLogo.TabIndex = 22;
		this.lblLogo.Text = "Picture / Video Logo";
		this.tpTransition.Controls.Add(this.cboTransition);
		this.tpTransition.Controls.Add(this.lblTransition);
		this.tpTransition.Controls.Add(this.pnFadeAll);
		this.tpTransition.Controls.Add(this.pnDissolveAll);
		this.tpTransition.Controls.Add(this.pnTransition);
		this.tpTransition.HorizontalScrollbar = true;
		this.tpTransition.HorizontalScrollbarBarColor = false;
		this.tpTransition.HorizontalScrollbarHighlightOnWheel = false;
		this.tpTransition.HorizontalScrollbarSize = 12;
		this.tpTransition.Location = new System.Drawing.Point(4, 34);
		this.tpTransition.Name = "tpTransition";
		this.tpTransition.Size = new System.Drawing.Size(632, 372);
		this.tpTransition.TabIndex = 3;
		this.tpTransition.Text = "Transition";
		this.tpTransition.VerticalScrollbar = true;
		this.tpTransition.VerticalScrollbarBarColor = true;
		this.tpTransition.VerticalScrollbarHighlightOnWheel = true;
		this.tpTransition.VerticalScrollbarSize = 12;
		this.cboTransition.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.cboTransition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboTransition.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboTransition.FormattingEnabled = true;
		this.cboTransition.ItemHeight = 19;
		this.cboTransition.Items.AddRange(new object[4] { "Disable", "Fade", "Dissolve", "Custom Transition" });
		this.cboTransition.Location = new System.Drawing.Point(110, 8);
		this.cboTransition.Name = "cboTransition";
		this.cboTransition.Size = new System.Drawing.Size(515, 25);
		this.cboTransition.TabIndex = 26;
		this.cboTransition.UseSelectable = true;
		this.cboTransition.SelectedIndexChanged += new System.EventHandler(this.cboTransition_SelectedIndexChanged);
		this.lblTransition.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.lblTransition.AutoSize = true;
		this.lblTransition.Location = new System.Drawing.Point(1, 11);
		this.lblTransition.Name = "lblTransition";
		this.lblTransition.Size = new System.Drawing.Size(101, 19);
		this.lblTransition.TabIndex = 27;
		this.lblTransition.Text = "Select Transition";
		this.pnFadeAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.pnFadeAll.BackColor = System.Drawing.Color.White;
		this.pnFadeAll.Controls.Add(this.pnFade);
		this.pnFadeAll.HorizontalScrollbarBarColor = true;
		this.pnFadeAll.HorizontalScrollbarHighlightOnWheel = false;
		this.pnFadeAll.HorizontalScrollbarSize = 10;
		this.pnFadeAll.Location = new System.Drawing.Point(6, 40);
		this.pnFadeAll.Name = "pnFadeAll";
		this.pnFadeAll.Size = new System.Drawing.Size(619, 300);
		this.pnFadeAll.TabIndex = 31;
		this.pnFadeAll.VerticalScrollbarBarColor = true;
		this.pnFadeAll.VerticalScrollbarHighlightOnWheel = false;
		this.pnFadeAll.VerticalScrollbarSize = 10;
		this.pnFade.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.pnFade.BackColor = System.Drawing.Color.White;
		this.pnFade.Controls.Add(this.grpEndCardFadeOut);
		this.pnFade.Controls.Add(this.grpSourceFadeOut);
		this.pnFade.Controls.Add(this.grpEndCardFadeIn);
		this.pnFade.Controls.Add(this.grpSourceFadeIn);
		this.pnFade.Controls.Add(this.grpIntroFadeOut);
		this.pnFade.Controls.Add(this.grpIntroFadeIn);
		this.pnFade.HorizontalScrollbarBarColor = true;
		this.pnFade.HorizontalScrollbarHighlightOnWheel = false;
		this.pnFade.HorizontalScrollbarSize = 10;
		this.pnFade.Location = new System.Drawing.Point(0, 0);
		this.pnFade.Name = "pnFade";
		this.pnFade.Size = new System.Drawing.Size(619, 300);
		this.pnFade.TabIndex = 28;
		this.pnFade.VerticalScrollbarBarColor = true;
		this.pnFade.VerticalScrollbarHighlightOnWheel = false;
		this.pnFade.VerticalScrollbarSize = 10;
		this.grpEndCardFadeOut.BackColor = System.Drawing.Color.Transparent;
		this.grpEndCardFadeOut.Controls.Add(this.lblEndCardFadeOutTime);
		this.grpEndCardFadeOut.Controls.Add(this.pEndCardOutColor);
		this.grpEndCardFadeOut.Controls.Add(this.lblEndCardFadeOutTimeSec);
		this.grpEndCardFadeOut.Controls.Add(this.togEndCardOut);
		this.grpEndCardFadeOut.Controls.Add(this.lblIntroEndCardOut);
		this.grpEndCardFadeOut.Controls.Add(this.btnEndCardFadeOutColor);
		this.grpEndCardFadeOut.Controls.Add(this.udEndCardFadeOutTime);
		this.grpEndCardFadeOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpEndCardFadeOut.Location = new System.Drawing.Point(313, 157);
		this.grpEndCardFadeOut.Name = "grpEndCardFadeOut";
		this.grpEndCardFadeOut.Size = new System.Drawing.Size(305, 71);
		this.grpEndCardFadeOut.TabIndex = 55;
		this.grpEndCardFadeOut.TabStop = false;
		this.lblEndCardFadeOutTime.AutoSize = true;
		this.lblEndCardFadeOutTime.Location = new System.Drawing.Point(130, 31);
		this.lblEndCardFadeOutTime.Name = "lblEndCardFadeOutTime";
		this.lblEndCardFadeOutTime.Size = new System.Drawing.Size(70, 19);
		this.lblEndCardFadeOutTime.TabIndex = 51;
		this.lblEndCardFadeOutTime.Text = "Fade Time";
		this.pEndCardOutColor.BackColor = System.Drawing.Color.Black;
		this.pEndCardOutColor.Location = new System.Drawing.Point(92, 26);
		this.pEndCardOutColor.Name = "pEndCardOutColor";
		this.pEndCardOutColor.Size = new System.Drawing.Size(30, 30);
		this.pEndCardOutColor.TabIndex = 49;
		this.lblEndCardFadeOutTimeSec.AutoSize = true;
		this.lblEndCardFadeOutTimeSec.Location = new System.Drawing.Point(265, 31);
		this.lblEndCardFadeOutTimeSec.Name = "lblEndCardFadeOutTimeSec";
		this.lblEndCardFadeOutTimeSec.Size = new System.Drawing.Size(29, 19);
		this.lblEndCardFadeOutTimeSec.TabIndex = 50;
		this.lblEndCardFadeOutTimeSec.Text = "Sec";
		this.togEndCardOut.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togEndCardOut.AutoSize = true;
		this.togEndCardOut.DisplayStatus = false;
		this.togEndCardOut.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togEndCardOut.Location = new System.Drawing.Point(244, 0);
		this.togEndCardOut.Name = "togEndCardOut";
		this.togEndCardOut.Size = new System.Drawing.Size(50, 17);
		this.togEndCardOut.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togEndCardOut.TabIndex = 49;
		this.togEndCardOut.Text = "Off";
		this.togEndCardOut.UseSelectable = true;
		this.togEndCardOut.CheckedChanged += new System.EventHandler(this.togEndCardOut_CheckedChanged);
		this.lblIntroEndCardOut.AutoSize = true;
		this.lblIntroEndCardOut.Location = new System.Drawing.Point(6, -3);
		this.lblIntroEndCardOut.Name = "lblIntroEndCardOut";
		this.lblIntroEndCardOut.Size = new System.Drawing.Size(118, 19);
		this.lblIntroEndCardOut.TabIndex = 22;
		this.lblIntroEndCardOut.Text = "EndCard Fade Out";
		this.btnEndCardFadeOutColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnEndCardFadeOutColor.Enabled = false;
		this.btnEndCardFadeOutColor.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnEndCardFadeOutColor.Location = new System.Drawing.Point(11, 26);
		this.btnEndCardFadeOutColor.Name = "btnEndCardFadeOutColor";
		this.btnEndCardFadeOutColor.Size = new System.Drawing.Size(75, 30);
		this.btnEndCardFadeOutColor.TabIndex = 46;
		this.btnEndCardFadeOutColor.Text = "Fade Color";
		this.btnEndCardFadeOutColor.UseSelectable = true;
		this.btnEndCardFadeOutColor.Click += new System.EventHandler(this.btnEndCardFadeOutColor_Click);
		this.udEndCardFadeOutTime.DecimalPlaces = 2;
		this.udEndCardFadeOutTime.Enabled = false;
		this.udEndCardFadeOutTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udEndCardFadeOutTime.Location = new System.Drawing.Point(207, 31);
		this.udEndCardFadeOutTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udEndCardFadeOutTime.Name = "udEndCardFadeOutTime";
		this.udEndCardFadeOutTime.Size = new System.Drawing.Size(50, 20);
		this.udEndCardFadeOutTime.TabIndex = 2;
		this.udEndCardFadeOutTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.grpSourceFadeOut.BackColor = System.Drawing.Color.Transparent;
		this.grpSourceFadeOut.Controls.Add(this.lblSourceFadeOutTime);
		this.grpSourceFadeOut.Controls.Add(this.pSourceOutColor);
		this.grpSourceFadeOut.Controls.Add(this.lblSourceFadeOutTimeSec);
		this.grpSourceFadeOut.Controls.Add(this.togSourceOut);
		this.grpSourceFadeOut.Controls.Add(this.lblIntroSourceOut);
		this.grpSourceFadeOut.Controls.Add(this.btnSourceFadeOutColor);
		this.grpSourceFadeOut.Controls.Add(this.udSourceFadeOutTime);
		this.grpSourceFadeOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpSourceFadeOut.Location = new System.Drawing.Point(313, 80);
		this.grpSourceFadeOut.Name = "grpSourceFadeOut";
		this.grpSourceFadeOut.Size = new System.Drawing.Size(305, 71);
		this.grpSourceFadeOut.TabIndex = 53;
		this.grpSourceFadeOut.TabStop = false;
		this.lblSourceFadeOutTime.AutoSize = true;
		this.lblSourceFadeOutTime.Location = new System.Drawing.Point(130, 31);
		this.lblSourceFadeOutTime.Name = "lblSourceFadeOutTime";
		this.lblSourceFadeOutTime.Size = new System.Drawing.Size(70, 19);
		this.lblSourceFadeOutTime.TabIndex = 51;
		this.lblSourceFadeOutTime.Text = "Fade Time";
		this.pSourceOutColor.BackColor = System.Drawing.Color.Black;
		this.pSourceOutColor.Location = new System.Drawing.Point(92, 26);
		this.pSourceOutColor.Name = "pSourceOutColor";
		this.pSourceOutColor.Size = new System.Drawing.Size(30, 30);
		this.pSourceOutColor.TabIndex = 49;
		this.lblSourceFadeOutTimeSec.AutoSize = true;
		this.lblSourceFadeOutTimeSec.Location = new System.Drawing.Point(265, 31);
		this.lblSourceFadeOutTimeSec.Name = "lblSourceFadeOutTimeSec";
		this.lblSourceFadeOutTimeSec.Size = new System.Drawing.Size(29, 19);
		this.lblSourceFadeOutTimeSec.TabIndex = 50;
		this.lblSourceFadeOutTimeSec.Text = "Sec";
		this.togSourceOut.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togSourceOut.AutoSize = true;
		this.togSourceOut.DisplayStatus = false;
		this.togSourceOut.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togSourceOut.Location = new System.Drawing.Point(244, 0);
		this.togSourceOut.Name = "togSourceOut";
		this.togSourceOut.Size = new System.Drawing.Size(50, 17);
		this.togSourceOut.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togSourceOut.TabIndex = 49;
		this.togSourceOut.Text = "Off";
		this.togSourceOut.UseSelectable = true;
		this.togSourceOut.CheckedChanged += new System.EventHandler(this.togSourceOut_CheckedChanged);
		this.lblIntroSourceOut.AutoSize = true;
		this.lblIntroSourceOut.Location = new System.Drawing.Point(6, -3);
		this.lblIntroSourceOut.Name = "lblIntroSourceOut";
		this.lblIntroSourceOut.Size = new System.Drawing.Size(107, 19);
		this.lblIntroSourceOut.TabIndex = 22;
		this.lblIntroSourceOut.Text = "Source Fade Out";
		this.btnSourceFadeOutColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnSourceFadeOutColor.Enabled = false;
		this.btnSourceFadeOutColor.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnSourceFadeOutColor.Location = new System.Drawing.Point(11, 26);
		this.btnSourceFadeOutColor.Name = "btnSourceFadeOutColor";
		this.btnSourceFadeOutColor.Size = new System.Drawing.Size(75, 30);
		this.btnSourceFadeOutColor.TabIndex = 46;
		this.btnSourceFadeOutColor.Text = "Fade Color";
		this.btnSourceFadeOutColor.UseSelectable = true;
		this.btnSourceFadeOutColor.Click += new System.EventHandler(this.btnSourceFadeOutColor_Click);
		this.udSourceFadeOutTime.DecimalPlaces = 2;
		this.udSourceFadeOutTime.Enabled = false;
		this.udSourceFadeOutTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udSourceFadeOutTime.Location = new System.Drawing.Point(207, 31);
		this.udSourceFadeOutTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udSourceFadeOutTime.Name = "udSourceFadeOutTime";
		this.udSourceFadeOutTime.Size = new System.Drawing.Size(50, 20);
		this.udSourceFadeOutTime.TabIndex = 2;
		this.udSourceFadeOutTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.grpEndCardFadeIn.BackColor = System.Drawing.Color.Transparent;
		this.grpEndCardFadeIn.Controls.Add(this.lblEndCardFadeInTime);
		this.grpEndCardFadeIn.Controls.Add(this.pEndCardInColor);
		this.grpEndCardFadeIn.Controls.Add(this.lblEndCardFadeInTimeSec);
		this.grpEndCardFadeIn.Controls.Add(this.togEndCardIn);
		this.grpEndCardFadeIn.Controls.Add(this.lblIntroEndCardIn);
		this.grpEndCardFadeIn.Controls.Add(this.btnEndCardFadeInColor);
		this.grpEndCardFadeIn.Controls.Add(this.udEndCardFadeInTime);
		this.grpEndCardFadeIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpEndCardFadeIn.Location = new System.Drawing.Point(1, 157);
		this.grpEndCardFadeIn.Name = "grpEndCardFadeIn";
		this.grpEndCardFadeIn.Size = new System.Drawing.Size(305, 71);
		this.grpEndCardFadeIn.TabIndex = 54;
		this.grpEndCardFadeIn.TabStop = false;
		this.lblEndCardFadeInTime.AutoSize = true;
		this.lblEndCardFadeInTime.Location = new System.Drawing.Point(130, 31);
		this.lblEndCardFadeInTime.Name = "lblEndCardFadeInTime";
		this.lblEndCardFadeInTime.Size = new System.Drawing.Size(70, 19);
		this.lblEndCardFadeInTime.TabIndex = 51;
		this.lblEndCardFadeInTime.Text = "Fade Time";
		this.pEndCardInColor.BackColor = System.Drawing.Color.Black;
		this.pEndCardInColor.Location = new System.Drawing.Point(92, 26);
		this.pEndCardInColor.Name = "pEndCardInColor";
		this.pEndCardInColor.Size = new System.Drawing.Size(30, 30);
		this.pEndCardInColor.TabIndex = 49;
		this.lblEndCardFadeInTimeSec.AutoSize = true;
		this.lblEndCardFadeInTimeSec.Location = new System.Drawing.Point(264, 31);
		this.lblEndCardFadeInTimeSec.Name = "lblEndCardFadeInTimeSec";
		this.lblEndCardFadeInTimeSec.Size = new System.Drawing.Size(29, 19);
		this.lblEndCardFadeInTimeSec.TabIndex = 50;
		this.lblEndCardFadeInTimeSec.Text = "Sec";
		this.togEndCardIn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togEndCardIn.AutoSize = true;
		this.togEndCardIn.DisplayStatus = false;
		this.togEndCardIn.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togEndCardIn.Location = new System.Drawing.Point(242, 0);
		this.togEndCardIn.Name = "togEndCardIn";
		this.togEndCardIn.Size = new System.Drawing.Size(50, 17);
		this.togEndCardIn.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togEndCardIn.TabIndex = 49;
		this.togEndCardIn.Text = "Off";
		this.togEndCardIn.UseSelectable = true;
		this.togEndCardIn.CheckedChanged += new System.EventHandler(this.togEndCardIn_CheckedChanged);
		this.lblIntroEndCardIn.AutoSize = true;
		this.lblIntroEndCardIn.Location = new System.Drawing.Point(6, -3);
		this.lblIntroEndCardIn.Name = "lblIntroEndCardIn";
		this.lblIntroEndCardIn.Size = new System.Drawing.Size(106, 19);
		this.lblIntroEndCardIn.TabIndex = 22;
		this.lblIntroEndCardIn.Text = "EndCard Fade In";
		this.btnEndCardFadeInColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnEndCardFadeInColor.Enabled = false;
		this.btnEndCardFadeInColor.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnEndCardFadeInColor.Location = new System.Drawing.Point(11, 26);
		this.btnEndCardFadeInColor.Name = "btnEndCardFadeInColor";
		this.btnEndCardFadeInColor.Size = new System.Drawing.Size(75, 30);
		this.btnEndCardFadeInColor.TabIndex = 46;
		this.btnEndCardFadeInColor.Text = "Fade Color";
		this.btnEndCardFadeInColor.UseSelectable = true;
		this.btnEndCardFadeInColor.Click += new System.EventHandler(this.btnEndCardFadeInColor_Click);
		this.udEndCardFadeInTime.DecimalPlaces = 2;
		this.udEndCardFadeInTime.Enabled = false;
		this.udEndCardFadeInTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udEndCardFadeInTime.Location = new System.Drawing.Point(207, 31);
		this.udEndCardFadeInTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udEndCardFadeInTime.Name = "udEndCardFadeInTime";
		this.udEndCardFadeInTime.Size = new System.Drawing.Size(50, 20);
		this.udEndCardFadeInTime.TabIndex = 2;
		this.udEndCardFadeInTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.grpSourceFadeIn.BackColor = System.Drawing.Color.Transparent;
		this.grpSourceFadeIn.Controls.Add(this.lblSourceFadeInTime);
		this.grpSourceFadeIn.Controls.Add(this.pSourceInColor);
		this.grpSourceFadeIn.Controls.Add(this.lblSourceFadeInTimeSec);
		this.grpSourceFadeIn.Controls.Add(this.togSourceIn);
		this.grpSourceFadeIn.Controls.Add(this.lblIntroSourceIn);
		this.grpSourceFadeIn.Controls.Add(this.btnSourceFadeInColor);
		this.grpSourceFadeIn.Controls.Add(this.udSourceFadeInTime);
		this.grpSourceFadeIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpSourceFadeIn.Location = new System.Drawing.Point(1, 80);
		this.grpSourceFadeIn.Name = "grpSourceFadeIn";
		this.grpSourceFadeIn.Size = new System.Drawing.Size(305, 71);
		this.grpSourceFadeIn.TabIndex = 52;
		this.grpSourceFadeIn.TabStop = false;
		this.lblSourceFadeInTime.AutoSize = true;
		this.lblSourceFadeInTime.Location = new System.Drawing.Point(130, 31);
		this.lblSourceFadeInTime.Name = "lblSourceFadeInTime";
		this.lblSourceFadeInTime.Size = new System.Drawing.Size(70, 19);
		this.lblSourceFadeInTime.TabIndex = 51;
		this.lblSourceFadeInTime.Text = "Fade Time";
		this.pSourceInColor.BackColor = System.Drawing.Color.Black;
		this.pSourceInColor.Location = new System.Drawing.Point(92, 26);
		this.pSourceInColor.Name = "pSourceInColor";
		this.pSourceInColor.Size = new System.Drawing.Size(30, 30);
		this.pSourceInColor.TabIndex = 49;
		this.lblSourceFadeInTimeSec.AutoSize = true;
		this.lblSourceFadeInTimeSec.Location = new System.Drawing.Point(264, 31);
		this.lblSourceFadeInTimeSec.Name = "lblSourceFadeInTimeSec";
		this.lblSourceFadeInTimeSec.Size = new System.Drawing.Size(29, 19);
		this.lblSourceFadeInTimeSec.TabIndex = 50;
		this.lblSourceFadeInTimeSec.Text = "Sec";
		this.togSourceIn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togSourceIn.AutoSize = true;
		this.togSourceIn.DisplayStatus = false;
		this.togSourceIn.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togSourceIn.Location = new System.Drawing.Point(242, 0);
		this.togSourceIn.Name = "togSourceIn";
		this.togSourceIn.Size = new System.Drawing.Size(50, 17);
		this.togSourceIn.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togSourceIn.TabIndex = 49;
		this.togSourceIn.Text = "Off";
		this.togSourceIn.UseSelectable = true;
		this.togSourceIn.CheckedChanged += new System.EventHandler(this.togSourceIn_CheckedChanged);
		this.lblIntroSourceIn.AutoSize = true;
		this.lblIntroSourceIn.Location = new System.Drawing.Point(6, -3);
		this.lblIntroSourceIn.Name = "lblIntroSourceIn";
		this.lblIntroSourceIn.Size = new System.Drawing.Size(95, 19);
		this.lblIntroSourceIn.TabIndex = 22;
		this.lblIntroSourceIn.Text = "Source Fade In";
		this.btnSourceFadeInColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnSourceFadeInColor.Enabled = false;
		this.btnSourceFadeInColor.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnSourceFadeInColor.Location = new System.Drawing.Point(11, 26);
		this.btnSourceFadeInColor.Name = "btnSourceFadeInColor";
		this.btnSourceFadeInColor.Size = new System.Drawing.Size(75, 30);
		this.btnSourceFadeInColor.TabIndex = 46;
		this.btnSourceFadeInColor.Text = "Fade Color";
		this.btnSourceFadeInColor.UseSelectable = true;
		this.btnSourceFadeInColor.Click += new System.EventHandler(this.btnSourceFadeInColor_Click);
		this.udSourceFadeInTime.DecimalPlaces = 2;
		this.udSourceFadeInTime.Enabled = false;
		this.udSourceFadeInTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udSourceFadeInTime.Location = new System.Drawing.Point(207, 31);
		this.udSourceFadeInTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udSourceFadeInTime.Name = "udSourceFadeInTime";
		this.udSourceFadeInTime.Size = new System.Drawing.Size(50, 20);
		this.udSourceFadeInTime.TabIndex = 2;
		this.udSourceFadeInTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.grpIntroFadeOut.BackColor = System.Drawing.Color.Transparent;
		this.grpIntroFadeOut.Controls.Add(this.lblIntroFadeOutTime);
		this.grpIntroFadeOut.Controls.Add(this.pFadeOutColor);
		this.grpIntroFadeOut.Controls.Add(this.lblIntroFadeOutTimeSec);
		this.grpIntroFadeOut.Controls.Add(this.togFadeOut);
		this.grpIntroFadeOut.Controls.Add(this.lblIntroFadeOut);
		this.grpIntroFadeOut.Controls.Add(this.btnIntroFadeOutColor);
		this.grpIntroFadeOut.Controls.Add(this.udIntroFadeOutTime);
		this.grpIntroFadeOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpIntroFadeOut.Location = new System.Drawing.Point(313, 3);
		this.grpIntroFadeOut.Name = "grpIntroFadeOut";
		this.grpIntroFadeOut.Size = new System.Drawing.Size(305, 71);
		this.grpIntroFadeOut.TabIndex = 48;
		this.grpIntroFadeOut.TabStop = false;
		this.lblIntroFadeOutTime.AutoSize = true;
		this.lblIntroFadeOutTime.Location = new System.Drawing.Point(130, 31);
		this.lblIntroFadeOutTime.Name = "lblIntroFadeOutTime";
		this.lblIntroFadeOutTime.Size = new System.Drawing.Size(70, 19);
		this.lblIntroFadeOutTime.TabIndex = 51;
		this.lblIntroFadeOutTime.Text = "Fade Time";
		this.pFadeOutColor.BackColor = System.Drawing.Color.Black;
		this.pFadeOutColor.Location = new System.Drawing.Point(92, 26);
		this.pFadeOutColor.Name = "pFadeOutColor";
		this.pFadeOutColor.Size = new System.Drawing.Size(30, 30);
		this.pFadeOutColor.TabIndex = 49;
		this.lblIntroFadeOutTimeSec.AutoSize = true;
		this.lblIntroFadeOutTimeSec.Location = new System.Drawing.Point(265, 31);
		this.lblIntroFadeOutTimeSec.Name = "lblIntroFadeOutTimeSec";
		this.lblIntroFadeOutTimeSec.Size = new System.Drawing.Size(29, 19);
		this.lblIntroFadeOutTimeSec.TabIndex = 50;
		this.lblIntroFadeOutTimeSec.Text = "Sec";
		this.togFadeOut.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togFadeOut.AutoSize = true;
		this.togFadeOut.DisplayStatus = false;
		this.togFadeOut.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togFadeOut.Location = new System.Drawing.Point(244, 0);
		this.togFadeOut.Name = "togFadeOut";
		this.togFadeOut.Size = new System.Drawing.Size(50, 17);
		this.togFadeOut.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togFadeOut.TabIndex = 49;
		this.togFadeOut.Text = "Off";
		this.togFadeOut.UseSelectable = true;
		this.togFadeOut.CheckedChanged += new System.EventHandler(this.togFadeOut_CheckedChanged);
		this.lblIntroFadeOut.AutoSize = true;
		this.lblIntroFadeOut.Location = new System.Drawing.Point(6, -3);
		this.lblIntroFadeOut.Name = "lblIntroFadeOut";
		this.lblIntroFadeOut.Size = new System.Drawing.Size(94, 19);
		this.lblIntroFadeOut.TabIndex = 22;
		this.lblIntroFadeOut.Text = "Intro Fade Out";
		this.btnIntroFadeOutColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnIntroFadeOutColor.Enabled = false;
		this.btnIntroFadeOutColor.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnIntroFadeOutColor.Location = new System.Drawing.Point(11, 26);
		this.btnIntroFadeOutColor.Name = "btnIntroFadeOutColor";
		this.btnIntroFadeOutColor.Size = new System.Drawing.Size(75, 30);
		this.btnIntroFadeOutColor.TabIndex = 46;
		this.btnIntroFadeOutColor.Text = "Fade Color";
		this.btnIntroFadeOutColor.UseSelectable = true;
		this.btnIntroFadeOutColor.Click += new System.EventHandler(this.btnIntroFadeOutColor_Click);
		this.udIntroFadeOutTime.DecimalPlaces = 2;
		this.udIntroFadeOutTime.Enabled = false;
		this.udIntroFadeOutTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udIntroFadeOutTime.Location = new System.Drawing.Point(207, 31);
		this.udIntroFadeOutTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udIntroFadeOutTime.Name = "udIntroFadeOutTime";
		this.udIntroFadeOutTime.Size = new System.Drawing.Size(50, 20);
		this.udIntroFadeOutTime.TabIndex = 2;
		this.udIntroFadeOutTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.grpIntroFadeIn.BackColor = System.Drawing.Color.Transparent;
		this.grpIntroFadeIn.Controls.Add(this.lblIntroFadeInTime);
		this.grpIntroFadeIn.Controls.Add(this.pFadeInColor);
		this.grpIntroFadeIn.Controls.Add(this.lblIntroFadeInTimeSec);
		this.grpIntroFadeIn.Controls.Add(this.togFadeIn);
		this.grpIntroFadeIn.Controls.Add(this.lblIntroFadeIn);
		this.grpIntroFadeIn.Controls.Add(this.btnIntroFadeInColor);
		this.grpIntroFadeIn.Controls.Add(this.udIntroFadeInTime);
		this.grpIntroFadeIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpIntroFadeIn.Location = new System.Drawing.Point(1, 3);
		this.grpIntroFadeIn.Name = "grpIntroFadeIn";
		this.grpIntroFadeIn.Size = new System.Drawing.Size(305, 71);
		this.grpIntroFadeIn.TabIndex = 47;
		this.grpIntroFadeIn.TabStop = false;
		this.lblIntroFadeInTime.AutoSize = true;
		this.lblIntroFadeInTime.Location = new System.Drawing.Point(130, 31);
		this.lblIntroFadeInTime.Name = "lblIntroFadeInTime";
		this.lblIntroFadeInTime.Size = new System.Drawing.Size(70, 19);
		this.lblIntroFadeInTime.TabIndex = 51;
		this.lblIntroFadeInTime.Text = "Fade Time";
		this.pFadeInColor.BackColor = System.Drawing.Color.Black;
		this.pFadeInColor.Location = new System.Drawing.Point(92, 26);
		this.pFadeInColor.Name = "pFadeInColor";
		this.pFadeInColor.Size = new System.Drawing.Size(30, 30);
		this.pFadeInColor.TabIndex = 49;
		this.lblIntroFadeInTimeSec.AutoSize = true;
		this.lblIntroFadeInTimeSec.Location = new System.Drawing.Point(264, 31);
		this.lblIntroFadeInTimeSec.Name = "lblIntroFadeInTimeSec";
		this.lblIntroFadeInTimeSec.Size = new System.Drawing.Size(29, 19);
		this.lblIntroFadeInTimeSec.TabIndex = 50;
		this.lblIntroFadeInTimeSec.Text = "Sec";
		this.togFadeIn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togFadeIn.AutoSize = true;
		this.togFadeIn.DisplayStatus = false;
		this.togFadeIn.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togFadeIn.Location = new System.Drawing.Point(242, 0);
		this.togFadeIn.Name = "togFadeIn";
		this.togFadeIn.Size = new System.Drawing.Size(50, 17);
		this.togFadeIn.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togFadeIn.TabIndex = 49;
		this.togFadeIn.Text = "Off";
		this.togFadeIn.UseSelectable = true;
		this.togFadeIn.CheckedChanged += new System.EventHandler(this.togFadeIn_CheckedChanged);
		this.lblIntroFadeIn.AutoSize = true;
		this.lblIntroFadeIn.Location = new System.Drawing.Point(6, -3);
		this.lblIntroFadeIn.Name = "lblIntroFadeIn";
		this.lblIntroFadeIn.Size = new System.Drawing.Size(82, 19);
		this.lblIntroFadeIn.TabIndex = 22;
		this.lblIntroFadeIn.Text = "Intro Fade In";
		this.btnIntroFadeInColor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnIntroFadeInColor.Enabled = false;
		this.btnIntroFadeInColor.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnIntroFadeInColor.Location = new System.Drawing.Point(11, 26);
		this.btnIntroFadeInColor.Name = "btnIntroFadeInColor";
		this.btnIntroFadeInColor.Size = new System.Drawing.Size(75, 30);
		this.btnIntroFadeInColor.TabIndex = 46;
		this.btnIntroFadeInColor.Text = "Fade Color";
		this.btnIntroFadeInColor.UseSelectable = true;
		this.btnIntroFadeInColor.Click += new System.EventHandler(this.btnIntroFadeInColor_Click);
		this.udIntroFadeInTime.DecimalPlaces = 2;
		this.udIntroFadeInTime.Enabled = false;
		this.udIntroFadeInTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udIntroFadeInTime.Location = new System.Drawing.Point(207, 31);
		this.udIntroFadeInTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udIntroFadeInTime.Name = "udIntroFadeInTime";
		this.udIntroFadeInTime.Size = new System.Drawing.Size(50, 20);
		this.udIntroFadeInTime.TabIndex = 2;
		this.udIntroFadeInTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.pnDissolveAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.pnDissolveAll.BackColor = System.Drawing.Color.White;
		this.pnDissolveAll.Controls.Add(this.grpDissolve);
		this.pnDissolveAll.HorizontalScrollbarBarColor = true;
		this.pnDissolveAll.HorizontalScrollbarHighlightOnWheel = false;
		this.pnDissolveAll.HorizontalScrollbarSize = 10;
		this.pnDissolveAll.Location = new System.Drawing.Point(6, 40);
		this.pnDissolveAll.Name = "pnDissolveAll";
		this.pnDissolveAll.Size = new System.Drawing.Size(619, 300);
		this.pnDissolveAll.TabIndex = 29;
		this.pnDissolveAll.VerticalScrollbarBarColor = true;
		this.pnDissolveAll.VerticalScrollbarHighlightOnWheel = false;
		this.pnDissolveAll.VerticalScrollbarSize = 10;
		this.grpDissolve.BackColor = System.Drawing.Color.Transparent;
		this.grpDissolve.Controls.Add(this.lblDissolveTime);
		this.grpDissolve.Controls.Add(this.lblDissolveTimeSec);
		this.grpDissolve.Controls.Add(this.udDissolveTime);
		this.grpDissolve.Controls.Add(this.lblDissolveControl);
		this.grpDissolve.Controls.Add(this.lblDissolveFadeOutTime);
		this.grpDissolve.Controls.Add(this.udDissolveFadeInTime);
		this.grpDissolve.Controls.Add(this.lblDissolveFadeOutTimeSec);
		this.grpDissolve.Controls.Add(this.lblDissolveFadeInTimeSec);
		this.grpDissolve.Controls.Add(this.udDissolveFadeOutTime);
		this.grpDissolve.Controls.Add(this.lblDissolveFadeInTime);
		this.grpDissolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpDissolve.Location = new System.Drawing.Point(0, 0);
		this.grpDissolve.Name = "grpDissolve";
		this.grpDissolve.Size = new System.Drawing.Size(619, 141);
		this.grpDissolve.TabIndex = 58;
		this.grpDissolve.TabStop = false;
		this.lblDissolveTime.AutoSize = true;
		this.lblDissolveTime.Location = new System.Drawing.Point(213, 29);
		this.lblDissolveTime.Name = "lblDissolveTime";
		this.lblDissolveTime.Size = new System.Drawing.Size(88, 19);
		this.lblDissolveTime.TabIndex = 57;
		this.lblDissolveTime.Text = "Dissolve Time";
		this.lblDissolveTimeSec.AutoSize = true;
		this.lblDissolveTimeSec.Location = new System.Drawing.Point(363, 29);
		this.lblDissolveTimeSec.Name = "lblDissolveTimeSec";
		this.lblDissolveTimeSec.Size = new System.Drawing.Size(52, 19);
		this.lblDissolveTimeSec.TabIndex = 56;
		this.lblDissolveTimeSec.Text = "Second";
		this.udDissolveTime.DecimalPlaces = 2;
		this.udDissolveTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udDissolveTime.Location = new System.Drawing.Point(307, 29);
		this.udDissolveTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udDissolveTime.Name = "udDissolveTime";
		this.udDissolveTime.Size = new System.Drawing.Size(50, 20);
		this.udDissolveTime.TabIndex = 55;
		this.udDissolveTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.lblDissolveControl.AutoSize = true;
		this.lblDissolveControl.Location = new System.Drawing.Point(6, -3);
		this.lblDissolveControl.Name = "lblDissolveControl";
		this.lblDissolveControl.Size = new System.Drawing.Size(103, 19);
		this.lblDissolveControl.TabIndex = 22;
		this.lblDissolveControl.Text = "Dissolve Control";
		this.lblDissolveFadeOutTime.AutoSize = true;
		this.lblDissolveFadeOutTime.Location = new System.Drawing.Point(204, 97);
		this.lblDissolveFadeOutTime.Name = "lblDissolveFadeOutTime";
		this.lblDissolveFadeOutTime.Size = new System.Drawing.Size(96, 19);
		this.lblDissolveFadeOutTime.TabIndex = 54;
		this.lblDissolveFadeOutTime.Text = "Fade Out Time";
		this.udDissolveFadeInTime.DecimalPlaces = 2;
		this.udDissolveFadeInTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udDissolveFadeInTime.Location = new System.Drawing.Point(307, 63);
		this.udDissolveFadeInTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udDissolveFadeInTime.Name = "udDissolveFadeInTime";
		this.udDissolveFadeInTime.Size = new System.Drawing.Size(50, 20);
		this.udDissolveFadeInTime.TabIndex = 2;
		this.udDissolveFadeInTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.lblDissolveFadeOutTimeSec.AutoSize = true;
		this.lblDissolveFadeOutTimeSec.Location = new System.Drawing.Point(363, 97);
		this.lblDissolveFadeOutTimeSec.Name = "lblDissolveFadeOutTimeSec";
		this.lblDissolveFadeOutTimeSec.Size = new System.Drawing.Size(52, 19);
		this.lblDissolveFadeOutTimeSec.TabIndex = 53;
		this.lblDissolveFadeOutTimeSec.Text = "Second";
		this.lblDissolveFadeInTimeSec.AutoSize = true;
		this.lblDissolveFadeInTimeSec.Location = new System.Drawing.Point(363, 63);
		this.lblDissolveFadeInTimeSec.Name = "lblDissolveFadeInTimeSec";
		this.lblDissolveFadeInTimeSec.Size = new System.Drawing.Size(52, 19);
		this.lblDissolveFadeInTimeSec.TabIndex = 50;
		this.lblDissolveFadeInTimeSec.Text = "Second";
		this.udDissolveFadeOutTime.DecimalPlaces = 2;
		this.udDissolveFadeOutTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udDissolveFadeOutTime.Location = new System.Drawing.Point(307, 97);
		this.udDissolveFadeOutTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udDissolveFadeOutTime.Name = "udDissolveFadeOutTime";
		this.udDissolveFadeOutTime.Size = new System.Drawing.Size(50, 20);
		this.udDissolveFadeOutTime.TabIndex = 52;
		this.udDissolveFadeOutTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.lblDissolveFadeInTime.AutoSize = true;
		this.lblDissolveFadeInTime.Location = new System.Drawing.Point(216, 63);
		this.lblDissolveFadeInTime.Name = "lblDissolveFadeInTime";
		this.lblDissolveFadeInTime.Size = new System.Drawing.Size(84, 19);
		this.lblDissolveFadeInTime.TabIndex = 51;
		this.lblDissolveFadeInTime.Text = "Fade In Time";
		this.pnTransition.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.pnTransition.BackColor = System.Drawing.Color.White;
		this.pnTransition.Controls.Add(this.lblTransitionLink);
		this.pnTransition.Controls.Add(this.lblTransitionTUT);
		this.pnTransition.Controls.Add(this.grpTransitionEndCard);
		this.pnTransition.Controls.Add(this.grpTransitionIntro);
		this.pnTransition.HorizontalScrollbarBarColor = true;
		this.pnTransition.HorizontalScrollbarHighlightOnWheel = false;
		this.pnTransition.HorizontalScrollbarSize = 10;
		this.pnTransition.Location = new System.Drawing.Point(6, 40);
		this.pnTransition.Name = "pnTransition";
		this.pnTransition.Size = new System.Drawing.Size(619, 300);
		this.pnTransition.TabIndex = 30;
		this.pnTransition.VerticalScrollbarBarColor = true;
		this.pnTransition.VerticalScrollbarHighlightOnWheel = false;
		this.pnTransition.VerticalScrollbarSize = 10;
		this.lblTransitionLink.BackColor = System.Drawing.Color.Transparent;
		this.lblTransitionLink.FontSize = MetroFramework.MetroLinkSize.Tall;
		this.lblTransitionLink.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblTransitionLink.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblTransitionLink.Location = new System.Drawing.Point(534, -1);
		this.lblTransitionLink.Name = "lblTransitionLink";
		this.lblTransitionLink.Size = new System.Drawing.Size(83, 26);
		this.lblTransitionLink.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblTransitionLink.TabIndex = 61;
		this.lblTransitionLink.Text = "click here";
		this.lblTransitionLink.UseSelectable = true;
		this.lblTransitionLink.Click += new System.EventHandler(this.lblTransitionLink_Click);
		this.lblTransitionTUT.AutoSize = true;
		this.lblTransitionTUT.FontSize = MetroFramework.MetroLabelSize.Tall;
		this.lblTransitionTUT.Location = new System.Drawing.Point(433, 0);
		this.lblTransitionTUT.Name = "lblTransitionTUT";
		this.lblTransitionTUT.Size = new System.Drawing.Size(105, 25);
		this.lblTransitionTUT.TabIndex = 62;
		this.lblTransitionTUT.Text = "How to use?";
		this.grpTransitionEndCard.BackColor = System.Drawing.Color.Transparent;
		this.grpTransitionEndCard.Controls.Add(this.chkEndCardTransitionOverlay);
		this.grpTransitionEndCard.Controls.Add(this.lblEndCardTransitionFile);
		this.grpTransitionEndCard.Controls.Add(this.lblEndCardTransition);
		this.grpTransitionEndCard.Controls.Add(this.lblEndCardTransitionAudioSec);
		this.grpTransitionEndCard.Controls.Add(this.lblEndCardTransitionAudio);
		this.grpTransitionEndCard.Controls.Add(this.udEndCardTransitionAudioTime);
		this.grpTransitionEndCard.Controls.Add(this.txtEndCardTransitionOverlay);
		this.grpTransitionEndCard.Controls.Add(this.txtEndCardTransition);
		this.grpTransitionEndCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpTransitionEndCard.Location = new System.Drawing.Point(0, 140);
		this.grpTransitionEndCard.Name = "grpTransitionEndCard";
		this.grpTransitionEndCard.Size = new System.Drawing.Size(619, 97);
		this.grpTransitionEndCard.TabIndex = 60;
		this.grpTransitionEndCard.TabStop = false;
		this.chkEndCardTransitionOverlay.AutoSize = true;
		this.chkEndCardTransitionOverlay.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
		this.chkEndCardTransitionOverlay.Location = new System.Drawing.Point(17, 58);
		this.chkEndCardTransitionOverlay.Name = "chkEndCardTransitionOverlay";
		this.chkEndCardTransitionOverlay.Size = new System.Drawing.Size(60, 15);
		this.chkEndCardTransitionOverlay.TabIndex = 72;
		this.chkEndCardTransitionOverlay.Text = "Overlay";
		this.chkEndCardTransitionOverlay.UseSelectable = true;
		this.lblEndCardTransitionFile.AutoSize = true;
		this.lblEndCardTransitionFile.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblEndCardTransitionFile.Location = new System.Drawing.Point(17, 29);
		this.lblEndCardTransitionFile.Name = "lblEndCardTransitionFile";
		this.lblEndCardTransitionFile.Size = new System.Drawing.Size(53, 15);
		this.lblEndCardTransitionFile.TabIndex = 54;
		this.lblEndCardTransitionFile.Text = "Transition";
		this.lblEndCardTransition.AutoSize = true;
		this.lblEndCardTransition.Location = new System.Drawing.Point(6, -3);
		this.lblEndCardTransition.Name = "lblEndCardTransition";
		this.lblEndCardTransition.Size = new System.Drawing.Size(118, 19);
		this.lblEndCardTransition.TabIndex = 22;
		this.lblEndCardTransition.Text = "EndCard Transition";
		this.lblEndCardTransitionAudioSec.AutoSize = true;
		this.lblEndCardTransitionAudioSec.Location = new System.Drawing.Point(559, 56);
		this.lblEndCardTransitionAudioSec.Name = "lblEndCardTransitionAudioSec";
		this.lblEndCardTransitionAudioSec.Size = new System.Drawing.Size(29, 19);
		this.lblEndCardTransitionAudioSec.TabIndex = 50;
		this.lblEndCardTransitionAudioSec.Text = "Sec";
		this.lblEndCardTransitionAudio.AutoSize = true;
		this.lblEndCardTransitionAudio.Location = new System.Drawing.Point(498, 28);
		this.lblEndCardTransitionAudio.Name = "lblEndCardTransitionAudio";
		this.lblEndCardTransitionAudio.Size = new System.Drawing.Size(109, 19);
		this.lblEndCardTransitionAudio.TabIndex = 51;
		this.lblEndCardTransitionAudio.Text = "Audio Fade Time";
		this.udEndCardTransitionAudioTime.DecimalPlaces = 2;
		this.udEndCardTransitionAudioTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udEndCardTransitionAudioTime.Location = new System.Drawing.Point(505, 56);
		this.udEndCardTransitionAudioTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udEndCardTransitionAudioTime.Name = "udEndCardTransitionAudioTime";
		this.udEndCardTransitionAudioTime.Size = new System.Drawing.Size(50, 20);
		this.udEndCardTransitionAudioTime.TabIndex = 2;
		this.udEndCardTransitionAudioTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.txtEndCardTransitionOverlay.CustomButton.Image = null;
		this.txtEndCardTransitionOverlay.CustomButton.Location = new System.Drawing.Point(384, 1);
		this.txtEndCardTransitionOverlay.CustomButton.Name = "";
		this.txtEndCardTransitionOverlay.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtEndCardTransitionOverlay.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtEndCardTransitionOverlay.CustomButton.TabIndex = 1;
		this.txtEndCardTransitionOverlay.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtEndCardTransitionOverlay.CustomButton.UseSelectable = true;
		this.txtEndCardTransitionOverlay.Lines = new string[0];
		this.txtEndCardTransitionOverlay.Location = new System.Drawing.Point(86, 54);
		this.txtEndCardTransitionOverlay.MaxLength = 32767;
		this.txtEndCardTransitionOverlay.Name = "txtEndCardTransitionOverlay";
		this.txtEndCardTransitionOverlay.PasswordChar = '\0';
		this.txtEndCardTransitionOverlay.ReadOnly = true;
		this.txtEndCardTransitionOverlay.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtEndCardTransitionOverlay.SelectedText = "";
		this.txtEndCardTransitionOverlay.SelectionLength = 0;
		this.txtEndCardTransitionOverlay.SelectionStart = 0;
		this.txtEndCardTransitionOverlay.ShortcutsEnabled = true;
		this.txtEndCardTransitionOverlay.ShowButton = true;
		this.txtEndCardTransitionOverlay.ShowClearButton = true;
		this.txtEndCardTransitionOverlay.Size = new System.Drawing.Size(406, 23);
		this.txtEndCardTransitionOverlay.TabIndex = 55;
		this.txtEndCardTransitionOverlay.UseSelectable = true;
		this.txtEndCardTransitionOverlay.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtEndCardTransitionOverlay.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtEndCardTransitionOverlay.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtEndCardTransitionOverlay_ButtonClick);
		this.txtEndCardTransition.CustomButton.Image = null;
		this.txtEndCardTransition.CustomButton.Location = new System.Drawing.Point(384, 1);
		this.txtEndCardTransition.CustomButton.Name = "";
		this.txtEndCardTransition.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtEndCardTransition.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtEndCardTransition.CustomButton.TabIndex = 1;
		this.txtEndCardTransition.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtEndCardTransition.CustomButton.UseSelectable = true;
		this.txtEndCardTransition.Lines = new string[0];
		this.txtEndCardTransition.Location = new System.Drawing.Point(86, 25);
		this.txtEndCardTransition.MaxLength = 32767;
		this.txtEndCardTransition.Name = "txtEndCardTransition";
		this.txtEndCardTransition.PasswordChar = '\0';
		this.txtEndCardTransition.ReadOnly = true;
		this.txtEndCardTransition.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtEndCardTransition.SelectedText = "";
		this.txtEndCardTransition.SelectionLength = 0;
		this.txtEndCardTransition.SelectionStart = 0;
		this.txtEndCardTransition.ShortcutsEnabled = true;
		this.txtEndCardTransition.ShowButton = true;
		this.txtEndCardTransition.ShowClearButton = true;
		this.txtEndCardTransition.Size = new System.Drawing.Size(406, 23);
		this.txtEndCardTransition.TabIndex = 52;
		this.txtEndCardTransition.UseSelectable = true;
		this.txtEndCardTransition.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtEndCardTransition.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtEndCardTransition.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtEndCardTransition_ButtonClick);
		this.grpTransitionIntro.BackColor = System.Drawing.Color.Transparent;
		this.grpTransitionIntro.Controls.Add(this.chkIntroTransitionOverlay);
		this.grpTransitionIntro.Controls.Add(this.lblIntroTransitionFile);
		this.grpTransitionIntro.Controls.Add(this.lblIntroTransition);
		this.grpTransitionIntro.Controls.Add(this.lblIntroTransitionAudioSec);
		this.grpTransitionIntro.Controls.Add(this.lblIntroTransitionAudio);
		this.grpTransitionIntro.Controls.Add(this.udIntroTransitionAudioTime);
		this.grpTransitionIntro.Controls.Add(this.txtIntroTransitionOverlay);
		this.grpTransitionIntro.Controls.Add(this.txtIntroTransition);
		this.grpTransitionIntro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpTransitionIntro.Location = new System.Drawing.Point(0, 31);
		this.grpTransitionIntro.Name = "grpTransitionIntro";
		this.grpTransitionIntro.Size = new System.Drawing.Size(619, 97);
		this.grpTransitionIntro.TabIndex = 58;
		this.grpTransitionIntro.TabStop = false;
		this.chkIntroTransitionOverlay.AutoSize = true;
		this.chkIntroTransitionOverlay.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
		this.chkIntroTransitionOverlay.Location = new System.Drawing.Point(17, 58);
		this.chkIntroTransitionOverlay.Name = "chkIntroTransitionOverlay";
		this.chkIntroTransitionOverlay.Size = new System.Drawing.Size(60, 15);
		this.chkIntroTransitionOverlay.TabIndex = 71;
		this.chkIntroTransitionOverlay.Text = "Overlay";
		this.chkIntroTransitionOverlay.UseSelectable = true;
		this.lblIntroTransitionFile.AutoSize = true;
		this.lblIntroTransitionFile.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblIntroTransitionFile.Location = new System.Drawing.Point(16, 29);
		this.lblIntroTransitionFile.Name = "lblIntroTransitionFile";
		this.lblIntroTransitionFile.Size = new System.Drawing.Size(53, 15);
		this.lblIntroTransitionFile.TabIndex = 54;
		this.lblIntroTransitionFile.Text = "Transition";
		this.lblIntroTransition.AutoSize = true;
		this.lblIntroTransition.Location = new System.Drawing.Point(6, -3);
		this.lblIntroTransition.Name = "lblIntroTransition";
		this.lblIntroTransition.Size = new System.Drawing.Size(94, 19);
		this.lblIntroTransition.TabIndex = 22;
		this.lblIntroTransition.Text = "Intro Transition";
		this.lblIntroTransitionAudioSec.AutoSize = true;
		this.lblIntroTransitionAudioSec.Location = new System.Drawing.Point(559, 56);
		this.lblIntroTransitionAudioSec.Name = "lblIntroTransitionAudioSec";
		this.lblIntroTransitionAudioSec.Size = new System.Drawing.Size(29, 19);
		this.lblIntroTransitionAudioSec.TabIndex = 50;
		this.lblIntroTransitionAudioSec.Text = "Sec";
		this.lblIntroTransitionAudio.AutoSize = true;
		this.lblIntroTransitionAudio.Location = new System.Drawing.Point(498, 28);
		this.lblIntroTransitionAudio.Name = "lblIntroTransitionAudio";
		this.lblIntroTransitionAudio.Size = new System.Drawing.Size(109, 19);
		this.lblIntroTransitionAudio.TabIndex = 51;
		this.lblIntroTransitionAudio.Text = "Audio Fade Time";
		this.udIntroTransitionAudioTime.DecimalPlaces = 2;
		this.udIntroTransitionAudioTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udIntroTransitionAudioTime.Location = new System.Drawing.Point(505, 56);
		this.udIntroTransitionAudioTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.udIntroTransitionAudioTime.Name = "udIntroTransitionAudioTime";
		this.udIntroTransitionAudioTime.Size = new System.Drawing.Size(50, 20);
		this.udIntroTransitionAudioTime.TabIndex = 2;
		this.udIntroTransitionAudioTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.txtIntroTransitionOverlay.CustomButton.Image = null;
		this.txtIntroTransitionOverlay.CustomButton.Location = new System.Drawing.Point(384, 1);
		this.txtIntroTransitionOverlay.CustomButton.Name = "";
		this.txtIntroTransitionOverlay.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtIntroTransitionOverlay.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtIntroTransitionOverlay.CustomButton.TabIndex = 1;
		this.txtIntroTransitionOverlay.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtIntroTransitionOverlay.CustomButton.UseSelectable = true;
		this.txtIntroTransitionOverlay.Lines = new string[0];
		this.txtIntroTransitionOverlay.Location = new System.Drawing.Point(86, 54);
		this.txtIntroTransitionOverlay.MaxLength = 32767;
		this.txtIntroTransitionOverlay.Name = "txtIntroTransitionOverlay";
		this.txtIntroTransitionOverlay.PasswordChar = '\0';
		this.txtIntroTransitionOverlay.ReadOnly = true;
		this.txtIntroTransitionOverlay.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtIntroTransitionOverlay.SelectedText = "";
		this.txtIntroTransitionOverlay.SelectionLength = 0;
		this.txtIntroTransitionOverlay.SelectionStart = 0;
		this.txtIntroTransitionOverlay.ShortcutsEnabled = true;
		this.txtIntroTransitionOverlay.ShowButton = true;
		this.txtIntroTransitionOverlay.ShowClearButton = true;
		this.txtIntroTransitionOverlay.Size = new System.Drawing.Size(406, 23);
		this.txtIntroTransitionOverlay.TabIndex = 55;
		this.txtIntroTransitionOverlay.UseSelectable = true;
		this.txtIntroTransitionOverlay.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtIntroTransitionOverlay.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtIntroTransitionOverlay.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtIntroTransitionOverlay_ButtonClick);
		this.txtIntroTransition.CustomButton.Image = null;
		this.txtIntroTransition.CustomButton.Location = new System.Drawing.Point(384, 1);
		this.txtIntroTransition.CustomButton.Name = "";
		this.txtIntroTransition.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtIntroTransition.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtIntroTransition.CustomButton.TabIndex = 1;
		this.txtIntroTransition.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtIntroTransition.CustomButton.UseSelectable = true;
		this.txtIntroTransition.Lines = new string[0];
		this.txtIntroTransition.Location = new System.Drawing.Point(86, 25);
		this.txtIntroTransition.MaxLength = 32767;
		this.txtIntroTransition.Name = "txtIntroTransition";
		this.txtIntroTransition.PasswordChar = '\0';
		this.txtIntroTransition.ReadOnly = true;
		this.txtIntroTransition.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtIntroTransition.SelectedText = "";
		this.txtIntroTransition.SelectionLength = 0;
		this.txtIntroTransition.SelectionStart = 0;
		this.txtIntroTransition.ShortcutsEnabled = true;
		this.txtIntroTransition.ShowButton = true;
		this.txtIntroTransition.ShowClearButton = true;
		this.txtIntroTransition.Size = new System.Drawing.Size(406, 23);
		this.txtIntroTransition.TabIndex = 52;
		this.txtIntroTransition.UseSelectable = true;
		this.txtIntroTransition.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtIntroTransition.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtIntroTransition.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtIntroTransition_ButtonClick);
		this.tpVideo.Controls.Add(this.grpColorEnhancer);
		this.tpVideo.Controls.Add(this.grpVideoEnhancer);
		this.tpVideo.Controls.Add(this.grpVideoSetting);
		this.tpVideo.HorizontalScrollbar = true;
		this.tpVideo.HorizontalScrollbarBarColor = false;
		this.tpVideo.HorizontalScrollbarHighlightOnWheel = false;
		this.tpVideo.HorizontalScrollbarSize = 12;
		this.tpVideo.Location = new System.Drawing.Point(4, 34);
		this.tpVideo.Name = "tpVideo";
		this.tpVideo.Size = new System.Drawing.Size(632, 372);
		this.tpVideo.Style = MetroFramework.MetroColorStyle.Silver;
		this.tpVideo.TabIndex = 1;
		this.tpVideo.Text = "Video";
		this.tpVideo.VerticalScrollbar = true;
		this.tpVideo.VerticalScrollbarBarColor = true;
		this.tpVideo.VerticalScrollbarHighlightOnWheel = true;
		this.tpVideo.VerticalScrollbarSize = 12;
		this.grpColorEnhancer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpColorEnhancer.BackColor = System.Drawing.Color.Transparent;
		this.grpColorEnhancer.Controls.Add(this.lblLinkDebanding);
		this.grpColorEnhancer.Controls.Add(this.lblColorSaturationLevel);
		this.grpColorEnhancer.Controls.Add(this.lblColorContrastLevel);
		this.grpColorEnhancer.Controls.Add(this.lblColorSaturation);
		this.grpColorEnhancer.Controls.Add(this.tbColorSaturation);
		this.grpColorEnhancer.Controls.Add(this.lblColorContrast);
		this.grpColorEnhancer.Controls.Add(this.tbColorContrast);
		this.grpColorEnhancer.Controls.Add(this.lblColorEnhancer);
		this.grpColorEnhancer.Controls.Add(this.lblColorDebanding);
		this.grpColorEnhancer.Controls.Add(this.cboColorDebanding);
		this.grpColorEnhancer.Controls.Add(this.lblColorBrightnessLevel);
		this.grpColorEnhancer.Controls.Add(this.lblColorBrightness);
		this.grpColorEnhancer.Controls.Add(this.tbColorBrightness);
		this.grpColorEnhancer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpColorEnhancer.Location = new System.Drawing.Point(13, 414);
		this.grpColorEnhancer.Name = "grpColorEnhancer";
		this.grpColorEnhancer.Size = new System.Drawing.Size(592, 193);
		this.grpColorEnhancer.TabIndex = 51;
		this.grpColorEnhancer.TabStop = false;
		this.lblLinkDebanding.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblLinkDebanding.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblLinkDebanding.Location = new System.Drawing.Point(74, 162);
		this.lblLinkDebanding.Name = "lblLinkDebanding";
		this.lblLinkDebanding.Size = new System.Drawing.Size(49, 15);
		this.lblLinkDebanding.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblLinkDebanding.TabIndex = 51;
		this.lblLinkDebanding.Text = "Example";
		this.lblLinkDebanding.UseSelectable = true;
		this.lblLinkDebanding.Click += new System.EventHandler(this.lblLinkDebanding_Click);
		this.lblColorSaturationLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblColorSaturationLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblColorSaturationLevel.Location = new System.Drawing.Point(541, 111);
		this.lblColorSaturationLevel.Name = "lblColorSaturationLevel";
		this.lblColorSaturationLevel.Size = new System.Drawing.Size(43, 15);
		this.lblColorSaturationLevel.TabIndex = 43;
		this.lblColorSaturationLevel.Text = "Disable";
		this.lblColorSaturationLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblColorContrastLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblColorContrastLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblColorContrastLevel.Location = new System.Drawing.Point(541, 68);
		this.lblColorContrastLevel.Name = "lblColorContrastLevel";
		this.lblColorContrastLevel.Size = new System.Drawing.Size(43, 15);
		this.lblColorContrastLevel.TabIndex = 42;
		this.lblColorContrastLevel.Text = "Disable";
		this.lblColorContrastLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblColorSaturation.AutoSize = true;
		this.lblColorSaturation.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblColorSaturation.Location = new System.Drawing.Point(8, 111);
		this.lblColorSaturation.Name = "lblColorSaturation";
		this.lblColorSaturation.Size = new System.Drawing.Size(58, 15);
		this.lblColorSaturation.TabIndex = 41;
		this.lblColorSaturation.Text = "Saturation";
		this.tbColorSaturation.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbColorSaturation.BackColor = System.Drawing.Color.Transparent;
		this.tbColorSaturation.LargeChange = 10;
		this.tbColorSaturation.Location = new System.Drawing.Point(8, 128);
		this.tbColorSaturation.Maximum = 200;
		this.tbColorSaturation.MouseWheelBarPartitions = 200;
		this.tbColorSaturation.Name = "tbColorSaturation";
		this.tbColorSaturation.Size = new System.Drawing.Size(576, 23);
		this.tbColorSaturation.TabIndex = 40;
		this.tbColorSaturation.Text = "metroTrackBar3";
		this.tbColorSaturation.Value = 100;
		this.tbColorSaturation.ValueChanged += new System.EventHandler(this.tbColorSaturation_ValueChanged);
		this.lblColorContrast.AutoSize = true;
		this.lblColorContrast.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblColorContrast.Location = new System.Drawing.Point(8, 68);
		this.lblColorContrast.Name = "lblColorContrast";
		this.lblColorContrast.Size = new System.Drawing.Size(50, 15);
		this.lblColorContrast.TabIndex = 38;
		this.lblColorContrast.Text = "Contrast";
		this.tbColorContrast.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbColorContrast.BackColor = System.Drawing.Color.Transparent;
		this.tbColorContrast.LargeChange = 10;
		this.tbColorContrast.Location = new System.Drawing.Point(8, 85);
		this.tbColorContrast.Maximum = 200;
		this.tbColorContrast.MouseWheelBarPartitions = 200;
		this.tbColorContrast.Name = "tbColorContrast";
		this.tbColorContrast.Size = new System.Drawing.Size(576, 23);
		this.tbColorContrast.TabIndex = 37;
		this.tbColorContrast.Text = "metroTrackBar8";
		this.tbColorContrast.Value = 100;
		this.tbColorContrast.ValueChanged += new System.EventHandler(this.tbColorContrast_ValueChanged);
		this.lblColorEnhancer.AutoSize = true;
		this.lblColorEnhancer.Location = new System.Drawing.Point(6, -3);
		this.lblColorEnhancer.Name = "lblColorEnhancer";
		this.lblColorEnhancer.Size = new System.Drawing.Size(99, 19);
		this.lblColorEnhancer.TabIndex = 22;
		this.lblColorEnhancer.Text = "Color Enhancer";
		this.lblColorDebanding.AutoSize = true;
		this.lblColorDebanding.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblColorDebanding.Location = new System.Drawing.Point(6, 162);
		this.lblColorDebanding.Name = "lblColorDebanding";
		this.lblColorDebanding.Size = new System.Drawing.Size(62, 15);
		this.lblColorDebanding.TabIndex = 28;
		this.lblColorDebanding.Text = "Debanding";
		this.cboColorDebanding.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboColorDebanding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboColorDebanding.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboColorDebanding.FormattingEnabled = true;
		this.cboColorDebanding.ItemHeight = 19;
		this.cboColorDebanding.Items.AddRange(new object[3] { "Disable", "Style 1", "Style 2" });
		this.cboColorDebanding.Location = new System.Drawing.Point(129, 157);
		this.cboColorDebanding.Name = "cboColorDebanding";
		this.cboColorDebanding.Size = new System.Drawing.Size(455, 25);
		this.cboColorDebanding.TabIndex = 27;
		this.cboColorDebanding.UseSelectable = true;
		this.lblColorBrightnessLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblColorBrightnessLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblColorBrightnessLevel.Location = new System.Drawing.Point(541, 25);
		this.lblColorBrightnessLevel.Name = "lblColorBrightnessLevel";
		this.lblColorBrightnessLevel.Size = new System.Drawing.Size(43, 15);
		this.lblColorBrightnessLevel.TabIndex = 36;
		this.lblColorBrightnessLevel.Text = "Disable";
		this.lblColorBrightnessLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblColorBrightness.AutoSize = true;
		this.lblColorBrightness.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblColorBrightness.Location = new System.Drawing.Point(8, 25);
		this.lblColorBrightness.Name = "lblColorBrightness";
		this.lblColorBrightness.Size = new System.Drawing.Size(59, 15);
		this.lblColorBrightness.TabIndex = 35;
		this.lblColorBrightness.Text = "Brightness";
		this.tbColorBrightness.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbColorBrightness.BackColor = System.Drawing.Color.Transparent;
		this.tbColorBrightness.LargeChange = 10;
		this.tbColorBrightness.Location = new System.Drawing.Point(8, 42);
		this.tbColorBrightness.Maximum = 200;
		this.tbColorBrightness.MouseWheelBarPartitions = 200;
		this.tbColorBrightness.Name = "tbColorBrightness";
		this.tbColorBrightness.Size = new System.Drawing.Size(576, 23);
		this.tbColorBrightness.TabIndex = 33;
		this.tbColorBrightness.Text = "metroTrackBar9";
		this.tbColorBrightness.Value = 100;
		this.tbColorBrightness.ValueChanged += new System.EventHandler(this.tbColorBrightness_ValueChanged);
		this.grpVideoEnhancer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpVideoEnhancer.BackColor = System.Drawing.Color.Transparent;
		this.grpVideoEnhancer.Controls.Add(this.lblVideoSmooth);
		this.grpVideoEnhancer.Controls.Add(this.cboVideoSmooth);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoResize);
		this.grpVideoEnhancer.Controls.Add(this.lblLinkRemover);
		this.grpVideoEnhancer.Controls.Add(this.lblLinkWarpSharp);
		this.grpVideoEnhancer.Controls.Add(this.lblLinkSharpen);
		this.grpVideoEnhancer.Controls.Add(this.lblLinkLineDarkener);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoWarpSharpLevel);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoSharpenLevel);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoWarpSharp);
		this.grpVideoEnhancer.Controls.Add(this.tbVideoWarpSharp);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoSharpen);
		this.grpVideoEnhancer.Controls.Add(this.tbVideoSharpen);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoEnhancer);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoNoiseRemover);
		this.grpVideoEnhancer.Controls.Add(this.cboVideoRemover);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoLineDarkenerLevel);
		this.grpVideoEnhancer.Controls.Add(this.lblVideoLineDarkener);
		this.grpVideoEnhancer.Controls.Add(this.tbVideoLineDarkener);
		this.grpVideoEnhancer.Controls.Add(this.cboVideoResize);
		this.grpVideoEnhancer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpVideoEnhancer.Location = new System.Drawing.Point(13, 152);
		this.grpVideoEnhancer.Name = "grpVideoEnhancer";
		this.grpVideoEnhancer.Size = new System.Drawing.Size(592, 256);
		this.grpVideoEnhancer.TabIndex = 50;
		this.grpVideoEnhancer.TabStop = false;
		this.lblVideoSmooth.AutoSize = true;
		this.lblVideoSmooth.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoSmooth.Location = new System.Drawing.Point(8, 55);
		this.lblVideoSmooth.Name = "lblVideoSmooth";
		this.lblVideoSmooth.Size = new System.Drawing.Size(150, 15);
		this.lblVideoSmooth.TabIndex = 54;
		this.lblVideoSmooth.Text = "Motion Interpolation (60FPS)";
		this.cboVideoSmooth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboVideoSmooth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboVideoSmooth.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboVideoSmooth.FormattingEnabled = true;
		this.cboVideoSmooth.ItemHeight = 19;
		this.cboVideoSmooth.Items.AddRange(new object[4] { "Disable", "Smooth", "Overlap", "Subtitle Only (Best for Karaoke)" });
		this.cboVideoSmooth.Location = new System.Drawing.Point(164, 50);
		this.cboVideoSmooth.Name = "cboVideoSmooth";
		this.cboVideoSmooth.Size = new System.Drawing.Size(420, 25);
		this.cboVideoSmooth.TabIndex = 53;
		this.cboVideoSmooth.UseSelectable = true;
		this.cboVideoSmooth.DropDownClosed += new System.EventHandler(this.cboVideoSmooth_DropDownClosed);
		this.lblVideoResize.AutoSize = true;
		this.lblVideoResize.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoResize.Location = new System.Drawing.Point(87, 24);
		this.lblVideoResize.Name = "lblVideoResize";
		this.lblVideoResize.Size = new System.Drawing.Size(71, 15);
		this.lblVideoResize.TabIndex = 52;
		this.lblVideoResize.Text = "Resize Video";
		this.lblLinkRemover.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblLinkRemover.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblLinkRemover.Location = new System.Drawing.Point(147, 225);
		this.lblLinkRemover.Name = "lblLinkRemover";
		this.lblLinkRemover.Size = new System.Drawing.Size(49, 15);
		this.lblLinkRemover.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblLinkRemover.TabIndex = 50;
		this.lblLinkRemover.Text = "Example";
		this.lblLinkRemover.UseSelectable = true;
		this.lblLinkRemover.Click += new System.EventHandler(this.lblLinkRemover_Click);
		this.lblLinkWarpSharp.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblLinkWarpSharp.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblLinkWarpSharp.Location = new System.Drawing.Point(84, 174);
		this.lblLinkWarpSharp.Name = "lblLinkWarpSharp";
		this.lblLinkWarpSharp.Size = new System.Drawing.Size(49, 15);
		this.lblLinkWarpSharp.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblLinkWarpSharp.TabIndex = 49;
		this.lblLinkWarpSharp.Text = "Example";
		this.lblLinkWarpSharp.UseSelectable = true;
		this.lblLinkWarpSharp.Click += new System.EventHandler(this.lblLinkWarpSharp_Click);
		this.lblLinkSharpen.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblLinkSharpen.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblLinkSharpen.Location = new System.Drawing.Point(84, 131);
		this.lblLinkSharpen.Name = "lblLinkSharpen";
		this.lblLinkSharpen.Size = new System.Drawing.Size(49, 15);
		this.lblLinkSharpen.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblLinkSharpen.TabIndex = 48;
		this.lblLinkSharpen.Text = "Example";
		this.lblLinkSharpen.UseSelectable = true;
		this.lblLinkSharpen.Click += new System.EventHandler(this.lblLinkSharpen_Click);
		this.lblLinkLineDarkener.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblLinkLineDarkener.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblLinkLineDarkener.Location = new System.Drawing.Point(84, 88);
		this.lblLinkLineDarkener.Name = "lblLinkLineDarkener";
		this.lblLinkLineDarkener.Size = new System.Drawing.Size(49, 15);
		this.lblLinkLineDarkener.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblLinkLineDarkener.TabIndex = 47;
		this.lblLinkLineDarkener.Text = "Example";
		this.lblLinkLineDarkener.UseSelectable = true;
		this.lblLinkLineDarkener.Click += new System.EventHandler(this.lblLinkLineDarkener_Click);
		this.lblVideoWarpSharpLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblVideoWarpSharpLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoWarpSharpLevel.Location = new System.Drawing.Point(541, 174);
		this.lblVideoWarpSharpLevel.Name = "lblVideoWarpSharpLevel";
		this.lblVideoWarpSharpLevel.Size = new System.Drawing.Size(43, 15);
		this.lblVideoWarpSharpLevel.TabIndex = 43;
		this.lblVideoWarpSharpLevel.Text = "Disable";
		this.lblVideoWarpSharpLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblVideoSharpenLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblVideoSharpenLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoSharpenLevel.Location = new System.Drawing.Point(541, 131);
		this.lblVideoSharpenLevel.Name = "lblVideoSharpenLevel";
		this.lblVideoSharpenLevel.Size = new System.Drawing.Size(43, 15);
		this.lblVideoSharpenLevel.TabIndex = 42;
		this.lblVideoSharpenLevel.Text = "Disable";
		this.lblVideoSharpenLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblVideoWarpSharp.AutoSize = true;
		this.lblVideoWarpSharp.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoWarpSharp.Location = new System.Drawing.Point(8, 174);
		this.lblVideoWarpSharp.Name = "lblVideoWarpSharp";
		this.lblVideoWarpSharp.Size = new System.Drawing.Size(66, 15);
		this.lblVideoWarpSharp.TabIndex = 41;
		this.lblVideoWarpSharp.Text = "Warp Sharp";
		this.tbVideoWarpSharp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbVideoWarpSharp.BackColor = System.Drawing.Color.Transparent;
		this.tbVideoWarpSharp.LargeChange = 10;
		this.tbVideoWarpSharp.Location = new System.Drawing.Point(8, 191);
		this.tbVideoWarpSharp.MouseWheelBarPartitions = 100;
		this.tbVideoWarpSharp.Name = "tbVideoWarpSharp";
		this.tbVideoWarpSharp.Size = new System.Drawing.Size(576, 23);
		this.tbVideoWarpSharp.TabIndex = 40;
		this.tbVideoWarpSharp.Text = "metroTrackBar7";
		this.tbVideoWarpSharp.Value = 0;
		this.tbVideoWarpSharp.ValueChanged += new System.EventHandler(this.tbVideoWarpSharp_ValueChanged);
		this.lblVideoSharpen.AutoSize = true;
		this.lblVideoSharpen.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoSharpen.Location = new System.Drawing.Point(8, 131);
		this.lblVideoSharpen.Name = "lblVideoSharpen";
		this.lblVideoSharpen.Size = new System.Drawing.Size(48, 15);
		this.lblVideoSharpen.TabIndex = 38;
		this.lblVideoSharpen.Text = "Sharpen";
		this.tbVideoSharpen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbVideoSharpen.BackColor = System.Drawing.Color.Transparent;
		this.tbVideoSharpen.LargeChange = 10;
		this.tbVideoSharpen.Location = new System.Drawing.Point(8, 148);
		this.tbVideoSharpen.MouseWheelBarPartitions = 100;
		this.tbVideoSharpen.Name = "tbVideoSharpen";
		this.tbVideoSharpen.Size = new System.Drawing.Size(576, 23);
		this.tbVideoSharpen.TabIndex = 37;
		this.tbVideoSharpen.Text = "metroTrackBar4";
		this.tbVideoSharpen.Value = 0;
		this.tbVideoSharpen.ValueChanged += new System.EventHandler(this.tbVideoSharpen_ValueChanged);
		this.lblVideoEnhancer.AutoSize = true;
		this.lblVideoEnhancer.Location = new System.Drawing.Point(6, -3);
		this.lblVideoEnhancer.Name = "lblVideoEnhancer";
		this.lblVideoEnhancer.Size = new System.Drawing.Size(100, 19);
		this.lblVideoEnhancer.TabIndex = 22;
		this.lblVideoEnhancer.Text = "Video Enhancer";
		this.lblVideoNoiseRemover.AutoSize = true;
		this.lblVideoNoiseRemover.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoNoiseRemover.Location = new System.Drawing.Point(6, 225);
		this.lblVideoNoiseRemover.Name = "lblVideoNoiseRemover";
		this.lblVideoNoiseRemover.Size = new System.Drawing.Size(135, 15);
		this.lblVideoNoiseRemover.TabIndex = 28;
		this.lblVideoNoiseRemover.Text = "Mosquito Noise Remover";
		this.cboVideoRemover.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboVideoRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboVideoRemover.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboVideoRemover.FormattingEnabled = true;
		this.cboVideoRemover.ItemHeight = 19;
		this.cboVideoRemover.Items.AddRange(new object[4] { "Disable", "Level 1", "Level 2", "Level 3" });
		this.cboVideoRemover.Location = new System.Drawing.Point(202, 220);
		this.cboVideoRemover.Name = "cboVideoRemover";
		this.cboVideoRemover.Size = new System.Drawing.Size(382, 25);
		this.cboVideoRemover.TabIndex = 27;
		this.cboVideoRemover.UseSelectable = true;
		this.lblVideoLineDarkenerLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblVideoLineDarkenerLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoLineDarkenerLevel.Location = new System.Drawing.Point(541, 88);
		this.lblVideoLineDarkenerLevel.Name = "lblVideoLineDarkenerLevel";
		this.lblVideoLineDarkenerLevel.Size = new System.Drawing.Size(43, 15);
		this.lblVideoLineDarkenerLevel.TabIndex = 36;
		this.lblVideoLineDarkenerLevel.Text = "Disable";
		this.lblVideoLineDarkenerLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblVideoLineDarkener.AutoSize = true;
		this.lblVideoLineDarkener.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoLineDarkener.Location = new System.Drawing.Point(8, 88);
		this.lblVideoLineDarkener.Name = "lblVideoLineDarkener";
		this.lblVideoLineDarkener.Size = new System.Drawing.Size(74, 15);
		this.lblVideoLineDarkener.TabIndex = 35;
		this.lblVideoLineDarkener.Text = "Line Darkener";
		this.tbVideoLineDarkener.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbVideoLineDarkener.BackColor = System.Drawing.Color.Transparent;
		this.tbVideoLineDarkener.LargeChange = 10;
		this.tbVideoLineDarkener.Location = new System.Drawing.Point(8, 105);
		this.tbVideoLineDarkener.MouseWheelBarPartitions = 100;
		this.tbVideoLineDarkener.Name = "tbVideoLineDarkener";
		this.tbVideoLineDarkener.Size = new System.Drawing.Size(576, 23);
		this.tbVideoLineDarkener.TabIndex = 33;
		this.tbVideoLineDarkener.Value = 0;
		this.tbVideoLineDarkener.ValueChanged += new System.EventHandler(this.tbVideoLineDarkener_ValueChanged);
		this.cboVideoResize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboVideoResize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboVideoResize.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboVideoResize.FormattingEnabled = true;
		this.cboVideoResize.ItemHeight = 19;
		this.cboVideoResize.Items.AddRange(new object[5] { "Original", "480p", "720p", "1080p", "4K (2160p)" });
		this.cboVideoResize.Location = new System.Drawing.Point(164, 19);
		this.cboVideoResize.Name = "cboVideoResize";
		this.cboVideoResize.Size = new System.Drawing.Size(420, 25);
		this.cboVideoResize.TabIndex = 51;
		this.cboVideoResize.UseSelectable = true;
		this.grpVideoSetting.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpVideoSetting.BackColor = System.Drawing.Color.Transparent;
		this.grpVideoSetting.Controls.Add(this.lblVideoPreset);
		this.grpVideoSetting.Controls.Add(this.cboVideoPreset);
		this.grpVideoSetting.Controls.Add(this.lblVideoQualityLevel);
		this.grpVideoSetting.Controls.Add(this.lblVideoQuality);
		this.grpVideoSetting.Controls.Add(this.tbVideo);
		this.grpVideoSetting.Controls.Add(this.lblVideoEncoder);
		this.grpVideoSetting.Controls.Add(this.cboVideoEncoder);
		this.grpVideoSetting.Controls.Add(this.lblVideoSetting);
		this.grpVideoSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpVideoSetting.Location = new System.Drawing.Point(13, 14);
		this.grpVideoSetting.Name = "grpVideoSetting";
		this.grpVideoSetting.Size = new System.Drawing.Size(592, 132);
		this.grpVideoSetting.TabIndex = 49;
		this.grpVideoSetting.TabStop = false;
		this.lblVideoPreset.AutoSize = true;
		this.lblVideoPreset.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoPreset.Location = new System.Drawing.Point(6, 55);
		this.lblVideoPreset.Name = "lblVideoPreset";
		this.lblVideoPreset.Size = new System.Drawing.Size(39, 15);
		this.lblVideoPreset.TabIndex = 38;
		this.lblVideoPreset.Text = "Preset";
		this.cboVideoPreset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboVideoPreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboVideoPreset.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboVideoPreset.FormattingEnabled = true;
		this.cboVideoPreset.ItemHeight = 19;
		this.cboVideoPreset.Items.AddRange(new object[4] { "Slow", "Medium", "Fast", "Very Fast" });
		this.cboVideoPreset.Location = new System.Drawing.Point(60, 50);
		this.cboVideoPreset.Name = "cboVideoPreset";
		this.cboVideoPreset.Size = new System.Drawing.Size(524, 25);
		this.cboVideoPreset.TabIndex = 37;
		this.cboVideoPreset.UseSelectable = true;
		this.lblVideoQualityLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblVideoQualityLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoQualityLevel.Location = new System.Drawing.Point(448, 84);
		this.lblVideoQualityLevel.Name = "lblVideoQualityLevel";
		this.lblVideoQualityLevel.Size = new System.Drawing.Size(136, 15);
		this.lblVideoQualityLevel.TabIndex = 36;
		this.lblVideoQualityLevel.Text = "<< Highest 20 Lowest >>";
		this.lblVideoQualityLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
		this.lblVideoQuality.AutoSize = true;
		this.lblVideoQuality.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoQuality.Location = new System.Drawing.Point(8, 85);
		this.lblVideoQuality.Name = "lblVideoQuality";
		this.lblVideoQuality.Size = new System.Drawing.Size(289, 15);
		this.lblVideoQuality.TabIndex = 35;
		this.lblVideoQuality.Text = "Quality (CRF/QP) [Recommend for TV 20 - 22, BD 15 - 17]";
		this.tbVideo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbVideo.BackColor = System.Drawing.Color.Transparent;
		this.tbVideo.Location = new System.Drawing.Point(8, 102);
		this.tbVideo.Maximum = 28;
		this.tbVideo.Minimum = 10;
		this.tbVideo.MouseWheelBarPartitions = 18;
		this.tbVideo.Name = "tbVideo";
		this.tbVideo.Size = new System.Drawing.Size(576, 23);
		this.tbVideo.TabIndex = 33;
		this.tbVideo.Value = 20;
		this.tbVideo.ValueChanged += new System.EventHandler(this.tbVideo_ValueChanged);
		this.lblVideoEncoder.AutoSize = true;
		this.lblVideoEncoder.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVideoEncoder.Location = new System.Drawing.Point(6, 24);
		this.lblVideoEncoder.Name = "lblVideoEncoder";
		this.lblVideoEncoder.Size = new System.Drawing.Size(48, 15);
		this.lblVideoEncoder.TabIndex = 26;
		this.lblVideoEncoder.Text = "Encoder";
		this.cboVideoEncoder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboVideoEncoder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboVideoEncoder.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboVideoEncoder.FormattingEnabled = true;
		this.cboVideoEncoder.ItemHeight = 19;
		this.cboVideoEncoder.Items.AddRange(new object[11]
		{
			"Software Encoder - H.264", "Software Encoder - HEVC 8-bit", "Software Encoder - HEVC 10-bit", "Intel Encoder - H.264", "Intel Encoder - HEVC 8-bit", "Intel Encoder - HEVC 10-bit", "Nvidia Encoder - H.264", "Nvidia Encoder - HEVC 8-bit", "Nvidia Encoder - HEVC 10-bit", "AMD Encoder - H.264",
			"AMD Encoder - HEVC 8-bit"
		});
		this.cboVideoEncoder.Location = new System.Drawing.Point(60, 19);
		this.cboVideoEncoder.Name = "cboVideoEncoder";
		this.cboVideoEncoder.Size = new System.Drawing.Size(524, 25);
		this.cboVideoEncoder.TabIndex = 25;
		this.cboVideoEncoder.UseSelectable = true;
		this.cboVideoEncoder.SelectedIndexChanged += new System.EventHandler(this.cboVideoEncoder_SelectedIndexChanged);
		this.lblVideoSetting.AutoSize = true;
		this.lblVideoSetting.Location = new System.Drawing.Point(6, -3);
		this.lblVideoSetting.Name = "lblVideoSetting";
		this.lblVideoSetting.Size = new System.Drawing.Size(87, 19);
		this.lblVideoSetting.TabIndex = 22;
		this.lblVideoSetting.Text = "Video Setting";
		this.tpLog.Controls.Add(this.pnLog);
		this.tpLog.Controls.Add(this.lblTroubleLink);
		this.tpLog.Controls.Add(this.lblTrouble);
		this.tpLog.HorizontalScrollbar = true;
		this.tpLog.HorizontalScrollbarBarColor = false;
		this.tpLog.HorizontalScrollbarHighlightOnWheel = false;
		this.tpLog.HorizontalScrollbarSize = 12;
		this.tpLog.Location = new System.Drawing.Point(4, 34);
		this.tpLog.Name = "tpLog";
		this.tpLog.Size = new System.Drawing.Size(632, 372);
		this.tpLog.TabIndex = 6;
		this.tpLog.Text = "Log";
		this.tpLog.VerticalScrollbar = true;
		this.tpLog.VerticalScrollbarBarColor = true;
		this.tpLog.VerticalScrollbarHighlightOnWheel = true;
		this.tpLog.VerticalScrollbarSize = 12;
		this.pnLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pnLog.BackColor = System.Drawing.Color.White;
		this.pnLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnLog.Controls.Add(this.txtLog);
		this.pnLog.Location = new System.Drawing.Point(1, 34);
		this.pnLog.Name = "pnLog";
		this.pnLog.Size = new System.Drawing.Size(627, 338);
		this.pnLog.TabIndex = 67;
		this.txtLog.BackColor = System.Drawing.Color.White;
		this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtLog.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtLog.ForeColor = System.Drawing.SystemColors.WindowText;
		this.txtLog.Location = new System.Drawing.Point(0, 0);
		this.txtLog.Name = "txtLog";
		this.txtLog.ReadOnly = true;
		this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
		this.txtLog.Size = new System.Drawing.Size(625, 336);
		this.txtLog.TabIndex = 67;
		this.txtLog.Text = "";
		this.txtLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtLog_LinkClicked);
		this.lblTroubleLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblTroubleLink.BackColor = System.Drawing.Color.Transparent;
		this.lblTroubleLink.FontSize = MetroFramework.MetroLinkSize.Tall;
		this.lblTroubleLink.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.lblTroubleLink.ForeColor = System.Drawing.Color.RoyalBlue;
		this.lblTroubleLink.Location = new System.Drawing.Point(544, 3);
		this.lblTroubleLink.Name = "lblTroubleLink";
		this.lblTroubleLink.Size = new System.Drawing.Size(83, 26);
		this.lblTroubleLink.Style = MetroFramework.MetroColorStyle.Orange;
		this.lblTroubleLink.TabIndex = 63;
		this.lblTroubleLink.Text = "click here";
		this.lblTroubleLink.UseSelectable = true;
		this.lblTroubleLink.Click += new System.EventHandler(this.lblTroubleLink_Click);
		this.lblTrouble.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblTrouble.AutoSize = true;
		this.lblTrouble.FontSize = MetroFramework.MetroLabelSize.Tall;
		this.lblTrouble.Location = new System.Drawing.Point(303, 4);
		this.lblTrouble.Name = "lblTrouble";
		this.lblTrouble.Size = new System.Drawing.Size(248, 25);
		this.lblTrouble.TabIndex = 64;
		this.lblTrouble.Text = "Send this to us if you in trouble";
		this.tpAudio.Controls.Add(this.grpVolumeControl);
		this.tpAudio.Controls.Add(this.grpAudioSetting);
		this.tpAudio.HorizontalScrollbar = true;
		this.tpAudio.HorizontalScrollbarBarColor = false;
		this.tpAudio.HorizontalScrollbarHighlightOnWheel = false;
		this.tpAudio.HorizontalScrollbarSize = 12;
		this.tpAudio.Location = new System.Drawing.Point(4, 34);
		this.tpAudio.Name = "tpAudio";
		this.tpAudio.Size = new System.Drawing.Size(632, 372);
		this.tpAudio.TabIndex = 2;
		this.tpAudio.Text = "Audio";
		this.tpAudio.VerticalScrollbar = true;
		this.tpAudio.VerticalScrollbarBarColor = true;
		this.tpAudio.VerticalScrollbarHighlightOnWheel = true;
		this.tpAudio.VerticalScrollbarSize = 12;
		this.grpVolumeControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpVolumeControl.BackColor = System.Drawing.Color.Transparent;
		this.grpVolumeControl.Controls.Add(this.lblVolumeEndCardLevel);
		this.grpVolumeControl.Controls.Add(this.lblVolumeEndCard);
		this.grpVolumeControl.Controls.Add(this.tbVolumeEndCard);
		this.grpVolumeControl.Controls.Add(this.lblVolumeIntroLevel);
		this.grpVolumeControl.Controls.Add(this.lblVolumeIntro);
		this.grpVolumeControl.Controls.Add(this.tbVolumeIntro);
		this.grpVolumeControl.Controls.Add(this.lblVolumeControl);
		this.grpVolumeControl.Controls.Add(this.lblVolumeSourceLevel);
		this.grpVolumeControl.Controls.Add(this.lblVolumeSource);
		this.grpVolumeControl.Controls.Add(this.tbVolumeSource);
		this.grpVolumeControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpVolumeControl.Location = new System.Drawing.Point(13, 135);
		this.grpVolumeControl.Name = "grpVolumeControl";
		this.grpVolumeControl.Size = new System.Drawing.Size(606, 153);
		this.grpVolumeControl.TabIndex = 52;
		this.grpVolumeControl.TabStop = false;
		this.lblVolumeEndCardLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblVolumeEndCardLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVolumeEndCardLevel.Location = new System.Drawing.Point(500, 106);
		this.lblVolumeEndCardLevel.Name = "lblVolumeEndCardLevel";
		this.lblVolumeEndCardLevel.Size = new System.Drawing.Size(98, 15);
		this.lblVolumeEndCardLevel.TabIndex = 42;
		this.lblVolumeEndCardLevel.Text = "100%";
		this.lblVolumeEndCardLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblVolumeEndCard.AutoSize = true;
		this.lblVolumeEndCard.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVolumeEndCard.Location = new System.Drawing.Point(8, 106);
		this.lblVolumeEndCard.Name = "lblVolumeEndCard";
		this.lblVolumeEndCard.Size = new System.Drawing.Size(50, 15);
		this.lblVolumeEndCard.TabIndex = 41;
		this.lblVolumeEndCard.Text = "EndCard";
		this.tbVolumeEndCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbVolumeEndCard.BackColor = System.Drawing.Color.Transparent;
		this.tbVolumeEndCard.Enabled = false;
		this.tbVolumeEndCard.LargeChange = 10;
		this.tbVolumeEndCard.Location = new System.Drawing.Point(8, 123);
		this.tbVolumeEndCard.Maximum = 500;
		this.tbVolumeEndCard.MouseWheelBarPartitions = 100;
		this.tbVolumeEndCard.Name = "tbVolumeEndCard";
		this.tbVolumeEndCard.Size = new System.Drawing.Size(590, 23);
		this.tbVolumeEndCard.TabIndex = 40;
		this.tbVolumeEndCard.Value = 100;
		this.tbVolumeEndCard.ValueChanged += new System.EventHandler(this.tbVolumeEndCard_ValueChanged);
		this.lblVolumeIntroLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblVolumeIntroLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVolumeIntroLevel.Location = new System.Drawing.Point(500, 63);
		this.lblVolumeIntroLevel.Name = "lblVolumeIntroLevel";
		this.lblVolumeIntroLevel.Size = new System.Drawing.Size(98, 15);
		this.lblVolumeIntroLevel.TabIndex = 39;
		this.lblVolumeIntroLevel.Text = "100%";
		this.lblVolumeIntroLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblVolumeIntro.AutoSize = true;
		this.lblVolumeIntro.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVolumeIntro.Location = new System.Drawing.Point(8, 63);
		this.lblVolumeIntro.Name = "lblVolumeIntro";
		this.lblVolumeIntro.Size = new System.Drawing.Size(31, 15);
		this.lblVolumeIntro.TabIndex = 38;
		this.lblVolumeIntro.Text = "Intro";
		this.tbVolumeIntro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbVolumeIntro.BackColor = System.Drawing.Color.Transparent;
		this.tbVolumeIntro.Enabled = false;
		this.tbVolumeIntro.LargeChange = 10;
		this.tbVolumeIntro.Location = new System.Drawing.Point(8, 80);
		this.tbVolumeIntro.Maximum = 500;
		this.tbVolumeIntro.MouseWheelBarPartitions = 100;
		this.tbVolumeIntro.Name = "tbVolumeIntro";
		this.tbVolumeIntro.Size = new System.Drawing.Size(590, 23);
		this.tbVolumeIntro.TabIndex = 37;
		this.tbVolumeIntro.Value = 100;
		this.tbVolumeIntro.ValueChanged += new System.EventHandler(this.tbVolumeIntro_ValueChanged);
		this.lblVolumeControl.AutoSize = true;
		this.lblVolumeControl.Location = new System.Drawing.Point(6, -3);
		this.lblVolumeControl.Name = "lblVolumeControl";
		this.lblVolumeControl.Size = new System.Drawing.Size(101, 19);
		this.lblVolumeControl.TabIndex = 22;
		this.lblVolumeControl.Text = "Volume Control";
		this.lblVolumeSourceLevel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblVolumeSourceLevel.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVolumeSourceLevel.Location = new System.Drawing.Point(500, 20);
		this.lblVolumeSourceLevel.Name = "lblVolumeSourceLevel";
		this.lblVolumeSourceLevel.Size = new System.Drawing.Size(98, 15);
		this.lblVolumeSourceLevel.TabIndex = 36;
		this.lblVolumeSourceLevel.Text = "100%";
		this.lblVolumeSourceLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.lblVolumeSource.AutoSize = true;
		this.lblVolumeSource.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblVolumeSource.Location = new System.Drawing.Point(8, 20);
		this.lblVolumeSource.Name = "lblVolumeSource";
		this.lblVolumeSource.Size = new System.Drawing.Size(41, 15);
		this.lblVolumeSource.TabIndex = 35;
		this.lblVolumeSource.Text = "Source";
		this.tbVolumeSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbVolumeSource.BackColor = System.Drawing.Color.Transparent;
		this.tbVolumeSource.LargeChange = 10;
		this.tbVolumeSource.Location = new System.Drawing.Point(8, 37);
		this.tbVolumeSource.Maximum = 500;
		this.tbVolumeSource.MouseWheelBarPartitions = 100;
		this.tbVolumeSource.Name = "tbVolumeSource";
		this.tbVolumeSource.Size = new System.Drawing.Size(590, 23);
		this.tbVolumeSource.TabIndex = 33;
		this.tbVolumeSource.Value = 100;
		this.tbVolumeSource.ValueChanged += new System.EventHandler(this.tbVolumeSource_ValueChanged);
		this.grpAudioSetting.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpAudioSetting.BackColor = System.Drawing.Color.Transparent;
		this.grpAudioSetting.Controls.Add(this.lblAudioTrack);
		this.grpAudioSetting.Controls.Add(this.cboAudioTrack);
		this.grpAudioSetting.Controls.Add(this.cboAudioSampleRates);
		this.grpAudioSetting.Controls.Add(this.lblAudioQuality);
		this.grpAudioSetting.Controls.Add(this.cboAudioQuality);
		this.grpAudioSetting.Controls.Add(this.lblAudioFormat);
		this.grpAudioSetting.Controls.Add(this.cboAudioFormat);
		this.grpAudioSetting.Controls.Add(this.lblAudioSetting);
		this.grpAudioSetting.Controls.Add(this.cboAudioTrack2);
		this.grpAudioSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpAudioSetting.Location = new System.Drawing.Point(13, 14);
		this.grpAudioSetting.Name = "grpAudioSetting";
		this.grpAudioSetting.Size = new System.Drawing.Size(606, 115);
		this.grpAudioSetting.TabIndex = 51;
		this.grpAudioSetting.TabStop = false;
		this.lblAudioTrack.AutoSize = true;
		this.lblAudioTrack.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblAudioTrack.Location = new System.Drawing.Point(6, 86);
		this.lblAudioTrack.Name = "lblAudioTrack";
		this.lblAudioTrack.Size = new System.Drawing.Size(31, 15);
		this.lblAudioTrack.TabIndex = 30;
		this.lblAudioTrack.Text = "Track";
		this.cboAudioTrack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboAudioTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboAudioTrack.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboAudioTrack.FormattingEnabled = true;
		this.cboAudioTrack.ItemHeight = 19;
		this.cboAudioTrack.Location = new System.Drawing.Point(56, 81);
		this.cboAudioTrack.Name = "cboAudioTrack";
		this.cboAudioTrack.Size = new System.Drawing.Size(542, 25);
		this.cboAudioTrack.TabIndex = 29;
		this.cboAudioTrack.UseSelectable = true;
		this.cboAudioSampleRates.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.cboAudioSampleRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboAudioSampleRates.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboAudioSampleRates.FormattingEnabled = true;
		this.cboAudioSampleRates.ItemHeight = 19;
		this.cboAudioSampleRates.Items.AddRange(new object[3] { "Original", "44100 kHz", "48000 kHz" });
		this.cboAudioSampleRates.Location = new System.Drawing.Point(437, 50);
		this.cboAudioSampleRates.Name = "cboAudioSampleRates";
		this.cboAudioSampleRates.Size = new System.Drawing.Size(161, 25);
		this.cboAudioSampleRates.TabIndex = 32;
		this.cboAudioSampleRates.UseSelectable = true;
		this.lblAudioQuality.AutoSize = true;
		this.lblAudioQuality.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblAudioQuality.Location = new System.Drawing.Point(6, 55);
		this.lblAudioQuality.Name = "lblAudioQuality";
		this.lblAudioQuality.Size = new System.Drawing.Size(41, 15);
		this.lblAudioQuality.TabIndex = 28;
		this.lblAudioQuality.Text = "Quality";
		this.cboAudioQuality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboAudioQuality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboAudioQuality.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboAudioQuality.FormattingEnabled = true;
		this.cboAudioQuality.ItemHeight = 19;
		this.cboAudioQuality.Items.AddRange(new object[4] { "128 Kbps Dafault", "192 Kbps", "256 Kbps", "320 Kbps" });
		this.cboAudioQuality.Location = new System.Drawing.Point(56, 50);
		this.cboAudioQuality.Name = "cboAudioQuality";
		this.cboAudioQuality.Size = new System.Drawing.Size(375, 25);
		this.cboAudioQuality.TabIndex = 27;
		this.cboAudioQuality.UseSelectable = true;
		this.lblAudioFormat.AutoSize = true;
		this.lblAudioFormat.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblAudioFormat.Location = new System.Drawing.Point(6, 24);
		this.lblAudioFormat.Name = "lblAudioFormat";
		this.lblAudioFormat.Size = new System.Drawing.Size(44, 15);
		this.lblAudioFormat.TabIndex = 26;
		this.lblAudioFormat.Text = "Format";
		this.cboAudioFormat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboAudioFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboAudioFormat.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboAudioFormat.FormattingEnabled = true;
		this.cboAudioFormat.ItemHeight = 19;
		this.cboAudioFormat.Items.AddRange(new object[2] { "AAC (Advanced Audio Coding)", "FLAC (Free Lossless Audio Codec)" });
		this.cboAudioFormat.Location = new System.Drawing.Point(56, 19);
		this.cboAudioFormat.Name = "cboAudioFormat";
		this.cboAudioFormat.Size = new System.Drawing.Size(542, 25);
		this.cboAudioFormat.TabIndex = 25;
		this.cboAudioFormat.UseSelectable = true;
		this.cboAudioFormat.SelectedIndexChanged += new System.EventHandler(this.cboAudioFormat_SelectedIndexChanged);
		this.lblAudioSetting.AutoSize = true;
		this.lblAudioSetting.Location = new System.Drawing.Point(6, -3);
		this.lblAudioSetting.Name = "lblAudioSetting";
		this.lblAudioSetting.Size = new System.Drawing.Size(88, 19);
		this.lblAudioSetting.TabIndex = 22;
		this.lblAudioSetting.Text = "Audio Setting";
		this.cboAudioTrack2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.cboAudioTrack2.Enabled = false;
		this.cboAudioTrack2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cboAudioTrack2.FontSize = MetroFramework.MetroComboBoxSize.Small;
		this.cboAudioTrack2.FormattingEnabled = true;
		this.cboAudioTrack2.ItemHeight = 19;
		this.cboAudioTrack2.Items.AddRange(new object[2] { "Can't change audio track in multi-selection mode.", "None" });
		this.cboAudioTrack2.Location = new System.Drawing.Point(56, 81);
		this.cboAudioTrack2.Name = "cboAudioTrack2";
		this.cboAudioTrack2.Size = new System.Drawing.Size(542, 25);
		this.cboAudioTrack2.TabIndex = 31;
		this.cboAudioTrack2.UseSelectable = true;
		this.tpMain.BackColor = System.Drawing.SystemColors.Control;
		this.tpMain.Controls.Add(this.splitIntroEndCard);
		this.tpMain.Controls.Add(this.grpClipDetails);
		this.tpMain.Controls.Add(this.grpKaraoke);
		this.tpMain.Controls.Add(this.grpSubtitle);
		this.tpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 222);
		this.tpMain.ForeColor = System.Drawing.SystemColors.ControlText;
		this.tpMain.HorizontalScrollbar = true;
		this.tpMain.HorizontalScrollbarBarColor = false;
		this.tpMain.HorizontalScrollbarHighlightOnWheel = false;
		this.tpMain.HorizontalScrollbarSize = 12;
		this.tpMain.Location = new System.Drawing.Point(4, 34);
		this.tpMain.Name = "tpMain";
		this.tpMain.Size = new System.Drawing.Size(632, 372);
		this.tpMain.Style = MetroFramework.MetroColorStyle.Pink;
		this.tpMain.TabIndex = 0;
		this.tpMain.Text = "Main";
		this.tpMain.VerticalScrollbar = true;
		this.tpMain.VerticalScrollbarBarColor = true;
		this.tpMain.VerticalScrollbarHighlightOnWheel = true;
		this.tpMain.VerticalScrollbarSize = 12;
		this.splitIntroEndCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitIntroEndCard.BackColor = System.Drawing.Color.White;
		this.splitIntroEndCard.ColumnCount = 2;
		this.splitIntroEndCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.splitIntroEndCard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.splitIntroEndCard.Controls.Add(this.grpIntro, 0, 0);
		this.splitIntroEndCard.Controls.Add(this.grpEndCard, 1, 0);
		this.splitIntroEndCard.Location = new System.Drawing.Point(10, 82);
		this.splitIntroEndCard.Name = "splitIntroEndCard";
		this.splitIntroEndCard.RowCount = 1;
		this.splitIntroEndCard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
		this.splitIntroEndCard.Size = new System.Drawing.Size(598, 144);
		this.splitIntroEndCard.TabIndex = 28;
		this.grpIntro.BackColor = System.Drawing.Color.Transparent;
		this.grpIntro.Controls.Add(this.chkIntroMusic);
		this.grpIntro.Controls.Add(this.togIntro);
		this.grpIntro.Controls.Add(this.lblIntroTimeSec);
		this.grpIntro.Controls.Add(this.udIntroTime);
		this.grpIntro.Controls.Add(this.lblIntroTime);
		this.grpIntro.Controls.Add(this.lblIntro);
		this.grpIntro.Controls.Add(this.txtIntroMusic);
		this.grpIntro.Controls.Add(this.txtIntro);
		this.grpIntro.Dock = System.Windows.Forms.DockStyle.Fill;
		this.grpIntro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpIntro.Location = new System.Drawing.Point(3, 3);
		this.grpIntro.Name = "grpIntro";
		this.grpIntro.Size = new System.Drawing.Size(293, 138);
		this.grpIntro.TabIndex = 17;
		this.grpIntro.TabStop = false;
		this.chkIntroMusic.AutoSize = true;
		this.chkIntroMusic.Enabled = false;
		this.chkIntroMusic.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
		this.chkIntroMusic.Location = new System.Drawing.Point(8, 58);
		this.chkIntroMusic.Name = "chkIntroMusic";
		this.chkIntroMusic.Size = new System.Drawing.Size(51, 15);
		this.chkIntroMusic.TabIndex = 70;
		this.chkIntroMusic.Text = "Music";
		this.chkIntroMusic.UseSelectable = true;
		this.togIntro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togIntro.AutoSize = true;
		this.togIntro.DisplayStatus = false;
		this.togIntro.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togIntro.Location = new System.Drawing.Point(237, 0);
		this.togIntro.Name = "togIntro";
		this.togIntro.Size = new System.Drawing.Size(50, 17);
		this.togIntro.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togIntro.TabIndex = 68;
		this.togIntro.Text = "Off";
		this.togIntro.UseSelectable = true;
		this.togIntro.CheckedChanged += new System.EventHandler(this.togIntro_CheckedChanged);
		this.togIntro.MouseUp += new System.Windows.Forms.MouseEventHandler(this.togIntro_MouseUp);
		this.lblIntroTimeSec.AutoSize = true;
		this.lblIntroTimeSec.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblIntroTimeSec.Location = new System.Drawing.Point(196, 111);
		this.lblIntroTimeSec.Name = "lblIntroTimeSec";
		this.lblIntroTimeSec.Size = new System.Drawing.Size(44, 15);
		this.lblIntroTimeSec.TabIndex = 28;
		this.lblIntroTimeSec.Text = "Second";
		this.udIntroTime.DecimalPlaces = 2;
		this.udIntroTime.Enabled = false;
		this.udIntroTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udIntroTime.Location = new System.Drawing.Point(140, 109);
		this.udIntroTime.Maximum = new decimal(new int[4] { 60, 0, 0, 0 });
		this.udIntroTime.Name = "udIntroTime";
		this.udIntroTime.Size = new System.Drawing.Size(50, 20);
		this.udIntroTime.TabIndex = 27;
		this.udIntroTime.Value = new decimal(new int[4] { 600, 0, 0, 131072 });
		this.udIntroTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.udIntroTime_KeyDown);
		this.udIntroTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.udIntroTime_MouseUp);
		this.lblIntroTime.AutoSize = true;
		this.lblIntroTime.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblIntroTime.Location = new System.Drawing.Point(8, 111);
		this.lblIntroTime.Name = "lblIntroTime";
		this.lblIntroTime.Size = new System.Drawing.Size(126, 15);
		this.lblIntroTime.TabIndex = 26;
		this.lblIntroTime.Text = "Intro Time (Picture Only)";
		this.lblIntro.AutoSize = true;
		this.lblIntro.Location = new System.Drawing.Point(6, -3);
		this.lblIntro.Name = "lblIntro";
		this.lblIntro.Size = new System.Drawing.Size(36, 19);
		this.lblIntro.TabIndex = 22;
		this.lblIntro.Text = "Intro";
		this.txtIntroMusic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtIntroMusic.CustomButton.Image = null;
		this.txtIntroMusic.CustomButton.Location = new System.Drawing.Point(256, 1);
		this.txtIntroMusic.CustomButton.Name = "";
		this.txtIntroMusic.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtIntroMusic.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtIntroMusic.CustomButton.TabIndex = 1;
		this.txtIntroMusic.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtIntroMusic.CustomButton.UseSelectable = true;
		this.txtIntroMusic.Enabled = false;
		this.txtIntroMusic.Lines = new string[0];
		this.txtIntroMusic.Location = new System.Drawing.Point(8, 79);
		this.txtIntroMusic.MaxLength = 32767;
		this.txtIntroMusic.Name = "txtIntroMusic";
		this.txtIntroMusic.PasswordChar = '\0';
		this.txtIntroMusic.ReadOnly = true;
		this.txtIntroMusic.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtIntroMusic.SelectedText = "";
		this.txtIntroMusic.SelectionLength = 0;
		this.txtIntroMusic.SelectionStart = 0;
		this.txtIntroMusic.ShortcutsEnabled = true;
		this.txtIntroMusic.ShowButton = true;
		this.txtIntroMusic.ShowClearButton = true;
		this.txtIntroMusic.Size = new System.Drawing.Size(278, 23);
		this.txtIntroMusic.TabIndex = 17;
		this.txtIntroMusic.UseSelectable = true;
		this.txtIntroMusic.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtIntroMusic.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtIntroMusic.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtIntroMusic_ButtonClick);
		this.txtIntro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtIntro.CustomButton.Image = null;
		this.txtIntro.CustomButton.Location = new System.Drawing.Point(256, 1);
		this.txtIntro.CustomButton.Name = "";
		this.txtIntro.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtIntro.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtIntro.CustomButton.TabIndex = 1;
		this.txtIntro.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtIntro.CustomButton.UseSelectable = true;
		this.txtIntro.Enabled = false;
		this.txtIntro.Lines = new string[0];
		this.txtIntro.Location = new System.Drawing.Point(8, 29);
		this.txtIntro.MaxLength = 32767;
		this.txtIntro.Name = "txtIntro";
		this.txtIntro.PasswordChar = '\0';
		this.txtIntro.ReadOnly = true;
		this.txtIntro.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtIntro.SelectedText = "";
		this.txtIntro.SelectionLength = 0;
		this.txtIntro.SelectionStart = 0;
		this.txtIntro.ShortcutsEnabled = true;
		this.txtIntro.ShowButton = true;
		this.txtIntro.ShowClearButton = true;
		this.txtIntro.Size = new System.Drawing.Size(278, 23);
		this.txtIntro.TabIndex = 13;
		this.txtIntro.UseSelectable = true;
		this.txtIntro.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtIntro.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtIntro.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtIntro_ButtonClick);
		this.grpEndCard.BackColor = System.Drawing.Color.Transparent;
		this.grpEndCard.Controls.Add(this.chkEndCardMusic);
		this.grpEndCard.Controls.Add(this.togEndCard);
		this.grpEndCard.Controls.Add(this.lblEndCardTimeSec);
		this.grpEndCard.Controls.Add(this.udEndCardTime);
		this.grpEndCard.Controls.Add(this.lblEndCardTime);
		this.grpEndCard.Controls.Add(this.lblEndCard);
		this.grpEndCard.Controls.Add(this.txtEndCardMusic);
		this.grpEndCard.Controls.Add(this.txtEndCard);
		this.grpEndCard.Dock = System.Windows.Forms.DockStyle.Fill;
		this.grpEndCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpEndCard.Location = new System.Drawing.Point(302, 3);
		this.grpEndCard.Name = "grpEndCard";
		this.grpEndCard.Size = new System.Drawing.Size(293, 138);
		this.grpEndCard.TabIndex = 26;
		this.grpEndCard.TabStop = false;
		this.chkEndCardMusic.AutoSize = true;
		this.chkEndCardMusic.Enabled = false;
		this.chkEndCardMusic.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
		this.chkEndCardMusic.Location = new System.Drawing.Point(8, 58);
		this.chkEndCardMusic.Name = "chkEndCardMusic";
		this.chkEndCardMusic.Size = new System.Drawing.Size(51, 15);
		this.chkEndCardMusic.TabIndex = 71;
		this.chkEndCardMusic.Text = "Music";
		this.chkEndCardMusic.UseSelectable = true;
		this.togEndCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togEndCard.AutoSize = true;
		this.togEndCard.DisplayStatus = false;
		this.togEndCard.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togEndCard.Location = new System.Drawing.Point(234, 0);
		this.togEndCard.Name = "togEndCard";
		this.togEndCard.Size = new System.Drawing.Size(50, 17);
		this.togEndCard.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togEndCard.TabIndex = 69;
		this.togEndCard.Text = "Off";
		this.togEndCard.UseSelectable = true;
		this.togEndCard.CheckedChanged += new System.EventHandler(this.togEndCard_CheckedChanged);
		this.togEndCard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.togEndCard_MouseUp);
		this.lblEndCardTimeSec.AutoSize = true;
		this.lblEndCardTimeSec.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblEndCardTimeSec.Location = new System.Drawing.Point(215, 111);
		this.lblEndCardTimeSec.Name = "lblEndCardTimeSec";
		this.lblEndCardTimeSec.Size = new System.Drawing.Size(44, 15);
		this.lblEndCardTimeSec.TabIndex = 31;
		this.lblEndCardTimeSec.Text = "Second";
		this.udEndCardTime.DecimalPlaces = 2;
		this.udEndCardTime.Enabled = false;
		this.udEndCardTime.Increment = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.udEndCardTime.Location = new System.Drawing.Point(159, 109);
		this.udEndCardTime.Maximum = new decimal(new int[4] { 60, 0, 0, 0 });
		this.udEndCardTime.Name = "udEndCardTime";
		this.udEndCardTime.Size = new System.Drawing.Size(50, 20);
		this.udEndCardTime.TabIndex = 30;
		this.udEndCardTime.Value = new decimal(new int[4] { 100, 0, 0, 131072 });
		this.udEndCardTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.udEndCardTime_KeyDown);
		this.udEndCardTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.udEndCardTime_MouseUp);
		this.lblEndCardTime.AutoSize = true;
		this.lblEndCardTime.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblEndCardTime.Location = new System.Drawing.Point(8, 111);
		this.lblEndCardTime.Name = "lblEndCardTime";
		this.lblEndCardTime.Size = new System.Drawing.Size(145, 15);
		this.lblEndCardTime.TabIndex = 29;
		this.lblEndCardTime.Text = "EndCard Time (Picture Only)";
		this.lblEndCard.AutoSize = true;
		this.lblEndCard.Location = new System.Drawing.Point(6, -3);
		this.lblEndCard.Name = "lblEndCard";
		this.lblEndCard.Size = new System.Drawing.Size(60, 19);
		this.lblEndCard.TabIndex = 22;
		this.lblEndCard.Text = "EndCard";
		this.txtEndCardMusic.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtEndCardMusic.CustomButton.Image = null;
		this.txtEndCardMusic.CustomButton.Location = new System.Drawing.Point(256, 1);
		this.txtEndCardMusic.CustomButton.Name = "";
		this.txtEndCardMusic.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtEndCardMusic.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtEndCardMusic.CustomButton.TabIndex = 1;
		this.txtEndCardMusic.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtEndCardMusic.CustomButton.UseSelectable = true;
		this.txtEndCardMusic.Enabled = false;
		this.txtEndCardMusic.Lines = new string[0];
		this.txtEndCardMusic.Location = new System.Drawing.Point(8, 79);
		this.txtEndCardMusic.MaxLength = 32767;
		this.txtEndCardMusic.Name = "txtEndCardMusic";
		this.txtEndCardMusic.PasswordChar = '\0';
		this.txtEndCardMusic.ReadOnly = true;
		this.txtEndCardMusic.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtEndCardMusic.SelectedText = "";
		this.txtEndCardMusic.SelectionLength = 0;
		this.txtEndCardMusic.SelectionStart = 0;
		this.txtEndCardMusic.ShortcutsEnabled = true;
		this.txtEndCardMusic.ShowButton = true;
		this.txtEndCardMusic.ShowClearButton = true;
		this.txtEndCardMusic.Size = new System.Drawing.Size(278, 23);
		this.txtEndCardMusic.TabIndex = 17;
		this.txtEndCardMusic.UseSelectable = true;
		this.txtEndCardMusic.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtEndCardMusic.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtEndCardMusic.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtEndCardMusic_ButtonClick);
		this.txtEndCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtEndCard.CustomButton.Image = null;
		this.txtEndCard.CustomButton.Location = new System.Drawing.Point(256, 1);
		this.txtEndCard.CustomButton.Name = "";
		this.txtEndCard.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtEndCard.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtEndCard.CustomButton.TabIndex = 1;
		this.txtEndCard.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtEndCard.CustomButton.UseSelectable = true;
		this.txtEndCard.Enabled = false;
		this.txtEndCard.Lines = new string[0];
		this.txtEndCard.Location = new System.Drawing.Point(8, 29);
		this.txtEndCard.MaxLength = 32767;
		this.txtEndCard.Name = "txtEndCard";
		this.txtEndCard.PasswordChar = '\0';
		this.txtEndCard.ReadOnly = true;
		this.txtEndCard.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtEndCard.SelectedText = "";
		this.txtEndCard.SelectionLength = 0;
		this.txtEndCard.SelectionStart = 0;
		this.txtEndCard.ShortcutsEnabled = true;
		this.txtEndCard.ShowButton = true;
		this.txtEndCard.ShowClearButton = true;
		this.txtEndCard.Size = new System.Drawing.Size(278, 23);
		this.txtEndCard.TabIndex = 13;
		this.txtEndCard.UseSelectable = true;
		this.txtEndCard.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtEndCard.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtEndCard.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtEndCard_ButtonClick);
		this.grpClipDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpClipDetails.BackColor = System.Drawing.Color.Transparent;
		this.grpClipDetails.Controls.Add(this.togClipDetails);
		this.grpClipDetails.Controls.Add(this.lblClipDeailsName);
		this.grpClipDetails.Controls.Add(this.lblClipDetails);
		this.grpClipDetails.Controls.Add(this.txtClipDeailsAuthor);
		this.grpClipDetails.Controls.Add(this.lblClipDeailsAuthor);
		this.grpClipDetails.Controls.Add(this.txtClipDeailsName);
		this.grpClipDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpClipDetails.Location = new System.Drawing.Point(13, 333);
		this.grpClipDetails.Name = "grpClipDetails";
		this.grpClipDetails.Size = new System.Drawing.Size(592, 92);
		this.grpClipDetails.TabIndex = 37;
		this.grpClipDetails.TabStop = false;
		this.togClipDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togClipDetails.AutoSize = true;
		this.togClipDetails.DisplayStatus = false;
		this.togClipDetails.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togClipDetails.Location = new System.Drawing.Point(533, 0);
		this.togClipDetails.Name = "togClipDetails";
		this.togClipDetails.Size = new System.Drawing.Size(50, 17);
		this.togClipDetails.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togClipDetails.TabIndex = 50;
		this.togClipDetails.Text = "Off";
		this.togClipDetails.UseSelectable = true;
		this.togClipDetails.CheckedChanged += new System.EventHandler(this.togClipDetails_CheckedChanged);
		this.lblClipDeailsName.AutoSize = true;
		this.lblClipDeailsName.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblClipDeailsName.Location = new System.Drawing.Point(21, 31);
		this.lblClipDeailsName.Name = "lblClipDeailsName";
		this.lblClipDeailsName.Size = new System.Drawing.Size(61, 15);
		this.lblClipDeailsName.TabIndex = 39;
		this.lblClipDeailsName.Text = "Title Name";
		this.lblClipDetails.AutoSize = true;
		this.lblClipDetails.Location = new System.Drawing.Point(5, -3);
		this.lblClipDetails.Name = "lblClipDetails";
		this.lblClipDetails.Size = new System.Drawing.Size(238, 19);
		this.lblClipDetails.TabIndex = 22;
		this.lblClipDetails.Text = "Clip Detail (Empty field will be ignored)";
		this.txtClipDeailsAuthor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtClipDeailsAuthor.CustomButton.Image = null;
		this.txtClipDeailsAuthor.CustomButton.Location = new System.Drawing.Point(474, 1);
		this.txtClipDeailsAuthor.CustomButton.Name = "";
		this.txtClipDeailsAuthor.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtClipDeailsAuthor.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtClipDeailsAuthor.CustomButton.TabIndex = 1;
		this.txtClipDeailsAuthor.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtClipDeailsAuthor.CustomButton.UseSelectable = true;
		this.txtClipDeailsAuthor.CustomButton.Visible = false;
		this.txtClipDeailsAuthor.Enabled = false;
		this.txtClipDeailsAuthor.Lines = new string[0];
		this.txtClipDeailsAuthor.Location = new System.Drawing.Point(88, 56);
		this.txtClipDeailsAuthor.MaxLength = 32767;
		this.txtClipDeailsAuthor.Name = "txtClipDeailsAuthor";
		this.txtClipDeailsAuthor.PasswordChar = '\0';
		this.txtClipDeailsAuthor.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtClipDeailsAuthor.SelectedText = "";
		this.txtClipDeailsAuthor.SelectionLength = 0;
		this.txtClipDeailsAuthor.SelectionStart = 0;
		this.txtClipDeailsAuthor.ShortcutsEnabled = true;
		this.txtClipDeailsAuthor.ShowClearButton = true;
		this.txtClipDeailsAuthor.Size = new System.Drawing.Size(496, 23);
		this.txtClipDeailsAuthor.TabIndex = 13;
		this.txtClipDeailsAuthor.UseSelectable = true;
		this.txtClipDeailsAuthor.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtClipDeailsAuthor.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.lblClipDeailsAuthor.AutoSize = true;
		this.lblClipDeailsAuthor.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblClipDeailsAuthor.Location = new System.Drawing.Point(6, 60);
		this.lblClipDeailsAuthor.Name = "lblClipDeailsAuthor";
		this.lblClipDeailsAuthor.Size = new System.Drawing.Size(76, 15);
		this.lblClipDeailsAuthor.TabIndex = 29;
		this.lblClipDeailsAuthor.Text = "Author Name";
		this.txtClipDeailsName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtClipDeailsName.CustomButton.Image = null;
		this.txtClipDeailsName.CustomButton.Location = new System.Drawing.Point(474, 1);
		this.txtClipDeailsName.CustomButton.Name = "";
		this.txtClipDeailsName.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtClipDeailsName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtClipDeailsName.CustomButton.TabIndex = 1;
		this.txtClipDeailsName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtClipDeailsName.CustomButton.UseSelectable = true;
		this.txtClipDeailsName.CustomButton.Visible = false;
		this.txtClipDeailsName.Enabled = false;
		this.txtClipDeailsName.Lines = new string[0];
		this.txtClipDeailsName.Location = new System.Drawing.Point(88, 27);
		this.txtClipDeailsName.MaxLength = 32767;
		this.txtClipDeailsName.Name = "txtClipDeailsName";
		this.txtClipDeailsName.PasswordChar = '\0';
		this.txtClipDeailsName.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtClipDeailsName.SelectedText = "";
		this.txtClipDeailsName.SelectionLength = 0;
		this.txtClipDeailsName.SelectionStart = 0;
		this.txtClipDeailsName.ShortcutsEnabled = true;
		this.txtClipDeailsName.ShowClearButton = true;
		this.txtClipDeailsName.Size = new System.Drawing.Size(496, 23);
		this.txtClipDeailsName.TabIndex = 36;
		this.txtClipDeailsName.UseSelectable = true;
		this.txtClipDeailsName.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtClipDeailsName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.grpKaraoke.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpKaraoke.BackColor = System.Drawing.Color.Transparent;
		this.grpKaraoke.Controls.Add(this.togKaraoke);
		this.grpKaraoke.Controls.Add(this.lblKaraoke);
		this.grpKaraoke.Controls.Add(this.txtKaraokeED);
		this.grpKaraoke.Controls.Add(this.txtKaraokeOP);
		this.grpKaraoke.Controls.Add(this.chkKaraokeOP);
		this.grpKaraoke.Controls.Add(this.chkKaraokeED);
		this.grpKaraoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpKaraoke.Location = new System.Drawing.Point(13, 232);
		this.grpKaraoke.Name = "grpKaraoke";
		this.grpKaraoke.Size = new System.Drawing.Size(592, 95);
		this.grpKaraoke.TabIndex = 33;
		this.grpKaraoke.TabStop = false;
		this.togKaraoke.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togKaraoke.AutoSize = true;
		this.togKaraoke.DisplayStatus = false;
		this.togKaraoke.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togKaraoke.Location = new System.Drawing.Point(533, 0);
		this.togKaraoke.Name = "togKaraoke";
		this.togKaraoke.Size = new System.Drawing.Size(50, 17);
		this.togKaraoke.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togKaraoke.TabIndex = 69;
		this.togKaraoke.Text = "Off";
		this.togKaraoke.UseSelectable = true;
		this.togKaraoke.CheckedChanged += new System.EventHandler(this.togKaraoke_CheckedChanged);
		this.lblKaraoke.AutoSize = true;
		this.lblKaraoke.Location = new System.Drawing.Point(6, -3);
		this.lblKaraoke.Name = "lblKaraoke";
		this.lblKaraoke.Size = new System.Drawing.Size(56, 19);
		this.lblKaraoke.TabIndex = 22;
		this.lblKaraoke.Text = "Karaoke";
		this.txtKaraokeED.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtKaraokeED.CustomButton.Image = null;
		this.txtKaraokeED.CustomButton.Location = new System.Drawing.Point(466, 1);
		this.txtKaraokeED.CustomButton.Name = "";
		this.txtKaraokeED.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtKaraokeED.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtKaraokeED.CustomButton.TabIndex = 1;
		this.txtKaraokeED.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtKaraokeED.CustomButton.UseSelectable = true;
		this.txtKaraokeED.Enabled = false;
		this.txtKaraokeED.Lines = new string[0];
		this.txtKaraokeED.Location = new System.Drawing.Point(96, 62);
		this.txtKaraokeED.MaxLength = 32767;
		this.txtKaraokeED.Name = "txtKaraokeED";
		this.txtKaraokeED.PasswordChar = '\0';
		this.txtKaraokeED.ReadOnly = true;
		this.txtKaraokeED.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtKaraokeED.SelectedText = "";
		this.txtKaraokeED.SelectionLength = 0;
		this.txtKaraokeED.SelectionStart = 0;
		this.txtKaraokeED.ShortcutsEnabled = true;
		this.txtKaraokeED.ShowButton = true;
		this.txtKaraokeED.ShowClearButton = true;
		this.txtKaraokeED.Size = new System.Drawing.Size(488, 23);
		this.txtKaraokeED.TabIndex = 17;
		this.txtKaraokeED.UseSelectable = true;
		this.txtKaraokeED.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtKaraokeED.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtKaraokeED.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtKaraokeED_ButtonClick);
		this.txtKaraokeOP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtKaraokeOP.CustomButton.Image = null;
		this.txtKaraokeOP.CustomButton.Location = new System.Drawing.Point(466, 1);
		this.txtKaraokeOP.CustomButton.Name = "";
		this.txtKaraokeOP.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtKaraokeOP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtKaraokeOP.CustomButton.TabIndex = 1;
		this.txtKaraokeOP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtKaraokeOP.CustomButton.UseSelectable = true;
		this.txtKaraokeOP.Enabled = false;
		this.txtKaraokeOP.Lines = new string[0];
		this.txtKaraokeOP.Location = new System.Drawing.Point(96, 33);
		this.txtKaraokeOP.MaxLength = 32767;
		this.txtKaraokeOP.Name = "txtKaraokeOP";
		this.txtKaraokeOP.PasswordChar = '\0';
		this.txtKaraokeOP.ReadOnly = true;
		this.txtKaraokeOP.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtKaraokeOP.SelectedText = "";
		this.txtKaraokeOP.SelectionLength = 0;
		this.txtKaraokeOP.SelectionStart = 0;
		this.txtKaraokeOP.ShortcutsEnabled = true;
		this.txtKaraokeOP.ShowButton = true;
		this.txtKaraokeOP.ShowClearButton = true;
		this.txtKaraokeOP.Size = new System.Drawing.Size(488, 23);
		this.txtKaraokeOP.TabIndex = 13;
		this.txtKaraokeOP.UseSelectable = true;
		this.txtKaraokeOP.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtKaraokeOP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtKaraokeOP.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtKaraokeOP_ButtonClick);
		this.chkKaraokeOP.AutoSize = true;
		this.chkKaraokeOP.Enabled = false;
		this.chkKaraokeOP.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
		this.chkKaraokeOP.Location = new System.Drawing.Point(10, 37);
		this.chkKaraokeOP.Name = "chkKaraokeOP";
		this.chkKaraokeOP.Size = new System.Drawing.Size(82, 15);
		this.chkKaraokeOP.TabIndex = 72;
		this.chkKaraokeOP.Text = "OP Karaoke";
		this.chkKaraokeOP.UseSelectable = true;
		this.chkKaraokeED.AutoSize = true;
		this.chkKaraokeED.Enabled = false;
		this.chkKaraokeED.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
		this.chkKaraokeED.Location = new System.Drawing.Point(10, 66);
		this.chkKaraokeED.Name = "chkKaraokeED";
		this.chkKaraokeED.Size = new System.Drawing.Size(80, 15);
		this.chkKaraokeED.TabIndex = 73;
		this.chkKaraokeED.Text = "ED Karaoke";
		this.chkKaraokeED.UseSelectable = true;
		this.grpSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.grpSubtitle.BackColor = System.Drawing.Color.Transparent;
		this.grpSubtitle.Controls.Add(this.togSubtitle);
		this.grpSubtitle.Controls.Add(this.lblSubtitle);
		this.grpSubtitle.Controls.Add(this.lblSubtitleFile);
		this.grpSubtitle.Controls.Add(this.txtSubtitle);
		this.grpSubtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.grpSubtitle.Location = new System.Drawing.Point(13, 14);
		this.grpSubtitle.Name = "grpSubtitle";
		this.grpSubtitle.Size = new System.Drawing.Size(592, 65);
		this.grpSubtitle.TabIndex = 36;
		this.grpSubtitle.TabStop = false;
		this.togSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togSubtitle.AutoSize = true;
		this.togSubtitle.DisplayStatus = false;
		this.togSubtitle.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togSubtitle.Location = new System.Drawing.Point(533, 0);
		this.togSubtitle.Name = "togSubtitle";
		this.togSubtitle.Size = new System.Drawing.Size(50, 17);
		this.togSubtitle.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togSubtitle.TabIndex = 67;
		this.togSubtitle.Text = "Off";
		this.togSubtitle.UseSelectable = true;
		this.togSubtitle.CheckedChanged += new System.EventHandler(this.togSubtitle_CheckedChanged);
		this.lblSubtitle.AutoSize = true;
		this.lblSubtitle.Location = new System.Drawing.Point(6, -3);
		this.lblSubtitle.Name = "lblSubtitle";
		this.lblSubtitle.Size = new System.Drawing.Size(52, 19);
		this.lblSubtitle.TabIndex = 22;
		this.lblSubtitle.Text = "Subtitle";
		this.lblSubtitleFile.AutoSize = true;
		this.lblSubtitleFile.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblSubtitleFile.Location = new System.Drawing.Point(5, 35);
		this.lblSubtitleFile.Name = "lblSubtitleFile";
		this.lblSubtitleFile.Size = new System.Drawing.Size(44, 15);
		this.lblSubtitleFile.TabIndex = 29;
		this.lblSubtitleFile.Text = "Subtitle";
		this.txtSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtSubtitle.CustomButton.Image = null;
		this.txtSubtitle.CustomButton.Location = new System.Drawing.Point(506, 1);
		this.txtSubtitle.CustomButton.Name = "";
		this.txtSubtitle.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtSubtitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtSubtitle.CustomButton.TabIndex = 1;
		this.txtSubtitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtSubtitle.CustomButton.UseSelectable = true;
		this.txtSubtitle.Enabled = false;
		this.txtSubtitle.Lines = new string[0];
		this.txtSubtitle.Location = new System.Drawing.Point(55, 31);
		this.txtSubtitle.MaxLength = 32767;
		this.txtSubtitle.Name = "txtSubtitle";
		this.txtSubtitle.PasswordChar = '\0';
		this.txtSubtitle.ReadOnly = true;
		this.txtSubtitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtSubtitle.SelectedText = "";
		this.txtSubtitle.SelectionLength = 0;
		this.txtSubtitle.SelectionStart = 0;
		this.txtSubtitle.ShortcutsEnabled = true;
		this.txtSubtitle.ShowButton = true;
		this.txtSubtitle.ShowClearButton = true;
		this.txtSubtitle.Size = new System.Drawing.Size(528, 23);
		this.txtSubtitle.TabIndex = 13;
		this.txtSubtitle.UseSelectable = true;
		this.txtSubtitle.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtSubtitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtSubtitle.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtSubtitle_ButtonClick);
		this.tcQueue.Controls.Add(this.tpMain);
		this.tcQueue.Controls.Add(this.tpVideo);
		this.tcQueue.Controls.Add(this.tpAudio);
		this.tcQueue.Controls.Add(this.tpTransition);
		this.tcQueue.Controls.Add(this.tpLogo);
		this.tcQueue.Controls.Add(this.tpSpecial);
		this.tcQueue.Controls.Add(this.tpLog);
		this.tcQueue.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tcQueue.ItemSize = new System.Drawing.Size(30, 30);
		this.tcQueue.Location = new System.Drawing.Point(3, 3);
		this.tcQueue.Name = "tcQueue";
		this.tcQueue.SelectedIndex = 0;
		this.tcQueue.Size = new System.Drawing.Size(640, 410);
		this.tcQueue.Style = MetroFramework.MetroColorStyle.Silver;
		this.tcQueue.TabIndex = 0;
		this.tcQueue.UseSelectable = true;
		this.togOntop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togOntop.AutoSize = true;
		this.togOntop.DisplayStatus = false;
		this.togOntop.FontWeight = MetroFramework.MetroLinkWeight.Light;
		this.togOntop.Location = new System.Drawing.Point(1206, 39);
		this.togOntop.Name = "togOntop";
		this.togOntop.Size = new System.Drawing.Size(50, 17);
		this.togOntop.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togOntop.TabIndex = 25;
		this.togOntop.Text = "Off";
		this.togOntop.UseSelectable = true;
		this.togOntop.CheckedChanged += new System.EventHandler(this.togOntop_CheckedChanged);
		this.cmsControlQueue_2.DropShadowEnabled = false;
		this.cmsControlQueue_2.Items.AddRange(new System.Windows.Forms.ToolStripItem[7] { this.tsmiAddFiles, this.tsmiAddFolder, this.toolStripMenuItem5, this.tsmiNewProject, this.tsmiOpenProject, this.tsmiSaveProject, this.tsmiSaveasProject });
		this.cmsControlQueue_2.Name = "cmsControlQueue";
		this.cmsControlQueue_2.Size = new System.Drawing.Size(153, 142);
		this.tsmiAddFiles.Image = (System.Drawing.Image)resources.GetObject("tsmiAddFiles.Image");
		this.tsmiAddFiles.Name = "tsmiAddFiles";
		this.tsmiAddFiles.ShortcutKeyDisplayString = "";
		this.tsmiAddFiles.Size = new System.Drawing.Size(152, 22);
		this.tsmiAddFiles.Text = "Add Files";
		this.tsmiAddFiles.Click += new System.EventHandler(this.tsmiAddFiles_Click);
		this.tsmiAddFolder.Image = (System.Drawing.Image)resources.GetObject("tsmiAddFolder.Image");
		this.tsmiAddFolder.Name = "tsmiAddFolder";
		this.tsmiAddFolder.ShortcutKeyDisplayString = "";
		this.tsmiAddFolder.Size = new System.Drawing.Size(152, 22);
		this.tsmiAddFolder.Text = "Add Folder";
		this.tsmiAddFolder.Click += new System.EventHandler(this.tsmiAddFolder_Click);
		this.toolStripMenuItem5.Name = "toolStripMenuItem5";
		this.toolStripMenuItem5.Size = new System.Drawing.Size(149, 6);
		this.tsmiNewProject.Image = (System.Drawing.Image)resources.GetObject("tsmiNewProject.Image");
		this.tsmiNewProject.Name = "tsmiNewProject";
		this.tsmiNewProject.ShortcutKeyDisplayString = "";
		this.tsmiNewProject.Size = new System.Drawing.Size(152, 22);
		this.tsmiNewProject.Text = "New Project";
		this.tsmiNewProject.Click += new System.EventHandler(this.tsmiNewProject_Click);
		this.tsmiOpenProject.Image = (System.Drawing.Image)resources.GetObject("tsmiOpenProject.Image");
		this.tsmiOpenProject.Name = "tsmiOpenProject";
		this.tsmiOpenProject.ShortcutKeyDisplayString = "";
		this.tsmiOpenProject.Size = new System.Drawing.Size(152, 22);
		this.tsmiOpenProject.Text = "Open Project";
		this.tsmiOpenProject.Click += new System.EventHandler(this.tsmiOpenProject_Click);
		this.tsmiSaveProject.Image = (System.Drawing.Image)resources.GetObject("tsmiSaveProject.Image");
		this.tsmiSaveProject.Name = "tsmiSaveProject";
		this.tsmiSaveProject.ShortcutKeyDisplayString = "";
		this.tsmiSaveProject.Size = new System.Drawing.Size(152, 22);
		this.tsmiSaveProject.Text = "Save Project";
		this.tsmiSaveProject.Click += new System.EventHandler(this.tsmiSaveProject_Click);
		this.tsmiSaveasProject.Name = "tsmiSaveasProject";
		this.tsmiSaveasProject.ShortcutKeyDisplayString = "";
		this.tsmiSaveasProject.Size = new System.Drawing.Size(152, 22);
		this.tsmiSaveasProject.Text = "Save as Project";
		this.tsmiSaveasProject.Click += new System.EventHandler(this.tsmiSaveasProject_Click);
		this.cmsControlQueue_4.DropShadowEnabled = false;
		this.cmsControlQueue_4.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.tsmiTUT, this.tsmiChangelog, this.tsmiTroubleshooting, this.toolStripMenuItem4, this.tsmiAbout });
		this.cmsControlQueue_4.Name = "cmsControlQueue";
		this.cmsControlQueue_4.Size = new System.Drawing.Size(185, 98);
		this.tsmiTUT.Image = (System.Drawing.Image)resources.GetObject("tsmiTUT.Image");
		this.tsmiTUT.Name = "tsmiTUT";
		this.tsmiTUT.Size = new System.Drawing.Size(184, 22);
		this.tsmiTUT.Text = "How to Use";
		this.tsmiTUT.Click += new System.EventHandler(this.tsmiTUT_Click);
		this.tsmiChangelog.Image = (System.Drawing.Image)resources.GetObject("tsmiChangelog.Image");
		this.tsmiChangelog.Name = "tsmiChangelog";
		this.tsmiChangelog.Size = new System.Drawing.Size(184, 22);
		this.tsmiChangelog.Text = "What's New";
		this.tsmiChangelog.Click += new System.EventHandler(this.tsmiChangelog_Click);
		this.tsmiTroubleshooting.Image = (System.Drawing.Image)resources.GetObject("tsmiTroubleshooting.Image");
		this.tsmiTroubleshooting.Name = "tsmiTroubleshooting";
		this.tsmiTroubleshooting.Size = new System.Drawing.Size(184, 22);
		this.tsmiTroubleshooting.Text = "Troubleshooting";
		this.tsmiTroubleshooting.Click += new System.EventHandler(this.tsmiTroubleshooting_Click);
		this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 6);
		this.tsmiAbout.Image = (System.Drawing.Image)resources.GetObject("tsmiAbout.Image");
		this.tsmiAbout.Name = "tsmiAbout";
		this.tsmiAbout.Size = new System.Drawing.Size(184, 22);
		this.tsmiAbout.Text = "About Konayuki Plus";
		this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
		this.psProgress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.psProgress.Enabled = false;
		this.psProgress.Location = new System.Drawing.Point(932, 72);
		this.psProgress.Maximum = 100;
		this.psProgress.Name = "psProgress";
		this.psProgress.Size = new System.Drawing.Size(24, 24);
		this.psProgress.Style = MetroFramework.MetroColorStyle.Silver;
		this.psProgress.TabIndex = 34;
		this.psProgress.UseSelectable = true;
		this.psProgress.Value = 100;
		this.psProgress.Visible = false;
		this.lblOntop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.lblOntop.AutoSize = true;
		this.lblOntop.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblOntop.Location = new System.Drawing.Point(1133, 40);
		this.lblOntop.Name = "lblOntop";
		this.lblOntop.Size = new System.Drawing.Size(69, 15);
		this.lblOntop.TabIndex = 26;
		this.lblOntop.Text = "Top Window";
		this.cmsControlQueue_5.DropShadowEnabled = false;
		this.cmsControlQueue_5.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.tsmiEmptyFile, this.tsmiDeleteFile });
		this.cmsControlQueue_5.Name = "cmsControlQueue";
		this.cmsControlQueue_5.Size = new System.Drawing.Size(210, 48);
		this.tsmiEmptyFile.Image = (System.Drawing.Image)resources.GetObject("tsmiEmptyFile.Image");
		this.tsmiEmptyFile.Name = "tsmiEmptyFile";
		this.tsmiEmptyFile.Size = new System.Drawing.Size(209, 22);
		this.tsmiEmptyFile.Text = "Empty Queue";
		this.tsmiEmptyFile.Click += new System.EventHandler(this.tsmiEmptyFile_Click);
		this.tsmiDeleteFile.Image = (System.Drawing.Image)resources.GetObject("tsmiDeleteFile.Image");
		this.tsmiDeleteFile.Name = "tsmiDeleteFile";
		this.tsmiDeleteFile.Size = new System.Drawing.Size(209, 22);
		this.tsmiDeleteFile.Text = "Delete Queue (0 Selected)";
		this.tsmiDeleteFile.Click += new System.EventHandler(this.tsmiDeleteFile_Click);
		this.cmsControlQueue_6.DropShadowEnabled = false;
		this.cmsControlQueue_6.Items.AddRange(new System.Windows.Forms.ToolStripItem[10] { this.tsmiOpenKonayuki, this.toolStripMenuItem1, this.tsmiTraySettings, this.tsmiTrayLanguage, this.toolStripMenuItem2, this.tsmiTrayApiVersion, this.toolStripMenuItem3, this.tsmiTrayAbout, this.toolStripMenuItem7, this.tsmiExit });
		this.cmsControlQueue_6.Name = "cmsControlQueue";
		this.cmsControlQueue_6.Size = new System.Drawing.Size(185, 160);
		this.tsmiOpenKonayuki.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.tsmiOpenKonayuki.Image = (System.Drawing.Image)resources.GetObject("tsmiOpenKonayuki.Image");
		this.tsmiOpenKonayuki.Name = "tsmiOpenKonayuki";
		this.tsmiOpenKonayuki.Size = new System.Drawing.Size(184, 22);
		this.tsmiOpenKonayuki.Text = "KONAYUKI PLUS";
		this.tsmiOpenKonayuki.Click += new System.EventHandler(this.tsmiOpenKonayuki_Click);
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
		this.tsmiTraySettings.Image = (System.Drawing.Image)resources.GetObject("tsmiTraySettings.Image");
		this.tsmiTraySettings.Name = "tsmiTraySettings";
		this.tsmiTraySettings.Size = new System.Drawing.Size(184, 22);
		this.tsmiTraySettings.Text = "Settings";
		this.tsmiTraySettings.Click += new System.EventHandler(this.tsmiTraySettings_Click);
		this.tsmiTrayLanguage.Image = (System.Drawing.Image)resources.GetObject("tsmiTrayLanguage.Image");
		this.tsmiTrayLanguage.Name = "tsmiTrayLanguage";
		this.tsmiTrayLanguage.Size = new System.Drawing.Size(184, 22);
		this.tsmiTrayLanguage.Text = "Tooltip Language";
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.Size = new System.Drawing.Size(181, 6);
		this.tsmiTrayApiVersion.Enabled = false;
		this.tsmiTrayApiVersion.Name = "tsmiTrayApiVersion";
		this.tsmiTrayApiVersion.Size = new System.Drawing.Size(184, 22);
		this.tsmiTrayApiVersion.Text = "API Version";
		this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 6);
		this.tsmiTrayAbout.Image = (System.Drawing.Image)resources.GetObject("tsmiTrayAbout.Image");
		this.tsmiTrayAbout.Name = "tsmiTrayAbout";
		this.tsmiTrayAbout.Size = new System.Drawing.Size(184, 22);
		this.tsmiTrayAbout.Text = "About Konayuki Plus";
		this.tsmiTrayAbout.Click += new System.EventHandler(this.tsmiTrayAbout_Click);
		this.toolStripMenuItem7.Name = "toolStripMenuItem7";
		this.toolStripMenuItem7.Size = new System.Drawing.Size(181, 6);
		this.tsmiExit.Image = (System.Drawing.Image)resources.GetObject("tsmiExit.Image");
		this.tsmiExit.Name = "tsmiExit";
		this.tsmiExit.Size = new System.Drawing.Size(184, 22);
		this.tsmiExit.Text = "Exit";
		this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
		this.cmsControlQueue_7.DropShadowEnabled = false;
		this.cmsControlQueue_7.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.tsmiSettings, this.tsmiRepair, this.tsmiLanguage });
		this.cmsControlQueue_7.Name = "cmsControlQueue";
		this.cmsControlQueue_7.Size = new System.Drawing.Size(167, 70);
		this.tsmiSettings.Image = (System.Drawing.Image)resources.GetObject("tsmiSettings.Image");
		this.tsmiSettings.Name = "tsmiSettings";
		this.tsmiSettings.Size = new System.Drawing.Size(166, 22);
		this.tsmiSettings.Text = "Settings";
		this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
		this.tsmiRepair.Image = (System.Drawing.Image)resources.GetObject("tsmiRepair.Image");
		this.tsmiRepair.Name = "tsmiRepair";
		this.tsmiRepair.Size = new System.Drawing.Size(166, 22);
		this.tsmiRepair.Text = "Repair Program";
		this.tsmiRepair.Click += new System.EventHandler(this.tsmiRepair_Click);
		this.tsmiLanguage.Image = (System.Drawing.Image)resources.GetObject("tsmiLanguage.Image");
		this.tsmiLanguage.Name = "tsmiLanguage";
		this.tsmiLanguage.Size = new System.Drawing.Size(166, 22);
		this.tsmiLanguage.Text = "Tooltip Language";
		this.cmsControlQueue_8.DropShadowEnabled = false;
		this.cmsControlQueue_8.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.tsmiDisable, this.tsmiCompare1, this.tsmiCompare2, this.tsmiCompare3 });
		this.cmsControlQueue_8.Name = "cmsControlQueue";
		this.cmsControlQueue_8.Size = new System.Drawing.Size(167, 92);
		this.tsmiDisable.Checked = true;
		this.tsmiDisable.CheckState = System.Windows.Forms.CheckState.Checked;
		this.tsmiDisable.Name = "tsmiDisable";
		this.tsmiDisable.Size = new System.Drawing.Size(166, 22);
		this.tsmiDisable.Text = "Disable";
		this.tsmiDisable.Click += new System.EventHandler(this.tsmiDisable_Click);
		this.tsmiCompare1.AutoSize = false;
		this.tsmiCompare1.Name = "tsmiCompare1";
		this.tsmiCompare1.Size = new System.Drawing.Size(155, 22);
		this.tsmiCompare1.Text = "Compare Mode 1";
		this.tsmiCompare1.Click += new System.EventHandler(this.tsmiCompare1_Click);
		this.tsmiCompare2.Name = "tsmiCompare2";
		this.tsmiCompare2.Size = new System.Drawing.Size(166, 22);
		this.tsmiCompare2.Text = "Compare Mode 2";
		this.tsmiCompare2.Click += new System.EventHandler(this.tsmiCompare2_Click);
		this.tsmiCompare3.Name = "tsmiCompare3";
		this.tsmiCompare3.Size = new System.Drawing.Size(166, 22);
		this.tsmiCompare3.Text = "Compare Mode 3";
		this.tsmiCompare3.Click += new System.EventHandler(this.tsmiCompare3_Click);
		this.cmsControlQueue_9.DropShadowEnabled = false;
		this.cmsControlQueue_9.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.tsmiCompareMPC1, this.tsmiCompareMPC2, this.tsmiCompareMPC3, this.tsmiCompareMPC4 });
		this.cmsControlQueue_9.Name = "cmsControlQueue";
		this.cmsControlQueue_9.ShowImageMargin = false;
		this.cmsControlQueue_9.Size = new System.Drawing.Size(142, 92);
		this.tsmiCompareMPC1.Name = "tsmiCompareMPC1";
		this.tsmiCompareMPC1.Size = new System.Drawing.Size(141, 22);
		this.tsmiCompareMPC1.Text = "Compare Mode 1";
		this.tsmiCompareMPC1.Click += new System.EventHandler(this.tsmiCompareMPC1_Click);
		this.tsmiCompareMPC2.Name = "tsmiCompareMPC2";
		this.tsmiCompareMPC2.Size = new System.Drawing.Size(141, 22);
		this.tsmiCompareMPC2.Text = "Compare Mode 2";
		this.tsmiCompareMPC2.Click += new System.EventHandler(this.tsmiCompareMPC2_Click);
		this.tsmiCompareMPC3.Name = "tsmiCompareMPC3";
		this.tsmiCompareMPC3.Size = new System.Drawing.Size(141, 22);
		this.tsmiCompareMPC3.Text = "Compare Mode 3";
		this.tsmiCompareMPC3.Click += new System.EventHandler(this.tsmiCompareMPC3_Click);
		this.tsmiCompareMPC4.Name = "tsmiCompareMPC4";
		this.tsmiCompareMPC4.Size = new System.Drawing.Size(141, 22);
		this.tsmiCompareMPC4.Text = "Compare Mode 4";
		this.tsmiCompareMPC4.Click += new System.EventHandler(this.tsmiCompareMPC4_Click);
		this.splitMain.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.splitMain.BackColor = System.Drawing.Color.White;
		this.splitMain.ColumnCount = 2;
		this.splitMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 646f));
		this.splitMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.splitMain.Controls.Add(this.tcPlayer, 1, 0);
		this.splitMain.Controls.Add(this.tcQueue, 0, 0);
		this.splitMain.Location = new System.Drawing.Point(17, 287);
		this.splitMain.Name = "splitMain";
		this.splitMain.RowCount = 1;
		this.splitMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
		this.splitMain.Size = new System.Drawing.Size(1246, 416);
		this.splitMain.TabIndex = 41;
		this.splitMain.Visible = false;
		this.splitMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitMain_MouseMove);
		this.tcPlayer.Controls.Add(this.tpPreview);
		this.tcPlayer.Controls.Add(this.tpMediaInfo);
		this.tcPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tcPlayer.ItemSize = new System.Drawing.Size(30, 30);
		this.tcPlayer.Location = new System.Drawing.Point(649, 3);
		this.tcPlayer.Name = "tcPlayer";
		this.tcPlayer.SelectedIndex = 0;
		this.tcPlayer.Size = new System.Drawing.Size(594, 410);
		this.tcPlayer.Style = MetroFramework.MetroColorStyle.Silver;
		this.tcPlayer.TabIndex = 1;
		this.tcPlayer.UseSelectable = true;
		this.tpPreview.BackColor = System.Drawing.Color.Black;
		this.tpPreview.Controls.Add(this.pnGoto);
		this.tpPreview.Controls.Add(this.pnControl);
		this.tpPreview.Controls.Add(this.videoBox);
		this.tpPreview.HorizontalScrollbarBarColor = false;
		this.tpPreview.HorizontalScrollbarHighlightOnWheel = false;
		this.tpPreview.HorizontalScrollbarSize = 0;
		this.tpPreview.Location = new System.Drawing.Point(4, 34);
		this.tpPreview.Margin = new System.Windows.Forms.Padding(0);
		this.tpPreview.Name = "tpPreview";
		this.tpPreview.Size = new System.Drawing.Size(586, 372);
		this.tpPreview.TabIndex = 0;
		this.tpPreview.Text = "Preview";
		this.tpPreview.VerticalScrollbarBarColor = false;
		this.tpPreview.VerticalScrollbarHighlightOnWheel = false;
		this.tpPreview.VerticalScrollbarSize = 0;
		this.pnGoto.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.pnGoto.AutoSize = true;
		this.pnGoto.BackColor = System.Drawing.Color.White;
		this.pnGoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnGoto.Controls.Add(this.lblGoToHelp);
		this.pnGoto.Controls.Add(this.btnGotoExit);
		this.pnGoto.Controls.Add(this.txtGoToFrame);
		this.pnGoto.Controls.Add(this.lblGoToFrame);
		this.pnGoto.Location = new System.Drawing.Point(201, 157);
		this.pnGoto.Name = "pnGoto";
		this.pnGoto.Size = new System.Drawing.Size(186, 60);
		this.pnGoto.TabIndex = 44;
		this.pnGoto.Visible = false;
		this.lblGoToHelp.AutoSize = true;
		this.lblGoToHelp.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblGoToHelp.Location = new System.Drawing.Point(19, 37);
		this.lblGoToHelp.Name = "lblGoToHelp";
		this.lblGoToHelp.Size = new System.Drawing.Size(147, 15);
		this.lblGoToHelp.TabIndex = 42;
		this.lblGoToHelp.Text = "PRESS ENTER TO CONFIRM";
		this.btnGotoExit.BackColor = System.Drawing.Color.White;
		this.btnGotoExit.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnGotoExit.BackgroundImage");
		this.btnGotoExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.btnGotoExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnGotoExit.ForeColor = System.Drawing.Color.Transparent;
		this.btnGotoExit.Location = new System.Drawing.Point(158, 8);
		this.btnGotoExit.Name = "btnGotoExit";
		this.btnGotoExit.Size = new System.Drawing.Size(21, 23);
		this.btnGotoExit.TabIndex = 41;
		this.btnGotoExit.UseVisualStyleBackColor = false;
		this.btnGotoExit.Click += new System.EventHandler(this.btnGotoExit_Click);
		this.txtGoToFrame.CustomButton.Image = null;
		this.txtGoToFrame.CustomButton.Location = new System.Drawing.Point(52, 1);
		this.txtGoToFrame.CustomButton.Name = "";
		this.txtGoToFrame.CustomButton.Size = new System.Drawing.Size(21, 21);
		this.txtGoToFrame.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
		this.txtGoToFrame.CustomButton.TabIndex = 1;
		this.txtGoToFrame.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
		this.txtGoToFrame.CustomButton.UseSelectable = true;
		this.txtGoToFrame.CustomButton.Visible = false;
		this.txtGoToFrame.Lines = new string[1] { "000000" };
		this.txtGoToFrame.Location = new System.Drawing.Point(80, 8);
		this.txtGoToFrame.MaxLength = 32767;
		this.txtGoToFrame.Name = "txtGoToFrame";
		this.txtGoToFrame.PasswordChar = '\0';
		this.txtGoToFrame.ScrollBars = System.Windows.Forms.ScrollBars.None;
		this.txtGoToFrame.SelectedText = "";
		this.txtGoToFrame.SelectionLength = 0;
		this.txtGoToFrame.SelectionStart = 0;
		this.txtGoToFrame.ShortcutsEnabled = true;
		this.txtGoToFrame.ShowClearButton = true;
		this.txtGoToFrame.Size = new System.Drawing.Size(74, 23);
		this.txtGoToFrame.TabIndex = 37;
		this.txtGoToFrame.Text = "000000";
		this.txtGoToFrame.UseSelectable = true;
		this.txtGoToFrame.WaterMarkColor = System.Drawing.Color.FromArgb(109, 109, 109);
		this.txtGoToFrame.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
		this.txtGoToFrame.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGoToFrame_KeyDown);
		this.lblGoToFrame.AutoSize = true;
		this.lblGoToFrame.FontSize = MetroFramework.MetroLabelSize.Small;
		this.lblGoToFrame.Location = new System.Drawing.Point(6, 11);
		this.lblGoToFrame.Name = "lblGoToFrame";
		this.lblGoToFrame.Size = new System.Drawing.Size(71, 15);
		this.lblGoToFrame.TabIndex = 40;
		this.lblGoToFrame.Text = "Go To Frame";
		this.pnControl.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.pnControl.BackColor = System.Drawing.Color.White;
		this.pnControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pnControl.Controls.Add(this.btnGoTo);
		this.pnControl.Controls.Add(this.tbVolume);
		this.pnControl.Controls.Add(this.btnMute);
		this.pnControl.Controls.Add(this.panel2);
		this.pnControl.Controls.Add(this.btnFullScreen);
		this.pnControl.Controls.Add(this.btnPause);
		this.pnControl.Controls.Add(this.btnPlay);
		this.pnControl.Controls.Add(this.tbSeek);
		this.pnControl.Controls.Add(this.btnStoped);
		this.pnControl.Controls.Add(this.panel1);
		this.pnControl.Controls.Add(this.btnNextFrame);
		this.pnControl.Controls.Add(this.btnDecreaseSpeed);
		this.pnControl.Controls.Add(this.btnPreviousFrame);
		this.pnControl.Controls.Add(this.btnIncreaseSpeed);
		this.pnControl.Controls.Add(this.btnComp);
		this.pnControl.Location = new System.Drawing.Point(0, 320);
		this.pnControl.Name = "pnControl";
		this.pnControl.Size = new System.Drawing.Size(586, 52);
		this.pnControl.TabIndex = 42;
		this.btnGoTo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnGoTo.BackColor = System.Drawing.Color.White;
		this.btnGoTo.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnGoTo.BackgroundImage");
		this.btnGoTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnGoTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnGoTo.ForeColor = System.Drawing.Color.Transparent;
		this.btnGoTo.ImageKey = "(none)";
		this.btnGoTo.Location = new System.Drawing.Point(271, 16);
		this.btnGoTo.Name = "btnGoTo";
		this.btnGoTo.Size = new System.Drawing.Size(32, 32);
		this.btnGoTo.TabIndex = 6;
		this.btnGoTo.UseVisualStyleBackColor = false;
		this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
		this.tbVolume.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.tbVolume.BackColor = System.Drawing.Color.White;
		this.tbVolume.Location = new System.Drawing.Point(478, 26);
		this.tbVolume.Minimum = 50;
		this.tbVolume.Name = "tbVolume";
		this.tbVolume.Size = new System.Drawing.Size(102, 12);
		this.tbVolume.TabIndex = 16;
		this.tbVolume.Value = 100;
		this.tbVolume.ValueChanged += new System.EventHandler(this.tbVolume_ValueChanged);
		this.btnMute.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnMute.BackColor = System.Drawing.Color.White;
		this.btnMute.BackgroundImage = KonayukiPlus.Properties.Resources.mute_on;
		this.btnMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnMute.ForeColor = System.Drawing.Color.Transparent;
		this.btnMute.ImageKey = "(none)";
		this.btnMute.Location = new System.Drawing.Point(441, 16);
		this.btnMute.Name = "btnMute";
		this.btnMute.Size = new System.Drawing.Size(32, 32);
		this.btnMute.TabIndex = 9;
		this.btnMute.Tag = "on";
		this.btnMute.UseVisualStyleBackColor = false;
		this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
		this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.panel2.BackColor = System.Drawing.Color.LightGray;
		this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.panel2.Location = new System.Drawing.Point(265, 19);
		this.panel2.Name = "panel2";
		this.panel2.Size = new System.Drawing.Size(2, 26);
		this.panel2.TabIndex = 17;
		this.btnFullScreen.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnFullScreen.BackColor = System.Drawing.Color.White;
		this.btnFullScreen.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFullScreen.BackgroundImage");
		this.btnFullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnFullScreen.ForeColor = System.Drawing.Color.Transparent;
		this.btnFullScreen.Location = new System.Drawing.Point(345, 16);
		this.btnFullScreen.Name = "btnFullScreen";
		this.btnFullScreen.Size = new System.Drawing.Size(32, 32);
		this.btnFullScreen.TabIndex = 8;
		this.btnFullScreen.Text = "c";
		this.btnFullScreen.UseVisualStyleBackColor = false;
		this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
		this.btnPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnPause.BackColor = System.Drawing.Color.White;
		this.btnPause.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnPause.BackgroundImage");
		this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPause.ForeColor = System.Drawing.Color.Transparent;
		this.btnPause.Location = new System.Drawing.Point(39, 16);
		this.btnPause.Name = "btnPause";
		this.btnPause.Size = new System.Drawing.Size(32, 32);
		this.btnPause.TabIndex = 16;
		this.btnPause.Tag = "Pause";
		this.btnPause.UseVisualStyleBackColor = false;
		this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
		this.btnPlay.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnPlay.BackColor = System.Drawing.Color.White;
		this.btnPlay.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnPlay.BackgroundImage");
		this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPlay.ForeColor = System.Drawing.Color.Transparent;
		this.btnPlay.Location = new System.Drawing.Point(2, 16);
		this.btnPlay.Name = "btnPlay";
		this.btnPlay.Size = new System.Drawing.Size(32, 32);
		this.btnPlay.TabIndex = 0;
		this.btnPlay.Tag = "Play";
		this.btnPlay.UseVisualStyleBackColor = false;
		this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
		this.tbSeek.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tbSeek.BackColor = System.Drawing.Color.White;
		this.tbSeek.LargeChange = 1;
		this.tbSeek.Location = new System.Drawing.Point(3, 3);
		this.tbSeek.MouseWheelBarPartitions = 1;
		this.tbSeek.Name = "tbSeek";
		this.tbSeek.Size = new System.Drawing.Size(578, 12);
		this.tbSeek.TabIndex = 15;
		this.tbSeek.Value = 0;
		this.tbSeek.ValueChanged += new System.EventHandler(this.tbSeek_ValueChanged);
		this.tbSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbSeek_MouseDown);
		this.tbSeek.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbSeek_MouseUp);
		this.btnStoped.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnStoped.BackColor = System.Drawing.Color.White;
		this.btnStoped.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnStoped.BackgroundImage");
		this.btnStoped.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnStoped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnStoped.ForeColor = System.Drawing.Color.Transparent;
		this.btnStoped.Location = new System.Drawing.Point(76, 16);
		this.btnStoped.Name = "btnStoped";
		this.btnStoped.Size = new System.Drawing.Size(32, 32);
		this.btnStoped.TabIndex = 1;
		this.btnStoped.UseVisualStyleBackColor = false;
		this.btnStoped.Click += new System.EventHandler(this.btnStoped_Click);
		this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.panel1.BackColor = System.Drawing.Color.LightGray;
		this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		this.panel1.Location = new System.Drawing.Point(112, 19);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(2, 26);
		this.panel1.TabIndex = 13;
		this.btnNextFrame.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnNextFrame.BackColor = System.Drawing.Color.White;
		this.btnNextFrame.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnNextFrame.BackgroundImage");
		this.btnNextFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnNextFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnNextFrame.ForeColor = System.Drawing.Color.Transparent;
		this.btnNextFrame.Location = new System.Drawing.Point(229, 16);
		this.btnNextFrame.Name = "btnNextFrame";
		this.btnNextFrame.Size = new System.Drawing.Size(32, 32);
		this.btnNextFrame.TabIndex = 5;
		this.btnNextFrame.UseVisualStyleBackColor = false;
		this.btnNextFrame.Click += new System.EventHandler(this.btnNextFrame_Click);
		this.btnDecreaseSpeed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnDecreaseSpeed.BackColor = System.Drawing.Color.White;
		this.btnDecreaseSpeed.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnDecreaseSpeed.BackgroundImage");
		this.btnDecreaseSpeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnDecreaseSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnDecreaseSpeed.ForeColor = System.Drawing.Color.Transparent;
		this.btnDecreaseSpeed.Location = new System.Drawing.Point(118, 16);
		this.btnDecreaseSpeed.Name = "btnDecreaseSpeed";
		this.btnDecreaseSpeed.Size = new System.Drawing.Size(32, 32);
		this.btnDecreaseSpeed.TabIndex = 2;
		this.btnDecreaseSpeed.UseVisualStyleBackColor = false;
		this.btnDecreaseSpeed.Click += new System.EventHandler(this.btnDecreaseSpeed_Click);
		this.btnPreviousFrame.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnPreviousFrame.BackColor = System.Drawing.Color.White;
		this.btnPreviousFrame.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnPreviousFrame.BackgroundImage");
		this.btnPreviousFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnPreviousFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnPreviousFrame.ForeColor = System.Drawing.Color.Transparent;
		this.btnPreviousFrame.Location = new System.Drawing.Point(192, 16);
		this.btnPreviousFrame.Name = "btnPreviousFrame";
		this.btnPreviousFrame.Size = new System.Drawing.Size(32, 32);
		this.btnPreviousFrame.TabIndex = 4;
		this.btnPreviousFrame.UseVisualStyleBackColor = false;
		this.btnPreviousFrame.Click += new System.EventHandler(this.btnPreviousFrame_Click);
		this.btnIncreaseSpeed.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnIncreaseSpeed.BackColor = System.Drawing.Color.White;
		this.btnIncreaseSpeed.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnIncreaseSpeed.BackgroundImage");
		this.btnIncreaseSpeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnIncreaseSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnIncreaseSpeed.ForeColor = System.Drawing.Color.Transparent;
		this.btnIncreaseSpeed.Location = new System.Drawing.Point(155, 16);
		this.btnIncreaseSpeed.Name = "btnIncreaseSpeed";
		this.btnIncreaseSpeed.Size = new System.Drawing.Size(32, 32);
		this.btnIncreaseSpeed.TabIndex = 3;
		this.btnIncreaseSpeed.UseVisualStyleBackColor = false;
		this.btnIncreaseSpeed.Click += new System.EventHandler(this.btnIncreaseSpeed_Click);
		this.btnComp.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.btnComp.BackColor = System.Drawing.Color.White;
		this.btnComp.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnComp.BackgroundImage");
		this.btnComp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnComp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnComp.ForeColor = System.Drawing.Color.Transparent;
		this.btnComp.Location = new System.Drawing.Point(308, 16);
		this.btnComp.Name = "btnComp";
		this.btnComp.Size = new System.Drawing.Size(32, 32);
		this.btnComp.TabIndex = 7;
		this.btnComp.UseVisualStyleBackColor = false;
		this.btnComp.Click += new System.EventHandler(this.btnComp_Click);
		this.videoBox.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
		this.videoBox.BackgroundImage = (System.Drawing.Image)resources.GetObject("videoBox.BackgroundImage");
		this.videoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.videoBox.Dock = System.Windows.Forms.DockStyle.Fill;
		this.videoBox.Image = KonayukiPlus.Properties.Resources.player_off;
		this.videoBox.Location = new System.Drawing.Point(0, 0);
		this.videoBox.Name = "videoBox";
		this.videoBox.Size = new System.Drawing.Size(586, 372);
		this.videoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		this.videoBox.TabIndex = 2;
		this.videoBox.TabStop = false;
		this.videoBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseClick);
		this.videoBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseDoubleClick);
		this.videoBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoBox_MouseMove);
		this.tpMediaInfo.Controls.Add(this.rtbInfo);
		this.tpMediaInfo.HorizontalScrollbarBarColor = false;
		this.tpMediaInfo.HorizontalScrollbarHighlightOnWheel = false;
		this.tpMediaInfo.HorizontalScrollbarSize = 0;
		this.tpMediaInfo.Location = new System.Drawing.Point(4, 34);
		this.tpMediaInfo.Name = "tpMediaInfo";
		this.tpMediaInfo.Size = new System.Drawing.Size(586, 372);
		this.tpMediaInfo.TabIndex = 1;
		this.tpMediaInfo.Text = "Detail";
		this.tpMediaInfo.VerticalScrollbarBarColor = false;
		this.tpMediaInfo.VerticalScrollbarHighlightOnWheel = false;
		this.tpMediaInfo.VerticalScrollbarSize = 0;
		this.rtbInfo.BackColor = System.Drawing.Color.White;
		this.rtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.rtbInfo.Dock = System.Windows.Forms.DockStyle.Fill;
		this.rtbInfo.Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.rtbInfo.ForeColor = System.Drawing.SystemColors.WindowText;
		this.rtbInfo.Location = new System.Drawing.Point(0, 0);
		this.rtbInfo.Name = "rtbInfo";
		this.rtbInfo.ReadOnly = true;
		this.rtbInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
		this.rtbInfo.Size = new System.Drawing.Size(586, 372);
		this.rtbInfo.TabIndex = 68;
		this.rtbInfo.Text = "";
		this.togPreview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.togPreview.AutoSize = true;
		this.togPreview.Location = new System.Drawing.Point(1177, 297);
		this.togPreview.Name = "togPreview";
		this.togPreview.Size = new System.Drawing.Size(80, 17);
		this.togPreview.Style = MetroFramework.MetroColorStyle.Magenta;
		this.togPreview.TabIndex = 45;
		this.togPreview.Text = "Off";
		this.togPreview.UseSelectable = true;
		this.togPreview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.togPreview_MouseUp);
		this.btnReset.BackColor = System.Drawing.Color.White;
		this.btnReset.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnReset.BackgroundImage");
		this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnReset.ForeColor = System.Drawing.Color.Transparent;
		this.btnReset.Location = new System.Drawing.Point(633, 292);
		this.btnReset.Name = "btnReset";
		this.btnReset.Size = new System.Drawing.Size(26, 26);
		this.btnReset.TabIndex = 48;
		this.btnReset.UseVisualStyleBackColor = false;
		this.btnReset.Visible = false;
		this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
		this.btnFonts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnFonts.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFonts.BackgroundImage");
		this.btnFonts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnFonts.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnFonts.Location = new System.Drawing.Point(890, 68);
		this.btnFonts.Name = "btnFonts";
		this.btnFonts.Size = new System.Drawing.Size(32, 32);
		this.btnFonts.TabIndex = 46;
		this.btnFonts.UseCustomBackColor = true;
		this.btnFonts.UseCustomForeColor = true;
		this.btnFonts.UseSelectable = true;
		this.btnFonts.UseStyleColors = true;
		this.btnFonts.Click += new System.EventHandler(this.btnFonts_Click);
		this.btnMPC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnMPC.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnMPC.BackgroundImage");
		this.btnMPC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnMPC.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnMPC.Location = new System.Drawing.Point(841, 68);
		this.btnMPC.Name = "btnMPC";
		this.btnMPC.Size = new System.Drawing.Size(32, 32);
		this.btnMPC.TabIndex = 39;
		this.btnMPC.UseCustomBackColor = true;
		this.btnMPC.UseCustomForeColor = true;
		this.btnMPC.UseSelectable = true;
		this.btnMPC.UseStyleColors = true;
		this.btnMPC.Visible = false;
		this.btnMPC.Click += new System.EventHandler(this.btnMPC_Click);
		this.btnCompareMPC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnCompareMPC.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnCompareMPC.BackgroundImage");
		this.btnCompareMPC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnCompareMPC.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnCompareMPC.Location = new System.Drawing.Point(872, 68);
		this.btnCompareMPC.Name = "btnCompareMPC";
		this.btnCompareMPC.Size = new System.Drawing.Size(12, 32);
		this.btnCompareMPC.TabIndex = 40;
		this.btnCompareMPC.UseCustomBackColor = true;
		this.btnCompareMPC.UseCustomForeColor = true;
		this.btnCompareMPC.UseSelectable = true;
		this.btnCompareMPC.UseStyleColors = true;
		this.btnCompareMPC.Visible = false;
		this.btnCompareMPC.Click += new System.EventHandler(this.btnCompareMPC_Click);
		this.picSaved.Image = (System.Drawing.Image)resources.GetObject("picSaved.Image");
		this.picSaved.Location = new System.Drawing.Point(178, 74);
		this.picSaved.Name = "picSaved";
		this.picSaved.Size = new System.Drawing.Size(20, 20);
		this.picSaved.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picSaved.TabIndex = 38;
		this.picSaved.TabStop = false;
		this.picSaved.Visible = false;
		this.btnPreview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnPreview.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnPreview.BackgroundImage");
		this.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnPreview.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnPreview.Location = new System.Drawing.Point(841, 68);
		this.btnPreview.Name = "btnPreview";
		this.btnPreview.Size = new System.Drawing.Size(32, 32);
		this.btnPreview.TabIndex = 30;
		this.btnPreview.UseCustomBackColor = true;
		this.btnPreview.UseCustomForeColor = true;
		this.btnPreview.UseSelectable = true;
		this.btnPreview.UseStyleColors = true;
		this.btnPreview.Visible = false;
		this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
		this.btnPreview.MouseHover += new System.EventHandler(this.btnPreview_MouseHover);
		this.btnCompare.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnCompare.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnCompare.BackgroundImage");
		this.btnCompare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnCompare.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnCompare.Location = new System.Drawing.Point(872, 68);
		this.btnCompare.Name = "btnCompare";
		this.btnCompare.Size = new System.Drawing.Size(12, 32);
		this.btnCompare.TabIndex = 36;
		this.btnCompare.UseCustomBackColor = true;
		this.btnCompare.UseCustomForeColor = true;
		this.btnCompare.UseSelectable = true;
		this.btnCompare.UseStyleColors = true;
		this.btnCompare.Visible = false;
		this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
		this.btnCompare.MouseHover += new System.EventHandler(this.btnCompare_MouseHover);
		this.picLogo.Image = (System.Drawing.Image)resources.GetObject("picLogo.Image");
		this.picLogo.Location = new System.Drawing.Point(24, 16);
		this.picLogo.Name = "picLogo";
		this.picLogo.Size = new System.Drawing.Size(216, 40);
		this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picLogo.TabIndex = 32;
		this.picLogo.TabStop = false;
		this.picLogo.DoubleClick += new System.EventHandler(this.picLogo_DoubleClick);
		this.picLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLogo_MouseDown);
		this.btnInfo.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnInfo.BackgroundImage");
		this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnInfo.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnInfo.Location = new System.Drawing.Point(138, 68);
		this.btnInfo.Name = "btnInfo";
		this.btnInfo.Size = new System.Drawing.Size(32, 32);
		this.btnInfo.TabIndex = 29;
		this.btnInfo.UseCustomBackColor = true;
		this.btnInfo.UseCustomForeColor = true;
		this.btnInfo.UseSelectable = true;
		this.btnInfo.UseStyleColors = true;
		this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
		this.btnSetting.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnSetting.BackgroundImage");
		this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnSetting.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnSetting.Location = new System.Drawing.Point(100, 68);
		this.btnSetting.Name = "btnSetting";
		this.btnSetting.Size = new System.Drawing.Size(32, 32);
		this.btnSetting.TabIndex = 27;
		this.btnSetting.UseCustomBackColor = true;
		this.btnSetting.UseCustomForeColor = true;
		this.btnSetting.UseSelectable = true;
		this.btnSetting.UseStyleColors = true;
		this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
		this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnStop.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnStop.BackgroundImage");
		this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnStop.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnStop.Location = new System.Drawing.Point(966, 68);
		this.btnStop.Name = "btnStop";
		this.btnStop.Size = new System.Drawing.Size(32, 32);
		this.btnStop.TabIndex = 4;
		this.btnStop.UseCustomBackColor = true;
		this.btnStop.UseCustomForeColor = true;
		this.btnStop.UseSelectable = true;
		this.btnStop.UseStyleColors = true;
		this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
		this.btnDel.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnDel.BackgroundImage");
		this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnDel.FontSize = MetroFramework.MetroButtonSize.Tall;
		this.btnDel.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnDel.Location = new System.Drawing.Point(62, 68);
		this.btnDel.Name = "btnDel";
		this.btnDel.Size = new System.Drawing.Size(32, 32);
		this.btnDel.TabIndex = 3;
		this.btnDel.UseCustomBackColor = true;
		this.btnDel.UseCustomForeColor = true;
		this.btnDel.UseSelectable = true;
		this.btnDel.UseStyleColors = true;
		this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
		this.btnAdd.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnAdd.BackgroundImage");
		this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.btnAdd.FontSize = MetroFramework.MetroButtonSize.Medium;
		this.btnAdd.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnAdd.Location = new System.Drawing.Point(24, 68);
		this.btnAdd.Name = "btnAdd";
		this.btnAdd.Size = new System.Drawing.Size(32, 32);
		this.btnAdd.Style = MetroFramework.MetroColorStyle.White;
		this.btnAdd.TabIndex = 0;
		this.btnAdd.UseCustomBackColor = true;
		this.btnAdd.UseCustomForeColor = true;
		this.btnAdd.UseSelectable = true;
		this.btnAdd.UseStyleColors = true;
		this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
		this.picWait.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.picWait.Image = (System.Drawing.Image)resources.GetObject("picWait.Image");
		this.picWait.Location = new System.Drawing.Point(180, 287);
		this.picWait.Name = "picWait";
		this.picWait.Size = new System.Drawing.Size(920, 410);
		this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		this.picWait.TabIndex = 35;
		this.picWait.TabStop = false;
		this.picWait.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picWait_MouseDown);
		this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.btnStart.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnStart.BackgroundImage");
		this.btnStart.FontWeight = MetroFramework.MetroButtonWeight.Regular;
		this.btnStart.Location = new System.Drawing.Point(928, 68);
		this.btnStart.Name = "btnStart";
		this.btnStart.Size = new System.Drawing.Size(32, 32);
		this.btnStart.TabIndex = 2;
		this.btnStart.UseCustomBackColor = true;
		this.btnStart.UseCustomForeColor = true;
		this.btnStart.UseSelectable = true;
		this.btnStart.UseStyleColors = true;
		this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
		base.ApplyImageInvert = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
		base.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
		base.ClientSize = new System.Drawing.Size(1280, 720);
		base.Controls.Add(this.btnReset);
		base.Controls.Add(this.btnFonts);
		base.Controls.Add(this.togPreview);
		base.Controls.Add(this.splitMain);
		base.Controls.Add(this.btnMPC);
		base.Controls.Add(this.btnCompareMPC);
		base.Controls.Add(this.picSaved);
		base.Controls.Add(this.btnPreview);
		base.Controls.Add(this.btnCompare);
		base.Controls.Add(this.picLogo);
		base.Controls.Add(this.btnInfo);
		base.Controls.Add(this.btnSetting);
		base.Controls.Add(this.lblOntop);
		base.Controls.Add(this.togOntop);
		base.Controls.Add(this.lblOutput);
		base.Controls.Add(this.lblSameInput);
		base.Controls.Add(this.togSameInput);
		base.Controls.Add(this.tvDetails);
		base.Controls.Add(this.btnStop);
		base.Controls.Add(this.btnDel);
		base.Controls.Add(this.btnAdd);
		base.Controls.Add(this.lstQueue);
		base.Controls.Add(this.txtOutput);
		base.Controls.Add(this.picWait);
		base.Controls.Add(this.psProgress);
		base.Controls.Add(this.btnStart);
		base.DisplayHeader = false;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.KeyPreview = true;
		this.MinimumSize = new System.Drawing.Size(1280, 720);
		base.Name = "frmMain";
		base.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
		base.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
		base.Style = MetroFramework.MetroColorStyle.Pink;
		this.Text = "KONAYUKI PLUS";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
		base.Load += new System.EventHandler(this.frmMain_Load);
		base.Shown += new System.EventHandler(this.frmMain_Shown);
		base.ResizeBegin += new System.EventHandler(this.frmMain_ResizeBegin);
		base.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
		base.DragLeave += new System.EventHandler(this.frmMain_DragLeave);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
		base.Resize += new System.EventHandler(this.frmMain_Resize);
		this.cmsControlQueue.ResumeLayout(false);
		this.cmsControlQueue_3.ResumeLayout(false);
		this.tpSpecial.ResumeLayout(false);
		this.grpHardSubRemover.ResumeLayout(false);
		this.grpHardSubRemover.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udRemoverRight).EndInit();
		((System.ComponentModel.ISupportInitialize)this.udRemoverLeft).EndInit();
		((System.ComponentModel.ISupportInitialize)this.udRemoverBottom).EndInit();
		((System.ComponentModel.ISupportInitialize)this.udRemoverTop).EndInit();
		this.tpLogo.ResumeLayout(false);
		this.groupBox19.ResumeLayout(false);
		this.groupBox19.PerformLayout();
		this.grpLogo.ResumeLayout(false);
		this.grpLogo.PerformLayout();
		this.grpLogoSetting.ResumeLayout(false);
		this.grpLogoSetting.PerformLayout();
		this.groupBox21.ResumeLayout(false);
		this.groupBox21.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udLogoTimeSecMinute).EndInit();
		((System.ComponentModel.ISupportInitialize)this.udLogoTimeSec).EndInit();
		this.tpTransition.ResumeLayout(false);
		this.tpTransition.PerformLayout();
		this.pnFadeAll.ResumeLayout(false);
		this.pnFade.ResumeLayout(false);
		this.grpEndCardFadeOut.ResumeLayout(false);
		this.grpEndCardFadeOut.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardFadeOutTime).EndInit();
		this.grpSourceFadeOut.ResumeLayout(false);
		this.grpSourceFadeOut.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udSourceFadeOutTime).EndInit();
		this.grpEndCardFadeIn.ResumeLayout(false);
		this.grpEndCardFadeIn.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardFadeInTime).EndInit();
		this.grpSourceFadeIn.ResumeLayout(false);
		this.grpSourceFadeIn.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udSourceFadeInTime).EndInit();
		this.grpIntroFadeOut.ResumeLayout(false);
		this.grpIntroFadeOut.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroFadeOutTime).EndInit();
		this.grpIntroFadeIn.ResumeLayout(false);
		this.grpIntroFadeIn.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroFadeInTime).EndInit();
		this.pnDissolveAll.ResumeLayout(false);
		this.grpDissolve.ResumeLayout(false);
		this.grpDissolve.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udDissolveTime).EndInit();
		((System.ComponentModel.ISupportInitialize)this.udDissolveFadeInTime).EndInit();
		((System.ComponentModel.ISupportInitialize)this.udDissolveFadeOutTime).EndInit();
		this.pnTransition.ResumeLayout(false);
		this.pnTransition.PerformLayout();
		this.grpTransitionEndCard.ResumeLayout(false);
		this.grpTransitionEndCard.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardTransitionAudioTime).EndInit();
		this.grpTransitionIntro.ResumeLayout(false);
		this.grpTransitionIntro.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroTransitionAudioTime).EndInit();
		this.tpVideo.ResumeLayout(false);
		this.grpColorEnhancer.ResumeLayout(false);
		this.grpColorEnhancer.PerformLayout();
		this.grpVideoEnhancer.ResumeLayout(false);
		this.grpVideoEnhancer.PerformLayout();
		this.grpVideoSetting.ResumeLayout(false);
		this.grpVideoSetting.PerformLayout();
		this.tpLog.ResumeLayout(false);
		this.tpLog.PerformLayout();
		this.pnLog.ResumeLayout(false);
		this.tpAudio.ResumeLayout(false);
		this.grpVolumeControl.ResumeLayout(false);
		this.grpVolumeControl.PerformLayout();
		this.grpAudioSetting.ResumeLayout(false);
		this.grpAudioSetting.PerformLayout();
		this.tpMain.ResumeLayout(false);
		this.splitIntroEndCard.ResumeLayout(false);
		this.grpIntro.ResumeLayout(false);
		this.grpIntro.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udIntroTime).EndInit();
		this.grpEndCard.ResumeLayout(false);
		this.grpEndCard.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.udEndCardTime).EndInit();
		this.grpClipDetails.ResumeLayout(false);
		this.grpClipDetails.PerformLayout();
		this.grpKaraoke.ResumeLayout(false);
		this.grpKaraoke.PerformLayout();
		this.grpSubtitle.ResumeLayout(false);
		this.grpSubtitle.PerformLayout();
		this.tcQueue.ResumeLayout(false);
		this.cmsControlQueue_2.ResumeLayout(false);
		this.cmsControlQueue_4.ResumeLayout(false);
		this.cmsControlQueue_5.ResumeLayout(false);
		this.cmsControlQueue_6.ResumeLayout(false);
		this.cmsControlQueue_7.ResumeLayout(false);
		this.cmsControlQueue_8.ResumeLayout(false);
		this.cmsControlQueue_9.ResumeLayout(false);
		this.splitMain.ResumeLayout(false);
		this.tcPlayer.ResumeLayout(false);
		this.tpPreview.ResumeLayout(false);
		this.tpPreview.PerformLayout();
		this.pnGoto.ResumeLayout(false);
		this.pnGoto.PerformLayout();
		this.pnControl.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.videoBox).EndInit();
		this.tpMediaInfo.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.picSaved).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picLogo).EndInit();
		((System.ComponentModel.ISupportInitialize)this.picWait).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
