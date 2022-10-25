// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Specifies an aspect dependency matching aspects of a specified type, and all its advices.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class AspectTypeDependencyAttribute : AspectDependencyAttribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "AspectTypeDependencyAttribute" /> and specifies a position.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "position">Dependency position.</param>
        /// <param name = "aspectType">Aspect type (derived from <see cref = "IAspect" />).</param>
         /// <remarks>
    /// </remarks>
    public AspectTypeDependencyAttribute( AspectDependencyAction action, AspectDependencyPosition position,
                                              Type aspectType )
            : base( action, position )
        {
            this.AspectType = aspectType;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectTypeDependencyAttribute" /> without specifying the position,
        ///   implicitly set to <see cref = "AspectDependencyPosition.Any" />.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "aspectType">Aspect type (derived from <see cref = "IAspect" />).</param>
        public AspectTypeDependencyAttribute( AspectDependencyAction action, Type aspectType )
            : base( action )
        {
            this.AspectType = aspectType;
        }

        /// <summary>
        ///   Gets the type from which the aspects should be derived in order to match the current dependency.
        /// </summary>
        public Type AspectType { get; private set; }
    }
}