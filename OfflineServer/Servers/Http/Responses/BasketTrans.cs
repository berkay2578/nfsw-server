using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("BasketTrans", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization")]
    public class BasketTrans
    {
        [XmlArray("Items")]
        [XmlArrayItem("BasketItemTrans")]
        public List<BasketItemTrans> basketItems;
    }
}
