using System;
using System.Collections;
using System.Collections.Generic;

namespace Garage
{
    public class Car
    {
        public Int32 iCarId;
        public Int32 iCarIndex;
        public Int64 iPhysicsProfileHash;
    }

    public class Cars : IEnumerable<Car>
    {
        private List<Car> mCarsArray;

        public void Add(Car newCarEntry)
        {
            mCarsArray.Add(newCarEntry);
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
            foreach (Car CarEntry in mCarsArray)
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