namespace PostSharp.Aspects
{
    public interface IInstanceScopedAspect : IAspect
    {
        // TODO: The correct semantics seem to be:
        //  object CreateInstance();   --> called before inline field assign,ent
        // void RuntimeInitializeInstance(object target --> called after base constructor (when 'this' is available).

        object CreateInstance( AdviceArgs adviceArgs );

        void RuntimeInitializeInstance();
    }
}