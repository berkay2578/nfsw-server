using OfflineServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace Garage
{
    public class Car : ObservableObject
    {
        public enum Class
        {
            E = 872416321,
            D = 415909161,
            C = 1866825865,
            B = -406473455,
            A = -405837480,
            S = -2142411446
        }

        private Int64 _BaseCar;
        private Class _RaceClass;
        private Int64 _ApiId;
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

        public Int64 BaseCar
        {
            get { return _BaseCar; }
            set
            {
                if (_BaseCar != value)
                {
                    _BaseCar = value;
                    RaisePropertyChangedEvent("BaseCar");
                }
            }
        }
        public Class RaceClass
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
        public Int64 ApiId
        {
            get { return _ApiId; }
            set
            {
                if (_ApiId != value)
                {
                    _ApiId = value;
                    RaisePropertyChangedEvent("ApiId");
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

        public Car(Int64 baseCar, Class raceClass, Int64 apiId, XElement paints, XElement performanceParts, Int64 physicsProfileHash, Int32 rating, Int32 resalePrice, XElement skillModParts, XElement vinyls, XElement visualParts, Int16 durability, DateTime expirationDate, Int16 heatLevel, Int32 id)
        {
            BaseCar = baseCar;
            RaceClass = raceClass;
            ApiId = apiId;
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

        public String GetCarMakeAndModel()
        {
            return "";
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
                        new XElement("BaseCar", BaseCar),
                        new XElement("CarClassHash", (Int32)RaceClass),
                        new XElement("Id", ApiId),
                        new XElement("Paints", Paints),
                        new XElement("PerformanceParts", PerformanceParts),
                        new XElement("PhysicsProfileHash", PhysicsProfileHash),
                        new XElement("ResalePrice", ResalePrice),
                        new XElement("SkillModParts", SkillModParts),
                        new XElement("SkillModSlotCount", 6),
                        new XElement("Vinyls", Vinyls),
                        new XElement("VisualParts", VisualParts),
                        new XElement("Durability", Durability),
                        new XElement("ExpirationDate", 
                            new XAttribute(ServerAttributes.nilNS + "nil", "true")
                        ), // ToString("o"))
                        new XElement("Heat", HeatLevel),
                        new XElement("Id", Id),
                        new XElement("OwnershipType", "CustomizedCar")
                    )
                );

            return eCarEntry;
        }
    }

    public class Cars : ObservableObject, IEnumerable<Car>
    {
        private SQLiteConnection dbConnection;
        private ObservableCollection<Car> _mCarsList = new ObservableCollection<Car>();
        public ObservableCollection<Car> mCarsList
        {
            get { return _mCarsList; }
            set
            {
                if (_mCarsList != value)
                {
                    _mCarsList = value;
                    RaisePropertyChangedEvent("mCarsList");
                }
            }
        }
        public Int32 Amount
        {
            get { return mCarsList.Count; }
        }

        public void Add(Car newCarEntry)
        {
            mCarsList.Add(newCarEntry);
        }

        public IEnumerator<Car> GetEnumerator()
        {
            foreach (Car CarEntry in mCarsList)
            {
                if (CarEntry != null)
                {
                    yield return CarEntry;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Cars(Int64 personaId)
        {
            dbConnection = new SQLiteConnection("Data Source=\"ServerData\\GarageData\\" + personaId.ToString() + ".db\";Version=3;");
            dbConnection.Open();
            string sql = "select * from garage order by Id asc";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime ValidTime = (String)reader[12] == "null" ? new DateTime(1,1,1) : DateTime.ParseExact((String)reader[12], "o", System.Globalization.CultureInfo.CurrentCulture);
                Car dummyCar = new Car((Int64)reader[0], (Car.Class)reader[1], (Int64)reader[2], XElement.Parse((String)reader[3]), XElement.Parse((String)reader[4]), (Int64)reader[5], (Int32)reader[6], (Int32)reader[7], XElement.Parse((String)reader[8]), XElement.Parse((String)reader[9]), XElement.Parse((String)reader[10]), (Int16)reader[11], ValidTime, (Int16)reader[13], (Int32)reader[14]);
                Add(dummyCar);
            }
        }

        public String GetCompleteGarage()
        {
            XElement CarEntries = new XElement("CarsOwnedByPersona");
            foreach (Car CarEntry in mCarsList)
            {
                CarEntries.Add(CarEntry.GetCarEntry());
            }

            XDocument docAllCars = new XDocument(
                new XDeclaration("1.0", Encoding.UTF8.HeaderName, String.Empty),
                new XElement("CarSlotInfoTrans",
                    new XAttribute(XNamespace.Xmlns + "i", ServerAttributes.nilNS),
                    CarEntries,
                    new XElement("DefaultOwnedCarIndex", "DebugNil"),
                    new XElement("ObtainableSlots",
                        Economy.Basket.GetProductTransactionEntry
                        (
                            Economy.Currency.Boost,
                            "Grants you 1 extra car slot.",
                            0,
                            -1143680669,
                            "128_cash",
                            0,
                            "Only for 100 boost you will get a car slot instantly!",
                            100,
                            0,
                            Economy.ServerItemType.CarSlot,
                            0,
                            "Car Slot",
                            Economy.GameItemType.CarSlot,
                            Economy.Special.None
                        )
                    ),
                    new XElement("OwnedCarSlotsCount", "DebugNil")
                )
            );
            docAllCars.Root.SetDefaultXmlNamespace(ServerAttributes.srlNS);
            return docAllCars.ToString();
        }
    }
}