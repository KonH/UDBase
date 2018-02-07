using System;

namespace UDBase.Utils {
	[AttributeUsage(AttributeTargets.Enum)]
	public class CompositeEnumAttribute:Attribute {

		public Type BaseType { get; private set; }

		public CompositeEnumAttribute(Type type) {
			BaseType = type;
		}
	}
}
