using System;
using System.Reflection;
using PostSharp.Extensibility;

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
    [AttributeUsage(
        AttributeTargets.All & ~( AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter ),
        AllowMultiple = true )]
    [MulticastAttributeUsage( MulticastTargets.Interface, TargetTypeAttributes = MulticastAttributes.Public )]
    public sealed class InternalImplementAttribute : ReferentialConstraint
    {
        /// <summary>
        /// Initializes a new <see cref="InternalImplementAttribute"/>.
        /// </summary>
        public InternalImplementAttribute()
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
        public override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}