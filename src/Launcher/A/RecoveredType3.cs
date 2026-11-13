using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;

namespace A;

internal static class RecoveredType3
{
	[CompilerGenerated]
	private sealed class RecoveredType4
	{
		public string name;

		public bool RecoveredMethod10(Dictionary<string, object> P_0)
		{
			if (P_0.ContainsKey("name"))
			{
				return Convert.ToString(P_0["name"]) == name;
			}
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType5
	{
		public HttpWebRequest request;

		public void RecoveredMethod11()
		{
			request.Abort();
		}
	}

	public const string Endpoint = "https://api.github.com/repos/Stellsor/twist/releases/latest";

	public const long MaxPackage = 67108864L;

	public static Version Installed => typeof(RecoveredType3).Assembly.GetName().Version;

	public static Version RecoveredMethod0(string P_0)
	{
		if (!Regex.IsMatch(P_0 ?? "", "^\\d+\\.\\d+\\.\\d+$") || !Version.TryParse(P_0, out var result))
		{
			throw new Exception("Invalid update version.");
		}
		return new Version(result.Major, result.Minor, result.Build, 0);
	}

	public static RecoveredType2 RecoveredMethod1(string P_0)
	{
		if (P_0 == null || P_0.Length > 131072)
		{
			throw new Exception("Invalid update response.");
		}
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		javaScriptSerializer.MaxJsonLength = 131072;
		if (!(javaScriptSerializer.DeserializeObject(P_0) is Dictionary<string, object> dictionary) || !dictionary.TryGetValue("tag_name", out var value))
		{
			throw new Exception("Missing release version.");
		}
		string text = Convert.ToString(value);
		if (!text.StartsWith("v", StringComparison.Ordinal))
		{
			throw new Exception("Invalid release tag.");
		}
		string text2 = text.Substring(1);
		RecoveredMethod0(text2);
		if ((dictionary.TryGetValue("draft", out value) && !object.Equals(value, false)) || (dictionary.TryGetValue("prerelease", out value) && !object.Equals(value, false)))
		{
			throw new Exception("Update is not a stable release.");
		}
		if (!dictionary.TryGetValue("assets", out value) || !(value is object[]))
		{
			throw new Exception("Missing update package.");
		}
		string name = "twist-" + text2 + "-public.zip";
		Dictionary<string, object>[] array = (from dictionary3 in ((object[])value).OfType<Dictionary<string, object>>()
			where dictionary3.ContainsKey("name") && Convert.ToString(dictionary3["name"]) == name
			select dictionary3).ToArray();
		if (array.Length != 1)
		{
			throw new Exception("Missing or ambiguous update package.");
		}
		Dictionary<string, object> dictionary2 = array[0];
		if (!dictionary2.TryGetValue("size", out var value2) || !long.TryParse(Convert.ToString(value2), out var result) || result < 1 || result > 67108864 || !dictionary2.TryGetValue("digest", out var value3) || !Regex.IsMatch(Convert.ToString(value3), "^sha256:[0-9a-f]{64}$") || !dictionary2.TryGetValue("browser_download_url", out var value4))
		{
			throw new Exception("The release has no verified package checksum.");
		}
		RecoveredType2 recoveredType = new RecoveredType2();
		recoveredType.Version = text2;
		recoveredType.Bytes = result;
		recoveredType.Sha256 = Convert.ToString(value3).Substring(7);
		recoveredType.DownloadUrl = Convert.ToString(value4);
		RecoveredType2 recoveredType2 = recoveredType;
		RecoveredMethod2(recoveredType2);
		return recoveredType2;
	}

	public static void RecoveredMethod2(RecoveredType2 P_0)
	{
		if (P_0 == null)
		{
			throw new Exception("Missing update.");
		}
		RecoveredMethod0(P_0.Version);
		string value = "/Stellsor/twist/releases/download/v" + P_0.Version + "/twist-" + P_0.Version + "-public.zip";
		if (!Uri.TryCreate(P_0.DownloadUrl, UriKind.Absolute, out var result) || result.Scheme != "https" || result.Port != 443 || result.Host != "github.com" || result.UserInfo != "" || result.Query != "" || result.Fragment != "" || !result.AbsolutePath.Equals(value, StringComparison.OrdinalIgnoreCase) || P_0.Bytes < 1 || P_0.Bytes > 67108864 || !Regex.IsMatch(P_0.Sha256 ?? "", "^[0-9a-f]{64}$"))
		{
			throw new Exception("Untrusted update package.");
		}
	}

	private static HttpWebRequest RecoveredMethod3(Uri P_0)
	{
		ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(P_0);
		httpWebRequest.Method = "GET";
		httpWebRequest.UserAgent = "twist launcher/" + Installed;
		httpWebRequest.AllowAutoRedirect = false;
		httpWebRequest.UseDefaultCredentials = false;
		httpWebRequest.Timeout = 15000;
		httpWebRequest.ReadWriteTimeout = 10000;
		return httpWebRequest;
	}

	public static RecoveredType2 RecoveredMethod4()
	{
		HttpWebRequest httpWebRequest = RecoveredMethod3(new Uri("https://api.github.com/repos/Stellsor/twist/releases/latest"));
		httpWebRequest.Timeout = 5000;
		httpWebRequest.Accept = "application/vnd.github+json";
		using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		if (httpWebResponse.StatusCode != HttpStatusCode.OK || httpWebResponse.ContentLength > 131072)
		{
			throw new Exception("Update check unavailable.");
		}
		using Stream stream = httpWebResponse.GetResponseStream();
		using MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[8192];
		Stopwatch stopwatch = Stopwatch.StartNew();
		int num;
		while ((num = stream.Read(array, 0, array.Length)) > 0)
		{
			if (memoryStream.Length + num > 131072 || stopwatch.ElapsedMilliseconds > 10000)
			{
				throw new Exception("Update check exceeded its limit.");
			}
			memoryStream.Write(array, 0, num);
		}
		return RecoveredMethod1(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true).GetString(memoryStream.ToArray()));
	}

	public static string RecoveredMethod5(string P_0)
	{
		using FileStream inputStream = File.OpenRead(P_0);
		using SHA256 sHA = SHA256.Create();
		return string.Concat(from b in sHA.ComputeHash(inputStream)
			select b.ToString("x2"));
	}

	internal static void RecoveredMethod6(Stream P_0, string P_1, RecoveredType2 P_2, CancellationToken P_3, Action<int> P_4)
	{
		long num = 0L;
		Stopwatch stopwatch = Stopwatch.StartNew();
		using (FileStream fileStream = new FileStream(P_1, FileMode.CreateNew, FileAccess.Write, FileShare.None))
		{
			byte[] array = new byte[65536];
			int num2 = -1;
			int num3;
			while ((num3 = P_0.Read(array, 0, array.Length)) > 0)
			{
				P_3.ThrowIfCancellationRequested();
				num += num3;
				if (num > P_2.Bytes || num > 67108864 || stopwatch.ElapsedMilliseconds > 120000)
				{
					throw new Exception("Update download exceeded its limit.");
				}
				fileStream.Write(array, 0, num3);
				int num4 = (int)(num * 100 / P_2.Bytes);
				if (num4 != num2)
				{
					num2 = num4;
					P_4?.Invoke(num4);
				}
			}
			fileStream.Flush(flushToDisk: true);
		}
		P_3.ThrowIfCancellationRequested();
		if (num != P_2.Bytes || RecoveredMethod5(P_1) != P_2.Sha256)
		{
			throw new Exception("The downloaded update failed its checksum check.");
		}
	}

	internal static bool RecoveredMethod7(Uri P_0)
	{
		if (P_0 != null && P_0.Scheme == "https" && P_0.Port == 443 && P_0.UserInfo == "" && P_0.Fragment == "")
		{
			return new string[3] { "github.com", "release-assets.githubusercontent.com", "objects.githubusercontent.com" }.Contains(P_0.Host);
		}
		return false;
	}

	public static string RecoveredMethod8(string P_0, RecoveredType2 P_1, CancellationToken P_2, Action<int> P_3)
	{
		RecoveredMethod2(P_1);
		string text = Path.Combine(P_0, "twist-" + P_1.Version + "-public.zip");
		string text2 = text + ".part-" + Guid.NewGuid().ToString("N");
		if (File.Exists(text) && new FileInfo(text).Length == P_1.Bytes && RecoveredMethod5(text) == P_1.Sha256)
		{
			return text;
		}
		try
		{
			Uri uri = new Uri(P_1.DownloadUrl);
			for (int i = 0; i < 6; i++)
			{
				P_2.ThrowIfCancellationRequested();
				if (!RecoveredMethod7(uri))
				{
					throw new Exception("Untrusted update redirect.");
				}
				HttpWebRequest request = RecoveredMethod3(uri);
				using (P_2.Register(delegate
				{
					request.Abort();
				}))
				{
					using HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
					int statusCode = (int)httpWebResponse.StatusCode;
					if (new int[5] { 301, 302, 303, 307, 308 }.Contains(statusCode))
					{
						string text3 = httpWebResponse.Headers["Location"];
						if (string.IsNullOrEmpty(text3))
						{
							throw new Exception("Missing update redirect.");
						}
						uri = new Uri(uri, text3);
						continue;
					}
					if (statusCode != 200 || (httpWebResponse.ContentLength >= 0 && httpWebResponse.ContentLength != P_1.Bytes))
					{
						throw new Exception("The update server returned an invalid package.");
					}
					using (Stream stream = httpWebResponse.GetResponseStream())
					{
						RecoveredMethod6(stream, text2, P_1, P_2, P_3);
					}
					if (File.Exists(text))
					{
						File.Replace(text2, text, null);
					}
					else
					{
						File.Move(text2, text);
					}
					return text;
				}
			}
			throw new Exception("Too many update redirects.");
		}
		finally
		{
			if (File.Exists(text2))
			{
				File.Delete(text2);
			}
		}
	}

	[CompilerGenerated]
	private static string RecoveredMethod9(byte P_0)
	{
		return P_0.ToString("x2");
	}
}
