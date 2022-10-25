namespace PostSharp.Extensibility
{
    /// <summary>
    /// Gets a text given its key.
    /// </summary>
    /// <seealso cref="MessageDispenser"/>
    public interface IMessageDispenser
    {
        /// <summary>
        /// Gets a message text given a message key.
        /// </summary>
        /// <param name="key">Message key.</param>
        /// <returns>The text corresponding to <paramref name="key"/>.</returns>
        string GetMessage( string key );
    }
}