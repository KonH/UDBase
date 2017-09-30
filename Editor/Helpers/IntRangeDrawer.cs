using UnityEngine;
using UnityEditor;
using UDBase.Helpers;

namespace UDBase.EditorTools {
	[CustomPropertyDrawer(typeof(IntRange))]
	public class IntRangeDrawer:PropertyDrawer {
		readonly BaseRangeDrawer _editor = new BaseRangeDrawer();

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_editor.OnGUI(position, property, label);
		}
	}
}
