using System;

namespace Bazaar
{
	class StoreItem
	{
		#region Properties and variables

		//Properties
		public string StoreItemName { get; private set; }
		public string StoreItemRarity { get; private set; }
		public int StoreItemPrice{ get; private set; }
        public int StoreItemProbability { get; set; }
        public bool StoreItemSold { get; set; }
        
		// For locking thread.
        private readonly Object _itemLock = new Object();
		#endregion

		#region Constructors
		public StoreItem(string name, string rarity, int price, int probability)
		{
			StoreItemName = name;
			StoreItemRarity = rarity;
			StoreItemPrice = price;
            StoreItemProbability = probability;
            StoreItemSold = false;
		}
        public StoreItem(StoreItem storeItem)
        {
            StoreItemName = storeItem.StoreItemName;
            StoreItemRarity = storeItem.StoreItemRarity;
            StoreItemPrice = storeItem.StoreItemPrice;
            StoreItemProbability = storeItem.StoreItemProbability;
            StoreItemSold = false;

            ForSale();
        }
		#endregion

		/// <summary>
		/// Prints itemname with correct color based on rarity.
		/// </summary>
		/// <returns>StoreItemName</returns>
		#region Prints to rarity color
		public string ToColor()
		{
			if (StoreItemRarity == "Legendary")
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
			} else if (StoreItemRarity == "Epic")
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
			} else if (StoreItemRarity == "Rare")
			{
				Console.ForegroundColor = ConsoleColor.DarkCyan;
			} else
			{
				Console.ForegroundColor = ConsoleColor.White;
			}
			return StoreItemName;
		}
		#endregion

		/// <summary>
		/// Prints itemname with ToColor(), up for sale + price of item
		/// </summary>
		#region Prints entire string with rarity color
		public void ForSale()
		{
            Console.Write("[" + ToColor() + "]");
            Console.ResetColor();
            Console.WriteLine(" was put up for sale for $" + StoreItemPrice);
        }
		#endregion
	}
}
