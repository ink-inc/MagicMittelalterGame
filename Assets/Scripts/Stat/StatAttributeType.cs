using UnityEngine;

namespace Stat
{
    /// <summary>
    /// Attribute Type.
    /// </summary>
    [CreateAssetMenu(menuName = "Stat/AttributeType")]
    public class StatAttributeType : ScriptableObject
    {
        public string Type => type;

        /// <summary>
        /// Identifier.
        /// </summary>
        [Tooltip("Identifier String")] [SerializeField]
        private string type;

        public static StatAttributeType Create(string type)
        {
            var attributeType = CreateInstance<StatAttributeType>();
            attributeType.type = type;
            return attributeType;
        }
    }
}