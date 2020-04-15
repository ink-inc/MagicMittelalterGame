using UnityEngine;

[AddComponentMenu("Interaction/Interactable/IncreaseHealth")]
public class Interactable_Healthbar : Interactable
{
    public PlayerProperties playerProp;
    public float value;

    public override void interact()
    {
        playerProp.Heal(value); //changes players current health
    }
}