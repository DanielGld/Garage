namespace Ex03.GarageLogic
{
    public class Owner
    {
        private readonly string m_OwnerName;
        private readonly string m_OwnerPhoneNumber;
        private readonly Vehicle m_VehicleOwner;

        public Owner(string i_OwnerName, string i_OwnerPhoneNumber, ref Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleOwner = i_Vehicle;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_VehicleOwner;
            }
        }
    }
}