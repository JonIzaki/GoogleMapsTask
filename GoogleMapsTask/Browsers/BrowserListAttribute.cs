namespace GoogleMapsTask.Browsers
{
	/// <summary>
	/// Provides value source attribute pointing to a browser list generated from a configuration file.
	/// Can be used by tests Nunit test cases to run with different Browser type parameters.
	/// </summary>
	public class ConfigFileBrowsers : ValueSourceAttribute
	{
		private static List<BrowserType> _browsers = new();

		private static bool InitializedOnce = false;

		public ConfigFileBrowsers() : base(typeof(ConfigFileBrowsers), "_browsers")
		{
			if (InitializedOnce == false)
			{
				UpdateBrowserList();

				ValidateBrowsers();

				InitializedOnce = true;
			}
		}

		private void UpdateBrowserList() => _browsers = BrowsersConfigParser.GetBrowsers().ToList();

		private static void ValidateBrowsers()
		{
			if (_browsers != null)
				RemoveInvalidBrowserTypes();
			else
				_browsers = new List<BrowserType>();
		}

		private static void RemoveInvalidBrowserTypes() =>  _browsers.RemoveAll(browserType => browserType == BrowserType.NotSpecified);
	}
}