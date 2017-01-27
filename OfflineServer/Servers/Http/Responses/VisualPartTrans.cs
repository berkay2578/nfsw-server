using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("VisualPartTrans")]
    public class VisualPartTrans
    {
        [XmlElement("PartHash", Order = 1)]
        public Int32 partHash;
        [XmlElement("SlotHash", Order = 2)]
        public Int32 slotHash;
    }
}
