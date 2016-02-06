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
        private Int64 _BaseCarId;
        private CarClass _RaceClass;
        private Int64 _ApId;
        private XElement _Paints;
        private XElement _PerformanceParts;
        private Int64 _PhysicsProfileHash;
        private Int32 _Rating;
        private Int32 _ResalePrice;
        private XElement _SkillModParts;
        private XElement _Vinyls;
        private XElement _VisualParts;
        private Int16 _Durability;
        private DateTime _ExpirationDate;
        private Int16 _HeatLevel;
        private Int32 _Id;
        public String MakeModel { get { return CarDefinitions.Define(PhysicsProfileHash); } }

        public Int64 BaseCarId
        {
            get { return _BaseCarId; }
            set
            {
                if (_BaseCarId != value)
                {
                    _BaseCarId = value;
                    RaisePropertyChangedEvent("BaseCarId");
                }
            }
        }
        public CarClass RaceClass
        {
            get { return _RaceClass; }
            set
            {
                if (_RaceClass != value)
                {
                    _RaceClass = value;
                    RaisePropertyChangedEvent("RaceClass");
                }
            }
        }
        public Int64 ApId
        {
            get { return _ApId; }
            set
            {
                if (_ApId != value)
                {
                    _ApId = value;
                    RaisePropertyChangedEvent("ApId");
                }
            }
        }
        public XElement Paints
        {
            get { return _Paints; }
            set
            {
                if (_Paints != value)
                {
                    _Paints = value;
                    RaisePropertyChangedEvent("Paints");
                }
            }
        }
        public XElement PerformanceParts
        {
            get { return _PerformanceParts; }
            set
            {
                if (_PerformanceParts != value)
                {
                    _PerformanceParts = value;
                    RaisePropertyChangedEvent("PerformanceParts");
                }
            }
        }
        public Int64 PhysicsProfileHash
        {
            get { return _PhysicsProfileHash; }
            set
            {
                if (_PhysicsProfileHash != value)
                {
                    _PhysicsProfileHash = value;
                    RaisePropertyChangedEvent("PhysicsProfileHash");
                    RaisePropertyChangedEvent("MakeModel");
                }
            }
        }
        public Int32 Rating
        {
            get { return _Rating; }
            set
            {
                if (_Rating != value)
                {
                    _Rating = value;
                    RaisePropertyChangedEvent("Rating");
                }
            }
        }
        public Int32 ResalePrice
        {
            get { return _ResalePrice; }
            set
            {
                if (_ResalePrice != value)
                {
                    _ResalePrice = value;
                    RaisePropertyChangedEvent("ResalePrice");
                }
            }
        }
        public XElement SkillModParts
        {
            get { return _SkillModParts; }
            set
            {
                if (_SkillModParts != value)
                {
                    _SkillModParts = value;
                    RaisePropertyChangedEvent("SkillModParts");
                }
            }
        }
        public XElement Vinyls
        {
            get { return _Vinyls; }
            set
            {
                if (_Vinyls != value)
                {
                    _Vinyls = value;
                    RaisePropertyChangedEvent("Vinyls");
                }
            }
        }
        public XElement VisualParts
        {
            get { return _VisualParts; }
            set
            {
                if (_VisualParts != value)
                {
                    _VisualParts = value;
                    RaisePropertyChangedEvent("VisualParts");
                }
            }
        }
        public Int16 Durability
        {
            get { return _Durability; }
            set
            {
                if (_Durability != value)
                {
                    _Durability = value;
                    RaisePropertyChangedEvent("Durability");
                }
            }
        }
        public DateTime ExpirationDate
        {
            get { return _ExpirationDate; }
            set
            {
                if (_ExpirationDate != value)
                {
                    _ExpirationDate = value;
                    RaisePropertyChangedEvent("ExpirationDate");
                }
            }
        }
        public Int16 HeatLevel
        {
            get { return _HeatLevel; }
            set
            {
                if (_HeatLevel != value)
                {
                    _HeatLevel = value;
                    RaisePropertyChangedEvent("HeatLevel");
                }
            }
        }
        public Int32 Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChangedEvent("Id");
                }
            }
        }

        public Car(Int64 baseCarId, CarClass raceClass, Int64 apId, XElement paints, XElement performanceParts, Int64 physicsProfileHash, Int32 rating, Int32 resalePrice, XElement skillModParts, XElement vinyls, XElement visualParts, Int16 durability, DateTime expirationDate, Int16 heatLevel, Int32 id)
        {
            BaseCarId = baseCarId;
            RaceClass = raceClass;
            ApId = apId;
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
            Id = id;
        }
        
        public String GetCarPreset()
        {
            return "";
        }
        public XElement GetCarEntry()
        {
            XElement eCarEntry =
                new XElement("OwnedCarTrans",
                    new XElement("CustomCar",
                        new XElement("BaseCar", BaseCarId),
                        new XElement("CarClassHash", (Int32)RaceClass),
                        new XElement("Id", ApId),
                        new XElement("Paints", Paints),
                        new XElement("PerformanceParts", PerformanceParts),
                        new XElement("PhysicsProfileHash", PhysicsProfileHash),
                        new XElement("ResalePrice", ResalePrice),
                        new XElement("SkillModParts", SkillModParts),
                        new XElement("SkillModSlotCount", 6),
                        new XElement("Vinyls", Vinyls),
                        new XElement("VisualParts", VisualParts),
                        new XElement("Durability", Durability),
                        (ExpirationDate == new DateTime(1, 1, 1) ?
                            new XElement("ExpirationDate", new XAttribute(ServerAttributes.nilNS + "nil", "true")) :
                            new XElement("ExpirationDate", ExpirationDate.ToString("o"))
                        ),
                        new XElement("Heat", HeatLevel),
                        new XElement("Id", Id),
                        new XElement("OwnershipType", "CustomizedCar")
                    )
                );

            return eCarEntry;
        }
    }
}