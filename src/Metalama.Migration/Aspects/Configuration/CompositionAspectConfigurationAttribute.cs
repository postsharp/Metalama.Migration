using System;
using System.Runtime.Serialization.Formatters.Binary;
using PostSharp.Aspects.Advices;

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
        /// <summary>
        ///   Gets or sets the array of type names of interfaces that should be introduced publicly into
        ///   the target type of the aspect.
        /// </summary>
        public string[] PublicInterfaces { get; set; }

        /// <summary>
        ///   Gets or sets the array of type names of interfaces to be introduced indirectly into the target type of the aspect.
        /// </summary>
        public string[] ProtectedInterfaces { get; set; }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when one of the interfaces specified by <see cref = "PublicInterfaces" /> or <see cref = "ProtectedInterfaces" />
        ///   is already implemented by the type to which the aspect is applied.
        /// </summary>
        /// <seealso cref = "AncestorOverrideAction" />
        public InterfaceOverrideAction OverrideAction { get; set; }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when an <i>ancestor</i> of one of the interfaces specified by <see cref = "PublicInterfaces" />
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "OverrideAction" />
        public InterfaceOverrideAction AncestorOverrideAction { get; set; }

        /// <summary>
        ///   Determines whether the field containing the interface implementation (and storing the object returned by
        ///   <see cref = "ICompositionAspect.CreateImplementationObject" />) should be excluded from serialization by <see cref = "BinaryFormatter" />.
        ///   The same effect is typically obtained by applying the <see cref = "NonSerializedAttribute" /> custom attribute to the field.
        /// </summary>
        public bool NonSerializedImplementation { get; set; }

        /// <summary>
        ///   This property has no effect.
        /// </summary>
        [Obsolete( "This property has no effect and will be removed in a future version." )]
        public bool GenerateImplementationAccessor { get; set; }

        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}