using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("TreasureHuntEventSession", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization.Event")]
    public class TreasureHuntEventSession
    {
        [XmlElement("CoinsCollected")]
        public Int32 coinsCollected;
        [XmlElement("IsStreakBroken")]
        public Boolean isStreakBroken;
        [XmlElement("NumCoins")]
        public Int32 numCoins;
        [XmlElement("Seed")]
        public Int32 seed;
        [XmlElement("Streak")]
        public Int32 streak;
    }
}
