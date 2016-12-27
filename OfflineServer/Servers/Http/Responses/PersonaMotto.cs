using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("PersonaMotto")]
    public class PersonaMotto
    {
        [XmlElement("message")]
        public String message;
        [XmlElement("personaId")]
        public Int32 personaId;
    }
}