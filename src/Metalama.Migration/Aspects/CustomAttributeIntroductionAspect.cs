using System;
using System.Reflection;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no specific aspect class to add a custom attribute in Metalama, but only the advice factory method
    /// <see cref="IAdviceFactory.IntroduceAttribute"/>. Create an aspect class that calls this advice factory method
    /// from <see cref="IAspect{T}.BuildAspect"/>.
    /// </summary>
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

        /// <inheritdoc/>
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