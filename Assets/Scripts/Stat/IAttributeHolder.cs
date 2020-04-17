namespace Stat
{
    /// <summary>
    /// Helper interface to identify components that contain StatAttributes.
    /// </summary>
    public interface IAttributeHolder
    {
        /// <summary>
        /// Get the StatAttribute instance for the given StatAttributeType.
        /// </summary>
        /// <param name="attributeType">given StatAttributeType</param>
        StatAttribute GetAttribute(StatAttributeType attributeType);
    }
}