using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Custom attribute that, when applied on an aspect, causes the aspect to increment some metric at build time.
    /// </summary>
    /// <remarks>
    ///  These metrics are used by PostSharp to collect usage information and are transferred to the makers
    /// of PostSharp only if you opted in for the Customer Experience Improvement Program.
    /// </remarks>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true )]
    public class MetricAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the metric.
        /// </summary>
        public string MetricName { get; }

        /// <summary>
        /// Gets the operand of the metric.
        /// </summary>
        public object Operand { get; }

        /// <summary>
        /// Initializes a new <see cref="MetricAttribute"/>.
        /// </summary>
        /// <param name="metricName">Metric name.</param>
        /// <param name="operand">Metric operand.</param>
        public MetricAttribute( string metricName, object operand )
        {
            MetricName = metricName;
            Operand = operand;
        }

        /// <summary>
        /// Determines whether the usage of features used by the target aspects must be instrumented.
        /// </summary>
        public bool AllowImplementationMetrics { get; set; }
    }
}