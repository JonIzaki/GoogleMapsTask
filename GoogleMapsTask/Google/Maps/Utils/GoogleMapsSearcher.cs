using OpenQA.Selenium;

namespace GoogleMapsTask.Google.Maps.Utils
{
	/// <summary>
	/// Handles searching google maps using the search bar, i.e. manipulating google maps searchbar text and 
	/// executing the search. Note: This module assumes the current focus of the web driver is on google maps.
	/// </summary>
	internal static class GMSearcher
	{
		private static readonly string _searchboxXPath = "//*[@id=\"searchboxinput\"]";
		private static readonly string _searchButtonXPath = "//*[@id=\"searchbox-searchbutton\"]";

		/// <summary>
		/// Locates the google maps searchbar UI elements in the given weDriver, set its text to the given value
		/// and executes the search by pressing the search button.
		/// </summary>
		/// <param name="_webDriver"> webDriver to use google maps search </param>
		/// <param name="searchKeyword"> the value to search in google maps </param>
		public static void Search(GoogleMapsTask.WebDriver.MyWebDriver _webDriver, string searchKeyword)
		{
			EnterSearchText(_webDriver, searchKeyword);

			PressSearchButton(_webDriver);
		}

		/// <summary>
		/// Attempts to write the given text into google maps searchbox. 
		/// Propagates exception if fails to locate textbox in current page.
		/// </summary>
		/// <param name="searchKeyword"> Requested string to set </param>
		public static void EnterSearchText(GoogleMapsTask.WebDriver.MyWebDriver _webDriver, string searchKeyword)
		{
			if (searchKeyword != null)
			{
				IWebElement searchbox = _webDriver.Driver.FindElement(By.XPath(_searchboxXPath));

				searchbox.SendKeys(searchKeyword);
			}
		}

		/// <summary>
		/// Attempts to locate and click on google maps search button. 
		/// Propagates exception if fails to locate searchbutton in current page.
		/// </summary>
		public static void PressSearchButton(GoogleMapsTask.WebDriver.MyWebDriver _webDriver)
		{
			IWebElement searchButton = _webDriver.Driver.FindElement(By.XPath(_searchButtonXPath));

			searchButton.Click();
		}
	}
}
