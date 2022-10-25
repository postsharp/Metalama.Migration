// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Advices;
#if BINARY_FORMATTER
using System.Runtime.Serialization.Formatters.Binary;
#endif

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Custom attribute that, when applied on a class implementing <see cref = "ICompositionAspect" />,
    ///   defines the declarative configuration of that aspect.
    /// </summary>
    /// <seealso cref = "AspectConfigurationAttribute" />
    /// <seealso cref = "CompositionAspect" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class CompositionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        private string[] publicInterfaces;
        private string[] protectedInterfaces;
        private InterfaceOverrideAction? overrideAction, ancestorOverrideAction;
        private bool? nonSerializedImplementation;
        private bool? generateImplementationAccessor;


        /// <summary>
        ///   Gets or sets the array of type names of interfaces that should be introduced publicly into
        ///   the target type of the aspect.
        /// </summary>
        public string[] PublicInterfaces
        {
            get { return this.publicInterfaces; }
            set { this.publicInterfaces = value; }
        }

        /// <summary>
        ///   Gets or sets the array of type names of interfaces to be introduced indirectly into the target type of the aspect.
        /// </summary>
        public string[] ProtectedInterfaces
        {
            get { return this.protectedInterfaces; }
            set { this.protectedInterfaces = value; }
        }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when one of the interfaces specified by <see cref = "PublicInterfaces" /> or <see cref = "ProtectedInterfaces" />
        ///   is already implemented by the type to which the aspect is applied.
        /// </summary>
        /// <seealso cref = "AncestorOverrideAction" />
        public InterfaceOverrideAction OverrideAction
        {
            get { return this.overrideAction ?? InterfaceOverrideAction.Fail; }
            set { this.overrideAction = value; }
        }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when an <i>ancestor</i> of one of the interfaces specified by <see cref = "PublicInterfaces" />
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "OverrideAction" />
        public InterfaceOverrideAction AncestorOverrideAction
        {
            get { return this.ancestorOverrideAction ?? InterfaceOverrideAction.Fail; }
            set { this.ancestorOverrideAction = value; }
        }

        /// <summary>
        ///   Determines whether the field containing the interface implementation (and storing the object returned by
        ///   <see cref = "ICompositionAspect.CreateImplementationObject" />) should be excluded from serialization by <see cref = "BinaryFormatter" />.
        ///   The same effect is typically obtained by applying the <see cref = "NonSerializedAttribute" /> custom attribute to the field.
        /// </summary>
        public bool NonSerializedImplementation
        {
            get { return this.nonSerializedImplementation ?? false; }
            set { this.nonSerializedImplementation = value; }
        }
    
        /// <summary>
        ///   This property has no effect.
        /// </summary>
        [Obsolete("This property has no effect and will be removed in a future version.")]
        public bool GenerateImplementationAccessor
        {
            get { return this.generateImplementationAccessor ?? false; }
            set { this.generateImplementationAccessor = value; }
        }


        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new CompositionAspectConfiguration
                       {
                           PublicInterfaces = TypeIdentity.FromTypeNames( this.publicInterfaces ),
                           AncestorOverrideAction = this.ancestorOverrideAction,
                           NonSerializedImplementation = this.nonSerializedImplementation,
                           OverrideAction = this.overrideAction
                       };
        }
    }
}