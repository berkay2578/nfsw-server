using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class DragEntrantResult : EntrantResult
    {
        [XmlElement("TopSpeed")]
        public float topSpeed;
    }
}
