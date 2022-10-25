using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using PostSharp.Aspects.Advices;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct,
        AllowMultiple = true,
        Inherited = false )]
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Struct, AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(CompositionAspectConfigurationAttribute) )]
    [Serializer( null )]
    public abstract class CompositionAspect : TypeLevelAspect, ICompositionAspect
    {
        public abstract object CreateImplementationObject( AdviceArgs args );

        protected virtual Type[] GetPublicInterfaces( Type targetType )
        {
            return null;
        }

        protected InterfaceOverrideAction OverrideAction { get; set; }

        protected InterfaceOverrideAction AncestorOverrideAction { get; set; }

        protected bool NonSerializedImplementation { get; set; }

        protected bool GenerateImplementationAccessor { get; set; }

        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new CompositionAspectConfiguration();
        }

        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, Type targetType ) { }
    }
}