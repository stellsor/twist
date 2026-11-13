using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace b;

internal static class RecoveredType423
{
	[CompilerGenerated]
	private sealed class RecoveredType424
	{
		public string bundled;
	}

	[CompilerGenerated]
	private sealed class RecoveredType425
	{
		public RecoveredType424 CS_0024_003C_003E8__locals4;

		public string newJson;

		public List<string> paths;

		public string RecoveredMethod381(string P_0)
		{
			paths.Add(P_0);
			if (!(P_0 == "offsets.json"))
			{
				return CS_0024_003C_003E8__locals4.bundled;
			}
			return newJson;
		}
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("Offset updater: " + P_1);
		}
	}

	public static void RecoveredMethod48(string P_0)
	{
		string text = Path.Combine(Path.GetTempPath(), "twist-offset-test-" + Guid.NewGuid().ToString("N"));
		try
		{
			string text2 = RecoveredType422.RecoveredMethod783(P_0);
			string text3 = "version-aaaaaaaaaaaaaaaa";
			string newJson = P_0.Replace(text2, text3);
			List<string> paths = new List<string>();
			RecoveredType422.RecoveredMethod909(text, P_0, delegate(string text7)
			{
				paths.Add(text7);
				return (!(text7 == "offsets.json")) ? P_0 : newJson;
			}, new string[1] { text2 });
			RecoveredMethod42(paths.SequenceEqual(new string[2]
			{
				"offsets.json",
				text2 + "/offsets.json"
			}), "live endpoint plus exact archive endpoint");
			RecoveredMethod42(RecoveredType422.RecoveredMethod908(text, text3) != null && RecoveredType422.RecoveredMethod908(text, text2) != null, "cache retains both versions");
			string text4 = "C:/Roblox/Versions/" + text2 + "/RobloxPlayerBeta.exe";
			string text5 = "C:/Roblox/Versions/" + text3 + "/RobloxPlayerBeta.exe";
			RecoveredMethod42(RecoveredType422.RecoveredMethod783(RecoveredType422.RecoveredMethod911(text, text4, P_0)) == text2 && RecoveredType422.RecoveredMethod783(RecoveredType422.RecoveredMethod911(text, text5, P_0)) == text3, "each client resolves its own version, never simply the newest");
			string text6 = RecoveredType422.RecoveredMethod908(text, text2);
			bool flag = false;
			try
			{
				RecoveredType422.RecoveredMethod907(text, "{bad");
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag && RecoveredType422.RecoveredMethod908(text, text2) == text6, "malformed update preserves good cache");
			flag = false;
			try
			{
				RecoveredType422.RecoveredMethod783(newJson, text2);
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag, "mismatched response rejected");
			flag = false;
			try
			{
				RecoveredType422.RecoveredMethod783(P_0.Replace("NameContainer", "RemovedRequiredKey"));
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag, "missing required fields rejected");
			flag = false;
			try
			{
				RecoveredType422.RecoveredMethod783(P_0.Replace("150312976", "-1"));
			}
			catch
			{
				flag = true;
			}
			RecoveredMethod42(flag, "negative offsets rejected");
			RecoveredMethod42(RecoveredType422.RecoveredMethod381("C:\\Roblox\\Versions\\" + text2 + "\\RobloxPlayerBeta.exe") == text2 && RecoveredType422.RecoveredMethod381("C:/version-../../RobloxPlayerBeta.exe") == null, "version paths constrained");
			RecoveredMethod42(RecoveredType422.RecoveredMethod908(text, "../bad") == null, "cache traversal rejected");
			RecoveredType422.RecoveredMethod909(text, P_0, delegate
			{
				throw new IOException("offline");
			}, new string[1] { text2 });
			RecoveredMethod42(RecoveredType422.RecoveredMethod908(text, text2) == text6, "offline startup preserves matching cache");
			RecoveredMethod42(RecoveredType422.RecoveredMethod911(text, "C:/version-bbbbbbbbbbbbbbbb/RobloxPlayerBeta.exe", P_0) == null, "unknown uncached version does not use the wrong bundle");
			Console.WriteLine("PASS: current/archive endpoint selection, exact-version cache resolution, malformed/missing/negative/mismatched data rejection, offline fallback and path validation.");
		}
		finally
		{
			if (Directory.Exists(text))
			{
				string[] files = Directory.GetFiles(text);
				foreach (string path in files)
				{
					File.Delete(path);
				}
				Directory.Delete(text);
			}
		}
	}

	[CompilerGenerated]
	private static string RecoveredMethod52(string P_0)
	{
		throw new IOException("offline");
	}
}
