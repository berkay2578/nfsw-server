using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("InventoryItemTrans")]
    public class InventoryItemTrans
    {
        [XmlElement("EntitlementTag", IsNullable = false)]
        public String entitlementTag;
        [XmlElement("ExpirationDate", IsNullable = false)]
        public String expirationDate;
        [XmlElement("Hash")]
        public Int64 hash;
        [XmlElement("InventoryId")]
        public Int64 inventoryId;
        [XmlElement("ProductId", IsNullable = false)]
        public String productId;
        [XmlElement("RemainingUseCount")]
        public Int32 remainingUseCount;
        [XmlElement("ResellPrice")]
        public Int32 resellPrice;
        [XmlElement("Status", IsNullable = false)]
        public String status;
        [XmlElement("StringHash", IsNullable = false)]
        public String stringHash;
        [XmlElement("VirtualItemType", IsNullable = false)]
        public String virtualItemType;
    }
}
