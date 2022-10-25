namespace PostSharp.Reflection.MethodBody
{
    public interface IConditionalExpression : IExpression
    {
        IExpression Condition { get; }

        IExpression IfTrue { get; }

        IExpression IfFalse { get; }
    }
}