namespace Status
{
    /// <summary>
    /// A StatusEffect is a temporary or permanent toggleable (de)buff that may either do something each tick or change StatAttributes while active.
    /// Can be applied to StatusEffectHolders.
    /// </summary>
    public abstract class StatusEffect
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Holder of this StatusEffect.
        /// </summary>
        public StatusEffectHolder Holder { get; set; }

        /// <summary>
        /// Flag if thei StatusEffect should be removed by the next tick.
        /// </summary>
        public bool MarkedForRemoval { get; private set; }

        /// <summary>
        /// Flag if this StatusEffect is active right now.
        /// </summary>
        public bool Active
        {
            get => _active;
            set
            {
                if (value != _active)
                {
                    _active = value;
                    if (_active)
                    {
                        OnEnable();
                    }
                    else
                    {
                        OnDisable();
                    }
                }
            }
        }

        /// <summary>
        /// Time in ticks this StatusEffect has been active.
        /// </summary>
        public int TimeActive { get; private set; }

        private bool _active;

        /// <summary>
        /// Event Handler for adding to a StatusEffectHolder. Gets called after Holder is available.
        /// </summary>
        public virtual void OnAdd()
        {
        }

        /// <summary>
        /// Event Handler for removing from a StatusEffectHolder. Gets called before Holder becomes unavailable.
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <summary>
        /// Event Handler for becoming active.
        /// </summary>
        public virtual void OnEnable()
        {
        }

        /// <summary>
        /// Event Handler for becoming inactive.
        /// </summary>
        public virtual void OnDisable()
        {
        }

        /// <summary>
        /// Updates this StatusEffect's Active status.
        /// </summary>
        public virtual void CheckActive()
        {
        }

        /// <summary>
        /// Event Handler for update logic. Gets called every FixedUpdate.
        /// </summary>
        public virtual void Tick()
        {
            TimeActive++;
        }

        /// <summary>
        /// Merge with a new effect with the same id.
        /// </summary>
        /// <param name="newEffect">new effect</param>
        public virtual void Merge(StatusEffect newEffect)
        {
        }

        /// <summary>
        /// Mark this StatusEffect for removal by the next update tick.
        /// </summary>
        public void MarkForRemoval()
        {
            MarkedForRemoval = true;
        }
    }
}