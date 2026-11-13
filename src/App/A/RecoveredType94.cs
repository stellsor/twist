using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using B;
using Microsoft.Win32.SafeHandles;

namespace A;

internal static class RecoveredType94
{
	[DllImport("kernel32.dll", EntryPoint = "GetNamedPipeServerProcessId", SetLastError = true)]
	public static extern bool RecoveredMethod379(SafePipeHandle P_0, out uint P_1);

	public static string RecoveredMethod380(int P_0)
	{
		return "twist.worker.discovery.v1." + P_0;
	}

	public static string RecoveredMethod381(string P_0)
	{
		using SHA256 sHA = SHA256.Create();
		return Convert.ToBase64String(sHA.ComputeHash(Encoding.UTF8.GetBytes(P_0 ?? "")));
	}

	public static byte[] RecoveredMethod382(string P_0)
	{
		using FileStream inputStream = File.OpenRead(P_0);
		using SHA256 sHA = SHA256.Create();
		return sHA.ComputeHash(inputStream);
	}

	private static byte[] RecoveredMethod383(Stream P_0, int P_1)
	{
		byte[] array = new byte[P_1];
		int result;
		for (int i = 0; i < P_1; i += result)
		{
			Task<int> task = P_0.ReadAsync(array, i, P_1 - i);
			if (!task.Wait(1500))
			{
				throw new TimeoutException("Worker discovery timed out.");
			}
			result = task.Result;
			if (result == 0)
			{
				throw new EndOfStreamException();
			}
		}
		return array;
	}

	public static A RecoveredMethod384<A>(Stream P_0)
	{
		int num = BitConverter.ToInt32(RecoveredMethod383(P_0, 4), 0);
		if (num < 2 || num > 4096)
		{
			throw new Exception("Invalid discovery message.");
		}
		return RecoveredType341.RecoveredMethod833<A>(Encoding.UTF8.GetString(RecoveredMethod383(P_0, num)));
	}

	public static void RecoveredMethod385(Stream P_0, object P_1)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(RecoveredType341.RecoveredMethod831().Serialize(P_1));
		if (bytes.Length > 4096)
		{
			throw new Exception("Discovery message is too large.");
		}
		byte[] bytes2 = BitConverter.GetBytes(bytes.Length);
		byte[] array = new byte[4 + bytes.Length];
		Buffer.BlockCopy(bytes2, 0, array, 0, 4);
		Buffer.BlockCopy(bytes, 0, array, 4, bytes.Length);
		Task task = P_0.WriteAsync(array, 0, array.Length);
		if (!task.Wait(1500))
		{
			throw new TimeoutException("Worker discovery timed out.");
		}
		task.GetAwaiter().GetResult();
	}

	public static bool RecoveredMethod386(string P_0, string P_1, bool P_2)
	{
		if (!(P_0 == P_1))
		{
			return P_2;
		}
		return true;
	}

	public static bool RecoveredMethod387()
	{
		using WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent();
		return new WindowsPrincipal(ntIdentity).IsInRole(WindowsBuiltInRole.Administrator);
	}
}
