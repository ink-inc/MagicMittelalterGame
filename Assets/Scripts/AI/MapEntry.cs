using System.Collections.Generic;
using System.Linq;

namespace AI
{
    public class MapEntry
    {
        private readonly Dictionary<string, float> _attributes;
        private readonly int _size;

        public MapEntry(Dictionary<string, float> attributes)
        {
            _attributes = attributes;
            _size = _attributes.Count;
        }

        /// <summary>
        /// The wrap float attributes of an object.
        /// </summary>

        public List<float> Attributes(List<string> attributeKeys)
        {
            return attributeKeys.Select(key => _attributes.TryGetValue(key, out float value) ? value : 0f).ToList();
        }

        /// <summary>
        /// The number of attributes.
        /// </summary>
        /// <returns>Integer value</returns>
        public int Dimension() => _size;
        
    }
}