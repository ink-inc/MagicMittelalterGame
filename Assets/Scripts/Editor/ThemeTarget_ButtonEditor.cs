using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Theme
{
    //[CustomEditor(typeof(ThemeTarget_Button), true)]
    public class ThemeTarget_ButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ThemeTarget_Button script = (ThemeTarget_Button)target;

            GUIContent arrayLabel = new GUIContent("Theme Component Name");
            int index = EditorGUILayout.Popup(arrayLabel, ThemeManager.GetPropertyIndex(script.GetName(0)), ThemeManager.GetGroupNames());
            script.propertyName = ThemeManager.GetPropertyName(index);

            GUIContent arrayLabel2 = new GUIContent("Theme Component Name (Highlighted)");
            int index2 = EditorGUILayout.Popup(arrayLabel2, ThemeManager.GetPropertyIndex(script.GetName(1)), ThemeManager.GetGroupNames());
            script.propertyName_highlighted = ThemeManager.GetPropertyName(index2);

            GUIContent arrayLabel3 = new GUIContent("Theme Component Name (Pressed)");
            int index3 = EditorGUILayout.Popup(arrayLabel3, ThemeManager.GetPropertyIndex(script.GetName(2)), ThemeManager.GetGroupNames());
            script.propertyName_pressed = ThemeManager.GetPropertyName(index3);

            GUIContent arrayLabel4 = new GUIContent("Theme Component Name (Selected)");
            int index4 = EditorGUILayout.Popup(arrayLabel4, ThemeManager.GetPropertyIndex(script.GetName(3)), ThemeManager.GetGroupNames());
            script.propertyName_selected = ThemeManager.GetPropertyName(index4);

            GUIContent arrayLabel5 = new GUIContent("Theme Component Name (Disabled)");
            int index5 = EditorGUILayout.Popup(arrayLabel5, ThemeManager.GetPropertyIndex(script.GetName(4)), ThemeManager.GetGroupNames());
            script.propertyName_disabled = ThemeManager.GetPropertyName(index5);
        }
    }
}