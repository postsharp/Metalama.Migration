// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that represents a local variable.
    /// </summary>
    public interface ILocalVariableExpression : IExpression
    {
        /// <summary>
        /// Gets the local variable.
        /// </summary>
        ILocalVariable LocalVariable { get; }

        /// <summary>
        /// Gets the value of the <see cref="ILocalVariable"/> at this specific point of the program execution, in case this value
        /// can be determined trivially.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the value cannot be determined in a trivial way, it is possible to perform a non-trivial data flow analysis
        /// by using the <see cref="GetPossibleAssignments"/> method.
        /// </para>
        /// </remarks>
        IExpression TrivialValue { get; }

        /// <summary>
        /// Returns an array of all possible assignments of the <see cref="ILocalVariable"/> at this specific point of the program execution.
        /// </summary>
        /// <returns>List of possible assignments.</returns>
        /// <remarks>
        ///     <para>
        ///         The result list contains either assignment expressions (<see cref="IBinaryExpression"/>) or 
        ///         <see cref="IAddressOfExpression"/> when the address of the variable is passed to a method through a reference argument.
        ///     </para>
        ///     <para>Result of this method is cached.</para>
        /// </remarks>
        IList<IExpression> GetPossibleAssignments();
    }
}
