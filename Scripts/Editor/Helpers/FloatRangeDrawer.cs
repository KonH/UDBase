using UnityEngine;
using UnityEditor;
using UDBase.Helpers;

namespace UDBase.EditorTools {
	[CustomPropertyDrawer(typeof(FloatRange))]
	public class FloatRangeDrawer:PropertyDrawer {
		readonly BaseRangeDrawer _editor = new BaseRangeDrawer();

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_editor.OnGUI(position, property, label);
		}
	}
}
