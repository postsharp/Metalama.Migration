namespace PostSharp.Aspects
{
    /// <summary>
    /// Contains the signature of <see cref="OnInstanceLocationInitialized"/>, a location-level advice.
    /// </summary>
    public interface IOnInstanceLocationInitializedAspect : ILocationLevelAspect
    {
        /// <summary>
        /// Method invoked <i>after</i> an initial value is set for a field or property to which the current aspect is applied.
        /// The method is invoked only for instance fields and instance auto-implemented properties, and it is invoked after their inline initialization.
        /// For static fields and properties, and for accesses from the constructor, OnSetValue is invoked instead.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is invoked at the beginning of an instance constructor.
        /// If more than one field or property is affected by this advice, this method will be called for them in declaration
        /// order of the properties (so, if in your C# file you declare first "a", then "b", then the method will be called for "a" first).
        /// If more than one advice group applies to a property, they will be called in order of aspect priority as normal.
        /// </para>
        /// <para>
        /// This method is invoked for all instance fields and auto-implemented properties, even if they do not have an initializer. If they don't,
        /// the method is called with the default value in the <see cref="LocationLevelAdviceArgs.Value"/> property (<c>null</c>, zero, or <c>false</c>).
        /// </para>
        /// <para>
        /// For structs, this method is only invoked if an actual non-default constructor of the struct is invoked.
        /// </para>
        /// </remarks>
        /// <param name="args">Information about the location.</param>
        void OnInstanceLocationInitialized( LocationInitializationArgs args );
    }
}