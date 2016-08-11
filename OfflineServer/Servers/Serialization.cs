using System;
using System.IO;
using System.Xml.Serialization;

namespace OfflineServer.Servers
{
    public static class Serialization
    {
        public static String SerializeObject<T>(this T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }
    }
}