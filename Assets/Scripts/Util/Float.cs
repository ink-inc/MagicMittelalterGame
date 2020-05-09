using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// A float wrapper with integrated change listener system.
    /// </summary>
    public abstract class Float : ScriptableObject
    {
        /// <summary>
        /// Type.
        /// </summary>
        [Tooltip("Type")] public AttributeType attributeType;

        public string Name => attributeType != null ? attributeType.ToString() : GetType().Name;

        public abstract float Value { get; set; }

        private readonly List<OnChange> _listeners = new List<OnChange>();

        protected void NotifyListeners(float oldValue)
        {
            foreach (var listener in _listeners)
            {
                listener.Invoke(this, oldValue);
            }
        }

        protected virtual void OnEnable()
        {
            RegisterListener();
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void RegisterListener()
        {
        }

        /// <summary>
        /// Add a change event listener.
        /// </summary>
        /// <param name="listener">change listener</param>
        public void AddListener(OnChange listener)
        {
            _listeners.Add(listener);
        }

        /// <summary>
        /// Remove a change event listener.
        /// </summary>
        /// <param name="listener">change listener</param>
        public void RemoveListener(OnChange listener)
        {
            _listeners.Remove(listener);
        }

        /// <summary>
        /// Change event handling delegate.
        /// </summary>
        /// <param name="f">changed value</param>
        /// <param name="oldValue">old value</param>
        public delegate void OnChange(Float f, float oldValue);

        public override string ToString()
        {
            return $"{Name}: {Value:0.##}";
        }
    }
}