using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("LuckyDrawBox")]
    public class LuckyDrawBox
    {
        [XmlElement("LocalizationString")]
        public String localizationString = "";
        [XmlElement("IsValid")]
        public Boolean isValid;
        [XmlElement("LuckyDrawSetCategoryId")]
        public Int32 luckyDrawSetCategoryId;
    }
}
