﻿// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
    public class MetricAttribute : Attribute
    {
        public string MetricName { get; }

        public object Operand { get; }

        public MetricAttribute( string metricName, object operand )
        {
            this.MetricName = metricName;
            this.Operand = operand;
        }

        public bool AllowImplementationMetrics { get; set; }
    }
}