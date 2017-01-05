using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class User
    {
        [XmlElement("address1")]
        public String address1 = null;
        [XmlElement("address2")]
        public String address2 = null;
        [XmlElement("country")]
        public String country = null;
        [XmlElement("dateCreated")]
        public String dateCreated = null;
        [XmlElement("dob")]
        public String dob = null;
        [XmlElement("email")]
        public String email = null;
        [XmlElement("emailStatus")]
        public String emailStatus = null;
        [XmlElement("firstName")]
        public String firstName = null;
        [XmlElement("fullGameAccess")]
        public Boolean fullGameAccess = true;
        [XmlElement("gender")]
        public String gender = null;
        [XmlElement("idDigits")]
        public String idDigits = null;
        [XmlElement("isComplete")]
        public Boolean isComplete = true;
        [XmlElement("landlinePhone")]
        public String landlinePhone = null;
        [XmlElement("language")]
        public String language = null;
        [XmlElement("lastAuthDate")]
        public String lastAuthDate = null;
        [XmlElement("lastName")]
        public String lastName = null;
        [XmlElement("mobile")]
        public String mobile = null;
        [XmlElement("nickname")]
        public String nickname = null;
        [XmlElement("postalCode")]
        public String postalCode = null;
        [XmlElement("realName")]
        public String realName = null;
        [XmlElement("reasonCode")]
        public String reasonCode = null;
        [XmlElement("remoteUserId")]
        public Int32 remoteUserId = 1;
        [XmlElement("securityToken")]
        public String securityToken = "a";
        [XmlElement("starterPackEntitlementTag", IsNullable = true)]
        public String starterPackEntitlementTag = null;
        [XmlElement("status")]
        public String status = null;
        [XmlElement("subscribeMsg")]
        public Boolean subscribeMsg = false;
        [XmlElement("tosVersion")]
        public String tosVersion = null;
        [XmlElement("userId")]
        public Int32 userId = 1;
        [XmlElement("username")]
        public String username = null;
    }
}
