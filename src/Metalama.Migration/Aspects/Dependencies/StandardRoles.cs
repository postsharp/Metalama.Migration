using System.ComponentModel;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   List of standard roles.
    /// </summary>
    /// <remarks>
    ///   <para>See <see cref = "AspectRoleDependencyAttribute" /> for a discussion of aspect roles.</para>
    ///   <para>Roles are used to categorize aspects according to their function. This class
    ///     defines standard names for the most commonly used aspect roles. If you are an aspect vendor,
    ///     you are encouraged to enroll your aspects (using <see cref = "ProvideAspectRoleAttribute" />) into
    ///     one of these roles. 
    ///   </para>
    ///   <para>
    ///     If this list is not sufficient, we at <c>PostSharp</c> encourage you
    ///     contact us to define a new role string. In any case, if you define a new role string, we recommend you
    ///     clearly define it so that users of your aspect can express dependencies with their own aspects,
    ///     or third-party aspects.</para>
    /// </remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public static class StandardRoles
    {
        /// <summary>
        ///   Validation of field, property, or parameter value.
        /// </summary>
        public const string Validation = "Validation";

        /// <summary>
        ///   Tracing and logging.
        /// </summary>
        public const string Tracing = "Tracing";

        /// <summary>
        ///   Performance instrumentation (for instance performance counters).
        /// </summary>
        public const string PerformanceInstrumentation = "PerformanceInstrumentation";

        /// <summary>
        ///   Security enforcing (typically authorization).
        /// </summary>
        public const string Security = "Security";

        /// <summary>
        ///   Caching.
        /// </summary>
        public const string Caching = "Caching";

        /// <summary>
        ///   Transaction handling.
        /// </summary>
        public const string TransactionHandling = "Transaction";

        /// <summary>
        ///   Exception handling.
        /// </summary>
        public const string ExceptionHandling = "ExceptionHandling";

        /// <summary>
        ///   Data binding (for instance implementation of <see cref = "INotifyPropertyChanged" />).
        /// </summary>
        public const string DataBinding = "DataBinding";

        /// <summary>
        ///   Object persistence (for instance Object-Relational Mapper).
        /// </summary>
        public const string Persistence = "Persistence";

        /// <summary>
        ///   Event broker (a system role used internally by <c>PostSharp</c> to realize
        ///   the <see cref = "IEventInterceptionAspect.OnInvokeHandler" />  handler).
        /// </summary>
        public const string EventBroker = "Event Broker";

        /// <summary>
        ///   Threading (locking).
        /// </summary>
        public const string Threading = "Threading";
    }
}