using System;
using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Not implemented yet in Metalama, but it will be.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.All & ~( AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter ),
        AllowMultiple = true )]
    [MulticastAttributeUsage( MulticastTargets.Interface, TargetTypeAttributes = MulticastAttributes.Public )]
    public sealed class InternalImplementAttribute : ReferentialConstraint
    {
        public InternalImplementAttribute()
        {
            Severity = SeverityType.Warning;
        }

        public SeverityType Severity { get; set; }

        public override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}