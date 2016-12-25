using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem.UI {
	public class PackView: MonoBehaviour {
		public Text              NameText    = null;
		public Text              CountText   = null;
		public string            CountFormat = "x{0}";
		public List<PackControl> Controls    = new List<PackControl>();

		public virtual void Init(HolderPacksView owner, InventoryPack pack) {
			InitName(pack);
			InitCount(pack);
			InitControls(owner, pack);
		}

		protected void InitName(InventoryPack pack) {
			if( NameText ) {
				NameText.text = pack.Name;
			}
		}

		protected void InitCount(InventoryPack pack) {
			if( CountText ) {
				var countText = pack.Count.ToString();
				if( !string.IsNullOrEmpty(countText) ) {
					countText = string.Format(CountFormat, countText);
				}
				CountText.text = countText;
			}
		}

		protected void InitControls(HolderPacksView owner, InventoryPack item) {
			for( int i = 0; i < Controls.Count; i++ ) {
				Controls[i].Init(owner, item);
			}
		}
	}
}
