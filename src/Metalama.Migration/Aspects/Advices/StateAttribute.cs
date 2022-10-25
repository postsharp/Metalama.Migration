namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a local variable in the template.
    /// </summary>
    public sealed class StateAttribute : AdviceParameterAttribute
    {
        public StateAttribute( StateScope scope )
        {
            Scope = scope;
        }

        public StateAttribute( StateScope scope, string slotName )
        {
            Scope = scope;
            SlotName = slotName;
        }

        public StateScope Scope { get; }

        public string SlotName { get; }
    }
}