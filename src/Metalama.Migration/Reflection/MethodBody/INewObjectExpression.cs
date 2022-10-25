// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;
using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that creates a new object by invoking a constructor.
    /// </summary>
    public interface INewObjectExpression : IExpression
    {
        /// <summary>
        /// Gets the constructor.
        /// </summary>
        ConstructorInfo Constructor { get; }

        /// <summary>
        /// Gets the arguments passed to the constructor.
        /// </summary>
        IList<IExpression> Arguments { get; }
    }
}

