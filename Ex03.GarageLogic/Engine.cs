using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float m_MaxCapacity;
        private float m_CurrentCapacity;

        protected Engine(float i_MaxCapacity, float i_CurrentCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrentCapacity = i_CurrentCapacity;
        }

        public enum eEngineType
        {
            Fuel = 1,
            Electric
        }

        public float MaxCapacity
        {
            get
            {
                return m_MaxCapacity;
            }
        }

        public float CurrentCapacity
        {
            get
            {
                return m_CurrentCapacity;
            }

            set
            {
                m_CurrentCapacity = value;
            }
        }
    }
}
