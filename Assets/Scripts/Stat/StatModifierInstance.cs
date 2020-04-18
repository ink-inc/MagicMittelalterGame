namespace Stat
{
    public class StatModifierInstance
    {
        public StatModifier Modifier { get; }
        public StatAttribute Attribute { get; }
        public IStatModifierSource Source { get; }

        public StatModifierInstance(StatModifier modifier, StatAttribute attribute, IStatModifierSource source)
        {
            Modifier = modifier;
            Attribute = attribute;
            Source = source;
        }

        public bool Matches(StatModifier modifier, IStatModifierSource source)
        {
            return Modifier == modifier && Source == source;
        }

        public bool Matches(IStatModifierSource source)
        {
            return Source == source;
        }

        public override string ToString()
        {
            return Modifier.ToString();
        }
    }
}