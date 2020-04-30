using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Editor
{
    [CustomEditor(typeof(Logger))]
    public class LoggerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            Logger logger = (Logger)target;
            EditorGUILayout.LabelField("IMPORTANT: Every log file name should start with 'AutoLog' and end with '.txt'. (caseSensitive) This is important for Version Control.");
            base.OnInspectorGUI();
            if(GUILayout.Button("Write log file"))
            {
                Logger.writeLog();
            }
            if (GUILayout.Button("Clear log file"))
            {
                Logger.clear();
            }
        }
    }
}
#endif
