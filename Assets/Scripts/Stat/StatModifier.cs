using System;
using UnityEngine;
using Util;

namespace Stat
{
    [CreateAssetMenu(menuName = "Stat/Modifier")]
    public class StatModifier : ScriptableObject
    {
        public StatAttributeType attributeType;
        public StatModifierType modifierType;
        public Float value;

        public float Apply(float baseValue, float currentValue)
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

        public bool ApplyModifier(IStatModifierSource source, params IAttributeHolder[] holders)
        {
            foreach (var holder in holders)
            {
                var attribute = holder.GetAttribute(attributeType);
                Debug.Log($"{this}.ApplyModifier(): Try apply in {holder}, attribute={attribute}");
                if (attribute != null && attribute.AddModifier(this, source))
                {
                    return true;
                }
            }

            return false;
        }

        public bool RemoveModifier(IStatModifierSource source, params IAttributeHolder[] holders)
        {
            foreach (var holder in holders)
            {
                var attribute = holder.GetAttribute(attributeType);
                if (attribute != null && attribute.RemoveModifier(this, source))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
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