using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    [CreateAssetMenu(fileName = "NewTheme", menuName = "Theme/New Theme")]
    public class ThemeScriptable : ScriptableObject
    {
        [Tooltip("Name of the theme. Must be unique.")]
        public new string name;

        public Color[] group1;

        public Color[] group2;
    }
}