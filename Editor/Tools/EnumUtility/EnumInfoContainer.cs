using System;
using System.Collections.Generic;

namespace UDBase.Editor.Tools.EnumUtility {
	public class EnumInfoContainer : Dictionary<Type, EnumInfo> {		
		public EnumInfo GetOrCreateInfo(Type baseType, EnumInfoContainer container) {
			EnumInfo info = null;
			if (!container.TryGetValue(baseType, out info)) {
				info = new EnumInfo(baseType);
				container.Add(baseType, info);
			}
			return info;
		}
	}
}