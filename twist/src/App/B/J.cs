using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace b;

[CompilerGenerated]
internal sealed class J<A, a, B>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003CFruit_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly a _003CWorld_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly B _003CAccount_003Ei__Field;

	public A Fruit => _003CFruit_003Ei__Field;

	public a World => _003CWorld_003Ei__Field;

	public B Account => _003CAccount_003Ei__Field;

	[DebuggerHidden]
	public J(A P_0, a P_1, B P_2)
	{
		_003CFruit_003Ei__Field = P_0;
		_003CWorld_003Ei__Field = P_1;
		_003CAccount_003Ei__Field = P_2;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ Fruit = ");
		stringBuilder.Append(_003CFruit_003Ei__Field);
		stringBuilder.Append(", World = ");
		stringBuilder.Append(_003CWorld_003Ei__Field);
		stringBuilder.Append(", Account = ");
		stringBuilder.Append(_003CAccount_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is J<A, a, B> j2 && EqualityComparer<A>.Default.Equals(_003CFruit_003Ei__Field, j2._003CFruit_003Ei__Field) && EqualityComparer<a>.Default.Equals(_003CWorld_003Ei__Field, j2._003CWorld_003Ei__Field))
		{
			return EqualityComparer<B>.Default.Equals(_003CAccount_003Ei__Field, j2._003CAccount_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = -480374988;
		num = -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003CFruit_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<a>.Default.GetHashCode(_003CWorld_003Ei__Field);
		return -1521134295 * num + EqualityComparer<B>.Default.GetHashCode(_003CAccount_003Ei__Field);
	}
}
[CompilerGenerated]
internal sealed class j<A, a, B>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003Cname_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly a _003Cvalue_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly B _003Cinline_003Ei__Field;

	public A name => _003Cname_003Ei__Field;

	public a value => _003Cvalue_003Ei__Field;

	public B inline => _003Cinline_003Ei__Field;

	[DebuggerHidden]
	public j(A P_0, a P_1, B P_2)
	{
		_003Cname_003Ei__Field = P_0;
		_003Cvalue_003Ei__Field = P_1;
		_003Cinline_003Ei__Field = P_2;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ name = ");
		stringBuilder.Append(_003Cname_003Ei__Field);
		stringBuilder.Append(", value = ");
		stringBuilder.Append(_003Cvalue_003Ei__Field);
		stringBuilder.Append(", inline = ");
		stringBuilder.Append(_003Cinline_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is j<A, a, B> j2 && EqualityComparer<A>.Default.Equals(_003Cname_003Ei__Field, j2._003Cname_003Ei__Field) && EqualityComparer<a>.Default.Equals(_003Cvalue_003Ei__Field, j2._003Cvalue_003Ei__Field))
		{
			return EqualityComparer<B>.Default.Equals(_003Cinline_003Ei__Field, j2._003Cinline_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = 1279807787;
		num = -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003Cname_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<a>.Default.GetHashCode(_003Cvalue_003Ei__Field);
		return -1521134295 * num + EqualityComparer<B>.Default.GetHashCode(_003Cinline_003Ei__Field);
	}
}
