using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Theme/Target/Button")]
public class ThemeTarget_Button : ThemeTarget
{
    public override void Refresh()
    {
        Button button = GetComponent<Button>();
        var colors = button.colors;
        colors.normalColor = GetColor("normal");
        colors.highlightedColor = GetColor("hightlighted");
        colors.pressedColor = GetColor("pressed");
        colors.selectedColor = GetColor("selected");
        button.colors = colors;
    }
}