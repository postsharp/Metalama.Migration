using System;

namespace PostSharp.Aspects.Advices
{
    public sealed class IntroduceInterfaceAdviceInstance : AdviceInstance
    {
        public IntroduceInterfaceAdviceInstance(
            Type interfaceType,
            InterfaceOverrideAction overrideAction = InterfaceOverrideAction.Fail,
            InterfaceOverrideAction ancestorOverrideAction = InterfaceOverrideAction.Fail )
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException( nameof(interfaceType) );
            }

            InterfaceType = interfaceType;
            OverrideAction = overrideAction;
            AncestorOverrideAction = ancestorOverrideAction;
        }

        public Type InterfaceType { get; }

        public InterfaceOverrideAction OverrideAction { get; }

        public InterfaceOverrideAction AncestorOverrideAction { get; }

        public override object MasterAspectMember { get; }
    }
}