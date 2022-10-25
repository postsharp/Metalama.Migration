// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if ASYNCAWAIT
using System.Threading.Tasks;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Internal]
    public abstract class AsyncMethodBinding : IAsyncMethodBinding, ITaskAdapter
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
        public abstract Task InvokeAsync( ref object instance, Arguments arguments, object reserved );

        /// <exclude />
        object ITaskAdapter.GetResult( Task task )
        {
            return null;
        }
    }
}
#endif
