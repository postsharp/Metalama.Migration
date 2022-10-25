namespace PostSharp.Reflection
{
    /// <summary>
    /// Enumeration of kinds of state machines.
    /// </summary>
    /// <seealso cref="ReflectionExtensions.GetStateMachineKind"/>
    public enum StateMachineKind
    {
        /// <summary>
        /// The method is not implemented by a state machine.
        /// </summary>
        None,

        /// <summary>
        /// Iterator method.
        /// </summary>
        Iterator,

        /// <summary>
        /// Async method.
        /// </summary>
        Async,

        /// <summary>
        /// Async method that returns IAsyncEnumerable&lt;T&gt;. New in C# 8.0.
        /// </summary>
        AsyncIterator
    }
}