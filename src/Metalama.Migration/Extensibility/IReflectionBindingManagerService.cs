using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Exposes the <see cref="ResolveAssembly"/> method, which gets the reference identity of
    /// the assembly declaring a given type.
    /// </summary>
    public interface IReflectionBindingManagerService : IService
    {
        /// <summary>
        /// Returns the reference identity of the assembly declaring a type.
        /// </summary>
        /// <param name="type">A <see cref="Type"/>.</param>
        /// <returns>The identity of the reference assembly defining <see cref="Type"/>. This assembly is possibly
        /// different than the runtime assembly, which is available from the <see cref="Type.Assembly"/> property
        /// of the <see cref="Type"/> class. This method may return <c>null</c> if <paramref name="type"/> is
        /// an internal type of a system assembly.</returns>
        string ResolveAssembly( Type type );
    }
}