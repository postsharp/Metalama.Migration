// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Serialization
{
    /// <summary>
    /// Security token passed to the <see cref="IActivator.CreateInstance"/> method of the <see cref="IActivator"/> interface.
    /// </summary>
    public sealed class ActivatorSecurityToken
    {
        private ActivatorSecurityToken() {}

        internal static readonly  ActivatorSecurityToken Instance = new ActivatorSecurityToken();
    }
}
