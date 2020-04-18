namespace Stat
{
    /// <summary>
    /// StatModifier calculation type.
    /// The order in which this Enum is laid out defines the calculation order!
    /// </summary>
    public enum StatModifierType
    {
        /// <summary>
        /// Add the modifying value to the base value.
        /// </summary>
        AdditiveAbsolute,

        /// <summary>
        /// Add all of the values from this category and then modify the base value by the calculated percentage.
        /// </summary>
        AdditiveRelative,

        /// <summary>
        /// Apply each value of this category as a percentage individually.
        /// </summary>
        MultiplicativeRelative
    }
}