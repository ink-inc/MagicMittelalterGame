using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AiWrapper : MonoBehaviour
    {
        private readonly Rigidbody _rigidbody;

        public AiWrapper()
        {
            Transform localTransform = transform;
            Position = localTransform.position;
            Size = localTransform.localScale;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private MapEntry GenerateAttributeList(int teamId)
        {
            Vector3 velocity = _rigidbody.velocity;
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
        public Vector3 Position { get; }
        public Vector3 Size { get; }

        private float GetTeamRelation(int teamId)
        {
            Logger.logWarning("Programming Team must implement this.");
            return 0f;
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