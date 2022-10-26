﻿// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using Metalama.Framework.Validation;
using System;
using System.Collections.Generic;
using System.Reflection;

#pragma warning disable CA1801 // Parameters kept for backwards compatibility.

namespace PostSharp.Reflection
{
    /// <summary>
    /// See individual methods for migration assistance.
    /// </summary>
    public static class ReflectionSearch
    {
        /// <summary>
        /// This is currently not exposed in Metalama but it is implemented internally.
        /// </summary>
        public static CustomAttributeInstance[] GetCustomAttributesOfType( Type customAttributeType )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is currently not exposed in Metalama but it is implemented internally.
        /// </summary>
        public static CustomAttributeInstance[] GetCustomAttributesOfType( Type customAttributeType, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, use <see cref="IDeclaration"/>.<see cref="IDeclaration.Attributes"/>.
        /// </summary>
        public static CustomAttributeInstance[] GetCustomAttributesOnTarget( object target )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, use <see cref="IDeclaration"/>.<see cref="IDeclaration.Attributes"/>.
        /// </summary>
        public static CustomAttributeInstance[] GetCustomAttributesOnTarget( object target, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, use <see cref="IDeclaration"/>.<see cref="IDeclaration.Attributes"/>.
        /// </summary>
        public static IList<T> GetCustomAttributesOnTarget<T>( object target, ReflectionSearchOptions options = ReflectionSearchOptions.IncludeDerivedTypes )
            where T : Attribute
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, use <see cref="IDeclaration"/>.<see cref="IDeclaration.Attributes"/>.
        /// </summary>
        public static bool HasCustomAttribute( object target, Type type, bool inherit = false )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, the feature is not exposed on the code model, but it is a part of the validation feature thanks to the
        /// <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/> method.
        /// </summary>
        /// <seealso href="@validating-references"/>
        public static MethodUsageCodeReference[] GetDeclarationsUsedByMethod( MethodBase method )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, the feature is not exposed on the code model, but it is a part of the validation feature thanks to the
        /// <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/> method.
        /// </summary>
        /// <seealso href="@validating-references"/>
        public static MethodUsageCodeReference[] GetDeclarationsUsedByMethod( MethodBase method, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, the feature is not exposed on the code model, but it is a part of the validation feature thanks to the
        /// <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/> method.
        /// </summary>
        /// <seealso href="@validating-references"/>
        public static MethodUsageCodeReference[] GetMethodsUsingDeclaration( MemberInfo declaration )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, the feature is not exposed on the code model, but it is a part of the validation feature thanks to the
        /// <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/> method.
        /// </summary>
        /// <seealso href="@validating-references"/>
        public static MethodUsageCodeReference[] GetMethodsUsingDeclaration( MemberInfo declaration, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, use <see cref="ICompilation"/>.<see cref="ICompilation.GetDerivedTypes(Metalama.Framework.Code.INamedType,bool)"/>.
        /// </summary>
        public static TypeInheritanceCodeReference[] GetDerivedTypes( Type baseType )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, use <see cref="ICompilation"/>.<see cref="ICompilation.GetDerivedTypes(Metalama.Framework.Code.INamedType,bool)"/>.
        /// </summary>
        public static TypeInheritanceCodeReference[] GetDerivedTypes( Type baseType, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, the feature is not exposed on the code model, but it is a part of the validation feature thanks to the
        /// <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/> method.
        /// </summary>
        /// <seealso href="@validating-references"/>
        public static MemberTypeCodeReference[] GetMembersOfType( Type memberType )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, the feature is not exposed on the code model, but it is a part of the validation feature thanks to the
        /// <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/> method.
        /// </summary>
        /// <seealso href="@validating-references"/>
        public static MemberTypeCodeReference[] GetMembersOfType( Type memberType, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }
    }
}