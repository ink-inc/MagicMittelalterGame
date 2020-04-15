namespace Stat
{
    /// <summary>
    /// Helper interface to identify components that contain StatAttributes.
    /// </summary>
    public interface IAttributeHolder
    {
        /// <summary>
        /// Remove all StatModifiers from all StatAttributes which come from the given source.
        /// </summary>
        /// <param name="source">given source</param>
        void RemoveAllModifiersFrom(IStatModifierSource source);
    }
}