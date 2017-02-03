using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization.Event")]
    public abstract class EventResult
    {
        [XmlElement("Accolades")]
        public Accolades accolades;
        [XmlElement("Durability")]
        public Int32 durability;
        [XmlElement("EventId")]
        public Int32 eventId = 1;
        [XmlElement("EventSessionId")]
        public Int64 eventSessionId = 1;
        [XmlElement("ExitPath")]
        public ExitPath exitPath = ExitPath.ExitToFreeroam;
        [XmlElement("InviteLifetimeInMilliseconds")]
        public Int32 inviteLifetimeInMilliseconds = 0;
        [XmlElement("LobbyInviteId")]
        public Int64 lobbyInviteId = 0;
        [XmlElement("PersonaId")]
        public Int32 personaId;
    }

    [Serializable()]
    public enum ExitPath
    {
        [XmlEnum("ExitToFreeRoam")]
        ExitToFreeroam,
        [XmlEnum("ExitToLobby")]
        ExitToLobby,
    }
}
