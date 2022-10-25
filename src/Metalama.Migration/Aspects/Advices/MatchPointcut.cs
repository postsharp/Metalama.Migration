// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects.Advices
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

    /// <exclude />
    public sealed class MatchPointcut : Pointcut
    {
        /// <exclude />
        public MatchPointcut( string methodName )
        {
            this.MethodName = methodName;
        }

        /// <exclude />
        public bool MatchParameterCount { get; set; } = true;

        /// <exclude />
        public string MethodName { get; private set; }

    }
}
