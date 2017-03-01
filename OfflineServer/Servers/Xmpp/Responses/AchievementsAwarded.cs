using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using OfflineServer.Servers.Http.Responses;

namespace OfflineServer.Servers.Xmpp.Responses
{
    [Serializable()]
    [XmlRoot("AchievementsAwarded", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class AchievementsAwarded
    {
        [XmlArray("Achievements")]
        [XmlArrayItem("AchievementAwarded")]
        public List<AchievementAwarded> achievements = new List<AchievementAwarded>();
        [XmlArray("Badges")]
        [XmlArrayItem("Badge")]
        public List<BadgePacket> badges = new List<BadgePacket>();
        [XmlElement("PersonaId")]
        public Int64 personaId = Access.CurrentSession.ActivePersona.Id;
        [XmlArray("Progressed")]
        [XmlArrayItem("AchievementProgress")]
        public List<AchievementProgress> progressed = new List<AchievementProgress>();
        [XmlElement("Score")]
        public Int32 score;
    }
}
