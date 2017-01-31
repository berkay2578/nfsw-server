using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CommerceItemTrans")]
    public class CommerceItemTrans
    {
        [XmlElement("Title")]
        public String title;
        [XmlElement("Hash")]
        public Int32 hash;
    }
}
