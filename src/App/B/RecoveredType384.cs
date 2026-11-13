using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using a;

namespace B;

internal sealed class RecoveredType384
{
	private readonly RecoveredType208 memory;

	private readonly RecoveredType285 reader;

	private readonly string version;

	public bool ExactTextBoxLayout => version == "version-5a21b87bbc2641cf";

	public RecoveredType384(RecoveredType208 P_0, RecoveredType285 P_1, string P_2)
	{
		memory = P_0;
		reader = P_1;
		version = P_2;
	}

	private string RecoveredMethod472(ulong P_0)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0))
		{
			return null;
		}
		byte[] array = memory.RecoveredMethod609(P_0, 32);
		if (array == null)
		{
			return null;
		}
		ulong num = BitConverter.ToUInt64(array, 16);
		ulong num2 = BitConverter.ToUInt64(array, 24);
		if (num > 4096 || num2 < 15 || num2 > 1048576 || num2 < num)
		{
			return null;
		}
		byte[] array2;
		if (num2 < 16)
		{
			if (num > 15)
			{
				return null;
			}
			array2 = array;
		}
		else
		{
			ulong num3 = BitConverter.ToUInt64(array, 0);
			if (!RecoveredType285.RecoveredMethod572(num3))
			{
				return null;
			}
			array2 = memory.RecoveredMethod609(num3, (int)num + 1);
			if (array2 == null)
			{
				return null;
			}
		}
		if (array2[(uint)num] != 0)
		{
			return null;
		}
		try
		{
			string text = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true).GetString(array2, 0, (int)num);
			return text.Any((char c) => char.IsControl(c) && c != '\n' && c != '\r' && c != '\t') ? null : text;
		}
		catch
		{
			return null;
		}
	}

	public string RecoveredMethod636(ulong P_0)
	{
		if (!RecoveredType285.RecoveredMethod572(P_0))
		{
			return "";
		}
		string text = reader.RecoveredMethod607(P_0);
		if (text != "TextLabel" && text != "TextButton" && text != "TextBox")
		{
			return "";
		}
		ulong num = (ulong)((text == "TextButton") ? 3616 : ((text == "TextBox") ? 2968 : 2976));
		if (version == "version-5a21b87bbc2641cf")
		{
			return RecoveredMethod472(P_0 + num) ?? "";
		}
		if (version == "version-9ac8595712b447a7")
		{
			string text2 = RecoveredMethod472(P_0 + 3640);
			if (text2 != null)
			{
				return text2;
			}
			return RecoveredMethod472(reader.RecoveredMethod753(P_0 + 3640)) ?? "";
		}
		string text3 = RecoveredMethod472(P_0 + num);
		string text4 = ((text == "TextButton") ? RecoveredMethod472(reader.RecoveredMethod753(P_0 + 3808)) : RecoveredMethod472(P_0 + (ulong)((text == "TextBox") ? 3584 : 3592)));
		if (text3 == null || !(text3 == text4))
		{
			return "";
		}
		return text3;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod530(char P_0)
	{
		if (char.IsControl(P_0) && P_0 != '\n' && P_0 != '\r')
		{
			return P_0 != '\t';
		}
		return false;
	}
}
