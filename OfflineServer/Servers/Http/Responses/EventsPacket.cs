using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("EventsPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization.Event")]
    public class EventsPacket
    {
        [XmlArray("Events")]
        [XmlArrayItem("EventDefinition")]
        public List<EventDefinition> events;
    }
}
