using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("SecurityResponse")]
    public class SecurityResponse
    {
        [XmlElement("ChallengeId")]
        public String challengeId = "";
        [XmlElement("Result")]
        public Int64 result;
    }
}
