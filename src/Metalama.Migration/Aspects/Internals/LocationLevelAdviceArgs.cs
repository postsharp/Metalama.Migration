using System;
using System.Diagnostics;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    public abstract class LocationLevelAdviceArgs : AdviceArgs
    {
        /// <exclude />
        protected LocationLevelAdviceArgs( object instance ) : base( instance ) { }

        protected LocationLevelAdviceArgs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets or sets the location value.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     Inside an <see cref = "ILocationInterceptionAspect.OnGetValue" /> advice, this property is available after
        ///     the next advice in chain has been invoked using <see cref = "LocationInterceptionArgs.ProceedGetValue" />. However, 
        ///     inside an <see cref = "ILocationInterceptionAspect.OnSetValue" /> advice, the value is available immediately,
        ///     and is used as input by <see cref = "LocationInterceptionArgs.ProceedSetValue" />. 
        ///   </para>
        ///   <para>
        ///     See <see cref = "LocationInterceptionArgs.GetCurrentValue" /> and <see cref = "LocationInterceptionArgs.SetNewValue" />
        ///     to get or set the value of the location without affecting the value of this property.
        ///   </para>
        /// </remarks>
        public abstract object Value
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }

        /// <summary>
        ///   Gets the location (field, property or parameter) related to the aspect or advice being executed.
        /// </summary>
        /// <remarks>
        ///   <note>
        ///     Using this property causes the aspect weaver to generate code that has non-trivial runtime overhead. Avoid using
        ///     this property whenever possible. One of the possible solution is to use compile-time initialization of
        ///     aspect instances and to make use of reflection only at build time.
        ///   </note>
        /// </remarks>
        public LocationInfo Location
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }

        /// <summary>
        ///   Gets the name of the location (field, property or parameter) related to the aspect or advice being executed.
        /// </summary>
        public string LocationName
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }

        /// <summary>
        ///   Gets the full name (including the full name of the declaring type) of the location (field, property or parameter) related to the aspect or advice being executed.
        /// </summary>
        public string LocationFullName
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }
    }
}