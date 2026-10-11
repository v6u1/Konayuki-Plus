namespace KonayukiPlus;

public static class Class8
{
	public static string[] Source { get; } = new string[10] { ".mp4", ".mkv", ".avi", ".wmv", ".mov", ".mpg", ".webm", ".mpeg", ".m2ts", ".ts" };

	public static string[] Subtitle { get; } = new string[4] { ".ass", ".srt", ".ssa", ".sup" };

	public static string[] Karaoke { get; } = new string[4] { ".ass", ".srt", ".ssa", ".sup" };

	public static string[] Intro { get; } = new string[12]
	{
		".mp4", ".mkv", ".avi", ".wmv", ".mov", ".mpg", ".webm", ".mpeg", ".m2ts", ".ts",
		".png", ".jpg"
	};

	public static string[] EndCard { get; } = new string[12]
	{
		".mp4", ".mkv", ".avi", ".wmv", ".mov", ".mpg", ".webm", ".mpeg", ".m2ts", ".ts",
		".png", ".jpg"
	};

	public static string[] IntroMusic { get; } = new string[4] { ".aac", ".mp3", ".wma", ".flac" };

	public static string[] EndCardMusic { get; } = new string[4] { ".aac", ".mp3", ".wma", ".flac" };

	public static string[] Logo { get; } = new string[2] { ".png", ".mov" };

	public static string[] Transition { get; } = new string[1] { ".mov" };

	public static string[] Project { get; } = new string[1] { ".kpj" };
}
