namespace PostSharp.Reflection.MethodBody
{
    public interface IUnaryExpression : IExpression
    {
        IExpression Value { get; }
    }
}