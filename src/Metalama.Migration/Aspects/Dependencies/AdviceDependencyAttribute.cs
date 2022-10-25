namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Specifies an aspect dependency matching an advice of the same aspect instance.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    /// <remarks>
    /// </remarks>
    public sealed class AdviceDependencyAttribute : AspectDependencyAttribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "AdviceDependencyAttribute" /> and specifies a position.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "position">Dependency position.</param>
        /// <param name = "adviceMethodName">Name of the advice method.</param>
        public AdviceDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string adviceMethodName )
            : base( action, position )
        {
            AdviceMethodName = adviceMethodName;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AdviceDependencyAttribute" /> without specifying the position,
        ///   implicitly set to <see cref = "AspectDependencyPosition.Any" />.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "adviceMethodName">Name of the advice method.</param>
        public AdviceDependencyAttribute( AspectDependencyAction action, string adviceMethodName )
            : base( action )
        {
            AdviceMethodName = adviceMethodName;
        }

        /// <summary>
        ///   Gets the name of the method implementing the advice.
        /// </summary>
        public string AdviceMethodName { get; }
    }
}