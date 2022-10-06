using GoogleMapsTask.Google.Maps.Addresses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace GoogleMapsTask.Google.Maps.Utils
{
	internal static class GMAddressVerifier
	{
		private static readonly string _addressTextXpath = "//*[@id=\"QA0Szd\"]/div/div/div[1]/div[2]/div/div[1]/div/div/div[2]/div[1]/div[1]/div[1]/h1/span[1]";

		/// <summary>
		/// Checks if the currently displayed address in google map UI (street and number only) is the same as the given address.
		/// This will return true only if the given web driver focuses on google maps and the address UI is displaying the street address provided.
		/// </summary>
		/// <returns> True iff the web driver is on google maps where the given adress is displayed in GM's address name UI </returns>
		/// <param name="_webDriver"> Web driver to retrieve the street UI element from </param>
		/// <param name="addressToVerify"> Address used to compare the displayed address with </param>
		/// <param name="maxAwaitTime"> Max time (in seconds) to wait for the address UI element to load </param>
		/// <returns></returns>
		public static bool VerifyAddressUI(GoogleMapsTask.WebDriver.MyWebDriver _webDriver, GMHouseAddress addressToVerify, double maxAwaitTime = 2)
		{
			bool isDisplayed = false;

			if (TryGetAddressFromUI(_webDriver, out string displayedAdress, maxAwaitTime))
			{
				displayedAdress = displayedAdress.Trim();

				string comparedAddress = addressToVerify.StreetAddress;
;
				isDisplayed = displayedAdress == comparedAddress;

				Debug.WriteLine($"Displayed address is \'{displayedAdress}\', compared address is \'{comparedAddress}\'. Result: \"{isDisplayed}\"");
			}

			return isDisplayed;
		}

		/// <summary>
		/// Returns the current address being displayed in google maps by attempting to extract the text from the street address UI.
		/// Returns true iff the address UI exists in the currently displayed web driver page, and sets the displayed adress to
		/// its text value. Otherwise returns false and sets the displayed adress to an empty string.
		/// </summary>
		/// <returns> True if the  </returns>
		private static bool TryGetAddressFromUI(GoogleMapsTask.WebDriver.MyWebDriver _webDriver, out string displayedAddress, double maxAwaitTime = 0)
		{
			IWebElement addressWebElement;

			try
			{
				addressWebElement = FindAddressUIElement(_webDriver, maxAwaitTime);

				displayedAddress = addressWebElement.Text;

				return true;
			}
			catch (Exception e)
			{
				Debug.WriteLine("Failed to locate the current Address UI element of google maps. Exception thrown: " + e.Message);

				displayedAddress = "";

				return false;
			}
		}

		private static IWebElement FindAddressUIElement(GoogleMapsTask.WebDriver.MyWebDriver _webDriver, double maxAwaitTime)
		{
			IWebElement addressWebElement;

			if (maxAwaitTime > 0)
			{
				WebDriverWait wait = new(_webDriver.Driver, TimeSpan.FromSeconds(maxAwaitTime));
				addressWebElement = wait.Until(e => e.FindElement(By.XPath(_addressTextXpath)));
			}
			else
			{
				addressWebElement = _webDriver.Driver.FindElement(By.XPath(_addressTextXpath));
			}

			return addressWebElement;
		}
	}
}
