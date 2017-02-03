using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization.Event")]
    public class RouteEntrantResult : EntrantResult
    {
        [XmlElement("BestLapDurationInMilliseconds")]
        public UInt32 bestLapDurationInMilliseconds;
        [XmlElement("TopSpeed")]
        public float topSpeed;
    }
}
