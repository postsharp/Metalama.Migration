// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if LEGACY_MEMBER_INFO
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace PostSharp.Reflection
{
    internal sealed class ObfuscatedPropertyInfo : PropertyInfo
    {
        private readonly Type declaringType;
        private readonly MethodInfo getter;
        private readonly MethodInfo setter;

#pragma warning disable CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)
        private static readonly object[] emptyArray = new object[0];
        private static readonly ParameterInfo[] emptyParameterInfoArray = new ParameterInfo[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)

        internal ObfuscatedPropertyInfo( Type declaringType, MethodInfo getter, MethodInfo setter )
        {
            if ( getter == null && setter == null )

                throw new ArgumentException( "Parameters 'getter' and 'setter' cannot be both null." );
            this.declaringType = declaringType;
            this.getter = getter;
            this.setter = setter;
        }


        public override object[] GetCustomAttributes( bool inherit )
        {
            return emptyArray;
        }

        public override bool IsDefined( Type attributeType, bool inherit )
        {
            return false;
        }

        public override object GetValue( object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture )
        {
            if ( this.getter == null )
                throw new InvalidOperationException();

            return this.getter.Invoke( obj, invokeAttr, binder, index, culture );
        }

        public override void SetValue( object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture )
        {
            if ( this.setter == null )
                throw new InvalidOperationException();

            index = index ?? emptyArray;
            object[] parameters = new object[index.Length + 1];
            this.setter.Invoke( obj, invokeAttr, binder, parameters, culture );
        }

        public override MethodInfo[] GetAccessors( bool nonPublic )
        {
            List<MethodInfo> accessors = new List<MethodInfo>( 2 );

            if ( this.getter != null && (nonPublic || this.getter.IsPublic) )
                accessors.Add(this.getter );

            if ( this.setter != null && (nonPublic || this.setter.IsPublic) )
                accessors.Add(this.setter );

            return accessors.ToArray();
        }

        public override MethodInfo GetGetMethod( bool nonPublic )
        {
            if ( this.getter != null && (nonPublic || this.getter.IsPublic) )
                return this.getter;
            else
                return null;
        }

        public override MethodInfo GetSetMethod( bool nonPublic )
        {
            if ( this.setter != null && (nonPublic || this.setter.IsPublic) )
                return this.setter;
            else
                return null;
        }

        public override ParameterInfo[] GetIndexParameters()
        {
            if ( this.getter != null )
            {
                return this.getter.GetParameters();
            }
            else
            {
                ParameterInfo[] setterParameters = this.setter.GetParameters();
                if ( setterParameters.Length == 1 ) return emptyParameterInfoArray;

                ParameterInfo[] indexParameters = new ParameterInfo[setterParameters.Length - 1];
                Array.Copy( setterParameters, indexParameters, indexParameters.Length );

                return indexParameters;
            }
        }

        public override string Name
        {
            get { return null; }
        }

        public override Type DeclaringType
        {
            get { return this.declaringType; }
        }

        public override Type ReflectedType
        {
            get { return this.ReflectedType; }
        }

        public override Type PropertyType
        {
            get
            {
                if ( this.getter != null )
                {
                    return this.getter.ReturnType;
                }
                else
                {
                    ParameterInfo[] setterParameters = this.setter.GetParameters();
                    return setterParameters[setterParameters.Length - 1].ParameterType;
                }
            }
        }

        public override PropertyAttributes Attributes
        {
            get { return PropertyAttributes.None; }
        }

        public override bool CanRead
        {
            get { return this.getter != null; }
        }

        public override bool CanWrite
        {
            get { return this.setter != null; }
        }

        public override object[] GetCustomAttributes( Type attributeType, bool inherit )
        {
            return emptyArray;
        }
    }
}

#endif