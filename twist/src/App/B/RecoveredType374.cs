using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Script.Serialization;
using A;
using D;
using TwistApp;
using a;

namespace B;

internal static class RecoveredType374
{
	[CompilerGenerated]
	private sealed class RecoveredType375
	{
		public ManualResetEvent started;

		public ManualResetEvent release;

		public int calls;

		public int latest;

		public void RecoveredMethod82(string P_0, string P_1)
		{
			Interlocked.Increment(ref calls);
			started.Set();
			release.WaitOne();
			latest = new JavaScriptSerializer().Deserialize<CatchRecord[]>(P_1)[0].Count;
		}
	}

	[CompilerGenerated]
	private sealed class RecoveredType376
	{
		public int changes;

		public string error;

		public void RecoveredMethod869(object P_0, PropertyChangedEventArgs P_1)
		{
			changes++;
		}

		public void RecoveredMethod48(string P_0)
		{
			error = P_0;
		}
	}

	private static void RecoveredMethod45()
	{
		ManualResetEvent started = new ManualResetEvent(initialState: false);
		ManualResetEvent release = new ManualResetEvent(initialState: false);
		int calls = 0;
		int latest = 0;
		O<CatchRecord> o = new O<CatchRecord>("unused", delegate(string P_0)
		{
			if (P_0 != "")
			{
				throw new Exception(P_0);
			}
		}, delegate(string P_0, string P_1)
		{
			Interlocked.Increment(ref calls);
			started.Set();
			release.WaitOne();
			latest = new JavaScriptSerializer().Deserialize<CatchRecord[]>(P_1)[0].Count;
		});
		Stopwatch stopwatch = Stopwatch.StartNew();
		o.RecoveredMethod669(new CatchRecord[1]
		{
			new CatchRecord
			{
				Count = 1
			}
		});
		RecoveredMethod42(stopwatch.ElapsedMilliseconds < 100, "slow storage does not block the dispatcher caller");
		RecoveredMethod42(started.WaitOne(5000), "background history save starts");
		for (int num = 2; num <= 100; num++)
		{
			o.RecoveredMethod669(new CatchRecord[1]
			{
				new CatchRecord
				{
					Count = num
				}
			});
		}
		release.Set();
		RecoveredMethod42(o.Completion.Wait(10000) && latest == 100 && calls <= 2, "history saves coalesce and flush the final catch");
		started.Dispose();
		release.Dispose();
	}

	private static void RecoveredMethod42(bool P_0, string P_1)
	{
		if (!P_0)
		{
			throw new Exception("UI performance: " + P_1);
		}
	}

	public static void RecoveredMethod50()
	{
		RecoveredMethod45();
		RecoveredMethod42(RecoveredType373.RecoveredMethod868(true, false, true, "Session") == 1000, "minimized render cadence");
		RecoveredMethod42(RecoveredType373.RecoveredMethod868(false, false, true, "Session") == 250, "visible live session cadence");
		RecoveredMethod42(RecoveredType373.RecoveredMethod868(false, false, true, "Inventory") == 250, "inactive charts do not request live refresh cadence");
		RecoveredMethod42(RecoveredType373.RecoveredMethod868(false, true, true, "Session") == 250, "compact worker status cadence");
		ItemMetadata itemMetadata = new ItemMetadata();
		itemMetadata.Name = "Tigerfin";
		itemMetadata.Category = "Fish";
		itemMetadata.Rarity = "Common";
		ItemMetadata itemMetadata2 = itemMetadata;
		string iconKey = itemMetadata2.IconKey;
		RecoveredMethod42(object.ReferenceEquals(iconKey, itemMetadata2.IconKey), "unchanged preview key reused");
		itemMetadata2.Image = "rbxassetid://123";
		RecoveredMethod42(itemMetadata2.IconKey != iconKey, "image edit invalidates preview key");
		List<VisualPart> parts = itemMetadata2.Parts;
		VisualPart visualPart = new VisualPart
		{
			Mesh = "mesh"
		};
		float[] position = new float[3];
		visualPart.Position = position;
		visualPart.Rotation = new float[9] { 1f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 1f };
		visualPart.Size = new float[3] { 1f, 1f, 1f };
		parts.Add(visualPart);
		string iconKey2 = itemMetadata2.IconKey;
		itemMetadata2.Parts[0].Position[1] = 3f;
		RecoveredMethod42(itemMetadata2.IconKey != iconKey2, "in-place geometry edit invalidates preview key");
		string text = new JavaScriptSerializer().Serialize(itemMetadata2);
		RecoveredMethod42(!text.Contains("IconKey"), "computed hashes are not serialized into metadata packets");
		ItemMetadata itemMetadata3 = new JavaScriptSerializer().Deserialize<ItemMetadata>(text);
		RecoveredMethod42(itemMetadata3.IconKey == itemMetadata2.IconKey, "worker/controller preview keys remain compatible");
		RecoveredType356 recoveredType = new RecoveredType356();
		recoveredType.State = new RecoveredType174
		{
			Account = "Demo",
			UserId = "demo",
			Pid = 1,
			Reeling = true
		};
		recoveredType.Scope = "demo";
		RecoveredType356 recoveredType2 = recoveredType;
		RecoveredType137 recoveredType3 = new RecoveredType137(recoveredType2);
		int changes = 0;
		recoveredType3.PropertyChanged += delegate
		{
			changes++;
		};
		recoveredType3.RecoveredMethod519(1.0);
		recoveredType2.State.Progress = 0.5;
		recoveredType3.RecoveredMethod519(1.01);
		RecoveredMethod42(changes == 0 && recoveredType3.Points.Count == 1, "unchanged account labels and duplicate chart samples avoid notifications");
		recoveredType2.State.Account = "Renamed";
		recoveredType3.RecoveredMethod519(1.1);
		RecoveredMethod42(changes == 1 && recoveredType3.Account == "Renamed" && recoveredType3.Points.Count == 2, "changed account identity and fresh chart sample still update");
		string text2 = Path.Combine(Path.GetTempPath(), "twist-cache-test-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(text2);
		string text3 = Path.Combine(text2, "catalog.json");
		string error = "";
		try
		{
			RecoveredType121 recoveredType4 = new RecoveredType121(text3, delegate(string P_0)
			{
				error = P_0;
			});
			for (int num = 0; num < 100; num++)
			{
				recoveredType4.RecoveredMethod489(new ItemMetadata[1]
				{
					new ItemMetadata
					{
						Name = "Demo " + num
					}
				});
			}
			RecoveredMethod42(recoveredType4.Completion.Wait(10000), "catalog writer drains");
			RecoveredMethod42(error == "" && new JavaScriptSerializer().Deserialize<ItemMetadata[]>(File.ReadAllText(text3))[0].Name == "Demo 99", "coalesced saves retain newest metadata");
		}
		finally
		{
			if (File.Exists(text3))
			{
				File.Delete(text3);
			}
			Directory.Delete(text2);
		}
		Console.WriteLine("PASS: adaptive UI cadence, preview-key reuse/invalidation and wire compatibility, account notification suppression, chart sampling and coalesced cache persistence. No game input.");
	}

	[CompilerGenerated]
	private static void RecoveredMethod48(string P_0)
	{
		if (P_0 != "")
		{
			throw new Exception(P_0);
		}
	}
}
