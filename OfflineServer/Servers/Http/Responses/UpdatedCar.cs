using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("UpdatedCar")]
    public class UpdatedCar
    {
        [XmlElement("CustomCar")]
        public CustomCar customCar;
        [XmlElement("Durability")]
        public Int16 durability;
        [XmlElement("ExpirationDate")]
        public String expirationDate;
        [XmlElement("Heat")]
        public Int16 heatLevel;
        [XmlElement("Id")]
        public Int32 id;
        [XmlElement("OwnershipType")]
        public String ownershipType;
    }
}
