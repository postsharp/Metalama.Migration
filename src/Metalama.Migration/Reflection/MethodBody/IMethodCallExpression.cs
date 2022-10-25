using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    public interface IMethodCallExpression : IExpression
    {
        IExpression Instance { get; }

        MethodBase Method { get; }

        IList<IExpression> Arguments { get; }

        bool IsVirtual { get; }

        bool IsTail { get; }

        Type ConstrainedType { get; }
    }
}