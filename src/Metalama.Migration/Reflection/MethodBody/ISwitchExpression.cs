using System.Collections.Generic;

namespace PostSharp.Reflection.MethodBody
{
    public interface ISwitchExpression : IExpression
    {
        IExpression Condition { get; }

        IList<IExpression> Targets { get; }
    }
}