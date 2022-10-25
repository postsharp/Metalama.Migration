// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Diagnostics;
using System.Globalization;
using PostSharp.Aspects.Advices;
using PostSharp.Constraints;

namespace PostSharp.Aspects
{
    /// <summary>
    /// System type used in the implementation of the <see cref="OnInstanceConstructedAdvice"/>. Do not use in user code.
    /// </summary>
    [Internal]
    [DebuggerStepThrough]
#pragma warning disable CA1815 // Override equals and operator equals on value types
    public struct ConstructorDepth
    {
        readonly short level;

        private ConstructorDepth( short level ) 
        {
            this.level = level;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="ConstructorDepth"/> type with a depth level that is one more than the current one.
        /// </summary>
        /// <returns>A new <see cref="ConstructorDepth"/>, incremented of one from the current <see cref="ConstructorDepth"/>.</returns>
        public ConstructorDepth Increment()
        {
            return new ConstructorDepth((short) (this.level + 1));
        }

        /// <summary>
        /// Determines whether the current depth is zero.
        /// </summary>
        public bool IsZero { get { return this.level == 0; }}

        /// <summary>
        /// Gets a <see cref="ConstructorDepth"/> instance representing zero.
        /// </summary>
        public static ConstructorDepth Zero { get { return new ConstructorDepth();}}

        /// <inheritdoc />
        public override string ToString()
        {
            return this.level.ToString( CultureInfo.InvariantCulture );
        }
    }

}
