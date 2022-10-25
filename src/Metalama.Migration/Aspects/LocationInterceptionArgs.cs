using System.Diagnostics;
using PostSharp.Aspects.Internals;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Arguments of advices of aspect type <see cref = "LocationInterceptionAspect" />.
    /// </summary>
    /// <remarks>
    ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgs']/*" />
    /// </remarks>
    /// <seealso cref = "LocationInterceptionAspect" />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class LocationInterceptionArgs : LocationLevelAdviceArgs, ILocationInterceptionArgs
    {
        /// <inheritdoc />
        public abstract ILocationBinding Binding { get; }

        /// <inheritdoc />
        public Arguments Index { get; }

        /// <inheritdoc />
        public abstract void ProceedGetValue();

        /// <inheritdoc />
        public abstract void ProceedSetValue();

        /// <inheritdoc />
        public abstract object GetCurrentValue();

        /// <inheritdoc />
        public abstract void SetNewValue( object value );

        /// <inheritdoc />
        public abstract void Execute<TPayload>( ILocationInterceptionArgsAction<TPayload> action, ref TPayload payload );
    }
}