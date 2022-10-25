using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Service that exposes the method <see cref="GetMethodBody"/>, which allows to decompile
    /// a method and get a AST representation.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface IMethodBodyService : IService
    {
        /// <summary>
        /// Decompiles a method and gets an AST representation of it.
        /// </summary>
        /// <param name="method">The method to decompile.</param>
        /// <param name="abstractionLevel">The required level of abstraction and detail.</param>
        /// <returns>AST representing the <paramref name="method"/> at the required level of abstraction and detail.</returns>
        IMethodBody GetMethodBody( MethodBase method, MethodBodyAbstractionLevel abstractionLevel );
    }
}