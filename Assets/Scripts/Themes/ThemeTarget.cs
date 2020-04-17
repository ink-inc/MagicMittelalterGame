using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    public abstract class ThemeTarget : MonoBehaviour
    {
        public new string name;

        private void Awake()
        {
            Refresh();
        }

        public Color GetColor()
        {
            return ThemeManager.GetColorByName(name);
        }

        public Color GetColor(string name)
        {
            return ThemeManager.GetColorByName(name);
        }

        public abstract void Refresh();
    }
}