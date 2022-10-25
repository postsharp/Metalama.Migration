using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// Base class for aspects applied on types, but having the same lifetime as
    /// instances of the type to which they are applied.
    /// </summary>
    /// <remarks>
    /// <para>This class is provided for convenience. You get the same functionality by deriving your
    /// aspect class directly from <see cref="TypeLevelAspect"/> and implementing the interface
    /// <see cref="IInstanceScopedAspect"/>
    /// </para>
    /// <br/>
    /// <para>See <see cref="IInstanceScopedAspect"/> for a discussion of instance-scoped aspects.</para>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    /// <seealso cref="IInstanceScopedAspect"/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='seeAlsoAspectLifetime']/*"/>
    [Serializable]
    [MulticastAttributeUsage( MulticastTargets.Class, AllowExternalAssemblies = false, TargetTypeAttributes = MulticastAttributes.Instance )]
    [AttributeUsage( AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class InstanceLevelAspect : TypeLevelAspect, ICloneAwareAspect
    {
        /// <inheritdoc />
        public virtual object CreateInstance( AdviceArgs adviceArgs )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual void RuntimeInitializeInstance() { }

        /// <inheritdoc />
        public virtual void OnCloned( ICloneAwareAspect source ) { }

        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new AspectConfiguration();
        }

        /// <summary>
        ///   Gets the object to which the current aspect has been applied.
        /// </summary>
        public object Instance { get; }
    }
}