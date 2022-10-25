using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Completely specifies an aspect instance (but not its target). An <see cref = "AspectSpecification" /> either the aspect instance itself 
    ///   (<see cref = "Aspect" /> property), either information allowing to construct the aspect (<see cref = "AspectConstruction" />) and configure the weaver (<see cref = "AspectConfiguration" />).
    /// </summary>
    /// <remarks>
    ///   User code cannot create an instance of the <see cref = "AspectSpecification" /> class. Always create an instance of
    ///   <see cref = "AspectInstance" /> instead.
    /// </remarks>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class AspectSpecification
    {
        /// <summary>
        ///   Gets the aspect configuration.
        /// </summary>
        /// <value>
        ///   The aspect configuration, or <c>null</c> if none was provided.
        /// </value>
        public AspectConfiguration AspectConfiguration { get; }

        /// <summary>
        ///   Gets the aspect construction.
        /// </summary>
        /// <value>
        ///   The aspect construction, or <c>null</c> if the aspect instance was provided instead.
        /// </value>
        public ObjectConstruction AspectConstruction { get; }

        /// <summary>
        ///   Gets the aspect instance.
        /// </summary>
        /// <value>
        ///   The aspect instance, or <c>null</c> if the <see cref = "AspectConfiguration" /> was provided instead.
        /// </value>
        public IAspect Aspect { get; }

        /// <summary>
        ///   Gets the assembly-qualified type name of the aspect.
        /// </summary>
        public string AspectAssemblyQualifiedTypeName { get; }

        /// <summary>
        ///   Gets the type name of the aspect.
        /// </summary>
        public string AspectTypeName { get; }
    }
}