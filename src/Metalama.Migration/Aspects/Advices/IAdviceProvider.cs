// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Interface that allows an aspect to provide aspects dynamically, instead of declaratively using custom attributes.
    /// </summary>
    public interface IAdviceProvider : IAspect
    {
        /// <summary>
        /// Provides an enumeration of advices, represented as instances of the <see cref="AdviceInstance"/> class, for the current aspect instance.
        /// </summary>
        /// <param name="targetElement">Element of code to which the current aspect has been applied.</param>
        /// <returns>A collection of advices to be added to the current aspect instance.</returns>
        IEnumerable<AdviceInstance> ProvideAdvices( object targetElement );
    }
}
