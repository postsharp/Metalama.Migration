// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System;

namespace PostSharp.Aspects.Advices
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

    /// <summary>
    /// In Metalama, use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method, iterate <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Target"/>.<see cref="INamedType"/>.<see cref="INamedType.Methods"/>, and add advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    public sealed class MatchPointcut : Pointcut
    {
        public MatchPointcut( string methodName )
        {
            throw new NotImplementedException();
        }

        public bool MatchParameterCount { get; set; } = true;

        public string MethodName { get; }
    }
}