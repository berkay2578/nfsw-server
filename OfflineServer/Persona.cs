using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Text;
using System.Xml.Linq;
using NHibernate;
using OfflineServer.Servers;
using OfflineServer.Servers.Database;
using OfflineServer.Servers.Database.Entities;

namespace OfflineServer
{
    /// <summary>
    /// Class containing all of the required variables and initializers to create and use a local Persona.
    /// </summary>
    public class Persona : ObservableObject
    {
        /// <summary>
        /// For future use.
        /// </summary>
        public enum PersonaType
        {
            Basic = 0,
            Detailed = 1,
            Debug = 2
        }

        private Int32 id;
        private Int16 iconIndex;
        private String name;
        private String motto;
        private Int32 level;
        private Int32 cash;
        private Int32 boost;
        private Int16 percentageOfLevelCompletion;
        private Int32 reputationInLevel;
        private Int32 reputationInTotal;
        private Int32 currentCarIndex;
        public Int32 score;
        public Int32 rating;
        private ObservableCollection<Car> cars = new ObservableCollection<Car>();

        //UI
        private Car selectedCar;

        public Int32 Id
        {
            get { return id; }
            set
            { 
                if (id != value) { 
                    id = value;
                    RaisePropertyChangedEvent("Id");
                }
            }
        }
        public Int16 IconIndex
        {
            get { return iconIndex; }
            set
            {
                if (iconIndex != value)
                {
                    iconIndex = (Int16)((value <= 0) ? 0 : (value >= 27) ? 27 : value);
                    RaisePropertyChangedEvent("IconIndex");
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
                    RaisePropertyChangedEvent("Name");
                }
            }
        }
        public String Motto
        {
            get { return motto; }
            set
            {
                if (motto != value)
                {
                    motto = value;
                    RaisePropertyChangedEvent("Motto");
                }
            }
        }
        public Int32 Level
        {
            get { return level; }
            set
            {
                if (level != value)
                {
                    level = value;
                    RaisePropertyChangedEvent("Level");
                }
            }
        }
        public Int32 Cash
        {
            get { return cash; }
            set
            {
                if (cash != value)
                {
                    cash = value;
                    RaisePropertyChangedEvent("Cash");
                    RaisePropertyChangedEvent("CashForView");
                }
            }
        }
        public String CashForView
        {
            get
            {
                return Cash == 0 ? "\r\n\r\n\r\n0." : Cash.ToString("#\r\n##,#\r\n###\r\n###") + ".";
            }
        }
        public Int32 Boost
        {
            get { return boost; }
            set
            {
                if (boost != value)
                {
                    boost = value;
                    RaisePropertyChangedEvent("Boost");
                    RaisePropertyChangedEvent("BoostForView");
                }
            }
        }
        public String BoostForView
        {
            get
            {
                return Boost == 0 ? "\r\n\r\n\r\n0." : Boost.ToString("#\r\n##,#\r\n###\r\n###") + ".";
            }
        }
        public Int16 PercentageOfLevelCompletion
        {
            get { return percentageOfLevelCompletion; }
            set
            {
                if (percentageOfLevelCompletion != value)
                {
                    percentageOfLevelCompletion = value;
                    RaisePropertyChangedEvent("PercentageOfLevelCompletion");
                }
            }
        }
        public Int32 ReputationInLevel
        {
            get { return reputationInLevel; }
            set
            {
                if (reputationInLevel != value)
                {
                    reputationInLevel = value;
                    RaisePropertyChangedEvent("ReputationInLevel");
                }
            }
        }
        public Int32 ReputationInTotal
        {
            get { return reputationInTotal; }
            set
            {
                if (reputationInTotal != value)
                {
                    reputationInTotal = value;
                    RaisePropertyChangedEvent("ReputationInTotal");
                }
            }
        }
        public Int32 CurrentCarIndex
        {
            get { return currentCarIndex; }
            set
            {
                if (currentCarIndex != value)
                {
                    currentCarIndex = value;
                    RaisePropertyChangedEvent("CurrentCarIndex");
                }
            }
        }
        public Car SelectedCar {
            get { return selectedCar; }
            set
            {
                if (selectedCar != value)
                {
                    selectedCar = value;
                    RaisePropertyChangedEvent("SelectedCar");
                }
            }
        }
        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set
            {
                if (cars != value)
                {
                    cars = value;
                    RaisePropertyChangedEvent("Cars");
                }
            }
        }

        /// <summary>
        /// Initializes the Persona class with the given parameter values.
        /// </summary>
        public Persona(Int32 personaId, Int16 personaAvatarIndex, String personaName, String personaMotto, Int32 personaLevel, Int32 personaCash, Int32 personaBoost, Int16 personaPercentageOfLevel, Int32 personaReputationLevel, Int32 personaReputationTotal, Int32 personaCarIndex)
        {
            Id = personaId;
            IconIndex = personaAvatarIndex;
            Name = personaName;
            Motto = personaMotto;
            Level = personaLevel;
            Cash = personaCash;
            Boost = personaBoost;
            PercentageOfLevelCompletion = personaPercentageOfLevel;
            ReputationInLevel = personaReputationLevel;
            ReputationInTotal = personaReputationTotal;
            CurrentCarIndex = personaCarIndex;
            
            SQLiteCommand command = new SQLiteCommand("select * from garage where ownerpersona_Id = " + Id + " order by id asc", NfswSession.dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime ValidTime = String.IsNullOrWhiteSpace((string)reader[12]) ? new DateTime(1, 1, 1) : DateTime.ParseExact((String)reader[12], "o", System.Globalization.CultureInfo.CurrentCulture);
                /*
                long a = (Int64)reader[0];
                long b = (Int64)reader[1];
                CarClass c = (CarClass)reader[2];
                XElement d = XElement.Parse((String)reader[3]);
                XElement e = XElement.Parse((String)reader[4]);
                long f = (Int64)reader[5];
                int g = (Int32)reader[6];
                int h = (Int32)reader[7];
                XElement j = XElement.Parse((String)reader[8]);
                XElement k = XElement.Parse((String)reader[9]);
                XElement l = XElement.Parse((String)reader[10]);
                short m = (Int16)reader[11];
                DateTime n = ValidTime;
                short o = (Int16)reader[13];
                long p = (Int64)reader[14];
                long q = (Int64)reader[15];*/

                Car dummyCar = new Car((Int32)reader[0], (Int64)reader[1], (CarClass)reader[2], XElement.Parse((String)reader[3]), XElement.Parse((String)reader[4]), (Int64)reader[5], (Int32)reader[6], (Int32)reader[7], XElement.Parse((String)reader[8]), XElement.Parse((String)reader[9]), XElement.Parse((String)reader[10]), (Int16)reader[11], ValidTime, (Int16)reader[13], (Int64)reader[14], (Int32)reader[15]);
                Cars.Add(dummyCar);
            }
        }

        /// <summary>
        /// Initializes the Persona class with the given persona entity.
        /// </summary>
        public Persona(PersonaEntity persona)
        {
            Id = persona.id;
            IconIndex = persona.iconIndex;
            Name = persona.name;
            Motto = persona.motto;
            Level = persona.level;
            Cash = persona.cash;
            Boost = persona.boost;
            PercentageOfLevelCompletion = persona.percentageOfLevelCompletion;
            ReputationInLevel = persona.reputationInLevel;
            ReputationInTotal = persona.reputationInTotal;
            CurrentCarIndex = persona.currentCarIndex;

            foreach (CarEntity car in persona.garage)
            {
                Cars.Add(new Car(car));
            }
        }

        /// <summary>
        /// Converts the Persona to its multilined string equivalent.
        /// </summary>
        public override String ToString()
        {
            string sPersonaData = "Persona Information: {" + Environment.NewLine +
                "   Id: " + Id.ToString() + Environment.NewLine +
                "   Avatar Index: " + IconIndex.ToString() + Environment.NewLine +
                "   Name: " + Name + Environment.NewLine +
                "   Motto: " + Motto + Environment.NewLine +
                "   Level: " + Level.ToString() + Environment.NewLine +
                "   Cash: " + Cash.ToString() + Environment.NewLine +
                "   Boost: " + Boost.ToString() + Environment.NewLine +
                "}";
            return sPersonaData;
        }

        /// <summary>
        /// Reads the registered personas from a fixed-string database file.
        /// </summary>
        /// <remarks>This is NOT dynamic, this only reads from the database.</remarks>
        /// <returns>An initialized "List<Persona>" containing the database entries for the personas.</returns>
        public static ObservableCollection<Persona> getCurrentPersonaList()
        {
            ObservableCollection<Persona> listPersona = new ObservableCollection<Persona>();
            var sessionFactory = SessionManager.getSessionFactory();
            using (var session = sessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    IList<PersonaEntity> personas = session.CreateCriteria(typeof(PersonaEntity)).List<PersonaEntity>();

                    foreach (PersonaEntity persona in personas)
                    {
                        listPersona.Add(new Persona(persona));
                    }
                }
            }

            return listPersona;
        }

        /// <summary>
        /// Reads the complete garage of the current active persona.
        /// </summary>
        /// <returns>A string instance containing all of the persona's cars in indented XML.</returns>
        public String getCompleteGarage()
        {
            XElement CarEntries = new XElement("CarsOwnedByPersona");
            foreach (Car CarEntry in Cars)
            {
                CarEntries.Add(CarEntry.getCarEntry());
            }

            XDocument docAllCars = new XDocument(
                new XDeclaration("1.0", Encoding.UTF8.HeaderName, String.Empty),
                new XElement("CarSlotInfoTrans",
                    new XAttribute(XNamespace.Xmlns + "i", ServerAttributes.nilNS),
                    CarEntries,
                    new XElement("DefaultOwnedCarIndex", currentCarIndex),
                    new XElement("ObtainableSlots",
                        Economy.Basket.GetProductTransactionEntry
                        (
                            Economy.Currency.Boost,
                            "Grants you 1 extra car slot.",
                            0,
                            -1143680669,
                            "128_cash",
                            0,
                            "Only for 100 boost you will get new a car slot instantly!",
                            100,
                            0,
                            Economy.ServerItemType.CarSlot,
                            0,
                            "Car Slot",
                            Economy.GameItemType.CarSlot,
                            Economy.Special.None
                        )
                    ),
                    new XElement("OwnedCarSlotsCount", "100")
                )
            );
            docAllCars.Root.SetDefaultXmlNamespace(ServerAttributes.srlNS);
            return docAllCars.ToString();
        }
    }
}