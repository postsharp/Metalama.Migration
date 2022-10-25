// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects.Advices
{
    /// <exclude />
    public sealed class StateAttribute : AdviceParameterAttribute
    {
        /// <exclude />
        public StateAttribute(StateScope scope)
        {
            this.Scope = scope;
        }

        /// <exclude />
        public StateAttribute( StateScope scope, string slotName )
        {
            this.Scope = scope;
            this.SlotName = slotName;
        }

        /// <exclude />
        public StateScope Scope { get; private set; }

        /// <exclude />
        public string SlotName { get; private set; }
    }
}
