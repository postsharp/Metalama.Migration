using System;

namespace PostSharp.Aspects.Advices
{
    [Serializable]
    public sealed class Property<TValue> : IProperty
    {
        public Property( PropertyGetter<TValue> getter, PropertySetter<TValue> setter )
        {
            throw new NotImplementedException();
        }

        public PropertyGetter<TValue> get;

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

    [Serializable]
    public sealed class Property<TValue, TIndex>
    {
        public Property( PropertyGetter<TValue, TIndex> getter, PropertySetter<TValue, TIndex> setter )
        {
            throw new NotImplementedException();
        }

        public PropertyGetter<TValue, TIndex> get;

        public PropertySetter<TValue, TIndex> set;
    }

    public delegate TValue PropertyGetter<TValue, TIndex>( TIndex index );

    public delegate void PropertySetter<TValue, TIndex>( TIndex index, TValue value );
}