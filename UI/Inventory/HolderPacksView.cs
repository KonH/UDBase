using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.InventorySystem.UI {
	public class HolderPacksView: MonoBehaviour {

		public HolderPacksView Transition = null;
		public PackView        PackPrefab = null;
		public string          HolderName = "";
		public List<string>    Ignores    = new List<string>();

		List<PackView> _views = new List<PackView>();

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

		protected virtual void Start() {
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
			var packs = Inventory.GetHolderPacks(HolderName);
			if( packs != null ) {
				for( int i = 0; i < packs.Count; i++ ) {
					if( Ignores.Contains(packs[i].Name) ) {
						continue;
					}
					var instance = Instantiate(PackPrefab) as PackView;
					if( instance ) {
						instance.Init(this, packs[i]);
						instance.transform.SetParent(transform);
						instance.transform.localScale = PackPrefab.transform.localScale;
						_views.Add(instance);
					}
				}
			}
		}
	}
}
