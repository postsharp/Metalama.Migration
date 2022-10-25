// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Aspect that, when applied to a target, adds a custom attribute to this target.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     There are two ways to specify a custom attribute: either using an
    ///     <see cref = "ObjectConstruction" /> (to construct a new custom attribute), 
    ///     either a <see cref = "CustomAttributeData" /> (to copy a custom attribute reflected 
    ///     using one of the overload of the method <see cref = "System.Reflection.CustomAttributeData.GetCustomAttributes(Assembly)" />/
    ///   </para>
    ///   <note>
    ///     This aspect is not a custom attribute. You have to create another aspect
    ///     implementing <see cref = "IAspectProvider" /> and have the method <see cref = "IAspectProvider.ProvideAspects" />
    ///     return instances of this aspect.
    ///   </note>
    /// </remarks>
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectProvider']/*" />
    
    [LinesOfCodeAvoided(1)]
    public sealed class CustomAttributeIntroductionAspect : ICustomAttributeIntroductionAspect, IAspectBuildSemantics
    {
        private readonly ObjectConstruction customAttribute;

        /// <summary>
        ///   Initializes a new <see cref = "CustomAttributeIntroductionAspect" /> by specifying an <see cref = "ObjectConstruction" />.
        /// </summary>
        /// <param name = "attribute">Construction of the custom attribute to be added to the target.</param>
        public CustomAttributeIntroductionAspect( ObjectConstruction attribute )
        {
            #region Preconditions

            if ( attribute == null ) throw new ArgumentNullException( nameof(attribute));

            #endregion

            this.customAttribute = attribute;
        }

        /// <summary>
        ///   Initializes a new <see cref = "CustomAttributeIntroductionAspect" /> by specifying a
        ///   <see cref = "CustomAttributeData" />.
        /// </summary>
        /// <param name = "customAttributeData">Construction of the custom attribute to be added to the target.</param>
        public CustomAttributeIntroductionAspect( CustomAttributeData customAttributeData )
        {
            if ( customAttributeData == null ) throw new ArgumentNullException( nameof(customAttributeData));

            this.customAttribute = new ObjectConstruction( customAttributeData );
        }

        /// <summary>
        ///   Gets the construction of the custom attribute that must be applied to the target of this aspect.
        /// </summary>
        public ObjectConstruction CustomAttribute
        {
            get { return this.customAttribute; }
        }


        bool IValidableAnnotation.CompileTimeValidate( object target )
        {
            return true;
        }

        AspectConfiguration IAspectBuildSemantics.GetAspectConfiguration( object targetElement )
        {
            return new CustomAttributeIntroductionAspectConfiguration {ObjectConstruction = customAttribute};
        }
    }
}

