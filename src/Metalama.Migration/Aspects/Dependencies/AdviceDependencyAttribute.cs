namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// In Metalama, advice methods have no dependencies.
    /// </summary>
    public sealed class AdviceDependencyAttribute : AspectDependencyAttribute
    {
        public AdviceDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string adviceMethodName )
            : base( action, position )
        {
            AdviceMethodName = adviceMethodName;
        }

        public AdviceDependencyAttribute( AspectDependencyAction action, string adviceMethodName )
            : base( action )
        {
            AdviceMethodName = adviceMethodName;
        }

        public string AdviceMethodName { get; }
    }
}