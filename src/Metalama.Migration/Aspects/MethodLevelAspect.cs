using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    [Serializable]
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [MulticastAttributeUsage( MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.StaticConstructor )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Constructor,
        AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class MethodLevelAspect : Aspect, IMethodLevelAspect, IMethodLevelAspectBuildSemantics
    {
        public virtual bool CompileTimeValidate( MethodBase method )
        {
            return true;
        }

        public sealed override bool CompileTimeValidate( object target )
        {
            var method = target as MethodBase;

            if (method == null)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Aspects of type {0} can be applied to methods only.",
                        GetType().FullName ) );
            }

            return CompileTimeValidate( method );
        }

        public virtual void CompileTimeInitialize( MethodBase method, AspectInfo aspectInfo ) { }

        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod ) { }

        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (MethodBase)targetElement );
        }

        public virtual void RuntimeInitialize( MethodBase method ) { }
    }
}