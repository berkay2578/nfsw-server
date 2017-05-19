using OfflineServer.Servers;
using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.Http.Responses;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;

namespace OfflineServer
{
    [Serializable()]
    public sealed class CarClass
    {
        private static readonly Dictionary<Int64, String> carClasses = new Dictionary<Int64, String>()
        {
            {872416321, "E"},
            {415909161, "D"},
            {1866825865, "C"},
            {3888493841, "B"},
            {3889129816, "A"},
            {2152555850, "S"},
            {-3422550975, "E"},
            {-3879058135, "D"},
            {-2428141431, "C"},
            {-406473455, "B"},
            {-405837480, "A"},
            {-2142411446, "S"},
        };

        public static String getCarClassFromHash(Int64 carClassHash)
        {
            return carClasses[carClassHash];
        }

        public static Int64 getHashFromCarClass(String carClass)
        {
            return carClasses.First(c => c.Value == carClass).Key;
        }
    }

    public class Car : ObservableObject
    {
        private Int32 id;
        private Int64 baseCarId;
        private Int64 carClassHash;
        private String name;
        private XElement paints;
        private XElement performanceParts;
        private Int64 physicsProfileHash;
        private Int32 rating;
        private Int32 resalePrice;
        private XElement skillModParts;
        private XElement vinyls;
        private XElement visualParts;
        private Int16 durability;
        private String expirationDate;
        private float heatLevel;
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
        public Int64 CarClassHash
        {
            get { return carClassHash; }
            set
            {
                if (carClassHash != value)
                {
                    carClassHash = value;
                    CarManagement.car.carClassHash = value;
                    CarManagement.car.update();
                    RaisePropertyChangedEvent("CarClassHash");
                }
            }
        }
        public String CarClassForUI
        {
            get { return CarClass.getCarClassFromHash(carClassHash); }
            set
            {
                Int64 _carClassHash = CarClass.getHashFromCarClass(value);
                if (carClassHash != _carClassHash)
                {
                    CarClassHash = _carClassHash;
                    RaisePropertyChangedEvent("CarClassForUI");
                }
            }
        }
        public String Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    CarManagement.car.name = value;
                    CarManagement.car.update();
                    RaisePropertyChangedEvent("Name");
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
                    CarManagement.car.vinyls = value.ToString(SaveOptions.DisableFormatting);
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
                if (durability != value && value >= 0)
                {
                    durability = value;
                    CarManagement.car.durability = value;
                    RaisePropertyChangedEvent("Durability");
                }
            }
        }
        public String ExpirationDate
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
        public float HeatLevel
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
            carClassHash = car.carClassHash;
            name = car.name;
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
            personaId = car.ownerPersona.id;
        }

        public CustomCar getCustomCar()
        {
            return new CustomCar()
            {
                baseCarId = BaseCarId,
                carClassHash = CarClassHash,
                id = Id,
                name = Name,
                paints = Paints.ToString().DeserializeObject<List<CustomPaintTrans>>(),
                performanceParts = PerformanceParts.ToString().DeserializeObject<List<PerformancePartTrans>>(),
                physicsProfileHash = PhysicsProfileHash,
                resalePrice = ResalePrice,
                skillModParts = SkillModParts.ToString().DeserializeObject<List<SkillModPartTrans>>(),
                skillModSlotCount = 6,
                vinyls = Vinyls.ToString().DeserializeObject<List<CustomVinylTrans>>(),
                visualParts = VisualParts.ToString().DeserializeObject<List<VisualPartTrans>>()
            };
        }
        public OwnedCarTrans getOwnedCarTrans()
        {
            return new OwnedCarTrans()
            {
                customCar = getCustomCar(),
                durability = Durability,
                expirationDate = ExpirationDate,
                heatLevel = HeatLevel,
                id = Id,
                ownershipType = "CustomCar"
            };
        }
        public XElement getCarEntry()
        {
            XElement eCarEntry =
                new XElement("OwnedCarTrans",
                    XElement.Parse(getCustomCar().SerializeObject()),
                    new XElement("Durability", Durability),
                    new XElement("ExpirationDate", null),
                    new XElement("Heat", HeatLevel),
                    new XElement("Id", Id),
                    new XElement("OwnershipType", "CustomizedCar")
                );

            return eCarEntry;
        }
    }
}