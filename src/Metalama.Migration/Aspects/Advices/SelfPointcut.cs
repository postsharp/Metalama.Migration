#pragma warning disable CA1710 // Identifiers should have correct suffix

// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   <see cref = "Pointcut" /> that selects exactly the aspect target.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    /// <remarks>
    /// </remarks>
    public sealed class SelfPointcut : Pointcut { }
}