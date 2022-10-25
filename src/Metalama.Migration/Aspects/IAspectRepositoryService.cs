// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Service that allows to determine which aspects have been applied to a given declaration, whether declaratively through custom attributes or <see cref="MulticastAttribute"/>,
    /// or programmatically using <see cref="IAspectProvider"/>.
    /// </summary>
    /// <remarks>
    /// <para>To get an instance of this service, use the <see cref="IProject.GetService{T}"/> method from <c>PostSharpEnvironment.CurrentProject.GetService</c>.</para>
    /// </remarks>
    public interface IAspectRepositoryService : IService
    {
        /// <summary>
        /// Gets the list of aspect instances on a given declaration.
        /// </summary>
        /// <param name="declaration">The declaration (in the current assembly) for which the list of aspect instances is required.</param>
        /// <returns>The list of aspect instances applied on <paramref name="declaration"/>.</returns>
        IAspectInstance[] GetAspectInstances( object declaration );

        /// <summary>
        /// Determines whether an aspect of a given type has been applied to a given declaration.
        /// </summary>
        /// <param name="declaration">The declaration on which the presence of the aspect must be checked.</param>
        /// <param name="aspectType">The type of aspect.</param>
        /// <returns><c>true</c> if an aspect of type <paramref name="aspectType"/> has been applied to <paramref name="declaration"/>, otherwise <c>false</c>.</returns>
        bool HasAspect( object declaration, Type aspectType );

        /// <summary>
        /// Event invoked after all the aspects in the current project have been discovered and initialized.
        /// </summary>
        event EventHandler AspectDiscoveryCompleted;
    }
}
