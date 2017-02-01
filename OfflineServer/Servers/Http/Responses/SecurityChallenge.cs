using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("Challenge")]
    public class SecurityChallenge
    {
        [XmlElement("ChallengeId")]
        public String challengeId = "";
        [XmlElement("Pattern")]
        public String pattern = "";
        [XmlElement("LeftSize")]
        public Int32 leftSize = 0;
        [XmlElement("RightSize")]
        public Int32 rightSize = 0;
    }
}
