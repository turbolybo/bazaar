using System;
using System.Collections.Generic;
using System.Threading;

namespace Bazaar
{
	class Handler
	{
        // Initializing thread array. 3 customers = 3 threads.
        private static Random rand = new Random();
        private static Thread[] threads = new Thread[100];

		// Creating stores using a StoreFactory
		private List<Customer> customers = new List<Customer>();
		private StoreFactory stores = new StoreFactory();

		public Handler()
		{
			// Adding customers to list
			customers.Add(new Customer("Santom", 100));
			customers.Add(new Customer("Lyband", 50));
			customers.Add(new Customer("Lanalf", 75));
		}

		/// <summary>
		/// Start method. Program will not start shop sales until this is called. 
		/// </summary>
		#region Start
		public void Start()
		{
			MultiThreading();
			Sleep();
		}
		#endregion

		/// <summary>
		/// Using multithreading to make sure only one customer can buy one item.
		/// Sleeping between stores putting items up for sale.
		/// </summary>
		#region MultiThreading
		public void MultiThreading()
		{ 
            // Initializing and starting transaction threads for TCG shop
            for (int i = 0; i < 10; i++)
            {
				// TCG shop
                Console.Write("\n");
                stores.tcg.generateItems(stores.tcg.storeItems, 1);
                Thread.Sleep(50);
                DoTransactions(customers, stores.tcg.allObjects[i]);
                Thread.Sleep(1500);

				// Hearthstone shop
                Console.Write("\n");
                stores.hs.generateItems(stores.hs.storeItems, 1);
                Thread.Sleep(50);
                DoTransactions(customers, stores.hs.allObjects[i]);
                Thread.Sleep(1500);
            }
		}
		#endregion

		/// <summary>
		/// Sleep for debugging purposes.
		/// </summary>
		#region Sleep
		public void Sleep()
		{
			System.Threading.Thread.Sleep(50);
			Console.Write("\nPress any key to continue...");
			Console.ReadKey();
		}
		#endregion

		/// <summary>
		/// Method handling transaction between store and customer.
		/// Only one customer can buy an item put up for sale
		/// </summary>
		/// <param name="customers"></param>
		/// <param name="storeItem"></param>
		#region DoTransactions
		private static void DoTransactions(List<Customer> customers, StoreItem storeItem)
        {
            for (int i = 0; i < customers.Count; ++i)
            {
                Thread t = new Thread(new ParameterizedThreadStart(customers[i].BuyItem));
                threads[i] = t;
            }
            for (int j = 0; j < customers.Count; j++)
            {
                threads[j].Start(storeItem);
            }
        }
		#endregion
	}
}
