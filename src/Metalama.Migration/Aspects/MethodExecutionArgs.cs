using System;
using System.Diagnostics;
using System.Reflection;

#pragma warning disable CA2227 // Collection properties should be read only

namespace PostSharp.Aspects
{
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public class MethodExecutionArgs : AdviceArgs
    {
        public MethodExecutionArgs( object instance, Arguments arguments ) : base( instance )
        {
            Arguments = arguments;
        }

        public MethodBase Method { get; }

        public Arguments Arguments { get; }

        public object ReturnValue { get; set; }

        public object YieldValue { get; set; }

        public Exception Exception { get; set; }

        public FlowBehavior FlowBehavior { get; set; }

        public object MethodExecutionTag { get; set; }
    }
}