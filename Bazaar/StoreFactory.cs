using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar
{
	class StoreFactory
	{
		#region variables

		public string StoreName { get; private set; }

		// Lists with names, rarity and price of items
		List<string> allNames = new List<string>();
		List<string> allRarities = new List<string>();
		List<int> allPrices = new List<int>();
		Random randItem = new Random();
        			
		// List of all StoreItems
		List<StoreItem> allObjects = new List<StoreItem>();
        #endregion

        public StoreFactory(string name, int maxItems)
		{
			StoreName = name;
            List<StoreItem> storeItems = new List<StoreItem>();
            storeItems.Add(new StoreItem("Swift Spectral Tiger", "Legendary", 100));
            storeItems.Add(new StoreItem("Hearthstone pack #1", "Rare", 50));
            storeItems.Add(new StoreItem("Hearthstone pack #2", "Epic", 65));


			//Create StoreItems
			generateItems(storeItems, maxItems);
		}

        public void generateItems(List<StoreItem> storeItems, int maxItems)
        {
            for (int i = 0; i < maxItems; ++i)
            {
                int thisRandom = randItem.Next(storeItems.Count);
                Console.Write(StoreName + " has put ");
                allObjects.Add(new StoreItem(storeItems[i]));
            }
        }
    }	
}
