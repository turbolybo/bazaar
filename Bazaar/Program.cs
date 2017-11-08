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
			StoreItem spectral = new StoreItem("Swift Spectral Tiger", "Legendary", 50);
			Customer lyband = new Customer("Lyband", 100);
			lyband.buyItem(spectral);
			Console.ReadKey();
		}
	}
}
