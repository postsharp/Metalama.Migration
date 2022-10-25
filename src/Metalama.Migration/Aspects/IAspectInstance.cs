// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Configuration;
using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Represents an instance of an aspect applied to a declaration.
    /// </summary>
    [InternalImplement]
    public interface IAspectInstance
    {
        /// <summary>
        ///   Gets the aspect configuration.
        /// </summary>
        /// <value>
        ///   The aspect configuration, or <c>null</c> if none was provided.
        /// </value>
        AspectConfiguration AspectConfiguration { get; }

        /// <summary>
        ///   Gets the aspect construction.
        /// </summary>
        /// <value>
        ///   The aspect construction, or <c>null</c> if the aspect instance was provided instead.
        /// </value>
        ObjectConstruction AspectConstruction { get; }

        /// <summary>
        ///   Gets the aspect instance.
        /// </summary>
        /// <value>
        ///   The aspect instance, or <c>null</c> if the <see cref = "AspectConfiguration" /> was provided instead.
        /// </value>
        IAspect Aspect { get; }

        /// <summary>
        /// Gets the type of the aspect.
        /// </summary>
        Type AspectType { get; }
      
    }
}
