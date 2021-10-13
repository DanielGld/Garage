using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base(string.Format("Error! value out of range must be between {0} and {1}", i_MinValue, i_MaxValue))
        {
        }
    }
}
