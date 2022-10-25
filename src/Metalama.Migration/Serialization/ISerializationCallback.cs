namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ILamaSerializationCallback"/>.
    /// </summary>
    public interface ISerializationCallback
    {
        void OnDeserialized();

        void OnSerializing();
    }
}