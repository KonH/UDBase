using System;

namespace UDBase.Editor.Tools.EnumUtility {
	public class EnumInfo {
		public Type                BaseType { get; private set; }
		public EnumValueDictionary Values   { get; private set; }

		public EnumInfo(Type type) {
			BaseType = type;
			Values   = new EnumValueDictionary();
		}

		public bool TryAddValue(string key, int value) {
			return Values.TryAddValue(key, value);
		}

		public void ReOrder() {
			Values.ReOrder();
		}
	}
}