using System;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and call
    ///  <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.ImplementInterface(Metalama.Framework.Code.INamedType,Metalama.Framework.Code.INamedType,Metalama.Framework.Aspects.OverrideStrategy,object?)"/>.
    /// </summary>
    /// <seealso href="@implementing-interfaces"/>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
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