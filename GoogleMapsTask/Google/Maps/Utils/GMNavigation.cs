using GoogleMapsTask.WebDriver;
using System.Diagnostics;

namespace GoogleMapsTask.Google.Maps.Utils
{
	internal static class GMNavigation
	{
		private static string _googleMapsURL => _validGoogleURLS[0];

		private static readonly string[] _validGoogleURLS = new string[]
		{
			"https://www.google.com/maps",
			"https://google.com/maps",
			"www.google.com/maps",
			"google.com/maps",
		};

		/// <summary>
		/// Navigates a webDriver to google maps, and handles the accept cookies popup if exists.
		/// </summary>
		/// <param name="webDriver"> webDriver used to navigating into google maps </param>
		public static void NavigateToGoogleMaps(MyWebDriver webDriver)
		{
			webDriver.NavigateToURL(_googleMapsURL);

			GoogleCookiesPage.HandleCookiesLayerIfExists(webDriver);
		}

		public static bool IsInGoogleMaps(MyWebDriver webDriver)
		{
			string currentURL = webDriver.Driver.Url;
			bool inGoogleMaps = false;

			foreach (var googleMapsURL in _validGoogleURLS)
			{
				inGoogleMaps = currentURL.StartsWith(googleMapsURL);

				if (inGoogleMaps)
					break;
			}

			return inGoogleMaps; 
		}
	}
}