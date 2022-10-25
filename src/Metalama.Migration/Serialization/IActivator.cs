using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public interface IActivator
    {
        object CreateInstance( Type objectType, ActivatorSecurityToken securityToken );
    }
}