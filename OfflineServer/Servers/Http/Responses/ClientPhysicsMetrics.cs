using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class ClientPhysicsMetrics
    {
        [XmlElement("AccelerationAverage")]
        public float accelerationAverage;
        [XmlElement("AccelerationMaximum")]
        public float accelerationMaximum;
        [XmlElement("AccelerationMedian")]
        public float accelerationMedian;
        [XmlElement("SpeedAverage")]
        public float speedAverage;
        [XmlElement("SpeedMaximum")]
        public float speedMaximum;
        [XmlElement("SpeedMedian")]
        public float speedMedian;
    }
}
