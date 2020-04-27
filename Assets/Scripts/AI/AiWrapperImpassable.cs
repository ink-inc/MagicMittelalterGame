using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AiWrapperImpassable : AiWrapper
    {
        private readonly SortedDictionary<string, float> _attributes;

        public AiWrapperImpassable()
        {
            _attributes = new SortedDictionary<string, float> {{"type", 1f}};
        }

        public override MapEntry MapEntry => new MapEntry(_attributes);


        public override Vector3 Position => transform.position;
    }
}