// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent to this feature in Metalama.
    /// </summary>
    /// <seealso href="@overriding-events"/>
    [Obsolete( "", true )]
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnEventInvokeHandlerAdvice : GroupingAdvice { }
}