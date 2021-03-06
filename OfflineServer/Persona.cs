﻿using OfflineServer.Servers.Database.Entities;
using OfflineServer.Servers.Database.Management;
using OfflineServer.Servers.Http.Responses;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Data;
using System.Xml.Linq;

namespace OfflineServer
{
    /// <summary>
    /// Class containing all of the required variables and initializers to create and use a local Persona.
    /// </summary>
    public class Persona : ObservableObject
    {
        public static object carsLock = new object();
        public static object inventoryLock = new object();

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
        public Int32 score { get; set; }
        public Int32 rating { get; set; }
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>();
        public ObservableCollection<InventoryItem> Inventory { get; set; } = new ObservableCollection<InventoryItem>();

        public Int32 currentEventId { get; set; } = 0;
        public Int32 currentEventSessionId { get; set; } = 0;

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
        public String TimePlayed
        {
            get
            {
                return TimeSpan.FromMilliseconds(PersonaManagement.persona.timePlayed).ToString(@"hh\:mm\.ss");
            }
            set
            {
                RaisePropertyChangedEvent("TimePlayed");
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
                    PersonaManagement.persona.iconIndex = iconIndex;
                    PersonaManagement.persona.update();
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
                    PersonaManagement.persona.name = value;
                    PersonaManagement.persona.update();
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
                    PersonaManagement.persona.motto = value;
                    PersonaManagement.persona.update();
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
                    value = Math.Min(Data.DataEx.maxLevel, value);
                    level = value;
                    PersonaManagement.persona.level = value;
                    PersonaManagement.persona.update();
                    RaisePropertyChangedEvent("Level");
                    RaisePropertyChangedEvent("ReputationRequiredToPassTheLevel");
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
                    PersonaManagement.persona.cash = value;
                    PersonaManagement.persona.update();
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
                    PersonaManagement.persona.boost = value;
                    PersonaManagement.persona.update();
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
                    PersonaManagement.persona.percentageOfLevelCompletion = value;
                    PersonaManagement.persona.update();
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
                    // Passed level
                    if (ReputationRequiredToPassTheLevel <= reputationInLevel + value)
                    {
                        Int32 maxLevel = Data.DataEx.maxLevel;
                        if (level < maxLevel)
                        {
                            if (level + 1 == maxLevel)
                            {
                                value = 0;
                                Level++;
                            }
                            else
                            {
                                Int32 extraExp;
                                do
                                {
                                    extraExp = Math.Abs(ReputationRequiredToPassTheLevel - value);
                                    reputationInLevel = extraExp;
                                    Level++;
                                } while (extraExp >= ReputationRequiredToPassTheLevel);
                                value = extraExp;
                            }
                        }
                        else
                        {
                            value = 0;
                        }
                    }

                    // Lost exp
                    if (Math.Sign(value) == -1)
                    {
                        if (level == 1)
                        {
                            value = 0;
                        }
                        else
                        {
                            // Dropped level
                            if (ReputationRequiredToPassTheLevel + value < 0)
                            {
                                Int32 expMissingInNewLevel;
                                do
                                {
                                    Int32 levelBaseExp = Data.DataEx.getRequiredLexelXP(level, 0);
                                    Int32 newLevelBaseExp = Data.DataEx.getRequiredLexelXP(level - 1, 0);
                                    expMissingInNewLevel = Math.Abs(ReputationRequiredToPassTheLevel + value);
                                    value = newLevelBaseExp - expMissingInNewLevel;

                                    Level--;
                                    if (level == 1)
                                    {
                                        value = 0;
                                        break;
                                    }
                                } while (expMissingInNewLevel != 0);
                            }
                        }
                    }

                    reputationInLevel = value;
                    PersonaManagement.persona.reputationInLevel = value;
                    PersonaManagement.persona.update();
                    RaisePropertyChangedEvent("ReputationInLevel");
                    RaisePropertyChangedEvent("ReputationRequiredToPassTheLevel");
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
                    ReputationInLevel += value;
                    PersonaManagement.persona.reputationInTotal = value;
                    PersonaManagement.persona.update();
                    RaisePropertyChangedEvent("ReputationInTotal");
                    RaisePropertyChangedEvent("ReputationRequiredToPassTheLevel");
                }
            }
        }
        public Int32 ReputationRequiredToPassTheLevel
        {
            get
            {
                return Data.DataEx.getRequiredLexelXP(level, reputationInLevel);
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
                    PersonaManagement.persona.currentCarIndex = value;
                    PersonaManagement.persona.update();
                    RaisePropertyChangedEvent("CurrentCarIndex");
                    RaisePropertyChangedEvent("SelectedCar");
                }
            }
        }
        public Car SelectedCar
        {
            get
            {
                if (currentCarIndex >= Cars.Count)
                    CurrentCarIndex = 0;

                if (currentCarIndex != -1)
                    return Cars[currentCarIndex];

                return null;
            }
        }

        /// <summary>
        /// Initializes the Persona class with the given persona entity.
        /// </summary>
        public Persona(PersonaEntity persona)
        {
            App.Current.Dispatcher.Invoke(() =>
                BindingOperations.EnableCollectionSynchronization(Cars, carsLock));
            App.Current.Dispatcher.Invoke(() =>
                BindingOperations.EnableCollectionSynchronization(Inventory, inventoryLock));

            id = persona.id;
            iconIndex = persona.iconIndex;
            name = persona.name;
            motto = persona.motto;
            level = persona.level;
            cash = persona.cash;
            boost = persona.boost;
            percentageOfLevelCompletion = persona.percentageOfLevelCompletion;
            reputationInLevel = persona.reputationInLevel;
            reputationInTotal = persona.reputationInTotal;
            currentCarIndex = persona.currentCarIndex;

            foreach (CarEntity car in persona.garage)
                Cars.Add(new Car(car));

            foreach (InventoryItemEntity inventoryItemEntity in persona.inventory)
                Inventory.Add(new InventoryItem(inventoryItemEntity));
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
        /// Reads the complete garage of the current active persona.
        /// </summary>
        /// <returns>A string instance containing all of the persona's cars in indented XML.</returns>
        public String getCompleteGarage()
        {
            XElement carEntries = new XElement("CarsOwnedByPersona");
            foreach (Car carEntry in Cars)
            {
                carEntries.Add(carEntry.getCarEntry());
            }

            XDocument docAllCars = new XDocument(
                new XDeclaration("1.0", Encoding.UTF8.HeaderName, String.Empty),
                new XElement("CarSlotInfoTrans",
                    carEntries,
                    new XElement("DefaultOwnedCarIndex", currentCarIndex),
                    new XElement("ObtainableSlots",
                        Basket.getProductTransactionEntry
                        (
                            Basket.Currency.Boost,
                            "Grants you 1 extra car slot.",
                            0,
                            -1143680669,
                            "128_cash",
                            0,
                            "Only for 100 boost you will get new a car slot instantly!",
                            100,
                            0,
                            "CARSLOT",
                            "Car Slot",
                            Basket.GameItemType.CarSlot,
                            Basket.Special.None
                        )
                    ),
                    new XElement("OwnedCarSlotsCount", "100")
                )
            );
            docAllCars.Root.SetDefaultXmlNamespace(XNamespace.Get("http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization"));
            return docAllCars.ToString();
        }

        public InventoryTrans getCompleteInventory()
        {
            InventoryTrans inventoryTrans = new InventoryTrans();
            foreach (InventoryItem inventoryItem in Inventory)
                inventoryTrans.inventoryItems.Add(inventoryItem.getInventoryItemTrans());

            return inventoryTrans;
        }
    }
}