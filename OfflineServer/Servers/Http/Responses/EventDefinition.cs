using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("EventDefinition")]
    public class EventDefinition
    {
        [XmlElement("EventModeIcon")]
        public String eventModeIcon = "";
        [XmlElement("TrackLayoutMap")]
        public String trackLayoutMap = "";
        [XmlElement("CarClassHash")]
        public CarClass carClassHash;
        [XmlElement("Coins")]
        public Int32 coins;
        [XmlElement("EngagePoint")]
        public Vector3 engagePoint;
        [XmlElement("EventId")]
        public Int32 eventId;
        [XmlElement("EventLocalization")]
        public Int32 eventLocalization;
        [XmlElement("EventModeDescriptionLocalization")]
        public Int32 eventModeDescriptionLocalization;
        [XmlElement("EventModeId")]
        public Int32 eventModeId;
        [XmlElement("EventModeLocalization")]
        public Int32 eventModeLocalization;
        [XmlElement("IsEnabled")]
        public Boolean isEnabled;
        [XmlElement("IsLocked")]
        public Boolean isLocked;
        [XmlElement("Laps")]
        public Int32 laps;
        [XmlElement("Length")]
        public float length;
        [XmlElement("MaxClassRating")]
        public Int32 maxClassRating;
        [XmlElement("MaxEntrants")]
        public Int32 maxEntrants;
        [XmlElement("MaxLevel")]
        public Int32 maxLevel;
        [XmlElement("MinClassRating")]
        public Int32 minClassRating;
        [XmlElement("MinEntrants")]
        public Int32 minEntrants;
        [XmlElement("MinLevel")]
        public Int32 minLevel;
        [XmlElement("RegionLocalization")]
        public Int32 regionLocalization;
        [XmlElement("RewardModes", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<Int32> rewardModes;
        [XmlElement("TimeLimit")]
        public float timeLimit;
        [XmlElement("TrackLocalization")]
        public Int32 trackLocalization;
    }
}
