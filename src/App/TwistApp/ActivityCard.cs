using System;

namespace TwistApp;

public sealed class ActivityCard
{
	public string Time { get; set; }

	public string Scope { get; set; }

	public string Kind { get; set; }

	public string Message { get; set; }

	public string Color { get; set; }

	public string Full => Time + " · " + Scope + " · " + Kind + Environment.NewLine + Message;
}
