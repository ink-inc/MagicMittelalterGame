using System.Collections.Generic;
using Character;
using Character.NPC;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(NpcProperties))]
    public class AiWrapper : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private CharacterProperties _characterProperties;

        public void Start()
        {
            Transform localTransform = transform;
            Position = localTransform.position;
            Size = localTransform.localScale;
            TryGetComponent(out _rigidbody);
            _characterProperties = GetComponent<CharacterProperties>();
        }

        private MapEntry GenerateAttributeList(int otherTeamId)
        {
            Vector3 velocity = _rigidbody != null ? _rigidbody.velocity : Vector3.zero;
            
            Dictionary<string, float> attributes = new Dictionary<string, float>
                {
                    {"team", GetTeamRelation(otherTeamId)},
                    {"health", GetHealth},
                    {"armor", GetArmor},
                    {"vecX", velocity.x},
                    {"vecY", velocity.y},
                    {"vecZ", velocity.z},
                    {"height", Size.y},
                    {"damageCounter", DamageCounter}
                };
            
                return new MapEntry(attributes);
            
        }

        public float DamageCounter => _characterProperties != null ? _characterProperties.damageCounter.Value : 0f;
        private float GetTeamRelation(int otherTeamId) => _characterProperties != null ? _characterProperties.Relation(otherTeamId) : 0f;
        private float GetHealth => _characterProperties != null ? _characterProperties.health.Value : 0f;
        private float GetArmor => _characterProperties != null ? _characterProperties.armor.Value : 0f;


        public MapEntry MapEntry(int otherTeamId)
        {
            return GenerateAttributeList(otherTeamId);
        }
        public Vector3 Position { get; private set; }
        public Vector3 Size { get; private set; }



    }
}