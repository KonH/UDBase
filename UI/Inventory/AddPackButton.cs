using UnityEngine;
using System.Collections;
using UDBase.UI.Common;
using UDBase.Controllers.SceneSystem;

namespace UDBase.Controllers.InventorySystem.UI {
	public class AddPackButton : ActionButton {
		public string HolderName = "";
		public string PackName   = "";
		public int    Count      = 0;

		public override bool IsVisible() {
			return true;
		}

		public override bool IsInteractable() {
			return true;
		}

		public override void OnClick() {
			Inventory.AddToPack(HolderName, PackName, Count);
			// Temp
			Scene.ReloadScene();
		}
	}
}
