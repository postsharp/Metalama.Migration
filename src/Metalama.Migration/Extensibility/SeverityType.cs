namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Types of message severities.
    /// </summary>
    public enum SeverityType
    {
        /// <summary>
        ///   Debugging information (typically trace).
        /// </summary>
        Debug = 0,

        /// <summary>
        ///   Verbose (information of low importance).
        /// </summary>
        Verbose = 1,

        /// <summary>
        ///   Information. Error messages of this severity are not shown in Visual Studio's Error List.
        /// </summary>
        Info = 2,

        /// <summary>
        ///   Important information. It is shown in Visual Studio's Error List under Messages.
        /// </summary>
        ImportantInfo = 3,

        /// <summary>
        ///   Command line.
        /// </summary>
        CommandLine = 4,

        /// <summary>
        ///   Warning. It is shown in Visual Studio's Error List under Warnings.
        /// </summary>
        Warning = 5,

        /// <summary>
        ///   Error. It is shown in Visual Studio's Error List under Errors. The project build fails.
        /// </summary>
        Error = 6,

        /// <summary>
        ///   Fatal error. It is shown in Visual Studio's Error List under Errors. The project build fails and ends immediately.
        /// </summary>
        Fatal = 7,

        /// <summary>
        /// No message.
        /// </summary>
        None = -1
    }
}