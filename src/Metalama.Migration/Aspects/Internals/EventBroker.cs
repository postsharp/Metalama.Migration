// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Threading;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{

    /// <exclude />
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    [Internal]
    [Obsolete("The SafeEventBroker class is now used by the compiler.")]
    public abstract class EventBroker
    {
        private volatile Delegate handlers;

        /// <exclude />
        [DebuggerHidden]
        protected EventBroker( object instance )
        {
            this.Instance = instance;
        }

        /// <exclude />

        protected object Instance
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            private set;
        }

        /// <exclude />
        protected abstract void SubscribeImpl();

        /// <exclude />
        protected abstract void UnsubscribeImpl();

        /// <exclude />
        protected abstract object OnHandlerInvoked( Delegate handler, Arguments arguments );

        /// <exclude />
        public void AddHandler( Delegate handler )
        {
            Delegate combinedHandlers;
            Delegate oldHandlers;

            do
            {
                oldHandlers = this.handlers;
                
                combinedHandlers = Delegate.Combine(oldHandlers, handler);

            }
           while ( Interlocked.CompareExchange( ref this.handlers, combinedHandlers, oldHandlers) == combinedHandlers);

            // At this point, the list of handlers is not empty but the broker did not subscribe to the event yet.

            if (oldHandlers == null)
            {
                // Note that here the list may be empty, with fairly little probability,
                // so we may subscribe an empty event broker.

                this.SubscribeImpl();
            }
        }

        /// <exclude />
        public void RemoveHandler( Delegate handler )
        {
            Delegate combinedHandlers;
            Delegate oldHandlers;


            do
            {
                oldHandlers = this.handlers;
                if (oldHandlers == null)
                {
                    return;
                }
               
                combinedHandlers = Delegate.Remove(oldHandlers, handler);
            }
            while (Interlocked.CompareExchange(ref this.handlers, combinedHandlers, oldHandlers) == combinedHandlers);

            // At this point, the list of handlers is empty but the broker is still subscribed to the event yet.

            if (combinedHandlers == null )
            {
                // In case there is a race with AddHandler, make sure AddHandler wins.
                if ( this.handlers == null )
                { 
                    this.UnsubscribeImpl();
                }
            }
        }

        /// <exclude />
        protected object OnEventFired( Arguments arguments )
        {
           
            object returnValue = null;
            Delegate localHandlers = this.handlers;
            Delegate[] invocationList = localHandlers?.GetInvocationList();

            if ( invocationList == null || invocationList.Length == 0 )
            {
                // It is possible that some thread views a non-null event but the handler is an empty broker.
                // We will return 'null' for runtime backward compatibility. The correct behavior needs the new SafeEventBroker implementation.

                return null;

            }
            else
            { 
                foreach ( Delegate handler in invocationList)
                {
                    returnValue = this.OnHandlerInvoked( handler, arguments );
                }
            }

            return returnValue;
        }
        
    }

    /// <exclude />
    public abstract class SafeEventBroker
    {
        private volatile EventInterceptor[] interceptors;

        /// <exclude />
        protected SafeEventBroker(object instance)
        {
            this.Instance = instance;
        }



        /// <exclude />

        protected object Instance
        {
            get;
            private set;
        }

        /// <exclude />
        protected abstract EventInterceptor CreateInterceptor( Delegate handler );

        /// <exclude />
        public void AddHandler( Delegate handler )
        {
            // We're locking on this to avoid the allocation of another object.

            lock ( this )
            {

                // Look for a free slot in the list.
                int slot;
                if ( this.interceptors == null )
                {
                    this.interceptors = new EventInterceptor[4];
                    slot = 0;
                }
                else
                {                     
                    slot = -1;
                    for ( int i = 0; i < this.interceptors.Length; i++ )
                    {
                        if ( this.interceptors[i] == null )
                        {
                            slot = i;
                            break;
                        }
                    }

                    if ( slot < 0 )
                    {
                        // No free slot.
                        slot = this.interceptors.Length;
#pragma warning disable 420
                        Array.Resize(ref this.interceptors, this.interceptors.Length * 2 );
#pragma warning restore 420

                    }
                }

                EventInterceptor interceptor = this.CreateInterceptor( handler );
                this.interceptors[ slot ] = interceptor;
                interceptor.Subscribe();

            }
        }

        /// <exclude />
        public void RemoveHandler( Delegate handler )
        {
            lock ( this )
            {
                if ( this.interceptors == null )
                    return;

                for ( int i = 0; i < this.interceptors.Length; i++ )
                {
                    EventInterceptor interceptor = this.interceptors[i ];
                    if ( interceptor != null && interceptor.Handler == handler )
                    {
                        interceptor.Unsubscribe();
                        this.interceptors[i] = null;
                        return;
                    }

                }
            }
        }



    }

    /// <exclude />
    public abstract class EventInterceptor
    {
        /// <exclude />
        public Delegate Handler { get; private set; }

        /// <exclude />
        protected object Instance { get; private set; }

        /// <exclude />
        protected EventInterceptor(object instance, Delegate handler)
        {
            this.Handler = handler;
            this.Instance = instance;
        }


        /// <exclude />
        public abstract void Subscribe();

        /// <exclude />
        public abstract void Unsubscribe();
        

    }
}