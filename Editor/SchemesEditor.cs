using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;

namespace UDBase.Editor {
	public class SchemesEditor : EditorWindow {
		enum State {
			Start,
			NewSchemeScript
		}
			
		State        _state         = State.Start;
		List<string> _schemes       = null;
		string       _newSchemeName = "";

		void OnGUI() {
			DrawState(_state);
		}

		void DrawState(State state) {
			switch( state ) {
				case State.Start: {
					DrawState_Start();
				}
				break;

				case State.NewSchemeScript: {
						DrawState_NewSchemeScript();
					}
				break;
			}
		}

		void DrawState_Start() {
			GUILayout.BeginVertical();
			DrawSchemes();
			if( GUILayout.Button("Update") ) {
				SchemesTool.UpdateSchemes();
				UpdateSchemes();
			}
			if( GUILayout.Button("Add new scheme") ) {
				_state = State.NewSchemeScript;
				_newSchemeName = "";
			}
			GUILayout.EndVertical();
		}

		void DrawSchemes() {
			if( _schemes == null ) {
				UpdateSchemes();
			}
			for( int i = 0; i < _schemes.Count; i++ ) {
				DrawScheme(_schemes[i]);
			}
		}

		void UpdateSchemes() {
			_schemes = SchemesTool.GetSchemes();
		}

		void DrawScheme(string name) {
			GUILayout.BeginHorizontal();
			GUILayout.Label(name);
			if( !SchemesTool.IsActiveScheme(name) ) {
				if( GUILayout.Button("Switch", GUILayout.Width(100)) ) {
					SchemesTool.SwitchScheme(name);
				}
			} else {
				GUILayout.Space(104);
			}
			if( name != UDBaseConfig.SchemeDefaultName ) {
				if( GUILayout.Button("Remove", GUILayout.Width(100)) ) {
					SchemesTool.RemoveScheme(name);
					UpdateSchemes();
				}
			} else {
				GUILayout.Space(104);
			}
			GUILayout.EndHorizontal();
		}

		void DrawState_NewSchemeScript() {
			GUILayout.BeginVertical();
			if( GUILayout.Button("Back") ) {
				_state = State.Start;
			}
			GUILayout.Label("Name:");
			_newSchemeName = GUILayout.TextArea(_newSchemeName);
			if( _newSchemeName.Length > 0) {
				if( GUILayout.Button("Create script") ) {
					SchemesTool.CreateSchemeScript(_newSchemeName);
					_state = State.Start;
				}
			}
			GUILayout.EndVertical();
		}
	}
}
