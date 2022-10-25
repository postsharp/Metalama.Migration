using System.Reflection;
using Metalama.Framework.Project;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="MetalamaExecutionContext"/>.
    /// </summary>
    public interface IPostSharpEnvironment
    {
        IProject CurrentProject { get; }

        Assembly LoadAssemblyFromFile( string fileName );
    }
}