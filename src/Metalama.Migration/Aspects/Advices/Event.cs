namespace PostSharp.Aspects.Advices
{
    public sealed class Event<TDelegate>
    {
        public Event( EventAccessor<TDelegate> addDelegate, EventAccessor<TDelegate> removeDelegate )
        {
            Add = addDelegate;
            Remove = removeDelegate;
        }

        public EventAccessor<TDelegate> Add { get; }

        public EventAccessor<TDelegate> Remove { get; }
    }
}