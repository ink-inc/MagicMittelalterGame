using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AiWrapper : MonoBehaviour
    {
        public AiWrapper(List<string> attributeKeys)
        {
            MapEntry = SetMapEntry(attributeKeys);
            Transform localTransform = transform;
            Position = localTransform.position;
            Size = localTransform.localScale;
        }

        private MapEntry SetMapEntry(List<string> attributeKeys)
        {
            throw new System.NotImplementedException();
        }

        public MapEntry MapEntry { get; }
        public Vector3 Position { get; }
        public Vector3 Size { get; }
    }
}