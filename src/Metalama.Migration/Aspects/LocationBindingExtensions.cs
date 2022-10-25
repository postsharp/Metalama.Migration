// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects
{
    public static class LocationBindingExtensions
    {
        public static object GetValue( this ILocationBinding locationBinding, object instance, Arguments index )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, index );
        }

        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, index );
        }

        public static object GetValue( this ILocationBinding locationBinding, object instance )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, Arguments.Empty );
        }

        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, Arguments.Empty );
        }

        public static void SetValue( this ILocationBinding locationBinding, object instance, Arguments index, object value )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, index, value );
        }

        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index, T value )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, index, value );
        }

        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, T value )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, Arguments.Empty, value );
        }

        public static void SetValue( this ILocationBinding locationBinding, object instance, object value )
        {
            if ( locationBinding == null )
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, Arguments.Empty, value );
        }
    }
}