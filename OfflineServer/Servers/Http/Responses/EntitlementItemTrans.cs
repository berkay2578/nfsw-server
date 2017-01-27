using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("EntitlementItemTrans")]
    public class EntitlementItemTrans
    {
        [XmlElement("EntitlementId")]
        public String entitlementId;
        [XmlElement("Quantity")]
        public Int32 quantity;
    }
}
