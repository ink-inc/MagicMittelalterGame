using UnityEngine;

namespace AI
{
    public class AiWrapperImpassable : AiWrapper
    {
        public new MapEntry MapEntry => new MapEntry(null);

        public new Vector3 Position => transform.position;
    }
}