using Metalama.Framework.Diagnostics;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, the equivalent is <see cref="IDiagnosticSink"/>.
    /// </summary>
    public interface IMessageSink
    {
        void Write( Message message );
    }
}