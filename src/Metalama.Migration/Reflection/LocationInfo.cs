// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Security;
#if SERIALIZABLE
using System.Runtime.Serialization;
#endif

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Represents a <see cref = "System.Reflection.FieldInfo" />, <see cref = "System.Reflection.PropertyInfo" /> or
    ///   <see cref = "System.Reflection.ParameterInfo" />, which all have the semantics of a location (get value, set value).
    /// </summary>
    [DebuggerNonUserCode]
#if SERIALIZABLE
    [Serializable]
#endif
    public sealed class LocationInfo : IEquatable<LocationInfo>
#if SERIALIZABLE
        , ISerializable
#endif
    {
        private readonly object location;
        private readonly MethodInfo getter;
        private readonly MethodInfo setter;

        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a <see cref = "System.Reflection.FieldInfo" />.
        /// </summary>
        /// <param name = "fieldInfo">The field represented by the <see cref = "LocationInfo" />.</param>
        public LocationInfo( FieldInfo fieldInfo )
        {
            if ( fieldInfo == null )
                throw new ArgumentNullException( nameof(fieldInfo));

            this.location = fieldInfo;
            this.LocationKind = LocationKind.Field;
            this.LocationType = fieldInfo.FieldType;
        }

        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a <see cref = "System.Reflection.PropertyInfo" />.
        /// </summary>
        /// <param name = "propertyInfo">The property represented by the <see cref = "LocationInfo" />.</param>
        public LocationInfo( PropertyInfo propertyInfo )
        {
            if ( propertyInfo == null )
                throw new ArgumentNullException( nameof(propertyInfo));

            this.location = propertyInfo;
            this.LocationKind = LocationKind.Property;
            this.LocationType = propertyInfo.PropertyType;
        }

        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a <see cref = "System.Reflection.ParameterInfo" />.
        /// </summary>
        /// <param name = "parameterInfo">The parameter represented by the <see cref = "LocationInfo" />.</param>
        public LocationInfo( ParameterInfo parameterInfo )
        {
            if ( parameterInfo == null )
                throw new ArgumentNullException( nameof(parameterInfo));

            this.location = parameterInfo;

            this.LocationKind = parameterInfo.Position == -1
                ? LocationKind.ReturnValue
                : LocationKind.Parameter;

            this.LocationType = parameterInfo.ParameterType;
        }

        internal LocationInfo( MethodInfo getter, MethodInfo setter )
        {
            this.LocationKind = LocationKind.Property;

            if ( getter == null && setter == null ) throw new ArgumentException("Getter and setter cannot be both null.");

            this.getter = getter;
            this.setter = setter;
        }

#if SERIALIZABLE
        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="context"></param>
#pragma warning disable IDE0060, CA1801 // Remove unused parameter 
        private LocationInfo(SerializationInfo serializationInfo, StreamingContext context)
#pragma warning restore IDE0060, CA1801 // Remove unused parameter 
        {

        }
#endif

        internal object UnderlyingReflectionObject { get { return this.location; } }

        /// <summary>
        ///   Initializes a new <see cref = "LocationInfo" /> from a
        ///   <see cref = "System.Reflection.FieldInfo" />, <see cref = "System.Reflection.PropertyInfo" />, or <see cref = "System.Reflection.ParameterInfo" />.
        /// </summary>
        /// <param name = "reflectionInfo"></param>
        /// <returns></returns>
        public static LocationInfo ToLocationInfo( object reflectionInfo )
        {
            switch (reflectionInfo)
            {
                case LocationInfo locationInfo:
                    return locationInfo;
                case FieldInfo fieldInfo:
                    return new LocationInfo( fieldInfo );
                case PropertyInfo propertyInfo:
                    return new LocationInfo( propertyInfo );
                case ParameterInfo parameterInfo:
                    return new LocationInfo( parameterInfo );
                default:
                    throw new ArgumentOutOfRangeException( nameof( reflectionInfo ) );
            }
        }

        /// <summary>
        ///   Converts a collection of <see cref = "FieldInfo" /> into an array of <see cref = "LocationInfo" />.
        /// </summary>
        /// <param name = "fields">A collection of <see cref = "FieldInfo" />.</param>
        /// <returns>An array of <see cref = "LocationInfo" />.</returns>
        public static LocationInfo[] ToLocationInfoArray( ICollection<FieldInfo> fields )
        {
            if ( fields == null ) return null;
            LocationInfo[] array = new LocationInfo[fields.Count];

            int i = 0;
            foreach ( FieldInfo item in fields )
            {
                array[i] = new LocationInfo( item );
                i++;
            }

            return array;
        }

        /// <summary>
        ///   Converts a collection of <see cref = "PropertyInfo" /> into an array of <see cref = "LocationInfo" />.
        /// </summary>
        /// <param name = "properties">A collection of <see cref = "PropertyInfo" />.</param>
        /// <returns>An array of <see cref = "LocationInfo" />.</returns>
        public static LocationInfo[] ToLocationInfoArray( ICollection<PropertyInfo> properties )
        {
            if ( properties == null ) return null;
            LocationInfo[] array = new LocationInfo[properties.Count];

            int i = 0;
            foreach ( PropertyInfo item in properties )
            {
                array[i] = new LocationInfo( item );
                i++;
            }

            return array;
        }

        /// <summary>
        ///   Converts a collection of <see cref = "ParameterInfo" /> into an array of <see cref = "LocationInfo" />.
        /// </summary>
        /// <param name = "parameters">A collection of <see cref = "ParameterInfo" />.</param>
        /// <returns>An array of <see cref = "LocationInfo" />.</returns>
        public static LocationInfo[] ToLocationInfoArray( ICollection<ParameterInfo> parameters )
        {
            if ( parameters == null ) return null;
            LocationInfo[] array = new LocationInfo[parameters.Count];

            int i = 0;
            foreach ( ParameterInfo item in parameters )
            {
                array[i] = new LocationInfo( item );
                i++;
            }

            return array;
        }


        /// <summary>
        ///   Gets the type of values that can be stored in the location.
        /// </summary>
        public Type LocationType { get; private set; }

        /// <summary>
        ///   Gets the location kind (<see cref = "Reflection.LocationKind.Field" />,
        ///   <see cref = "Reflection.LocationKind.Property" />,
        ///   <see cref = "Reflection.LocationKind.Parameter" /> or
        ///   <see cref = "Reflection.LocationKind.ReturnValue" />).
        /// </summary>
        public LocationKind LocationKind { get; private set; }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.PropertyInfo" />,
        ///   or <c>null</c> if the underlying code element is not a property.
        /// </summary>
        public PropertyInfo PropertyInfo
        {
            get { return this.location as PropertyInfo; }
        }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.FieldInfo" />,
        ///   or <c>null</c> if the underlying code element is not a field.
        /// </summary>
        public FieldInfo FieldInfo
        {
            get { return this.location as FieldInfo; }
        }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.ParameterInfo" />,
        ///   or <c>null</c> if the underlying code element is not a parameter.
        /// </summary>
        public ParameterInfo ParameterInfo
        {
            get { return this.location as ParameterInfo; }
        }

        /// <summary>
        ///   Gets the underlying <see cref = "System.Reflection.MemberInfo" />,
        ///   or <c>null</c> if the underlying code element is not a field or a property.
        /// </summary>
        public MemberInfo MemberInfo
        {
            get { return this.location as MemberInfo; }
        }

        /// <summary>
        ///   Gets the declaring type of the underlying field, property, parameter, or return value.
        /// </summary>
        public Type DeclaringType
        {
            get
            {
                switch ( this.LocationKind )
                {
                    case LocationKind.Field:
                        return this.FieldInfo.DeclaringType;

                    case LocationKind.Parameter:
                    case LocationKind.ReturnValue:
                        return this.ParameterInfo.Member.DeclaringType;

                    case LocationKind.Property:
                        return this.PropertyInfo.DeclaringType;

                    default:
                        return null;
                }
            }
        }

        /// <summary>
        ///   Gets the name of the underlying field, property, parameter, or return value.
        /// </summary>
        public string Name
        {
            get
            {
                switch ( this.LocationKind )
                {
                    case LocationKind.Field:
                        return this.FieldInfo.Name;

                    case LocationKind.Parameter:
                        return this.ParameterInfo.Name;

                    case LocationKind.ReturnValue:
                        return "(Return Value)";


                    case LocationKind.Property:
                        return this.PropertyInfo.Name;

                    default:
                        return null;
                }
            }
        }

        /// <summary>
        ///   Determines whether the underlying field or property is static.
        /// </summary>
        public bool IsStatic
        {
            get
            {
                switch ( this.LocationKind )
                {
                    case LocationKind.Field:
                        return this.FieldInfo.IsStatic;


                    case LocationKind.Property:
                        {
                            MethodInfo method = this.getter ?? this.setter ?? this.PropertyInfo.GetGetMethod(true) ??
                                                this.PropertyInfo.GetSetMethod(true);
                            if ( method == null )
                                throw new InvalidOperationException();

                            return method.IsStatic;
                        }

                    default:
                        throw new InvalidOperationException();
                }
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
            return this.GetValue( instance, null );
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
            switch ( this.LocationKind )
            {
                case LocationKind.Field:
                    return this.FieldInfo.GetValue( instance );

                case LocationKind.Property:
                    if ( this.PropertyInfo != null )
                    {
                        return this.PropertyInfo.GetValue( instance, index );
                    }
                    else if ( this.getter != null )
                    {
                        return this.getter.Invoke( instance, index );
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        ///   Sets the value of the field or property represented by the current object to a given value.
        /// </summary>
        /// <param name = "instance">The object whose field  or property value will be changed (<c>null</c> if the
        ///   field or property is static).</param>
        /// <param name = "value">New value.</param>
        public void SetValue( object instance, object value )
        {
            this.SetValue( instance, value, null );
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
            switch ( this.LocationKind )
            {
                case LocationKind.Field:
                    this.FieldInfo.SetValue( instance, value );
                    return;

                case LocationKind.Property:
                    if ( this.PropertyInfo != null )
                    {
                        this.PropertyInfo.SetValue( instance, value, index );
                    }
                    else if ( this.setter != null )
                    {
                        object[] arguments;
                        if ( index == null || index.Length == 0 )
                        {
                            arguments = new [] { value};
                        }
                        else
                        {
                            arguments = new object[index.Length+1];
                            Array.Copy( index, arguments, index.Length );
                            arguments[arguments.Length - 1] = value;
                        }
                        this.setter.Invoke( instance, arguments );
                    }
                    return;

                default:
                    throw new InvalidOperationException();
            }
        }


        /// <inheritdoc />
        public override string ToString()
        {
            return this.location != null ? this.location.ToString() : "<Missing Property>";
        }

        /// <inheritdoc />
        public override bool Equals( object obj )
        {
            LocationInfo locationInfo = obj as LocationInfo;
            return locationInfo != null && this.location.Equals( locationInfo.location );
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return ~this.location.GetHashCode();
        }

#if SERIALIZABLE
        [SecurityCritical]
        void ISerializable.GetObjectData( SerializationInfo info, StreamingContext context )
        {
            throw new NotImplementedException();
        }
#endif

        /// <inheritdoc />
        public bool Equals( LocationInfo other )
        {
            if ( other == null ) return false;
            return this.location.Equals( other.location );
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
    }
}