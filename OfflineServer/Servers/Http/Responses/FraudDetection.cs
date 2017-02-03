using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class FraudDetection
    {
        [XmlElement("ModuleName")]
        public String moduleName = "";
        [XmlElement("ModulePath")]
        public String modulePath = "";
        [XmlElement("ModuleValue")]
        public String moduleValue = "";
        [XmlElement("StringValue1")]
        public String stringValue1 = "";
        [XmlElement("StringValue2")]
        public String stringValue2 = "";
        [XmlElement("Checksum")]
        public Int32 checksum;
        [XmlElement("IntValue1")]
        public Int32 intValue1;
        [XmlElement("IntValue2")]
        public Int32 intValue2;
        [XmlElement("IntValue3")]
        public Int32 intValue3;
        [XmlElement("IntValue4")]
        public Int32 intValue4;
        [XmlElement("IsEncrypted")]
        public Boolean isEncrypted;
    }
}
