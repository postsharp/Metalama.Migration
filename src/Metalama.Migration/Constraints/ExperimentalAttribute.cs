using System;
using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Custom attribute that, when applied on a declaration, causes PostSharp to emit a warning if the declaration is being used.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(
        AttributeTargets.All & ~( AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter ),
        AllowMultiple = true )]
    [MulticastAttributeUsage( MulticastTargets.AnyType | MulticastTargets.Method | MulticastTargets.Field )]
    public sealed class ExperimentalAttribute : ReferentialConstraint
    {
        /// <inheritdoc />
        public override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }
    }
}