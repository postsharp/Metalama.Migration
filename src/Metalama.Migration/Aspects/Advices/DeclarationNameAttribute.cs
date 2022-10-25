namespace PostSharp.Aspects.Advices
{
    public sealed class DeclarationNameAttribute : AdviceParameterAttribute
    {
        public bool IncludeTypeName { get; set; }
    }
}