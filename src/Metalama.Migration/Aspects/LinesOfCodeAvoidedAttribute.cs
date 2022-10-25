﻿using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Custom attribute that, when applied to an aspect class, specifies how many manual lines of code
    /// are avoided every time the aspect is being used.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
    public sealed class LinesOfCodeAvoidedAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="LinesOfCodeAvoidedAttribute"/>.
        /// </summary>
        /// <param name="lines">Number of lines of code saved every time the aspect is applied to a target class.</param>
        public LinesOfCodeAvoidedAttribute( int lines )
        {
            Count = lines;
        }

        /// <summary>
        /// Gets the number of lines of code saved every time the aspect is applied to a target class.
        /// </summary>
        public int Count { get; }
    }
}