// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    [Flags]
    internal enum ImportKind
    {
        None = 0,
        Event = 2,
        LocationBinding = 4,
        Method = 8,
        Property = 16,
        All = 30,
    }
}
