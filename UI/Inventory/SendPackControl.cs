using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDBase.Controllers.InventorySystem.UI {
	public class SendPackControl : PackControl {
		public Button SendButton = null;

		string          _fromHolder = null;
		string          _toHolder   = null;
		InventoryPack   _pack       = null;

		void Awake() {
			SendButton.onClick.AddListener(() => SendItem());
		}

		public override void Init(HolderPacksView owner, InventoryPack pack) {
			_fromHolder = owner.HolderName;
			_toHolder = owner.Transition.HolderName;
			_pack  = pack;
			SetButtonState(Inventory.CanSend(_fromHolder, _toHolder, _pack, 1));
		}

		void SetButtonState(bool state) {
			SendButton.interactable = state;
		}

		void SendItem() {
			Inventory.Send(_fromHolder, _toHolder, _pack, 1);
		}
	}
}
