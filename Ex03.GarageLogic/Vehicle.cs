using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public List<Wheel> m_VehicleWheels = new List<Wheel>();
        private readonly string m_ModelName;
        private readonly string m_PlateNumber;
        private float m_RemainingEnergyLevelPrecent;
        private Garage.eVehicleStatus m_CarStatus;
        private Engine m_VehicleEngine;

        protected Vehicle(string i_ModelName, string i_PlateNumber, float i_RemainingEnergyLevelInPrecent, int i_NumOfWheels, string i_Manufacture, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_ModelName = i_ModelName;
            m_PlateNumber = i_PlateNumber;
            m_RemainingEnergyLevelPrecent = i_RemainingEnergyLevelInPrecent;
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_Manufacture, i_CurrentAirPressure, i_MaxAirPressure));
            }
        }

        public Garage.eVehicleStatus CarStatus
        {
            get
            {
                return m_CarStatus;
            }

            set
            {
                m_CarStatus = value;
            }
        }

        public Engine VehicleEngine
        {
            get
            {
                return m_VehicleEngine;
            }

            set
            {
                m_VehicleEngine = value;
            }
        }

        public string ModelName
        {
            get
            {
                return this.m_ModelName;
            }
        }

        public string PlateNumber
        {
            get
            {
                return this.m_PlateNumber;
            }
        }

        public float RemainingEnergyLevelPrecent
        {
            get
            {
                return m_RemainingEnergyLevelPrecent;
            }

            set
            {
                m_RemainingEnergyLevelPrecent = value;
            }
        }

        public abstract void VehicleCustomization(object i_firstValue, object i_SecondValue);
    }
}