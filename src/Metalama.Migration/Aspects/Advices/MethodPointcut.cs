// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on an advice method, specifies the name of
    ///   the method that will be invoked at build-time to return the set of elements of code
    ///   to which the advice applies.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     This method should have the signature
    ///     <c>IEnumerable&lt;AdviceTargetType&gt; SelectCodeElements(AspectTargetType target)</c> ,
    ///     where <c>AspectTargetType</c> is either <c>object</c> either a reflection type
    ///     corresponding to the kind of targets of the <i>aspect</i> (for instance <c>System.Type</c>
    ///     for a type-level aspect), and <c>AdviceTargetType</c> is either <c>object</c> either
    ///     a reflection type of the kind of targets of the <i>advice</i> (for instance <c>System.MethodInfo</c> for a method-level advice).
    ///   </para>
    /// </remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    public sealed class MethodPointcut : Pointcut
    {
        /// <summary>
        ///   Initializes a new <see cref = "MethodPointcut" />.
        /// </summary>
        /// <param name = "methodName">Name of the method returning the set of targets. This method should have
        ///   a specific signature as discussed in the <see cref = "MethodPointcut">class documentation</see>.</param>
        public MethodPointcut( string methodName )
        {
            this.MethodName = methodName;
        }

        /// <summary>
        ///   Gets the name of the method returning the set of code elements.
        /// </summary>
        public string MethodName { get; private set; }
    }
}

