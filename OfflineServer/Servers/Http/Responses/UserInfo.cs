using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlInclude(typeof(ProfileData))]
    [XmlRoot("UserInfo", Namespace = "http://schemas.datacontract.org/2004/07/Victory.TransferObjects.User", IsNullable = true)]
    public class UserInfo
    {
        [XmlElement("defaultPersonaIdx")]
        public Int32 defaultPersonaIdx = 0;
        [XmlArray("personas")]
        [XmlArrayItem("ProfileData")]
        public List<ProfileData> personas = new List<ProfileData>();
        [XmlElement("user")]
        public User user = new User();
    }
}
