using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace A;

[CompilerGenerated]
internal sealed class H<A, a, B, b>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003Ctag_name_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly a _003Cdraft_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly B _003Cprerelease_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly b _003Cassets_003Ei__Field;

	public A tag_name => _003Ctag_name_003Ei__Field;

	public a draft => _003Cdraft_003Ei__Field;

	public B prerelease => _003Cprerelease_003Ei__Field;

	public b assets => _003Cassets_003Ei__Field;

	[DebuggerHidden]
	public H(A P_0, a P_1, B P_2, b P_3)
	{
		_003Ctag_name_003Ei__Field = P_0;
		_003Cdraft_003Ei__Field = P_1;
		_003Cprerelease_003Ei__Field = P_2;
		_003Cassets_003Ei__Field = P_3;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ tag_name = ");
		stringBuilder.Append(_003Ctag_name_003Ei__Field);
		stringBuilder.Append(", draft = ");
		stringBuilder.Append(_003Cdraft_003Ei__Field);
		stringBuilder.Append(", prerelease = ");
		stringBuilder.Append(_003Cprerelease_003Ei__Field);
		stringBuilder.Append(", assets = ");
		stringBuilder.Append(_003Cassets_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is H<A, a, B, b> h && EqualityComparer<A>.Default.Equals(_003Ctag_name_003Ei__Field, h._003Ctag_name_003Ei__Field) && EqualityComparer<a>.Default.Equals(_003Cdraft_003Ei__Field, h._003Cdraft_003Ei__Field) && EqualityComparer<B>.Default.Equals(_003Cprerelease_003Ei__Field, h._003Cprerelease_003Ei__Field))
		{
			return EqualityComparer<b>.Default.Equals(_003Cassets_003Ei__Field, h._003Cassets_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = -700456029;
		num = -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003Ctag_name_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<a>.Default.GetHashCode(_003Cdraft_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<B>.Default.GetHashCode(_003Cprerelease_003Ei__Field);
		return -1521134295 * num + EqualityComparer<b>.Default.GetHashCode(_003Cassets_003Ei__Field);
	}
}
