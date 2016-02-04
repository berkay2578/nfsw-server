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

        private Int64 _iId;
        public Int64 iId
        {
            get { return _iId; }
            set
            { 
                if (_iId != value) { 
                    _iId = value;
                    RaisePropertyChangedEvent("iId");
                }
            }
        }

        private Int16 _shAvatarIndex;
        public Int16 shAvatarIndex
        {
            get { return _shAvatarIndex; }
            set
            {
                if (_shAvatarIndex != value)
                {
                    _shAvatarIndex = (Int16)((value <= 0) ? 0 : (value >= 27) ? 27 : value);
                    RaisePropertyChangedEvent("shAvatarIndex");
                }
            }
        }

        private String _sName;
        public String sName
        {
            get { return _sName; }
            set
            {
                if (_sName != value)
                {
                    _sName = value;
                    RaisePropertyChangedEvent("sName");
                }
            }
        }

        private String _sMotto;
        public String sMotto
        {
            get { return _sMotto; }
            set
            {
                if (_sMotto != value)
                {
                    _sMotto = value;
                    RaisePropertyChangedEvent("sMotto");
                }
            }
        }

        private Int16 _shLevel;
        public Int16 shLevel
        {
            get { return _shLevel; }
            set
            {
                if (_shLevel != value)
                {
                    _shLevel = value;
                    RaisePropertyChangedEvent("shLevel");
                }
            }
        }

        private Int32 _iCash;
        public Int32 iCash
        {
            get { return _iCash; }
            set
            {
                if (_iCash != value)
                {
                    _iCash = value;
                    RaisePropertyChangedEvent("iCash");
                    RaisePropertyChangedEvent("iCashForView");
                }
            }
        }
        public String iCashForView
        {
            get
            {
                return iCash == 0 ? "\r\n\r\n\r\n0." : iCash.ToString("#\r\n##,#\r\n###\r\n###") + ".";
            }
        }

        private Int32 _iBoost;
        public Int32 iBoost
        {
            get { return _iBoost; }
            set
            {
                if (_iBoost != value)
                {
                    _iBoost = value;
                    RaisePropertyChangedEvent("iBoost");
                    RaisePropertyChangedEvent("iBoostForView");
                }
            }
        }
        public String iBoostForView
        {
            get
            {
                return iBoost == 0 ? "\r\n\r\n\r\n0." : iBoost.ToString("#\r\n##,#\r\n###\r\n###") + ".";
            }
        }

        private Int16 _iPercentageOfLevelCompletion;
        public Int16 iPercentageOfLevelCompletion
        {
            get { return _iPercentageOfLevelCompletion; }
            set
            {
                if (_iPercentageOfLevelCompletion != value)
                {
                    _iPercentageOfLevelCompletion = value;
                    RaisePropertyChangedEvent("iPercentageOfLevelCompletion");
                }
            }
        }

        private Int32 _iReputationInLevel;
        public Int32 iReputationInLevel
        {
            get { return _iReputationInLevel; }
            set
            {
                if (_iReputationInLevel != value)
                {
                    _iReputationInLevel = value;
                    RaisePropertyChangedEvent("iReputationInLevel");
                }
            }
        }

        private Int32 _iReputationInTotal;
        public Int32 iReputationInTotal
        {
            get { return _iReputationInTotal; }
            set
            {
                if (_iReputationInTotal != value)
                {
                    _iReputationInTotal = value;
                    RaisePropertyChangedEvent("iReputationInTotal");
                }
            }
        }

        private Car _SelectedCar;
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

        private ObservableCollection<Car> _Cars = new ObservableCollection<Car>();
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
        public Persona(Int64 personaId, Int16 personaAvatarIndex, String personaName, String personaMotto, Int16 personaLevel, Int32 personaCash, Int32 personaBoost, Int16 personaPercentageOfLevel, Int32 personaReputationLevel, Int32 personaReputationTotal)
        {
            iId = personaId;
            shAvatarIndex = personaAvatarIndex;
            sName = personaName;
            sMotto = personaMotto;
            shLevel = personaLevel;
            iCash = personaCash;
            iBoost = personaBoost;
            iPercentageOfLevelCompletion = personaPercentageOfLevel;
            iReputationInLevel = personaReputationLevel;
            iReputationInTotal = personaReputationTotal;
            
            SQLiteCommand command = new SQLiteCommand("select * from Id" + personaId.ToString() + " order by ApiId asc", NfswSession.dbCarsConnection);
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
            iId = persona.iId;
            shAvatarIndex = persona.shAvatarIndex;
            sName = persona.sName;
            sMotto = persona.sMotto;
            shLevel = persona.shLevel;
            iCash = persona.iCash;
            iBoost = persona.iBoost;
            iPercentageOfLevelCompletion = persona.iPercentageOfLevelCompletion;
            iReputationInLevel = persona.iReputationInLevel;
            iReputationInTotal = persona.iReputationInTotal;

            SQLiteCommand command = new SQLiteCommand("select * from Id" + persona.iId.ToString() + " order by ApiId asc", NfswSession.dbCarsConnection);
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
                "   Id: " + iId.ToString() + Environment.NewLine +
                "   Avatar Index: " + shAvatarIndex.ToString() + Environment.NewLine +
                "   Name: " + sName + Environment.NewLine +
                "   Motto: " + sMotto + Environment.NewLine +
                "   Level: " + shLevel.ToString() + Environment.NewLine +
                "   Cash: " + iCash.ToString() + Environment.NewLine +
                "   Boost: " + iBoost.ToString() + Environment.NewLine +
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
                Persona dummyPersona = new Persona((Int64)reader[0], (Int16)reader[1], (String)reader[2], (String)reader[3], (Int16)reader[4], (Int32)reader[5], (Int32)reader[6], (Int16)reader[7], (Int32)reader[8], (Int32)reader[9]);
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