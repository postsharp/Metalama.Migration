// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.


using PostSharp.Reflection;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Configuration of aspects of type <see cref = "CustomAttributeIntroductionAspect" />.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class CustomAttributeIntroductionAspectConfiguration : AspectConfiguration
    {
        /// <summary>
        ///   Gets or sets the construction of the custom attribute that must be applied to the target of this aspect.
        /// </summary>
        public ObjectConstruction ObjectConstruction { get; set; }
    }
}
