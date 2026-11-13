using System;

namespace A;

internal sealed class RecoveredType2
{
	public string Version;

	public string DownloadUrl;

	public string Sha256;

	public long Bytes;

	public Version Number => RecoveredType3.RecoveredMethod0(Version);
}
