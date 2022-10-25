// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Specifies that the aspect or aspect advice to which this custom attribute is applied is a
    ///   part of a given role. This aspect or advice can then be matched by <see cref = "AspectRoleDependencyAttribute" />/
    /// </summary>
    /// <seealso cref = "AspectRoleDependencyAttribute" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    /// <remarks>
    /// </remarks>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true )]
    public sealed class ProvideAspectRoleAttribute : AspectDependencyAttribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "ProvideAspectRoleAttribute" />.
        /// </summary>
        /// <param name = "role">Role.</param>
        public ProvideAspectRoleAttribute( string role ) : base( AspectDependencyAction.None )
        {
            this.Role = role;
        }

        /// <summary>
        ///   Gets the role into which the aspect or advice to which this custom
        ///   attribute is applied will be enrolled.
        /// </summary>
        public string Role { get; private set; }
    }
}