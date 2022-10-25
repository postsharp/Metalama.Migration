// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
    internal interface IMemberTypeIndexReflectionService : IService
    {
        MemberTypeCodeReference[] GetMembersOfType( Type type, ReflectionSearchOptions options );
    }

}