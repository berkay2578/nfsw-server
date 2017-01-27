using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using static OfflineServer.Economy.Basket;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CommerceSessionResultTrans", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization", IsNullable = true)]
    public class CommerceSessionResultTrans
    {
        [XmlElement("InvalidBasket", IsNullable = false)]
        public String invalidBasket = "";
        [XmlArray("InventoryItems")]
        [XmlArrayItem("InventoryItemTrans")]
        public List<InventoryItemTrans> inventoryItems;
        [XmlElement("UpdatedCar")]
        public UpdatedCar updatedCar;
        [XmlElement("Status")]
        public String status = ShoppingCartPurchaseResult.success;
        [XmlElement("Wallets")]
        public Wallets wallets = new Wallets();
    }
}
