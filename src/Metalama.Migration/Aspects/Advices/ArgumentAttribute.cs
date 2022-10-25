namespace PostSharp.Aspects.Advices
{
    /// <exclude />
    public sealed class ArgumentAttribute : AdviceParameterAttribute
    {
        /// <exclude />
        public int Index { get; }

        /// <exclude />
        public ArgumentAttribute( int index )
        {
            Index = index;
        }
    }
}