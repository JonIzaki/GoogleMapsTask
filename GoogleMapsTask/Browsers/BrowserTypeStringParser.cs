namespace GoogleMapsTask.Browsers
{
	internal static class BrowserTypeStringParser
	{
		private const string _chromeBrowserString = "chrome";
		private const string _firefoxBrowserString = "firefox";

		public static List<BrowserType> Parse(IEnumerable<string> browsersToAdd)
		{
			List<BrowserType> browsers = new();

			if (browsersToAdd != null)
			{
				foreach (var browser in browsersToAdd)
					browsers.Add(GetBrowserTypeFromString(browser));
			}

			return browsers;
		}

		public static BrowserType GetBrowserTypeFromString(string line)
		{

			BrowserType parsedBrowserType = BrowserType.NotSpecified;

			if (line != null)
			{
				string trimmedLine = line.Trim().ToLower();

				if (trimmedLine == _chromeBrowserString)
					parsedBrowserType = BrowserType.Chrome;
				else if (trimmedLine == _firefoxBrowserString)
					parsedBrowserType = BrowserType.Firefox;
			}

			return parsedBrowserType;
		}
	}
}
