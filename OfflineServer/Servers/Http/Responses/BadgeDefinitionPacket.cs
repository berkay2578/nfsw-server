using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("BadgeDefinitionPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class BadgeDefinitionPacket
    {
        [XmlElement("Background", Order = 1)]
        public String background;
        [XmlElement("BadgeDefinitionId", Order = 2)]
        public Int32 badgeDefinitionId;
        [XmlElement("Border", Order = 3)]
        public String border;
        [XmlElement("Description", Order = 4)]
        public String description;
        [XmlElement("Icon", Order = 5)]
        public String icon;
        [XmlElement("Name", Order = 6)]
        public String name;
    }
}
