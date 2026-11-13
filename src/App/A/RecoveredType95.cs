using System;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using B;

namespace A;

internal sealed class RecoveredType95 : IDisposable
{
	[CompilerGenerated]
	private sealed class RecoveredType96
	{
		public bool allowed;

		public RecoveredType95 _003C_003E4__this;

		public void RecoveredMethod45()
		{
			using WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent(ifImpersonating: true);
			if (windowsIdentity != null && windowsIdentity.User != null)
			{
				allowed = windowsIdentity.User.Value == _003C_003E4__this.owner || new WindowsPrincipal(windowsIdentity).IsInRole(WindowsBuiltInRole.Administrator);
			}
		}
	}

	private readonly string owner;

	private readonly string id;

	private readonly string pipeName;

	private readonly Func<bool> connected;

	private readonly Func<string> code;

	private readonly Action<string> pair;

	private readonly object gate = new object();

	private NamedPipeServerStream current;

	private int closed;

	public RecoveredType95(string P_0, Func<bool> P_1, Func<string> P_2, Action<string> P_3, string P_4 = null)
	{
		pipeName = P_4 ?? RecoveredType94.RecoveredMethod380(RecoveredType309.SessionId);
		id = P_0;
		connected = P_1;
		code = P_2;
		pair = P_3;
		using (WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent())
		{
			owner = windowsIdentity.User.Value;
		}
		Task.Run((Action)RecoveredMethod45);
	}

	private void RecoveredMethod45()
	{
		while (Volatile.Read(ref closed) == 0)
		{
			NamedPipeServerStream namedPipeServerStream = null;
			try
			{
				PipeSecurity pipeSecurity = new PipeSecurity();
				pipeSecurity.SetAccessRuleProtection(isProtected: true, preserveInheritance: false);
				pipeSecurity.AddAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.NetworkSid, null), PipeAccessRights.FullControl, AccessControlType.Deny));
				pipeSecurity.AddAccessRule(new PipeAccessRule(new SecurityIdentifier(owner), PipeAccessRights.FullControl, AccessControlType.Allow));
				pipeSecurity.AddAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null), PipeAccessRights.FullControl, AccessControlType.Allow));
				namedPipeServerStream = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 4096, 4096, pipeSecurity);
				lock (gate)
				{
					if (Volatile.Read(ref closed) != 0)
					{
						namedPipeServerStream.Dispose();
						break;
					}
					current = namedPipeServerStream;
				}
				namedPipeServerStream.WaitForConnection();
				RecoveredType94.RecoveredMethod385(namedPipeServerStream, new RecoveredType91
				{
					Id = id,
					Pid = Process.GetCurrentProcess().Id,
					Session = RecoveredType309.SessionId,
					Connected = connected(),
					PairHash = RecoveredType94.RecoveredMethod381(code())
				});
				RecoveredType92 recoveredType = RecoveredType94.RecoveredMethod384<RecoveredType92>(namedPipeServerStream);
				bool allowed = false;
				namedPipeServerStream.RunAsClient(delegate
				{
					using WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent(ifImpersonating: true);
					if (windowsIdentity != null && windowsIdentity.User != null)
					{
						allowed = windowsIdentity.User.Value == owner || new WindowsPrincipal(windowsIdentity).IsInRole(WindowsBuiltInRole.Administrator);
					}
				});
				if (!allowed)
				{
					throw new UnauthorizedAccessException("The controller Windows identity is not authorized.");
				}
				RecoveredType321 recoveredType2 = RecoveredType321.RecoveredMethod780(recoveredType.Code);
				string text = recoveredType2.Code;
				if (recoveredType.Type != "pair")
				{
					throw new Exception("Unsupported discovery request.");
				}
				if (connected() && code() != text)
				{
					RecoveredType94.RecoveredMethod385(namedPipeServerStream, new RecoveredType93
					{
						Accepted = false,
						Status = "Worker is already paired to another active controller."
					});
				}
				else
				{
					pair(text);
					RecoveredType94.RecoveredMethod385(namedPipeServerStream, new RecoveredType93
					{
						Accepted = true,
						Status = "Worker connected automatically"
					});
				}
			}
			catch
			{
				if (Volatile.Read(ref closed) != 0)
				{
					break;
				}
			}
			finally
			{
				lock (gate)
				{
					if (current == namedPipeServerStream)
					{
						current = null;
					}
				}
				namedPipeServerStream?.Dispose();
			}
		}
	}

	public void Dispose()
	{
		if (Interlocked.Exchange(ref closed, 1) != 0)
		{
			return;
		}
		lock (gate)
		{
			if (current != null)
			{
				current.Dispose();
			}
		}
	}
}
