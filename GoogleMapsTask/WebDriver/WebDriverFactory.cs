using GoogleMapsTask.Browsers;

namespace GoogleMapsTask.WebDriver
{
	/// <summary>
	/// Handles generating web browser driver instances for requested browser type.
	/// </summary>
	internal static class WebDriverFactory
	{
		public static MyWebDriver GetWebDriver(BrowserType requestedType)
		{
			MyWebDriver webDriver;

			// Currently only one browser type is supported.
			if (requestedType == BrowserType.Chrome)
				webDriver = new ChromeWebDriver();
			else
				throw new ArgumentException("Failed to created web driver due invalid browser type specified: \'" + requestedType + "\'");

			//...
			//else if (reqeuestedType == BrowserType.Firefox)
			//	webDriver = new FirefoxWebDriver();

			return webDriver;
		}
	}
}
