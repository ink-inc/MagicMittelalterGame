using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    public abstract class ThemeTarget : MonoBehaviour
    {
        [Header("Copy this value to 'Property Name'")]
        public string copyName;

        [Space(30)]
        //[HideInInspector]
        public string propertyName = "Please select property";

        private void Awake()
        {
            Refresh();
        }

        public string GetName()
        {
            return propertyName;
        }

        public Color GetColor()
        {
            Logger.log("Getting color: " + GetName() + " from: " + gameObject.name);
            return ThemeManager.GetColorByName(GetName());
        }

        public Color GetColor(string name)
        {
            Logger.log("Getting color: " + name + " from: " + gameObject.name);
            return ThemeManager.GetColorByName(name);
        }

        public abstract void Refresh();
    }
}