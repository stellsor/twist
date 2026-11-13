using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using A;

namespace c;

internal sealed class RecoveredType146 : RecoveredType89
{
	[CompilerGenerated]
	private sealed class RecoveredType147
	{
		public HttpWebRequest request;

		public void RecoveredMethod45()
		{
			request.Abort();
		}
	}

	public RecoveredType145 RecoveredMethod378(Uri P_0, string P_1, CancellationToken P_2)
	{
		ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(P_0);
		request.Method = "POST";
		request.ContentType = "application/json; charset=utf-8";
		request.UserAgent = "twist/0.7.29";
		request.AllowAutoRedirect = false;
		request.UseDefaultCredentials = false;
		request.Timeout = 8000;
		request.ReadWriteTimeout = 8000;
		byte[] bytes = Encoding.UTF8.GetBytes(P_1);
		request.ContentLength = bytes.Length;
		Action callback = delegate
		{
			request.Abort();
		};
		using (P_2.Register(callback))
		{
			try
			{
				P_2.ThrowIfCancellationRequested();
				using (Stream stream = request.GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
				}
				using HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
				return RecoveredMethod531(httpWebResponse);
			}
			catch (WebException ex)
			{
				P_2.ThrowIfCancellationRequested();
				if (!(ex.Response is HttpWebResponse httpWebResponse2))
				{
					RecoveredType145 recoveredType = new RecoveredType145();
					recoveredType.Status = 0;
					recoveredType.Error = "Connection failure: " + ex.Status;
					return recoveredType;
				}
				using (httpWebResponse2)
				{
					return RecoveredMethod531(httpWebResponse2);
				}
			}
		}
	}

	private static RecoveredType145 RecoveredMethod531(HttpWebResponse P_0)
	{
		RecoveredType145 recoveredType = new RecoveredType145();
		recoveredType.Status = (int)P_0.StatusCode;
		recoveredType.Error = "Discord HTTP " + (int)P_0.StatusCode;
		RecoveredType145 recoveredType2 = recoveredType;
		if (recoveredType2.Status == 429)
		{
			if (!double.TryParse(P_0.Headers["Retry-After"], NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
			{
				result = 2.0;
			}
			try
			{
				using StreamReader streamReader = new StreamReader(P_0.GetResponseStream());
				string text = streamReader.ReadToEnd();
				if (text.Length < 64000)
				{
					Dictionary<string, object> dictionary = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(text);
					if (dictionary.TryGetValue("retry_after", out var value) && double.TryParse(Convert.ToString(value, CultureInfo.InvariantCulture), NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
					{
						result = result2;
					}
				}
			}
			catch
			{
			}
			if (double.IsNaN(result) || double.IsInfinity(result))
			{
				result = 2.0;
			}
			recoveredType2.RetryAfterMs = (int)Math.Max(500.0, Math.Min(86400000.0, result * 1000.0));
		}
		return recoveredType2;
	}
}
