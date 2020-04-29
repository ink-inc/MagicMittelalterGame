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

        public List<float> Attributes(IEnumerable<string> attributeKeys)
        {
            return attributeKeys.Select(key => _attributes.TryGetValue(key, out float value) ? value : 0f).ToList();
        }
    }
}