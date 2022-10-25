// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// <see cref="ReferentialConstraint"/> that, when applied on a declaration, limits the scope (namespace or type) in which this declaration 
    /// can be used. This constraint is useful to isolate several components from each other, even if they are implemented in
    /// the same assembly. The <i>ComponentInternal</i> constraint sets the visibility of a declaration between <c>internal</c> and <c>private</c>.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class ComponentInternalAttribute : ReferenceConstraint
    {
        private string[] friendNamespaces;

        /// <summary>
        /// Initializes a <see cref="ComponentInternalAttribute"/> restricting the target declaration from being used
        /// from another namespace than the namespace of the declaration.
        /// </summary>
        public ComponentInternalAttribute()
        {
            this.Severity = SeverityType.Warning;
        }

        /// <summary>
        /// Gets or sets the severity of messages emitted by this constraint.
        /// </summary>
        /// <remarks>
        /// <para>The default value is <see cref="SeverityType.Warning"/>.</para>
        /// </remarks>
        public SeverityType Severity { get; set; }

        /// <summary>
        /// Initializes a <see cref="ComponentInternalAttribute"/> restricting the target declaration from being used
        /// outside of given types or namespaces, given as <see cref="Type"/>.
        /// </summary>
        /// <param name="friendTypes">List of types from which the target declaration can be used. If the name of a
        /// type is <c>NamespaceType</c>, the whole namespace of this type is allowed.</param>
        public ComponentInternalAttribute( params Type[] friendTypes )
            : this()
        {
            if ( friendTypes != null )
            {
                this.friendNamespaces = new string[friendTypes.Length];
                for ( int i = 0; i < friendTypes.Length; i++ )
                {
                    string typeName = friendTypes[i].FullName;
                    if ( typeName.EndsWith( ".NamespaceType", StringComparison.Ordinal ) )
                    {
                        typeName = typeName.Substring( 0, typeName.Length - 14 );
                    }
                    this.friendNamespaces[i] = typeName;
                }
            }
        }

        /// <summary>
        /// Initializes a <see cref="ComponentInternalAttribute"/> restricting the target declaration from being used
        /// outside of given types or namespaces, given by strings.
        /// </summary>
        /// <param name="friendNamespaces">List of types or namespaces from which the target declaration
        /// can be used.</param>
        public ComponentInternalAttribute( params string[] friendNamespaces )
            : this()
        {
            this.friendNamespaces = friendNamespaces;
        }

        /// <inheritdoc />
        protected override void ValidateReference( ICodeReference codeReference )
        {

            if ( this.friendNamespaces == null )
            {
                this.friendNamespaces = new[] {ReflectionHelper.GetDeclaringType( codeReference.ReferencedDeclaration ).Namespace};
            }

            object referencingDeclaration = codeReference.ReferencingDeclaration;

            Type usingType;

            MethodInfo referencingMethod = referencingDeclaration as MethodInfo;

            if ( referencingMethod != null && referencingMethod.GetStateMachineKind() != StateMachineKind.None )
            {
                referencingDeclaration = referencingMethod.GetStateMachinePublicMethod();
                usingType = ReflectionHelper.GetNestingType( referencingMethod.DeclaringType );
            }
            else
            {
                Type referencingType;
                MemberInfo referencingDeclarationMemberInfo;
                ReflectionHelper.GetMemberInfo( referencingDeclaration, out referencingType, out referencingDeclarationMemberInfo );

                if ( referencingDeclarationMemberInfo != null && referencingDeclarationMemberInfo.IsCompilerGenerated() )
                    return;

                usingType = ReflectionHelper.GetNestingType( referencingType );
            }

            if ( usingType.IsCompilerGenerated() )
                return;

            Type usedType = ReflectionHelper.GetNestingType( ReflectionHelper.GetDeclaringType( codeReference.ReferencedDeclaration ) );

            if ( usingType == usedType )
                return;

            bool isValid = false;
            foreach ( string friendNamespace in this.friendNamespaces )
            {
                string ns;
                if ( usingType.FullName == friendNamespace || usingType.Namespace == friendNamespace ||
                     ((ns = usingType.Namespace) != null && ns.StartsWith( friendNamespace, StringComparison.Ordinal ) && ns[friendNamespace.Length] == '.') )
                {
                    isValid = true;
                    break;
                }
            }

            if ( isValid )
                return;

            object[] arguments = new object[]
                                 {
                                     ReflectionHelper.GetReflectionObjectKindName( codeReference.ReferencedDeclaration ),
                                     codeReference.ReferencedDeclaration,
                                     ReflectionHelper.GetReflectionObjectKindName( referencingDeclaration ).ToLowerInvariant(),
                                     referencingDeclaration,
                                 };

            ArchitectureMessageSource.Instance.Write( MessageLocation.Of( referencingDeclaration ), this.Severity, "AR0102", arguments );
        }
    }
}