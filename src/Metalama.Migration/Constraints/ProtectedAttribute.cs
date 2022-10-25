// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Custom attribute that, when applied to a target declaration, causes PostSharp to emit a warning if the declaration
    /// is being referenced from classes that are not derived from the target class. This constraint is similar to the
    /// C# keyword <c>protected</c> and should be used only when the target declaration must be made public or internal
    /// for non-architectural reasons.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter), AllowMultiple = true)]
    [MulticastAttributeUsage(MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetTypeAttributes = MulticastAttributes.Public | MulticastAttributes.Internal | MulticastAttributes.UserGenerated,
        TargetMemberAttributes = MulticastAttributes.Public | MulticastAttributes.Internal)]
    public sealed class ProtectedAttribute : ReferentialConstraint
    {
        /// <summary>
        /// Initializes a new <see cref="ProtectedAttribute"/>.
        /// </summary>
        public ProtectedAttribute()
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

        /// <inheritdoc />
        public override bool ValidateConstraint(object target)
        {
            if (ReflectionHelper.IsOnlyFamilyVisible((MemberInfo)target))
            {
                ArchitectureMessageSource.Instance.Write(MessageLocation.Of(target), SeverityType.Error, "AR0107", new object[]
                                                                                                                          {
                                                                                                                              ReflectionHelper.
                                                                                                                                  GetReflectionObjectKindName(
                                                                                                                                      target ).ToLowerInvariant()
                                                                                                                              ,
                                                                                                                              ReflectionHelper.
                                                                                                                                  GetReflectionObjectName(
                                                                                                                                      target ),
                                                                                                                          });
                return false;
            }

            return true;
        }

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

            if ( !usedType.IsAssignableFrom( usingType ) )
            {
                ArchitectureMessageSource.Instance.Write(
                    MessageLocation.Of( referencingDeclaration ),
                    this.Severity, "AR0108", new object[]
                                             {
                                                 ReflectionHelper.GetReflectionObjectKindName( referencedDeclaration ),
                                                 referencedDeclaration,
                                                 ReflectionHelper.GetReflectionObjectKindName(
                                                     referencingDeclaration ).ToLowerInvariant(),
                                                 referencingDeclaration,
                                             } );
            }
        }

        /// <inheritdoc />

        public override void ValidateCode(object target, Assembly assembly)
        {
            MemberInfo member = target as MemberInfo;
            if (member != null)
            {
                Type type = target as Type;

                foreach (MethodUsageCodeReference reference in ReflectionSearch.GetMethodsUsingDeclaration(member, ReflectionSearchOptions.None))
                {
                    this.Validate(reference);
                }

                if (type != null)
                {
                    foreach (TypeInheritanceCodeReference reference in ReflectionSearch.GetDerivedTypes(type, ReflectionSearchOptions.IncludeTypeElement))
                    {
                        this.Validate(reference);
                    }

                    foreach (MemberTypeCodeReference reference in ReflectionSearch.GetMembersOfType(type, ReflectionSearchOptions.IncludeTypeElement))
                    {
                        this.Validate(reference);
                    }
                }
            }
        }
    }
}
