using System;
using System.Reflection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.Advised;

#pragma warning disable CA2227 // Collection properties should be read only

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, this object exposed the run-time execution context to the advice. However, in Metalama, advice do not execute at run time.
    /// Instead, advice are templates that generate run-time code. This run-time code does not need helper objects to represent the execution context.
    /// </summary>
    public class MethodExecutionArgs : AdviceArgs
    {
        public MethodExecutionArgs( object instance, Arguments arguments ) : base( instance )
        {
            Arguments = arguments;
        }

        /// <summary>
        /// In Metalama, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>. If you need a run-time object,
        /// call <see cref="IMethod"/>.<see cref="IMethod.ToMethodInfo"/>.
        /// </summary>
        public MethodBase Method { get; }

        /// <summary>
        /// In Metalama, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Parameters"/>.<see cref="IAdvisedParameterList.Values"/>.
        /// </summary>
        public Arguments Arguments { get; }

        /// <summary>
        /// In Metalama, when you call <see cref="meta"/>.<see cref="meta.Proceed"/>, store the return value in a local variable.
        /// </summary>
        public object ReturnValue { get; set; }

        /// <summary>
        /// There is no equivalent in Metalama and no workaround. 
        /// </summary>
        [Obsolete( "", true )]
        public object YieldValue { get; set; }

        /// <summary>
        /// In Metalama, when you have your own <c>try</c>/<c>catch</c>, this is the exception variable of the <c>catch</c> block.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// There is no equivalent in Metalama because you can code any control flow in the template.
        /// </summary>
        public FlowBehavior FlowBehavior { get; set; }

        /// <summary>
        /// In Metalama, use a local variable in the template.
        /// </summary>
        public object MethodExecutionTag { get; set; }
    }
}