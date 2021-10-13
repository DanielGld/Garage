using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Owner> m_VehiclesInTheGarage = new Dictionary<string, Owner>();

        public enum eVehicleStatus
        {
            inRepair = 1,
            completed,
            paid
        }

        public Dictionary<string, Owner> VehiclesInTheGarage
        {
            get
            {
                return m_VehiclesInTheGarage;
            }

            set
            {
                m_VehiclesInTheGarage = value;
            }
        }

        public string PrintVehicleData(string i_plateNumber)
        {
            string vehicleData = null;
            if (VehiclesInTheGarage.ContainsKey(i_plateNumber))
            {
                Owner owner = VehiclesInTheGarage[i_plateNumber];

                vehicleData = string.Format(
    @"=======================================
             Plate number:
               -{0}-
Model name: {1}
First Name: {2}
Phone number: {3}
Car status: {4}
Wheel manufacture: {5}
Wheel max air pressure: {6}
Wheel current air pressure: {7}
Remaining energy level in precent: {8}
Engine type: {9}
=======================================",
            owner.Vehicle.PlateNumber, owner.Vehicle.ModelName, owner.OwnerName, owner.PhoneNumber,
            owner.Vehicle.CarStatus, owner.Vehicle.m_VehicleWheels[0].Manufacture,
            owner.Vehicle.m_VehicleWheels[0].MaxAirPressure, owner.Vehicle.m_VehicleWheels[0].CurrentAirPressure,
            owner.Vehicle.RemainingEnergyLevelPrecent, owner.Vehicle.VehicleEngine.GetType().Name);
            }
            else
            {
                vehicleData = "vehicle is not in the garage";
            }

            return vehicleData;
        }

        public StringBuilder GetAllVehiclePlateNumbersByStatus(Garage.eVehicleStatus i_CarStatus)
        {
            StringBuilder allPlateNumbersByStatus = new StringBuilder();
            if (VehiclesInTheGarage != null)
            {
                foreach (string plateNumber in VehiclesInTheGarage.Keys)
                {
                    if (i_CarStatus == 0)
                    {
                        allPlateNumbersByStatus.AppendLine(plateNumber);
                    }
                    else
                    {
                        if (i_CarStatus == VehiclesInTheGarage[plateNumber].Vehicle.CarStatus)
                        {
                            allPlateNumbersByStatus.AppendLine(plateNumber);
                        }
                    }
                }
            }
            else
            {
                throw new System.ArgumentNullException();
            }

            return allPlateNumbersByStatus;
        }

        public void ChangeCarStatus(string i_PlateNumber, eVehicleStatus i_CarStatus)
        {
            if (VehiclesInTheGarage.ContainsKey(i_PlateNumber))
            {
                if (VehiclesInTheGarage[i_PlateNumber].Vehicle != null)
                {
                    VehiclesInTheGarage[i_PlateNumber].Vehicle.CarStatus = i_CarStatus;
                }
                else
                {
                    throw new System.ArgumentNullException();
                }
            }
            else
            {
                throw new System.ArgumentNullException();
            }
        }

        public void InflateWheels(string i_PlateNumber)
        {
            if (VehiclesInTheGarage.ContainsKey(i_PlateNumber))
            {
                float amountToAdd;
                foreach (Wheel wheel in VehiclesInTheGarage[i_PlateNumber].Vehicle.m_VehicleWheels)
                {
                    if (wheel == null)
                    {
                        throw new System.ArgumentNullException();
                    }

                    amountToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                    wheel.InflatWheel(amountToAdd);
                }
            }
        }

        public void FuelVehicle(string i_PlateNumber, FuelEngine.eFuelType i_FuelType, float i_AmountToAdd)
        {
            if (i_FuelType == ((FuelEngine)VehiclesInTheGarage[i_PlateNumber].Vehicle.VehicleEngine).FuelType)
            {
                ((FuelEngine)VehiclesInTheGarage[i_PlateNumber].Vehicle.VehicleEngine).Refuel(i_AmountToAdd);
            }
            else
            {
                throw new System.ArgumentException("Invalid fuel type!");
            }
        }

        public void ChargeVehicle(string i_PlateNumber, float i_AmountToAdd)
        {
            ((ElectricEngine)VehiclesInTheGarage[i_PlateNumber].Vehicle.VehicleEngine).ReCharge(i_AmountToAdd / 60);
        }

        public void VehicleCustomization(Vehicle i_Vehicle, object i_FirstParm, object i_SeconedParm)
        {
            if (i_Vehicle is Car)
            {
                i_Vehicle = i_Vehicle as Car;
                i_Vehicle.VehicleCustomization(i_FirstParm, i_SeconedParm);
            }
            else if (i_Vehicle is MotorCycle)
            {
                i_Vehicle = i_Vehicle as MotorCycle;
                i_Vehicle.VehicleCustomization(i_FirstParm, i_SeconedParm);
            }
            else if (i_Vehicle is Truck)
            {
                i_Vehicle = i_Vehicle as Truck;
                i_Vehicle.VehicleCustomization(i_FirstParm, i_SeconedParm);
            }
            else
            {
                throw new System.ArgumentException();
            }
        }
    }
}