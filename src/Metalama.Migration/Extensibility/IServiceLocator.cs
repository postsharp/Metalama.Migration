namespace PostSharp.Extensibility
{
    public interface IServiceLocator : IService
    {
        T GetService<T>( bool throwing = true ) where T : class, IService;
    }
}