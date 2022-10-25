using System;
using System.Reflection;
using PostSharp.Extensibility;

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
    [AttributeUsage(
        AttributeTargets.All & ~( AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter ),
        AllowMultiple = true )]
    [MulticastAttributeUsage(
        MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.Field,
        TargetTypeAttributes = MulticastAttributes.Public | MulticastAttributes.Internal | MulticastAttributes.UserGenerated,
        TargetMemberAttributes = MulticastAttributes.Public | MulticastAttributes.Internal )]
    public sealed class ProtectedAttribute : ReferentialConstraint
    {
        /// <summary>
        /// Initializes a new <see cref="ProtectedAttribute"/>.
        /// </summary>
        public ProtectedAttribute()
        {
            Severity = SeverityType.Warning;
        }

        /// <summary>
        /// Gets or sets the severity of messages emitted by this constraint.
        /// </summary>
        /// <remarks>
        /// <para>The default value is <see cref="SeverityType.Warning"/>.</para>
        /// </remarks>
        public SeverityType Severity { get; set; }

        /// <inheritdoc />
        public override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        public override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}