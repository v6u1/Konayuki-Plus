using System.Globalization;
using System.Windows.Forms;

namespace KonayukiPlus;

internal class Class2
{
	public static void smethod_0()
	{
		CultureInfo cultureInfo = (CultureInfo)Application.CurrentCulture.Clone();
		cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
		cultureInfo.NumberFormat.NumberGroupSeparator = ",";
		cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
		cultureInfo.NumberFormat.CurrencyGroupSeparator = ",";
		Application.CurrentCulture = cultureInfo;
	}
}
