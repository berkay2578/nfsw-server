using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    public class PersonaBase
    {
        [XmlElement("Badges")]
        public String badges = "";
        [XmlElement("IconIndex")]
        public Int16 iconIndex = 27;
        [XmlElement("Level")]
        public Int32 level = 0;
        [XmlElement("Motto")]
        public String motto = "";
        [XmlElement("Name")]
        public String name = "Debug";
        [XmlElement("PersonaId")]
        public Int32 personaId = 0;
        [XmlElement("Presence")]
        public Int32 presence = 0;
        [XmlElement("Score")]
        public Int32 score = 0;
        [XmlElement("UserId")]
        public Int32 userId = 1;
    }
}