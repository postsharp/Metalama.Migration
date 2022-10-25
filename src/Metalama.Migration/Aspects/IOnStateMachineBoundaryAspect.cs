using System.Collections;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Extends the <see cref="IOnMethodBoundaryAspect"/> interface with two advises
    /// to be applied on state machines.
    /// </summary>
    public interface IOnStateMachineBoundaryAspect : IOnMethodBoundaryAspect
    {
        /// <summary>
        /// Method executed when a state machine resumes execution after a <c>yield return</c> or
        /// <c>await</c> statement.
        /// </summary>
        /// <remarks>
        /// <para>For iterator methods, this advice is executed before the <see cref="IEnumerator.MoveNext"/> method.
        /// However, the very first call of <see cref="IEnumerator.MoveNext"/> maps to <see cref="IOnMethodBoundaryAspect.OnEntry"/>.
        /// </para>
        /// <para>In async methods, the advice is executed just after the state machine restarts execution after having waited 
        /// as a result of the <c>await</c> statement. </para>
        /// </remarks>
        /// <param name = "args">Event arguments specifying which method
        ///   is being executed and which are its arguments.</param>
        void OnResume( MethodExecutionArgs args );

        /// <summary>
        /// Method executed when a state machine yields, as the result of a <c>yield return</c> or
        /// <c>await</c> statement.
        /// </summary>
        /// <remarks>
        /// <para>In iterator methods, this advise is exactly executed at the <c>yield return</c> statement.</para>
        /// <para>
        /// In async methods, the advice is executed just after the state machine starts waiting as a result of the <c>await</c> statement.
        ///  In case the operand of the <c>await</c> statement is an operation that completed synchronously, the state machine
        /// does not yield, and the <see cref="OnYield"/> advise won't be invoked.
        ///  </para>
        /// </remarks>
        /// <param name = "args">Event arguments specifying which method
        ///   is being executed and which are its arguments. In iterator methods, the <see cref="MethodExecutionArgs.YieldValue"/>
        /// property gives access to the operand of the <c>yield return</c> statement.</param>
        void OnYield( MethodExecutionArgs args );
    }
}