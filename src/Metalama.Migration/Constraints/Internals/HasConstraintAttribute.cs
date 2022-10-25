// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Extensibility;

namespace PostSharp.Constraints.Internals
{
    /// <exclude />
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Field |
        AttributeTargets.Constructor | AttributeTargets.Delegate | AttributeTargets.Enum, 
        AllowMultiple = true )]
    [MulticastAttributeUsage( MulticastTargets.Assembly, Inheritance = MulticastInheritance.Strict )]
    [RequirePostSharp( null, "ArchitectureConstraint" )]
    [Internal]
    public sealed class HasConstraintAttribute : MulticastAttribute
    {
    }

}