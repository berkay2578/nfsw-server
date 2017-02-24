using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Xmpp.Responses
{
    [Serializable()]
    [XmlRoot("AchievementAwarded", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class AchievementAwarded
    {
        [XmlElement("AchievedOn")]
        public String achievedOn = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ff");
        [XmlElement("Clip")]
        public String clip = "AchievementFlasherBase";
        [XmlElement("Description")]
        public String description;
        [XmlElement("Icon")]
        public String icon;
        [XmlElement("Name")]
        public String name;
        [XmlElement("AchievementDefinitionId")]
        public Int32 achievementDefinitionId;
        [XmlElement("AchievementRankId")]
        public Int32 achievementRankId;
        [XmlElement("ClipLengthInSeconds")]
        public float clipLengthInSeconds = 5f;
        [XmlElement("IsRare")]
        public bool isRare;
        [XmlElement("Points")]
        public Int16 points;
        [XmlElement("Rarity")]
        public float rarity;
    }
}
