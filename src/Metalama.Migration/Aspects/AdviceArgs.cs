using System.Diagnostics;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class AdviceArgs
    {
        static AdviceArgs()
        {
            // TODO: remove this after we have a different way of forcing DebuggerInterop type to load during debugging.
            DebuggerInterop.Dummy();
        }

        public AdviceArgs( object instance ) { }

        protected AdviceArgs() { }

        public object Instance { get; }

        public DeclarationIdentifier DeclarationIdentifier { get; }
    }
}