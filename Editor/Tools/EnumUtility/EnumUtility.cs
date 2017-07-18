using System;
using System.Linq;
using System.Reflection;
using UnityEditor.Callbacks;
using UDBase.Utils;

namespace UDBase.Editor.Tools.EnumUtility {
	public class EnumUtility {
		
		static readonly string[] DefaultAssemblies = {
			"Assembly-CSharp",
			"Assembly-CSharp-Editor"
		};

		static readonly EnumUtility Instance = new EnumUtility();

		protected EnumProcessor Processor { get; private set; }
		protected EnumFormatter Formatter { get; private set; }
		protected EnumWriter    Writer    { get; private set; }

		string[] _assemblies = null;
		
		public EnumUtility(EnumProcessor processor, EnumFormatter formatter, EnumWriter writer, string[] assemblies) {
			Processor   = processor;
			Formatter   = formatter;
			Writer      = writer;
			_assemblies = assemblies;
		}

		public EnumUtility(string[] assemblies) {
			Processor   = new EnumProcessor();
			Formatter   = new EnumFormatter();
			Writer      = new EnumWriter(Formatter);
			_assemblies = assemblies;
		}

		public EnumUtility():this(DefaultAssemblies) {}
		
		[DidReloadScripts]
		static void OnDidReloadScripts() {
			Instance.TryUpdateCompositeEnums();
		}

		protected virtual Assembly[] GetAssemblies() {
			var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			var filteredAssemblies = allAssemblies.Where(assembly => _assemblies.Contains(assembly.GetName().Name));
			return filteredAssemblies.ToArray();
		}
		
		protected virtual void TryUpdateCompositeEnums() {
			var container = new EnumInfoContainer();
			var assemblies = GetAssemblies();
			foreach (var assembly in assemblies) {
				var types = assembly.GetTypes();
				foreach (var type in types) {
					var attrs = type.GetCustomAttributes(typeof(CompositeEnumAttribute), true);
					if (attrs.Length == 0) {
						continue;
					}
					if (!Processor.TryProcessAttributes(type, attrs, container)) {
						return;
					}
				}	
			}
			Writer.WriteEnums(container);
		}
	}
}
