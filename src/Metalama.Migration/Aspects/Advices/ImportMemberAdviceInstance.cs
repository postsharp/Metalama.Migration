// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Base class for <see cref="ImportLocationAdviceInstance"/> and <see cref="ImportMethodAdviceInstance"/>.
    /// </summary>
    /// <seealso cref="IAdviceProvider"/>
    /// <seealso cref="ImportMemberAttribute"/>
    public abstract class ImportMemberAdviceInstance : AdviceInstance, IImportMemberAdviseProperties
    {

        internal ImportMemberAdviceInstance(FieldInfo aspectField, ImportMemberOrder order, bool isRequired )
        {
            this.Order = order;
            if ( aspectField == null )
                throw new ArgumentNullException(nameof(aspectField));

            // TODO: validate that the type is compatible.

            this.AspectField = aspectField;
            this.IsRequired = isRequired;
        }

        /// <summary>
        /// Gets the field of the aspect class to which the field or property needs to be bound.
        /// </summary>
        public FieldInfo AspectField { get; private set; }

        /// <summary>
        /// Determines whether a build-time error should be emitted if the member cannot be found.
        /// If <c>false</c>, the binding field will be <c>null</c> in case the imported member is absent.
        /// </summary>
        /// <remarks>
        /// <para>This property is always <c>true</c> when the <see cref="Member"/> property is set.</para>
        /// </remarks>
        public bool IsRequired { get; private set; }

        /// <summary>
        /// Gets the reflection object (<see cref="LocationInfo"/> or <see cref="MethodInfo"/>) that needs to be
        /// imported, or <c>null</c> if the exact member is unknown and must be matched by name and signature.
        /// </summary>
        public abstract object Member { get; }

#pragma warning disable CA1819 // Properties should not return arrays (TODO)
        /// <summary>
        /// Gets the fallback list of possible names of the member to be imported.
        /// </summary>
        public abstract string[] MemberNames { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Determines whether the <see cref="AspectField"/> should be bound to the member
        /// as resolved before or after introduction of new members into the target class by the current advise.
        /// </summary>
        public ImportMemberOrder Order { get; private set; }

        /// <inheritdoc />
        public override object MasterAspectMember
        {
            get { return this.AspectField; }
        }
        
    }

    
}
