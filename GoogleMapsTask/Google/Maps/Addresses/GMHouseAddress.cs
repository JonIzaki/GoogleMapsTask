namespace GoogleMapsTask.Google.Maps.Addresses
{
	internal struct GMHouseAddress
	{
		public string Street { get; private set; }
		public string HouseNumber { get; private set; }
		public string PostalCode { get; private set; }
		public string City { get; private set; }
		public string State { get; private set; }
		public string Country { get; private set; }

		/// <summary>
		/// The street address as "STREET_NAME HOUSE_NUMBER" (whitespace seperated)
		/// </summary>
		public string StreetAddress => Street.Trim() + " " + HouseNumber.Trim();

		public GMHouseAddress(string street = "", string houseNumber = "", string postalCode = "", string city = "",
											 string state = "", string country = "")
		{
			Street = street;
			HouseNumber = houseNumber;
			PostalCode = postalCode;
			City = city;
			State = state;
			Country = country;
		}
	}
}