using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class FuelEngine : Engine
    {
        readonly private eFuelType m_FuelType;

        public FuelEngine(eFuelType i_FuelType, float i_MaxCapacity, float i_CurrentCapacityInPrecent) : base(i_MaxCapacity, i_CurrentCapacityInPrecent)
        {
            m_FuelType = i_FuelType;
        }

        public enum eFuelType
        {
            Octan95 = 95,
            Octan96 = 96,
            Octan98 = 98,
            Soler
        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                m_FuelType = value;
            }
        }

        public void Refuel(float i_AmountToAdd)
        {
            if (i_AmountToAdd + CurrentCapacity < MaxCapacity)
            {
                CurrentCapacity += i_AmountToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxCapacity - CurrentCapacity);
            }
        }
    }
}
