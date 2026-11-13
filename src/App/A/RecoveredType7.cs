using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace A;

internal static class RecoveredType7
{
	[CompilerGenerated]
	private sealed class RecoveredType8
	{
		public Func<RecoveredType2, Task> start;

		public async Task<string> RecoveredMethod41(RecoveredType2 P_0)
		{
			int num = default(int);
			_ = num;
			_ = 0;
			try
			{
				await start(P_0);
				return null;
			}
			catch (Exception ex)
			{
				return P_0.State.Account + ": " + ex.Message;
			}
		}
	}

	public static async Task<RecoveredType6> RecoveredMethod38(RecoveredType2[] P_0, Func<RecoveredType2, Task> P_1)
	{
		Task<string>[] tasks = P_0.Select(async delegate(RecoveredType2 recoveredType)
		{
			int num = default(int);
			_ = num;
			_ = 0;
			try
			{
				await P_1(recoveredType);
				return (string)null;
			}
			catch (Exception ex)
			{
				return recoveredType.State.Account + ": " + ex.Message;
			}
		}).ToArray();
		string[] failures = await Task.WhenAll(tasks);
		return new RecoveredType6
		{
			Started = failures.Count((string text) => text == null),
			Failures = failures.Where((string text) => text != null).ToArray()
		};
	}

	[CompilerGenerated]
	private static bool RecoveredMethod39(string P_0)
	{
		return P_0 == null;
	}

	[CompilerGenerated]
	private static bool RecoveredMethod40(string P_0)
	{
		return P_0 != null;
	}
}
