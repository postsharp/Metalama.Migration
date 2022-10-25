using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    public interface IFieldExpression : IExpression
    {
        IExpression Instance { get; }

        FieldInfo Field { get; }

        bool IsVolatile { get; }

        AddressAlignment Alignment { get; }
    }
}