namespace Ex03.GarageLogic
{
    public class ObjectsCreation
    {
        public static Vehicle CreateVehicle(int i_VehicleType, Engine.eEngineType i_EngineType, string i_ModelName, string i_PlateNumber, float i_RemainingEnergyLevel, string i_Manufacture, float i_CurrentAirPressure)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case 1:
                    {
                        newVehicle = new Car(i_EngineType, i_ModelName, i_PlateNumber, i_RemainingEnergyLevel, i_Manufacture, i_CurrentAirPressure);
                        break;
                    }

                case 2:
                    {
                        newVehicle = new MotorCycle(i_EngineType, i_ModelName, i_PlateNumber, i_RemainingEnergyLevel, i_Manufacture, i_CurrentAirPressure);
                        break;
                    }

                case 3:
                    {
                        newVehicle = new Truck(i_EngineType, i_ModelName, i_PlateNumber, i_RemainingEnergyLevel, i_Manufacture, i_CurrentAirPressure);
                        break;
                    }

                default:
                    {
                        throw new System.ArgumentException();
                    }
            }

            newVehicle.CarStatus = Garage.eVehicleStatus.inRepair;

            return newVehicle;
        }

        public static Owner CreateOwner(string i_OwnerName, string i_OwnerPhone, ref Vehicle i_Vehicle)
        {
            return new Owner(i_OwnerName, i_OwnerPhone, ref i_Vehicle);
        }
    }
}