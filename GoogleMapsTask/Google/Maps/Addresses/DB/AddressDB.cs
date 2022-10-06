namespace GoogleMapsTask.Google.Maps.Addresses.DB
{

	internal static class StaticAddressDB
	{
		public static class ValidAddresses
		{
			public static List<GMHouseAddress> shortCollection = new()
			{
				new GMHouseAddress("Theodor-Fliedner-Straße ", "3"),
				new GMHouseAddress("Schlebuscher-Heide ", "9"),
				new GMHouseAddress("Gebhardtstraße", "18"),
				new GMHouseAddress("Schlangenhecke", "7"),
				new GMHouseAddress("Quarzstraße", "6"),
				new GMHouseAddress("Wiesdorfer Pl.", "5"),
			};
		}

		public static class InvalidAddresses
		{
			public static List<GMHouseAddress> shortCollection = new()
			{
				new GMHouseAddress(" ", "3"),
				new GMHouseAddress("456452", "9"),
				new GMHouseAddress("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "18"),
			};
		}
	}
}
