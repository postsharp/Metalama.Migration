// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Internals
{
    /// <exclude/>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DebuggerBindingMethodAttribute : Attribute
    {
        /// <exclude/>
        public DebuggerBindingMethodAttribute(int bindingInvokeMethodToken)
        {
            this.BindingInvokeMethodToken = bindingInvokeMethodToken;
        }

        /// <exclude/>
        public int BindingInvokeMethodToken { get; }
    }
}
