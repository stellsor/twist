using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace b;

[CompilerGenerated]
internal sealed class K<A>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003Ctext_003Ei__Field;

	public A text => _003Ctext_003Ei__Field;

	[DebuggerHidden]
	public K(A P_0)
	{
		_003Ctext_003Ei__Field = P_0;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ text = ");
		stringBuilder.Append(_003Ctext_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is K<A> k2)
		{
			return EqualityComparer<A>.Default.Equals(_003Ctext_003Ei__Field, k2._003Ctext_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = -2042385164;
		return -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003Ctext_003Ei__Field);
	}
}
[CompilerGenerated]
internal sealed class k<A, a, B, b, C>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003Ctitle_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly a _003Ccolor_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly B _003Cfields_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly b _003Cfooter_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly C _003Ctimestamp_003Ei__Field;

	public A title => _003Ctitle_003Ei__Field;

	public a color => _003Ccolor_003Ei__Field;

	public B fields => _003Cfields_003Ei__Field;

	public b footer => _003Cfooter_003Ei__Field;

	public C timestamp => _003Ctimestamp_003Ei__Field;

	[DebuggerHidden]
	public k(A P_0, a P_1, B P_2, b P_3, C P_4)
	{
		_003Ctitle_003Ei__Field = P_0;
		_003Ccolor_003Ei__Field = P_1;
		_003Cfields_003Ei__Field = P_2;
		_003Cfooter_003Ei__Field = P_3;
		_003Ctimestamp_003Ei__Field = P_4;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ title = ");
		stringBuilder.Append(_003Ctitle_003Ei__Field);
		stringBuilder.Append(", color = ");
		stringBuilder.Append(_003Ccolor_003Ei__Field);
		stringBuilder.Append(", fields = ");
		stringBuilder.Append(_003Cfields_003Ei__Field);
		stringBuilder.Append(", footer = ");
		stringBuilder.Append(_003Cfooter_003Ei__Field);
		stringBuilder.Append(", timestamp = ");
		stringBuilder.Append(_003Ctimestamp_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is k<A, a, B, b, C> k2 && EqualityComparer<A>.Default.Equals(_003Ctitle_003Ei__Field, k2._003Ctitle_003Ei__Field) && EqualityComparer<a>.Default.Equals(_003Ccolor_003Ei__Field, k2._003Ccolor_003Ei__Field) && EqualityComparer<B>.Default.Equals(_003Cfields_003Ei__Field, k2._003Cfields_003Ei__Field) && EqualityComparer<b>.Default.Equals(_003Cfooter_003Ei__Field, k2._003Cfooter_003Ei__Field))
		{
			return EqualityComparer<C>.Default.Equals(_003Ctimestamp_003Ei__Field, k2._003Ctimestamp_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = 309067557;
		num = -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003Ctitle_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<a>.Default.GetHashCode(_003Ccolor_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<B>.Default.GetHashCode(_003Cfields_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<b>.Default.GetHashCode(_003Cfooter_003Ei__Field);
		return -1521134295 * num + EqualityComparer<C>.Default.GetHashCode(_003Ctimestamp_003Ei__Field);
	}
}
