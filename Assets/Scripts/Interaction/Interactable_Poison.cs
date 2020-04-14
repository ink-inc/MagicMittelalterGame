﻿using Status;
using UnityEngine;

[AddComponentMenu("Interaction/Interactable/Poison")]
public class Interactable_Poison : Interactable
{
    public StatusEffectHolder holder;
    public float strength;
    public int duration;

    public override void interact()
    {
        holder.AddEffect(new PoisonEffect(strength, duration));
    }
}