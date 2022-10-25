// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
    internal interface IReflectionHelperService : IService
    {
        bool IsAvailableInTargetFramework(MemberInfo memberInfo);

        bool IsAvailableInTargetFramework(Type type);

        StateMachineKind GetStateMachineKind( MethodInfo method );

        MethodInfo GetStateMachinePublicMethod(MethodInfo method);

        AssemblyName GetAssemblyName( Assembly assembly );

        bool AssemblyReferenceMatchesDefinition( AssemblyName reference, AssemblyName definition );

        bool AssemblyReferenceMatchesDefinition(AssemblyName reference, Assembly definition);

        DeclarationIdentifier GetDeclarationIdentifier( MemberInfo memberInfo );

        bool IsCompilerGenerated( MemberInfo memberInfo );

        bool IsCompilerGenerated( Type type);

        /// <summary>
        /// Gets the backing field of a given property.
        /// </summary>
        /// <param name="propertyInfo">A property.</param>
        /// <returns>The <see cref="FieldInfo"/> representing the backing field of <paramref name="propertyInfo"/>, or <c>null</c> if <paramref name="propertyInfo"/>
        /// is not an automatic property.</returns>
        FieldInfo GetBackingField( PropertyInfo propertyInfo );

        /// <summary>
        /// Gets the name of the automatic property given the name of the corresponding backing field.
        /// </summary>
        /// <param name="fieldName">A name of the backing field for the automatic property.</param>
        /// <returns>The name of the property that corresponds to the provided name of the backing field,
        /// or <c>null</c> if the name of the field was not in the expected format.</returns>
        string GetAutomaticPropertyName( string fieldName );

        SemanticInfo GetSemanticInfo( MemberInfo member );
        SemanticInfo GetSemanticInfo( Type member);
    }
}
