using Status;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class DebugScreen : MonoBehaviour
{
    public Transform coordinatesObject;
    public Text coordsText;

    public bool showCoord_x = true;
    public bool showCoord_y = false;
    public bool showCoord_z = true;
    public int digitsAfterPoint = 2;

    public Text fpsCounter;
    public int avgFrameRate;

    public Float speed;
    public Text speedText;

    public StatusEffectHolder effectHolder;
    public Text effectText;

    private void Start()
    {
        if (coordinatesObject == null)
        {
            Logger.log("No coordinates object for Debug screen... Looking for player controller...");
            PlayerController[] foundController = FindObjectsOfType<PlayerController>();
            if (foundController.Length == 1)
            {
                coordinatesObject = foundController[0].transform;
                Logger.log("Controller automatically assigned. Please fix that for later builds.");
            }
            else
            {
                Logger.log("No singleton controller found!");
            }
        }
    }

    private void Update()
    {
        coordsText.text = "";
        if (showCoord_x)
            coordsText.text += "X:" + coordinatesObject.position.x.ToString("F" + digitsAfterPoint);
        if (showCoord_y)
            coordsText.text += " Y:" + coordinatesObject.position.y.ToString("F" + digitsAfterPoint);
        if (showCoord_z)
            coordsText.text += " Z:" + coordinatesObject.position.z.ToString("F" + digitsAfterPoint);

        float current = 0;
        current = (int) (1f / Time.unscaledDeltaTime);
        avgFrameRate = (int) current;
        fpsCounter.text = "FPS: " + avgFrameRate.ToString();

        speedText.text = $"Speed: {speed}";

        effectText.text = "StatusEffects:\n";
        foreach (var effectInstance in effectHolder.Effects)
        {
            effectText.text += $" - {effectInstance}\n";
        }
    }
}