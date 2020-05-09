using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(PlayerProperties))]
    public class AiWrapper : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private PlayerProperties _playerProperties;

        public void Start()
        {
            Transform localTransform = transform;
            Position = localTransform.position;
            Size = localTransform.localScale;
            TryGetComponent(out _rigidbody);
            _playerProperties = GetComponent<PlayerProperties>();
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
            return teamId;
        }
        private float GetHealth()
        {
            return _playerProperties.health.Value;
        }
        
        private float GetArmor()
        {
            return _playerProperties.armor.Value;
        }
    }
}