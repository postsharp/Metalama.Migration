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
    /// <see cref="ReferentialConstraint"/>, when applied to a declaration, prevents it to be used from a different assembly. 
    /// This constraint can be used when a declaration must be made public for technical reasons, but its author does
    /// not want it to be used in external code.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter), AllowMultiple = true)]
    [MulticastAttributeUsage( MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetMemberAttributes = MulticastAttributes.Public, 
        TargetTypeAttributes = MulticastAttributes.Public | MulticastAttributes.UserGenerated)]
    public sealed class InternalAttribute : ReferentialConstraint
    {
        /// <summary>
        /// Initializes a new <see cref="InternalAttribute"/>.
        /// </summary>
        public InternalAttribute()
        {
            this.Severity = SeverityType.Warning;
        }

        /// <inheritdoc />
        public override bool ValidateConstraint( object target )
        {
            if ( !ReflectionHelper.IsExported( (MemberInfo) target ) )
            {
                ArchitectureMessageSource.Instance.Write( MessageLocation.Of( target ), SeverityType.Error, "AR0104", new object[]
                                                                                                                          {
                                                                                                                              ReflectionHelper.
                                                                                                                                  GetReflectionObjectKindName(
                                                                                                                                      target ).ToLowerInvariant()
                                                                                                                              ,
                                                                                                                              ReflectionHelper.
                                                                                                                                  GetReflectionObjectName(
                                                                                                                                      target ),
                                                                                                                          } );
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets or sets the severity of messages emitted by this constraint.
        /// </summary>
        /// <remarks>
        /// <para>The default value is <see cref="SeverityType.Warning"/>.</para>
        /// </remarks>
        public SeverityType Severity { get; set; }

        private void Validate( ICodeReference codeReference, object referencedDeclaration = null )
        {
            if ( referencedDeclaration == null )
            {
                referencedDeclaration = codeReference.ReferencedDeclaration;
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

            if ( !usingType.GetAssembly().AreInternalsVisibleTo( usedType.GetAssembly() ) )
            {
                ArchitectureMessageSource.Instance.Write(
                    MessageLocation.Of( codeReference.ReferencingDeclaration ),
                    this.Severity, "AR0105", new object[]
                                             {
                                                 ReflectionHelper.GetReflectionObjectKindName( referencedDeclaration ),
                                                 referencedDeclaration,
                                                 ReflectionHelper
                                                     .GetReflectionObjectKindName( referencingDeclaration ).ToLowerInvariant(),
                                                 referencingDeclaration,
                                             } );
            }
        }

        /// <inheritdoc />
        
        public override void ValidateCode( object target, Assembly assembly )
        {
            if ( ReflectionHelper.GetDeclaringAssembly( target  ) == assembly )
            {
                // Nothing to check in the current assembly.
                return;
            }

            MemberInfo member = target as MemberInfo;
            if ( member != null )
            {
                Type type = target as Type;

                foreach ( MethodUsageCodeReference reference in ReflectionSearch.GetMethodsUsingDeclaration( member, ReflectionSearchOptions.None ) )
                {
                    this.Validate( reference );
                }

                if (type != null)
                {
                    foreach ( TypeInheritanceCodeReference reference in ReflectionSearch.GetDerivedTypes( type, ReflectionSearchOptions.IncludeTypeElement ) )
                    {
                        this.Validate( reference );
                    }

                    foreach ( MemberTypeCodeReference reference in ReflectionSearch.GetMembersOfType( type, ReflectionSearchOptions.IncludeTypeElement ) )
                    {
                        this.Validate( reference );
                    }
                }
            }
        }
    }

}
