// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Enumeration of kinds of syntax elements (<see cref="IMethodBodyElement"/>).
    /// </summary>
    /// <see cref="IMethodBodyElement"/>
    public enum MethodBodyElementKind
    {
        /// <summary>
        /// Addition (<see cref="IBinaryExpression"/>).
        /// </summary>
        Add,

        /// <summary>
        /// Addition with overflow checking (<see cref="IBinaryExpression"/>).
        /// </summary>
        AddChecked,

        /// <summary>
        /// Bitwise <c>And</c> (<see cref="IBinaryExpression"/>).
        /// </summary>
        And,

        /// <summary>
        /// Element of an array (<see cref="IBinaryExpression"/> where <see cref="IBinaryExpression.Left"/> is the
        /// array and <see cref="IBinaryExpression.Right"/> is the index).
        /// </summary>
        ArrayIndex,

        /// <summary>
        /// Length of an array (<see cref="IUnaryExpression"/>).
        /// </summary>
        ArrayLength,

        /// <summary>
        /// Assignment (<see cref="IBinaryExpression"/>).
        /// </summary>
        Assign,

        /// <summary>
        /// Unconditional branch (<see cref="IGotoExpression"/>).
        /// </summary>
        Goto,

        /// <summary>
        /// Local variable expression (<see cref="ILocalVariableExpression"/>).
        /// </summary>
        Variable,

        /// <summary>
        /// Conditional expression (<see cref="IConditionalExpression"/>).
        /// </summary>
        Conditional,

        /// <summary>
        /// Cast (<see cref="IUnaryExpression"/> where <see cref="IExpression.ReturnType"/> is the destination type).
        /// </summary>
        Cast,

        /// <summary>
        /// Division (<see cref="IBinaryExpression"/>).
        /// </summary>
        Divide,

        /// <summary>
        /// Less than (<see cref="IBinaryExpression"/>).
        /// </summary>
        LessThan,

        /// <summary>
        /// Less than or equal (<see cref="IBinaryExpression"/>).
        /// </summary>
        LessThanOrEqual,

        /// <summary>
        /// Modulo (<see cref="IBinaryExpression"/>).
        /// </summary>
        Modulo,

        /// <summary>
        /// Multiply with overflow checking (<see cref="IBinaryExpression"/>).
        /// </summary>
        MultiplyChecked,

        /// <summary>
        /// Multiply (<see cref="IBinaryExpression"/>).
        /// </summary>
        Multiply,

        /// <summary>
        /// Greater than (<see cref="IBinaryExpression"/>).
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Greater than (<see cref="IBinaryExpression"/>).
        /// </summary>
        GreaterThanOrEqual,

        /// <summary>
        /// Substract (<see cref="IBinaryExpression"/>).
        /// </summary>
        Substract,


        /// <summary>
        /// Substract with overflow checking (<see cref="IBinaryExpression"/>).
        /// </summary>
        SubstractChecked,

        /// <summary>
        /// Parameter (<see cref="IParameterExpression"/>).
        /// </summary>
        Parameter,

        /// <summary>
        /// Current object (<c>this</c> keyword in C#, <see cref="IZeroaryExpression"/>).
        /// </summary>
        This,

        /// <summary>
        /// Referencing operator (<c>&amp;</c> in C#, see <see cref="IUnaryExpression"/>).
        /// </summary>
        AddressOf,

        /// <summary>
        /// Constant (<see cref="IConstantExpression"/>).
        /// </summary>
        Constant,

        /// <summary>
        /// Equal (<see cref="IBinaryExpression"/>).
        /// </summary>
        Equal,

        /// <summary>
        /// Logical negation (<see cref="IUnaryExpression"/>).
        /// </summary>
        Not,

        /// <summary>
        /// Different (<see cref="IBinaryExpression"/>).
        /// </summary>
        Different,

        /// <summary>
        /// Dereferencing operator (<c>*</c> in C#, see <see cref="IUnaryExpression"/>).
        /// </summary>
        ValueOf,

        /// <summary>
        /// Bitwise <c>Or</c> (<see cref="IBinaryExpression"/>).
        /// </summary>
        Or,

        /// <summary>
        /// Bitwise <c>And</c> (<see cref="IBinaryExpression"/>).
        /// </summary>
        Xor,

        /// <summary>
        /// Bitwise shift to left (<see cref="IBinaryExpression"/>).
        /// </summary>
        ShiftLeft,

        /// <summary>
        /// Bitwise shift to right (<see cref="IBinaryExpression"/>).
        /// </summary>
        ShiftRight,

        /// <summary>
        /// Bitwise negation (<see cref="IUnaryExpression"/>).
        /// </summary>
        Negate,

        /// <summary>
        /// Safe cast (<see cref="IUnaryExpression"/> where <see cref="IExpression.ReturnType"/> is the destination type).
        /// </summary>
        SafeCast,

        /// <summary>
        /// Unbox (<see cref="IUnaryExpression"/>).
        /// </summary>
        Unbox,

        /// <summary>
        /// Throw exception (<see cref="IUnaryExpression"/>).
        /// </summary>
        Throw,

        /// <summary>
        /// Field (<see cref="IFieldExpression"/>).
        /// </summary>
        Field,

        /// <summary>
        /// Box (<see cref="IUnaryExpression"/>).
        /// </summary>
        Box,

        /// <summary>
        /// Create new array (<see cref="INewArrayExpression"/>).
        /// </summary>
        NewArray,

        /// <summary>
        /// Get value of typed reference (<see cref="IUnaryExpression"/>).
        /// </summary>
        TypedReferenceValue,

        /// <summary>
        /// Check that the value is finite (<see cref="IUnaryExpression"/>).
        /// </summary>
        CheckFinite,

        /// <summary>
        /// Make typed reference (<see cref="IUnaryExpression"/>).
        /// </summary>
        MakeTypedReference,

        /// <summary>
        /// Get argument list (<see cref="IZeroaryExpression"/>).
        /// </summary>
        ArgumentList,

        /// <summary>
        /// Get pointer of method (<see cref="IMethodPointerExpression"/>).
        /// </summary>
        MethodPointer,

        /// <summary>
        /// Allocate on local stack (<see cref="IUnaryExpression"/>).
        /// </summary>
        LocalAlloc,

        /// <summary>
        /// Default value for given type (<see cref="IMetadataExpression"/>).
        /// </summary>
        DefaultValue,

        /// <summary>
        /// Copy buffer (<see cref="ICopyBufferExpression"/>).
        /// </summary>
        CopyBuffer,

        /// <summary>
        /// Initialize buffer (<see cref="IInitBufferExpression"/>).
        /// </summary>
        InitBuffer,

        /// <summary>
        /// Load metadata token (<see cref="IMetadataExpression"/>).
        /// </summary>
        LoadToken,

        /// <summary>
        /// Size of type (<see cref="IMetadataExpression"/>).
        /// </summary>
        SizeOf,

        /// <summary>
        /// Get type of typed reference (<see cref="IUnaryExpression"/>).
        /// </summary>
        TypedReferenceType,

        /// <summary>
        /// Convert to integral type with overflow check (<see cref="IUnaryExpression"/>).
        /// </summary>
        ConvertChecked,

        /// <summary>
        /// Convert to integral type (<see cref="IUnaryExpression"/>).
        /// </summary>
        Convert,

        /// <summary>
        /// Method call (<see cref="IMethodCallExpression"/>).
        /// </summary>
        MethodCall,

        /// <summary>
        /// Return (<see cref="IUnaryExpression"/>).
        /// </summary>
        Return,

        /// <summary>
        /// Creates new object (<see cref="INewObjectExpression"/>).
        /// </summary>
        NewObject,

        /// <summary>
        /// Switch (<see cref="ISwitchExpression"/>).
        /// </summary>
        Switch,

        /// <summary>
        /// Instruction block (<see cref="IBlockExpression"/>).
        /// </summary>
        Block,

        /// <summary>
        /// Method body (<see cref="IMethodBody"/>).
        /// </summary>
        MethodBody,

        /// <summary>
        /// Local variable definition (<see cref="ILocalVariable"/>).
        /// </summary>
        LocalVariableDefinition,

        /// <summary>
        /// Statement (<see cref="IStatementExpression"/>).
        /// </summary>
        Statement,

        /// <summary>
        /// Re-throw exception (<see cref="IZeroaryExpression"/>).
        /// </summary>
        Rethrow
    }
}
