using System.Linq;
using System.Collections.Generic;

namespace UDBase.Editor.Tools.EnumUtility {
	public class EnumValueDictionary {

		public class EnumValueItem {
			public string Key   { get; private set; }
			public int    Value { get; private set; }

			public EnumValueItem(string key, int value) {
				Key   = key;
				Value = value;
			}
		}
		
		readonly List<EnumValueItem> _items = new List<EnumValueItem>();
		
		public bool ContainsKey(string key) {
			return _items.Any(item => item.Key == key);
		}

		public bool ContainsValue(int value) {
			return _items.Any(item => item.Value == value);
		}

		public bool TryAddValue(string key, int value) {
			if (ContainsKey(key) || ContainsValue(value)) {
				return false;
			}
			_items.Add(new EnumValueItem(key, value));
			return true;
		}

		public int Count {
			get { return _items.Count; }
		}

		public EnumValueItem this[int i] {
			get { return _items[i]; }
		}

		public IEnumerator<EnumValueItem> GetEnumerator() {
			return _items.GetEnumerator();
		}
		
		public void ReOrder() {
			_items.Sort((a, b) => a.Value.CompareTo(b.Value));
		}
	}
}
