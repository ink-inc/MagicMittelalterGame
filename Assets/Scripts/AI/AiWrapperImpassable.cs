using UnityEngine;

namespace AI
{
    public class AiWrapperImpassable : AiWrapper
    {
        public override MapEntry MapEntry => new MapEntry(null);
        

        public override Vector3 Position => transform.position;
    }
}