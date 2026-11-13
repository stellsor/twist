using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace A;

internal static class RecoveredType12
{
	public static ProcessStartInfo RecoveredMethod32(string P_0, RecoveredType11 P_1, bool P_2, bool P_3)
	{
		string fullPath = Path.GetFullPath(Path.Combine(P_0, "app"));
		string text = Path.Combine(fullPath, "twist.exe");
		if (!File.Exists(text))
		{
			throw new FileNotFoundException("The app folder is missing twist.exe. Keep it beside the launcher.", text);
		}
		if (P_1 != RecoveredType11.Worker && P_1 != RecoveredType11.Controller && P_1 != RecoveredType11.Local)
		{
			throw new ArgumentException("Choose a mode.");
		}
		ProcessStartInfo processStartInfo = new ProcessStartInfo(text);
		processStartInfo.Arguments = P_1 switch
		{
			RecoveredType11.Local => "--local ", 
			RecoveredType11.Worker => "--worker ", 
			_ => "", 
		} + "--offsets-checked";
		processStartInfo.WorkingDirectory = fullPath;
		processStartInfo.UseShellExecute = true;
		processStartInfo.Verb = ((P_1 == RecoveredType11.Controller && P_2 && !P_3) ? "runas" : "");
		return processStartInfo;
	}

	public static RecoveredType11 RecoveredMethod33(string P_0)
	{
		try
		{
			if (Enum.TryParse<RecoveredType11>(File.ReadAllText(P_0).Trim(), out var result) && Enum.IsDefined(typeof(RecoveredType11), result))
			{
				return result;
			}
		}
		catch
		{
		}
		return RecoveredType11.Worker;
	}

	public static bool RecoveredMethod34(string P_0, RecoveredType11 P_1, bool P_2, bool P_3, string P_4, Action<ProcessStartInfo> P_5, out string P_6)
	{
		try
		{
			ProcessStartInfo obj = RecoveredMethod32(P_0, P_1, P_2, P_3);
			P_5(obj);
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(P_4));
				File.WriteAllText(P_4, P_1.ToString());
			}
			catch
			{
			}
			P_6 = "";
			return true;
		}
		catch (Win32Exception ex)
		{
			P_6 = ((ex.NativeErrorCode == 1223) ? "Opening was cancelled. Choose a mode to try again." : ex.Message);
			return false;
		}
		catch (Exception ex2)
		{
			P_6 = ex2.Message;
			return false;
		}
	}
}
