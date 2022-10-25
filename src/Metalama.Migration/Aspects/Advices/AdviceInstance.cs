namespace PostSharp.Aspects.Advices
{
    public abstract class AdviceInstance
    {
        public abstract object MasterAspectMember { get; }

        public string Description { get; set; }

        public int LinesOfCodeAvoided { get; set; }
    }
}