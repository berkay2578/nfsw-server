using OfflineServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Linq;

namespace Garage
{
    public class Car : ObservableObject
    {
        private Int32 _iId;
        private Int32 _iIndex;
        private Int64 _iPhysicsProfileHash;
        private Int32 _iBasketId;

        public Int32 iId
        {
            get { return _iId; }
            set
            {
                if (_iId != value)
                {
                    _iId = value;
                    RaisePropertyChangedEvent("iId");
                }
            }
        }
        public Int32 iIndex
        {
            get { return _iIndex; }
            set
            {
                if (_iIndex != value)
                {
                    _iIndex = value;
                    RaisePropertyChangedEvent("iIndex");
                }
            }
        }
        public Int64 iPhysicsProfileHash
        {
            get { return _iPhysicsProfileHash; }
            set
            {
                if (_iPhysicsProfileHash != value)
                {
                    _iPhysicsProfileHash = value;
                    RaisePropertyChangedEvent("iPhysicsProfileHash");
                }
            }
        }

        public String GetCarMakeAndModel()
        {
            return "";
        }
        public String GetCarPresetType(Int32 BasketIndex)
        {
            return "";
        }
        public XElement GetCarEntry()
        {
            return new XElement("null", "null");
        }
    }

    public class Cars : OfflineServer.ObservableObject, IEnumerable<Car>
    {
        private ObservableCollection<Car> _mCarsList;
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

        public void Add(Car newCarEntry)
        {
            mCarsList.Add(newCarEntry);
        }

        public Int32 iAmount
        {
            get
            {
                return mCarsList.Count;
            }
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

        private XNamespace srlNS = "http://schemas.datacontract.org/2004/07/Victory.DataLayer.Serialization";
        private XNamespace nilNS = "http://www.w3.org/2001/XMLSchema-instance";
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
                    new XAttribute("xmlns", srlNS),
                    new XAttribute(XNamespace.Xmlns + "i", nilNS),
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
            return docAllCars.ToString();
        }
    }
}