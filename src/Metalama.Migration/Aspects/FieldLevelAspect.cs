using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    [Serializable]
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class FieldLevelAspect : Aspect, IFieldLevelAspect, IFieldLevelAspectBuildSemantics
    {
        public virtual bool CompileTimeValidate( FieldInfo field )
        {
            return true;
        }

        public sealed override bool CompileTimeValidate( object target )
        {
            var field = target as FieldInfo;

            if (field == null)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Aspects of type {0} can be applied to fields only.",
                        GetType().FullName ) );
            }

            return CompileTimeValidate( field );
        }

        public virtual void CompileTimeInitialize( FieldInfo field, AspectInfo aspectInfo ) { }

        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, FieldInfo targetField ) { }

        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (FieldInfo)targetElement );
        }

        public virtual void RuntimeInitialize( FieldInfo field ) { }
    }
}