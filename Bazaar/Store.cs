﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar
{
	class Store
	{
		#region variables

		public string StoreName { get; private set; }
        public double StoreBalance { get; set; }

        // Lists with names, rarity and price of items
        List<string> allNames = new List<string>();
		List<string> allRarities = new List<string>();
		List<int> allPrices = new List<int>();
		Random rand = new Random();

		// List of all StoreItems
		public List<StoreItem> allObjects = new List<StoreItem>();
		public List<StoreItem> storeItems = new List<StoreItem>();
		#endregion

		public Store(string name)
		{
			StoreName = name;
            StoreBalance = 0;
			//storeItems.Add(new StoreItem("Swift Spectral Tiger", "Legendary", 100, 10));
			//storeItems.Add(new StoreItem("Hearthstone pack #1", "Rare", 50, 60));
			//storeItems.Add(new StoreItem("Hearthstone pack #2", "Epic", 65, 30));

			//addItem("Test", "Legendary", 10, 100);

			//Create StoreItems
			//generateItems(storeItems, maxItems);
		}

		public void addItem(string name, string rarity, int price, int probability)
		{
			storeItems.Add(new StoreItem(name, rarity, price, probability));
		}

		public void generateItems(List<StoreItem> storeItems, int maxItems)
		{
			int totalProbability = getTotalProbability(storeItems);

			for (int i = 0; i < maxItems; i++)
			{
				int randNum = rand.Next(totalProbability) + 1;
				int probabilityChecker = totalProbability;
				int currentItem = storeItems.Count - 1;
				while (probabilityChecker > 0 && currentItem >= 0)
				{
					probabilityChecker -= storeItems[currentItem].StoreItemProbability;
					if (randNum > probabilityChecker)
					{

						Console.Write(StoreName + " has put ");
						allObjects.Add(new StoreItem(storeItems[currentItem]));
						break;
					}
					currentItem--;
				}


			}
		}

        public void UpdateStoreBalance(StoreItem item)
        {

            if (item.StoreItemSold == true)
            {
                StoreBalance += item.StoreItemPrice;
                Console.Write(StoreName + "'s balance is $" + StoreBalance + "\n");
            }

        }

		int getTotalProbability(List<StoreItem> storeItem)
		{
			int result = 0;
			for (int i = 0; i < storeItem.Count; i++)
			{
				result += storeItem[i].StoreItemProbability;
			}
			return result;
		}
	}
}
