using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CustomPaintTrans")]
    public class CustomPaintTrans
    {
        [XmlElement("Group", Order = 1)]
        public Int32 group;
        [XmlElement("Hue", Order = 2)]
        public Int32 hue;
        [XmlElement("Sat", Order = 3)]
        public Int32 saturation;
        [XmlElement("Slot", Order = 4)]
        public Int32 slot;
        [XmlElement("Var", Order = 5)]
        public Int32 var;
    }
}
