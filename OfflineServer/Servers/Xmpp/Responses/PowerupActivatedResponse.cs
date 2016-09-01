using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Xmpp.Responses
{
    [Serializable()]
    [XmlRoot("response")]
    public class PowerupActivatedResponse
    {
        [XmlElement("PowerupActivated")]
        public PowerupActivated powerupActivated;
        [XmlAttribute("status")]
        public Int32 status = 1;
        [XmlAttribute("ticket")]
        public Int32 ticket = 0;
    }
}
