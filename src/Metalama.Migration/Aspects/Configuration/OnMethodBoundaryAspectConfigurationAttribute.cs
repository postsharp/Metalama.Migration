// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Custom attribute that, when applied on a class implementing <see cref = "IOnMethodBoundaryAspect" />,
    ///   defines the configuration of that aspect.
    /// </summary>
    /// <seealso cref = "OnMethodBoundaryAspectConfiguration" />
    /// <seealso cref = "OnMethodBoundaryAspect" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class OnMethodBoundaryAspectConfigurationAttribute : AspectConfigurationAttribute

    {
        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnMethodBoundaryAspectConfiguration();
        }
    }
}