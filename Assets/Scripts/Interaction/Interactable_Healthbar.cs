using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Interaction/Interactable/IncreaseHealth")]
public class Interactable_Healthbar : Interactable
{
    public PlayerHealthbar playerHealthbar;
    public PlayerProperties playerProp;
    public int value;

    public override void interact()
    {
        playerProp.SetHealth(Mathf.Clamp(playerProp.GetHealth() + value, 0, playerProp.GetMaxHealth())); //changes players current health
        playerHealthbar.SetHealth(playerProp.GetHealth());       //adjusts player healthbar
    }
}