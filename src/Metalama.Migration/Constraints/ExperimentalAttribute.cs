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
    [MulticastAttributeUsage( MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.Field )]
    public sealed class ExperimentalAttribute : ReferentialConstraint
    {
        public override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}