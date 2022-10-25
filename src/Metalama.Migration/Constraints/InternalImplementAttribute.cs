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
    /// <see cref="ReferentialConstraint"/> that, when applied on an interface, prevents it to be implemented
    /// in a different assembly. This constraint should be used when the author of an interface
    /// does not expect users to implement the interface and wants to reserve the possibility
    /// to add new methods to the interface.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter), AllowMultiple = true)]
    [MulticastAttributeUsage(MulticastTargets.Interface, TargetTypeAttributes = MulticastAttributes.Public)]
    public sealed class InternalImplementAttribute : ReferentialConstraint
    {
        /// <summary>
        /// Initializes a new <see cref="InternalImplementAttribute"/>.
        /// </summary>
        public InternalImplementAttribute()
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
        public override void ValidateCode( object target, Assembly assembly )
        {
            Type type = (Type) target;

            foreach ( TypeInheritanceCodeReference reference in ReflectionSearch.GetDerivedTypes( type ) )
            {
                if (  !reference.BaseType.GetAssembly().AreInternalsVisibleTo( reference.DerivedType.GetAssembly()))
                {
#if LEGACY_REFLECTION_API
                    MemberInfo derivedType = reference.DerivedType;
#else
                    MemberInfo derivedType = reference.DerivedType.GetTypeInfo();
#endif
                    ArchitectureMessageSource.Instance.Write( derivedType, this.Severity, "AR0101", new object[]
                                                                                       {
                                                                                           reference.BaseType.FullName,
                                                                                           reference.DerivedType.FullName
                                                                                       });
                }
            }
        }
    }

}