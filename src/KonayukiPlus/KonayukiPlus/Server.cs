namespace KonayukiPlus;

/// <summary>
/// Central network configuration for the revived build.
///
/// The original release hard-coded <c>*.konayuki.moe</c> hosts across the code base. The revival
/// routes every functional endpoint through this one class, so moving to a different server is a
/// single change to <see cref="Host"/> (set in <c>ServerConfig.local.cs</c>).
///
/// All of these are plain static HTTP GETs:
///   <see cref="Sync"/>       serves <c>list.txt</c> (the "path|sha1|run|cmd" update manifest) and
///                            every file listed in it (ffmpeg, mpv, AviSynth filters, codecs, ...).
///   <see cref="Api"/>        the encrypted configuration blob (base64 -> XOR -> JSON): version,
///                            the AviSynth function library, the font catalogue and the mpv config.
///   <see cref="Changelog"/>  the "What's New" page shown in the changelog window.
///   <see cref="Help"/>       base for the per-filter help pages (HOW_TO_USE.html, SHARPEN.html, ...).
///
/// Font files themselves are not referenced here: their URLs live inside the <see cref="Api"/> blob,
/// so they are repointed by editing that file on the server, not by rebuilding the app.
/// </summary>
internal static class Server
{
    /// <summary>
    /// Base URL for all revived infrastructure. It comes from <c>ServerConfig.local.cs</c>, which is
    /// git-ignored because the server only serves the app's files under a secret path prefix
    /// (see <c>ServerConfig.example.cs</c>). Without that file the build uses a placeholder host.
    /// </summary>
    public const string Host = ServerConfig.Host;

    /// <summary>Self-updater root. Serves <c>list.txt</c> and every file it references.</summary>
    public const string Sync = Host + "/sync/";

    /// <summary>Encrypted configuration blob consumed on startup by the splash screen.</summary>
    public const string Api = Sync + "plugins.cfg";

    /// <summary>"What's New" page. Its &lt;title&gt; must contain "konayuki.moe" for the changelog window to show it.</summary>
    public const string Changelog = Host + "/plus_changelog.html";

    /// <summary>Base URL for the per-filter help pages.</summary>
    public const string Help = Host + "/KonayukiPlus/";

    /// <summary>
    /// Where users report problems. The original pointed at the developers' Facebook Messenger, which nobody
    /// answers any more; this is the bug report form of the revival's repository (public, not under Host).
    /// </summary>
    public const string Support = "https://github.com/v6u1/KonayukiPlus/issues/new/choose";
}
