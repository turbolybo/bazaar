using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar
{
	class Program
	{
		static void Main(string[] args)
		{
			Store tcg = new Store();

			/* What we want it to look like
			tcg.AddItem("Swift Spectral Tiger", "Legendary", 75);
			tcg.AddItem("Rare Card", "Rare", 15);
			tcg.AddItem("Test", "Epic", 5);
			*/

			// Create items
			StoreItem spectral = new StoreItem("Swift Spectral Tiger", "Legendary", 50);
			StoreItem test = new StoreItem("TCG", "Epic", 10);
			StoreItem test2 = new StoreItem("Dildo", "Rare", 5);
			spectral.printItemHelp();

			// Create customers
			Customer lyband = new Customer("Lyband", 100);
			Customer santom = new Customer("Santom", 100);

			// Try to buy item
			lyband.BuyItem(spectral);
			santom.BuyItem(spectral);
			Console.ReadKey();
		}
	}
}
