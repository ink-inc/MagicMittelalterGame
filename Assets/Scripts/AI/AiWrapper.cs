using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AiWrapper : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public void Start()
        {
            Transform localTransform = transform;
            Position = localTransform.localPosition;
            Size = localTransform.localScale;
            TryGetComponent(out _rigidbody);
        }

        private MapEntry GenerateAttributeList(int teamId)
        {
            Vector3 velocity = _rigidbody != null ? _rigidbody.velocity : Vector3.zero;
            
            Dictionary<string, float> attributes = new Dictionary<string, float>
                {
                    {"team", GetTeamRelation(teamId)},
                    {"health", GetHealth()},
                    {"armor", GetArmor()},
                    {"vecX", velocity.x},
                    {"vecY", velocity.y},
                    {"vecZ", velocity.z}
                };
            
                return new MapEntry(attributes);
            
        }

        public MapEntry MapEntry(int teamId)
        {
            return GenerateAttributeList(teamId);
        }
        public Vector3 Position { get; private set; }
        public Vector3 Size { get; private set; }

        private float GetTeamRelation(int teamId)
        {
            Logger.logWarning("Programming Team must implement this.");
            return teamId;
        }
        private float GetHealth()
        {
            Logger.logWarning("Programming Team must implement this.");
            return 0f;
        }
        
        private float GetArmor()
        {
            Logger.logWarning("Programming Team must implement this.");
            return 0f;
        }
    }
}