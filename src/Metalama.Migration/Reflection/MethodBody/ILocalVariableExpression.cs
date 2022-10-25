using System.Collections.Generic;

namespace PostSharp.Reflection.MethodBody
{
    public interface ILocalVariableExpression : IExpression
    {
        ILocalVariable LocalVariable { get; }

        IExpression TrivialValue { get; }

        IList<IExpression> GetPossibleAssignments();
    }
}