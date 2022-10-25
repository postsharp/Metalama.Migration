using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    public interface IMetadataExpression : IExpression
    {
        MemberInfo Declaration { get; }
    }
}