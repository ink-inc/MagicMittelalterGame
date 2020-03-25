using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Healthbar : Interactable
{

    public PlayerHealthbar playerHealthbar;
    public PlayerProperties playerProp;
    public int value;
    public override void interact()
    {
        playerProp.SetHealth(Mathf.Clamp(playerProp.GetCurHealth() + value, 0, playerProp.GetMaxHealth())); //changes players current health
        playerHealthbar.SetHealth(playerProp.GetCurHealth());       //adjusts player healthbar
    }
}
