﻿using System;
using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideMethodAspect"/>.
    /// </summary>
    [MulticastAttributeUsage(
        MulticastTargets.Method,
        AllowMultiple = false,
        PersistMetaData = false,
        Inheritance = MulticastInheritance.None )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    public abstract class MethodImplementationAspect : MethodLevelAspect, IMethodInterceptionAspect
    {
        /// <summary>
        /// In Metalama, override <see cref="OverrideMethodAspect.OverrideMethod"/>.
        /// </summary>
        public abstract void OnInvoke( MethodInterceptionArgs args );

        /// <inheritdoc/>
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }
    }
}