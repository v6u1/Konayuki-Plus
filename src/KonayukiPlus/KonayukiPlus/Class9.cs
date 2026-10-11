using System.Diagnostics;
using System.Windows.Forms;

namespace KonayukiPlus;

public static class Class9
{
	public static void smethod_0(this LinkLabel P_0, string[] P_1, string[] P_2)
	{
		P_0.AutoSize = true;
		for (int i = 0; i < P_1.Length; i++)
		{
			P_0.Links.Add(P_0.Text.IndexOf(P_1[i]), P_1[i].Length, P_2[i]);
		}
		P_0.LinkClicked += (object obj, LinkLabelLinkClickedEventArgs e) =>
		{
			P_0.Links[P_0.Links.IndexOf(e.Link)].Visited = true;
			Process.Start(e.Link.LinkData.ToString());
		};
	}
}
