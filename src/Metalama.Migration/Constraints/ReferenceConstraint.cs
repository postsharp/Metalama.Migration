using System;
using System.Reflection;
using PostSharp.Extensibility;
using PostSharp.Reflection;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    [AttributeUsage(
        AttributeTargets.All & ~( AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter ),
        AllowMultiple = true )]
    [MulticastAttributeUsage(
        MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetTypeAttributes = MulticastAttributes.Public | MulticastAttributes.Internal | MulticastAttributes.InternalOrProtected
                               | MulticastAttributes.UserGenerated,
        TargetMemberAttributes = MulticastAttributes.AnyVisibility & ~MulticastAttributes.Private )]
    public abstract class ReferenceConstraint : ReferentialConstraint
    {
        protected abstract void ValidateReference( ICodeReference reference );

        public sealed override void ValidateCode( object target, Assembly assembly )
        {
            var targetMember = target as MemberInfo;

            if (targetMember != null)
            {
                var targetType = target as Type;

                if (targetType != null)
                {
                    foreach (
                        var reference in ReflectionSearch.GetDerivedTypes( targetType, ReflectionSearchOptions.IncludeTypeElement ))
                    {
                        ValidateReference( reference );
                    }

                    foreach (var reference in ReflectionSearch.GetMembersOfType( targetType, ReflectionSearchOptions.IncludeTypeElement ))
                    {
                        ValidateReference( reference );
                    }
                }

                foreach (var methodUsageCodeReference in ReflectionSearch.GetMethodsUsingDeclaration( targetMember ))
                {
                    ValidateReference( methodUsageCodeReference );
                }
            }
        }
    }
}