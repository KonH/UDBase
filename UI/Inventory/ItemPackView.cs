using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.InventorySystem.UI {
	[RequireComponent(typeof(Text))]
	public class ItemPackView:MonoBehaviour {
		public string FormatLine = "";
		public string HolderName = "";
		public string PackName   = "";

		Text _text = null;

		void OnEnable() {
			Events.Subscribe<Inv_PackChanged>(this, OnPackChanged);
		}

		void OnDisable() {
			Events.Unsubscribe<Inv_PackChanged>(OnPackChanged);
		}

		void OnPackChanged(Inv_PackChanged e) {
			if( (e.HolderName == HolderName) && (e.PackName == PackName) ) {
				UpdateText();
			}
		}

		void Start() {
			Init();
			UpdateText();
		}

		void Init() {
			_text = GetComponent<Text>();
		}

		void UpdateText() {
			_text.text = GetLine();
		}

		string GetLine() {
			var count = GetCount();
			if( !string.IsNullOrEmpty(FormatLine) ) {
				return string.Format(FormatLine, count);
			}
			return count.ToString();
		}

		int GetCount() {
			return Inventory.GetPackCount(HolderName, PackName);
		}
	}
}
