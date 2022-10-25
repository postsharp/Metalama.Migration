using System.Diagnostics;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// An interface for <see cref="LocationInterceptionArgs"/>.
    /// </summary>
    /// <remarks>
    /// <para>This interface is not generally used directly, but it serves as a base for the strongly-typed <see cref="ILocationInterceptionArgs{T}"/>,
    /// which is used by <see cref="LocationInterceptionArgs.Execute{TPayload}"/>.</para>
    /// </remarks>
    public interface ILocationInterceptionArgs
    {
        /// <summary>
        ///   Gets an interface that allows to invoke the next node in the chain of invocation of the intercepted method.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='bindingProperty']/*" />
        /// </remarks>
        ILocationBinding Binding { get; }

        /// <summary>
        ///   Gets the current index arguments (in case of a property with parameters).
        /// </summary>
        Arguments Index { get; }

        /// <summary>
        ///   Invokes the <b>Get Location Value</b> semantic on the next node in the chain of invocation and stores the location value in the <see cref = "LocationLevelAdviceArgs.Value" /> property.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     Note that this method overwrites the content of the <see cref = "LocationLevelAdviceArgs.Value" /> property. Therefore, you should not call this invoke
        ///     from a <see cref = "ILocationInterceptionAspect.OnSetValue" /> advice unless you store the value before. If you need to retrieve
        ///     the current value of the location from a <see cref = "ILocationInterceptionAspect.OnSetValue" /> advice, it is recommended you
        ///     use the <see cref = "LocationInterceptionArgs.GetCurrentValue" /> method.
        ///   </para>
        ///   <br />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='locationInterceptionArgsStateWarning']/*" />
        /// </remarks>
        void ProceedGetValue();

        /// <summary>
        ///   Invokes the <b>Set Location Value</b> semantic on the next node in the chain of invocation and stores the value of the <see cref = "LocationLevelAdviceArgs.Value" /> property into
        ///   the location.
        /// </summary>
        /// <remarks>
        ///   <para>Note that this method requires the value to be stored in the <see cref = "LocationLevelAdviceArgs.Value" /> property. If you need to retrieve
        ///     the current value of the location from a <see cref = "ILocationInterceptionAspect.OnSetValue" /> advice, it is recommended you
        ///     use the <see cref = "LocationInterceptionArgs.GetCurrentValue" /> method.
        ///   </para>
        ///   <br />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='locationInterceptionArgsStateWarning']/*" />
        /// </remarks>
        void ProceedSetValue();

        /// <summary>
        ///   Retrieves the current value of the location without overwriting the <see cref = "LocationLevelAdviceArgs.Value" /> property.
        /// </summary>
        /// <returns>The current value of the location, as returned by the next node in the chain of invocation (see <see cref = "LocationInterceptionArgs.Binding" />).</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='locationInterceptionArgsStateWarning']/*" />
        /// </remarks>
        object GetCurrentValue();

        /// <summary>
        ///   Sets the value of the location without overwriting the <see cref = "LocationLevelAdviceArgs.Value" /> property.
        /// </summary>
        /// <param name = "value">The value to be passed to the next node in the chain of invocation (see <see cref = "LocationInterceptionArgs.Binding" />).</param>
        /// <remarks>
        ///   <br />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='locationInterceptionArgsStateWarning']/*" />
        /// </remarks>
        void SetNewValue( object value );

        /// <summary>
        /// Executes a delegate for the current <see cref="LocationInterceptionArgs"/>. This method allows to
        /// execute strongly-typed operations and avoid boxing required by the weakly typed <see cref="ILocationInterceptionArgs"/> interface.
        /// </summary>
        /// <typeparam name="TPayload">Type of the payload.</typeparam>
        /// <param name="action">Class (typically a singleton) that contains the generic method <see cref="ILocationInterceptionArgsAction{TPayload}.Execute{TValue}"/>
        /// that will be executed with the right method generic argument.</param>
        /// <param name="payload">An argument being passed to the <see cref="ILocationInterceptionArgsAction{TPayload}.Execute{TValue}"/> method of the <paramref name="action"/>
        /// parameter.</param>
        /// <remarks>
        /// <note>
        ///     <para>This method is ignored by the advice optimizer. As a result, the optimizer will not know that the <paramref name="action"/> implementation uses
        /// any feature of the <see cref="LocationInterceptionArgs"/> object, and the code supporting these features won't be generated. If these features are required
        /// by <paramref name="action"/>, they must be referenced inside the <see cref="LocationInterceptionAspect.OnGetValue"/> or <see cref="LocationInterceptionAspect.OnSetValue"/>
        /// method.
        /// </para>
        /// </note>
        /// </remarks>
        void Execute<TPayload>( ILocationInterceptionArgsAction<TPayload> action, ref TPayload payload );

        /// <summary>
        /// See <see cref="LocationLevelAdviceArgs.Value" />
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// See <see cref="LocationLevelAdviceArgs.Location" />
        /// </summary>
        LocationInfo Location { get; set; }

        /// <summary>
        /// See <see cref="LocationLevelAdviceArgs.LocationName" />
        /// </summary>
        string LocationName { get; set; }

        /// <summary>
        /// See <see cref="LocationLevelAdviceArgs.LocationFullName" />
        /// </summary>
        string LocationFullName { get; set; }

        /// <summary>
        ///   Gets or sets the object instance on which the method is being executed.
        /// </summary>
        /// <remarks>
        ///   This set may be set by user code only when the instance is a value type.
        ///   As usually, user code is responsible for setting an object of the
        ///   right type.
        /// </remarks>
        [DebuggerNonUserCode]
        object Instance { get; }
    }

    /// <summary>
    /// A strongly-typed specialization of the <see cref="ILocationInterceptionArgs"/> interface.
    /// </summary>
    /// <typeparam name="T">Type of the location value.</typeparam>
    /// <remarks>Use the <see cref="ILocationInterceptionArgs.Execute{TPayload}"/> method to consume this interface.</remarks>
    public interface ILocationInterceptionArgs<T> : ILocationInterceptionArgs
    {
        /// <summary>
        ///   Gets an interface that allows to invoke the next node in the chain of invocation of the intercepted method.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='bindingProperty']/*" />
        /// </remarks>
        new ILocationBinding<T> Binding { get; }

        /// <summary>
        ///   Gets or sets the location value.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     Inside an <see cref = "ILocationInterceptionAspect.OnGetValue" /> advice, this property is available after
        ///     the next advice in chain has been invoked using <see cref = "ILocationInterceptionArgs.ProceedGetValue" />. However, 
        ///     inside an <see cref = "ILocationInterceptionAspect.OnSetValue" /> advice, the value is available immediately,
        ///     and is used as input by <see cref = "ILocationInterceptionArgs.ProceedSetValue" />. 
        ///   </para>
        ///   <para>
        ///     See <see cref = "GetCurrentValue" /> and <see cref = "SetNewValue" />
        ///     to get or set the value of the location without affecting the value of this property.
        ///   </para>
        /// </remarks>
        new T Value { get; set; }

        /// <summary>
        ///   Retrieves the current value of the location without overwriting the <see cref = "LocationLevelAdviceArgs.Value" /> property.
        /// </summary>
        /// <returns>The current value of the location, as returned by the next node in the chain of invocation (see <see cref = "LocationInterceptionArgs.Binding" />).</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='locationInterceptionArgsStateWarning']/*" />
        /// </remarks>
        new T GetCurrentValue();

        /// <summary>
        ///   Sets the value of the location without overwriting the <see cref = "LocationLevelAdviceArgs.Value" /> property.
        /// </summary>
        /// <param name = "value">The value to be passed to the next node in the chain of invocation (see <see cref = "LocationInterceptionArgs.Binding" />).</param>
        /// <remarks>
        ///   <br />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='locationInterceptionArgsStateWarning']/*" />
        /// </remarks>
        void SetNewValue( T value );
    }
}