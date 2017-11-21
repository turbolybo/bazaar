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

        private static Random rand = new Random();
        private static Thread[] threads = new Thread[20];


        static void Main(string[] args)
		{
            
			Store tcg = new Store();
            List<Customer> customers = new List<Customer>();
            /* What we want it to look like
            tcg.AddItem("Swift Spectral Tiger", "Legendary", 75);
            tcg.AddItem("Rare Card", "Rare", 15);
            tcg.AddItem("Test", "Epic", 5);
            */

            // Create items
            StoreItem spectral = new StoreItem("Swift Spectral Tiger", "Legendary", 50);
            StoreItem test = new StoreItem("TCG", "Epic", 10);
			StoreItem test2 = new StoreItem("Dildo", "Rare", 5);
			//spectral.printItemHelp();
                

            #region OldBuy

            // Create customers
            Customer lyband = new Customer("Lyband", 50);
            customers.Add(lyband);
			Customer santom = new Customer("Santom", 50);
            customers.Add(santom);
            Customer lanalf = new Customer("lanalf", 100);
            customers.Add(lanalf);

            #endregion

            List<Customer> shuffledCustomers = ShuffleCustomerList(customers);
            #region Multithread test
            // One transaction per person
            // Initializing transaction threads and starting.

            // Every customer will try to buy spectral
            DoTransactions(shuffledCustomers, spectral);
            shuffledCustomers = ShuffleCustomerList(shuffledCustomers);
            //DoTransactions(shuffledCustomers, test);

            #endregion

            //Console.Write("\nPress any key to continue...");
            Console.ReadKey();
		}

        // Function that shuffles a List of customers. Used for testing and proving threads.
        private static List<Customer> ShuffleCustomerList(List<Customer> list)
        {
            int size = list.Count;
            List<Customer> result = new List<Customer>();

            for (int i = 0; i < size; i++)
            {
                int r = rand.Next(size-i);
                result.Add(list[r]);
                list.Remove(list[r]);
            }
            return result;
        }

        private static void DoTransactions(List<Customer> customers, StoreItem storeItem)
        {
            for (int i = 0; i < customers.Count; ++i)
            {
                int index = i;
                //Thread t = new Thread(() => customers.ElementAt(index).BuyItem(storeItem));
                Thread t = new Thread(new ParameterizedThreadStart(customers[i].Buy));
                threads[index] = t;

                // Used for debug
                //Console.Write("Person: " + customers[i].CustomerName + " index: " + i + "\n");

            }
            for (int j = 0; j < 3; j++)
            {
                threads[j].Start(storeItem);
            }
        }
	}
}
