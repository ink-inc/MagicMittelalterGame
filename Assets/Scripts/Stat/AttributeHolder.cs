using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Util;

namespace Stat
{
    /// <summary>
    /// Helper class to identify components that contain StatAttributes.
    /// </summary>
    public abstract class AttributeHolder : MonoBehaviour
    {
        /// <summary>
        /// Get the StatAttribute instance for the given AttributeType.
        /// </summary>
        /// <param name="attributeType">given AttributeType</param>
        /// <param name="attribute">out attribute</param>
        public bool TryGetAttribute<T>(AttributeType attributeType, out T attribute) where T : Float
        {
            var attr = GetAttribute(attributeType);
            if (attr is T castedAttr)
            {
                attribute = castedAttr;
                return true;
            }

            attribute = null;
            return false;
        }

        private Float GetAttribute(AttributeType attributeType)
        {
            return GetAllAttributes().FirstOrDefault(attribute => attribute.attributeType == attributeType);
        }

        public List<Float> GetAllAttributes()
        {
            var list = new List<Float>();
            var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (typeof(Float).IsAssignableFrom(field.FieldType)
                    && field.GetValue(this) is Float attribute)
                {
                    list.Add(attribute);
                }
            }

            return list;
        }
    }
}