namespace PostSharp.Reflection.MethodBody
{
    public interface IStatementExpression : IExpression
    {
        IStatementExpression PreviousSibling { get; }

        IStatementExpression NextSibling { get; }

        IExpression Expression { get; }
    }
}