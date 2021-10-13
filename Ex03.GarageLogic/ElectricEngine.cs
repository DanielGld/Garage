using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxCapacity, float i_CurrentCapacity) : base(i_MaxCapacity, i_CurrentCapacity)
        {
        }

        public void ReCharge(float i_AmountToAdd)
        {
            if (i_AmountToAdd + CurrentCapacity <= MaxCapacity)
            {
                CurrentCapacity += i_AmountToAdd;
            }
        }
    }
}
