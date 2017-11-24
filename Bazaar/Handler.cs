using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
			customers.Add(new Customer("Lyband", 1000));
			customers.Add(new Customer("lanalf", 1000));
		}
		public void Start()
		{
			MultiThreading();
			Sleep();
		}
		public void MultiThreading()
		{ 
            // Initializing and starting transaction threads for TCG shop
            for (int i = 0; i < 10; i++)
            {
                Console.Write("\n");
                stores.tcg.generateItems(stores.tcg.storeItems, 1);
                Thread.Sleep(1000);
                DoTransactions(customers, stores.tcg.allObjects[i]);
                Thread.Sleep(500);
                Console.Write("\n");
                stores.hs.generateItems(stores.hs.storeItems, 1);
                Thread.Sleep(1000);
                DoTransactions(customers, stores.hs.allObjects[i]);
                Thread.Sleep(500);
            }
		}

		public void Sleep()
		{
			System.Threading.Thread.Sleep(50);
			Console.Write("\nPress any key to continue...");
			Console.ReadKey();
		}

        // Multithreading function. Performs the transactions.
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
	}
}
