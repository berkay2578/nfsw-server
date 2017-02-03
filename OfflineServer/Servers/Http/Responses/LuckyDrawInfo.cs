using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("LuckyDrawInfo")]
    public class LuckyDrawInfo
    {
        [XmlElement("CardDeck")]
        public CardDeck cardDeck;
        [XmlArray("Boxes")]
        [XmlArrayItem("LuckyDrawBox")]
        public List<LuckyDrawBox> boxes = new List<LuckyDrawBox>();
        [XmlElement("CurrentStreak")]
        public Int32 currentStreak;
        [XmlElement("IsStreakBroken")]
        public Boolean isStreakBroken;
        [XmlArray("Items")]
        [XmlArrayItem("LuckyDrawItem")]
        public List<LuckyDrawItem> items = new List<LuckyDrawItem>();
        [XmlElement("NumBoxAnimations")]
        public Int32 numBoxAnimations = 100;
        [XmlElement("NumCards")]
        public Int32 numCards = 5;
    }

    [Serializable()]
    public enum CardDeck
    {
        [XmlEnum("LD_CARD_BLUE")]
        LD_CARD_BLUE,
        [XmlEnum("LD_CARD_BRONZE")]
        LD_CARD_BRONZE,
        [XmlEnum("LD_CARD_SILVER")]
        LD_CARD_SILVER,
        [XmlEnum("LD_CARD_GOLD")]
        LD_CARD_GOLD,
        [XmlEnum("LD_CARD_SPECIAL_GOLD")]
        LD_CARD_SPECIAL_GOLD
    }
}
