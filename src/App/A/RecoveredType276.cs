using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Imaging;
using TwistApp;

namespace a;

internal sealed class RecoveredType276 : IDisposable
{
	private sealed class RecoveredType277
	{
		public ItemMetadata Item;

		public string Key;

		public bool CachedOnly;
	}

	private sealed class RecoveredType278
	{
		public BitmapSource Image;

		public string Error;

		public DateTime At = DateTime.UtcNow;
	}

	[CompilerGenerated]
	private sealed class RecoveredType279
	{
		public RecoveredType276 _003C_003E4__this;

		public string folder;

		public void RecoveredMethod45()
		{
			ItemPreviewRenderer itemPreviewRenderer = new ItemPreviewRenderer(folder);
			foreach (RecoveredType277 item in _003C_003E4__this.jobs.GetConsumingEnumerable())
			{
				_003C_003E4__this.displayReady.WaitOne();
				if (_003C_003E4__this.closed)
				{
					break;
				}
				RecoveredType278 recoveredType = new RecoveredType278();
				try
				{
					recoveredType.Image = (item.CachedOnly ? itemPreviewRenderer.Cached(item.Item) : itemPreviewRenderer.Render(item.Item));
					recoveredType.Error = "";
				}
				catch (Exception ex)
				{
					recoveredType.Error = ex.Message;
				}
				List<Action<BitmapSource, string>> list;
				lock (_003C_003E4__this.gate)
				{
					_003C_003E4__this.done[item.Key] = recoveredType;
					list = _003C_003E4__this.pending[item.Key];
					_003C_003E4__this.pending.Remove(item.Key);
				}
				foreach (Action<BitmapSource, string> item2 in list)
				{
					try
					{
						item2(recoveredType.Image, recoveredType.Error);
					}
					catch
					{
					}
				}
			}
		}
	}

	private readonly ManualResetEvent displayReady = new ManualResetEvent(initialState: true);

	private readonly object gate = new object();

	private readonly BlockingCollection<RecoveredType277> jobs = new BlockingCollection<RecoveredType277>();

	private readonly Thread worker;

	private bool closed;

	private readonly Dictionary<string, List<Action<BitmapSource, string>>> pending = new Dictionary<string, List<Action<BitmapSource, string>>>();

	private readonly Dictionary<string, RecoveredType278> done = new Dictionary<string, RecoveredType278>();

	public void RecoveredMethod72(bool P_0)
	{
		if (P_0)
		{
			displayReady.Reset();
		}
		else
		{
			displayReady.Set();
		}
	}

	public RecoveredType276(string P_0)
	{
		RecoveredType276 recoveredType = this;
		ThreadStart start = delegate
		{
			ItemPreviewRenderer itemPreviewRenderer = new ItemPreviewRenderer(P_0);
			foreach (RecoveredType277 item in recoveredType.jobs.GetConsumingEnumerable())
			{
				recoveredType.displayReady.WaitOne();
				if (recoveredType.closed)
				{
					break;
				}
				RecoveredType278 recoveredType2 = new RecoveredType278();
				try
				{
					recoveredType2.Image = (item.CachedOnly ? itemPreviewRenderer.Cached(item.Item) : itemPreviewRenderer.Render(item.Item));
					recoveredType2.Error = "";
				}
				catch (Exception ex)
				{
					recoveredType2.Error = ex.Message;
				}
				List<Action<BitmapSource, string>> list;
				lock (recoveredType.gate)
				{
					recoveredType.done[item.Key] = recoveredType2;
					list = recoveredType.pending[item.Key];
					recoveredType.pending.Remove(item.Key);
				}
				foreach (Action<BitmapSource, string> item2 in list)
				{
					try
					{
						item2(recoveredType2.Image, recoveredType2.Error);
					}
					catch
					{
					}
				}
			}
		};
		worker = new Thread(start)
		{
			IsBackground = true,
			Priority = ThreadPriority.BelowNormal,
			Name = "twist item previews"
		};
		worker.SetApartmentState(ApartmentState.STA);
		worker.Start();
	}

	public void RecoveredMethod747(ItemMetadata P_0, Action<BitmapSource, string> P_1, bool P_2 = false)
	{
		RecoveredType278 value = null;
		lock (gate)
		{
			if (closed)
			{
				return;
			}
			string text = (P_2 ? "remote|" : "") + P_0.IconKey;
			if (done.TryGetValue(text, out var value2) && value2.Image == null && DateTime.UtcNow - value2.At > TimeSpan.FromSeconds(30.0))
			{
				done.Remove(text);
			}
			if (!done.TryGetValue(text, out value))
			{
				if (pending.TryGetValue(text, out var value3))
				{
					value3.Add(P_1);
					return;
				}
				pending[text] = new List<Action<BitmapSource, string>> { P_1 };
				jobs.Add(new RecoveredType277
				{
					Item = P_0,
					Key = text,
					CachedOnly = P_2
				});
				return;
			}
		}
		P_1(value.Image, value.Error);
	}

	public void RecoveredMethod45()
	{
		lock (gate)
		{
			string[] array = (from P_0 in done
				where P_0.Value.Image == null
				select P_0.Key).ToArray();
			foreach (string key in array)
			{
				done.Remove(key);
			}
		}
	}

	public void RecoveredMethod48(string P_0)
	{
		lock (gate)
		{
			string key = "remote|" + P_0;
			if (done.TryGetValue(key, out var value) && value.Image == null)
			{
				done.Remove(key);
			}
		}
	}

	public void Dispose()
	{
		lock (gate)
		{
			closed = true;
			jobs.CompleteAdding();
			displayReady.Set();
		}
	}

	[CompilerGenerated]
	private static bool RecoveredMethod748(KeyValuePair<string, RecoveredType278> P_0)
	{
		return P_0.Value.Image == null;
	}

	[CompilerGenerated]
	private static string RecoveredMethod749(KeyValuePair<string, RecoveredType278> P_0)
	{
		return P_0.Key;
	}
}
