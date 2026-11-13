using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;

namespace A;

internal static class RecoveredType26
{
	[CompilerGenerated]
	private sealed class RecoveredType27
	{
		public HashSet<string> names;

		public bool RecoveredMethod78(string P_0)
		{
			return !names.Contains(P_0);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType28
	{
		public HashSet<string> names;

		public bool RecoveredMethod78(string P_0)
		{
			return !names.Contains(P_0);
		}
	}

	internal static readonly string[] Required = new string[8] { "twist Launcher.exe", "README.md", "app/twist.exe", "app/Dashboard.xaml", "app/Worker.xaml", "app/twist.ico", "app/offsets.json", "app/data/item-catalog.json" };

	private static string RecoveredMethod60(string P_0)
	{
		return Path.GetFullPath(P_0).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
	}

	internal static bool RecoveredMethod61(string P_0)
	{
		if (string.IsNullOrEmpty(P_0) || P_0.Contains('\\') || P_0.Contains(':') || P_0.Split('/').Any((string text) => text == "" || text == "." || text == "..") || P_0.IndexOfAny(new char[3] { '\0', '\r', '\n' }) >= 0)
		{
			return false;
		}
		if (Regex.IsMatch(P_0, "(?i)(\\.(cs|pdb|map|cmd|bat|csproj|sln|zip)$|mapping|source)"))
		{
			return false;
		}
		if (!Required.Contains(P_0))
		{
			return P_0.StartsWith("app/assets/", StringComparison.Ordinal);
		}
		return true;
	}

	internal static string RecoveredMethod62(string P_0, string P_1)
	{
		if (!RecoveredMethod61(P_1))
		{
			throw new Exception("Unexpected update file.");
		}
		string fullPath = Path.GetFullPath(Path.Combine(P_0, P_1.Replace('/', Path.DirectorySeparatorChar)));
		if (!fullPath.StartsWith(RecoveredMethod60(P_0) + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
		{
			throw new Exception("Update path escaped its folder.");
		}
		return fullPath;
	}

	private static void RecoveredMethod19(string P_0, string P_1)
	{
		string text = Path.GetFullPath(P_1);
		string text2 = RecoveredMethod60(P_0);
		while (text.Length >= text2.Length)
		{
			if ((File.Exists(text) || Directory.Exists(text)) && (File.GetAttributes(text) & FileAttributes.ReparsePoint) != 0)
			{
				throw new Exception("Update folders must not contain links.");
			}
			if (text.Equals(text2, StringComparison.OrdinalIgnoreCase))
			{
				break;
			}
			text = Path.GetDirectoryName(text);
			if (text == null)
			{
				break;
			}
		}
	}

	private static void RecoveredMethod63(string P_0)
	{
		DirectorySecurity directorySecurity = new DirectorySecurity();
		directorySecurity.SetAccessRuleProtection(isProtected: true, preserveInheritance: false);
		using (WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent())
		{
			directorySecurity.SetOwner(windowsIdentity.User);
			directorySecurity.AddAccessRule(new FileSystemAccessRule(windowsIdentity.User, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
		}
		Directory.CreateDirectory(P_0, directorySecurity);
	}

	public static void RecoveredMethod64(string P_0)
	{
		string path = Path.Combine(P_0, "app", "twist.exe");
		if (!File.Exists(path))
		{
			return;
		}
		try
		{
			using (File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
			{
			}
		}
		catch (IOException)
		{
			throw new Exception("Close twist controllers and workers using this folder, then try the update again.");
		}
		catch (UnauthorizedAccessException)
		{
			throw new Exception("This folder is not writable. Open twist from a folder you can update.");
		}
	}

	internal static RecoveredType24[] RecoveredMethod65(string P_0, string P_1, RecoveredType2 P_2, CancellationToken P_3, bool P_4 = true)
	{
		RecoveredType3.RecoveredMethod2(P_2);
		if (new FileInfo(P_0).Length != P_2.Bytes || RecoveredType3.RecoveredMethod5(P_0) != P_2.Sha256)
		{
			throw new Exception("Update package changed before installation.");
		}
		string text = "twist-" + P_2.Version + "/";
		List<RecoveredType24> list = new List<RecoveredType24>();
		HashSet<string> names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		long num = 0L;
		using (ZipArchive zipArchive = ZipFile.OpenRead(P_0))
		{
			if (zipArchive.Entries.Count < Required.Length || zipArchive.Entries.Count > 2000)
			{
				throw new Exception("Invalid update file count.");
			}
			foreach (ZipArchiveEntry entry in zipArchive.Entries)
			{
				P_3.ThrowIfCancellationRequested();
				if (!entry.FullName.StartsWith(text, StringComparison.Ordinal))
				{
					throw new Exception("Invalid update archive root.");
				}
				string text2 = entry.FullName.Substring(text.Length);
				if (!RecoveredMethod61(text2) || !names.Add(text2) || entry.Length < 0 || entry.Length > 134217728 || (num += entry.Length) > 268435456)
				{
					throw new Exception("Invalid update archive contents.");
				}
			}
			if (Required.Any((string item) => !names.Contains(item)))
			{
				throw new Exception("The update is missing required files.");
			}
			Directory.CreateDirectory(P_1);
			foreach (ZipArchiveEntry entry2 in zipArchive.Entries)
			{
				P_3.ThrowIfCancellationRequested();
				string text3 = entry2.FullName.Substring(text.Length);
				string text4 = RecoveredMethod62(P_1, text3);
				RecoveredMethod19(P_1, text4);
				Directory.CreateDirectory(Path.GetDirectoryName(text4));
				long num2 = 0L;
				using (Stream stream = entry2.Open())
				{
					using FileStream fileStream = new FileStream(text4, FileMode.CreateNew, FileAccess.Write, FileShare.None);
					byte[] array = new byte[65536];
					int num3;
					while ((num3 = stream.Read(array, 0, array.Length)) > 0)
					{
						P_3.ThrowIfCancellationRequested();
						if ((num2 += num3) > entry2.Length)
						{
							throw new Exception("Expanded update file exceeded its limit.");
						}
						fileStream.Write(array, 0, num3);
					}
					fileStream.Flush(flushToDisk: true);
				}
				if (num2 != entry2.Length)
				{
					throw new Exception("An update file was truncated.");
				}
				list.Add(new RecoveredType24
				{
					Path = text3,
					Bytes = num2,
					Sha256 = RecoveredType3.RecoveredMethod5(text4)
				});
			}
		}
		if (P_4)
		{
			string[] array2 = new string[2] { "twist Launcher.exe", "app/twist.exe" };
			foreach (string text5 in array2)
			{
				if (AssemblyName.GetAssemblyName(RecoveredMethod62(P_1, text5)).Version != P_2.Number)
				{
					throw new Exception("The update binaries do not match the release version.");
				}
			}
		}
		return list.ToArray();
	}

	public static string RecoveredMethod66(string P_0, string P_1, RecoveredType2 P_2, CancellationToken P_3, bool P_4 = true)
	{
		P_0 = RecoveredMethod60(P_0);
		RecoveredMethod64(P_0);
		RecoveredMethod19(P_0, P_0);
		string text = Path.Combine(P_0, ".twist-update-" + Guid.NewGuid().ToString("N"));
		RecoveredMethod63(text);
		try
		{
			RecoveredType25 recoveredType = new RecoveredType25();
			recoveredType.InstallRoot = P_0;
			recoveredType.StageRoot = text;
			recoveredType.Version = P_2.Version;
			recoveredType.ArchiveHash = P_2.Sha256;
			recoveredType.Files = RecoveredMethod65(P_1, Path.Combine(text, "payload"), P_2, P_3, P_4);
			RecoveredType25 recoveredType2 = recoveredType;
			using (Process process = Process.GetCurrentProcess())
			{
				recoveredType2.ParentPid = process.Id;
				recoveredType2.ParentStarted = process.StartTime.ToUniversalTime().Ticks;
			}
			File.Copy(typeof(RecoveredType26).Assembly.Location, Path.Combine(text, "apply.exe"));
			string text2 = Path.Combine(text, "update.json");
			File.WriteAllText(text2, new JavaScriptSerializer
			{
				MaxJsonLength = 1048576
			}.Serialize(recoveredType2), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
			RecoveredMethod75(recoveredType2);
			return text2;
		}
		catch
		{
			try
			{
				RecoveredMethod74(P_0, text);
			}
			catch
			{
			}
			throw;
		}
	}

	public static ProcessStartInfo RecoveredMethod67(string P_0)
	{
		string directoryName = Path.GetDirectoryName(Path.GetFullPath(P_0));
		if (P_0.Contains('"'))
		{
			throw new Exception("Invalid update path.");
		}
		ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(directoryName, "apply.exe"), "--apply-update \"" + P_0 + "\"");
		processStartInfo.UseShellExecute = true;
		processStartInfo.WorkingDirectory = directoryName;
		processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		return processStartInfo;
	}

	internal static void RecoveredMethod68(RecoveredType25 P_0, string P_1)
	{
		if (P_0 == null || P_0.Files == null || P_0.Files.Length < Required.Length || P_0.Files.Length > 2000)
		{
			throw new Exception("Invalid update plan.");
		}
		RecoveredType3.RecoveredMethod0(P_0.Version);
		string text = RecoveredMethod60(P_0.StageRoot);
		string text2 = RecoveredMethod60(P_0.InstallRoot);
		if (!text.Equals(RecoveredMethod60(P_1), StringComparison.OrdinalIgnoreCase) || !Path.GetDirectoryName(text).Equals(text2, StringComparison.OrdinalIgnoreCase) || !Regex.IsMatch(Path.GetFileName(text), "^\\.twist-update-[0-9a-f]{32}$"))
		{
			throw new Exception("Update plan does not belong to this folder.");
		}
		RecoveredMethod19(text2, text);
		HashSet<string> names = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		long num = 0L;
		RecoveredType24[] files = P_0.Files;
		foreach (RecoveredType24 recoveredType in files)
		{
			if (recoveredType == null || !RecoveredMethod61(recoveredType.Path) || !names.Add(recoveredType.Path) || !Regex.IsMatch(recoveredType.Sha256 ?? "", "^[0-9a-f]{64}$") || recoveredType.Bytes < 0 || (num += recoveredType.Bytes) > 268435456)
			{
				throw new Exception("Invalid planned update file.");
			}
		}
		if (Required.Any((string item) => !names.Contains(item)))
		{
			throw new Exception("Incomplete update plan.");
		}
	}

	private static bool RecoveredMethod69(RecoveredType25 P_0)
	{
		try
		{
			using Process process = Process.GetProcessById(P_0.ParentPid);
			return !process.HasExited && process.StartTime.ToUniversalTime().Ticks == P_0.ParentStarted;
		}
		catch
		{
			return false;
		}
	}

	private static void RecoveredMethod70(string P_0, string P_1)
	{
		string text = P_1 + ".update-" + Guid.NewGuid().ToString("N");
		try
		{
			File.Copy(P_0, text);
			if (File.Exists(P_1))
			{
				File.Replace(text, P_1, null);
			}
			else
			{
				File.Move(text, P_1);
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

	internal static void RecoveredMethod71(RecoveredType25 P_0, Action<int> P_1 = null)
	{
		RecoveredMethod68(P_0, P_0.StageRoot);
		string text = Path.Combine(P_0.InstallRoot, ".twist-update.lock");
		RecoveredMethod19(P_0.InstallRoot, text);
		FileStream fileStream;
		try
		{
			fileStream = new FileStream(text, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
		}
		catch (IOException)
		{
			throw new Exception("Another update is using this folder. Try again when it finishes.");
		}
		using (fileStream)
		{
			try
			{
				File.SetAttributes(text, FileAttributes.Hidden);
			}
			catch
			{
			}
			string text2 = RecoveredMethod62(P_0.InstallRoot, "twist Launcher.exe");
			if (File.Exists(text2))
			{
				try
				{
					if (AssemblyName.GetAssemblyName(text2).Version > RecoveredType3.RecoveredMethod0(P_0.Version))
					{
						throw new Exception("A newer twist version is already installed.");
					}
				}
				catch (BadImageFormatException)
				{
				}
				catch (FileLoadException)
				{
				}
			}
			RecoveredMethod72(P_0, P_1);
		}
	}

	private static void RecoveredMethod72(RecoveredType25 P_0, Action<int> P_1)
	{
		RecoveredMethod68(P_0, P_0.StageRoot);
		string text = Path.Combine(P_0.StageRoot, "payload");
		string text2 = Path.Combine(P_0.StageRoot, "backup");
		List<KeyValuePair<string, bool>> list = new List<KeyValuePair<string, bool>>();
		RecoveredType24[] files = P_0.Files;
		foreach (RecoveredType24 recoveredType in files)
		{
			string text3 = RecoveredMethod62(text, recoveredType.Path);
			RecoveredMethod19(P_0.StageRoot, text3);
			if (!File.Exists(text3) || new FileInfo(text3).Length != recoveredType.Bytes || RecoveredType3.RecoveredMethod5(text3) != recoveredType.Sha256)
			{
				throw new Exception("Staged update changed; installation was cancelled.");
			}
			RecoveredMethod19(P_0.InstallRoot, RecoveredMethod62(P_0.InstallRoot, recoveredType.Path));
		}
		try
		{
			int num = 0;
			RecoveredType24[] files2 = P_0.Files;
			foreach (RecoveredType24 recoveredType2 in files2)
			{
				string text4 = RecoveredMethod62(P_0.InstallRoot, recoveredType2.Path);
				string text5 = RecoveredMethod62(text, recoveredType2.Path);
				string text6 = RecoveredMethod62(text2, recoveredType2.Path);
				bool flag = File.Exists(text4);
				if (!flag || !(RecoveredType3.RecoveredMethod5(text4) == recoveredType2.Sha256))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(text4));
					if (flag)
					{
						Directory.CreateDirectory(Path.GetDirectoryName(text6));
						File.Copy(text4, text6, overwrite: false);
					}
					list.Add(new KeyValuePair<string, bool>(recoveredType2.Path, flag));
					P_1?.Invoke(num);
					num++;
					RecoveredMethod19(P_0.InstallRoot, text4);
					RecoveredMethod70(text5, text4);
				}
			}
			File.WriteAllText(Path.Combine(P_0.StageRoot, "complete"), DateTime.UtcNow.ToString("o"));
		}
		catch
		{
			bool flag2 = true;
			foreach (KeyValuePair<string, bool> item in list.AsEnumerable().Reverse())
			{
				try
				{
					string text7 = RecoveredMethod62(P_0.InstallRoot, item.Key);
					RecoveredMethod19(P_0.InstallRoot, text7);
					if (item.Value)
					{
						RecoveredMethod70(RecoveredMethod62(text2, item.Key), text7);
					}
					else if (File.Exists(text7))
					{
						File.Delete(text7);
					}
				}
				catch
				{
					flag2 = false;
				}
			}
			if (!flag2)
			{
				throw new Exception("Update failed and a file could not be restored. Previous files are in the update backup folder.");
			}
			throw;
		}
	}

	public static void RecoveredMethod73(string P_0)
	{
		string text = RecoveredMethod60(AppDomain.CurrentDomain.BaseDirectory);
		if (!Path.GetFullPath(P_0).Equals(Path.Combine(text, "update.json"), StringComparison.OrdinalIgnoreCase))
		{
			throw new Exception("Invalid updater plan location.");
		}
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		javaScriptSerializer.MaxJsonLength = 1048576;
		RecoveredType25 recoveredType = javaScriptSerializer.Deserialize<RecoveredType25>(File.ReadAllText(P_0));
		RecoveredMethod68(recoveredType, text);
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (RecoveredMethod69(recoveredType))
		{
			if (stopwatch.ElapsedMilliseconds > 15000)
			{
				throw new Exception("The launcher did not close. Close it and try the update again.");
			}
			Thread.Sleep(100);
		}
		stopwatch.Restart();
		while (true)
		{
			try
			{
				RecoveredMethod64(recoveredType.InstallRoot);
			}
			catch
			{
				if (stopwatch.ElapsedMilliseconds > 15000)
				{
					throw;
				}
				Thread.Sleep(250);
				continue;
			}
			break;
		}
		RecoveredMethod71(recoveredType);
		RecoveredMethod75(recoveredType);
		ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(recoveredType.InstallRoot, "twist Launcher.exe"));
		processStartInfo.UseShellExecute = true;
		processStartInfo.WorkingDirectory = recoveredType.InstallRoot;
		Process.Start(processStartInfo);
	}

	internal static void RecoveredMethod74(string P_0, string P_1)
	{
		P_0 = RecoveredMethod60(P_0);
		P_1 = RecoveredMethod60(P_1);
		if (!Path.GetDirectoryName(P_1).Equals(P_0, StringComparison.OrdinalIgnoreCase) || !Regex.IsMatch(Path.GetFileName(P_1), "^\\.twist-update-[0-9a-f]{32}$"))
		{
			throw new Exception("Invalid update cleanup path.");
		}
		RecoveredMethod19(P_0, P_1);
		string path = Path.Combine(P_1, "apply.exe");
		if (File.Exists(path))
		{
			using (File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
			{
			}
		}
		Stack<string> stack = new Stack<string>();
		stack.Push(P_1);
		while (stack.Count > 0)
		{
			string path2 = stack.Pop();
			string[] fileSystemEntries = Directory.GetFileSystemEntries(path2);
			foreach (string text in fileSystemEntries)
			{
				if (!Path.GetFullPath(text).StartsWith(P_1 + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
				{
					throw new Exception("Invalid update cleanup entry.");
				}
				RecoveredMethod19(P_1, text);
				if (Directory.Exists(text))
				{
					stack.Push(text);
				}
			}
		}
		Directory.Delete(P_1, recursive: true);
	}

	internal static bool RecoveredMethod75(RecoveredType25 P_0)
	{
		try
		{
			RecoveredMethod68(P_0, P_0.StageRoot);
			if (!Regex.IsMatch(P_0.ArchiveHash ?? "", "^[0-9a-f]{64}$"))
			{
				return true;
			}
			string text = RecoveredMethod60(P_0.InstallRoot);
			string text2 = Path.Combine(text, "twist-" + P_0.Version + "-public.zip");
			RecoveredMethod19(text, text2);
			if (!File.Exists(text2))
			{
				return true;
			}
			if (RecoveredType3.RecoveredMethod5(text2) != P_0.ArchiveHash)
			{
				return true;
			}
			File.Delete(text2);
			return !File.Exists(text2);
		}
		catch
		{
			return false;
		}
	}

	public static void RecoveredMethod76(string P_0)
	{
		try
		{
			string[] directories = Directory.GetDirectories(P_0, ".twist-update-*");
			foreach (string text in directories)
			{
				if (!File.Exists(Path.Combine(text, "complete")))
				{
					continue;
				}
				try
				{
					string text2 = Path.Combine(text, "update.json");
					if (!File.Exists(text2))
					{
						goto IL_0085;
					}
					if (new FileInfo(text2).Length <= 1048576)
					{
						JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
						javaScriptSerializer.MaxJsonLength = 1048576;
						RecoveredType25 recoveredType = javaScriptSerializer.Deserialize<RecoveredType25>(File.ReadAllText(text2));
						RecoveredMethod68(recoveredType, text);
						if (RecoveredMethod75(recoveredType))
						{
							goto IL_0085;
						}
					}
					goto end_IL_002d;
					IL_0085:
					RecoveredMethod74(P_0, text);
					end_IL_002d:;
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private static bool RecoveredMethod77(string P_0)
	{
		if (!(P_0 == "") && !(P_0 == "."))
		{
			return P_0 == "..";
		}
		return true;
	}
}
