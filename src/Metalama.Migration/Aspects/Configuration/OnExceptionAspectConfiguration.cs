using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Configuration of the <see cref = "IOnExceptionAspect" /> aspect.
    /// </summary>
    /// <seealso cref = "OnExceptionAspect" />
    /// <seealso cref = "OnExceptionAspectConfigurationAttribute" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class OnExceptionAspectConfiguration : AspectConfiguration
    {
        /// <summary>
        ///   Gets or sets the type of exceptions that are caught by this aspect.
        /// </summary>
        /// <remarks>
        ///   If this property is <c>null</c>, any <see cref = "Exception" /> shall be caught.
        /// </remarks>
        public TypeIdentity ExceptionType { get; set; }

        /// <summary>
        /// Determines which target methods will be advised semantically. This affects the behavior of the aspect when it's applied to
        /// iterator or async methods, which are compiled into state machines.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Semantic advising results in an aspect that is consistent with the level of abstraction of the programming language. This is the default behavior.
        /// You can disable semantic advising using this property to be consistent with the level of abstraction
        /// of MSIL and for backward-compatibility with the versions of PostSharp prior to 3.1.
        /// </para>
        /// </remarks>
        public SemanticallyAdvisedMethodKinds? SemanticallyAdvisedMethodKinds { get; set; }
    }
}