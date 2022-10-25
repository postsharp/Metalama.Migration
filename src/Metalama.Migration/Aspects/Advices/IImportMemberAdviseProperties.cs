// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;
using System.Runtime.InteropServices;

namespace PostSharp.Aspects.Advices
{
    internal interface IImportMemberAdviseProperties
    {
        bool IsRequired { get; }

        string[] MemberNames { get; }

        ImportMemberOrder Order { get; }
    }
}
