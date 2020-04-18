using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Theme
{
    [CustomEditor(typeof(ThemeTarget_Button), true)]
    public class ThemeTarget_ButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ThemeTarget_Button script = (ThemeTarget_Button)target;

            GUIContent arrayLabel = new GUIContent("Theme Component Name");
            script.arrayIndex = EditorGUILayout.Popup(arrayLabel, script.arrayIndex, ThemeManager.GetGroupNames());

            GUIContent arrayLabel2 = new GUIContent("Theme Component Name (Highlighted)");
            script.arrayIndex_highlighted = EditorGUILayout.Popup(arrayLabel2, script.arrayIndex_highlighted, ThemeManager.GetGroupNames());

            GUIContent arrayLabel3 = new GUIContent("Theme Component Name (Pressed)");
            script.arrayIndex_pressed = EditorGUILayout.Popup(arrayLabel3, script.arrayIndex_pressed, ThemeManager.GetGroupNames());

            GUIContent arrayLabel4 = new GUIContent("Theme Component Name (Selected)");
            script.arrayIndex_selected = EditorGUILayout.Popup(arrayLabel4, script.arrayIndex_selected, ThemeManager.GetGroupNames());
        }
    }
}