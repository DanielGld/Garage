namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public MotorCycle(Engine.eEngineType i_EngineType, string i_ModelName, string i_PlateNumber, float i_RemainingEnergyLevelPrecent, string i_Manufacture, float i_CurrentAirPressure)
            : base(i_ModelName, i_PlateNumber, i_RemainingEnergyLevelPrecent, 2, i_Manufacture, i_CurrentAirPressure, 30f)
        {
            if (i_EngineType == Engine.eEngineType.Fuel)
            {
                VehicleEngine = new FuelEngine(FuelEngine.eFuelType.Octan95, 7f, (i_RemainingEnergyLevelPrecent * 7f) / 100);
            }
            else if (i_EngineType == Engine.eEngineType.Electric)
            {
                VehicleEngine = new ElectricEngine(1.2f, (i_RemainingEnergyLevelPrecent * 1.2f) / 100);
            }

            RemainingEnergyLevelPrecent = i_RemainingEnergyLevelPrecent;
        }

        public enum eLicenseType
        {
            A = 1,
            A1,
            AA,
            B
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public override void VehicleCustomization(object i_firstValue, object i_SecondValue)
        {
            LicenseType = (eLicenseType)i_firstValue;
            EngineVolume = (int)i_SecondValue;
        }
    }
}
