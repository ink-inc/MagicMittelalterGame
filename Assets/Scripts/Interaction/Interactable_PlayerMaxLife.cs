using Status;
using UnityEngine;

[AddComponentMenu("Interaction/Interactable/PlayerMaxLife")]
public class Interactable_PlayerMaxLife : Interactable
{
    public StatusEffectHolder holder;
    public float value;

    public override void interact()
    {
        holder.AddEffect(new MaxHealthBoostEffect(value));
    }
}