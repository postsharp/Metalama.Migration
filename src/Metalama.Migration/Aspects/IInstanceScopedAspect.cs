using PostSharp.Aspects.Advices;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of aspects that have the same lifetime as <i>instance</i> of types
    ///   to which their are applied (or instance of the declaring type of members to which they are applied).
    /// </summary>
    /// <remarks>
    ///   <para>When an aspect is instance-scoped, a new instance of this aspect is created whenever an instance of the
    ///     type to which it has been applied is created (concretely, before the call to the base constructor and the own constructor of this type).</para>
    ///   <para>New aspect instances are obtained using the <b>prototype</b> design pattern. As any other aspect, an instance-scope aspect
    ///     has a static instance initialized at build time, then serialized, deserialized at runtime, and initialized by <b>RuntimeInitialize</b>.
    ///     This static instance then serves as a <i>prototype</i>.  When a new instance of the target type is created, the prototype is cloned
    ///     by the method <see cref = "CreateInstance" /> (typically implemented by a call to <see cref = "object.MemberwiseClone" />). Then some system
    ///     initializations (for instance member import) are performed on the aspect instance, and finally the <see cref = "RuntimeInitializeInstance" />
    ///     method is invoked.
    ///   </para>
    ///   <para>When an aspect implementing the <see cref = "IInstanceScopedAspect" /> interface is applied on a static method, field, property, or event,
    ///     the aspect will be statically scoped and the interface will be ignored.</para>
    /// </remarks>
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectLifetime']/*" />
    public interface IInstanceScopedAspect : IAspect
    {
        // TODO: The correct semantics seem to be:
        //  object CreateInstance();   --> called before inline field assign,ent
        // void RuntimeInitializeInstance(object target --> called after base constructor (when 'this' is available).

        /// <summary>
        ///   Creates a new instance of the aspect based on the current instance, serving as a prototype.
        /// </summary>
        /// <param name = "adviceArgs">Aspect arguments.</param>
        /// <returns>A new instance of the aspect, typically a clone of the current prototype instance.</returns>
        /// <remarks>
        ///   This method is typically implemented by invoking <see cref = "object.MemberwiseClone" />.
        /// </remarks>
        object CreateInstance( AdviceArgs adviceArgs );

        /// <summary>
        ///   Initializes the aspect instance. This method is invoked when all system elements of the aspect (like member imports)
        ///   have completed.
        /// </summary>
        /// <seealso cref="InitializeAspectInstanceAdvice"/>
        void RuntimeInitializeInstance();
    }
}