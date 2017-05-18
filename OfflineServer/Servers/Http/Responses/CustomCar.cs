using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OfflineServer.Servers.Http.Responses
{
    [Serializable()]
    [XmlRoot("CustomCar")]
    public class CustomCar
    {
        [XmlElement("BaseCar")]
        public Int64 baseCarId;
        [XmlElement("CarClassHash")]
        public Int64 carClassHash;
        [XmlElement("Id")]
        public Int64 id;
        [XmlElement("IsPreset")]
        public Boolean isPreset = false;
        [XmlElement("Level")]
        public Int32 level = 0;
        [XmlElement("Name")]
        public String name;
        [XmlArray("Paints")]
        [XmlArrayItem("CustomPaintTrans")]
        public List<CustomPaintTrans> paints;
        [XmlArray("PerformanceParts")]
        [XmlArrayItem("PerformancePartTrans")]
        public List<PerformancePartTrans> performanceParts;
        [XmlElement("PhysicsProfileHash")]
        public Int64 physicsProfileHash;
        [XmlElement("Rating")]
        public Int32 rating;
        [XmlElement("RideHeightDrop")]
        public float rideHeightDrop = 0;
        [XmlElement("ResalePrice")]
        public Int32 resalePrice;
        [XmlArray("SkillModParts")]
        [XmlArrayItem("SkillModPartTrans")]
        public List<SkillModPartTrans> skillModParts;
        [XmlElement("SkillModSlotCount")]
        public Int16 skillModSlotCount = 6;
        [XmlElement("Version")]
        public Int32 version = 0;
        [XmlArray("Vinyls")]
        [XmlArrayItem("CustomVinylTrans")]
        public List<CustomVinylTrans> vinyls;
        [XmlArray("VisualParts")]
        [XmlArrayItem("VisualPartTrans")]
        public List<VisualPartTrans> visualParts;
    }
}
