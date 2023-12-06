
namespace SKTools
{
    public interface ISKSerializable
    {
        object Serialize();
        void Deserialize(object data);   
    }
}