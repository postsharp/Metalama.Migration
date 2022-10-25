using Metalama.Framework.Code;
using Metalama.Framework.Diagnostics;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, an <see cref="IDeclaration"/> is also a <see cref="IDiagnosticLocation"/>.
    /// </summary>
    public interface IMessageLocationResolver : IService
    {
        MessageLocation GetMessageLocation( object codeElement );
    }
}