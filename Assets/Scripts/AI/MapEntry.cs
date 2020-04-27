using System.Collections.Generic;

namespace AI
{
    public class MapEntry
    {
        public MapEntry(List<float> attributes)
        {
            Attributes = attributes;
        }

        public List<float> Attributes { get; }

        public int Dimension() => Attributes.Count;
    }
}