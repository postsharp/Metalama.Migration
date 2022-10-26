// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Internals;
using System;

namespace PostSharp.Aspects
{
    public sealed class LocationInitializationArgs : LocationLevelAdviceArgs
    {
        internal LocationInitializationArgs()
        {
            throw new NotImplementedException();
        }

        public override object Value { get; set; }
    }
}