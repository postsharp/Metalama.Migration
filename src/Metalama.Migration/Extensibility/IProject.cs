using System.Collections.Generic;
using System.Reflection;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    [InternalImplement]
    public interface IProject : IServiceLocator
    {
        IStateStore StateStore { get; }

        string EvaluateExpression( string expression );

        Assembly TargetAssembly { get; }

        new T GetService<T>( bool throwing = true ) where T : class, IService;

        IEnumerable<ProjectExtensionElement> GetExtensionElements( string name, string ns );
    }
}