using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Theme/Target/Image")]
public class ThemeTarget_Image : ThemeTarget
{
    public override void Refresh()
    {
        Image image = GetComponent<Image>();
        image.color = GetColor();
    }
}