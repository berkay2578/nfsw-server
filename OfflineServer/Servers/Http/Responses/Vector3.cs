using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("Vector3", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization")]
    public class Vector3
    {
        [XmlElement("X")]
        public float x;
        [XmlElement("Y")]
        public float y;
        [XmlElement("Z")]
        public float z;
    }
}
