namespace GoogleMapsTask.Google.Maps.Addresses
{
	/// <summary>
	/// Provides abstraction for google maps addresses databases.
	/// </summary>
	internal interface IAddressProvider
	{
		/// <summary>
		/// Returns all Addresses in DB
		/// </summary>
		public IEnumerable<GMHouseAddress> GetAllAddresses();

		/// <summary>
		/// Fetches a single address from the DB
		/// </summary>
		public GMHouseAddress GetAddress();
	}
}
