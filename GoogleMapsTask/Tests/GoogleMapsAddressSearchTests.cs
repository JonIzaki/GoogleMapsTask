using GoogleMapsTask.Google.Maps;
using GoogleMapsTask.Google.Maps.Addresses;
using GoogleMapsTask.Browsers;
using GoogleMapsTask.Google.Maps.Addresses.DB;
using System.Diagnostics;

namespace GoogleMapsTask.Tests
{
	/// <summary>
	/// Test case example showcasing the google maps automation tests framework use case.
	/// </summary>
	public class GoogleMapsAddressSearchTests
	{
		private IAddressProvider _validAddressProvider;

		/// <summary>
		/// Providing long times with our address lookup test as we don't want a tesst to fail on slow connection.
		/// </summary>
		private readonly double _loadingAddressMaxTime = 20;

		[OneTimeSetUp]
		public void SetUpOnce() => _validAddressProvider = new AddressesCollection(StaticAddressDB.ValidAddresses.shortCollection);

		/// <summary>
		/// An example for a test searching for all addresses in the given DB.
		/// This test is defined with the multi browser feature using browser type attribute.
		/// </summary>
		/// <param name="browser"> The browser type to run the test on </param>
		[Test]
		public void ConsecutiveValidAddressSearchExample([ConfigFileBrowsers] BrowserType browser)
		{
			bool allAdressesFound = true;

			using (var googleMaps = new GoogleMapsFacade(browser))
			{
				foreach (GMHouseAddress address in _validAddressProvider.GetAllAddresses())
				{
					bool addressFound = googleMaps.FindAddress(address, _loadingAddressMaxTime);

					allAdressesFound &= addressFound;
					Debug.WriteLine($"Result of address {address.StreetAddress} is {addressFound}. Test state is {allAdressesFound}");
				}
			}

			Assert.That(allAdressesFound, Is.True);
		}

		/// <summary>
		/// Single address search test which doesn't use the multi browser feature.
		/// </summary>
		[Test]
		public void OneAddressSearchExample()
		{
			bool allAdressesFound = true;

			using (var googleMaps = new GoogleMapsFacade(BrowserType.Chrome))
			{
				GMHouseAddress address = _validAddressProvider.GetAddress();

				bool addressFound = googleMaps.FindAddress(address, _loadingAddressMaxTime);
				allAdressesFound &= addressFound;

				//Debug.WriteLine($"Result of address {address.StreetAddress} is {addressFound}. Test state is {allAdressesFound}");
			}

			Assert.That(allAdressesFound, Is.True);
		}
	}
}