// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Custom attribute that, when applied on a declaration, causes PostSharp to emit a warning if the declaration is being used.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(AttributeTargets.All & ~(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter), AllowMultiple = true)]
    [MulticastAttributeUsage(MulticastTargets.AnyType|MulticastTargets.Method|MulticastTargets.Field)]
    public sealed class ExperimentalAttribute : ReferentialConstraint
    {
        /// <inheritdoc />
        public override void ValidateCode(object target, Assembly assembly)
        {
            ArchitectureMessageSource.Instance.Write(MessageLocation.Of(assembly),
                                                          SeverityType.Warning, "AR0106", new object[]
                                                                                            {
                                                                                                assembly,
                                                                                                ReflectionHelper.GetReflectionObjectKindName( target ).
                                                                                                    ToLowerInvariant(),
                                                                                                ReflectionHelper.GetReflectionObjectName( target ),
                                                                                            });
        }
    }
}

