// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Internals
{
    /// <exclude/>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DebuggerSourceMethodAttribute : Attribute
    {
        /// <exclude/>
        public DebuggerSourceMethodAttribute(int sourceMethodToken)
        {
            this.SourceMethodToken = sourceMethodToken;
        }

        /// <exclude/>
        public int SourceMethodToken { get; }
    }
}
