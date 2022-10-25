// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
#if !LEGACY_REFLECTION_API

#endif
namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression representing a method call.
    /// </summary>
    public interface IMethodCallExpression : IExpression
    {
        /// <summary>
        /// Gets the instance on which the method is called, or <c>null</c> if the method is static.
        /// </summary>
        IExpression Instance { get; }

        /// <summary>
        /// Gets the called method.
        /// </summary>
        MethodBase Method { get; }

        /// <summary>
        /// Gets the method arguments.
        /// </summary>
        IList<IExpression> Arguments { get; }

        /// <summary>
        /// Determines whether the call is a virtual call.
        /// </summary>
        bool IsVirtual { get; }

        /// <summary>
        /// Determines whether the call is a tail call (see <see cref="OpCodes.Tailcall"/>).
        /// </summary>
        bool IsTail { get; }

        /// <summary>
        /// Gets the type to which the virtual method call is constrained to (see <see cref="OpCodes.Constrained"/>).
        /// </summary>
        Type ConstrainedType { get; }
    }
}
