using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using WebDriverManager.Helpers;

namespace GoogleMapsTask.WebDriver
{
	/// <summary>
	/// A chrome web driver which handles initializing selenium's "ChromeDriver" and verifying other chrome specifics requirements.
	/// </summary>
	internal class ChromeWebDriver : MyWebDriver
	{
		private static bool _didSetupChromeDrivers = false;

		protected override IWebDriver InitializeWebDriver()
		{
			if (_didSetupChromeDrivers == false)
				SetupChromeDrivers();

			return new ChromeDriver();
		}

		/// <summary>
		/// Verifies chrome web driver matches the locally installed chrome version.
		/// </summary>
		private static void SetupChromeDrivers()
		{
			new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

			_didSetupChromeDrivers = true;
		}
	}
}