using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
    public interface IFieldExpression : IExpression
    {
        IExpression Instance { get; }

        FieldInfo Field { get; }

        bool IsVolatile { get; }

        AddressAlignment Alignment { get; }
    }
}