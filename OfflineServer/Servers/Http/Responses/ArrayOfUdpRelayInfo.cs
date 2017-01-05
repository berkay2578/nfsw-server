using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("ArrayOfUdpRelayInfo")]
    public class ArrayOfUdpRelayInfo
    {
        [XmlElement("UdpRelayInfo")]
        public UdpRelayInfo udpRelayInfo = new UdpRelayInfo();
    }
}
