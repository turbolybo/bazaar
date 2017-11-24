using System;

namespace Bazaar
{
	class Customer
	{
        // Customer properties
		public string CustomerName { get; private set; }
		public int CustomerBalance { get; private set; }

        // Lock object used for locking when multithreading.
        private static readonly Object _customerLock = new Object();

        // Constructor
        public Customer(string name, int balance)
		{
			CustomerName = name;
			CustomerBalance = balance;
		}

        // Buy function that is run whith multithreading
        public void BuyItem(object objitem)
        {

            // Locks the function when in use.
            lock (_customerLock)
            {
                // Casts input object to StoreItem object.
                StoreItem item = (StoreItem)objitem;

                // Checks if the Item is already sold.
                if (item.StoreItemSold)
                {
                    Console.WriteLine("	" + CustomerName + " tried purchasing " + item.StoreItemName + " but it was already sold.");
                }
                // Checks to see if the customer has enough balance to buy the Item.
                else if (CustomerBalance < item.StoreItemPrice)
                {
                    Console.WriteLine("	" + CustomerName + " tried purchasing " + item.StoreItemName + " but didn't have enough balance");
                }
                // If none of the above, purchaces the Item.
                else
                {
                    // Prints the information about the purchase.
                    Console.Write("	" + CustomerName + " bought ");
                    Console.Write("[" + item.ToColor() + "]");
                    Console.ResetColor();
                    Console.Write(" for $ " + item.StoreItemPrice);

                    // Withdraws money from the customers balance.
                    CustomerBalance -= item.StoreItemPrice;
                    Console.WriteLine(" and now have balance: " + CustomerBalance);

                    // Sets item to sold.
                    item.StoreItemSold = true;

                }
            }
        }
    }
}
