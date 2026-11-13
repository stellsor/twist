using System;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using B;
using TwistApp;

namespace A;

internal sealed class RecoveredType121
{
	private readonly object gate = new object();

	private readonly string path;

	private readonly Action<string> error;

	private ItemMetadata[] pending;

	private Task task = Task.FromResult(0);

	private bool running;

	private string saved = "";

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

	public RecoveredType121(string P_0, Action<string> P_1)
	{
		path = P_0;
		error = P_1;
	}

	public void RecoveredMethod489(ItemMetadata[] P_0)
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
			ItemMetadata[] array;
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
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				javaScriptSerializer.MaxJsonLength = 8000000;
				string text = javaScriptSerializer.Serialize(array);
				if (text != saved)
				{
					RecoveredType351.RecoveredMethod82(path, text);
					saved = text;
				}
			}
			catch (Exception ex)
			{
				if (error != null)
				{
					error(ex.Message);
				}
			}
		}
	}
}
