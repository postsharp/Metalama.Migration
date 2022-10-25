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
    [Serializable]
    public sealed class Property<TValue> : IProperty
    {
        /// <exclude />
        public Property( PropertyGetter<TValue> getter, PropertySetter<TValue> setter )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>get</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertyGetter<TValue> get;

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>set</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertySetter<TValue> set;

        object IProperty.GetValue()
        {
            throw new NotImplementedException();
        }

        void IProperty.SetValue( object value )
        {
            throw new NotImplementedException();
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
    [Serializable]
    public sealed class Property<TValue, TIndex>
    {
        /// <exclude />
        public Property( PropertyGetter<TValue, TIndex> getter, PropertySetter<TValue, TIndex> setter )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>get</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertyGetter<TValue, TIndex> get;

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>set</b> accessor
        ///   of the imported property.
        /// </summary>
        public PropertySetter<TValue, TIndex> set;
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