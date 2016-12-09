using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem.UI {
	public abstract class ItemView: MonoBehaviour {
		public Text              NameText = null;
		public List<ItemControl> Controls = new List<ItemControl>();

		public virtual void Init(HolderItemsView owner, InventoryItem item) {
			InitName(item);
			InitControls(owner, item);
		}

		protected void InitName(InventoryItem item) {
			if( NameText ) {
				NameText.text = item.Name;
			}
		}

		protected void InitControls(HolderItemsView owner, InventoryItem item) {
			for( int i = 0; i < Controls.Count; i++ ) {
				Controls[i].Init(owner, item);
			}
		}
	}
}
