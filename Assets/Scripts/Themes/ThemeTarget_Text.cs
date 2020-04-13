using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Theme/Target/Text")]
public class ThemeTarget_Text : ThemeTarget
{
    public override void Refresh()
    {
        Text text = GetComponent<Text>();
        text.color = GetColor();
    }
}