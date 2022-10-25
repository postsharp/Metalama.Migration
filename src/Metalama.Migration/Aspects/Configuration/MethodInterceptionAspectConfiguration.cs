namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Configuration of aspects of type <see cref = "IMethodInterceptionAspect" />.
    /// </summary>
    /// <seealso cref = "MethodInterceptionAspectConfigurationAttribute" />
    /// <seealso cref = "MethodInterceptionAspect" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class MethodInterceptionAspectConfiguration : AspectConfiguration
    {
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