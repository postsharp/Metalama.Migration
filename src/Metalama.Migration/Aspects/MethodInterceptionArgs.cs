using System.Diagnostics;
using System.Reflection;

#pragma warning disable CA2227 // Collection properties should be read only

namespace PostSharp.Aspects
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class MethodInterceptionArgs : AdviceArgs
    {
        public abstract IMethodBinding Binding { get; }

        public abstract object ReturnValue { get; set; }

        public MethodBase Method { get; set; }

        public Arguments Arguments { get; protected set; }

        public abstract void Proceed();

        public abstract object Invoke( Arguments arguments );

        public abstract bool IsAsync { get; }

        public abstract IAsyncMethodBinding AsyncBinding { get; }

        public abstract MethodInterceptionProceedAwaitable ProceedAsync();

        public abstract MethodBindingInvokeAwaitable InvokeAsync( Arguments arguments );
    }
}