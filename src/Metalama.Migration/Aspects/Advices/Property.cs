// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Exposes the semantics of a parameterless property for use
    /// with the <see cref="ImportMemberAttribute"/> aspect extension.
    /// </summary>
    /// <typeparam name="TValue">Property value type.</typeparam>
    /// <remarks>
    /// </remarks>
    /// <seealso cref="Property{TValue,TIndex}"/>
    /// <seealso cref="PropertyGetter{TValue}"/>
    /// <seealso cref="PropertySetter{TValue}"/>
    /// <seealso cref="ImportMemberAttribute"/>
    /// <include file="../Documentation.xml" path="/documentation/section[@name='seeAlsoIntroduceImportMembers']/*"/>
#if SERIALIZABLE
    [Serializable]
#endif
    public sealed class Property<TValue> : IProperty
    {
        /// <exclude />
        public Property( PropertyGetter<TValue> getter, PropertySetter<TValue> setter )
        {
            this.Get = getter;
            this.Set = setter;
        }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>get</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertyGetter<TValue> Get { get; private set; }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>set</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertySetter<TValue> Set { get; private set; }

        object IProperty.GetValue()
        {
            if ( this.Get == null )
                throw new InvalidOperationException("The property has no getter.");

            return this.Get();
        }

        void IProperty.SetValue( object value )
        {
            if ( this.Set == null )
                throw new InvalidOperationException("The property has no setter.");

            this.Set( (TValue) value );
        }
    }

    /// <summary>
    /// Mimics the semantics of a property accepting a single index parameter, for use
    /// with the <see cref="ImportMemberAttribute"/> aspect extension.
    /// </summary>
    /// <typeparam name="TIndex">Property index type.</typeparam>
    /// <typeparam name="TValue">Property value type.</typeparam>
    /// <seealso cref="Property{TValue}"/>
    /// <seealso cref="PropertyGetter{TValue,TIndex}"/>
    /// <seealso cref="PropertySetter{TValue,TIndex}"/>
#if SERIALIZABLE
    [Serializable]
#endif
    public sealed class Property<TValue, TIndex>
    {
        /// <exclude />
        public Property( PropertyGetter<TValue, TIndex> getter, PropertySetter<TValue, TIndex> setter )
        {
            this.Get = getter;
            this.Set = setter;
        }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>get</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertyGetter<TValue, TIndex> Get { get; private set; }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>set</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertySetter<TValue, TIndex> Set { get; private set; }
    }

    /// <summary>
    ///   Defines the signature of methods implementing the <see cref = "Property{TValue,TIndex}.Get" />
    ///   semantic of a property with a single index parameter.
    /// </summary>
    /// <typeparam name = "TValue">Property value type.</typeparam>
    /// <typeparam name = "TIndex">Property index type.</typeparam>
    /// <param name = "index">Index.</param>
    /// <returns>The property value.</returns>
    /// <seealso cref = "Property{TValue,TIndex}" />
    public delegate TValue PropertyGetter<TValue, TIndex>( TIndex index );

    /// <summary>
    ///   Defines the signature of methods implementing the <see cref = "Property{TValue,TIndex}.Set" />
    ///   semantic of a property with a single index parameter.
    /// </summary>
    /// <typeparam name = "TValue">Property value type.</typeparam>
    /// <typeparam name = "TIndex">Property index type.</typeparam>
    /// <param name = "index">Index.</param>
    /// <param name = "value">The property value.</param>
    /// <seealso cref = "Property{TValue,TIndex}" />
    public delegate void PropertySetter<TValue, TIndex>( TIndex index, TValue value );
}