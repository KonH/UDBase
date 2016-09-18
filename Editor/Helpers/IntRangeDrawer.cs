using UnityEngine;
using UnityEditor;
using System.Collections;
using UDBase.Helpers;

namespace Editors {
	[CustomPropertyDrawer(typeof(IntRange))]
	public class IntRangeDrawer:PropertyDrawer {
		BaseRangeDrawer _editor = new BaseRangeDrawer();

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			_editor.OnGUI(position, property, label);
		}
	}
}
