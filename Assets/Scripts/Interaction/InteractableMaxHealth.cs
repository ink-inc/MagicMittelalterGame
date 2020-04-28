using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/MaxHealth")]
    public class InteractableMaxHealth : Interactable
    {
        public int value;

        public override void Interact(Interactor interactor)
        {
            var playerProp = interactor.GetComponent<PlayerProperties>();
            var playerHealthbar = playerProp.playerHealthbar;
            if (playerProp.GetMaxHealth() + value > 0)  //players max health should always be below zero
            {
                playerProp.SetMaxHealth(playerProp.GetMaxHealth() + value);     //increases/decreases player max life, depending on value
                playerProp.SetHealth(Mathf.Clamp(playerProp.GetHealth(), 0, playerProp.GetMaxHealth())); //reloads player current life if max life has been decreased below current life
            }
        }
    }
}