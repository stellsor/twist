using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace B;

internal sealed class RecoveredType321
{
	public int Port = 26744;

	public string Secret;

	public string Code => "twist1:" + Port + ":" + Secret;

	public static RecoveredType321 RecoveredMethod780(string P_0)
	{
		string[] array = (P_0 ?? "").Trim().Split(':');
		if (array.Length != 3 || array[0] != "twist1" || !int.TryParse(array[1], out var result) || result < 1024 || result > 65535 || !Regex.IsMatch(array[2], "^[0-9a-fA-F]{64}$"))
		{
			throw new FormatException("Paste the complete pairing code from the controller.");
		}
		RecoveredType321 recoveredType = new RecoveredType321();
		recoveredType.Port = result;
		recoveredType.Secret = array[2].ToLowerInvariant();
		return recoveredType;
	}

	public static RecoveredType321 RecoveredMethod781(string P_0, Action P_1 = null)
	{
		bool flag = false;
		if (File.Exists(P_0))
		{
			string text = File.ReadAllText(P_0);
			try
			{
				return RecoveredMethod780(text);
			}
			catch (FormatException)
			{
				File.Copy(P_0, P_0 + ".invalid-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + "-" + Guid.NewGuid().ToString("N"));
				flag = true;
			}
		}
		RecoveredType321 recoveredType = new RecoveredType321();
		recoveredType.Secret = RecoveredMethod357();
		RecoveredType321 recoveredType2 = recoveredType;
		RecoveredMethod782(P_0, recoveredType2);
		if (flag)
		{
			P_1?.Invoke();
		}
		return recoveredType2;
	}

	public static void RecoveredMethod782(string P_0, RecoveredType321 P_1)
	{
		string code = RecoveredMethod780(P_1.Code).Code;
		string text = P_0 + ".tmp-" + Guid.NewGuid().ToString("N");
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(code);
			using (FileStream fileStream = new FileStream(text, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			{
				fileStream.Write(bytes, 0, bytes.Length);
				fileStream.Flush(flushToDisk: true);
			}
			if (File.Exists(P_0))
			{
				File.Replace(text, P_0, null);
			}
			else
			{
				File.Move(text, P_0);
			}
		}
		finally
		{
			if (File.Exists(text))
			{
				File.Delete(text);
			}
		}
	}

	public static string RecoveredMethod357()
	{
		byte[] array = new byte[32];
		using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
		{
			randomNumberGenerator.GetBytes(array);
		}
		return string.Concat(array.Select((byte P_0) => P_0.ToString("x2")));
	}

	public static string RecoveredMethod783(string P_0, string P_1)
	{
		using HMACSHA256 hMACSHA = new HMACSHA256(Encoding.ASCII.GetBytes(P_0));
		return Convert.ToBase64String(hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(P_1)));
	}

	public static bool RecoveredMethod784(string P_0, string P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		int num = P_0.Length ^ P_1.Length;
		for (int i = 0; i < Math.Max(P_0.Length, P_1.Length); i++)
		{
			num |= ((i < P_0.Length) ? P_0[i] : '\0') ^ ((i < P_1.Length) ? P_1[i] : '\0');
		}
		return num == 0;
	}

	public static string RecoveredMethod785(RecoveredType312 P_0)
	{
		return P_0.WorkerId + "|" + P_0.SessionId + "|" + P_0.Name + "|" + P_0.User;
	}

	[CompilerGenerated]
	private static string RecoveredMethod698(byte P_0)
	{
		return P_0.ToString("x2");
	}
}
