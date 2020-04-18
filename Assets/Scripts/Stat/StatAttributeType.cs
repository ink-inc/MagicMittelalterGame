using UnityEngine;

namespace Stat
{
    /// <summary>
    /// Attribute Type.
    /// </summary>
    [CreateAssetMenu(menuName = "Stat/AttributeType")]
    public class StatAttributeType : ScriptableObject
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Tooltip("Identifier String")] public string type;
    }
}