using System;

namespace Stat
{
    /// <summary>
    /// StatModifier calculation type.
    /// </summary>
    public enum StatModifierType
    {
        /// <summary>
        /// _Add_ the modifying value to the base value.
        /// </summary>
        Additive,

        /// <summary>
        /// Collect all of these percentages and then multiply by it.
        /// </summary>
        AdditivePercentage,

        /// <summary>
        /// 
        /// </summary>
        Multiplicative
    }

    public class StatModifier
    {
        public StatAttribute Owner { get; set; }

        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                MarkDirty();
            }
        }

        public readonly StatModifierType Type;
        public readonly object Source;

        private float _value;

        public StatModifier(float value, StatModifierType type, object source)
        {
            Value = value;
            Type = type;
            Source = source;
        }

        public float Apply(float @base, float value)
        {
            switch (Type)
            {
                case StatModifierType.Additive:
                    return value + Value;
                case StatModifierType.AdditivePercentage:
                    return @base * (1.0f + Value);
                case StatModifierType.Multiplicative:
                    return value * (1.0f + Value);
                default:
                    throw new InvalidOperationException("type not supported");
            }
        }

        public void MarkDirty()
        {
            Owner?.MarkDirty();
        }
    }
}