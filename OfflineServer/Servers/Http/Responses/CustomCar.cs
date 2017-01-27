using OfflineServer.Servers.Database.Entities;
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
        public Int32 carClassHash;
        [XmlElement("IsPreset")]
        public Boolean isPreset;
        [XmlElement("Level")]
        public Int32 level;
        [XmlElement("Name")]
        public String name;
        [XmlElement("Id")]
        public Int64 id;
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
        [XmlElement("ResalePrice")]
        public Int32 resalePrice;
        [XmlArray("SkillModParts")]
        [XmlArrayItem("SkillModPartTrans")]
        public List<SkillModPartTrans> skillModParts;
        [XmlElement("SkillModSlotCount")]
        public Int16 skillModSlotCount;
        [XmlArray("Vinyls")]
        [XmlArrayItem("CustomVinylTrans")]
        public List<CustomVinylTrans> vinyls;
        [XmlArray("VisualParts")]
        [XmlArrayItem("VisualPartTrans")]
        public List<VisualPartTrans> visualParts;

        public static CustomCar getCustomCar(CarEntity carEntity)
        {
            CustomCar customCar = new CustomCar();
            customCar.baseCarId = carEntity.baseCarId;
            customCar.carClassHash = (Int32)carEntity.raceClass;
            customCar.id = carEntity.id;
            customCar.isPreset = false;
            customCar.level = 0;
            customCar.name = null;
            customCar.paints = carEntity.paints.DeserializeObject<List<CustomPaintTrans>>();
            customCar.performanceParts = carEntity.performanceParts.DeserializeObject<List<PerformancePartTrans>>();
            customCar.physicsProfileHash = carEntity.physicsProfileHash;
            customCar.rating = carEntity.rating;
            customCar.resalePrice = carEntity.resalePrice;
            customCar.skillModParts = carEntity.skillModParts.DeserializeObject<List<SkillModPartTrans>>();
            customCar.skillModSlotCount = 6;
            customCar.vinyls = carEntity.vinyls.DeserializeObject<List<CustomVinylTrans>>();
            customCar.visualParts = carEntity.visualParts.DeserializeObject<List<VisualPartTrans>>();

            return customCar;
        }
    }
}
