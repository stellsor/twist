using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace A;

[CompilerGenerated]
internal sealed class g<A, a, B, b>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly A _003Cname_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly a _003Csize_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly B _003Cdigest_003Ei__Field;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly b _003Cbrowser_download_url_003Ei__Field;

	public A name => _003Cname_003Ei__Field;

	public a size => _003Csize_003Ei__Field;

	public B digest => _003Cdigest_003Ei__Field;

	public b browser_download_url => _003Cbrowser_download_url_003Ei__Field;

	[DebuggerHidden]
	public g(A P_0, a P_1, B P_2, b P_3)
	{
		_003Cname_003Ei__Field = P_0;
		_003Csize_003Ei__Field = P_1;
		_003Cdigest_003Ei__Field = P_2;
		_003Cbrowser_download_url_003Ei__Field = P_3;
	}

	[DebuggerHidden]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("{ name = ");
		stringBuilder.Append(_003Cname_003Ei__Field);
		stringBuilder.Append(", size = ");
		stringBuilder.Append(_003Csize_003Ei__Field);
		stringBuilder.Append(", digest = ");
		stringBuilder.Append(_003Cdigest_003Ei__Field);
		stringBuilder.Append(", browser_download_url = ");
		stringBuilder.Append(_003Cbrowser_download_url_003Ei__Field);
		stringBuilder.Append(" }");
		return stringBuilder.ToString();
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		if (value is g<A, a, B, b> g2 && EqualityComparer<A>.Default.Equals(_003Cname_003Ei__Field, g2._003Cname_003Ei__Field) && EqualityComparer<a>.Default.Equals(_003Csize_003Ei__Field, g2._003Csize_003Ei__Field) && EqualityComparer<B>.Default.Equals(_003Cdigest_003Ei__Field, g2._003Cdigest_003Ei__Field))
		{
			return EqualityComparer<b>.Default.Equals(_003Cbrowser_download_url_003Ei__Field, g2._003Cbrowser_download_url_003Ei__Field);
		}
		return false;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = 761693162;
		num = -1521134295 * num + EqualityComparer<A>.Default.GetHashCode(_003Cname_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<a>.Default.GetHashCode(_003Csize_003Ei__Field);
		num = -1521134295 * num + EqualityComparer<B>.Default.GetHashCode(_003Cdigest_003Ei__Field);
		return -1521134295 * num + EqualityComparer<b>.Default.GetHashCode(_003Cbrowser_download_url_003Ei__Field);
	}
}
