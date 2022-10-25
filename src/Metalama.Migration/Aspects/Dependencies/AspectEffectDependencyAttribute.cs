namespace PostSharp.Aspects.Dependencies
{
    public sealed class AspectEffectDependencyAttribute : AspectDependencyAttribute
    {
        public AspectEffectDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string effect )
            : base( action, position )
        {
            Effect = effect;
        }

        public AspectEffectDependencyAttribute( AspectDependencyAction action, string effect )
            : base( action )
        {
            Effect = effect;
        }

        public string Effect { get; }
    }
}