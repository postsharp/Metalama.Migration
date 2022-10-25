﻿// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PostSharp.Aspects.Internals
{
    /// <exclude/>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DebuggerTargetMethodAttribute : Attribute
    {
        /// <exclude/>
        public DebuggerTargetMethodAttribute( int targetMethodToken )
        {
            this.TargetMethodToken = targetMethodToken;
        }

        /// <exclude/>
        public int TargetMethodToken { get; }
    }
}
