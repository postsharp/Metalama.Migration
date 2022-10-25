using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Represents an advice that imports a field or property (represented by a <see cref="LocationInfo"/>) of the target class
    /// into a field of the aspect class. This class is the imperative equivalent of the <see cref="ImportMemberAttribute"/> declarative advise.
    /// </summary>
    /// <seealso cref="IAdviceProvider"/>
    /// <seealso cref="ImportMemberAttribute"/>
    public sealed class ImportLocationAdviceInstance : ImportMemberAdviceInstance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportLocationAdviceInstance"/> class and specifies which field or property should be imported by giving its reflection representation.
        /// </summary>
        /// <param name="aspectField">A field of the aspect class to which <paramref name="location"/> should be bound at runtime.
        ///     This field can be of type <see cref="ILocationBinding"/>, <see cref="Property{TValue}"/>, or a type that is both (a) derived from <c>ICollection&lt;ILocationBinding&gt;</c> and (b) has a parameterless constructor.</param>
        /// <param name="location">The field or property to import.</param>
        public ImportLocationAdviceInstance( FieldInfo aspectField, LocationInfo location )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportLocationAdviceInstance"/> class and specifies the name of the property to be imported; the type of this
        /// property will be matched according to the type of the aspect field.
        /// </summary>
        /// <param name="aspectField">A field of the aspect class to which the field or property should be bound at build time.
        ///     This field must be of type <see cref="Property{TValue}"/>.</param>
        /// <param name="propertyName">The name of the property to import.</param>
        /// <param name="isRequired">Determines whether a build-time error should be emitted if the member cannot be found.
        /// If <c>false</c>, the binding field will be <c>null</c> in case the imported member is absent.
        /// </param>
        /// <param name="order">Determines whether the <paramref name="aspectField"/> should be bound to the member
        /// as resolved before or after introduction of new members into the target class by the current advise.</param>
        public ImportLocationAdviceInstance(
            FieldInfo aspectField,
            string propertyName,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportLocationAdviceInstance"/> class and specifies the name of the property to be imported; the type of this
        /// property will be matched according to the type of the aspect field.
        /// </summary>
        /// <param name="aspectField">A field of the aspect class to which the field or property should be bound at build time.
        ///     This field must be of type <see cref="Property{TValue}"/>.</param>
        /// <param name="propertyNames">Fallback list of possible names of the property to import.</param>
        /// <param name="isRequired">Determines whether a build-time error should be emitted if the member cannot be found.
        /// If <c>false</c>, the binding field will be <c>null</c> in case the imported member is absent.
        /// </param>
        /// <param name="order">Determines whether the <paramref name="aspectField"/> should be bound to the member
        /// as resolved before or after introduction of new members into the target class by the current advise.</param>
        public ImportLocationAdviceInstance(
            FieldInfo aspectField,
            string[] propertyNames,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the field or property of the target class that needs to be imported into the aspect.
        /// </summary>
        public LocationInfo Location { get; }

        /// <inheritdoc />
        public override object Member { get; }

        /// <inheritdoc />
        public override string[] MemberNames { get; }
    }
}