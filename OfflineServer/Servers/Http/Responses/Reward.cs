using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class Reward
    {
        [XmlElement("Rep")]
        public Int32 rep = 0;
        [XmlElement("Tokens")]
        public Int32 tokens = 0;
    }
}
