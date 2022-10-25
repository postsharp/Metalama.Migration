using System;
using PostSharp.Constraints;

namespace PostSharp.Reflection
{
    /// <summary>
    /// This is currently not exposed in Metalama.
    /// </summary>
    [InternalImplement]
    public interface ISourceDocument
    {
        string FileName { get; }

        Guid Language { get; }
    }
}