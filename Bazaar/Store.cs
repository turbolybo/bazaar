using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar
{
	class Store
	{
		public string StoreName { get; private set; }		

		public StoreItem AddItem(string name, string rarity, int price, int probability)
		{
			StoreItem thisItem = new StoreItem(name, rarity, price, probability);
			return thisItem;
		}
	}
}
