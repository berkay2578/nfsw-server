using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("RegionInfo")]
    public class RegionInfo
    {
        [XmlElement("CountdownProposalInMilliseconds")]
        public Int32 countdownProposalInMilliseconds = 3000;
        [XmlElement("DirectConnectTimeoutInMilliseconds")]
        public Int32 directConnectTimeoutInMilliseconds = 1000;
        [XmlElement("DropOutTimeInMilliseconds")]
        public Int32 dropOutTimeInMilliseconds = 15000;
        [XmlElement("EventLoadTimeoutInMilliseconds")]
        public Int32 eventLoadTimeoutInMilliseconds = 30000;
        [XmlElement("HeartbeatIntervalInMilliseconds")]
        public Int32 heartbeatIntervalInMilliseconds = 10000;
        [XmlElement("UdpRelayBandwidthInBps")]
        public Int32 udpRelayBandwidthInBps = 0;
        [XmlElement("UdpRelayTimeoutInMilliseconds")]
        public Int32 udpRelayTimeoutInMilliseconds = 60000;
    }
}
