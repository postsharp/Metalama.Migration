using System;

namespace PostSharp.Aspects
{
    // TODO: Create a profile that targets .NET 3.5 so we can use the 'this' keyword for the first parameter.

    /// <summary>
    /// Extension methods for the <see cref="ILocationBinding"/> interface.
    /// </summary>
    public static class LocationBindingExtensions
    {
        /// <summary>
        /// Gets the value of an indexer (property with arguments).
        /// </summary>
        /// <param name="locationBinding">The binding for the indexer.</param>
        /// <param name="instance">The instance for which the indexer is evaluated, or <c>null</c> if the indexer is static.</param>
        /// <param name="index">The arguments of the indexer.</param>
        /// <returns>The indexer value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
        public static object GetValue( this ILocationBinding locationBinding, object instance, Arguments index )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, index );
        }

        /// <summary>
        /// Gets the value of an indexer (property with arguments).
        /// </summary>
        /// <param name="locationBinding">The binding for the indexer.</param>
        /// <param name="instance">The instance for which the indexer is evaluated, or <c>null</c> if the indexer is static.</param>
        /// <param name="index">The arguments of the indexer.</param>
        /// <returns>The indexer value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, index );
        }

        /// <summary>
        /// Gets the value of a field or property.
        /// </summary>
        /// <param name="locationBinding">The binding for the field or property.</param>
        /// <param name="instance">The instance for which the field or property is evaluated, or <c>null</c> if the location is static.</param>
        /// <returns>The field or property value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
        public static object GetValue( this ILocationBinding locationBinding, object instance )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, Arguments.Empty );
        }

        /// <summary>
        /// Gets the value of a field or property.
        /// </summary>
        /// <param name="locationBinding">The binding for the field or property.</param>
        /// <param name="instance">The instance for which the field or property is evaluated, or <c>null</c> if the location is static.</param>
        /// <returns>The field or property value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
        public static T GetValue<T>( this ILocationBinding<T> locationBinding, object instance )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            return locationBinding.GetValue( ref instance, Arguments.Empty );
        }

        /// <summary>
        /// Sets the value of an indexer (property with arguments).
        /// </summary>
        /// <param name="locationBinding">The binding for the indexer.</param>
        /// <param name="instance">The instance for which the indexer is set, or <c>null</c> if the indexer is static.</param>
        /// <param name="index">The arguments of the indexer.</param>
        /// <param name="value">The new value.</param>
        /// <returns>The indexer value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
        public static void SetValue( this ILocationBinding locationBinding, object instance, Arguments index, object value )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, index, value );
        }

        /// <summary>
        /// Sets the value of an indexer (property with arguments).
        /// </summary>
        /// <param name="locationBinding">The binding for the indexer.</param>
        /// <param name="instance">The instance for which the indexer is set, or <c>null</c> if the indexer is static.</param>
        /// <param name="index">The arguments of the indexer.</param>
        /// <param name="value">The new value.</param>
        /// <returns>The indexer value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, Arguments index, T value )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, index, value );
        }

        /// <summary>
        /// Sets the value of a field or property.
        /// </summary>
        /// <param name="locationBinding">The binding for the field or property.</param>
        /// <param name="instance">The instance for which the field or property is set, or <c>null</c> if the location is static.</param>
        /// <param name="value">The new value assigned to the field or property.</param>
        /// <returns>The field or property value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
        public static void SetValue<T>( this ILocationBinding<T> locationBinding, object instance, T value )
        {
            if (locationBinding == null)
            {
                throw new ArgumentNullException( nameof(locationBinding) );
            }

            locationBinding.SetValue( ref instance, Arguments.Empty, value );
        }

        /// <summary>
        /// Sets the value of a field or property.
        /// </summary>
        /// <param name="locationBinding">The binding for the field or property.</param>
        /// <param name="instance">The instance for which the field or property is set, or <c>null</c> if the location is static.</param>
        /// <param name="value">The new value assigned to the field or property.</param>
        /// <returns>The field or property value.</returns>
        /// <seealso cref="ILocationBinding.GetValue"/>
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