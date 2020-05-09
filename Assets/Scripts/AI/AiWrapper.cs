using System.Collections.Generic;
using Stat;
using UnityEngine;
using Util;

namespace AI
{
    [RequireComponent(typeof(AttributeHolder))]
    public class AiWrapper : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private AttributeHolder _attributeHolder;
        private AttributeType _health;
        private AttributeType _armor;
        private AttributeType _team;

        public void Start()
        {
            Transform localTransform = transform;
            Position = localTransform.position;
            Size = localTransform.localScale;
            TryGetComponent(out _rigidbody);
            _attributeHolder = GetComponent<AttributeHolder>();
            _health = AttributeType.Create("Health");
            _armor = AttributeType.Create("Armor");
            _team = AttributeType.Create("Team");
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
            _attributeHolder.TryGetAttribute(_team, out Float teamAttribute);
            return teamId;
        }
        private float GetHealth()
        {
            _attributeHolder.TryGetAttribute(_health, out Float healthAttribute);

            return healthAttribute.Value;
        }
        
        private float GetArmor()
        {
            _attributeHolder.TryGetAttribute(_armor, out Float armorAttribute);
            return armorAttribute.Value;
        }
    }
}