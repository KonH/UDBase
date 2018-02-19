using System;
using System.Collections.Generic;
using UnityEngine;
using Rotorz.Games.Reflection;

namespace UDBase.Controllers.LogSystem {

	/// <summary>
	/// Node, which defined, need to show logs for specific context or not
	/// </summary>
	[Serializable]
	public class LogNode {
		/// <summary>
		/// Current log context
		/// </summary>
		[Header("Current log context")]
		[ClassImplements(typeof(ILogContext))]
		public ClassTypeReference Context;

		/// <summary>
		/// Is logs enabled for current context?
		/// </summary>
		[Header("Is logs enabled for current context?")]
		public bool Enabled;
	}

	/// <summary>
	/// Common log settings
	/// </summary>
	[Serializable]
	public class CommonLogSettings {
		/// <summary>
		/// Is logging for all contexts enabled by default?
		/// </summary>
		[Header("Is logging for all contexts enabled by default?")]
		public bool EnabledByDefault = false;

		/// <summary>
		/// The contexts with specific enabled state
		/// </summary>
		[Header("The contexts with specific enabled state")]
		public List<LogNode> Nodes = new List<LogNode>();

		internal bool IsContextEnabled(ILogContext context) {
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
