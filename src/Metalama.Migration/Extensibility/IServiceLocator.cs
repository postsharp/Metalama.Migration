namespace PostSharp.Extensibility
{
    /// <summary>
    /// Exposes build-time services.
    /// </summary>
    public interface IServiceLocator : IService
    {
        /// <summary>
        /// Gets a build-time service exposed by PostSharp.
        /// </summary>
        /// <typeparam name="T">An interface derived from <see cref="IService"/>.</typeparam>
        /// <param name="throwing"><c>true</c> whether an exception should be thrown in case the service cannot be acquired, otherwise <c>false</c>.
        /// The default value is <c>true</c>.</param>
        /// <returns>The service <typeparamref name="T"/>, or <c>null</c> if the service could not be acquired and <paramref name="throwing"/>
        /// was set to <c>false</c>.</returns>
        T GetService<T>( bool throwing = true ) where T : class, IService;
    }
}