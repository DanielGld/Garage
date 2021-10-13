namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eCarDoors m_NumOfDoors;

        public Car(Engine.eEngineType i_EngineType, string i_ModelName, string i_PlateNumber, float i_RemainingEnergyLevelPrecent, string i_Manufacture, float i_CurrentAirPressure)
            : base(i_ModelName, i_PlateNumber, i_RemainingEnergyLevelPrecent, 4, i_Manufacture, i_CurrentAirPressure, 32f)
        {
            if (i_EngineType is Engine.eEngineType.Fuel)
            {
                VehicleEngine = new FuelEngine(FuelEngine.eFuelType.Octan96, 60f, (i_RemainingEnergyLevelPrecent * 60f) / 100);
            }
            else if (i_EngineType is Engine.eEngineType.Electric)
            {
                VehicleEngine = new ElectricEngine(2.1f, (i_RemainingEnergyLevelPrecent * 2.1f) / 100);
            }

            RemainingEnergyLevelPrecent = i_RemainingEnergyLevelPrecent;
        }

        public enum eCarColor
        {
            Red = 1,
            White,
            Black,
            Silver
        }

        public enum eCarDoors
        {
            twoDoors = 2,
            threeDoors,
            fourDoors,
            fiveDoors
        }

        public eCarDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }

            set
            {
                m_CarColor = value;
            }
        }

        public override void VehicleCustomization(object i_firstValue, object i_SecondValue)
        {
            NumOfDoors = (eCarDoors)i_firstValue;
            CarColor = (eCarColor)i_SecondValue;
        }
    }
}
