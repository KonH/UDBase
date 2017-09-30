using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IItemSource {
		void                       Load();
		InventoryItem              GetItem(string name);
		InventoryPack              GetPack(string name);
		List<InventoryHolder>      GetHolders();
		Dictionary<string, string> GetNames();
	}
}
