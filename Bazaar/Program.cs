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
	class Program
	{
        // Initializing thread array. 3 customers = 3 threads.
        private static Random rand = new Random();
        private static Thread[] threads = new Thread[100];


        static void Main(string[] args)
		{


			// Creating stores using a StoreFactory
			StoreFactory stores = new StoreFactory();

            #region Initializing customers

            // Creating 3 customers and adding them to a customer list.
            List<Customer> customers = new List<Customer>();

            Customer santom = new Customer("Santom", 100);
            customers.Add(santom);
            Customer lyband = new Customer("Lyband", 1000);
            customers.Add(lyband);
            Customer lanalf = new Customer("lanalf", 1000);
            customers.Add(lanalf);

            #endregion

            #region Multithreading

            // Initializing and starting transaction threads for TCG shop
            for (int i = 0; i < 10; i++)
            {
                
                stores.tcg.generateItems(stores.tcg.storeItems, 1);
                Thread.Sleep(1000);
                DoTransactions(customers, stores.tcg.allObjects[i]);
                
                Thread.Sleep(500);
            }

            // Initializing and starting transaction threads for HS shop
            for (int i = 0; i < 10; i++)
            {
                
                stores.hs.generateItems(stores.hs.storeItems, 1);
                Thread.Sleep(1000);
                DoTransactions(customers, stores.hs.allObjects[i]);
                
                Thread.Sleep(500);
            }

            #endregion

            // Mainthread delay. Sleeping the code before "Press any key..." appears.
            System.Threading.Thread.Sleep(50);

            // Pause
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
                //Thread.Sleep(500);

                threads[j].Start(storeItem);
            }

            

        }
	}
}
