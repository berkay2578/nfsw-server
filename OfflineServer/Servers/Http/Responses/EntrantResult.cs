using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization.Event")]
    public abstract class EntrantResult
    {
        [XmlElement("EventDurationInMilliseconds")]
        public UInt32 eventDurationInMilliseconds;
        [XmlElement("EventSessionId")]
        public Int64 eventSessionId;
        [XmlElement("FinishReason")]
        public FinishReason finishReason;
        [XmlElement("PersonaId")]
        public Int32 personaId;
        [XmlElement("Ranking")]
        public Int32 ranking;
    }
}
