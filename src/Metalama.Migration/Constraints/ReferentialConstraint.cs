using System.Reflection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Validation;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    // <summary>
    /// In Metalama, use an aspect or a fabric, and register a reference validator using the <see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/>
    /// method. For instance, from the <see cref="IAspect{T}.BuildAspect"/> method of an aspect, call <c>builder</c>.<see cref="IAspectReceiverSelector{TTarget}.With{TMember}(System.Func{TTarget,System.Collections.Generic.IEnumerable{TMember}})"/><c>(...)</c>.<see cref="IValidatorReceiver{TDeclaration}.ValidateReferences"/>.
    /// </summary>
    /// <seealso href="@validating-references"/>
    public abstract class ReferentialConstraint : Constraint, IReferentialConstraint
    {
        public virtual void ValidateCode( object target, Assembly assembly ) { }
    }
}