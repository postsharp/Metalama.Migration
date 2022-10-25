// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Globalization;
using System.Resources;

namespace PostSharp.Extensibility
{
    internal class ResourceManagerMessageDispenser : IMessageDispenser
    {
        private readonly ResourceManager resourceManager;

        public ResourceManagerMessageDispenser( ResourceManager resourceManager )
        {
            this.resourceManager = resourceManager;
        }

        public string GetMessage( string key )
        {
            return this.resourceManager.GetString( key, CultureInfo.InvariantCulture );
        }
    }
}
