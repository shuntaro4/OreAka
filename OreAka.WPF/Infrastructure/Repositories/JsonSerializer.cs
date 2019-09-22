using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace OreAka.WPF.Infrastructure.Repositories
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize(object target)
        {
            using (var memoryStream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(target.GetType());
                serializer.WriteObject(memoryStream, target);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public T Desirialize<T>(string json)
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(memoryStream);
            }
        }
    }
}
