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
            StoreItem storeItem1 = new StoreItem("Swift Spectral Tiger", "Legendary", 100);
            storeItems.Add(storeItem1);
            StoreItem storeItem2 = new StoreItem("Hearthstone pack #1", "Rare", 50);
            storeItems.Add(storeItem2);
            StoreItem storeItem3 = new StoreItem("Hearthstone pack #2", "Epic", 65);
            storeItems.Add(storeItem3);


			//Create StoreItems
			generateItems(storeItems);
		}

		// Makes new items and adds it to allObjects array.
		public void generateItems2(int maxItems)
		{
			for (int i = 0; i < maxItems; ++i)
			{
				int thisRandom = randItem.Next(3);
				Console.Write(StoreName + " has put ");
				allObjects.Add(new StoreItem(allNames[thisRandom], allRarities[thisRandom], allPrices[thisRandom]));
			}
		}

        public void generateItems(List<StoreItem> storeItems)
        {
            for (int i = 0; i < storeItems.Count; ++i)
            {
                int thisRandom = randItem.Next(storeItems.Count);
                Console.Write(StoreName + " has put ");
                allObjects.Add(new StoreItem(storeItems[i]));
            }
        }
    }	
}
