// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Extensibility;
using PostSharp.Reflection;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    /// <summary>
    /// Base class for constraints validating code references.
    /// </summary>
    [AttributeUsage(AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter), AllowMultiple = true)]
    [MulticastAttributeUsage(MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetTypeAttributes = MulticastAttributes.Public | MulticastAttributes.Internal | MulticastAttributes.InternalOrProtected | MulticastAttributes.UserGenerated,
        TargetMemberAttributes = MulticastAttributes.AnyVisibility & ~MulticastAttributes.Private)]
    public abstract class ReferenceConstraint : ReferentialConstraint
    {
        /// <summary>
        /// Validates a reference to the target declaration of the current constraint.
        /// </summary>
        /// <param name="reference">Represents a reference to the target of the current constraint.</param>
        protected abstract void ValidateReference( ICodeReference reference );

        /// <exclude />

        public sealed override void ValidateCode(object target, Assembly assembly)
        {
            MemberInfo targetMember = target as MemberInfo;

            if (targetMember != null)
            {
                Type targetType = target as Type;
                if (targetType != null)
                {
                    foreach (
                        TypeInheritanceCodeReference reference in ReflectionSearch.GetDerivedTypes(targetType, ReflectionSearchOptions.IncludeTypeElement))
                    {
                        this.ValidateReference(reference);
                    }

                    foreach (MemberTypeCodeReference reference in ReflectionSearch.GetMembersOfType(targetType, ReflectionSearchOptions.IncludeTypeElement))
                    {
                        this.ValidateReference(reference);
                    }
                }


                foreach (MethodUsageCodeReference methodUsageCodeReference in ReflectionSearch.GetMethodsUsingDeclaration(targetMember))
                {
                    this.ValidateReference(methodUsageCodeReference);
                }
            }
        }
    }
}
