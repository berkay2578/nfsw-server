using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("AchievementsPacket", Namespace = "http://schemas.datacontract.org/2004/07/Victory.Service.Objects")]
    public class AchievementsPacket
    {
        [XmlArray("Badges")]
        [XmlArrayItem("BadgeDefinitionPacket")]
        public List<BadgeDefinitionPacket> badges = new List<BadgeDefinitionPacket>();
        [XmlArray("Definitions")]
        [XmlArrayItem("AchievementDefinitionPacket")]
        public List<AchievementDefinitionPacket> definitions = new List<AchievementDefinitionPacket>();
        [XmlElement("PersonaId")]
        public Int64 personaId = Access.CurrentSession.ActivePersona.Id;
    }
}
