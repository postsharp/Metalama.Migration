using PostSharp.Aspects.Configuration;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Defines the semantics of an aspect that, when applied on a type, introduce one or many new interfaces
    ///   into that type, and let these interfaces be implemented by an object created
    ///   at runtime.
    /// </summary>
    /// <remarks>
    ///   See <see cref = "CompositionAspect" /> for details.
    /// </remarks>
    /// <seealso cref = "CompositionAspect" />
    public interface ICompositionAspect : ITypeLevelAspect
    {
        /// <summary>
        ///   Method invoked at runtime, during the initialization of instances of the target type,
        ///   to create the composed object.
        /// </summary>
        /// <returns>The composed object. This interface should implement the interfaces specified
        ///   by the <see cref = "CompositionAspectConfigurationAttribute.PublicInterfaces" /> and 
        ///   <see cref = "CompositionAspectConfigurationAttribute.ProtectedInterfaces" /> collections.</returns>
        /// <remarks>
        ///   This method is invoked during at runtime after the base constructor has executed, and before
        ///   the constructor of the current type is executed.
        /// </remarks>
        object CreateImplementationObject( AdviceArgs args );
    }
}