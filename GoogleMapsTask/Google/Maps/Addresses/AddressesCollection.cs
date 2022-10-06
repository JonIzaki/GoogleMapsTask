namespace GoogleMapsTask.Google.Maps.Addresses
{
	internal class AddressesCollection : IAddressProvider
	{
		private readonly List<GMHouseAddress> _addresses;

		private static readonly Random _rnd = new();

		public AddressesCollection(List<GMHouseAddress> addresses) => _addresses = addresses;

		public GMHouseAddress GetAddress()
		{
			int randomAddressIndex = _rnd.Next(_addresses.Count);

			return _addresses[randomAddressIndex];
		}

		public IEnumerable<GMHouseAddress> GetAllAddresses() => new List<GMHouseAddress>(_addresses);
	}
}