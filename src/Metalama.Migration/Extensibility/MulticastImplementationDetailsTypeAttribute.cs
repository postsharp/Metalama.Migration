// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    /// <exclude/>
    [AttributeUsage(AttributeTargets.Assembly)]
    [Internal]
    public sealed class MulticastImplementationDetailsTypeAttribute : Attribute
    {
        /// <exclude/>
        public MulticastImplementationDetailsTypeAttribute( Type type )
        {
            this.MulticastImplementationDetailsType = type;
        }

        /// <exclude/>
        public Type MulticastImplementationDetailsType { get; }

    }
}
