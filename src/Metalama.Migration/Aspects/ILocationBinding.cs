using System;
using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    [InternalImplement]
    public interface ILocationBinding
    {
        object GetValue( ref object instance, Arguments index );

        void SetValue( ref object instance, Arguments index, object value );

        LocationInfo LocationInfo { get; }

        Type LocationType { get; }

        DeclarationIdentifier DeclarationIdentifier { get; }

        void Execute<TPayload>( ILocationBindingAction<TPayload> action, ref TPayload payload );
    }

    public interface ILocationBinding<T> : ILocationBinding
    {
        new T GetValue( ref object instance, Arguments index );

        void SetValue( ref object instance, Arguments index, T value );
    }
}