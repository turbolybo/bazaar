using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Bazaar
{
	[TestFixture]
	public class BazaarUnitTest
	{

		[TestCase]
		public void BuyItem()
		{
			Customer lyband16 = new Customer("Lyband16", 100);
			Assert.AreEqual(100, lyband16.CustomerBalance);
		}
	}
}
