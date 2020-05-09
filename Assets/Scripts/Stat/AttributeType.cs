using System;
using UnityEngine;

namespace Stat
{
    /// <summary>
    ///     Attribute Type.
    /// </summary>
    [CreateAssetMenu(menuName = "Stat/AttributeType")]
    public class AttributeType : ScriptableObject, IEquatable<AttributeType>
    {
        /// <summary>
        ///     Identifier.
        /// </summary>
        [Tooltip("Identifier String")] [SerializeField]
        private string type;

        public string Type => type;

        public bool Equals(AttributeType other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return base.Equals(other) && type == other.type;
        }

        public static AttributeType Create(string type)
        {
            if (type == null) throw new ArgumentException("type must not be null");

            var attributeType = CreateInstance<AttributeType>();
            attributeType.type = type;
            return attributeType;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

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

        public override string ToString()
        {
            return type;
        }
    }
}