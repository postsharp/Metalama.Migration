namespace PostSharp.Reflection.MethodBody
{
    public interface IInitBufferExpression : IExpression
    {
        IExpression Buffer { get; }

        IExpression Length { get; }

        bool IsVolatile { get; }

        AddressAlignment Alignment { get; }
    }
}