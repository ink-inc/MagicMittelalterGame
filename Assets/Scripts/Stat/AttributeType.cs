using System;
using UnityEngine;

namespace Stat
{
    /// <summary>
    /// Attribute Type.
    /// </summary>
    [CreateAssetMenu(menuName = "Stat/AttributeType")]
    public class AttributeType : ScriptableObject, IEquatable<AttributeType>
    {
        public string Type => type;

        /// <summary>
        /// Identifier.
        /// </summary>
        [Tooltip("Identifier String")] [SerializeField]
        private string type;

        public static AttributeType Create(string type)
        {
            var attributeType = CreateInstance<AttributeType>();
            attributeType.type = type;
            return attributeType;
        }

        public bool Equals(AttributeType other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other) && type == other.type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals((AttributeType) obj);
        }

        public override int GetHashCode()
        {
            return type.GetHashCode();
        }

        public static bool operator ==(AttributeType left, AttributeType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AttributeType left, AttributeType right)
        {
            return !Equals(left, right);
        }
    }
}