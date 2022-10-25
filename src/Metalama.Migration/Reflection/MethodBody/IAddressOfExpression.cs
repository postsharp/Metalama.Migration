namespace PostSharp.Reflection.MethodBody
{
    public interface IAddressOfExpression : IUnaryExpression
    {
        bool IsReadOnly { get; }
    }
}