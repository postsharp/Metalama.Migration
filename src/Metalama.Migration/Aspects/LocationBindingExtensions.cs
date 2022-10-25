using System;

namespace PostSharp.Aspects
{
    // TODO: Create a profile that targets .NET 3.5 so we can use the 'this' keyword for the first parameter.

    public static class LocationBindingExtensions
    {
        public static object GetValue( this ILocationBinding locationBinding, object instance, Arguments index )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, index );
        }

        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, index );
        }

        public static object GetValue( this ILocationBinding locationBinding, object instance )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, Arguments.Empty );
        }

        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, Arguments.Empty );
        }

        public static void SetValue( this ILocationBinding locationBinding, object instance, Arguments index, object value )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, index, value );
        }

        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index, T value )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, index, value );
        }

        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, T value )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, Arguments.Empty, value );
        }

        public static void SetValue( this ILocationBinding locationBinding, object instance, object value )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, Arguments.Empty, value );
        }
    }
}