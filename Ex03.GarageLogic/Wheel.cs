using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class Wheel
    {
        private readonly float r_MaxAirPressure;
        private string m_Manufacture;
        private float m_CurrentAirPressure;

        public Wheel(string i_Manufacture, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacture = i_Manufacture;
            r_MaxAirPressure = i_MaxAirPressure;
            m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public string Manufacture
        {
            get
            {
                return this.m_Manufacture;
            }

            set
            {
                this.m_Manufacture = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return this.r_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return this.m_CurrentAirPressure;
            }

            set
            {
                this.m_CurrentAirPressure = value;
            }
        }

        public void InflatWheel(float i_AmountToAdd)
        {
            if (i_AmountToAdd + CurrentAirPressure <= MaxAirPressure)
            {
                CurrentAirPressure += i_AmountToAdd;
            }
        }
    }
}
