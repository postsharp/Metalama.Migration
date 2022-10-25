using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Specifies an aspect dependency matching aspects of a specified type, and all its advices.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class AspectTypeDependencyAttribute : AspectDependencyAttribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "AspectTypeDependencyAttribute" /> and specifies a position.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "position">Dependency position.</param>
        /// <param name = "aspectType">Aspect type (derived from <see cref = "IAspect" />).</param>
        /// <remarks>
        /// </remarks>
        public AspectTypeDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            Type aspectType )
            : base( action, position )
        {
            AspectType = aspectType;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectTypeDependencyAttribute" /> without specifying the position,
        ///   implicitly set to <see cref = "AspectDependencyPosition.Any" />.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "aspectType">Aspect type (derived from <see cref = "IAspect" />).</param>
        public AspectTypeDependencyAttribute( AspectDependencyAction action, Type aspectType )
            : base( action )
        {
            AspectType = aspectType;
        }

        /// <summary>
        ///   Gets the type from which the aspects should be derived in order to match the current dependency.
        /// </summary>
        public Type AspectType { get; }
    }
}