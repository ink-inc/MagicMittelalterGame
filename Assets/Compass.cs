using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public Text compassText;

    public Transform directionParent;

    private void FixedUpdate()
    {
        updateCompass();
    }

    private void updateCompass()
    {
        int direction = (int)directionParent.rotation.eulerAngles.y;
        compassText.text = "Direction: " + direction;
    }
}