namespace PostSharp.Reflection.MethodBody
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
    public struct LocalVariableAssignment
    {
        public ILocalVariable LocalVariable { get; }

        public IExpression Expression { get; }
    }
}