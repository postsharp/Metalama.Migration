// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Reflection
{
    internal enum ReflectionObjectKind
    {
        None = 0,

        Type = 1,

        Constructor = 2,

        Method = 3,

        Property = 4,

        Event = 5,

        Field = 6,

        Parameter = 7,

        ReturnValue = 8
    }
}
