// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    internal static class ServiceLocatorExtensions
    {
        /// <summary>
        /// A helper method that checks whether the project is <c>null</c> before attempting to get a service.
        /// </summary>
        internal static T GetServiceChecked<T>( this IProject project ) where T : class, IService
        {
            if ( project == null )
            {
                throw new InvalidOperationException( "The project instance is not available. You are probably running build-time only code in run-time." );
            }

            return project.GetService<T>();
        }
    }
}
