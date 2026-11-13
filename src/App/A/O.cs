using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using B;

namespace a;

internal sealed class O<A>
{
	private readonly object gate = new object();

	private readonly string file;

	private readonly Action<string> report;

	private readonly Action<string, string> persist;

	private A[] pending;

	private bool running;

	private Task task = Task.FromResult(0);

	public Task Completion
	{
		get
		{
			lock (gate)
			{
				return task;
			}
		}
	}

	public O(string P_0, Action<string> P_1, Action<string, string> P_2 = null)
	{
		file = P_0;
		report = P_1;
		persist = P_2 ?? new Action<string, string>(RecoveredType351.RecoveredMethod82);
	}

	public void RecoveredMethod669(A[] P_0)
	{
		lock (gate)
		{
			pending = P_0;
			if (!running)
			{
				running = true;
				task = Task.Run((Action)RecoveredMethod45);
			}
		}
	}

	private void RecoveredMethod45()
	{
		while (true)
		{
			A[] array;
			lock (gate)
			{
				array = pending;
				pending = null;
				if (array == null)
				{
					running = false;
					break;
				}
			}
			try
			{
				persist(file, new JavaScriptSerializer
				{
					MaxJsonLength = 16000000
				}.Serialize(array));
				report("");
			}
			catch (Exception ex)
			{
				report(ex.Message);
			}
		}
	}
}
