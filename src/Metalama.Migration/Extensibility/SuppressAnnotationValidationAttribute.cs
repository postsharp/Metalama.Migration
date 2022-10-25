// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Instructs PostSharp that the validation of <see cref="IValidableAnnotation"/> is done by another component, and should
    /// not be processed by the default component.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface )]
    public class SuppressAnnotationValidationAttribute : Attribute
    {
    }
}
