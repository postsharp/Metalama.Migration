using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    [Serializable]
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(AspectConfigurationAttribute) )]
    [Serializer( null )]
    public abstract class Aspect : MulticastAttribute, IAspect, IAspectBuildSemantics
    {
        public int AspectPriority { get; set; }

        protected Type SerializerType { get; set; }

        public UnsupportedTargetAction UnsupportedTargetAction { get; set; }

        bool IValidableAnnotation.CompileTimeValidate( object target )
        {
            return CompileTimeValidate( target );
        }

        protected virtual AspectConfiguration CreateAspectConfiguration()
        {
            return new AspectConfiguration();
        }

        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, object targetElement )
        {
            throw new NotImplementedException();
        }

        public AspectConfiguration GetAspectConfiguration( object targetElement )
        {
            throw new NotImplementedException();
        }

        public virtual bool CompileTimeValidate( object target )
        {
            return true;
        }
    }
}