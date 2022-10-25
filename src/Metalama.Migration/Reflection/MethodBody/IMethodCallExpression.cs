using System;
using System.Collections.Generic;
using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
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