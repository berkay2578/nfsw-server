using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CommerceSessionTrans", Namespace = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization", IsNullable = true)]
    public class CommerceSessionTrans
    {
        [XmlElement("Basket")]
        public BasketTrans basketTrans;
        [XmlElement("EntitlementsToSell")]
        public EntitlementTrans entitlementsToSell;
        [XmlElement("UpdatedCar")]
        public UpdatedCar updatedCar;
    }
}
