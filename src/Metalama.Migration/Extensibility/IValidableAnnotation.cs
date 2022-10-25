namespace PostSharp.Extensibility
{
    [RequirePostSharp( null, "ValidateAnnotations" )]
    public interface IValidableAnnotation
    {
        bool CompileTimeValidate( object target );
    }
}