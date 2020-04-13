using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[AddComponentMenu("Theme/Target/TMPText")]
public class ThemeTarget_TMPText : ThemeTarget
{
    public override void Refresh()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.color = GetColor();
    }
}