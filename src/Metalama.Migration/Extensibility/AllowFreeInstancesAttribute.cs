// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    /// <exclude/>
    [Internal]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false )]
    [Obsolete( "Licensing is now based on hard-coded assembly name." )]
    public sealed class AllowFreeInstancesAttribute : Attribute
    {
        /// <exclude/>
        public AllowFreeInstancesAttribute( string featureName )
        {
            this.FeatureName = featureName;
        }

        /// <exclude/>
        public AllowFreeInstancesAttribute( string featureName, int count )
        {
            this.FeatureName = featureName;
            this.FreeInstanceCount = count;
        }

        /// <exclude/>
        public string FeatureName { get; private set; }

        /// <exclude/>
        public int? FreeInstanceCount { get; private set; }

        /// <exclude/>
        public bool ApplyToType { get; set; }
    }
}
