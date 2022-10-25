// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Reflection;
using System.Threading;
using PostSharp.Aspects;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

#pragma warning disable CA2211 // Non-constant fields should not be visible (These are used by the debugger)


namespace PostSharp.Extensibility
{
    /// <exclude/>
    public static class DebuggerInterop
    {
                              /// <exclude/>
        public static long NextStateMachineId = 1;

        /// <exclude/>
#pragma warning disable CA1805 // Do not initialize unnecessarily
        public static bool IsInInspectionQuery = false;
#pragma warning restore CA1805 // Do not initialize unnecessarily

        internal static void Dummy()
        {
#pragma warning disable 1717
            NextStateMachineId = NextStateMachineId;
            IsInInspectionQuery = IsInInspectionQuery;
#pragma warning restore 1717
            
        }
    }
}

