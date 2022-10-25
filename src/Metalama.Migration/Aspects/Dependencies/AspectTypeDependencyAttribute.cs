// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// In Metalama, use <see cref="AspectOrderAttribute"/> to specify order dependencies (typically one attribute per aspect library).
    /// The other kinds of dependencies are not supported in Metalama.
    /// </summary>
    public sealed class AspectTypeDependencyAttribute : AspectDependencyAttribute
    {
        public AspectTypeDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            Type aspectType )
            : base( action, position )
        {
            this.AspectType = aspectType;
        }

        public AspectTypeDependencyAttribute( AspectDependencyAction action, Type aspectType )
            : base( action )
        {
            this.AspectType = aspectType;
        }

        public Type AspectType { get; }
    }
}