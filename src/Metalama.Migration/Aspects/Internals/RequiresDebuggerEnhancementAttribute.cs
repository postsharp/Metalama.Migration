// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    [MulticastAttributeUsage(MulticastTargets.Method | MulticastTargets.Class, Inheritance = MulticastInheritance.Strict)]
    [Internal]
    public sealed class RequiresDebuggerEnhancementAttribute : MulticastAttribute
    {
        /// <exclude />
        public RequiresDebuggerEnhancementAttribute(DebuggerStepOverAspectBehavior kind)
        {
            this.Kind = kind;
        }

        /// <exclude />
        public DebuggerStepOverAspectBehavior Kind { get; private set; }
    }
}
