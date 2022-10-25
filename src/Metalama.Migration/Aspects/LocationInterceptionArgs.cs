using System.Diagnostics;
using PostSharp.Aspects.Internals;

namespace PostSharp.Aspects
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class LocationInterceptionArgs : LocationLevelAdviceArgs, ILocationInterceptionArgs
    {
        public abstract ILocationBinding Binding { get; }

        public Arguments Index { get; }

        public abstract void ProceedGetValue();

        public abstract void ProceedSetValue();

        public abstract object GetCurrentValue();

        public abstract void SetNewValue( object value );

        public abstract void Execute<TPayload>( ILocationInterceptionArgsAction<TPayload> action, ref TPayload payload );
    }
}