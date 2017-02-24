using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Xmpp.Responses
{
    [Serializable()]
    [XmlRoot("Badge", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class BadgePacket
    {
        [XmlElement("AchievementRankId")]
        public Int32 achievementRankId;
        [XmlElement("BadgeDefinitionId")]
        public Int32 badgeDefinitionId;
        [XmlElement("IsRare")]
        public Boolean isRare;
        [XmlElement("Rarity")]
        public float rarity;
        [XmlElement("SlotId")]
        public Int16 slotId;
    }
}
