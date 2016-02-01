using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Garage
{
    public class Car : OfflineServer.ObservableObject
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
                Int32 calculate = 13;
                return calculate;
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
    }
}