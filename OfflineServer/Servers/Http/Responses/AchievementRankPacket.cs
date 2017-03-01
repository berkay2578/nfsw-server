using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("AchievementRankPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class AchievementRankPacket
    {
        [XmlElement("AchievedOn", Order = 1)]
        public String achievedOn = DateTime.FromBinary(1L).ToString("yyyy-MM-ddTHH:mm:ss.ff");
        [XmlElement("AchievementRankId", Order = 2)]
        public Int32 achievementRankId;
        [XmlElement("IsRare", Order = 3)]
        public Boolean isRare;
        [XmlElement("Points", Order = 4)]
        public Int16 points;
        [XmlElement("Rank", Order = 5)]
        public Int16 rank;
        [XmlElement("Rarity", Order = 6)]
        public float rarity;
        [XmlElement("RewardDescription", Order = 7)]
        public String rewardDescription;
        [XmlElement("RewardType", Order = 8)]
        public String rewardType;
        [XmlElement("RewardVisualStyle", Order = 9)]
        public String rewardVisualStyle;
        [XmlElement("State", Order = 10)]
        public AchievementState state;
        [XmlElement("ThresholdValue", Order = 11)]
        public Int64 thresholdValue;
    }

    [Serializable()]
    public enum AchievementState
    {
        [XmlEnum("Locked")]
        Locked,
        [XmlEnum("InProgress")]
        InProgress,
        [XmlEnum("RewardWaiting")]
        RewardWaiting,
        [XmlEnum("Completed")]
        Completed,
    }
}
