using System.Diagnostics;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    public interface ILocationInterceptionArgs
    {
        ILocationBinding Binding { get; }

        Arguments Index { get; }

        void ProceedGetValue();

        void ProceedSetValue();

        object GetCurrentValue();

        void SetNewValue( object value );

        void Execute<TPayload>( ILocationInterceptionArgsAction<TPayload> action, ref TPayload payload );

        object Value { get; set; }

        LocationInfo Location { get; set; }

        string LocationName { get; set; }

        string LocationFullName { get; set; }

        [DebuggerNonUserCode]
        object Instance { get; }
    }

    public interface ILocationInterceptionArgs<T> : ILocationInterceptionArgs
    {
        new ILocationBinding<T> Binding { get; }

        new T Value { get; set; }

        new T GetCurrentValue();

        void SetNewValue( T value );
    }
}