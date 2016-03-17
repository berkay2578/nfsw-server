using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Text;
using System.Xml.Linq;

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

        private Int64 _Id;
        private Int16 _AvatarIndex;
        private String _Name;
        private String _Motto;
        private Int16 _Level;
        private Int32 _Cash;
        private Int32 _Boost;
        private Int16 _PercentageOfLevelCompletion;
        private Int32 _ReputationInLevel;
        private Int32 _ReputationInTotal;
        private Int32 _CarIndex;
        private Car _SelectedCar;
        private ObservableCollection<Car> _Cars = new ObservableCollection<Car>();

        public Int64 Id
        {
            get { return _Id; }
            set
            { 
                if (_Id != value) { 
                    _Id = value;
                    RaisePropertyChangedEvent("Id");
                }
            }
        }
        public Int16 AvatarIndex
        {
            get { return _AvatarIndex; }
            set
            {
                if (_AvatarIndex != value)
                {
                    _AvatarIndex = (Int16)((value <= 0) ? 0 : (value >= 27) ? 27 : value);
                    RaisePropertyChangedEvent("AvatarIndex");
                }
            }
        }
        public String Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChangedEvent("Name");
                }
            }
        }
        public String Motto
        {
            get { return _Motto; }
            set
            {
                if (_Motto != value)
                {
                    _Motto = value;
                    RaisePropertyChangedEvent("Motto");
                }
            }
        }
        public Int16 Level
        {
            get { return _Level; }
            set
            {
                if (_Level != value)
                {
                    _Level = value;
                    RaisePropertyChangedEvent("Level");
                }
            }
        }
        public Int32 Cash
        {
            get { return _Cash; }
            set
            {
                if (_Cash != value)
                {
                    _Cash = value;
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
            get { return _Boost; }
            set
            {
                if (_Boost != value)
                {
                    _Boost = value;
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
            get { return _PercentageOfLevelCompletion; }
            set
            {
                if (_PercentageOfLevelCompletion != value)
                {
                    _PercentageOfLevelCompletion = value;
                    RaisePropertyChangedEvent("PercentageOfLevelCompletion");
                }
            }
        }
        public Int32 ReputationInLevel
        {
            get { return _ReputationInLevel; }
            set
            {
                if (_ReputationInLevel != value)
                {
                    _ReputationInLevel = value;
                    RaisePropertyChangedEvent("ReputationInLevel");
                }
            }
        }
        public Int32 ReputationInTotal
        {
            get { return _ReputationInTotal; }
            set
            {
                if (_ReputationInTotal != value)
                {
                    _ReputationInTotal = value;
                    RaisePropertyChangedEvent("ReputationInTotal");
                }
            }
        }
        public Int32 CarIndex
        {
            get { return _CarIndex; }
            set
            {
                if (_CarIndex != value)
                {
                    _CarIndex = value;
                    RaisePropertyChangedEvent("CarIndex");
                }
            }
        }
        public Car SelectedCar {
            get { return _SelectedCar; }
            set
            {
                if (_SelectedCar != value)
                {
                    _SelectedCar = value;
                    RaisePropertyChangedEvent("SelectedCar");
                }
            }
        }
        public ObservableCollection<Car> Cars
        {
            get { return _Cars; }
            set
            {
                if (_Cars != value)
                {
                    _Cars = value;
                    RaisePropertyChangedEvent("Cars");
                }
            }
        }

        /// <summary>
        /// Initializes the Persona class with the given parameter values.
        /// </summary>
        public Persona(Int64 personaId, Int16 personaAvatarIndex, String personaName, String personaMotto, Int16 personaLevel, Int32 personaCash, Int32 personaBoost, Int16 personaPercentageOfLevel, Int32 personaReputationLevel, Int32 personaReputationTotal, Int32 personaCarIndex)
        {
            Id = personaId;
            AvatarIndex = personaAvatarIndex;
            Name = personaName;
            Motto = personaMotto;
            Level = personaLevel;
            Cash = personaCash;
            Boost = personaBoost;
            PercentageOfLevelCompletion = personaPercentageOfLevel;
            ReputationInLevel = personaReputationLevel;
            ReputationInTotal = personaReputationTotal;
            CarIndex = personaCarIndex;
            
            SQLiteCommand command = new SQLiteCommand("select * from Id" + personaId.ToString() + " order by ApId asc", NfswSession.dbCarsConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime ValidTime = (String)reader[12] == "null" ? new DateTime(1, 1, 1) : DateTime.ParseExact((String)reader[12], "o", System.Globalization.CultureInfo.CurrentCulture);
                Car dummyCar = new Car((Int64)reader[0], (CarClass)reader[1], (Int64)reader[2], XElement.Parse((String)reader[3]), XElement.Parse((String)reader[4]), (Int64)reader[5], (Int32)reader[6], (Int32)reader[7], XElement.Parse((String)reader[8]), XElement.Parse((String)reader[9]), XElement.Parse((String)reader[10]), (Int16)reader[11], ValidTime, (Int16)reader[13], (Int32)reader[14]);
                Cars.Add(dummyCar);
            }
        }

        /// <summary>
        /// Initializes the Persona class with the given persona.
        /// </summary>
        public Persona(Persona persona)
        {
            Id = persona.Id;
            AvatarIndex = persona.AvatarIndex;
            Name = persona.Name;
            Motto = persona.Motto;
            Level = persona.Level;
            Cash = persona.Cash;
            Boost = persona.Boost;
            PercentageOfLevelCompletion = persona.PercentageOfLevelCompletion;
            ReputationInLevel = persona.ReputationInLevel;
            ReputationInTotal = persona.ReputationInTotal;
            CarIndex = persona.CarIndex;

            SQLiteCommand command = new SQLiteCommand("select * from Id" + persona.Id.ToString() + " order by ApId asc", NfswSession.dbCarsConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DateTime ValidTime = (String)reader[12] == "null" ? new DateTime(1, 1, 1) : DateTime.ParseExact((String)reader[12], "o", System.Globalization.CultureInfo.CurrentCulture);
                Car dummyCar = new Car((Int64)reader[0], (CarClass)reader[1], (Int64)reader[2], XElement.Parse((String)reader[3]), XElement.Parse((String)reader[4]), (Int64)reader[5], (Int32)reader[6], (Int32)reader[7], XElement.Parse((String)reader[8]), XElement.Parse((String)reader[9]), XElement.Parse((String)reader[10]), (Int16)reader[11], ValidTime, (Int16)reader[13], (Int32)reader[14]);
                Cars.Add(dummyCar);
            }
        }

        /// <summary>
        /// Converts the Persona to its multilined string equivalent.
        /// </summary>
        public override String ToString()
        {
            string sPersonaData = "Persona Information: {" + Environment.NewLine +
                "   Id: " + Id.ToString() + Environment.NewLine +
                "   Avatar Index: " + AvatarIndex.ToString() + Environment.NewLine +
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
        public static ObservableCollection<Persona> GetCurrentPersonaList()
        {
            ObservableCollection<Persona> listPersona = new ObservableCollection<Persona>();
            
            SQLiteCommand command = new SQLiteCommand("select * from personas order by Id asc", NfswSession.dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Persona dummyPersona = new Persona((Int64)reader[0], (Int16)reader[1], (String)reader[2], (String)reader[3], (Int16)reader[4], (Int32)reader[5], (Int32)reader[6], (Int16)reader[7], (Int32)reader[8], (Int32)reader[9], (Int32)reader[10]);
                listPersona.Add(dummyPersona);
            }

            return listPersona;
        }

        /// <summary>
        /// Reads the complete garage of the current active persona.
        /// </summary>
        /// <returns>A string instance containing all of the persona's cars in indented XML.</returns>
        public String GetCompleteGarage()
        {
            XElement CarEntries = new XElement("CarsOwnedByPersona");
            foreach (Car CarEntry in Cars)
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
                    new XElement("OwnedCarSlotsCount", "DebugNil")
                )
            );
            docAllCars.Root.SetDefaultXmlNamespace(ServerAttributes.srlNS);
            return docAllCars.ToString();
        }
    }
}