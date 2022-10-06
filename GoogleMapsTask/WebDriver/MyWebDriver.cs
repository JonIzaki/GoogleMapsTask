using OpenQA.Selenium;

namespace GoogleMapsTask.WebDriver
{
	/// <summary>
	/// Wraps a web driver and provides a platform to extend its API as well as encapsulating browser specific functionalities.
	/// </summary>
	public abstract class MyWebDriver : IDisposable
	{
		public IWebDriver Driver { get; private set; }

		public MyWebDriver() => Driver = InitializeWebDriver();

		protected abstract IWebDriver InitializeWebDriver();

		public void NavigateToURL(string requestedURL) => Driver.Navigate().GoToUrl(requestedURL);

		public void Dispose() => Driver.Quit();
	}
}