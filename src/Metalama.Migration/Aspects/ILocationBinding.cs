using System;
using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Interface through which a field- or property-level aspect or advice can
    ///   invoke the next node in the chain of invocation.
    /// </summary>
    /// <seealso cref="PostSharp.Aspects.Advices.ImportMemberAttribute"/>
    /// <seealso cref="ILocationBinding{T}"/>
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectBindings']/*" />
    [InternalImplement]
    public interface ILocationBinding
    {
        /// <summary>
        ///   Invokes the <c>Get</c> semantic on the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance from which the field or property should be retrieved (<c>null</c> if the field or property is static).</param>
        /// <param name = "index">Index arguments, if the location is an indexer property.</param>
        /// <returns>The value stored at the location.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        object GetValue( ref object instance, Arguments index );

        /// <summary>
        ///   Invokes the <c>Set</c> semantic on the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance from which the field or property should be retrieved (<c>null</c> if the field or property is static).</param>
        /// <param name = "index">Index arguments, if the location is an indexer property.</param>
        /// <param name = "value">New value to be stored at the location.</param>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        void SetValue( ref object instance, Arguments index, object value );

        /// <summary>
        /// Gets metadata information about the field or property represented by the current binding.
        /// </summary>
        LocationInfo LocationInfo { get; }

        /// <summary>
        /// Gets the type of the field or property.
        /// </summary>
        Type LocationType { get; }

        /// <summary>
        /// Gets the <see cref="DeclarationIdentifier"/> of the declaration that the binding represents.
        /// </summary>
        /// <remarks>
        /// <para>For usage information, see the remarks of the <see cref="DeclarationIdentifier"/> type documentation.</para>
        /// </remarks>
        DeclarationIdentifier DeclarationIdentifier { get; }

        /// <summary>
        /// Provides a mechanism to execute a strongly-typed action that depends on the type of the current location.
        /// </summary>
        /// <typeparam name="TPayload">Type of the payload passed to the <paramref name="payload"/> parameter.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="payload">Payload.</param>
        void Execute<TPayload>( ILocationBindingAction<TPayload> action, ref TPayload payload );
    }

    /// <summary>
    /// A strongly-typed variant for <see cref="ILocationBinding"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILocationBinding<T> : ILocationBinding
    {
        /// <summary>
        ///   Invokes the <c>Get</c> semantic on the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance from which the field or property should be retrieved (<c>null</c> if the field or property is static).</param>
        /// <param name = "index">Index arguments, if the location is an indexer property.</param>
        /// <returns>The value stored at the location.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        new T GetValue( ref object instance, Arguments index );

        /// <summary>
        ///   Invokes the <c>Set</c> semantic on the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance from which the field or property should be retrieved (<c>null</c> if the field or property is static).</param>
        /// <param name = "index">Index arguments, if the location is an indexer property.</param>
        /// <param name = "value">New value to be stored at the location.</param>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        void SetValue( ref object instance, Arguments index, T value );
    }
}