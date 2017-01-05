using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("UdpRelayInfo")]
    public class UdpRelayInfo
    {
        [XmlElement("Host")]
        public String host = "127.0.0.1";
        [XmlElement("Port")]
        public Int32 port = 9999;
    }
}
