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
		public StoreItem(string name, string rarity, int price)
		{
			StoreItemName = name;
			StoreItemRarity = rarity;
			StoreItemPrice = price;
		}

		public override string ToString()
		{
			string thisString = "";
			thisString += "[" + ToColor(StoreItemName) + "]";
			Console.ResetColor();
			thisString += " for $" + StoreItemPrice + ".";
			return thisString;

		}

		public string ToColor(string name)
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
				return name;
		}

	}
	
}
