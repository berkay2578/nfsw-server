using System;
using System.Xml.Serialization;

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
    }
}
