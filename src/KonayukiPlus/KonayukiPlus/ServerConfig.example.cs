namespace KonayukiPlus;

/// <summary>
/// Placeholder server configuration, compiled only when <c>ServerConfig.local.cs</c> does not exist.
///
/// The production server serves the app's files (config blob, update manifest, fonts, installer)
/// only under an unguessable path prefix, and answers 404 everywhere else except the public changelog
/// page. That prefix is therefore kept out of version control. To build a client that can reach a
/// server, copy this file to <c>ServerConfig.local.cs</c> (git-ignored) and set <see cref="Host"/> to
/// the real base URL. The project file picks the local file automatically when it exists.
/// </summary>
internal static class ServerConfig
{
    public const string Host = "https://cdn.example.com/konayuki";
}
