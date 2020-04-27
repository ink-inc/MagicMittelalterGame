using UnityEngine;

namespace AI
{
    public abstract class AiWrapper : MonoBehaviour
    {
        public virtual MapEntry MapEntry { get; }
        public virtual Vector3 Position { get; }
    }
}