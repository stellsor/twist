using System;
using System.Collections.Generic;
using System.Text;

namespace A;

internal static class ActivityTextExport
{
    public static string Format(IEnumerable<RecoveredType82> events)
    {
        var text = new StringBuilder();
        text.AppendLine("Twist activity log");
        text.AppendLine("Exported UTC " + DateTime.UtcNow.ToString("o"));
        text.AppendLine("All saved accounts and events, newest first. Search and display filters do not limit this export.");
        text.AppendLine();
        foreach (var item in events)
        {
            var entry = RecoveredType84.RecoveredMethod366(item);
            text.AppendLine(entry.AtUtc + " | " + entry.Level + " | " + entry.Category + " | " + entry.Account + " | " + entry.Source);
            text.AppendLine(entry.Message);
            text.AppendLine();
        }
        return text.ToString();
    }
}
