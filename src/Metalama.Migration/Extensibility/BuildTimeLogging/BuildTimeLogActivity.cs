using System;

namespace PostSharp.Extensibility.BuildTimeLogging
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Value returned by the <see cref="BuildTimeLogger.Activity(string)"/> method that should
    /// be disposed to mark the end of the activity and decrease the indentation level.
    /// </summary>
    /// <remarks>
    /// <para>Only the value returned by <see cref="BuildTimeLogger.Activity(string)"/> method results in the indentation level
    /// to be decreased upon when the <see cref="Dispose"/> method is invoked. Calling the <see cref="Dispose"/> method on the default instance has no effect.</para>
    /// </remarks>
    public struct BuildTimeLogActivity : IDisposable
    {
        /// <summary>
        /// When the current <see cref="BuildTimeLogActivity"/> has been returned by the  <see cref="BuildTimeLogger.Activity(string)"/> method,
        /// decreases the indentation level.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}