// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if LEGACY_MEMBER_INFO
using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    internal sealed class ObfuscatedEventInfo : EventInfo
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)
        private static readonly object[] emptyArray = new object[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)

        private readonly MethodInfo addMethod;
        private readonly MethodInfo removeMethod;
        private readonly MethodInfo raiseMethod;
        private readonly Type declaringType;


        internal ObfuscatedEventInfo( Type declaringType, MethodInfo addMethod, MethodInfo removeMethod, MethodInfo raiseMethod )
        {
            this.addMethod = addMethod;
            this.removeMethod = removeMethod;
            this.declaringType = declaringType;
            this.raiseMethod = raiseMethod;
        }

        public override object[] GetCustomAttributes( bool inherit )
        {
            return emptyArray;
        }

        public override bool IsDefined( Type attributeType, bool inherit )
        {
            return false;
        }

        public override MethodInfo GetAddMethod( bool nonPublic )
        {
            if ( this.addMethod != null && (nonPublic || this.addMethod.IsPublic) )
                return this.addMethod;
            else
                return null;
        }

        public override MethodInfo GetRemoveMethod( bool nonPublic )
        {
            if ( this.removeMethod != null && (nonPublic || this.removeMethod.IsPublic) )
                return this.removeMethod;
            else
                return null;
        }

        public override MethodInfo GetRaiseMethod( bool nonPublic )
        {
            if ( this.raiseMethod != null && (nonPublic || this.raiseMethod.IsPublic) )
                return this.raiseMethod;
            else
                return null;
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
            get { return this.declaringType; }
        }

        public override EventAttributes Attributes
        {
            get { return EventAttributes.None; }
        }

        public override object[] GetCustomAttributes( Type attributeType, bool inherit )
        {
            return emptyArray;
        }
    }
}

#endif