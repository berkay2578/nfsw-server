using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Xmpp.Responses
{
    [Serializable()]
    [XmlRoot("Progress", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class AchievementProgress
    {
        [XmlElement("AchievementDefinitionId")]
        public Int32 achievementDefinitionId;
        [XmlElement("CurrentValue")]
        public Int64 currentValue;
    }
}
