using System.Reflection;

namespace PostSharp.Extensibility
{
    public interface IPostSharpEnvironment
    {
        IProject CurrentProject { get; }

        Assembly LoadAssemblyFromFile( string fileName );
    }
}