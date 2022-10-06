using GoogleMapsTask.WebDriver;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace GoogleMapsTask.Google
{
	internal static class GoogleCookiesPage
	{
		private static readonly string _googleCookiesPage = "consent.google.com";
		private static readonly string _acceptCookiesButtonXpath = "//*[@id=\"yDmH0d\"]/c-wiz/div/div/div/div[2]/div[1]/div[3]/div[1]/div[1]/form[1]/div/div/button";

		/// <summary>
		/// Time interval where we expect the accept button to load in the cookie form.
		/// </summary>
		private static readonly TimeSpan _maxButtonLoadingTime = TimeSpan.FromSeconds(3);

		public static void HandleCookiesLayerIfExists(MyWebDriver webDriver)
		{
			bool onCookieConsentPage = webDriver.Driver.Url.Contains(_googleCookiesPage);

			if (onCookieConsentPage)
			{
				//Debug.WriteLine("Google cookie page detected. Accepting cookies.");
				AcceptGoogleCookies(webDriver);
			}
		}

		private static void AcceptGoogleCookies(MyWebDriver webDriver)
		{
			WebDriverWait driverWait = new(webDriver.Driver, _maxButtonLoadingTime);

			IWebElement acceptCookieButton = driverWait.Until(e => e.FindElement(By.XPath(_acceptCookiesButtonXpath)));

			acceptCookieButton.Click();
		}
	}
}
