using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bazaar
{
	class Customer
	{
		public string CustomerName { get; private set; }
		public int CustomerBalance { get; private set; }
        private static readonly Object _customerLock = new Object();

        public Customer(string name, int balance)
		{
			CustomerName = name;
			CustomerBalance = balance;
		}

        public void BuyItem(object objitem)
        {

            // Check if customer have money and item is still available
            lock (_customerLock)
            {
                StoreItem item = (StoreItem)objitem;
                if (item.StoreItemPrice <= CustomerBalance && item.StoreItemSold == false)
                {
                    // Enough balance and not sold
                    Console.Write("	" + CustomerName + " bought ");
                    Console.Write("[" + item.ToColor() + "]");
                    Console.ResetColor();
                    Console.Write(" for $ " + item.StoreItemPrice);

                    // Withdraw cash
                    CustomerBalance -= item.StoreItemPrice;
                    Console.WriteLine(" and now have balance: " + CustomerBalance);
                    item.StoreItemSold = true;

                }

                // Not enough balance
                else if (CustomerBalance < item.StoreItemPrice)
                {
                    Console.WriteLine("	" + CustomerName + " tried purchasing " + item.StoreItemName + " but didn't have enough balance");
                }

                // Already sold
                else if (item.StoreItemSold)
                {
                    Console.WriteLine("	" + CustomerName + " tried purchasing " + item.StoreItemName + " but it was already sold.");
                }
            }
        }
    }
}
