using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UDBase.Controllers.InventorySystem.UI {
	public abstract class ItemView: MonoBehaviour {
		public Text NameText = null;

		public virtual void Init(InventoryItem item) {
			if( NameText ) {
				NameText.text = item.Name;
			}
		}
	}
}
