// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    /// <exclude />
    [AttributeUsage(AttributeTargets.Parameter)]
    public abstract class AdviceParameterAttribute : Attribute
    {
        /// <exclude/>
        protected AdviceParameterAttribute()
        {
            
        }

    }
}
