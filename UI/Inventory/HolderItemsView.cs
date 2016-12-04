using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem.UI {
	public class HolderItemsView: MonoBehaviour {
		
		public ItemView ItemPrefab = null;
		public string   HolderName = "";

		void Start() {
			Init();	
		}

		public virtual void Init() {
			var items = Inventory.GetHolderItems(HolderName);
			if( items != null ) {
				for( int i = 0; i < items.Count; i++ ) {
					var instance = Instantiate(ItemPrefab) as ItemView;
					instance.transform.SetParent(transform);
					if( instance ) {
						instance.Init(items[i]);
					}
				}
			}
		}
	}
}
