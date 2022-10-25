// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   <b>Internal Only.</b> Custom attribute used internally by <c>PostSharp</c> to mark
    ///   elements having inherited custom attributes. This custom attribute should not
    ///   be used in custom code, otherwise <c>PostSharp</c> may not work properly.
    /// </summary>
    [AttributeUsage( AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface |
                     AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.ReturnValue,
        AllowMultiple = false, Inherited = true )]
    
    public sealed class HasInheritedAttributeAttribute : Attribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "HasInheritedAttributeAttribute" />.
        /// </summary>
        public HasInheritedAttributeAttribute()
        {
        }

        // TODO: Used in compiler.
        /// <exclude />
        [Obsolete("Do not use this custom attribute in user code.", false)]
        public HasInheritedAttributeAttribute(long[] ids)
        {
        }
    }
}