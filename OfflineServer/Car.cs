using OfflineServer.Servers;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.Http.Responses;
using System;
using System.Collections.Generic;
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
        public String MakeModel { get { return CarDefinitions.defineFromPhysicsProfileHash(PhysicsProfileHash, true); } }
        public String MakeModelDetailed { get { return CarDefinitions.defineFromBaseCarId(BaseCarId); } }


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
                    CarManagement.car.baseCarId = value;
                    CarManagement.car.update();
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
                    CarManagement.car.raceClass = value;
                    CarManagement.car.update();
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
                    CarManagement.car.paints = value.ToString(SaveOptions.DisableFormatting);
                    CarManagement.car.update();
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
                    CarManagement.car.performanceParts = value.ToString(SaveOptions.DisableFormatting);
                    CarManagement.car.update();
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
                    CarManagement.car.physicsProfileHash = value;
                    CarManagement.car.update();
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
                    CarManagement.car.rating = value;
                    CarManagement.car.update();
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
                    resalePrice = Math.Min(value, Int32.MaxValue - 1);
                    CarManagement.car.resalePrice = resalePrice;
                    CarManagement.car.update();
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
                    CarManagement.car.skillModParts = value.ToString(SaveOptions.DisableFormatting);
                    CarManagement.car.update();
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
                    CarManagement.car.skillModParts = value.ToString(SaveOptions.DisableFormatting);
                    CarManagement.car.update();
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
                    CarManagement.car.visualParts = value.ToString(SaveOptions.DisableFormatting);
                    CarManagement.car.update();
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
                    CarManagement.car.durability = value;
                    CarManagement.car.update();
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
                    CarManagement.car.expirationDate = value;
                    CarManagement.car.update();
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
                    CarManagement.car.heatLevel = value;
                    CarManagement.car.update();
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

        public Car() { }

        public Car(CarEntity car)
        {
            id = car.id;
            baseCarId = car.baseCarId;
            raceClass = car.raceClass;
            paints = XElement.Parse(car.paints);
            performanceParts = XElement.Parse(car.performanceParts);
            physicsProfileHash = car.physicsProfileHash;
            rating = car.rating;
            resalePrice = car.resalePrice;
            skillModParts = XElement.Parse(car.skillModParts);
            vinyls = XElement.Parse(car.vinyls);
            visualParts = XElement.Parse(car.visualParts);
            durability = car.durability;
            expirationDate = car.expirationDate;
            heatLevel = car.heatLevel;
            carId = car.carId;
            personaId = car.ownerPersona.id;
        }

        public String getCarPreset()
        {
            return "";
        }
        public XElement getCarEntry()
        {
            XElement eCarEntry =
                new XElement("OwnedCarTrans",
                    XElement.Parse(
                        new CustomCar()
                        {
                            baseCarId = BaseCarId,
                            carClassHash = (Int32)RaceClass,
                            id = Id,
                            paints = Paints.ToString().DeserializeObject<List<CustomPaintTrans>>(),
                            performanceParts = PerformanceParts.ToString().DeserializeObject<List<PerformancePartTrans>>(),
                            physicsProfileHash = PhysicsProfileHash,
                            resalePrice = ResalePrice,
                            skillModParts = SkillModParts.ToString().DeserializeObject<List<SkillModPartTrans>>(),
                            skillModSlotCount = 6,
                            vinyls = Vinyls.ToString().DeserializeObject<List<CustomVinylTrans>>(),
                            visualParts = VisualParts.ToString().DeserializeObject<List<VisualPartTrans>>()
                        }.SerializeObject()
                    ),
                    new XElement("Durability", Durability),
                    (ExpirationDate == new DateTime(1, 1, 1) ?
                        new XElement("ExpirationDate", null) :
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