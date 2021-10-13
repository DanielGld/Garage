namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoVolume;
        private bool m_HaveDangerousSubstance;

        public Truck(Engine.eEngineType i_EngineType, string i_ModelName, string i_PlateNumber, float i_RemainingEnergyLevelPrecent, string i_Manufacture, float i_CurrentAirPressure)
           : base(i_ModelName, i_PlateNumber, i_RemainingEnergyLevelPrecent, 16, i_Manufacture, i_CurrentAirPressure, 28f)
        {
            if (i_EngineType is Engine.eEngineType.Fuel)
            {
                VehicleEngine = new FuelEngine(FuelEngine.eFuelType.Soler, 120f, (i_RemainingEnergyLevelPrecent * 120f) / 100);
            }

            RemainingEnergyLevelPrecent = i_RemainingEnergyLevelPrecent;
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }

            set
            {
                m_CargoVolume = value;
            }
        }

        public bool HaveDangerousSubstance
        {
            get
            {
                return m_HaveDangerousSubstance;
            }

            set
            {
                m_HaveDangerousSubstance = value;
            }
        }

        public override void VehicleCustomization(object i_FirstValue, object i_SecondValue)
        {
            HaveDangerousSubstance = (bool)i_FirstValue;
            CargoVolume = (float)i_SecondValue;
        }
    }
}
