using System;
using System.IO;
using System.Text;

namespace B;

internal static class RecoveredType351
{
	public static void RecoveredMethod82(string P_0, string P_1)
	{
		Directory.CreateDirectory(Path.GetDirectoryName(P_0));
		string text = P_0 + ".tmp-" + Guid.NewGuid().ToString("N");
		try
		{
			byte[] bytes = Encoding.UTF8.GetBytes(P_1);
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
}
