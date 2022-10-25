namespace PostSharp.Reflection.MethodBody
{
    public enum MethodBodyElementKind
    {
        Add,

        AddChecked,

        And,

        ArrayIndex,

        ArrayLength,

        Assign,

        Goto,

        Variable,

        Conditional,

        Cast,

        Divide,

        LessThan,

        LessThanOrEqual,

        Modulo,

        MultiplyChecked,

        Multiply,

        GreaterThan,

        GreaterThanOrEqual,

        Substract,

        SubstractChecked,

        Parameter,

        This,

        AddressOf,

        Constant,

        Equal,

        Not,

        Different,

        ValueOf,

        Or,

        Xor,

        ShiftLeft,

        ShiftRight,

        Negate,

        SafeCast,

        Unbox,

        Throw,

        Field,

        Box,

        NewArray,

        TypedReferenceValue,

        CheckFinite,

        MakeTypedReference,

        ArgumentList,

        MethodPointer,

        LocalAlloc,

        DefaultValue,

        CopyBuffer,

        InitBuffer,

        LoadToken,

        SizeOf,

        TypedReferenceType,

        ConvertChecked,

        Convert,

        MethodCall,

        Return,

        NewObject,

        Switch,

        Block,

        MethodBody,

        LocalVariableDefinition,

        Statement,

        Rethrow
    }
}