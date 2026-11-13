using System;

namespace A;

internal sealed class RecoveredType82
{
	public string Id = Guid.NewGuid().ToString("N");

	public string AtUtc = DateTime.UtcNow.ToString("o");

	public string Account = "";

	public string UserId = "";

	public string Source = "";

	public string Category = "General";

	public string Level = "Info";

	public string Message = "";

	public RecoveredType82 RecoveredMethod361()
	{
		return (RecoveredType82)MemberwiseClone();
	}
}
