using System;
using System.Diagnostics;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Internals
{
    public abstract class LocationLevelAdviceArgs : AdviceArgs
    {
        protected LocationLevelAdviceArgs( object instance ) : base( instance ) { }

        protected LocationLevelAdviceArgs()
        {
            throw new NotImplementedException();
        }

        public abstract object Value
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }

        public LocationInfo Location
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }

        public string LocationName
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }

        public string LocationFullName
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            set;
        }
    }
}