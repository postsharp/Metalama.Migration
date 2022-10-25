namespace PostSharp.Reflection.MethodBody
{
    public interface IConstantExpression : IExpression
    {
        object Value { get; }
    }
}