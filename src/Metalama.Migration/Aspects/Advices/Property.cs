using System;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In PostSharp, this class allowed the run-time code of the aspect to access a property in the target code. In Metalama,
    /// no run-time helper is required because the template directly generates run-time code. Use <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="Metalama.Framework.Code.IProperty.Invokers"/>
    /// or <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="ExpressionFactory.ToExpression(Metalama.Framework.Code.IFieldOrProperty,Metalama.Framework.Code.IExpression?)"/>.<see cref="IExpression.Value"/>
    /// to generate run-time code for any event.
    /// </summary>
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

    /// <summary>
    /// In PostSharp, this class allowed the run-time code of the aspect to access a property in the target code. In Metalama,
    /// no run-time helper is required because the template directly generates run-time code. Use <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="Metalama.Framework.Code.IProperty.Invokers"/>
    /// or <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="ExpressionFactory.ToExpression(Metalama.Framework.Code.IFieldOrProperty,Metalama.Framework.Code.IExpression?)"/>.<see cref="IExpression.Value"/>
    /// to generate run-time code for any event.
    /// </summary>
    public sealed class Property<TValue, TIndex>
    {
        public Property( PropertyGetter<TValue, TIndex> getter, PropertySetter<TValue, TIndex> setter )
        {
            throw new NotImplementedException();
        }

        public PropertyGetter<TValue, TIndex> get;

        public PropertySetter<TValue, TIndex> set;
    }

    /// <summary>
    /// In PostSharp, this delegate allowed the run-time code of the aspect to access a property in the target code. In Metalama,
    /// no run-time helper is required because the template directly generates run-time code. Use <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="Metalama.Framework.Code.IProperty.Invokers"/>
    /// or <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="ExpressionFactory.ToExpression(Metalama.Framework.Code.IFieldOrProperty,Metalama.Framework.Code.IExpression?)"/>.<see cref="IExpression.Value"/>
    /// to generate run-time code for any event.
    /// </summary>
    public delegate TValue PropertyGetter<TValue, TIndex>( TIndex index );

    /// <summary>
    /// In PostSharp, this delegate allowed the run-time code of the aspect to access a property in the target code. In Metalama,
    /// no run-time helper is required because the template directly generates run-time code. Use <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="Metalama.Framework.Code.IProperty.Invokers"/>
    /// or <see cref="Metalama.Framework.Code.IProperty"/>.<see cref="ExpressionFactory.ToExpression(Metalama.Framework.Code.IFieldOrProperty,Metalama.Framework.Code.IExpression?)"/>.<see cref="IExpression.Value"/>
    /// to generate run-time code for any event.
    /// </summary>
    public delegate void PropertySetter<TValue, TIndex>( TIndex index, TValue value );
}