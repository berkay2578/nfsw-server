using OfflineServer.Servers;
using OfflineServer.Servers.Database.Entities;
using System;
using System.Xml.Linq;

namespace OfflineServer
{
    public enum CarClass
    {
        E = 872416321,
        D = 415909161,
        C = 1866825865,
        B = -406473455,
        A = -405837480,
        S = -2142411446
    }

    public class Car : ObservableObject
    {
        private Int32 id;
        private Int64 baseCarId;
        private CarClass raceClass;
        private XElement paints;
        private XElement performanceParts;
        private Int64 physicsProfileHash;
        private Int32 rating;
        private Int32 resalePrice;
        private XElement skillModParts;
        private XElement vinyls;
        private XElement visualParts;
        private Int16 durability;
        private DateTime expirationDate;
        private Int16 heatLevel;
        private Int64 carId;
        private Int32 personaId;
        public String MakeModel { get { return CarDefinitions.Define(PhysicsProfileHash); } }
        public String MakeModelDetailed { get { return CarDefinitions.DefineFromBaseCarId(BaseCarId); } }


        public Int32 Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChangedEvent("Id");
                }
            }
        }
        public Int64 BaseCarId
        {
            get { return baseCarId; }
            set
            {
                if (baseCarId != value)
                {
                    baseCarId = value;
                    RaisePropertyChangedEvent("BaseCarId");
                }
            }
        }
        public CarClass RaceClass
        {
            get { return raceClass; }
            set
            {
                if (raceClass != value)
                {
                    raceClass = value;
                    RaisePropertyChangedEvent("RaceClass");
                }
            }
        }
        public XElement Paints
        {
            get { return paints; }
            set
            {
                if (paints != value)
                {
                    paints = value;
                    RaisePropertyChangedEvent("Paints");
                }
            }
        }
        public XElement PerformanceParts
        {
            get { return performanceParts; }
            set
            {
                if (performanceParts != value)
                {
                    performanceParts = value;
                    RaisePropertyChangedEvent("PerformanceParts");
                }
            }
        }
        public Int64 PhysicsProfileHash
        {
            get { return physicsProfileHash; }
            set
            {
                if (physicsProfileHash != value)
                {
                    physicsProfileHash = value;
                    RaisePropertyChangedEvent("PhysicsProfileHash");
                    RaisePropertyChangedEvent("MakeModel");
                }
            }
        }
        public Int32 Rating
        {
            get { return rating; }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    RaisePropertyChangedEvent("Rating");
                }
            }
        }
        public Int32 ResalePrice
        {
            get { return resalePrice; }
            set
            {
                if (resalePrice != value)
                {
                    resalePrice = value;
                    RaisePropertyChangedEvent("ResalePrice");
                }
            }
        }
        public XElement SkillModParts
        {
            get { return skillModParts; }
            set
            {
                if (skillModParts != value)
                {
                    skillModParts = value;
                    RaisePropertyChangedEvent("SkillModParts");
                }
            }
        }
        public XElement Vinyls
        {
            get { return vinyls; }
            set
            {
                if (vinyls != value)
                {
                    vinyls = value;
                    RaisePropertyChangedEvent("Vinyls");
                }
            }
        }
        public XElement VisualParts
        {
            get { return visualParts; }
            set
            {
                if (visualParts != value)
                {
                    visualParts = value;
                    RaisePropertyChangedEvent("VisualParts");
                }
            }
        }
        public Int16 Durability
        {
            get { return durability; }
            set
            {
                if (durability != value)
                {
                    durability = value;
                    RaisePropertyChangedEvent("Durability");
                }
            }
        }
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set
            {
                if (expirationDate != value)
                {
                    expirationDate = value;
                    RaisePropertyChangedEvent("ExpirationDate");
                }
            }
        }
        public Int16 HeatLevel
        {
            get { return heatLevel; }
            set
            {
                if (heatLevel != value)
                {
                    heatLevel = value;
                    RaisePropertyChangedEvent("HeatLevel");
                }
            }
        }
        public Int64 CarId
        {
            get { return carId; }
            set
            {
                if (carId != value)
                {
                    carId = value;
                    RaisePropertyChangedEvent("CarId");
                }
            }
        }
        public Int32 PersonaId
        {
            get { return personaId; }
            set
            {
                if (personaId != value)
                {
                    personaId = value;
                    RaisePropertyChangedEvent("PersonaId");
                }
            }
        }

        public Car(Int32 id, Int64 baseCarId, CarClass raceClass, XElement paints, XElement performanceParts, Int64 physicsProfileHash, Int32 rating, Int32 resalePrice, XElement skillModParts, XElement vinyls, XElement visualParts, Int16 durability, DateTime expirationDate, Int16 heatLevel, Int64 carId, Int32 personaId)
        {
            Id = id;
            BaseCarId = baseCarId;
            RaceClass = raceClass;
            Paints = paints;
            PerformanceParts = performanceParts;
            PhysicsProfileHash = physicsProfileHash;
            Rating = rating;
            ResalePrice = resalePrice;
            SkillModParts = skillModParts;
            Vinyls = vinyls;
            VisualParts = visualParts;
            Durability = durability;
            ExpirationDate = expirationDate;
            HeatLevel = heatLevel;
            CarId = carId;
            PersonaId = personaId;
        }

        public Car(CarEntity car)
        {
            Id = car.id;
            BaseCarId = car.baseCarId;
            RaceClass = car.raceClass;
            Paints = XElement.Parse(car.paints);
            PerformanceParts = XElement.Parse(car.performanceParts);
            PhysicsProfileHash = car.physicsProfileHash;
            Rating = car.rating;
            ResalePrice = car.resalePrice;
            SkillModParts = XElement.Parse(car.skillModParts);
            Vinyls = XElement.Parse(car.vinyls);
            VisualParts = XElement.Parse(car.visualParts);
            Durability = car.durability;
            ExpirationDate = car.expirationDate;
            HeatLevel = car.heatLevel;
            CarId = car.carId;
            PersonaId = car.ownerPersona.id;
        }
        
        public String getCarPreset()
        {
            return "";
        }
        public XElement getCarEntry()
        {
            XElement eCarEntry =
                new XElement("OwnedCarTrans",
                    new XElement("CustomCar",
                        new XElement("BaseCar", BaseCarId),
                        new XElement("CarClassHash", (Int32)RaceClass),
                        new XElement("Id", Id),
                        Paints,
                        PerformanceParts,
                        new XElement("PhysicsProfileHash", PhysicsProfileHash),
                        new XElement("ResalePrice", ResalePrice),
                        SkillModParts,
                        new XElement("SkillModSlotCount", 6),
                        Vinyls,
                        VisualParts
                    ),
                    new XElement("Durability", Durability),
                    (ExpirationDate == new DateTime(1, 1, 1) ?
                        new XElement("ExpirationDate", new XAttribute(ServerAttributes.nilNS + "nil", "true")) :
                        new XElement("ExpirationDate", ExpirationDate.ToString("o"))
                    ),
                    new XElement("Heat", HeatLevel),
                    new XElement("Id", CarId),
                    new XElement("OwnershipType", "CustomizedCar")
                );

            return eCarEntry;
        }
    }
}