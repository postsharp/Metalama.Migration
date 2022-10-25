using System;
using PostSharp.Constraints;

namespace PostSharp.Reflection
{
    [InternalImplement]
    public interface ISourceDocument
    {
        string FileName { get; }

        Guid Language { get; }
    }
}