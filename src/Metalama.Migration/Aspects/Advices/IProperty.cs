namespace PostSharp.Aspects.Advices
{
    public interface IProperty
    {
        object GetValue();

        void SetValue( object value );
    }
}