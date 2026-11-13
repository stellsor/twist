using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using A;
using a;

namespace TwistApp;

public sealed class ItemMetadata
{
	public string Name = "";

	public string Rarity = "Unknown";

	public string Category = "Unknown";

	public string Image = "";

	public List<VisualPart> Parts = new List<VisualPart>();

	private readonly object iconGate = new object();

	private string cachedIcon;

	private ulong cachedFingerprint;

	internal ulong PreviewFingerprint
	{
		get
		{
			ulong num = RecoveredMethod696(RecoveredMethod696(1469598103934665603uL, (Name ?? "").GetHashCode()), (Image ?? "").GetHashCode());
			if (Parts != null)
			{
				foreach (VisualPart part in Parts)
				{
					num = RecoveredMethod696(RecoveredMethod696(num, (part.Mesh ?? "").GetHashCode()), (part.Texture ?? "").GetHashCode());
					num = RecoveredMethod697(RecoveredMethod697(RecoveredMethod697(num, part.Position), part.Rotation), part.Size);
				}
			}
			return num;
		}
	}

	[ScriptIgnore]
	public string IconKey
	{
		get
		{
			lock (iconGate)
			{
				ulong previewFingerprint = PreviewFingerprint;
				if (cachedIcon != null && previewFingerprint == cachedFingerprint)
				{
					return cachedIcon;
				}
				string s = "renderer2|" + Name + "|" + Image + "|" + new JavaScriptSerializer().Serialize(Parts);
				using SHA256 sHA = SHA256.Create();
				cachedIcon = string.Concat(from P_0 in sHA.ComputeHash(Encoding.UTF8.GetBytes(s)).Take(12)
					select P_0.ToString("x2"));
				cachedFingerprint = previewFingerprint;
				return cachedIcon;
			}
		}
	}

	public bool IsFruit
	{
		get
		{
			if (!(Category == "Fruit"))
			{
				return RecoveredType219.RecoveredMethod39(Name);
			}
			return true;
		}
	}

	public bool IsFish
	{
		get
		{
			if (Category == "Fish" || RecoveredType210.RecoveredMethod39(Name))
			{
				return RecoveredType106.RecoveredMethod403(Name) == 0;
			}
			return false;
		}
	}

	private static ulong RecoveredMethod696(ulong P_0, int P_1)
	{
		return (P_0 ^ (uint)P_1) * 1099511628211L;
	}

	private static ulong RecoveredMethod697(ulong P_0, float[] P_1)
	{
		P_0 = RecoveredMethod696(P_0, (P_1 == null) ? (-1) : P_1.Length);
		if (P_1 != null)
		{
			for (int i = 0; i < P_1.Length; i++)
			{
				P_0 = RecoveredMethod696(P_0, P_1[i].GetHashCode());
			}
		}
		return P_0;
	}

	[CompilerGenerated]
	private static string RecoveredMethod698(byte P_0)
	{
		return P_0.ToString("x2");
	}
}
