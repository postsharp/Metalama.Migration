using System;
using System.Diagnostics;
using System.Reflection;

namespace PostSharp.Aspects
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class EventInterceptionArgs : AdviceArgs
    {
        public abstract IEventBinding Binding { get; }

        public Delegate Handler { get; }

        public object ReturnValue { get; set; }

        public EventInfo Event { get; set; }

        public Arguments Arguments { get; }

        public abstract void ProceedAddHandler();

        public abstract void AddHandler( Delegate handler );

        public abstract void ProceedRemoveHandler();

        public abstract void RemoveHandler( Delegate handler );

        public abstract void ProceedInvokeHandler();

        public abstract object InvokeHandler( Delegate handler, Arguments arguments );
    }
}