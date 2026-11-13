using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Web.Script.Serialization;

namespace B;

internal sealed class RecoveredType341 : IDisposable
{
	public const int Limit = 4194304;

	private readonly TcpClient client;

	private readonly NetworkStream stream;

	private readonly object sendGate = new object();

	public RecoveredType341(TcpClient P_0)
	{
		client = P_0;
		P_0.NoDelay = true;
		P_0.ReceiveTimeout = 5000;
		P_0.SendTimeout = 2000;
		stream = P_0.GetStream();
	}

	public static JavaScriptSerializer RecoveredMethod831()
	{
		JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
		javaScriptSerializer.MaxJsonLength = 4194304;
		javaScriptSerializer.RecursionLimit = 128;
		return javaScriptSerializer;
	}

	public void RecoveredMethod807(object P_0)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(RecoveredMethod831().Serialize(P_0));
		if (bytes.Length < 2 || bytes.Length > 4194304)
		{
			throw new Exception("Message exceeds the connection limit.");
		}
		lock (sendGate)
		{
			byte[] bytes2 = BitConverter.GetBytes(bytes.Length);
			stream.Write(bytes2, 0, 4);
			stream.Write(bytes, 0, bytes.Length);
		}
	}

	private byte[] RecoveredMethod832(int P_0)
	{
		byte[] array = new byte[P_0];
		int num;
		for (int i = 0; i < P_0; i += num)
		{
			num = stream.Read(array, i, P_0 - i);
			if (num == 0)
			{
				throw new EndOfStreamException("Connection closed.");
			}
		}
		return array;
	}

	public string RecoveredMethod470()
	{
		int num = BitConverter.ToInt32(RecoveredMethod832(4), 0);
		if (num < 2 || num > 4194304)
		{
			throw new Exception("Invalid message length.");
		}
		return Encoding.UTF8.GetString(RecoveredMethod832(num));
	}

	public static string RecoveredMethod381(string P_0)
	{
		if (!(RecoveredMethod831().DeserializeObject(P_0) is Dictionary<string, object> dictionary) || !dictionary.TryGetValue("Type", out var value))
		{
			return "";
		}
		return Convert.ToString(value);
	}

	public static A RecoveredMethod833<A>(string P_0)
	{
		return RecoveredMethod831().Deserialize<A>(P_0);
	}

	public void Dispose()
	{
		try
		{
			client.Close();
		}
		catch
		{
		}
	}
}
