// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

#pragma warning disable CA2211 // Non-constant fields should not be visible (These are used by the debugger)

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public static class DebuggerInterop
    {
        public static long NextStateMachineId = 1;

#pragma warning disable CA1805 // Do not initialize unnecessarily
        public static bool IsInInspectionQuery = false;
#pragma warning restore CA1805 // Do not initialize unnecessarily
    }
}