using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace A;

internal static class RecoveredType6
{
	[CompilerGenerated]
	private sealed class RecoveredType7
	{
		public RecoveredType25 plan;

		public string failedRoot;

		public string failedZip;

		public string cancelledRoot;

		public string cancelledZip;

		public CancellationTokenSource cancel;

		public bool RecoveredMethod25(RecoveredType24 P_0)
		{
			return File.Exists(RecoveredType26.RecoveredMethod62(Path.Combine(plan.StageRoot, "payload"), P_0.Path));
		}

		public void RecoveredMethod11()
		{
			RecoveredType26.RecoveredMethod66(failedRoot, failedZip, RecoveredMethod17(failedZip, "99.1.2"), CancellationToken.None, false);
		}

		public void RecoveredMethod20()
		{
			RecoveredType26.RecoveredMethod66(cancelledRoot, cancelledZip, RecoveredMethod17(cancelledZip, "99.1.2"), cancel.Token, false);
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType8
	{
		public string temp;
	}

	[CompilerGenerated]
	private sealed class RecoveredType9
	{
		public RecoveredType8 CS_0024_003C_003E8__locals23;

		public byte[] content;

		public RecoveredType2 download;

		public CancellationTokenSource cancel;

		public string install;

		public RecoveredType25 plan;

		public string rollbackRoot;

		public RecoveredType25 rollback;

		public RecoveredType25 changed;

		public RecoveredType25 locked;

		public RecoveredType25 downgrade;

		private static Action<int> CS_0024_003C_003E9__CachedAnonymousMethodDelegate29;

		public void RecoveredMethod11()
		{
			RecoveredType3.RecoveredMethod6(new MemoryStream(new byte[1] { 1 }), Path.Combine(CS_0024_003C_003E8__locals23.temp, "truncated"), download, CancellationToken.None, null);
		}

		public void RecoveredMethod20()
		{
			RecoveredType3.RecoveredMethod6(new MemoryStream(new byte[content.Length + 1]), Path.Combine(CS_0024_003C_003E8__locals23.temp, "large"), download, CancellationToken.None, null);
		}

		public void RecoveredMethod21()
		{
			RecoveredType3.RecoveredMethod6(new MemoryStream(new byte[content.Length]), Path.Combine(CS_0024_003C_003E8__locals23.temp, "wrong-hash"), download, CancellationToken.None, null);
		}

		public void RecoveredMethod22()
		{
			RecoveredType3.RecoveredMethod6(new MemoryStream(content), Path.Combine(CS_0024_003C_003E8__locals23.temp, "cancel"), download, cancel.Token, null);
		}

		public bool RecoveredMethod25(RecoveredType24 P_0)
		{
			return RecoveredType3.RecoveredMethod5(RecoveredType26.RecoveredMethod62(install, P_0.Path)) == P_0.Sha256;
		}

		public void RecoveredMethod23()
		{
			RecoveredType26.RecoveredMethod71(rollback, delegate(int P_0)
			{
				if (P_0 == 2)
				{
					throw new IOException("Simulated file lock");
				}
			});
		}

		public bool RecoveredMethod26(RecoveredType24 P_0)
		{
			return File.ReadAllText(RecoveredType26.RecoveredMethod62(rollbackRoot, P_0.Path)) == "previous " + P_0.Path;
		}

		public void RecoveredMethod24()
		{
			RecoveredType26.RecoveredMethod71(changed);
		}

		public void RecoveredMethod27()
		{
			RecoveredType26.RecoveredMethod68(plan, CS_0024_003C_003E8__locals23.temp);
		}

		public void RecoveredMethod28()
		{
			RecoveredType26.RecoveredMethod74(install, CS_0024_003C_003E8__locals23.temp);
		}

		public void RecoveredMethod29()
		{
			RecoveredType26.RecoveredMethod71(locked);
		}

		public void RecoveredMethod30()
		{
			RecoveredType26.RecoveredMethod71(downgrade);
		}

		private static void RecoveredMethod31(int P_0)
		{
			if (P_0 == 2)
			{
				throw new IOException("Simulated file lock");
			}
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType10
	{
		public RecoveredType9 CS_0024_003C_003E8__locals26;

		public RecoveredType8 CS_0024_003C_003E8__locals23;

		public string unsafeZip;

		public void RecoveredMethod11()
		{
			RecoveredType26.RecoveredMethod65(unsafeZip, Path.Combine(CS_0024_003C_003E8__locals23.temp, Guid.NewGuid().ToString("N")), RecoveredMethod17(unsafeZip, "99.1.2"), CancellationToken.None, false);
		}
	}

	private static void RecoveredMethod12(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("App update test: " + P_1);
		}
	}

	private static void RecoveredMethod13(Action P_0, string P_1)
	{
		bool flag = false;
		try
		{
			P_0();
		}
		catch
		{
			flag = true;
		}
		RecoveredMethod12(flag, P_1);
	}

	private static string RecoveredMethod14(byte[] P_0)
	{
		using SHA256 sHA = SHA256.Create();
		return string.Concat(from b in sHA.ComputeHash(P_0)
			select b.ToString("x2"));
	}

	private static string RecoveredMethod15(string P_0, string P_1 = null, string P_2 = null, long P_3 = 4L)
	{
		return new JavaScriptSerializer().Serialize(new H<string, bool, bool, g<string, long, string, string>[]>("v" + P_0, false, false, new g<string, long, string, string>[1]
		{
			new g<string, long, string, string>("twist-" + P_0 + "-public.zip", P_3, P_2 ?? ("sha256:" + new string('a', 64)), P_1 ?? ("https://github.com/Stellsor/twist/releases/download/v" + P_0 + "/twist-" + P_0 + "-public.zip"))
		}));
	}

	internal static string RecoveredMethod16(string P_0, string P_1, string P_2 = null)
	{
		string text = Path.Combine(P_0, Guid.NewGuid().ToString("N") + ".zip");
		using FileStream stream = File.Create(text);
		using ZipArchive zipArchive = new ZipArchive(stream, ZipArchiveMode.Create);
		foreach (string item in RecoveredType26.Required.Concat((P_2 == null) ? new string[0] : new string[1] { P_2 }))
		{
			ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntry("twist-" + P_1 + "/" + item);
			using Stream stream2 = zipArchiveEntry.Open();
			byte[] bytes = Encoding.UTF8.GetBytes("new " + item);
			stream2.Write(bytes, 0, bytes.Length);
		}
		return text;
	}

	internal static RecoveredType2 RecoveredMethod17(string P_0, string P_1)
	{
		RecoveredType2 recoveredType = new RecoveredType2();
		recoveredType.Version = P_1;
		recoveredType.DownloadUrl = "https://github.com/Stellsor/twist/releases/download/v" + P_1 + "/twist-" + P_1 + "-public.zip";
		recoveredType.Bytes = new FileInfo(P_0).Length;
		recoveredType.Sha256 = RecoveredType3.RecoveredMethod5(P_0);
		return recoveredType;
	}

	internal static RecoveredType25 RecoveredMethod18(string P_0, string P_1, string P_2)
	{
		string text = Path.Combine(P_0, ".twist-update-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text);
		RecoveredType25 recoveredType = new RecoveredType25();
		recoveredType.InstallRoot = P_0;
		recoveredType.StageRoot = text;
		recoveredType.Version = P_2;
		recoveredType.ParentPid = 1;
		recoveredType.ParentStarted = 1L;
		recoveredType.ArchiveHash = RecoveredType3.RecoveredMethod5(P_1);
		recoveredType.Files = RecoveredType26.RecoveredMethod65(P_1, Path.Combine(text, "payload"), RecoveredMethod17(P_1, P_2), CancellationToken.None, false);
		return recoveredType;
	}

	private static void RecoveredMethod19(string P_0, string P_1)
	{
		string text = Path.Combine(P_0, "archive cleanup");
		Directory.CreateDirectory(text);
		string text2 = Path.Combine(text, "twist-99.1.2-public.zip");
		File.Copy(P_1, text2);
		string path = RecoveredType26.RecoveredMethod66(text, text2, RecoveredMethod17(text2, "99.1.2"), CancellationToken.None, false);
		RecoveredType25 plan = new JavaScriptSerializer().Deserialize<RecoveredType25>(File.ReadAllText(path));
		RecoveredMethod12(!File.Exists(text2) && plan.Files.All((RecoveredType24 recoveredType) => File.Exists(RecoveredType26.RecoveredMethod62(Path.Combine(plan.StageRoot, "payload"), recoveredType.Path))), "Verified extraction removes only its downloaded ZIP while retaining the staged files");
		string text3 = Path.Combine(text, "other-download.zip");
		File.Copy(P_1, text3);
		File.Copy(P_1, text2);
		RecoveredType26.RecoveredMethod71(plan);
		using (new FileStream(text2, FileMode.Open, FileAccess.Read, FileShare.None))
		{
			RecoveredType26.RecoveredMethod76(text);
			RecoveredMethod12(File.Exists(text2) && Directory.Exists(plan.StageRoot), "Locked ZIP cleanup is deferred without discarding its completed stage");
		}
		RecoveredType26.RecoveredMethod76(text);
		RecoveredMethod12(!File.Exists(text2) && !Directory.Exists(plan.StageRoot) && File.Exists(text3) && File.Exists(P_1), "Next startup removes a verified leftover ZIP and preserves unrelated and external archives");
		string failedRoot = Path.Combine(P_0, "failed extraction");
		Directory.CreateDirectory(failedRoot);
		string sourceFileName = RecoveredMethod16(P_0, "99.1.2", "app/source.cs");
		string failedZip = Path.Combine(failedRoot, "twist-99.1.2-public.zip");
		File.Copy(sourceFileName, failedZip);
		RecoveredMethod13(delegate
		{
			RecoveredType26.RecoveredMethod66(failedRoot, failedZip, RecoveredMethod17(failedZip, "99.1.2"), CancellationToken.None, false);
		}, "Failed extraction is rejected");
		RecoveredMethod12(File.Exists(failedZip), "Failed extraction keeps the download");
		string cancelledRoot = Path.Combine(P_0, "cancelled extraction");
		Directory.CreateDirectory(cancelledRoot);
		string cancelledZip = Path.Combine(cancelledRoot, "twist-99.1.2-public.zip");
		File.Copy(P_1, cancelledZip);
		CancellationTokenSource cancel = new CancellationTokenSource();
		cancel.Cancel();
		RecoveredMethod13(delegate
		{
			RecoveredType26.RecoveredMethod66(cancelledRoot, cancelledZip, RecoveredMethod17(cancelledZip, "99.1.2"), cancel.Token, false);
		}, "Cancelled extraction stops preparation");
		RecoveredMethod12(File.Exists(cancelledZip), "Cancelled extraction keeps the download");
		string text4 = Path.Combine(P_0, "different archive");
		Directory.CreateDirectory(text4);
		string path2 = Path.Combine(text4, "twist-99.1.2-public.zip");
		File.WriteAllText(path2, "unrelated replacement");
		RecoveredType26.RecoveredMethod66(text4, P_1, RecoveredMethod17(P_1, "99.1.2"), CancellationToken.None, false);
		RecoveredMethod12(File.ReadAllText(path2) == "unrelated replacement" && File.Exists(P_1), "Matching filename with different bytes and external input ZIP are preserved");
	}

	public static void RecoveredMethod11()
	{
		string temp = Path.Combine(Path.GetTempPath(), "twist-update-tests-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(temp);
		try
		{
			RecoveredType2 recoveredType = RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", null, null, 4L));
			RecoveredMethod12(recoveredType.Number > RecoveredType3.Installed && recoveredType.Bytes == 4, "Stable release version and checksum parsed");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", "https://evil.example/update.zip", null, 4L));
			}, "Foreign update URL rejected");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", null, "sha256:missing", 4L));
			}, "Missing digest rejected");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", null, null, 67108865L));
			}, "Oversized package rejected");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod1(RecoveredMethod15("../bad", null, null, 4L));
			}, "Invalid version rejected");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", null, null, 4L).Replace("\"draft\":false", "\"draft\":true"));
			}, "Draft release rejected");
			RecoveredMethod12(RecoveredType3.RecoveredMethod7(new Uri("https://release-assets.githubusercontent.com/path?signature=abc")) && !RecoveredType3.RecoveredMethod7(new Uri("http://github.com/asset")) && !RecoveredType3.RecoveredMethod7(new Uri("https://github.com.evil.example/asset")), "Only HTTPS GitHub asset redirects accepted");
			byte[] content = Encoding.UTF8.GetBytes("verified update");
			RecoveredType2 download = new RecoveredType2
			{
				Bytes = content.Length,
				Sha256 = RecoveredMethod14(content)
			};
			string text = Path.Combine(temp, "download");
			RecoveredType3.RecoveredMethod6(new MemoryStream(content), text, download, CancellationToken.None, null);
			RecoveredMethod12(File.ReadAllBytes(text).SequenceEqual(content), "Exact downloaded bytes retained");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod6(new MemoryStream(new byte[1] { 1 }), Path.Combine(temp, "truncated"), download, CancellationToken.None, null);
			}, "Truncated download rejected");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod6(new MemoryStream(new byte[content.Length + 1]), Path.Combine(temp, "large"), download, CancellationToken.None, null);
			}, "Unexpected extra bytes rejected");
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod6(new MemoryStream(new byte[content.Length]), Path.Combine(temp, "wrong-hash"), download, CancellationToken.None, null);
			}, "Wrong digest rejected");
			CancellationTokenSource cancel = new CancellationTokenSource();
			cancel.Cancel();
			RecoveredMethod13(delegate
			{
				RecoveredType3.RecoveredMethod6(new MemoryStream(content), Path.Combine(temp, "cancel"), download, cancel.Token, null);
			}, "Cancellation prevents verified download");
			string[] array = new string[8] { "../outside", "app/../../outside", "app\\outside", "/outside", "app/C:/outside", "THIRD-PARTY-NOTICES.txt", "app/source.cs", "app/profiles/settings.json" };
			foreach (string text2 in array)
			{
				RecoveredMethod12(!RecoveredType26.RecoveredMethod61(text2), "Unexpected path rejected: " + text2);
			}
			string[] array2 = new string[4] { "../outside.txt", "app/../../outside.txt", "THIRD-PARTY-NOTICES.txt", "app/source.cs" };
			foreach (string text3 in array2)
			{
				string unsafeZip = RecoveredMethod16(temp, "99.1.2", text3);
				RecoveredMethod13(delegate
				{
					RecoveredType26.RecoveredMethod65(unsafeZip, Path.Combine(temp, Guid.NewGuid().ToString("N")), RecoveredMethod17(unsafeZip, "99.1.2"), CancellationToken.None, false);
				}, "Unsafe ZIP rejected before extracting: " + text3);
			}
			string text4 = RecoveredMethod16(temp, "99.1.2");
			string install = Path.Combine(temp, "install with spaces");
			RecoveredMethod19(temp, text4);
			Directory.CreateDirectory(install);
			RecoveredType25 plan = RecoveredMethod18(install, text4, "99.1.2");
			RecoveredType24[] files = plan.Files;
			foreach (RecoveredType24 recoveredType2 in files)
			{
				string path = RecoveredType26.RecoveredMethod62(install, recoveredType2.Path);
				Directory.CreateDirectory(Path.GetDirectoryName(path));
				File.WriteAllText(path, "old " + recoveredType2.Path);
			}
			string path2 = Path.Combine(install, "personal-note.txt");
			File.WriteAllText(path2, "keep");
			RecoveredType26.RecoveredMethod71(plan);
			RecoveredMethod12(plan.Files.All((RecoveredType24 P_0) => RecoveredType3.RecoveredMethod5(RecoveredType26.RecoveredMethod62(install, P_0.Path)) == P_0.Sha256) && File.ReadAllText(path2) == "keep", "In-place replacement preserves unrelated files");
			RecoveredMethod12(File.Exists(Path.Combine(plan.StageRoot, "complete")), "Successful update recorded for cleanup");
			string rollbackRoot = Path.Combine(temp, "rollback");
			Directory.CreateDirectory(rollbackRoot);
			RecoveredType25 rollback = RecoveredMethod18(rollbackRoot, text4, "99.1.2");
			RecoveredType24[] files2 = rollback.Files;
			foreach (RecoveredType24 recoveredType3 in files2)
			{
				string path3 = RecoveredType26.RecoveredMethod62(rollbackRoot, recoveredType3.Path);
				Directory.CreateDirectory(Path.GetDirectoryName(path3));
				File.WriteAllText(path3, "previous " + recoveredType3.Path);
			}
			RecoveredMethod13(delegate
			{
				RecoveredType26.RecoveredMethod71(rollback, delegate(int P_0)
				{
					if (P_0 == 2)
					{
						throw new IOException("Simulated file lock");
					}
				});
			}, "Installation failure reported");
			RecoveredMethod12(rollback.Files.All((RecoveredType24 P_0) => File.ReadAllText(RecoveredType26.RecoveredMethod62(rollbackRoot, P_0.Path)) == "previous " + P_0.Path), "All replaced files restored after partial failure");
			string text5 = Path.Combine(temp, "changed");
			Directory.CreateDirectory(text5);
			RecoveredType25 changed = RecoveredMethod18(text5, text4, "99.1.2");
			File.AppendAllText(RecoveredType26.RecoveredMethod62(Path.Combine(changed.StageRoot, "payload"), changed.Files[0].Path), "tampered");
			RecoveredMethod13(delegate
			{
				RecoveredType26.RecoveredMethod71(changed);
			}, "Changed staged bytes rejected");
			RecoveredMethod12(!File.Exists(Path.Combine(text5, "twist Launcher.exe")), "Failed validation writes no installed files");
			RecoveredMethod13(delegate
			{
				RecoveredType26.RecoveredMethod68(plan, temp);
			}, "Foreign helper location rejected");
			RecoveredMethod13(delegate
			{
				RecoveredType26.RecoveredMethod74(install, temp);
			}, "Cleanup cannot escape the installation folder");
			ProcessStartInfo processStartInfo = RecoveredType26.RecoveredMethod67(Path.Combine(plan.StageRoot, "update.json"));
			RecoveredMethod12(processStartInfo.FileName == Path.Combine(plan.StageRoot, "apply.exe") && processStartInfo.Arguments.Contains("--apply-update") && processStartInfo.WindowStyle == ProcessWindowStyle.Hidden, "Helper handoff uses its private stage and quoted plan");
			string text6 = Path.Combine(temp, "locked");
			Directory.CreateDirectory(text6);
			RecoveredType25 locked = RecoveredMethod18(text6, text4, "99.1.2");
			using (new FileStream(Path.Combine(text6, ".twist-update.lock"), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
			{
				RecoveredMethod13(delegate
				{
					RecoveredType26.RecoveredMethod71(locked);
				}, "Concurrent installer cannot replace files");
			}
			string text7 = Path.Combine(temp, "newer");
			Directory.CreateDirectory(text7);
			RecoveredType25 downgrade = RecoveredMethod18(text7, text4, "99.1.2");
			File.Copy(typeof(RecoveredType6).Assembly.Location, Path.Combine(text7, "twist Launcher.exe"));
			downgrade.Version = "0.0.1";
			RecoveredMethod13(delegate
			{
				RecoveredType26.RecoveredMethod71(downgrade);
			}, "Newer installed launcher cannot be downgraded");
			Console.WriteLine("PASS: release/checksum/origin validation, bounded downloads and cancellation, ZIP traversal/source/notice rejection, staged integrity, in-place install, rollback, verified ZIP removal, failed/cancelled extraction retention, locked ZIP retry, unrelated-file preservation and constrained helper cleanup. No real installation, app launch or game input.");
		}
		finally
		{
			string fullPath = Path.GetFullPath(temp);
			if (!fullPath.StartsWith(Path.GetFullPath(Path.GetTempPath()), StringComparison.OrdinalIgnoreCase) || !Path.GetFileName(fullPath).StartsWith("twist-update-tests-", StringComparison.Ordinal))
			{
				throw new Exception("Invalid test cleanup path.");
			}
			Directory.Delete(fullPath, recursive: true);
		}
	}

	[CompilerGenerated]
	private static string RecoveredMethod9(byte P_0)
	{
		return P_0.ToString("x2");
	}

	[CompilerGenerated]
	private static void RecoveredMethod20()
	{
		RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", "https://evil.example/update.zip", null, 4L));
	}

	[CompilerGenerated]
	private static void RecoveredMethod21()
	{
		RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", null, "sha256:missing", 4L));
	}

	[CompilerGenerated]
	private static void RecoveredMethod22()
	{
		RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", null, null, 67108865L));
	}

	[CompilerGenerated]
	private static void RecoveredMethod23()
	{
		RecoveredType3.RecoveredMethod1(RecoveredMethod15("../bad", null, null, 4L));
	}

	[CompilerGenerated]
	private static void RecoveredMethod24()
	{
		RecoveredType3.RecoveredMethod1(RecoveredMethod15("99.1.2", null, null, 4L).Replace("\"draft\":false", "\"draft\":true"));
	}
}
