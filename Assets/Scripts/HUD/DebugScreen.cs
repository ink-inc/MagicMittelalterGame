using Character.Player;
using Stat;
using Status;
using UnityEngine;
using UnityEngine.UI;

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

    public AttributeHolder attributeHolder;
    public Text attributeText;

    public StatusEffectHolder effectHolder;
    public Text effectText;

    private int qualityIndex = 0;

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
        if (Input.GetKeyDown(KeyCode.Y))
        {
            QualitySettings.SetQualityLevel(qualityIndex, true);
            qualityIndex--;
            qualityIndex = qualityIndex % 6;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            QualitySettings.SetQualityLevel(qualityIndex, true);
            qualityIndex++;
            qualityIndex = qualityIndex % 6;
        }
        coordsText.text = "";
        if (showCoord_x)
            coordsText.text += "X:" + coordinatesObject.position.x.ToString("F" + digitsAfterPoint);
        if (showCoord_y)
            coordsText.text += " Y:" + coordinatesObject.position.y.ToString("F" + digitsAfterPoint);
        if (showCoord_z)
            coordsText.text += " Z:" + coordinatesObject.position.z.ToString("F" + digitsAfterPoint);

        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        fpsCounter.text = "FPS: " + avgFrameRate.ToString();

        var attributes = attributeHolder.GetAllAttributes();
        if (attributes.Count > 0)
        {
            attributeText.text = "Attributes:";
            foreach (var attribute in attributes)
            {
                attributeText.text += $"\n - {attribute}";
            }
        }
        else
        {
            attributeText.text = "";
        }

        var effects = effectHolder.GetActiveEffects();
        if (effects.Count > 0)
        {
            effectText.text = "Effects:";
            foreach (var effect in effects)
            {
                effectText.text += $"\n - {effect}";
            }
        }
        else
        {
            effectText.text = "";
        }
    }
}