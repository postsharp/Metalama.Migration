using PostSharp.Constraints;

namespace PostSharp.Reflection.MethodBody
{
    [InternalImplement]
    public interface IMethodBodyElement
    {
        IMethodBody ParentMethodBody { get; }

        IMethodBodyElement ParentElement { get; }

        MethodBodyElementKind MethodBodyElementKind { get; }
    }
}