// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = false, Inherited = false )]
    [Internal]
    public abstract class AdviceOptimizationAttribute : Attribute
    {
    }
}