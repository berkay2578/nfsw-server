using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("AchievementsPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class AchievementDefinitionPacket
    {
        [XmlElement("AchievementDefinitionId", Order = 1)]
        public Int32 achievementDefinitionId;
        [XmlArray("AchievementRanks", Order = 2)]
        [XmlArrayItem("AchievementRankPacket")]
        public List<AchievementRankPacket> achievementRanks;
        [XmlElement("BadgeDefinitionId", Order = 3)]
        public Int32 badgeDefinitionId;
        [XmlElement("CanProgress", Order = 4)]
        public Boolean canProgress;
        [XmlElement("CurrentValue", Order = 5)]
        public Int64 currentValue;
        [XmlElement("IsVisible", Order = 6)]
        public Boolean isVisible;
        [XmlElement("ProgressText", Order = 7)]
        public String progressText;
        [XmlElement("StatConversion", Order = 8)]
        public StatConversion statConversion;
    }

    [Serializable()]
    public enum StatConversion
    {
        [XmlEnum("None")]
        None,
        [XmlEnum("FromMillisecondsToMinutes")]
        FromMillisecondsToMinutes,
        [XmlEnum("FromSecondsToMinutes")]
        FromSecondsToMinutes,
        [XmlEnum("FromCentimetersPerSecondToSpeed")]
        FromCentimetersPerSecondToSpeed,
        [XmlEnum("FromMetersToDistance")]
        FromMetersToDistance,
        [XmlEnum("FromNumberToCurrency")]
        FromNumberToCurrency,
    }
}
