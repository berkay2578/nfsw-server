using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CommerceResultTrans", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization")]
    public class CommerceResultTrans
    {
        [XmlArray("CommerceItems")]
        [XmlArrayItem("CommerceItemTrans")]
        public List<CommerceItemTrans> commerceItems;
        [XmlElement("InvalidBasket")]
        public String invalidBasket = "";
        [XmlArray("InventoryItems")]
        [XmlArrayItem("InventoryItemTrans")]
        public List<InventoryItemTrans> inventoryItems;
        [XmlArray("PurchasedCars")]
        [XmlArrayItem("OwnedCarTrans")]
        public List<OwnedCarTrans> purchasedCars;
        [XmlElement("Status")]
        public String status;
        [XmlElement("Wallets")]
        public Wallets wallets = new Wallets();
    }
}
