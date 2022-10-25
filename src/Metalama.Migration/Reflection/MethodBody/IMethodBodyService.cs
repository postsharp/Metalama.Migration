using System;
using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
    [Obsolete( "", true )]
    public interface IMethodBodyService : IService
    {
        IMethodBody GetMethodBody( MethodBase method, MethodBodyAbstractionLevel abstractionLevel );
    }
}