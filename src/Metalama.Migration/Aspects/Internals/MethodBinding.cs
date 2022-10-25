// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;
#if ASYNCAWAIT
using System.Threading.Tasks;
#endif

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Internal]
    public abstract class MethodBinding : IMethodBinding
    {
        /// <exclude />
        object IMethodBinding.Invoke( ref object instance, Arguments arguments )
        {
            this.Invoke( ref instance, arguments, null );
            return null;
        }

        /// <exclude />
        public abstract void Invoke( ref object instance, Arguments arguments, object reserved );
    }

    /// <exclude />
    [Internal]
    public abstract class MethodBinding<TReturnValue> : IMethodBinding
    {
        /// <exclude />
        object IMethodBinding.Invoke( ref object instance, Arguments arguments )
        {
            return this.Invoke( ref instance, arguments, null );
        }

        /// <exclude />
        public abstract TReturnValue Invoke( ref object instance, Arguments arguments, object reserved );
    }

#if ASYNCAWAIT

    /// <exclude />
    [Internal]
    public abstract class AsyncMethodBinding<TReturnValue> : IAsyncMethodBinding, ITaskAdapter
    {
        /// <exclude />
        public object Invoke( ref object instance, Arguments arguments )
        {
            return this.InvokeAsync( ref instance, arguments, null );
        }

        /// <exclude />
        MethodBindingInvokeAwaitable IAsyncMethodBinding.InvokeAsync( ref object instance, Arguments arguments )
        {
            Task task = this.InvokeAsync( ref instance, arguments, null );
            return new MethodBindingInvokeAwaitable( task, this );
        }

        /// <exclude />
        public abstract Task<TReturnValue> InvokeAsync( ref object instance, Arguments arguments, object reserved );

        /// <exclude />
        object ITaskAdapter.GetResult( Task task )
        {
            return ((Task<TReturnValue>) task).Result;
        }
    }
#endif

}