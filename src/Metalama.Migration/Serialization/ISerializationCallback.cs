namespace PostSharp.Serialization
{
    public interface ISerializationCallback
    {
        void OnDeserialized();

        void OnSerializing();
    }
}