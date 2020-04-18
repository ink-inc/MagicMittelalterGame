using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DropDownEditor : Editor
{
    [CustomEditor(typeof(DropDown))]
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DropDown script = (DropDown)target;

        GUIContent arrayLabel = new GUIContent("Array");
        script.arrayIndex = EditorGUILayout.Popup(arrayLabel, script.arrayIndex, script.array);

        GUIContent arrayList = new GUIContent("List");
        script.listIndex = EditorGUILayout.Popup(arrayList, script.listIndex, script.list.ToArray());
    }
}