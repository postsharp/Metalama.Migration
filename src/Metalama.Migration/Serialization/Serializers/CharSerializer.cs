// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Globalization;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class CharSerializer : IntrinsicSerializer<char>
    {
        public override object Convert( object value, Type targetType )
        {
            return System.Convert.ToChar( value, CultureInfo.InvariantCulture);
        }

        
    }
}