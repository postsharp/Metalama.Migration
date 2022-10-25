using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    public interface IMethodBody : IMethodBodyElement
    {
        MethodBase Method { get; }

        IBlockExpression RootBlock { get; }
    }
}