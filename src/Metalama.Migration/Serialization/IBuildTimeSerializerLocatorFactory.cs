// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Extensibility;

namespace PostSharp.Serialization
{
    internal interface IBuildTimeSerializerLocatorFactory : IService
    {
        ISerializerFactoryProvider Create( ISerializerFactoryProvider next );
    }
}
