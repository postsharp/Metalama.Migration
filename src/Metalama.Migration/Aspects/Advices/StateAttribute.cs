namespace PostSharp.Aspects.Advices
{
    /// <exclude />
    public sealed class StateAttribute : AdviceParameterAttribute
    {
        /// <exclude />
        public StateAttribute( StateScope scope )
        {
            Scope = scope;
        }

        /// <exclude />
        public StateAttribute( StateScope scope, string slotName )
        {
            Scope = scope;
            SlotName = slotName;
        }

        /// <exclude />
        public StateScope Scope { get; }

        /// <exclude />
        public string SlotName { get; }
    }
}