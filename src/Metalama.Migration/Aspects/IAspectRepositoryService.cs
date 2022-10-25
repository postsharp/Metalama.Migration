using System;
using Metalama.Framework.Code;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use extension methods of the code model.
    /// </summary>
    public interface IAspectRepositoryService : IService
    {
        /// <summary>
        /// Use <see cref="IDeclaration"/>.<see cref="DeclarationExtensions.Aspects{T}"/>.
        /// </summary>
        IAspectInstance[] GetAspectInstances( object declaration );

        /// <summary>
        /// Use <see cref="IDeclaration"/>.<see cref="DeclarationExtensions.Aspects{T}"/>.<c>Any()</c>.
        /// </summary>
        bool HasAspect( object declaration, Type aspectType );

        /// <summary>
        /// This event is not exposed, but when you register validators, they get executed
        /// after all aspects have been applied.
        /// </summary>
        /// <seealso href="@validating-declarations"/>
        [Obsolete( "", true )]
        event EventHandler AspectDiscoveryCompleted;
    }
}