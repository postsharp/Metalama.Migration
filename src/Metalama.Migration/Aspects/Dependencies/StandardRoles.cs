namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect roles are not supported in Metalama.
    /// </summary>
    public static class StandardRoles
    {
        public const string Validation = "Validation";

        public const string Tracing = "Tracing";

        public const string PerformanceInstrumentation = "PerformanceInstrumentation";

        public const string Security = "Security";

        public const string Caching = "Caching";

        public const string TransactionHandling = "Transaction";

        public const string ExceptionHandling = "ExceptionHandling";

        public const string DataBinding = "DataBinding";

        public const string Persistence = "Persistence";

        public const string EventBroker = "Event Broker";

        public const string Threading = "Threading";
    }
}