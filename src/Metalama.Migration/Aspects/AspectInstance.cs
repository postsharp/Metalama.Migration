using System;
using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Completely specifies an aspect instance, including its target code element. An <see cref = "AspectInstance" />
    ///   contains either the aspect instance itself (<see cref = "Aspect" /> property), either information allowing to construct the aspect 
    ///   (<see cref = "AspectSpecification.AspectConstruction" />) and configure the weaver (<see cref = "AspectConfiguration" />).
    /// </summary>
    /// <see cref = "IAspectProvider" />
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectProvider']/*" />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public sealed class AspectInstance : AspectSpecification
    {
        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from a runtime aspect instance (<see cref = "IAspect" />).
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspect">The aspect runtime instance.</param>
        public AspectInstance( object targetElement, IAspect aspect ) { }

        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from a runtime aspect instance (<see cref = "IAspect" />)
        ///   and its <see cref = "AspectConfiguration" />.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspect">The aspect runtime instance.</param>
        /// <param name = "aspectConfiguration">The aspect configuration (the type of this parameter should be equal to the
        ///   type configuration objects expected by the concrete <paramref name = "aspect" />).</param>
        public AspectInstance( object targetElement, IAspect aspect, AspectConfiguration aspectConfiguration ) { }

        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from an <see cref="ObjectConstruction"/>.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspectConstruction">An <see cref = "ObjectConstruction" /> instructing how the aspect instance
        ///   should be constructed.</param>
        public AspectInstance( object targetElement, ObjectConstruction aspectConstruction ) { }

        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from an <see cref="ObjectConstruction"/> and specifies an <see cref="AspectConfiguration"/> object.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspectConstruction">An <see cref = "ObjectConstruction" /> instructing how the aspect instance
        ///   should be constructed.</param>
        /// <param name = "aspectConfiguration">An optional configuration object whose type corresponds to 
        ///   the aspect type.</param>
        public AspectInstance(
            object targetElement,
            ObjectConstruction aspectConstruction,
            AspectConfiguration aspectConfiguration ) { }

        /// <summary>
        ///   Gets the code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.
        /// </summary>
        public object TargetElement { get; }

        /// <summary>
        /// Determines whether the <see cref="AspectInstance"/> should be represented as a stand-alone instance
        /// in PostSharp Tools for Visual Studio. If <c>false</c>, the current <see cref="AspectInstance"/>
        /// will be not be represented as a standalone node, and its advices will be merged with the ones provided 
        /// by the parent aspect (implementing <see cref="IAspectProvider"/>). The default value is <c>false</c>.
        /// </summary>
        public bool RepresentAsStandalone { get; set; }
    }
}