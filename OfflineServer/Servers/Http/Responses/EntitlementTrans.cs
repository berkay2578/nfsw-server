using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("EntitlementTrans")]
    public class EntitlementTrans
    {
        [XmlArray("Items")]
        [XmlArrayItem("EntitlementItemTrans")]
        public List<EntitlementItemTrans> entitlementItems;
    }
}
