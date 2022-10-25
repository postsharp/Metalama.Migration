// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if ASYNCAWAIT
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
    internal interface ITaskAdapter
    {
        object GetResult( Task task );
    }
}
#endif
