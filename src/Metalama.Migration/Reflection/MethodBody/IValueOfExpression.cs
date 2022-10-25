namespace PostSharp.Reflection.MethodBody
{
    public interface IValueOfExpression : IUnaryExpression
    {
        bool IsVolatile { get; }

        AddressAlignment Alignment { get; }
    }
}