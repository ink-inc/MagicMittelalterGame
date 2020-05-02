namespace Stat
{
    /// <summary>
    /// Interface to identify sources of StatModifiers.
    /// </summary>
    public interface IStatModifierSource
    {
        /// <summary>
        /// Get the name of this source.
        /// </summary>
        /// <returns>name</returns>
        string GetName();
    }
}