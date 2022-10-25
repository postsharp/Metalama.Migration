using System;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Custom attribute that, when added to a static method, causes the method to be executed immediately
    /// after the assembly is loaded by the CLR. The target method must be public, parameterless, void, and non-generic.
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    [RequirePostSharp( null, "ModuleInitializer" )]
    public sealed class ModuleInitializerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="ModuleInitializerAttribute"/>.
        /// </summary>
        /// <param name="order">Order in which the <see cref="ModuleInitializerAttribute"/> will be executed if the
        /// current project contains several initializers. Initializers with smaller values of the <paramref name="order"/>
        /// parameter get invoked first.</param>
        public ModuleInitializerAttribute( int order )
        {
            Order = order;
        }

        /// <summary>
        /// Gets the order in which the <see cref="ModuleInitializerAttribute"/> will be executed if the
        /// current project contains several initializers. Initializers with smaller values of the <see cref="Order"/>
        /// property get invoked first.
        /// </summary>
        public int Order { get; }
    }
}