using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace b;

internal static class RecoveredType422
{
	public const string Origin = "https://offsets.imtheo.lol/";

	private static readonly Regex VersionPattern = new Regex("^version-[a-f0-9]{16}$", RegexOptions.IgnoreCase);

	private static readonly string[] Required = new string[20]
	{
		"FakeDataModel.Pointer", "FakeDataModel.RealDataModel", "Instance.NameContainer", "Instance.Name", "Instance.ChildrenStart", "Instance.ChildrenEnd", "Instance.ClassDescriptor", "Instance.ClassName", "Instance.Parent", "Misc.StringLength",
		"Player.LocalPlayer", "Player.UserId", "Player.DisplayName", "Player.ModelInstance", "GuiObject.Visible", "GuiObject.ScreenGui_Enabled", "GuiObject.Position", "GuiObject.Size", "DataModel.PlaceId", "DataModel.GameId"
	};

	public static string LastStatus = "Bundled offsets";

	public static string CacheFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "twist-rdp", "offsets");

	public static string RecoveredMethod783(string P_0, string P_1 = null)
	{
		if (P_0 == null || P_0.Length > 524288)
		{
			throw new Exception("Offset response is too large.");
		}
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		javaScriptSerializer.MaxJsonLength = 524288;
		if (!(javaScriptSerializer.DeserializeObject(P_0) is Dictionary<string, object> dictionary) || !dictionary.TryGetValue("Roblox Version", out var value) || !VersionPattern.IsMatch(Convert.ToString(value)) || !dictionary.TryGetValue("Offsets", out var value2))
		{
			throw new Exception("Invalid versioned offset JSON.");
		}
		string text = Convert.ToString(value).ToLowerInvariant();
		if (P_1 != null && text != P_1.ToLowerInvariant())
		{
			throw new Exception("Downloaded offsets do not match " + P_1 + ".");
		}
		if (!(value2 is Dictionary<string, object> dictionary2))
		{
			throw new Exception("Invalid offset groups.");
		}
		string[] required = Required;
		foreach (string text2 in required)
		{
			string[] array = text2.Split('.');
			if (!dictionary2.TryGetValue(array[0], out var value3))
			{
				throw new Exception("Missing offset group " + array[0] + ".");
			}
			if (!(value3 is Dictionary<string, object> dictionary3) || !dictionary3.TryGetValue(array[1], out var value4) || value4 == null || value4 is bool)
			{
				throw new Exception("Missing offset " + text2 + ".");
			}
			string text3 = Convert.ToString(value4, CultureInfo.InvariantCulture);
			if (!(text3.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? ulong.TryParse(text3.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result) : ulong.TryParse(text3, NumberStyles.None, CultureInfo.InvariantCulture, out result)) || result > 1073741824 || (result == 0 && text2 != "Instance.Name"))
			{
				throw new Exception("Invalid offset " + text2 + ".");
			}
		}
		return text;
	}

	public static string RecoveredMethod381(string P_0)
	{
		Match match = Regex.Match(P_0 ?? "", "(?:^|[\\\\/])(version-[a-f0-9]{16})(?:[\\\\/]|$)", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return null;
		}
		return match.Groups[1].Value.ToLowerInvariant();
	}

	private static string RecoveredMethod52(string P_0)
	{
		Uri uri = new Uri(new Uri("https://offsets.imtheo.lol/"), P_0);
		if (uri.Scheme != "https" || uri.Host != "offsets.imtheo.lol")
		{
			throw new Exception("Invalid offset endpoint.");
		}
		ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
		httpWebRequest.Method = "GET";
		httpWebRequest.Timeout = 5000;
		httpWebRequest.ReadWriteTimeout = 3000;
		httpWebRequest.AllowAutoRedirect = false;
		httpWebRequest.UserAgent = "twist/0.7.29 offsets";
		httpWebRequest.Accept = "application/json";
		httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK || httpWebResponse.ContentLength > 524288)
		{
			throw new Exception("Offset server returned an invalid response.");
		}
		using Stream stream = httpWebResponse.GetResponseStream();
		using MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[8192];
		Stopwatch stopwatch = Stopwatch.StartNew();
		int num;
		while ((num = stream.Read(array, 0, array.Length)) > 0)
		{
			if (memoryStream.Length + num > 524288 || stopwatch.ElapsedMilliseconds > 8000)
			{
				httpWebRequest.Abort();
				throw new Exception("Offset download exceeded its limit.");
			}
			memoryStream.Write(array, 0, num);
		}
		return new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true).GetString(memoryStream.ToArray());
	}

	public static void RecoveredMethod907(string P_0, string P_1)
	{
		string text = RecoveredMethod783(P_1);
		Directory.CreateDirectory(P_0);
		string text2 = Path.Combine(P_0, text + ".json");
		string text3 = text2 + "." + Guid.NewGuid().ToString("N") + ".tmp";
		try
		{
			File.WriteAllText(text3, P_1, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
			if (File.Exists(text2))
			{
				File.Replace(text3, text2, null);
				return;
			}
			try
			{
				File.Move(text3, text2);
			}
			catch (IOException)
			{
				if (!File.Exists(text2))
				{
					throw;
				}
				File.Replace(text3, text2, null);
			}
		}
		finally
		{
			if (File.Exists(text3))
			{
				File.Delete(text3);
			}
		}
	}

	public static string RecoveredMethod908(string P_0, string P_1)
	{
		if (P_1 == null || !VersionPattern.IsMatch(P_1))
		{
			return null;
		}
		string path = Path.Combine(P_0, P_1.ToLowerInvariant() + ".json");
		try
		{
			string text = File.ReadAllText(path);
			RecoveredMethod783(text, P_1);
			return text;
		}
		catch
		{
			return null;
		}
	}

	public static string[] RecoveredMethod790()
	{
		List<string> list = new List<string>();
		int sessionId;
		using (Process process = Process.GetCurrentProcess())
		{
			sessionId = process.SessionId;
		}
		Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
		foreach (Process process2 in processesByName)
		{
			using (process2)
			{
				try
				{
					if (process2.SessionId == sessionId)
					{
						string text = RecoveredMethod381(process2.MainModule.FileName);
						if (text != null)
						{
							list.Add(text);
						}
					}
				}
				catch
				{
				}
			}
		}
		return list.Distinct().Take(2).ToArray();
	}

	public static string RecoveredMethod909(string P_0, string P_1, Func<string, string> P_2, IEnumerable<string> P_3)
	{
		string text = RecoveredMethod783(P_1);
		List<string> list = new List<string>();
		string text2 = null;
		try
		{
			string text3 = P_2("offsets.json");
			text2 = RecoveredMethod783(text3);
			RecoveredMethod907(P_0, text3);
		}
		catch (Exception ex)
		{
			list.Add(ex.Message);
		}
		foreach (string item in (from text6 in P_3.Concat(new string[1] { text })
			where text6 != null && VersionPattern.IsMatch(text6)
			select text6).Distinct().Take(3))
		{
			if (!(item == text2) && (text2 != null || (!(item == text) && RecoveredMethod908(P_0, item) == null)))
			{
				try
				{
					string text4 = P_2(item + "/offsets.json");
					RecoveredMethod783(text4, item);
					RecoveredMethod907(P_0, text4);
				}
				catch (Exception ex2)
				{
					list.Add(ex2.Message);
				}
			}
		}
		string text5 = ((text2 == null) ? "Offset check unavailable; keeping cached or bundled matching offsets." : ("Offsets checked · " + text2));
		if (list.Count > 0 && text2 != null)
		{
			text5 += " · some archived versions unavailable";
		}
		LastStatus = text5;
		try
		{
			Directory.CreateDirectory(P_0);
			File.WriteAllText(Path.Combine(P_0, "last-check.txt"), DateTime.UtcNow.ToString("o") + "\r\n" + text5);
		}
		catch
		{
		}
		return text5;
	}

	public static string RecoveredMethod910(string P_0)
	{
		return RecoveredMethod909(CacheFolder, P_0, RecoveredMethod52, RecoveredMethod790());
	}

	public static string RecoveredMethod911(string P_0, string P_1, string P_2)
	{
		string text = RecoveredMethod381(P_1);
		if (text == null)
		{
			throw new Exception("Cannot identify this Roblox version.");
		}
		string text2 = RecoveredMethod908(P_0, text);
		if (text2 != null)
		{
			return text2;
		}
		if (!(RecoveredMethod783(P_2) == text))
		{
			return null;
		}
		return P_2;
	}

	public static string RecoveredMethod912(string P_0, string P_1)
	{
		string text = RecoveredMethod381(P_0);
		if (text == null)
		{
			throw new Exception("Cannot identify this Roblox version.");
		}
		string text2 = RecoveredMethod911(CacheFolder, P_0, P_1);
		if (text2 != null)
		{
			return text2;
		}
		try
		{
			text2 = RecoveredMethod52(text + "/offsets.json");
			RecoveredMethod783(text2, text);
			RecoveredMethod907(CacheFolder, text2);
			return text2;
		}
		catch
		{
			throw new Exception("No validated offsets are available for " + text + ". Reopen twist after that version is published.");
		}
	}

	[CompilerGenerated]
	private static bool RecoveredMethod901(string P_0)
	{
		if (P_0 != null)
		{
			return VersionPattern.IsMatch(P_0);
		}
		return false;
	}
}
