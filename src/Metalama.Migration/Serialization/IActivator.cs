using System;

namespace PostSharp.Serialization
{
    public interface IActivator
    {
        object CreateInstance( Type objectType, ActivatorSecurityToken securityToken );
    }
}