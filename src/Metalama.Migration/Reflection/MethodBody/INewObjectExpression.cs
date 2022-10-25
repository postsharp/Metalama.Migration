using System.Collections.Generic;
using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    public interface INewObjectExpression : IExpression
    {
        ConstructorInfo Constructor { get; }

        IList<IExpression> Arguments { get; }
    }
}