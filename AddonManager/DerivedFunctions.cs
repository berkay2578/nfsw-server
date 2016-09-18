using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace AddonManager
{
    internal static class DerivedFunctions
    {
        public static String serializeObject<T>(this T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter stringWriter = new StringWriter()) 
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = new UTF8Encoding(false, false), Indent = true, OmitXmlDeclaration = false }))
            {
                xmlSerializer.Serialize(xmlWriter, obj);
                return stringWriter.ToString();
            }
        }
        public static T DeserializeObject<T>(this String plainXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringReader stringReader = new StringReader(plainXml))
            using (XmlReader xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings()))
            {
                return (T)xmlSerializer.Deserialize(xmlReader);
            }
        }
    }
}