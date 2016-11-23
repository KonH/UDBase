using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem.UI {
	public abstract class HolderItemsView<TItem> : MonoBehaviour where TItem:IInventoryItem {

		public ItemViewBase ItemPrefab = null;
		public string       HolderName = "";

		void Start() {
			Init();	
		}

		public virtual void Init() {
			var items = Inventory.GetHolderItems<TItem>(HolderName);
			if( items != null ) {
				for( int i = 0; i < items.Count; i++ ) {
					var instance = Instantiate(ItemPrefab) as ItemViewBase;
					instance.transform.SetParent(transform);
					var typedInstance = instance as ItemView<TItem>;
					if( typedInstance ) {
						typedInstance.Init(items[i]);
					}
				}
			}
		}
	}
}
