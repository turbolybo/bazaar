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
		public Store tcg = new Store("TCG Shop", 0);
		
		public Store hs = new Store("HS Shop", 0);
        
        public StoreFactory()
		{

			// Adding different TCG packs to TCG Shop
			tcg.addItem("Heroes of Azeroth", "Legendary", 50, 10);
			tcg.addItem("Dark Portal", "Epic", 25, 20);
			tcg.addItem("Fires of Outland", "Epic", 25, 20);
			tcg.addItem("Twilight of the Dragons", "Rare", 15, 25);
			tcg.addItem("Thrones of the Tides", "Rare", 15, 25);


			// Adding different card packs to HeartSthone Shop
			hs.addItem("Whispers of the Old Gods", "Rare", 10, 50);
			hs.addItem("Mean Streets of Gadgetzan", "Epic", 10, 30);
			hs.addItem("Journey to Un'Goro", "Legendary", 25, 10);
			hs.addItem("Knights of the Frozen Throne", "Legendary", 25, 10);
		}
	}
}
