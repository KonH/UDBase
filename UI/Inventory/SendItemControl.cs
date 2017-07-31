using UnityEngine.UI;

namespace UDBase.Controllers.InventorySystem.UI {
	public class SendItemControl : ItemControl {
		public Button SendButton;

		string          _fromHolder;
		string          _toHolder;
		InventoryItem   _item;

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
