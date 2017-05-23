using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    public static class VirtualItemType
    {
        public static readonly String powerup = "powerup";
        public static readonly String amplifier = "amplifier";
        public static readonly String skillMod = "skillmodpart";
        public static readonly String presetCar = "presetcar";
        public static readonly String vinyl = "vinyl";
    }

    [Serializable()]
    [XmlRoot("InventoryItemTrans")]
    public class InventoryItemTrans
    {
        [XmlElement("EntitlementTag")]
        public String entitlementTag;
        [XmlElement("ExpirationDate", IsNullable = true)]
        public String expirationDate = null;
        [XmlElement("Hash")]
        public Int64 hash;
        [XmlElement("InventoryId")]
        public Int64 inventoryId;
        [XmlElement("ProductId")]
        public String productId = "DO NOT USE ME";
        [XmlElement("RemainingUseCount")]
        public Int32 remainingUseCount;
        [XmlElement("ResellPrice")]
        public Int32 resellPrice = 0;
        [XmlElement("Status")]
        public String status = "ACTIVE";
        [XmlElement("StringHash")]
        public String stringHash;
        [XmlElement("VirtualItemType")]
        public String virtualItemType;

        public void setTag(String entitlementTag, Boolean alsoSetHash = true)
        {
            this.entitlementTag = entitlementTag;
            if (alsoSetHash)
                setHash(entitlementTag);
        }
        public void setHash(String entitlementTag)
        {
            String hexHash = Engine.getHexHash(entitlementTag);
            hash = Convert.ToInt32(hexHash, 16);
            stringHash = "0x" + hexHash;
        }
    }
}
