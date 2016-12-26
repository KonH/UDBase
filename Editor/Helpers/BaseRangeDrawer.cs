using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.Helpers {
	public class BaseRangeDrawer {
		float valuesOffset = 2.5f;

		public void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			var minWidth = 0.0f;
			var maxWidth = 0.0f;
			EditorStyles.label.CalcMinMaxWidth(new GUIContent(property.name), out minWidth, out maxWidth);
			var headerRect = new Rect(position);
			headerRect.width = maxWidth;
			EditorGUI.LabelField(headerRect, property.name);
			var start = property.FindPropertyRelative("Start");
			var end   = property.FindPropertyRelative("End");
			var valuesWidth = (position.width)/4 - valuesOffset;
			var startPos = new Rect(position);
			startPos.x = position.width/2;
			startPos.width = valuesWidth;
			var endPos = new Rect(startPos);
			endPos.x += valuesWidth + valuesOffset;
			DrawProperty(start, startPos);
			DrawProperty(end, endPos);
		}

		void DrawProperty(SerializedProperty property, Rect position) {
			if( property != null ) {
				switch( property.type ) {
					case "int": {
							property.intValue = EditorGUI.IntField(position, property.intValue);
						}
					break;

					case "float": {
							property.floatValue = EditorGUI.FloatField(position, property.floatValue);
						}
					break;
				}
			}
		}
	}
}
