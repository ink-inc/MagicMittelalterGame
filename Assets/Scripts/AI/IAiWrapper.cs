using UnityEngine;

namespace AI
{
    public abstract class AiWrapper : MonoBehaviour
    {
        public MapEntry MapEntry { get; }
        public Vector3 Position { get; }
    }
}