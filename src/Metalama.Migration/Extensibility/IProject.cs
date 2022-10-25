// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Reflection;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Provides information about the currently executing project.
    /// </summary>
    [InternalImplement]
    public interface IProject : IServiceLocator
    {
        /// <summary>
        /// Gets the context of the current project that serves as a project-scoped cache.
        /// </summary>
        IStateStore StateStore { get; }

        /// <summary>
        ///   Evaluates an expression (that is, replace parameters by their actual value).
        /// </summary>
        /// <param name = "expression">An expression.</param>
        /// <returns>The evaluated expression, or <c>null</c> if one parameter could not be
        ///   resolved.</returns>
        string EvaluateExpression( string expression );

        
        /// <summary>
        ///   Gets the assembly that is being transformed by PostSharp.
        /// </summary>
        /// <returns>The assembly being processed.</returns>
        Assembly TargetAssembly { get; }
        
        /// <summary>
        /// Gets a build-time service exposed by PostSharp.
        /// </summary>
        /// <typeparam name="T">An interface derived from <see cref="IService"/>.</typeparam>
        /// <param name="throwing"><c>true</c> whether an exception should be thrown in case the service cannot be acquired, otherwise <c>false</c>.
        /// The default value is <c>true</c>.</param>
        /// <returns>The service <typeparamref name="T"/>, or <c>null</c> if the service could not be acquired and <paramref name="throwing"/>
        /// was set to <c>false</c>.</returns>
        new T GetService<T>( bool throwing = true ) where T : class, IService;


        /// <summary>
        /// Gets the set of project extension elements (<see cref="ProjectExtensionElement"/>) given their name and XML namespace.
        /// </summary>
        /// <param name="name">Local name of the project extension element.</param>
        /// <param name="ns">XML namespace of the project extension element.</param>
        /// <returns>The set of project elements named <paramref name="name"/> in all loaded projects.</returns>
        IEnumerable<ProjectExtensionElement> GetExtensionElements( string name, string ns );
    }
}
