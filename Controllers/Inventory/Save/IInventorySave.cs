using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventorySave {

		void            Setup(List<InventoryHolder> defaultHolders, Dictionary<string, string> nameToTypes);
		InventoryHolder GetHolder(string name);
		void            AddHolder(InventoryHolder holder);
		void            SaveChanges();
	}
}
