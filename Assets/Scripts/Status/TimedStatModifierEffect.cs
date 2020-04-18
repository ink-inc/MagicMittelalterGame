using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Status
{
    /// <summary>
    /// A temporary StatusEffect which applies a list of StatModifiers while active.
    /// </summary>
    [CreateAssetMenu(menuName = "StatusEffect/TimedStatModifier")]
    public class TimedStatAttributeModifierEffect : TimedEffect
    {
        [Tooltip("Modifiers to apply")] public List<StatModifier> modifiers;

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