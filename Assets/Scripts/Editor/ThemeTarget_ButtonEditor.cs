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

            GUIContent arrayLabel1 = new GUIContent("'Normal' Theme Component Name");
            int index1 = EditorGUILayout.Popup(arrayLabel1, ThemeManager.GetPropertyIndex(script.GetPropertyName(0)), ThemeManager.GetGroupNames());
            script.SetPropertyName(ThemeManager.GetPropertyName(index1), 0);

            GUIContent arrayLabel2 = new GUIContent("'Highlighted' Theme Component Name");
            int index2 = EditorGUILayout.Popup(arrayLabel2, ThemeManager.GetPropertyIndex(script.GetPropertyName(1)), ThemeManager.GetGroupNames());
            script.SetPropertyName(ThemeManager.GetPropertyName(index2), 1);

            GUIContent arrayLabel3 = new GUIContent("'Pressed' Theme Component Name");
            int index3 = EditorGUILayout.Popup(arrayLabel3, ThemeManager.GetPropertyIndex(script.GetPropertyName(2)), ThemeManager.GetGroupNames());
            script.SetPropertyName(ThemeManager.GetPropertyName(index3), 2);

            GUIContent arrayLabel4 = new GUIContent("'Selected' Theme Component Name");
            int index4 = EditorGUILayout.Popup(arrayLabel4, ThemeManager.GetPropertyIndex(script.GetPropertyName(3)), ThemeManager.GetGroupNames());
            script.SetPropertyName(ThemeManager.GetPropertyName(index4), 3);

            GUIContent arrayLabel5 = new GUIContent("'Disabled' Theme Component Name");
            int index5 = EditorGUILayout.Popup(arrayLabel5, ThemeManager.GetPropertyIndex(script.GetPropertyName(4)), ThemeManager.GetGroupNames());
            script.SetPropertyName(ThemeManager.GetPropertyName(index5), 4);
        }
    }
}