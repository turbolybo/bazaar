using System;
using System.Collections.Generic;

namespace Bazaar
{
	class Store
	{
		#region Variables and properties

		//Name of store 
		public string StoreName { get; private set; }

        // Lists with names, rarity and price of items
        List<string> allNames = new List<string>();
		List<string> allRarities = new List<string>();
		List<int> allPrices = new List<int>();
		Random rand = new Random();

		// List of all StoreItems
		public List<StoreItem> allObjects = new List<StoreItem>();
		public List<StoreItem> storeItems = new List<StoreItem>();
		#endregion

		#region Constructor
		public Store(string name)
		{
			StoreName = name;
		}
		#endregion

		/// <summary>
		/// Adds item to store list so it can pick between them when generating items.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="rarity"></param>
		/// <param name="price"></param>
		/// <param name="probability"></param>
		#region Add item to list
		public void addItem(string name, string rarity, int price, int probability)
		{
			storeItems.Add(new StoreItem(name, rarity, price, probability));
		}
		#endregion

		/// <summary>
		/// Generate X (maxItems) items based on the items in list. 
		/// Uses probability to generate item.
		/// </summary>
		/// <param name="storeItems"></param>
		/// <param name="maxItems"></param>
		#region Generate items from list
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
		#endregion

		/// <summary>
		/// Get the total probability for all items in list
		/// </summary>
		/// <param name="storeItem"></param>
		/// <returns></returns>
		#region Get total probability
		int getTotalProbability(List<StoreItem> storeItem)
		{
			int result = 0;
			for (int i = 0; i < storeItem.Count; i++)
			{
				result += storeItem[i].StoreItemProbability;
			}
			return result;
		}
		#endregion
	}
}
