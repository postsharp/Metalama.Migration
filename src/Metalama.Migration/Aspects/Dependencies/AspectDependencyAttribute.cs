// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Aspects.Advices;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Base class for all custom attributes defining aspect dependencies. An aspect dependency determines the
    ///   behavior of aspects or advices when used in conjunction with other aspects and advices.
    ///   Aspect dependencies determine ordering, requirements, conflicts, and commutativity of aspects and advices.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    /// <remarks>
    /// </remarks>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true )]
    public abstract class AspectDependencyAttribute : Attribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "AspectDependencyAttribute" /> without specifying the position,
        ///   implicitly set to <see cref = "AspectDependencyPosition.Any" />.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        protected AspectDependencyAttribute( AspectDependencyAction action )
        {
            this.Action = action;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectDependencyAttribute" /> and specifies a position.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "position">Dependency position.</param>
        protected AspectDependencyAttribute( AspectDependencyAction action, AspectDependencyPosition position )
        {
            this.Action = action;
            this.Position = position;
        }

        /// <summary>
        ///   Gets the dependency action, i.e. the kind of relationship specified by the dependency
        ///   (<see cref = "AspectDependencyAction.Order" />, <see cref = "AspectDependencyAction.Require" />,
        ///   <see cref = "AspectDependencyAction.Conflict" />, or <see cref = "AspectDependencyAction.Commute" />).
        /// </summary>
        /// <remarks>
        ///   See documentation of <see cref = "AspectDependencyAction" /> for a description of the meaning of combined <see cref = "Action" />
        ///   and <see cref = "Position" /> properties.
        /// </remarks>
        public AspectDependencyAction Action { get; private set; }

        /// <summary>
        ///   Gets the position of the current dependency, i.e. actually the position of the <i>other</i>
        ///   aspect or advices with respect to the one related to this dependency.
        /// </summary>
        /// <remarks>
        ///   See documentation of <see cref = "AspectDependencyAction" /> for a description of the meaning of combined <see cref = "Action" />
        ///   and <see cref = "Position" /> properties.
        /// </remarks>
        public AspectDependencyPosition Position { get; private set; }

        /// <summary>
        ///   Determines the target (<see cref = "AspectDependencyTarget.Default" /> or <see cref = "AspectDependencyTarget.Type" />)
        ///   to which the aspect dependency apply.
        /// </summary>
        /// <remarks>
        ///   See the documentation of <see cref = "AspectDependencyTarget" /> for details.
        /// </remarks>
        public AspectDependencyTarget Target { get; set; }

        /// <summary>
        ///   If <c>true</c>, specifies that the constraint (of type <see cref = "AspectDependencyAction.Require" />
        ///   or <see cref = "AspectDependencyAction.Conflict" />) should emit a warning instead of an error if not
        ///   respected.
        /// </summary>
        public bool IsWarning { get; set; }

        /// <summary>
        ///   Aspect type to which this dependency applies. This property is required when the
        ///   custom attribute is applied at assembly level. It is ignored when applied on
        ///   class or method level.
        /// </summary>
        public Type TargetType { get; set; }
    }
}