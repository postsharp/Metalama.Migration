namespace PostSharp.Reflection.MethodBody
{
    public interface IGotoExpression : IExpression
    {
        IBlockExpression Target { get; }
    }
}