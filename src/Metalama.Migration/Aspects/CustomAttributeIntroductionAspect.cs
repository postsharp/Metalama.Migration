using System;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    [LinesOfCodeAvoided( 1 )]
    public sealed class CustomAttributeIntroductionAspect : ICustomAttributeIntroductionAspect, IAspectBuildSemantics
    {
        public CustomAttributeIntroductionAspect( ObjectConstruction attribute )
        {
            throw new NotImplementedException();
        }

        public CustomAttributeIntroductionAspect( CustomAttributeData customAttributeData )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction CustomAttribute { get; }

        bool IValidableAnnotation.CompileTimeValidate( object target )
        {
            return true;
        }

        AspectConfiguration IAspectBuildSemantics.GetAspectConfiguration( object targetElement )
        {
            throw new NotImplementedException();
        }
    }
}