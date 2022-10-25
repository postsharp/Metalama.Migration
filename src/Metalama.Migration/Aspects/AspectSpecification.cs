// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
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
        private readonly IAspect aspect;
        private readonly ObjectConstruction aspectConstruction;
        private readonly AspectConfiguration aspectConfiguration;

        internal AspectSpecification( IAspect aspect, AspectConfiguration aspectConfiguration )
        {
            #region Preconditions

            if ( aspect == null ) throw new ArgumentNullException( nameof(aspect));

            #endregion

            this.aspect = aspect;
            this.aspectConfiguration = aspectConfiguration;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectSpecification" /> from an aspect instance.
        /// </summary>
        /// <param name = "aspect">Aspect instance.</param>
        /// <param name = "aspectConstruction">Construction of the aspect (or <c>null</c> if the construction
        ///   is not available - in this case the aspect is required to have a serializer).</param>
        internal AspectSpecification( IAspect aspect, ObjectConstruction aspectConstruction )
        {
            #region Preconditions

            if ( aspect == null ) throw new ArgumentNullException( nameof(aspect));

            #endregion

            this.aspectConstruction = aspectConstruction;
            this.aspect = aspect;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectSpecification" /> when one cannot provide an aspect instance,
        ///   i.e. from an <see cref = "ObjectConstruction" /> and a <see cref = "Configuration.AspectConfiguration" />.
        /// </summary>
        /// <param name = "aspectConstruction">Aspect construction.</param>
        /// <param name = "aspectConfiguration">Aspect configuration.</param>
        protected internal AspectSpecification( ObjectConstruction aspectConstruction,
                                                AspectConfiguration aspectConfiguration )
        {
            #region Preconditions

            if ( aspectConstruction == null ) throw new ArgumentNullException( nameof(aspectConstruction));

            #endregion

            this.aspectConfiguration = aspectConfiguration;
            this.aspectConstruction = aspectConstruction;
        }


        /// <summary>
        ///   Gets the aspect configuration.
        /// </summary>
        /// <value>
        ///   The aspect configuration, or <c>null</c> if none was provided.
        /// </value>
        public AspectConfiguration AspectConfiguration
        {
            get { return this.aspectConfiguration; }
        }

        /// <summary>
        ///   Gets the aspect construction.
        /// </summary>
        /// <value>
        ///   The aspect construction, or <c>null</c> if the aspect instance was provided instead.
        /// </value>
        public ObjectConstruction AspectConstruction
        {
            get { return this.aspectConstruction; }
        }

        /// <summary>
        ///   Gets the aspect instance.
        /// </summary>
        /// <value>
        ///   The aspect instance, or <c>null</c> if the <see cref = "AspectConfiguration" /> was provided instead.
        /// </value>
        public IAspect Aspect
        {
            get { return this.aspect; }
        }

        /// <summary>
        ///   Gets the assembly-qualified type name of the aspect.
        /// </summary>
        public string AspectAssemblyQualifiedTypeName
        {
            get
            {
                return this.aspect != null
                           ? this.aspect.GetType().AssemblyQualifiedName
                           : this.aspectConstruction.TypeName;
            }
        }

        /// <summary>
        ///   Gets the type name of the aspect.
        /// </summary>
        public string AspectTypeName
        {
            get
            {
                if ( this.aspect != null )
                    return this.aspect.GetType().FullName;
                else
                {
                    int index = this.aspectConstruction.TypeName.IndexOf( ',' );
                    if ( index > 0 )
                        return this.aspectConstruction.TypeName.Substring( 0, index );
                    else
                        return this.aspectConstruction.TypeName;
                }
            }
        }
    }
}

