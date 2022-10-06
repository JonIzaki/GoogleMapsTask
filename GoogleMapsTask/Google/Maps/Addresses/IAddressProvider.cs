namespace GoogleMapsTask.Google.Maps.Addresses
{
	/// <summary>
	/// Provides abstraction for google maps addresses databases.
	/// </summary>
	internal interface IAddressProvider
	{
		public IEnumerable<GMHouseAddress> GetAllAddresses();

		public GMHouseAddress GetAddress();
	}
}
