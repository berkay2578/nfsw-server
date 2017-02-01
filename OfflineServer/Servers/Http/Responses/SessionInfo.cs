using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("SessionInfo", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service")]
    public class SessionInfo
    {
        [XmlElement("Challenge")]
        public SecurityChallenge challenge = new SecurityChallenge();
        [XmlElement("EventId")]
        public Int32 eventId;
        [XmlElement("SessionId")]
        public Int64 sessionId = 1L;
    }
}
