using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("BasketTrans")]
    public class BasketTrans
    {
        [XmlArray("Items")]
        [XmlArrayItem("BasketItemTrans")]
        public List<BasketItemTrans> basketItems;
    }
}
