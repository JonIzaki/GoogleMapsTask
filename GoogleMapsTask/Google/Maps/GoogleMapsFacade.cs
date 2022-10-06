using GoogleMapsTask.Google.Maps.Addresses;
using GoogleMapsTask.Google.Maps.Utils;
using GoogleMapsTask.Browsers;
using GoogleMapsTask.WebDriver;

namespace GoogleMapsTask.Google.Maps
{
	/// <summary>
	/// 
	/// </summary>
	internal class GoogleMapsFacade : IDisposable
	{
		private MyWebDriver _webDriver;

		/// <summary>
		/// Opens a new browser of the given type
		/// </summary>
		/// <param name="browser"> The requested browser type </param>
		public GoogleMapsFacade(BrowserType browser) => _webDriver = InitializeNewWebDriver(browser);

		/// <summary>
		/// Closes currently open browser if exists and creates a new one.
		/// </summary>
		/// <param name="browser"></param>
		public void StartNewSession(BrowserType browser)
		{
			Dispose();

			_webDriver = InitializeNewWebDriver(browser);
		}

		private static MyWebDriver InitializeNewWebDriver(BrowserType browser) => WebDriverFactory.GetWebDriver(browser);

		/// <summary>
		/// Searches for given Address in google maps and returns true if address was found.
		/// </summary>
		/// <param name="address"> Address to search for </param>
		/// <param name="maxAwaitTime"> Maximum time (in seconds) to wait for page loading after search </param>
		/// <returns> True iff address was found by google maps search </returns>
		public bool FindAddress(GMHouseAddress address, double maxAwaitTime = 2)
		{
			NavigateToGoogleMaps();

			SearchAddress(address);

			return VerifyAdressIsShown(address, maxAwaitTime);
		}

		public void NavigateToGoogleMaps() => GMNavigation.NavigateToGoogleMaps(_webDriver);

		public void SearchAddress(GMHouseAddress searchKeyword) => Search(searchKeyword.StreetAddress);

		/// <summary>
		/// Verifies the web driver is at google maps and performs a google maps search with the given keyword.
		/// </summary>
		public void Search(string searchKeyword)
		{
			NavigateToGoogleMaps();

			GMSearcher.Search(_webDriver, searchKeyword);
		}

		/// <summary>
		/// Checks if the currently displayed address in google map UI (street and number only) is the same as the given address.
		/// This will return true only if the given web driver focuses on google maps and the address UI is displaying the street address provided.
		/// </summary>
		/// <returns> True iff the web driver is on google maps where the given adress is displayed in GM's address name UI </returns>
		/// <param name="_webDriver"> Web driver to retrieve the street UI element from </param>
		/// <param name="addressToVerify"> Address used to compare the displayed address with </param>
		/// <param name="maxAwaitTime"> Max time (in seconds) to wait for the address UI element to load </param>
		/// <returns></returns>
		public bool VerifyAdressIsShown(GMHouseAddress houseAddress, double maxAwaitTime = 2) => GMAddressVerifier.VerifyAddressUI(_webDriver, houseAddress, maxAwaitTime);

		public void Dispose()
		{
			_webDriver?.Dispose();
		}
	}
}
