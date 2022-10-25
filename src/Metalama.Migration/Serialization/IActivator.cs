﻿using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Exposes a method <see cref="CreateInstance"/>, which allows to create an instance of a type using the <see cref="Activator"/> facility.
    /// </summary>
    /// <remarks>
    /// <para>PostSharp generates implementations of this interface in each assembly that contains serializable classes. It allows
    /// to create objects in the security context of this assembly (instead of from the security context of <c>PostSharp.dll</c>).</para>
    /// </remarks>
    public interface IActivator
    {
        /// <summary>
        /// Creates an instance of a give type.
        /// </summary>
        /// <param name="objectType">Type of object whose an instance is requested.</param>
        /// <param name="securityToken">A security token.</param>
        /// <returns>A new instance of type <paramref name="objectType"/>.</returns>
        /// <remarks>
        ///     <para>For security reasons, implementations should throw an exception or return <c>null</c> if <paramref name="securityToken"/> is <c>nuill</c>.</para>
        /// </remarks>
        object CreateInstance( Type objectType, ActivatorSecurityToken securityToken );
    }
}