using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class PursuitEventResult : EventResult
    {
        [XmlElement("Heat")]
        public float heat;
    }
}
