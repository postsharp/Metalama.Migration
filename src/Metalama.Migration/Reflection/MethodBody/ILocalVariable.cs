using System;

namespace PostSharp.Reflection.MethodBody
{
    public interface ILocalVariable : IMethodBodyElement
    {
        string Name { get; }

        Type VariableType { get; }

        int? Slot { get; }
    }
}