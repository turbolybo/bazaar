using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazaar
{
	class StoreFactory
	{
		public Store tcg = new Store("TCG Shop", 20);
		public Store hs = new Store("HS Shop", 20);
		public StoreFactory()
		{
		}
	}
}
