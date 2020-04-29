using System.Collections.Generic;
using System.Linq;

namespace AI
{
    public class MapEntry
    {
        private readonly Dictionary<string, float> _attributes;

        public MapEntry(Dictionary<string, float> attributes)
        {
            _attributes = attributes;
        }

        /// <summary>
        /// The wrap float attributes of an object.
        /// </summary>

        public List<float> Attributes => _attributes != null ? _attributes.Values.ToList() : new List<float>();

        /// <summary>
        /// The number of attributes.
        /// </summary>
        /// <returns>Integer value</returns>
        public int Dimension() => Attributes.Count;
    }
}