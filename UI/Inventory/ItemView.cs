using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase.Controllers.InventorySystem.UI {
	public class ItemView: MonoBehaviour {
		public Text              NameText;
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
