// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Utility methods for <c>PostSharp.Aspects</c>.
    /// </summary>
    public sealed class AspectUtilities
    {
       

        /// <summary>
        ///   Initializes the all the aspects of the calling instance. This method must be
        ///   invoked from an instance method (not a static method) of a type that has been enhanced
        ///   by an aspect.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     Calls to this method are transformed, at build time, to calls to
        ///     <b>this.InitializeAspects</b>, a method that is typically generated by <c>PostSharp</c>. 
        ///     This is why the current method has actually no implementation.
        ///   </para>
        ///   <para>
        ///     The constructors of enhanced classes always initialize aspects. The only scenario
        ///     where this method needs to be invoked manually is when instances are not built
        ///     using the constructor, but for instance with the method <see cref = "System.Runtime.Serialization.FormatterServices.GetUninitializedObject" />.
        ///   </para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInstanceInitialization']/*" />
        public static void InitializeCurrentAspects()
        {
            throw new NotSupportedException( "The caller of this method should be transformed by PostSharp." );
        }
    }
}