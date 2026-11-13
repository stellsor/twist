using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace b;

[CompilerGenerated]
internal sealed class L<A, a, B, b>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003Cusername_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly a _003Ccontent_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly B _003Callowed_mentions_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly b _003Cembeds_003Ei__Field;

	public A username => _003Cusername_003Ei__Field;

	public a content => _003Ccontent_003Ei__Field;

	public B allowed_mentions => _003Callowed_mentions_003Ei__Field;

	public b embeds => _003Cembeds_003Ei__Field;

	[DebuggerHidden]
	public L(A P_0, a P_1, B P_2, b P_3)
	{
		_003Cusername_003Ei__Field = P_0;
		_003Ccontent_003Ei__Field = P_1;
		_003Callowed_mentions_003Ei__Field = P_2;
		_003Cembeds_003Ei__Field = P_3;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ username = ");
		stringBuilder.Append(_003Cusername_003Ei__Field);
		stringBuilder.Append(", content = ");
		stringBuilder.Append(_003Ccontent_003Ei__Field);
		stringBuilder.Append(", allowed_mentions = ");
		stringBuilder.Append(_003Callowed_mentions_003Ei__Field);
		stringBuilder.Append(", embeds = ");
		stringBuilder.Append(_003Cembeds_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is L<A, a, B, b> l2 && EqualityComparer<A>.Default.Equals(_003Cusername_003Ei__Field, l2._003Cusername_003Ei__Field) && EqualityComparer<a>.Default.Equals(_003Ccontent_003Ei__Field, l2._003Ccontent_003Ei__Field) && EqualityComparer<B>.Default.Equals(_003Callowed_mentions_003Ei__Field, l2._003Callowed_mentions_003Ei__Field))
		{
			return EqualityComparer<b>.Default.Equals(_003Cembeds_003Ei__Field, l2._003Cembeds_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = -1382796808;
		num = -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003Cusername_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<a>.Default.GetHashCode(_003Ccontent_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<B>.Default.GetHashCode(_003Callowed_mentions_003Ei__Field);
		return -1521134295 * num + EqualityComparer<b>.Default.GetHashCode(_003Cembeds_003Ei__Field);
	}
}
[CompilerGenerated]
internal sealed class l<A>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003Cparse_003Ei__Field;

	public A parse => _003Cparse_003Ei__Field;

	[DebuggerHidden]
	public l(A P_0)
	{
		_003Cparse_003Ei__Field = P_0;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ parse = ");
		stringBuilder.Append(_003Cparse_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is l<A> l2)
		{
			return EqualityComparer<A>.Default.Equals(_003Cparse_003Ei__Field, l2._003Cparse_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = -466724452;
		return -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003Cparse_003Ei__Field);
	}
}
