namespace PostSharp.Aspects
{
    
    
    
    
    
    public interface IAsyncMethodBinding : IMethodBinding
    {
        
        
        
        
        
        
        
        
        
        
        MethodBindingInvokeAwaitable InvokeAsync( ref object instance, Arguments arguments );
    }
}