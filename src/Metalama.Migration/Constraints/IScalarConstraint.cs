﻿// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Validation;

namespace PostSharp.Constraints
{
    /// <summary>
    /// In Metalama, use an aspect or a fabric, and register a reference validator using the  <see cref="IValidatorReceiver.ValidateReferences(ReferenceValidator)"/>  method.
    /// For instance, from the <see cref="IAspect{T}.BuildAspect"/> method of an aspect, call <c>builder</c>.<see cref="IAspectReceiverSelector{TTarget}.With{TMember}(System.Func{TTarget,System.Collections.Generic.IEnumerable{TMember}})"/><c>(...)</c>.<see cref="IValidatorReceiver.Validate(ValidatorDelegate{DeclarationValidationContext})"/>.
    /// </summary>
    /// <seealso href="@validating-declarations"/>
    public interface IScalarConstraint : IConstraint
    {
        void ValidateCode( object target );
    }
}