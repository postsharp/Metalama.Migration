namespace PostSharp.Reflection.MethodBody
{
    public interface ICopyBufferExpression : IExpression

    {
        IExpression Source { get; }

        IExpression Destination { get; }

        IExpression Length { get; }

        bool IsVolatile { get; }

        AddressAlignment Alignment { get; }
    }
}