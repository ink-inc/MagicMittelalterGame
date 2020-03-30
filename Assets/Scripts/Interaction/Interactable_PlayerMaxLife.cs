using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_PlayerMaxLife : Interactable
{
    public PlayerHealthbar playerHealthbar;
    public PlayerProperties playerProp;
    public int value;

    public override void interact()
    {
        if (playerProp.GetMaxHealth() + value > 0)  //players max health should always be below zero
        {
            playerProp.SetMaxHealth(playerProp.GetMaxHealth() + value);     //increases/decreases player max life, depending on value
            playerHealthbar.SetHealth(playerProp.GetHealth());           //adjusts player healthbar
            playerProp.SetHealth(Mathf.Clamp(playerProp.GetHealth(), 0, playerProp.GetMaxHealth())); //reloads player current life if max life has been decreased below current life
        }
    }
}