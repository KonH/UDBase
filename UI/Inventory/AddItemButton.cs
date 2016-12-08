using UnityEngine;
using System.Collections;
using UDBase.UI.Common;
using UDBase.Controllers.SceneSystem;

namespace UDBase.Controllers.InventorySystem.UI {
	public class AddItemButton : ActionButton {
		public string HolderName = "";
		public string ItemName   = "";

		public override bool IsVisible() {
			return true;
		}

		public override bool IsInteractable() {
			return true;
		}

		public override void OnClick() {
			Inventory.AddItem(HolderName, ItemName);
			// Temp
			Scene.ReloadScene();
		}
	}
}
