#pragma warning disable CA2211 // Non-constant fields should not be visible (These are used by the debugger)

namespace PostSharp.Extensibility
{
    public static class DebuggerInterop
    {
        public static long NextStateMachineId = 1;

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