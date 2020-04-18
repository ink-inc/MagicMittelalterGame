using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public abstract class Float : ScriptableObject
    {
        public abstract float Value { get; set; }

        private readonly List<OnChange> _listeners = new List<OnChange>();

        protected void NotifyListeners()
        {
            foreach (var listener in _listeners)
            {
                listener.Invoke(this);
            }
        }

        protected virtual void OnEnable()
        {
        }

        protected virtual void OnDisable()
        {
        }

        public void AddListener(OnChange listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(OnChange listener)
        {
            _listeners.Remove(listener);
        }

        public void RemoveListenersFrom(object target)
        {
            _listeners.RemoveAll(listener => listener.Target == target);
        }

        public delegate void OnChange(Float f);

        public override string ToString()
        {
            return $"{GetType().Name}[{Value}]";
        }
    }
}