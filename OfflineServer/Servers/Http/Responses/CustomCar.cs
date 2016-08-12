using OfflineServer.Servers.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Int64 carId;
        [XmlElement("Paints")]
        public String paints;
        [XmlElement("PerformanceParts")]
        public String performanceParts;
        [XmlElement("PhysicsProfileHash")]
        public Int64 physicsProfileHash;
        [XmlElement("Rating")]
        public Int32 rating;
        [XmlElement("ResalePrice")]
        public Int32 resalePrice;
        [XmlElement("SkillModParts")]
        public String skillModParts;
        [XmlElement("SkillModSlotCount")]
        public Int16 skillModSlotCount;
        [XmlElement("Vinyls")]
        public String vinyls;
        [XmlElement("VisualParts")]
        public String visualParts;

        public static CustomCar getCustomCar(CarEntity carEntity)
        {
            CustomCar customCar = new CustomCar();
            customCar.baseCarId = carEntity.baseCarId;
            customCar.carClassHash = (Int32)carEntity.raceClass;
            customCar.carId = carEntity.carId;
            customCar.isPreset = false;
            customCar.level = 0;
            customCar.name = null;
            customCar.paints = carEntity.paints;
            customCar.performanceParts = carEntity.performanceParts;
            customCar.physicsProfileHash = carEntity.physicsProfileHash;
            customCar.rating = carEntity.rating;
            customCar.resalePrice = carEntity.resalePrice;
            customCar.skillModParts = carEntity.skillModParts;
            customCar.skillModSlotCount = 6;
            customCar.vinyls = carEntity.vinyls;
            customCar.visualParts = carEntity.visualParts;

            return customCar;
        }
    }
}
