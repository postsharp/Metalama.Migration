using System;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that represents a local variable.
    /// </summary>
    /// <remarks>
    ///     <para>There are three kind of local variable, but consumers of this class should be oblivious to these kinds:
    /// local variables defined in user code, local variables introduced by the compiler, and pseudo-variables introduced
    /// by the AST decompiler to emulate the stack.</para>
    /// </remarks>
    public interface ILocalVariable : IMethodBodyElement
    {
        /// <summary>
        /// Gets the name of the local variable.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the type of the local variable.
        /// </summary>
        Type VariableType { get; }

        /// <summary>
        /// Gets the ordinal of the local variable.
        /// </summary>
        /// <remarks>
        /// Several local variables may be assigned the same slot if they are used in different scopes.
        /// </remarks>
        int? Slot { get; }
    }
}