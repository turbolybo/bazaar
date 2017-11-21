using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar
{
	class StoreItem
	{
		public string StoreItemName { get; private set; }
		public string StoreItemRarity { get; private set; }
		public int StoreItemPrice{ get; private set; }
		public bool StoreItemSold { get; set; }
        
        private readonly Object _itemLock = new Object();

        public StoreItem(string name, string rarity, int price)
		{
			StoreItemName = name;
			StoreItemRarity = rarity;
			StoreItemPrice = price;
			StoreItemSold = false;

			ForSale();
		}
        public StoreItem(StoreItem storeItem)
        {

                StoreItemName = storeItem.StoreItemName;
                StoreItemRarity = storeItem.StoreItemRarity;
                StoreItemPrice = storeItem.StoreItemPrice;
                StoreItemSold = false;

        }

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
		public void printItemHelp()
		{
			Console.WriteLine("\nItem rarities: ");

			//Legendary
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("[Legendary]");
			Console.ResetColor();

			//Epic
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("[Epic]");
			Console.ResetColor();

			//Rare
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("[Rare]");
			Console.ResetColor();
		}

		public void ForSale()
		{
            Console.Write("[" + ToColor() + "]");
            Console.ResetColor();
            Console.WriteLine(" was put up for sale for $" + StoreItemPrice);
        }
	}
	
}
