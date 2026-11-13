using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using TwistApp;
using a;
using c;

namespace A;

internal static class RecoveredType135
{
	[CompilerGenerated]
	private sealed class RecoveredType136
	{
		public string folder;

		public bool RecoveredMethod39(string P_0)
		{
			if (P_0 != "" && !File.Exists(Path.Combine(folder, P_0 + ".asset")))
			{
				return !File.Exists(Path.Combine(folder, P_0 + ".clientmesh"));
			}
			return false;
		}
	}

	private static byte[] RecoveredMethod516(RecoveredType282 P_0, ulong P_1, int P_2)
	{
		if (!RecoveredType285.RecoveredMethod572(P_1) || P_2 < 1 || P_2 > 16000000)
		{
			return null;
		}
		byte[] array = new byte[P_2];
		for (int i = 0; i < P_2; i += 65536)
		{
			int num = Math.Min(65536, P_2 - i);
			byte[] array2 = P_0.RecoveredMethod609(P_1 + (ulong)i, num);
			if (array2 == null)
			{
				return null;
			}
			Buffer.BlockCopy(array2, 0, array, i, num);
		}
		return array;
	}

	public static bool RecoveredMethod517(byte[] P_0, byte[] P_1)
	{
		if (P_0 == null || P_1 == null || P_0.Length == 0 || P_0.Length % 40 != 0 || P_1.Length == 0 || P_1.Length % 12 != 0)
		{
			return false;
		}
		int num = P_0.Length / 40;
		if (num > 250000 || P_1.Length / 12 > 500000)
		{
			return false;
		}
		for (int i = 0; i < P_0.Length; i += 40)
		{
			for (int j = 0; j < 8; j++)
			{
				float num2 = BitConverter.ToSingle(P_0, i + j * 4);
				if (float.IsNaN(num2) || float.IsInfinity(num2) || Math.Abs(num2) > 1000000f)
				{
					return false;
				}
				if (j >= 3 && j < 6 && (double)Math.Abs(num2) > 1.01)
				{
					return false;
				}
			}
		}
		for (int k = 0; k < P_1.Length; k += 4)
		{
			if (BitConverter.ToUInt32(P_1, k) >= num)
			{
				return false;
			}
		}
		return true;
	}

	public static void RecoveredMethod518(RecoveredType282 P_0, RecoveredType285 P_1, ulong P_2, IEnumerable<string> P_3, string P_4)
	{
		HashSet<string> hashSet = new HashSet<string>(from text4 in P_3.Select(AssetFiles.RecoveredMethod741)
			where text4 != "" && !File.Exists(Path.Combine(P_4, text4 + ".asset")) && !File.Exists(Path.Combine(P_4, text4 + ".clientmesh"))
			select text4);
		if (hashSet.Count == 0)
		{
			return;
		}
		ulong num = P_1.RecoveredMethod756(P_2, "MeshContentProvider");
		ulong num2 = P_1.RecoveredMethod753(num + 192);
		ulong num3 = P_1.RecoveredMethod753(num2 + 32);
		ulong num4 = P_1.RecoveredMethod753(num3 + 8);
		ulong num5 = num4;
		HashSet<ulong> hashSet2 = new HashSet<ulong>();
		for (int num6 = 0; num6 < 10000; num6++)
		{
			if (!RecoveredType285.RecoveredMethod572(num5))
			{
				break;
			}
			if (!hashSet2.Add(num5))
			{
				break;
			}
			if (hashSet.Count <= 0)
			{
				break;
			}
			string text = P_1.RecoveredMethod475(num5 + 16);
			Match match = Regex.Match(text ?? "", "[?&]id=([0-9]{1,19})(?:&|$)");
			if (match.Success && hashSet.Contains(match.Groups[1].Value))
			{
				string value = match.Groups[1].Value;
				ulong num7 = P_1.RecoveredMethod753(num5 + 64);
				ulong num8 = P_1.RecoveredMethod753(num7 + 64);
				ulong num9 = P_1.RecoveredMethod753(num8);
				ulong num10 = P_1.RecoveredMethod753(num8 + 8);
				ulong num11 = P_1.RecoveredMethod753(num8 + 48);
				ulong num12 = P_1.RecoveredMethod753(num8 + 56);
				if (num10 > num9 && num12 > num11 && num10 - num9 <= 10000000 && num12 - num11 <= 6000000)
				{
					byte[] array = RecoveredMethod516(P_0, num9, (int)(num10 - num9));
					byte[] array2 = RecoveredMethod516(P_0, num11, (int)(num12 - num11));
					if (RecoveredMethod517(array, array2))
					{
						Directory.CreateDirectory(P_4);
						string text2 = Path.Combine(P_4, value + ".clientmesh");
						string text3 = text2 + ".tmp";
						try
						{
							using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(text3)))
							{
								binaryWriter.Write(Encoding.ASCII.GetBytes("twistmesh1"));
								binaryWriter.Write(array.Length / 40);
								binaryWriter.Write(array2.Length / 12);
								binaryWriter.Write(array);
								binaryWriter.Write(array2);
							}
							if (!File.Exists(text2))
							{
								File.Move(text3, text2);
							}
							else
							{
								File.Delete(text3);
							}
							hashSet.Remove(value);
						}
						catch
						{
							try
							{
								File.Delete(text3);
							}
							catch
							{
							}
						}
					}
				}
			}
			num5 = P_1.RecoveredMethod753(num5);
		}
	}
}
