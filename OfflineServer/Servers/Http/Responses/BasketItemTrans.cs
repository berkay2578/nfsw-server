using System;
using System.Xml.Serialization;
using static OfflineServer.Basket;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("BasketItemTrans")]
    public class BasketItemTrans
    {
        [XmlElement("ProductId")]
        public String productId;
        [XmlElement("Quantity")]
        public Int32 quantity;

        public BasketItemType getItemType()
        {
            if (productId.StartsWith("SRV-TH_REVIVE"))
                return BasketItemType.THRevive;
            else if (productId.StartsWith("SRV-REPAIR"))
                return BasketItemType.Repair;
            else if (productId.StartsWith("SRV-CARSLOT"))
                return BasketItemType.CarSlot;
            else if (productId.StartsWith("SRV-POWERUP"))
                return BasketItemType.Powerup;
            else if (productId.StartsWith("SRV-CAR"))
                return BasketItemType.Car;
            else
                return BasketItemType.Unknown;
        }
    }
}
