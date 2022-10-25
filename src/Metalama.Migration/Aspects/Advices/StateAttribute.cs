namespace PostSharp.Aspects.Advices
{
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