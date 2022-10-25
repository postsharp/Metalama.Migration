using System;

namespace PostSharp.Aspects.Advices
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true, Inherited = true )]
    public sealed class IntroduceInterfaceAttribute : Advice
    {
        public IntroduceInterfaceAttribute( Type interfaceType )
        {
            throw new NotImplementedException();
        }

        public InterfaceOverrideAction OverrideAction { get; set; }

        public InterfaceOverrideAction AncestorOverrideAction { get; set; }
    }
}