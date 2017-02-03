using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("LuckyDrawItem")]
    public class LuckyDrawItem
    {
        [XmlElement("Description")]
        public String description = "";
        [XmlElement("Icon")]
        public String icon = "";
        [XmlElement("VirtualItem")]
        public String virtualItem = "";
        [XmlElement("VirtualItemType")]
        public String virtualItemType = "";
        [XmlElement("Hash")]
        public Int64 hash;
        [XmlElement("RemainingUseCount")]
        public Int32 remainingUseCount;
        [XmlElement("ResellPrice")]
        public Int32 resellPrice;
        [XmlElement("WasSold")]
        public Boolean wasSold;
    }
}
