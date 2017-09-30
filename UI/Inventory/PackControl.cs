using UnityEngine;

namespace UDBase.Controllers.InventorySystem.UI {
	public abstract class PackControl : MonoBehaviour {		
		public abstract void Init(HolderPacksView owner, InventoryPack pack);
	}
}