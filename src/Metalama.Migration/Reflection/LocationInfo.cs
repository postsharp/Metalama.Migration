using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Represents a <see cref = "System.Reflection.FieldInfo" />, <see cref = "System.Reflection.PropertyInfo" /> or
    ///   <see cref = "System.Reflection.ParameterInfo" />, which all have the semantics of a location (get value, set value).
    /// </summary>
    [DebuggerNonUserCode]
    [Serializable]
    public sealed class LocationInfo : IEquatable<LocationInfo>
                                     , ISerializable

    {
        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a <see cref = "System.Reflection.FieldInfo" />.
        /// </summary>
        /// <param name = "fieldInfo">The field represented by the <see cref = "LocationInfo" />.</param>
        public LocationInfo( FieldInfo fieldInfo )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a <see cref = "System.Reflection.PropertyInfo" />.
        /// </summary>
        /// <param name = "propertyInfo">The property represented by the <see cref = "LocationInfo" />.</param>
        public LocationInfo( PropertyInfo propertyInfo )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a <see cref = "System.Reflection.ParameterInfo" />.
        /// </summary>
        /// <param name = "parameterInfo">The parameter represented by the <see cref = "LocationInfo" />.</param>
        public LocationInfo( ParameterInfo parameterInfo )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a
        ///   <see cref = "System.Reflection.FieldInfo" />, <see cref = "System.Reflection.PropertyInfo" />, or <see cref = "System.Reflection.ParameterInfo" />.
        /// </summary>
        /// <param name = "reflectionInfo"></param>
        /// <returns></returns>
        public static LocationInfo ToLocationInfo( object reflectionInfo )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Converts a collection of <see cref = "FieldInfo" /> into an array of <see cref = "LocationInfo" />.
        /// </summary>
        /// <param name = "fields">A collection of <see cref = "FieldInfo" />.</param>
        /// <returns>An array of <see cref = "LocationInfo" />.</returns>
        public static LocationInfo[] ToLocationInfoArray( ICollection<FieldInfo> fields )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Converts a collection of <see cref = "PropertyInfo" /> into an array of <see cref = "LocationInfo" />.
        /// </summary>
        /// <param name = "properties">A collection of <see cref = "PropertyInfo" />.</param>
        /// <returns>An array of <see cref = "LocationInfo" />.</returns>
        public static LocationInfo[] ToLocationInfoArray( ICollection<PropertyInfo> properties )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Converts a collection of <see cref = "ParameterInfo" /> into an array of <see cref = "LocationInfo" />.
        /// </summary>
        /// <param name = "parameters">A collection of <see cref = "ParameterInfo" />.</param>
        /// <returns>An array of <see cref = "LocationInfo" />.</returns>
        public static LocationInfo[] ToLocationInfoArray( ICollection<ParameterInfo> parameters )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets the type of values that can be stored in the location.
        /// </summary>
        public Type LocationType { get; }

        /// <summary>
        ///   Gets the location kind (<see cref = "Reflection.LocationKind.Field" />,
        ///   <see cref = "Reflection.LocationKind.Property" />,
        ///   <see cref = "Reflection.LocationKind.Parameter" /> or
        ///   <see cref = "Reflection.LocationKind.ReturnValue" />).
        /// </summary>
        public LocationKind LocationKind { get; }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.PropertyInfo" />,
        ///   or <c>null</c> if the underlying code element is not a property.
        /// </summary>
        public PropertyInfo PropertyInfo { get; }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.FieldInfo" />,
        ///   or <c>null</c> if the underlying code element is not a field.
        /// </summary>
        public FieldInfo FieldInfo { get; }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.ParameterInfo" />,
        ///   or <c>null</c> if the underlying code element is not a parameter.
        /// </summary>
        public ParameterInfo ParameterInfo { get; }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.MemberInfo" />,
        ///   or <c>null</c> if the underlying code element is not a field or a property.
        /// </summary>
        public MemberInfo MemberInfo { get; }

        /// <summary>
        ///   Gets the declaring type of the underlying field, property, parameter, or return value.
        /// </summary>
        public Type DeclaringType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///   Gets the name of the underlying field, property, parameter, or return value.
        /// </summary>
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///   Determines whether the underlying field or property is static.
        /// </summary>
        public bool IsStatic
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///   Returns the value of the field or property represented by the current object.
        /// </summary>
        /// <param name = "instance">The object whose field  or property value will be returned (<c>null</c> if the
        ///   field or property is static).</param>
        /// <returns>The value of the field or property.</returns>
        public object GetValue( object instance )
        {
            return GetValue( instance, null );
        }

        /// <summary>
        ///   Returns the value of the field or property represented by the current object 
        ///   with optional index values for indexed properties.
        /// </summary>
        /// <param name = "instance">The object whose field  or property value will be returned (<c>null</c> if the
        ///   field or property is static).</param>
        /// <param name = "index">Optional index values for indexed properties. <c>null</c> for fields or non-index
        ///   properties.</param>
        /// <returns>The value of the field or property.</returns>
        public object GetValue( object instance, object[] index )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Sets the value of the field or property represented by the current object to a given value.
        /// </summary>
        /// <param name = "instance">The object whose field  or property value will be changed (<c>null</c> if the
        ///   field or property is static).</param>
        /// <param name = "value">New value.</param>
        public void SetValue( object instance, object value )
        {
            SetValue( instance, value, null );
        }

        /// <summary>
        ///   Sets the value of the field or property represented by the current object to a given value
        ///   with optional index values for indexed properties.
        /// </summary>
        /// <param name = "instance">The object whose field  or property value will be changed (<c>null</c> if the
        ///   field or property is static).</param>
        /// <param name = "value">New value.</param>
        /// <param name = "index">Optional index values for indexed properties. <c>null</c> for fields or non-index
        ///   properties.</param>
        public void SetValue( object instance, object value, object[] index )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Equals( LocationInfo other )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Determines whether two instances of <see cref = "LocationInfo" /> represent the same element of code.
        /// </summary>
        /// <param name = "left">A <see cref = "LocationInfo" />.</param>
        /// <param name = "right">A <see cref = "LocationInfo" />.</param>
        /// <returns><c>true</c> if <paramref name = "left" /> and <paramref name = "right" /> are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==( LocationInfo left, LocationInfo right )
        {
            return Equals( left, right );
        }

        /// <summary>
        ///   Determines whether two instances of <see cref = "LocationInfo" /> represent different elements of code.
        /// </summary>
        /// <param name = "left">A <see cref = "LocationInfo" />.</param>
        /// <param name = "right">A <see cref = "LocationInfo" />.</param>
        /// <returns><c>true</c> if <paramref name = "left" /> and <paramref name = "right" /> are different, otherwise <c>false</c>.</returns>
        public static bool operator !=( LocationInfo left, LocationInfo right )
        {
            return !Equals( left, right );
        }

        public void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            throw new NotImplementedException();
        }
    }
}