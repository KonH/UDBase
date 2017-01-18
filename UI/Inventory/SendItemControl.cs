using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase.Controllers.InventorySystem.UI {
	public class SendItemControl : ItemControl {
		public Button SendButton = null;

		string          _fromHolder = null;
		string          _toHolder   = null;
		InventoryItem   _item       = null;

		void Awake() {
			SendButton.onClick.AddListener(() => SendItem());
		}

		public override void Init(HolderItemsView owner, InventoryItem item) {
			_fromHolder = owner.HolderName;
			_toHolder = owner.Transition.HolderName;
			_item  = item;
			SetButtonState(Inventory.CanSend(_fromHolder, _toHolder, _item));
		}

		void SetButtonState(bool state) {
			SendButton.interactable = state;
		}

		void SendItem() {
			Inventory.Send(_fromHolder, _toHolder, _item);
		}
	}
}
