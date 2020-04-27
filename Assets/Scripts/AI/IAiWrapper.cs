using UnityEngine;

namespace AI
{
    public abstract class AiWrapper : MonoBehaviour
    {
        public MapEntry MapEntry { get; }
        public Vector3 Position { get; }
    }

    public class AiWrapperImpassable : AiWrapper
    {
        public new MapEntry MapEntry => new MapEntry(null);

        public new Vector3 Position => transform.position;
    }
}