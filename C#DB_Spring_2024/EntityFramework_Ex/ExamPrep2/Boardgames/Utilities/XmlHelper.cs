using System.Text;
using System.Xml.Serialization;

namespace Boardgames.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            using StringReader stringReader = new StringReader(inputXml);
            object? deserializedObject = serializer.Deserialize(stringReader);

            if(deserializedObject  == null
                || deserializedObject is not T deserializedObjectTypes)
            {
                throw new InvalidOperationException();
            }
            return deserializedObjectTypes;
        }
        public string Serialize<T>(T obj, string rootName)
        {
            StringBuilder sb=new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute(rootName);

            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            using StringWriter stringWriter = new StringWriter(sb);
            serializer.Serialize(stringWriter, obj,xmlSerializerNamespaces);
            
            return sb.ToString().Trim();
        }
    }
}
