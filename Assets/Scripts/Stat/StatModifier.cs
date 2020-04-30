using System;
using UnityEngine;
using Util;

namespace Stat
{
    /// <summary>
    /// Modifier of a StatAttribute. May be absolute or relative.
    /// </summary>
    [CreateAssetMenu(menuName = "Stat/Modifier")]
    public class StatModifier : ScriptableObject
    {
        [Tooltip("Apply to which StatAttribute")]
        public AttributeType attributeType;

        [Tooltip("Modifier Type")] public StatModifierType modifierType;
        [Tooltip("Value")] public Float value;

        /// <summary>
        /// Get additive modification value.
        /// </summary>
        /// <param name="baseValue">base value</param>
        /// <param name="currentValue">current value</param>
        /// <returns>new value to add</returns>
        public float GetModification(float baseValue, float currentValue)
        {
            switch (modifierType)
            {
                case StatModifierType.AdditiveAbsolute:
                    return value.Value;
                case StatModifierType.AdditiveRelative:
                    return baseValue * value.Value;
                case StatModifierType.MultiplicativeRelative:
                    return currentValue * value.Value;
                default:
                    throw new InvalidOperationException("type not supported");
            }
        }

        /// <summary>
        /// Apply this modifier to the first matching StatAttribute.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="holders">holders to check</param>
        /// <returns>success</returns>
        public bool ApplyModifier(IStatModifierSource source, params AttributeHolder[] holders)
        {
            foreach (var holder in holders)
            {
                if (holder.TryGetAttribute<StatAttribute>(attributeType, out var attribute)
                    && ApplyModifier(source, attribute))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Apply this modifier to the given attribute.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="attribute">attribute</param>
        /// <returns>success</returns>
        public bool ApplyModifier(IStatModifierSource source, StatAttribute attribute)
        {
            return attribute != null && attribute.AddModifier(this, source);
        }

        /// <summary>
        /// Remove this modifier from the first matching StatAttribute.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="holders">holders to check</param>
        /// <returns>success</returns>
        public bool RemoveModifier(IStatModifierSource source, params AttributeHolder[] holders)
        {
            foreach (var holder in holders)
            {
                if (holder.TryGetAttribute<StatAttribute>(attributeType, out var attribute)
                    && RemoveModifier(source, attribute))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Remove this modifier to the given attribute.
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="attribute">attribute</param>
        /// <returns>success</returns>
        public bool RemoveModifier(IStatModifierSource source, StatAttribute attribute)
        {
            return attribute != null && attribute.RemoveModifier(this, source);
        }

        public string ToString(StatModifierInstance instance)
        {
            var val = value.Value;
            switch (modifierType)
            {
                case StatModifierType.AdditiveAbsolute:
                    return $"{val:+0.##;-0.##}";
                case StatModifierType.AdditiveRelative:
                    return $"{val:+0.##%;-0.##%}";
                case StatModifierType.MultiplicativeRelative:
                    return $"*{val:+0.##%;-0.##%}";
                default:
                    throw new InvalidOperationException("type not supported");
            }
        }
    }
}