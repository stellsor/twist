using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using B;

namespace A;

internal static class RecoveredType97
{
	public static string RecoveredMethod388(int P_0, int P_1, string P_2, string P_3 = null)
	{
		using NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(".", P_3 ?? RecoveredType94.RecoveredMethod380(P_1), PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.Identification);
		namedPipeClientStream.Connect(300);
		if (!RecoveredType94.RecoveredMethod379(namedPipeClientStream.SafePipeHandle, out var num) || num != (uint)P_0)
		{
			throw new Exception("Worker process identity changed.");
		}
		using (Process process = Process.GetProcessById(P_0))
		{
			using Process process2 = Process.GetCurrentProcess();
			if (process.SessionId != P_1 || !RecoveredType94.RecoveredMethod382(process.MainModule.FileName).SequenceEqual(RecoveredType94.RecoveredMethod382(process2.MainModule.FileName)))
			{
				throw new Exception("Update this worker to the same twist build as the controller.");
			}
		}
		RecoveredType91 recoveredType = RecoveredType94.RecoveredMethod384<RecoveredType91>(namedPipeClientStream);
		if (recoveredType.Type != "worker" || recoveredType.Pid != P_0 || recoveredType.Session != P_1)
		{
			throw new Exception("Invalid worker discovery identity.");
		}
		if (recoveredType.Connected && recoveredType.PairHash != RecoveredType94.RecoveredMethod381(P_2))
		{
			return "Worker is connected to another controller.";
		}
		RecoveredType94.RecoveredMethod385(namedPipeClientStream, new RecoveredType92
		{
			Code = P_2
		});
		RecoveredType93 recoveredType2 = RecoveredType94.RecoveredMethod384<RecoveredType93>(namedPipeClientStream);
		if (!recoveredType2.Accepted)
		{
			throw new Exception(recoveredType2.Status);
		}
		return recoveredType2.Status;
	}

	public static string RecoveredMethod389(string P_0, int[] P_1)
	{
		List<string> list = new List<string>();
		HashSet<int> hashSet = new HashSet<int>();
		Process[] processesByName = Process.GetProcessesByName("twist");
		foreach (Process process in processesByName)
		{
			using (process)
			{
				try
				{
					int sessionId = process.SessionId;
					if (sessionId != RecoveredType309.SessionId && !P_1.Contains(sessionId) && hashSet.Add(sessionId))
					{
						try
						{
							list.Add("S" + sessionId + ": " + RecoveredMethod388(process.Id, sessionId, P_0));
						}
						catch (UnauthorizedAccessException)
						{
							list.Add("S" + sessionId + ": use Run as administrator or manual pairing.");
						}
						catch (TimeoutException)
						{
							list.Add("S" + sessionId + ": waiting for an updated worker.");
						}
						catch (Exception ex3)
						{
							list.Add("S" + sessionId + ": " + ex3.Message);
						}
					}
				}
				catch
				{
				}
			}
		}
		if (list.Count != 0)
		{
			return string.Join("  ·  ", list);
		}
		return "Watching for workers in other Windows sessions.";
	}
}
