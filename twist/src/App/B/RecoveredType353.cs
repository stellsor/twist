using System;
using System.Drawing;
using System.Windows.Forms;

namespace B;

internal sealed class RecoveredType353 : Form
{
	public int Downs;

	public int Ups;

	public int Keys;

	public IntPtr LastPoint;

	public RecoveredType353(string P_0)
	{
		Text = P_0;
		base.ClientSize = new Size(800, 600);
		_ = base.Handle;
	}

	protected override void WndProc(ref Message message)
	{
		if (message.Msg == 513)
		{
			Downs++;
			LastPoint = message.LParam;
		}
		else if (message.Msg == 514)
		{
			Ups++;
		}
		else if (message.Msg == 256)
		{
			Keys++;
		}
		else if (message.Msg != 512 && message.Msg != 257)
		{
			base.WndProc(ref message);
		}
	}
}
