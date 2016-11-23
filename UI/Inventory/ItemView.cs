using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UDBase.Controllers.InventorySystem.UI {
	public abstract class ItemViewBase : MonoBehaviour {}

	public abstract class ItemView<TItem>: ItemViewBase where TItem:IInventoryItem {
		public Text NameText = null;

		public virtual void Init(TItem item) {
			if( NameText ) {
				NameText.text = item.Name;
			}
		}
	}
}
