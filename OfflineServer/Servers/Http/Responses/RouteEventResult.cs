using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization.Event")]
    public class RouteEventResult : EventResult
    {
        [XmlArray("Entrants")]
        [XmlArrayItem("RouteEntrantResult")]
        public List<RouteEntrantResult> entrants = new List<RouteEntrantResult>();
    }
}
