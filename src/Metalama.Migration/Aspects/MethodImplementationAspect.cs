// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// Aspect that, when applied on an abstract or <c>extern</c> method, creates an implementation for this method.
    /// </summary>
    /// <seealso cref="MethodInterceptionAspectConfigurationAttribute"/>
    /// <remarks>
    /// <para>This aspect is exactly identical to <see cref="MethodInterceptionAspect"/>, with the difference
    /// that it applies to abstract methods.</para>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>

#if SERIALIZABLE
    [Serializable]
#endif
    [MulticastAttributeUsage( MulticastTargets.Method, AllowMultiple = false, AllowExternalAssemblies = false,
        PersistMetaData = false, Inheritance = MulticastInheritance.None )]
    [HasInheritedAttribute]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer(null)]
    public abstract class MethodImplementationAspect : MethodLevelAspect, IMethodInterceptionAspect
    {
        /// <inheritdoc />
        public abstract void OnInvoke( MethodInterceptionArgs args );



        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }
    }
}