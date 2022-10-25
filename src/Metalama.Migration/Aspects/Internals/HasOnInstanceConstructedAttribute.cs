// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace PostSharp.Aspects.Internals
{
    /// <exclude/>
    [Internal]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [MulticastAttributeUsage(MulticastTargets.Class, AllowMultiple = false, Inheritance = MulticastInheritance.Strict)]
    [RequirePostSharp(null, "AspectInfrastructure.TypeInitialization")]
    public class HasOnInstanceConstructedAttribute : MulticastAttribute
    {
    }
}
