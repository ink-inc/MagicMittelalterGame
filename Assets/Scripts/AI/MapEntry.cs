using System.Collections.Generic;

namespace AI
{
    public class MapEntry
    {
        public MapEntry(List<float> attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        /// The wrap float attributes of an object.
        /// </summary>
        public List<float> Attributes { get; }

        /// <summary>
        /// The number of attributes.
        /// </summary>
        /// <returns>Integer value</returns>
        public int Dimension() => Attributes.Count;
    }
}