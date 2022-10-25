// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Internal]
    public sealed class LocationInterceptionAdviceOptimizationAttribute : AdviceOptimizationAttribute
    {
        /// <exclude />
        public LocationInterceptionAdviceOptimizationAttribute( LocationInterceptionAdviceOptimizations optimizations )
        {
            this.Optimizations = optimizations;
        }

        /// <exclude />
        public LocationInterceptionAdviceOptimizations Optimizations { get; private set; }
    }
}