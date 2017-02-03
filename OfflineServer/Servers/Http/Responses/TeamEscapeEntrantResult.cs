using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class TeamEscapeEntrantResult : EntrantResult
    {
        [XmlElement("DistanceToFinish")]
        public float distanceToFinish;
        [XmlElement("FractionCompleted")]
        public float fractionCompleted;
    }
}
