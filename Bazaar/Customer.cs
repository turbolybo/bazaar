using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar
{
	class Customer
	{
		public string CustomerName { get; private set; }
		public int CustomerBalance { get; private set; }

		public Customer(string name, int balance)
		{
			CustomerName = name;
			CustomerBalance = balance;
		}

		public int buyItem(StoreItem item)
		{
			if(item.StoreItemPrice <= CustomerBalance)
			{
				// Enough balance
				Console.Write(CustomerName + " bought " + item.ToString());

				// Withdraw cash
				CustomerBalance -= item.StoreItemPrice;
				Console.WriteLine(" and now have balance: " + CustomerBalance);
				
				return 0;
			} else
			{
				// Not enough balance
				Console.WriteLine(CustomerName + " tried purchasing " + item.StoreItemName + " but didn't have enough balance");
				return 1;
			}
		}
	}
}
