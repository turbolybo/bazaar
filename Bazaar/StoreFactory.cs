namespace Bazaar
{
	class StoreFactory
	{
		// Adding stores
		public Store tcg = new Store("TCG Shop");
		public Store hs = new Store("HS Shop");

		/// <summary>
		/// Adding items to the shops when making a StoreFactory object.
		/// </summary>
		#region Adding items for sale
		public StoreFactory()
		{
			// Adding different TCG packs to TCG Shop
			tcg.AddItem("Heroes of Azeroth", "Legendary", 50, 10);
			tcg.AddItem("Dark Portal", "Epic", 25, 20);
			tcg.AddItem("Fires of Outland", "Epic", 25, 20);
			tcg.AddItem("Twilight of the Dragons", "Rare", 15, 25);
			tcg.AddItem("Thrones of the Tides", "Rare", 15, 25);


			// Adding different card packs to HeartSthone Shop
			hs.AddItem("Whispers of the Old Gods", "Rare", 10, 50);
			hs.AddItem("Mean Streets of Gadgetzan", "Epic", 10, 30);
			hs.AddItem("Journey to Un'Goro", "Legendary", 25, 10);
			hs.AddItem("Knights of the Frozen Throne", "Legendary", 25, 10);
		}
		#endregion
	}
}
