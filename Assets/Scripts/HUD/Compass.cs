using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Text compassText;
    public RawImage compassImage;
    public Transform directionParent;

    private void FixedUpdate()
    {
        updateCompass();
    }

    private void updateCompass()
    {
        int direction = (int)directionParent.rotation.eulerAngles.y;
        compassText.text = "Direction: " + direction;

        compassImage.uvRect = new Rect(directionParent.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}