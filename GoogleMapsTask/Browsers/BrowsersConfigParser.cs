using System.Diagnostics;

namespace GoogleMapsTask.Browsers
{
	/// <summary>
	/// Provides a list of browser types parsed from a configuration file.
	/// </summary>
	internal static class BrowsersConfigParser
	{
		/// <summary>
		/// The browser's configuration filepath relative to the project root folder.
		/// </summary>
		private static string _browsersConfigFileRelativeFilepath => @"\TestsParameters\Browsers.txt";
		
		private static List<BrowserType> _browsers = new();
		
		private static bool _alreadyParsed = false;

		public static List<BrowserType> GetBrowsers()
		{
			ParseBrowserListIfNotParsed();

			return new List<BrowserType>(_browsers);
		}

		private static void ParseBrowserListIfNotParsed()
		{
			if (_alreadyParsed == false)
			{
				ParseBrowsers();

				_alreadyParsed = true;
			}
		}

		private static void ParseBrowsers()
		{
			string configFullFilepath = Environment.CurrentDirectory + _browsersConfigFileRelativeFilepath;

			try
			{
				IEnumerable<string> configFileLines = File.ReadLines(configFullFilepath);

				_browsers = BrowserTypeStringParser.Parse((configFileLines));

			}
			catch (Exception e)
			{
				Debug.WriteLine("Failed to read the browsers config file at " + configFullFilepath +
									".\n Exception thrown:\n" + e.Message);

				_browsers = new List<BrowserType>() { BrowserType.Chrome };
			}
		}
	}
}
