using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class GarageManagerUI
    {
        private Garage m_Garage = new Garage();

        internal void UserMenu()
        {
            int userInput;
            string displayMenu = string.Format(
@"1. To enter you vehicle to the garage press 1.
2. To view the plate numbers of the vehicles in the garage press 2.
3. To change the vehicle status press 3.
4. To inflate your wheels press 4.
5. To fuel your vehicle press 5.
6. To charge your vehicle press 6.
7. To view all the date for your vehicle press 7.
8. To quit press 0.
");
            do
            {
                System.Console.WriteLine(displayMenu);
                userInput = IsInRangeInt(0, 7);
                switch (userInput)
                {
                    case 1:
                        {
                            enterVehiclToGarage();
                            break;
                        }

                    case 2:
                        {
                            PrintAllVehicleByStatus();
                            break;
                        }

                    case 3:
                        {
                            ChangeCarStatus();
                            break;
                        }

                    case 4:
                        {
                            InflateWheelsToMax();
                            break;
                        }

                    case 5:
                        {
                            RefuelVehicle();
                            break;
                        }

                    case 6:
                        {
                            ReChargeVehicle();
                            break;
                        }

                    case 7:
                        {
                            PrintAllDataByPlateNumber();
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                System.Console.Write("press any key to continue.");
                System.Console.ReadLine();
                System.Console.Clear();
            }
            while (userInput != 0);
        }

        private void enterVehiclToGarage()
        {
            int customerVehicleType;
            string fuelVehiclesStr;
            string electricVehiclesStr;
            string plateNumberStr;
            string engineTypeStr;
            Engine.eEngineType engineType;
            Owner owner;
            Vehicle vehicle = null;

            engineTypeStr = string.Format(
@"Please choose the vehicle type you have:
if you have a fuel vehicle  press 1.
if you have an electric vehicle press 2.
");
            fuelVehiclesStr = string.Format(
@"Please choose the vehicle you have:
if you have a car press 1.
if you have a motorcycle press 2.
if you have a truck press 3.
");
            electricVehiclesStr = string.Format(
@"Please choose the vehicle you have:
if you have a car press 1.
if you have a motorcycle press 2.");

            System.Console.Write("Please enter your plate number (6-8 digits): ");
            System.Console.WriteLine();
            plateNumberStr = IsCorrectLengthString(6, 8);
            if (!m_Garage.VehiclesInTheGarage.ContainsKey(plateNumberStr))
            {
                System.Console.WriteLine(engineTypeStr);
                engineType = (Engine.eEngineType)IsInRangeInt(1, 2);
                if (engineType is Engine.eEngineType.Fuel)
                {
                    System.Console.WriteLine(fuelVehiclesStr);
                    customerVehicleType = IsInRangeInt(1, 3);
                    if (customerVehicleType == 1)
                    {
                        vehicle = GetVehicleInfoAndCreate(customerVehicleType, plateNumberStr, engineType, 32);
                        getCarCustomization(vehicle as Car);
                    }
                    else if (customerVehicleType == 2)
                    {
                        vehicle = GetVehicleInfoAndCreate(customerVehicleType, plateNumberStr, engineType, 30);
                        GetMotorcycleCustomization(vehicle as MotorCycle);
                    }
                    else if (customerVehicleType == 3)
                    {
                        vehicle = GetVehicleInfoAndCreate(customerVehicleType, plateNumberStr, engineType, 28);
                        GetTruckCustomization(vehicle as Truck);
                    }
                }
                else if (engineType is Engine.eEngineType.Electric)
                {
                    System.Console.WriteLine(electricVehiclesStr);
                    customerVehicleType = IsInRangeInt(1, 2);
                    if (customerVehicleType == 1)
                    {
                        vehicle = GetVehicleInfoAndCreate(customerVehicleType, plateNumberStr, engineType, 32);
                        getCarCustomization(vehicle as Car);
                    }
                    else if (customerVehicleType == 2)
                    {
                        vehicle = GetVehicleInfoAndCreate(customerVehicleType, plateNumberStr, engineType, 30);
                        GetMotorcycleCustomization(vehicle as MotorCycle);
                    }
                }

                owner = CreateOwner(vehicle);
                m_Garage.VehiclesInTheGarage.Add(owner.Vehicle.PlateNumber, owner);
            }
            else
            {
                m_Garage.VehiclesInTheGarage[plateNumberStr].Vehicle.CarStatus = Garage.eVehicleStatus.inRepair;
                System.Console.WriteLine("Vehicle already in the garage");
            }
        }

        private void getCarCustomization(Car i_Car)
        {
            string displayDoorOptions = string.Format(@"
Please enter the number of doors in your car: 
for 2 doors car press 2.
for 3 doors car press 3.
for 4 doors car press 4.
for 5 doors car press 5.
");

            string displayColorOptions = string.Format(@"
Please enter your car color:
if your car is red press 1.
if your car is white press 2.
if your car is black press 3.
if your car is silver press 4.
");
            Car.eCarDoors numOfDoors;
            Car.eCarColor carColor;
            try
            {
                System.Console.WriteLine(displayDoorOptions);
                numOfDoors = (Car.eCarDoors)IsInRangeInt(2, 5);
                System.Console.WriteLine(displayColorOptions);
                carColor = (Car.eCarColor)IsInRangeInt(1, 4);
                m_Garage.VehicleCustomization(i_Car, numOfDoors, carColor);
            }
            catch (ArgumentException)
            {
            }
        }

        private void GetMotorcycleCustomization(MotorCycle i_Motorcycle)
        {
            string displayLicenseTypeOptions = string.Format(@"
Please enter your license type: 
if you have type A press 1.
if you have type A1 press 2.
if you have type AA press 3.
if you have type B press 4.
");

            MotorCycle.eLicenseType licenseType;
            int engineVolume;

            try
            {
                System.Console.WriteLine(displayLicenseTypeOptions);
                licenseType = (MotorCycle.eLicenseType)IsInRangeInt(1, 4);
                System.Console.WriteLine("Please enter the motorcycle engine volume: ");
                engineVolume = IsInRangeInt(1, 1000);
                m_Garage.VehicleCustomization(i_Motorcycle, licenseType, engineVolume);
            }
            catch (ArgumentException)
            {
            }
        }

        private void GetTruckCustomization(Truck i_Truck)
        {
            string displayDangerousSubstanceOptions = string.Format(@"
if your truck carry a dangerous substance press 1
if not press 0.
");
            bool isDangerousSubstance = true;
            float cargoVolume;

            try
            {
                System.Console.WriteLine(displayDangerousSubstanceOptions);
                isDangerousSubstance = StringToBool();
                System.Console.WriteLine("Please enter the truck cargo volume: ");
                cargoVolume = IsInRangeFloat(1, 5000);
                m_Garage.VehicleCustomization(i_Truck, isDangerousSubstance, cargoVolume);
            }
            catch (ArgumentException)
            {
            }
        }

        private Vehicle GetVehicleInfoAndCreate(int i_VehicleType, string i_PlateNumberStr, Engine.eEngineType i_EngineType, float i_maxValue)
        {
            string modelNameStr;
            string manufactureStr;
            float remainingEnergyLevel;
            float currentAirPressure;
            Vehicle vehicle = null;
            try
            {
                System.Console.WriteLine("Plase enter the following information about your vehicle");
                System.Console.Write("model name: ");
                modelNameStr = IsCorrectLengthString(1, 15);
                System.Console.WriteLine();
                System.Console.Write("remaining energy level in the tank in precent: ");
                remainingEnergyLevel = IsInRangeFloat(0, 100);
                System.Console.WriteLine();
                System.Console.Write("wheels manufacture name: ");
                manufactureStr = IsCorrectLengthString(0, 15);
                System.Console.WriteLine();
                System.Console.Write("current air pressure in the wheels: ");
                currentAirPressure = IsInRangeFloat(0, i_maxValue);
                System.Console.WriteLine();
                vehicle = ObjectsCreation.CreateVehicle(i_VehicleType, i_EngineType, modelNameStr, i_PlateNumberStr, remainingEnergyLevel, manufactureStr, currentAirPressure);
            }
            catch (ArgumentException)
            {
            }

            return vehicle;
        }

        private Owner CreateOwner(Vehicle i_Vehicle)
        {
            string name;
            string phoneNum;
            Owner owner = null;
            System.Console.WriteLine("Please enter your name: ");
            name = CehckOwnerName();
            System.Console.WriteLine("Please enter your phone number: ");
            phoneNum = CehckOwnerPhoneNumber();
            owner = ObjectsCreation.CreateOwner(name, phoneNum, ref i_Vehicle);

            return owner;
        }

        private void PrintAllDataByPlateNumber()
        {
            string userInput;

            System.Console.Write("Please enter your plate number: ");
            System.Console.WriteLine();
            userInput = System.Console.ReadLine();
            System.Console.WriteLine(m_Garage.PrintVehicleData(userInput));
        }

        private void PrintAllVehicleByStatus()
        {
            int userInput;
            Garage.eVehicleStatus carStatus;
            StringBuilder plateNumbers;

            string displayOptions = string.Format(@"
To view all the vehicle in the garage press 0.
To view inrepair status press 1.
To view completed status press 2.
To view paid status press 3.");
            try
            {
                System.Console.WriteLine(displayOptions);
                userInput = IsInRangeInt(0, 3);
                carStatus = (Garage.eVehicleStatus)userInput;
                plateNumbers = m_Garage.GetAllVehiclePlateNumbersByStatus(carStatus);
                System.Console.WriteLine(plateNumbers);
                System.Console.WriteLine();
            }
            catch (ArgumentNullException)
            {
            }
        }

        private void ChangeCarStatus()
        {
            string userOptions = string.Format(
@"please enter the new status:
for inrepair press 1.
for completed press 2.
for paid press 3.
");

            string plateNumber;
            int userInput;
            Garage.eVehicleStatus carStatus;
            try
            {
                System.Console.Write("Please enter your plate number: ");
                plateNumber = System.Console.ReadLine();
                System.Console.WriteLine();
                if (m_Garage.VehiclesInTheGarage.ContainsKey(plateNumber))
                {
                    System.Console.Write(userOptions);
                    userInput = IsInRangeInt(1, 3);
                    carStatus = (Garage.eVehicleStatus)userInput;
                    m_Garage.ChangeCarStatus(plateNumber, carStatus);
                }
                else
                {
                    System.Console.WriteLine("Vehicle is not in the garage.");
                }
            }
            catch (ArgumentNullException)
            {
            }
        }

        private void InflateWheelsToMax()
        {
            string plateNumber;
            try
            {
                System.Console.Write("Please enter your plate number: ");
                plateNumber = System.Console.ReadLine();
                if (m_Garage.VehiclesInTheGarage.ContainsKey(plateNumber))
                {
                    m_Garage.InflateWheels(plateNumber);
                }
                else
                {
                    System.Console.WriteLine("Vehicle is not in the garage.");
                }
            }
            catch (ArgumentNullException)
            {
            }
        }

        private int IsInRangeInt(int i_MinValue, int i_MaxValue)
        {
            int userInput;
            bool isValid = true;
            do
            {
                isValid = int.TryParse(Console.ReadLine(), out userInput);
                if (userInput < i_MinValue || userInput > i_MaxValue || !isValid)
                {
                    isValid = false;
                    System.Console.Write("Error! Invalid input please try again ");
                }
            }
            while (!isValid);

            return userInput;
        }

        private float IsInRangeFloat(float i_MinValue, float i_MaxValue)
        {
            float userInput;
            bool isValid = true;
            do
            {
                isValid = float.TryParse(Console.ReadLine(), out userInput);
                if (userInput < i_MinValue || userInput > i_MaxValue || !isValid)
                {
                    isValid = false;
                    System.Console.Write("Error! Invalid input please try again ");
                }
            }
            while (!isValid);

            return userInput;
        }

        private string IsCorrectLengthString(int i_MinLength, int i_MaxLength)
        {
            bool isValid = true;
            string userInput;
            do
            {
                isValid = true;
                userInput = System.Console.ReadLine();
                if (userInput.Length < i_MinLength || userInput.Length > i_MaxLength)
                {
                    System.Console.WriteLine("Error! invliad input please try again");
                    isValid = false;
                }
            }
            while (!isValid);

            return userInput;
        }

        private string CehckOwnerName()
        {
            bool isValid = true;
            string userInput;
            do
            {
                isValid = true;
                userInput = System.Console.ReadLine();
                if (userInput.Length < 2 || !userInput.All(char.IsLetter))
                {
                    System.Console.WriteLine("Error! Invalid name please try again.");
                    isValid = false;
                }
            }
            while (!isValid);

            return userInput;
        }

        private string CehckOwnerPhoneNumber()
        {
            bool isValid = true;
            string userInput;
            do
            {
                isValid = true;
                userInput = System.Console.ReadLine();
                if (userInput.Length != 10 || !userInput.All(char.IsDigit))
                {
                    System.Console.WriteLine("Error! Invalid phone number please try again.");
                    isValid = false;
                }
            }
            while (!isValid);

            return userInput;
        }

        private void RefuelVehicle()
        {
            string plateNum;
            FuelEngine.eFuelType fuelType;
            float amountToAdd;

            string userOptions = string.Format(
@"please enter your fuel type
for 95 press 1.
for 96 press 2.
for 98 press 3.
for soler press 4.
");
            System.Console.WriteLine("Please enter you plate number: ");
            plateNum = System.Console.ReadLine();
            System.Console.WriteLine();
            if (m_Garage.VehiclesInTheGarage.ContainsKey(plateNum))
            {
                if (m_Garage.VehiclesInTheGarage[plateNum].Vehicle.VehicleEngine is FuelEngine)
                {
                    System.Console.WriteLine(userOptions);
                    fuelType = (FuelEngine.eFuelType)(94 + IsInRangeInt(1, 4));
                    System.Console.WriteLine("please enter how much fuel do you want to add in liters: ");
                    amountToAdd = IsInRangeFloat(0, 500);
                    try
                    {
                        m_Garage.FuelVehicle(plateNum, fuelType, amountToAdd);
                    }
                    catch (ArgumentException arge)
                    {
                        Console.WriteLine(arge.Message);
                        System.Console.WriteLine();
                    }
                    catch (ValueOutOfRangeException voore)
                    {
                        Console.WriteLine(voore.Message);
                        System.Console.WriteLine();
                    }
                }
                else
                {
                    System.Console.WriteLine("this vehicle engine is not fuel engine!.");
                    System.Console.WriteLine();
                }
            }
            else
            {
                System.Console.WriteLine("Vehicle is not in the garage.");
                System.Console.WriteLine();
            }
        }

        private void ReChargeVehicle()
        {
            string plateNum;
            float amountToAdd;

            System.Console.WriteLine("Please enter you plate number: ");
            plateNum = System.Console.ReadLine();
            if (m_Garage.VehiclesInTheGarage.ContainsKey(plateNum))
            {
                if (m_Garage.VehiclesInTheGarage[plateNum].Vehicle.VehicleEngine is ElectricEngine)
                {
                    System.Console.WriteLine("please enter how much time to add to your battery in minutes: ");
                    amountToAdd = IsInRangeFloat(0, 126);
                    m_Garage.ChargeVehicle(plateNum, amountToAdd);
                }
                else
                {
                    System.Console.WriteLine("this vehicle engine is not an electric engine!.");
                }
            }
            else
            {
                System.Console.WriteLine("Vehicle is not in the garage.");
            }
        }

        private bool StringToBool()
        {
            string userInput;
            bool userChocie = true;
            bool isValidInput = true;
            do
            {
                isValidInput = true;
                userInput = System.Console.ReadLine();
                if (userInput.Equals("1"))
                {
                    userChocie = true;
                }
                else if (userInput.Equals("0"))
                {
                    userChocie = false;
                }
                else
                {
                    isValidInput = false;
                    System.Console.WriteLine("Error! invalid input please try again");
                }
            }
            while (!isValidInput);
            return userChocie;
        }
    }
}