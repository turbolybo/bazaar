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
		public StoreItem(string name, string rarity, int price)
		{
			StoreItemName = name;
			StoreItemRarity = rarity;
			StoreItemPrice = price;
			StoreItemSold = false;

			ForSale();
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
				Console.ForegroundColor = ConsoleColor.Blue;
			} else
			{
				Console.ForegroundColor = ConsoleColor.White;
			}
			return StoreItemName;
		}

		public void ForSale()
		{
			Console.Write("[" + ToColor() + "]");
			Console.ResetColor();
			Console.WriteLine(" was put up for sale for $" + StoreItemPrice);
		}
	}
	
}
