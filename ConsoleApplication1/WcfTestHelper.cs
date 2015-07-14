using System.IO;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    public static class WcfTestHelper
    {
        public static T DataContractSerializationRoundTrip<T>(T obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            obj = (T) serializer.ReadObject(memoryStream);
            return obj;
        }
    }
}