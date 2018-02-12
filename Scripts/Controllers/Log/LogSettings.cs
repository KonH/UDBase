using System;
using System.Collections.Generic;
using Rotorz.Games.Reflection;

namespace UDBase.Controllers.LogSystem {
	[Serializable]
	public class LogNode {
		[ClassImplements(typeof(ILogContext))]
		public ClassTypeReference Context;
		public bool               Enabled;
	}

	[Serializable]
	public class CommonLogSettings {
		public bool          EnabledByDefault = false;
		public List<LogNode> Nodes            = new List<LogNode>();

		public bool IsContextEnabled(ILogContext context) {
			var contextType = context.GetType();
			foreach ( var node in Nodes ) {
				if ( node.Context == contextType ) {
					return node.Enabled;
				}
			}
			return EnabledByDefault;
		}
	}
}
