using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.InventorySystem.UI {
	public class HolderItemsView: MonoBehaviour {

		public HolderItemsView Transition = null;
		public ItemView        ItemPrefab = null;
		public string          HolderName = "";

		List<ItemView> _views = new List<ItemView>();

		protected virtual void OnEnable() {
			Events.Subscribe<Inv_HolderChanged>(this, OnHolderChanged);
		}

		protected virtual void OnDisable() {
			Events.Unsubscribe<Inv_HolderChanged>(OnHolderChanged);
		}

		protected virtual void OnHolderChanged(Inv_HolderChanged e) {
			if( e.HolderName == HolderName ) {
				Setup();
			}
		}

		protected void Start() {
			Setup();
		}

		void Setup() {
			Clear();
			Fill();
		}

		protected virtual void Clear() {
			for(int i = 0; i < _views.Count; i++) {
				_views[i].gameObject.SetActive(false);
			}
			_views.Clear();
		}

		public virtual void Fill() {
			var items = Inventory.GetHolderItems(HolderName);
			if( items != null ) {
				for( int i = 0; i < items.Count; i++ ) {
					var instance = Instantiate(ItemPrefab) as ItemView;
					if( instance ) {
						instance.Init(this, items[i]);
						instance.transform.SetParent(transform);
						instance.transform.localScale = ItemPrefab.transform.localScale;
						_views.Add(instance);
					}
				}
			}
		}
	}
}
