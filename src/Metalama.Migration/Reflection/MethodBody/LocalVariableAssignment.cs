namespace PostSharp.Reflection.MethodBody
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    public struct LocalVariableAssignment
    {
        public ILocalVariable LocalVariable { get; }

        public IExpression Expression { get; }
    }
}