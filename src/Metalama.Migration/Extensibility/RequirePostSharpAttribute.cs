using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Custom attribute that, when applied on another custom attribute (a class derived 
    ///   from <see cref = "Attribute" />), means that assemblies with elements
    ///   annotated with that custom attribute should be processed by <c>PostSharp</c>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly, AllowMultiple = true )]
    public sealed class RequirePostSharpAttribute : Attribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "RequirePostSharpAttribute" /> and specifies the required plug-in name and task name.
        /// </summary>
        /// <param name = "plugIn">Name of the required plug-in (file name without extension).</param>
        /// <param name = "task">Name of the required task (should be defined in <paramref name = "plugIn" />).</param>
        public RequirePostSharpAttribute( string plugIn, string task )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new <see cref = "RequirePostSharpAttribute" /> and specifies the required plug-in name.
        /// All implicit (auto-included) tasks of that plug-in will be added to the project.
        /// </summary>
        /// <param name = "plugIn">Name of the required plug-in (file name without extension).</param>
        public RequirePostSharpAttribute( string plugIn )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new <see cref="RequirePostSharpAttribute"/> and specifies the required <see cref="IService"/> type.
        /// </summary>
        /// <param name="serviceType">A type derived from <see cref="IService"/>.</param>
        public RequirePostSharpAttribute( Type serviceType )
        {
            ServiceType = serviceType;
        }

        /// <summary>
        ///   Gets the name of the required plug-in (file name without the extension).
        /// </summary>
        public string PlugIn { get; }

        /// <summary>
        ///   Gets the name of the required task (should be defined in <see cref = "PlugIn" />).
        /// </summary>
        public string Task { get; }

        /// <summary>
        /// Gets the type of the required <see cref="IService"/>.
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// Determines whether the requirement should apply only to assemblies referencing the declaration to
        /// which the custom attribute is applied. If <c>true</c>, the requirement will not apply to the assembly
        /// where the custom attribute is used.
        /// </summary>
        public bool AssemblyReferenceOnly { get; set; }

        /// <summary>
        /// Determines whether the current attribute applies to any project that has any
        /// reference of the target type. If <c>false</c>, the requirement will apply only
        /// to assemblies that use the target type as a custom attribute. If <c>true</c>,
        /// the requirement will apply to any assembly that references the target type. The default value is <c>false</c>.
        /// </summary>
        public bool AnyTypeReference { get; set; }
    }
}