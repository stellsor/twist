using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using B;

namespace A;

internal static class RecoveredType143
{
	public static void RecoveredMethod527(string P_0, RecoveredType141 P_1, bool P_2 = true)
	{
		if (P_2)
		{
			P_1.RecoveredMethod50();
		}
		RecoveredType142 recoveredType = new RecoveredType142();
		recoveredType.SpawnEnabled = P_1.SpawnEnabled;
		recoveredType.Enabled = P_1.Enabled;
		recoveredType.PingMythical = P_1.PingMythical;
		recoveredType.PingKind = P_1.PingKind;
		recoveredType.PingId = P_1.PingId;
		recoveredType.ProtectedUrl = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(P_1.Url ?? ""), null, DataProtectionScope.CurrentUser));
		RecoveredType142 obj = recoveredType;
		RecoveredType351.RecoveredMethod82(P_0, new JavaScriptSerializer().Serialize(obj));
	}

	public static RecoveredType141 RecoveredMethod528(string P_0, bool P_1 = true)
	{
		if (!File.Exists(P_0))
		{
			return new RecoveredType141();
		}
		RecoveredType142 recoveredType = new JavaScriptSerializer().Deserialize<RecoveredType142>(File.ReadAllText(P_0));
		RecoveredType141 recoveredType2 = new RecoveredType141();
		recoveredType2.SpawnEnabled = recoveredType.SpawnEnabled;
		recoveredType2.Enabled = recoveredType.Enabled;
		recoveredType2.PingMythical = recoveredType.PingMythical;
		recoveredType2.PingKind = recoveredType.PingKind ?? "User";
		recoveredType2.PingId = recoveredType.PingId ?? "";
		recoveredType2.Url = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(recoveredType.ProtectedUrl), null, DataProtectionScope.CurrentUser));
		RecoveredType141 recoveredType3 = recoveredType2;
		if (P_1)
		{
			recoveredType3.RecoveredMethod50();
		}
		return recoveredType3;
	}
}
