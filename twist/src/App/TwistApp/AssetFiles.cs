using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace TwistApp;

public sealed class AssetFiles
{
	private readonly string folder;

	public AssetFiles(string directory)
	{
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		folder = directory;
		Directory.CreateDirectory(folder);
	}

	public static string RecoveredMethod741(string content)
	{
		Match match = Regex.Match(content ?? "", "^(?:rbxassetid://|https://(?:www\\.)?roblox\\.com/asset/\\?id=|https://assetdelivery\\.roblox\\.com/v1/asset/\\?id=)([0-9]{1,19})", RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return "";
		}
		return match.Groups[1].Value;
	}

	public string RecoveredMethod742(string content)
	{
		string text = RecoveredMethod741(content);
		if (text == "")
		{
			throw new Exception("No public asset reference.");
		}
		string text2 = Path.Combine(folder, text + ".asset");
		if (File.Exists(text2) && new FileInfo(text2).Length > 0)
		{
			return text2;
		}
		string text3 = Path.Combine(folder, text + ".clientmesh");
		if (File.Exists(text3))
		{
			return text3;
		}
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://assetdelivery.roblox.com/v1/asset/?id=" + text);
		httpWebRequest.Timeout = 15000;
		httpWebRequest.ReadWriteTimeout = 15000;
		httpWebRequest.UserAgent = "twist/0.5";
		httpWebRequest.UseDefaultCredentials = false;
		httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
		{
			using Stream stream = httpWebResponse.GetResponseStream();
			using MemoryStream memoryStream = new MemoryStream();
			if (httpWebResponse.ContentLength > 33554432)
			{
				throw new Exception("Asset exceeds the preview limit.");
			}
			byte[] array = new byte[32768];
			int num;
			while ((num = stream.Read(array, 0, array.Length)) > 0)
			{
				if (memoryStream.Length + num > 33554432)
				{
					throw new Exception("Asset exceeds the preview limit.");
				}
				memoryStream.Write(array, 0, num);
			}
			if (memoryStream.Length == 0)
			{
				throw new Exception("Empty asset response.");
			}
			string text4 = text2 + "." + Guid.NewGuid().ToString("N") + ".tmp";
			File.WriteAllBytes(text4, memoryStream.ToArray());
			try
			{
				if (File.Exists(text2))
				{
					File.Delete(text4);
				}
				else
				{
					File.Move(text4, text2);
				}
			}
			catch
			{
				if (File.Exists(text4))
				{
					File.Delete(text4);
				}
				throw;
			}
		}
		return text2;
	}
}
