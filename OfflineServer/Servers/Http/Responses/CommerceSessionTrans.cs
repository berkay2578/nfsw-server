using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CommerceSessionTrans", IsNullable = true)]
    public class CommerceSessionTrans
    {
        [XmlElement("Basket")]
        public String basketTrans;
        [XmlElement("EntitlementsToSell")]
        public String entitlementsToSell;
        [XmlElement("UpdatedCar")]
        public UpdatedCar updatedCar;
    }
}
