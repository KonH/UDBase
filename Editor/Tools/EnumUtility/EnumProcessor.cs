using System;
using UnityEngine;
using UDBase.Utils;

namespace UDBase.Editor.Tools.EnumUtility {
	public class EnumProcessor {
		
		public virtual bool TryProcessAttributes(Type type, object[] attrs, EnumInfoContainer container) {
			foreach (var attr in attrs) {
				var enumInputAttr = (attr as CompositeEnumAttribute);
				if (enumInputAttr != null) {
					var baseType = enumInputAttr.BaseType;
					if (!TryAddEnumInfo(type, baseType, container)) {
						return false;
					}
				}
			}
			ReOrderValues(container);
			return true;
		}

		protected virtual void ReOrderValues(EnumInfoContainer container) {
			foreach (var value in container.Values) {
				value.ReOrder();
			}
		} 
		
		protected virtual bool TryAddEnumInfo(Type partialType, Type baseType, EnumInfoContainer container) {
			if (!baseType.IsEnum) {
				Debug.LogErrorFormat("[EnumUtility] CompositeEnumAttribute: only enum is supported as type parameter! (invalid type: {0})", partialType);
				return false;
			}
			var info = container.GetOrCreateInfo(baseType, container);
			var names = Enum.GetNames(partialType);
			var values = Enum.GetValues(partialType);
			for (int i = 0; i < names.Length; i++) {
				var key = names[i];
				var value = (int)values.GetValue(i);
				if(!TryAddEnumValue(info, key, value, partialType)) {
					return false;
				}
			}
			return true;
		}
		
		protected virtual bool TryAddEnumValue(EnumInfo info, string key, int value, Type partialType) {
			var result = info.TryAddValue(key, value);
			if (!result) {
				ReportConflict(info, partialType, key, value);
			}
			return result;
		}
		
		protected virtual void ReportConflict(EnumInfo info, Type newType, string key, int value) {
			string conflictInfo = null;
			if (info.Values.ContainsKey(key)) {
				conflictInfo = string.Format("duplicated key \"{0}\"", key);
			}
			if (info.Values.ContainsValue(value)) {
				if (conflictInfo != null) {
					conflictInfo += ", ";
				}
				conflictInfo += string.Format("duplicated value: {0}", value);
			}
			Debug.LogErrorFormat("[EnumUtility] Enum type {0} has conflicts in {1}: {2}!", info.BaseType, newType, conflictInfo);
		}
	}
}
