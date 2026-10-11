namespace KonayukiPlus;

/// <summary>
/// Central network configuration for the revived build.
///
/// The original release hard-coded <c>*.konayuki.moe</c> hosts across the code base. The revival
/// routes every functional endpoint through this one class, so moving to a different server is a
/// single-line change to <see cref="Host"/>.
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
    /// <summary>Base host for all revived infrastructure. Change this one line to move servers.</summary>
    // cdn.v6u1.lol is nginx-static (CORS + cache, Cloudflare TLS), served from /srv/konayuki,
    // isolated from the Next.js site on v6u1.lol.
    public const string Host = "https://cdn.v6u1.lol/konayuki";

    /// <summary>Self-updater root. Serves <c>list.txt</c> and every file it references.</summary>
    public const string Sync = Host + "/sync/";

    /// <summary>Encrypted configuration blob consumed on startup by the splash screen.</summary>
    public const string Api = Sync + "plugins.cfg";

    /// <summary>"What's New" page. Its &lt;title&gt; must contain "konayuki.moe" for the changelog window to show it.</summary>
    public const string Changelog = Host + "/plus_changelog.html";

    /// <summary>Base URL for the per-filter help pages.</summary>
    public const string Help = Host + "/KonayukiPlus/";
}
