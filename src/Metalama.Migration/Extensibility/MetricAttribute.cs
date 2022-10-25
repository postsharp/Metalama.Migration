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
            MetricName = metricName;
            Operand = operand;
        }

        public bool AllowImplementationMetrics { get; set; }
    }
}