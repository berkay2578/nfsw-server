using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("OwnedCarTrans")]
    public class OwnedCarTrans
    {
        [XmlElement("CustomCar")]
        public CustomCar customCar;
        [XmlElement("Durability")]
        public Int16 durability;
        [XmlElement("ExpirationDate", IsNullable = true)]
        public String expirationDate = null;
        [XmlElement("Heat")]
        public float heatLevel;
        [XmlElement("Id")]
        public Int32 id;
        [XmlElement("OwnershipType")]
        public String ownershipType;
    }
}
