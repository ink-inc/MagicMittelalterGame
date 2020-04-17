﻿using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Status
{
    [CreateAssetMenu(menuName = "StatusEffect/TimedStatAttributeModifier")]
    public class TimedStatAttributeModifierEffect : TimedEffect
    {
        public List<StatModifier> modifiers;

        public override void OnActive(StatusEffectInstance instance)
        {
            base.OnActive(instance);

            var attributeHolders = instance.Holder.GetComponents<IAttributeHolder>();
            foreach (var statModifier in modifiers)
            {
                statModifier.ApplyModifier(instance, attributeHolders);
            }
        }

        public override void OnInactive(StatusEffectInstance instance)
        {
            base.OnInactive(instance);

            var attributeHolders = instance.Holder.GetComponents<IAttributeHolder>();
            foreach (var statModifier in modifiers)
            {
                statModifier.RemoveModifier(instance, attributeHolders);
            }
        }
    }
}