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

				//Item names in order
				allNames.Add("Swift Spectral Tiger");
				allNames.Add("Hearthstone pack #1");
				allNames.Add("Hearthstone pack #2");

				//Item rarities in order (sorted by item names)
				allRarities.Add("Legendary");
				allRarities.Add("Rare");
				allRarities.Add("Epic");

				//Item prices in order (sorted by item names)
				allPrices.Add(100);
				allPrices.Add(50);
				allPrices.Add(65);

				//Create StoreItems
				generateItems(maxItems);
			}

		// Makes new items and adds it to allObjects array.
		public void generateItems(int maxItems)
		{
			for (int i = 0; i < maxItems; ++i)
			{
				int thisRandom = randItem.Next(3);
				Console.Write(StoreName + " has put ");
				allObjects.Add(new StoreItem(allNames[thisRandom], allRarities[thisRandom], allPrices[thisRandom]));
			}
		}
	}	
}
