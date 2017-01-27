using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("SkillModPartTrans")]
    public class SkillModPartTrans
    {
        [XmlElement("IsFixed", Order = 1)]
        public Boolean isFixed;
        [XmlElement("SkillModPartAttribHash", Order = 2)]
        public Int32 skillModPartAttribHash;
    }
}
