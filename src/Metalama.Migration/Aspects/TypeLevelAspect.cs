using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Base class for all aspects applied on types.
    /// </summary>
    /// <seealso cref="ITypeLevelAspect"/>
    /// <remarks>
    /// <include file="Documentation.xml" path="/documentation/section[@name='abstractAspectClass']/*"/>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    [Serializable]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [MulticastAttributeUsage(
        MulticastTargets.Class | MulticastTargets.Struct | MulticastTargets.Interface,
        AllowExternalAssemblies = false,
        AllowMultiple = true,
        PersistMetaData = false )]
    [AttributeUsage( AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true )]
    [Serializer( null )]
    public abstract class TypeLevelAspect : Aspect, ITypeLevelAspect, ITypeLevelAspectBuildSemantics
    {
        /// <summary>
        ///   Method invoked at build time to ensure that the aspect has been applied to the right target.
        /// </summary>
        /// <param name = "type">Type to which the aspect has been applied</param>
        /// <returns><c>true</c> if the aspect was applied to an acceptable field, otherwise
        ///   <c>false</c>.</returns>
        /// <remarks>
        ///   The implementation of this method is expected to emit an error message (see 
        ///   <see cref = "MessageSource" />) or an exception in case of error. Returning <c>false</c> without emitting an
        ///   error message or exception causes the aspect to be silently ignored.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoValidatingAspects']/*" />
        public virtual bool CompileTimeValidate( Type type )
        {
            return true;
        }

        /// <inheritdoc />
        public sealed override bool CompileTimeValidate( object target )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Method invoked at build time to set up an <see cref = "AspectConfiguration" /> object according to the current 
        ///   <see cref = "Aspect" /> instance and a specified target element of the current aspect.
        /// </summary>
        /// <param name = "aspectConfiguration">The <see cref = "AspectConfiguration" /> instance previously returned  by the
        ///   <see cref = "Aspect.CreateAspectConfiguration" /> method.</param>
        /// <param name = "targetType">Type to which the current aspect has been applied.</param>
        /// <remarks>
        ///   <para>Classes overriding this method must always invoke the base implementation before performing their own
        ///     changes to the 
        ///     <see cref = "AspectConfiguration" />.</para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, Type targetType ) { }

        /// <inheritdoc />
        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual void CompileTimeInitialize( Type type, AspectInfo aspectInfo ) { }

        /// <inheritdoc />
        public virtual void RuntimeInitialize( Type type ) { }
    }
}