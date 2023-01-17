// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// There is no full equivalent of this attribute in Metalama, and there will not be. To mark an aspect as inherited, use the <see cref="InheritableAttribute"/>
    /// custom attribute. To specify the eligibility of an aspect, implement the <see cref="IEligible{T}.BuildEligibility"/> method.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class MulticastAttributeUsageAttribute : Attribute
    {
        /// <summary>
        /// In Metalama, the valid targets are determined by the declaration types for which the <see cref="IAspect{T}"/> interface is implemented.
        /// Additionally, you can implement the <see cref="IEligible{T}.BuildEligibility"/> method.
        /// </summary>
        /// <param name="validOn"></param>
        /// <exception cref="NotImplementedException"></exception>
        public MulticastAttributeUsageAttribute( MulticastTargets validOn )
        {
            throw new NotImplementedException();
        }

        public MulticastAttributeUsageAttribute() { }

        /// <summary>
        /// In Metalama, the valid targets are determined by the declaration types for which the <see cref="IAspect{T}"/> interface is implemented.
        /// Additionally, you can implement the <see cref="IEligible{T}.BuildEligibility"/> method.
        /// </summary>
        public MulticastTargets ValidOn { get; }

        /// <summary>
        /// Metalama always allows multiple attributes, but only one is actually processed. The other instances are exposed in <c>builder</c>.<see cref="IAspectBuilder.AspectInstance"/>.<see cref="IAspectInstance.SecondaryInstances"/>.
        /// It is up to the <see cref="IAspect{T}.BuildAspect"/> implementation to handle the situation with many aspects.
        /// </summary>
        public bool AllowMultiple { get; set; }

        /// <summary>
        /// To mark an aspect as inherited, use <see cref="InheritableAttribute"/> or implement <see cref="IConditionallyInheritableAspect"/>. Multicast inheritance is not supported in Metalama, but you can build a similar feature
        /// by making the aspect implement the <see cref="IAspect{T}"/> for <see cref="INamedType"/> and implement multicasting in the <see cref="IAspect{T}.BuildAspect"/>
        /// method.
        /// </summary>
        public MulticastInheritance Inheritance { get; set; }

        /// <summary>
        /// Targeting external declarations is not supported in Metalama.
        /// </summary>
        [Obsolete( "", true )]
        public bool AllowExternalAssemblies { get; set; }

        /// <summary>
        /// By default, custom attributes (metadata) are preserved in the code. To remove them, use the advice <see cref="IAdviceFactory.RemoveAttributes(Metalama.Framework.Code.IDeclaration,Metalama.Framework.Code.INamedType)"/>.
        /// </summary>
        public bool PersistMetaData { get; set; }

        /// <summary>
        /// In Metalama, implement the <see cref="IEligible{T}.BuildEligibility"/> method.
        /// </summary>
        public MulticastAttributes TargetMemberAttributes { get; set; }

        /// <summary>
        /// Applying an aspect to an external declaration is not supported in Metalama.
        /// </summary>
        public MulticastAttributes TargetExternalMemberAttributes { get; set; }

        /// <summary>
        /// In Metalama, implement the <see cref="IEligible{T}.BuildEligibility"/> method.
        /// </summary>
        public MulticastAttributes TargetParameterAttributes { get; set; }

        /// <summary>
        /// In Metalama, implement the <see cref="IEligible{T}.BuildEligibility"/> method.
        /// </summary>
        public MulticastAttributes TargetTypeAttributes { get; set; }

        /// <summary>
        /// Applying an aspect to an external declaration is not supported in Metalama.
        /// </summary>
        public MulticastAttributes TargetExternalTypeAttributes { get; set; }
    }
}