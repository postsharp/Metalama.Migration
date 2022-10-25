// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.RunTime;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="FieldOrPropertyInfo"/>.
    /// </summary>
    public sealed class LocationInfo : IEquatable<LocationInfo>
                                     , ISerializable

    {
        public LocationInfo( FieldInfo fieldInfo )
        {
            throw new NotImplementedException();
        }

        public LocationInfo( PropertyInfo propertyInfo )
        {
            throw new NotImplementedException();
        }

        public LocationInfo( ParameterInfo parameterInfo )
        {
            throw new NotImplementedException();
        }

        public static LocationInfo ToLocationInfo( object reflectionInfo )
        {
            throw new NotImplementedException();
        }

        public static LocationInfo[] ToLocationInfoArray( ICollection<FieldInfo> fields )
        {
            throw new NotImplementedException();
        }

        public static LocationInfo[] ToLocationInfoArray( ICollection<PropertyInfo> properties )
        {
            throw new NotImplementedException();
        }

        public static LocationInfo[] ToLocationInfoArray( ICollection<ParameterInfo> parameters )
        {
            throw new NotImplementedException();
        }

        public Type LocationType { get; }

        public LocationKind LocationKind { get; }

        public PropertyInfo PropertyInfo { get; }

        public FieldInfo FieldInfo { get; }

        public ParameterInfo ParameterInfo { get; }

        public MemberInfo MemberInfo { get; }

        public Type DeclaringType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsStatic
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public object GetValue( object instance )
        {
            return this.GetValue( instance, null );
        }

        public object GetValue( object instance, object[] index )
        {
            throw new NotImplementedException();
        }

        public void SetValue( object instance, object value )
        {
            this.SetValue( instance, value, null );
        }

        public void SetValue( object instance, object value, object[] index )
        {
            throw new NotImplementedException();
        }

        public bool Equals( LocationInfo other )
        {
            throw new NotImplementedException();
        }

        public static bool operator ==( LocationInfo left, LocationInfo right )
        {
            return Equals( left, right );
        }

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