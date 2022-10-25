using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
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
        public virtual bool CompileTimeValidate( Type type )
        {
            return true;
        }

        public sealed override bool CompileTimeValidate( object target )
        {
            throw new NotImplementedException();
        }

        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, Type targetType ) { }

        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            throw new NotImplementedException();
        }

        public virtual void CompileTimeInitialize( Type type, AspectInfo aspectInfo ) { }

        public virtual void RuntimeInitialize( Type type ) { }
    }
}