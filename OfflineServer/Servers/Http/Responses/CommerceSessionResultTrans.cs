using System;
using System.Xml.Serialization;
using static OfflineServer.Economy.Basket;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CommerceSessionResultTrans", IsNullable = true)]
    public class CommerceSessionResultTrans
    {
        [XmlElement("InvalidBasket")]
        public String invalidBasket;
        [XmlElement("InventoryItems")]
        public String inventoryItems;
        [XmlElement("UpdatedCar")]
        public UpdatedCar updatedCar;
        [XmlElement("Status")]
        public String status = ShoppingCartPurchaseResult.success;
        [XmlElement("Wallets")]
        public Wallets wallets = new Wallets();
    }
}
