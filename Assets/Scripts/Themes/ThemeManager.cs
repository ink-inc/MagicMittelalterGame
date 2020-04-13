using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public static ThemeManager instance;

    public static Color GetColorByGroup(string group)
    {
        return new Color();
    }

    public void applyTheme()
    {
        ThemeTarget[] targets = FindObjectsOfType<ThemeTarget>();
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].Refresh();
        }
    }
}