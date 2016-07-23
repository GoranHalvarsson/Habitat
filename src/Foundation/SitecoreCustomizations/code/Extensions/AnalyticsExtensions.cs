namespace VisionsInCode.Foundation.SitecoreCustomizations.Extensions
{
	using System.Net;

	public static class AnalyticsExtensions
	{
		public static string GetFriendlyIpAddress(this byte[] bytes)
		{
			IPAddress address = new IPAddress(bytes);

			return address.ToString();
		}

	}
}
