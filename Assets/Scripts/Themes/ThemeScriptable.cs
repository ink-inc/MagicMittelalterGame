using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    public enum LoggingType
    { Info, Warning, Error }

    [System.Serializable]
    public struct ThemeComponent
    {
        public string name;
        public Color color;
    }

    [CreateAssetMenu(fileName = "NewTheme", menuName = "Theme/New Theme")]
    public class ThemeScriptable : ScriptableObject
    {
        [Tooltip("Name of the theme. Must be unique.")]
        public new string name;

        public LoggingType loggingType = LoggingType.Warning;

        public ThemeComponent[] themeComponents;

        public Color GetColorByName(string name)
        {
            foreach (ThemeComponent tc in themeComponents)
            {
                if (tc.name == name)
                {
                    return tc.color;
                }
            }
            string failedLogMessage = "ThemeComponent named '" + name + "' was not found in Theme '" + this.name + "'!";
            if (loggingType == LoggingType.Info)
                Logger.log(failedLogMessage);
            else if (loggingType == LoggingType.Warning)
                Logger.logWarning(failedLogMessage);
            else
                Logger.logError(failedLogMessage);
            return new Color();
        }
    }
}