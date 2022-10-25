namespace PostSharp.Aspects.Advices
{
    public sealed class ArgumentAttribute : AdviceParameterAttribute
    {
        public int Index { get; }

        public ArgumentAttribute( int index )
        {
            Index = index;
        }
    }
}