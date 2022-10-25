using PostSharp.Constraints;

namespace PostSharp.Reflection.MethodBody
{
    [Experimental]
    public interface IBinaryExpression : IExpression
    {
        IExpression Left { get; }

        IExpression Right { get; }
    }
}