using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThemeTarget : MonoBehaviour
{
    public string group;

    public Color GetColor()
    {
        return ThemeManager.GetColorByGroup(group);
    }

    public Color GetColor(string addition)
    {
        return ThemeManager.GetColorByGroup(group + "_" + addition);
    }

    public abstract void Refresh();
}