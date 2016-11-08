using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UDBase.Controllers.InventorySystem.UI {
	[RequireComponent(typeof(Text))]
	public class ItemPackView:MonoBehaviour {
		public string FormatLine = "";
		public string HolderName = "";
		public string PackName   = "";

		Text _text = null;

		void Start() {
			Init();

			var item = Inventory.GetItem<SimpleItem>(HolderName, "item_1");
			Inventory.RemoveItem(HolderName, item);
		}

		void Init() {
			_text = GetComponent<Text>();
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
