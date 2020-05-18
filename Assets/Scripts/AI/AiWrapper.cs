using System.Collections.Generic;
using Character;
using Character.NPC;
using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(NpcProperties))]
    public class AiWrapper : MonoBehaviour
    {
        private CharacterProperties _characterProperties;

        private Rigidbody _rigidbody;
        public Vector3 Position => transform.position;
        public Vector3 Size => transform.localScale;

        public float DamageCounter => _characterProperties != null ? _characterProperties.damageCounter.Value : 0f;
        private float GetHealth => _characterProperties != null ? _characterProperties.health.Value : 0f;
        private float GetArmor => _characterProperties != null ? _characterProperties.armor.Value : 0f;

        private Vector2 Orientation
        {
            get
            {
                if (_rigidbody == null) return Vector2.zero;
                float angle = _rigidbody.rotation.eulerAngles.y;
                return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            }
        }

        public void Start()
        {
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
                {"orientX", Orientation.x},
                {"orientY", Orientation.y},
                {"height", Size.y},
                {"damageCounter", DamageCounter}
            };

            return new MapEntry(attributes);
        }

        private float GetTeamRelation(int otherTeamId) =>
            _characterProperties != null ? _characterProperties.Relation(otherTeamId) : 0f;

        public MapEntry MapEntry(int otherTeamId)
        {
            return GenerateAttributeList(otherTeamId);
        }
    }
}