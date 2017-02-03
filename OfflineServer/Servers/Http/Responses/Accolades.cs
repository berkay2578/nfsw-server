using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("Accolades", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization.Event")]
    public class Accolades
    {
        [XmlElement("FinalRewards")]
        public Reward finalRewards = new Reward();
        [XmlElement("HasLeveledUp")]
        public Boolean hasLeveledUp = false;
        [XmlElement("LuckyDrawInfo")]
        public LuckyDrawInfo luckyDrawInfo = new LuckyDrawInfo();
        [XmlElement("OriginalRewards")]
        public Reward originalRewards = new Reward();
        [XmlArray("RewardInfo")]
        [XmlArrayItem("RewardPart")]
        public List<RewardPart> rewardInfo = new List<RewardPart>();
    }
}
