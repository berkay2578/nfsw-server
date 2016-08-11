using System;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("ProfileData")]
    public class ProfileData
    {
        [XmlElement("Badges")]
        public String badges;
        [XmlElement("Boost")]
        public Int32 boost;
        [XmlElement("Cash")]
        public Int32 cash;
        [XmlElement("IconIndex")]
        public Int16 iconIndex;
        [XmlElement("Level")]
        public Int32 level;
        [XmlElement("Motto")]
        public String motto;
        [XmlElement("Name")]
        public String name;
        [XmlElement("PercentToLevel")]
        public Int32 percentToLevel;
        [XmlElement("PersonaId")]
        public Int32 personaId;
        [XmlElement("Rating")]
        public Int32 rating;
        [XmlElement("Rep")]
        public Int32 rep;
        [XmlElement("RepAtCurrentLevel")]
        public Int32 repAtCurrentLevel;
        [XmlElement("ccar")]
        public String ccar;
        [XmlElement("Score")]
        public Int32 score;
    }
}