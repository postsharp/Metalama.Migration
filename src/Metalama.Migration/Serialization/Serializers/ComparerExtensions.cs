// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;

namespace PostSharp.Serialization.Serializers
{
    internal static class ComparerExtensions
    {
        public static byte GetComparerCode<T>(IEqualityComparer<T> comparer)
        {
            if (Equals(comparer, EqualityComparer<T>.Default ))
            {
                return 0;
            }

            if (Equals(comparer, StringComparer.CurrentCulture))
            {
                return 1;
            }

            if (Equals( comparer, StringComparer.CurrentCultureIgnoreCase ))
            {
                return 2;
            }

            if (Equals( comparer, StringComparer.Ordinal ))
            {
                return 3;
            }

            if (Equals(comparer, StringComparer.OrdinalIgnoreCase))
            {
                return 4;
            }

            return byte.MaxValue;
        }

        public static IEqualityComparer<string> GetComparerFromCode(byte code)
        {
            switch ( code )
            {
                case 1:
                    return StringComparer.CurrentCulture;
                case 2:
                    return StringComparer.CurrentCultureIgnoreCase;
                case 3:
                    return StringComparer.Ordinal;
                case 4:
                    return StringComparer.OrdinalIgnoreCase;
                default:
                    return null;
            }
        }
    }
}
