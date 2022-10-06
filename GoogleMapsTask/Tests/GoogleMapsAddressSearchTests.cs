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
		private readonly double _loadingAddressMaxTime = 4;

		[OneTimeSetUp]
		public void SetUpOnce() => _validAddressProvider = new AddressesCollection(StaticAddressDB.ValidAddresses.shortCollection);

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