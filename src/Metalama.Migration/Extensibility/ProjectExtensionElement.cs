// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;


namespace PostSharp.Extensibility
{
    /// <summary>
    /// Represents a custom element (or section) in the XML project type.
    /// </summary>
    public sealed class ProjectExtensionElement
    {

        internal ProjectExtensionElement(string name, string ns, object xmlElement, bool isWellKnown)
        {
            this.Name = name;
            this.Namespace = ns;
            this.XElement = xmlElement;
            this.IsWellKnown = isWellKnown;
        }

        /// <summary>
        /// Gets the local name of the custom element.
        /// </summary>
        public string Name { get; private set; }

        internal bool? IsEnabled { get; set; }
        
        internal bool IsWellKnown { get; private set; }

        /// <summary>
        /// Gets the XML namespace of the custom element.
        /// </summary>
        public string Namespace { get; private set; }

        /// <summary>
        /// Gets the <c>XElement</c> materializing the project extension.
        /// </summary>
        public object XElement { get; private set; }
        
    }
}

